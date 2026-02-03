// ---------------------------------------------------------------------------------------
//                                  SpawnDev.ILGPU.WebGPU
//                         Copyright (c) 2024 SpawnDev Project
//
// File: WGSLKernelFunctionGenerator.cs
// ---------------------------------------------------------------------------------------

using global::ILGPU.Backends.EntryPoints;
using global::ILGPU.IR;
using global::ILGPU.IR.Analyses;
using global::ILGPU.IR.Types;
using global::ILGPU.IR.Values;
using global::ILGPU;
using System.Text;
using System;

namespace SpawnDev.ILGPU.WebGPU.Backend
{
    internal sealed class WGSLKernelFunctionGenerator : WGSLCodeGenerator
    {
        #region Instance

        public WGSLKernelFunctionGenerator(
            in GeneratorArgs args,
            Method method,
            Allocas allocas)
            : base(args, method, allocas)
        {
            EntryPoint = args.EntryPoint;
            DynamicSharedAllocations = args.DynamicSharedAllocations;
        }

        #endregion

        #region Properties

        public EntryPoint EntryPoint { get; }
        public AllocaKindInformation DynamicSharedAllocations { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Helper to unwrap Pointer/ByRef types to get the underlying StructureType.
        /// </summary>
        private TypeNode UnwrapType(TypeNode type)
        {
            var current = type;
            while (current != null)
            {
                if (current is PointerType ptr)
                {
                    current = ptr.ElementType;
                    continue;
                }
                return current;
            }
            return type;
        }

        public override void GenerateHeader(StringBuilder builder)
        {
            int bindingIdx = 0;
            int paramOffset = EntryPoint.IsExplicitlyGrouped ? 0 : 1;

            foreach (var param in Method.Parameters)
            {
                if (param.Index < paramOffset)
                    continue;

                var elementType = GetBufferElementType(param.ParameterType);
                var wgslType = TypeGenerator[elementType];
                string accessMode = "read_write";

                // 1. Primary Binding
                var bindingDecl = $"@group(0) @binding({bindingIdx}) var<storage, {accessMode}> param{param.Index} : array<{wgslType}>;";
                builder.AppendLine(bindingDecl);
                Console.WriteLine($"[WGSL Binding] {bindingDecl}");
                bindingIdx++;

                // 2. Secondary Binding (Stride Injection)
                var rawType = UnwrapType(param.ParameterType);
                if (rawType is StructureType structType &&
                    structType.NumFields > 2 && // Ptr + Length + X + Y
                    structType.Fields[0] is ViewType)
                {
                    var strideDecl = $"@group(0) @binding({bindingIdx}) var<storage, read> param{param.Index}_stride : array<i32>;";
                    builder.AppendLine(strideDecl);
                    Console.WriteLine($"[WGSL Binding] {strideDecl}");
                    bindingIdx++;
                }
            }
            builder.AppendLine();
        }

        public override void GenerateCode()
        {
            string workgroupSize = GetWorkgroupSize();

            Builder.AppendLine($"@compute @workgroup_size({workgroupSize})");
            Builder.Append("fn main(");
            Builder.Append("@builtin(global_invocation_id) global_id : vec3<u32>");

            if (EntryPoint.IsExplicitlyGrouped)
            {
                Builder.Append(", @builtin(local_invocation_id) local_id : vec3<u32>");
                Builder.Append(", @builtin(workgroup_id) workgroup_id : vec3<u32>");
                Builder.Append(", @builtin(num_workgroups) num_workgroups : vec3<u32>");
            }

            Builder.AppendLine(") {");
            PushIndent();

            SetupIndexVariables();
            SetupParameterBindings();
            GenerateCodeInternal();

            PopIndent();

            Console.WriteLine("================================ WGSL KERNEL CODE ================================");
            Console.WriteLine(Builder.ToString());
            Console.WriteLine("==================================================================================");

            Builder.AppendLine("}");
        }

        private string GetWorkgroupSize()
        {
            return EntryPoint.IndexType switch
            {
                IndexType.Index1D => "64",
                IndexType.Index2D => "8, 8",
                IndexType.Index3D => "4, 4, 4",
                _ => "64"
            };
        }

        private TypeNode GetBufferElementType(TypeNode type)
        {
            var current = type;
            while (current != null)
            {
                if (current is ViewType viewType) return viewType.ElementType;
                if (current is PointerType ptrType) return ptrType.ElementType;
                if (current is StructureType structType)
                {
                    if (structType.NumFields > 0)
                    {
                        current = structType.Fields[0];
                        continue;
                    }
                    break;
                }
                break;
            }
            return type;
        }

        private void SetupIndexVariables()
        {
            if (EntryPoint.IsExplicitlyGrouped) return;

            if (Method.Parameters.Count > 0)
            {
                var indexParam = Method.Parameters[0];
                var indexVar = Allocate(indexParam);

                switch (EntryPoint.IndexType)
                {
                    case IndexType.Index1D:
                        AppendLine($"var {indexVar.Name} : i32 = i32(global_id.x);");
                        break;
                    case IndexType.Index2D:
                        AppendLine($"var {indexVar.Name} : vec2<i32> = vec2<i32>(i32(global_id.x), i32(global_id.y));");
                        break;
                    case IndexType.Index3D:
                        AppendLine($"var {indexVar.Name} : vec3<i32> = vec3<i32>(i32(global_id.x), i32(global_id.y), i32(global_id.z));");
                        break;
                }
            }
        }

        private void SetupParameterBindings()
        {
            int paramOffset = EntryPoint.IsExplicitlyGrouped ? 0 : 1;
            foreach (var param in Method.Parameters)
            {
                if (param.Index < paramOffset) continue;

                var variable = Allocate(param);
                var bufferType = GetBufferElementType(param.ParameterType);
                bool isView = bufferType != param.ParameterType;

                if (param.ParameterType.IsPrimitiveType || !isView)
                {
                    AppendLine($"var {variable.Name} = param{param.Index}[0];");
                }
                else
                {
                    AppendLine($"let {variable.Name} = &param{param.Index};");
                }
            }
        }

        public override void GenerateCode(Parameter parameter) { }

        public override void GenerateCode(LoadElementAddress value)
        {
            var target = Load(value);
            var offset = Load(value.Offset);

            if (ResolveToParameter(value.Source) is global::ILGPU.IR.Values.Parameter param)
            {
                int paramOffset = EntryPoint.IsExplicitlyGrouped ? 0 : 1;
                if (param.Index >= paramOffset)
                {
                    AppendIndent();
                    Builder.Append($"let {target.Name} = &param{param.Index}[{offset}];");
                    Builder.AppendLine();
                    return;
                }
            }

            var sourceVal = Load(value.Source);
            AppendIndent();
            Builder.Append($"let {target.Name} = ");
            if (value.Source.Type.IsPointerType)
                Builder.Append($"&(*{sourceVal})[{offset}];");
            else
                Builder.Append($"&{sourceVal}[{offset}];");
            Builder.AppendLine();
        }

        public override void GenerateCode(global::ILGPU.IR.Values.Load load)
        {
            var target = Load(load);
            var source = Load(load.Source);
            Declare(target);
            AppendLine($"{target} = *{source};");
        }

        public override void GenerateCode(Store store)
        {
            var address = Load(store.Target);
            var val = Load(store.Value);
            AppendLine($"*{address} = {val};");
        }

        public override void GenerateCode(GetField value)
        {
            if (ResolveToParameter(value.ObjectValue) is global::ILGPU.IR.Values.Parameter param)
            {
                int paramOffset = EntryPoint.IsExplicitlyGrouped ? 0 : 1;
                if (param.Index >= paramOffset)
                {
                    bool isView = GetBufferElementType(param.ParameterType) != param.ParameterType;

                    if (isView)
                    {
                        var target = Load(value);
                        var rawType = UnwrapType(param.ParameterType);
                        bool isMultiDim = rawType is StructureType structType &&
                                          structType.NumFields > 2 &&
                                          structType.Fields[0] is ViewType;

                        // FIELD MAPPING
                        // 0: Data Pointer
                        // 1: Linear Length (IntLength)
                        // 2: Width/Stride (Index2D.X)
                        // 3: Height (Index2D.Y)

                        if (value.FieldSpan.Index == 0) // Data Ptr
                        {
                            AppendLine($"let {target} = &param{param.Index};");
                            return;
                        }

                        if (isMultiDim)
                        {
                            var stride = $"param{param.Index}_stride[0]";
                            var totalLen = $"i32(arrayLength(&param{param.Index}))";

                            if (value.FieldSpan.Index == 2) // INDEX 2 = STRIDE (Width)
                            {
                                AppendLine($"let {target} = {stride};");
                                return;
                            }
                            else if (value.FieldSpan.Index == 3) // INDEX 3 = HEIGHT
                            {
                                AppendLine($"let {target} = {totalLen} / {stride};");
                                return;
                            }
                        }

                        // Fallback (Index 1 or others) -> Return Array Length
                        AppendLine($"let {target} = i32(arrayLength(&param{param.Index}));");
                        return;
                    }
                }

                // Handle Kernel Index Parameter
                if (param.Index < paramOffset)
                {
                    var target = Load(value);
                    var source = Load(value.ObjectValue);

                    if (EntryPoint.IndexType == IndexType.Index2D)
                    {
                        string comp = value.FieldSpan.Index == 0 ? "x" : "y";
                        AppendLine($"let {target} = {source}.{comp};");
                        return;
                    }
                    else if (EntryPoint.IndexType == IndexType.Index1D)
                    {
                        if (value.FieldSpan.Index == 0) AppendLine($"let {target} = {source};");
                        else AppendLine($"let {target} = 0;");
                        return;
                    }
                }
            }

            base.GenerateCode(value);
        }

        public override void GenerateCode(LoadFieldAddress value)
        {
            if (ResolveToParameter(value.Source) is global::ILGPU.IR.Values.Parameter param)
            {
                int paramOffset = EntryPoint.IsExplicitlyGrouped ? 0 : 1;
                if (param.Index < paramOffset)
                {
                    var target = Load(value);
                    var source = Load(value.Source);

                    if (EntryPoint.IndexType == IndexType.Index2D)
                    {
                        string comp = value.FieldSpan.Index == 0 ? "x" : "y";
                        AppendLine($"var temp_{target.Name} : i32 = {source}.{comp};");
                        AppendLine($"let {target} = &temp_{target.Name};");
                        return;
                    }
                }
            }
            base.GenerateCode(value);
        }

        private global::ILGPU.IR.Values.Parameter? ResolveToParameter(global::ILGPU.IR.Value value)
        {
            if (value is global::ILGPU.IR.Values.Parameter p) return p;
            if (value is GetField gf) return ResolveToParameter(gf.ObjectValue);
            return null;
        }

        #endregion
    }
}