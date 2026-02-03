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

            if (!EntryPoint.IsExplicitlyGrouped && method.Parameters.Count > 0)
            {
                var indexParam = method.Parameters[0];
                foreach (var block in method.Blocks)
                {
                    foreach (var entry in block)
                    {
                        if (entry.Value is Store store && store.Value == indexParam)
                        {
                            _indexParameterAddress = store.Target;
                            goto FoundIndexParam;
                        }
                    }
                }
            FoundIndexParam:;
            }
        }

        #endregion

        #region Properties

        public EntryPoint EntryPoint { get; }
        public AllocaKindInformation DynamicSharedAllocations { get; }

        private Value? _indexParameterAddress;

        #endregion

        #region Methods

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

        private bool IsViewStructure(TypeNode type)
        {
            if (type is ViewType) return true;
            if (type is StructureType st)
            {
                if (st.ToString().Contains("View")) return true;
                if (st.NumFields >= 2 && st.Fields[0] is PointerType) return true;
            }
            return false;
        }

        public override void GenerateHeader(StringBuilder builder)
        {
            int bindingIdx = 0;
            int paramOffset = EntryPoint.IsExplicitlyGrouped ? 0 : 1;

            foreach (var param in Method.Parameters)
            {
                if (param.Index < paramOffset) continue;

                var elementType = GetBufferElementType(param.ParameterType);
                var wgslType = TypeGenerator[elementType];
                string accessMode = "read_write";

                var bindingDecl = $"@group(0) @binding({bindingIdx}) var<storage, {accessMode}> param{param.Index} : array<{wgslType}>;";
                builder.AppendLine(bindingDecl);
                bindingIdx++;

                var rawType = UnwrapType(param.ParameterType);
                string typeName = param.ParameterType.ToString();
                
                bool isMultiDim = typeName.Contains("ArrayView") || rawType.ToString().Contains("ArrayView") || rawType is ViewType;

                // Fallback to structure check if string check fails (for custom structs using views)
                if (!isMultiDim && rawType is StructureType structType)
                {
                    if (structType.NumFields > 2 && IsViewStructure(structType.Fields[0]))
                    {
                        isMultiDim = true;
                    }
                    if (structType.NumFields == 3) isMultiDim = true; // 1D View
                }

                if (isMultiDim)
                {
                    var strideDecl = $"@group(0) @binding({bindingIdx}) var<storage, read> param{param.Index}_stride : array<i32>;";
                    builder.AppendLine(strideDecl);
                    bindingIdx++;
                }
            }
            builder.AppendLine();
        }

        public override void GenerateCode()
        {
            string workgroupSize = GetWorkgroupSize();
            Builder.AppendLine($"@compute @workgroup_size({workgroupSize})");
            Builder.Append("fn main(@builtin(global_invocation_id) global_id : vec3<u32>");
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
                    case IndexType.Index1D: AppendLine($"var {indexVar.Name} : i32 = i32(global_id.x);"); break;
                    case IndexType.Index2D: AppendLine($"var {indexVar.Name} : vec2<i32> = vec2<i32>(i32(global_id.x), i32(global_id.y));"); break;
                    case IndexType.Index3D: AppendLine($"var {indexVar.Name} : vec3<i32> = vec3<i32>(i32(global_id.x), i32(global_id.y), i32(global_id.z));"); break;
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
                if (param.ParameterType.IsPrimitiveType || !isView) AppendLine($"var {variable.Name} = param{param.Index}[0];");
                else 
                {
                    AppendLine($"let {variable.Name} = &param{param.Index};");

                    // Force usage of stride buffer to prevent optimization culling (Binding Mismatch)
                    var rawType = UnwrapType(param.ParameterType);
                    string typeName = param.ParameterType.ToString();
                    bool isMultiDim = typeName.Contains("ArrayView") || rawType.ToString().Contains("ArrayView") || rawType is ViewType;
                     if (!isMultiDim && rawType is StructureType structType)
                    {
                        if (structType.NumFields > 2 && IsViewStructure(structType.Fields[0])) isMultiDim = true;
                        if (structType.NumFields == 3) isMultiDim = true; 
                    }
                    if (isMultiDim) AppendLine($"let _stride_{param.Index} = param{param.Index}_stride[0];");
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
            if (value.Source.Type.IsPointerType) Builder.Append($"&(*{sourceVal})[{offset}];");
            else Builder.Append($"&{sourceVal}[{offset}];");
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

                        // ROBUST TYPE DETECTION
                        string typeName = param.ParameterType.ToString();
                        bool isLong = typeName.Contains("Long") || typeName.Contains("Int64"); 
                        bool isMultiDim = typeName.Contains("ArrayView") || rawType.ToString().Contains("ArrayView"); // Restored
                        bool is3DView = typeName.Contains("3D"); 
                        bool is2DView = typeName.Contains("2D");

                        bool is1DView = false;
                        if (rawType is StructureType st)
                        {
                            if (st.NumFields == 6) { is3DView = true; isMultiDim = true; }
                            if (st.NumFields == 4) { is2DView = true; isMultiDim = true; }
                            if (st.NumFields == 3) { is1DView = true; isMultiDim = true; }
                        }
                        
                        if (value.FieldSpan.Index == 0)
                        {
                            AppendLine($"let {target} = &param{param.Index};");
                            return;
                        }

                        if (isMultiDim)
                        {
                            var width = $"param{param.Index}_stride[0]";
                            var height = $"param{param.Index}_stride[1]";
                            var depth = $"param{param.Index}_stride[2]"; 
                            var totalLen = $"i32(arrayLength(&param{param.Index}))";
                            
                            // Removed duplicate is2DView declaration

                            if (is3DView)
                            {
                                switch (value.FieldSpan.Index)
                                {
                                    case 1: AppendLine($"let {target} = {width};"); return; // Width
                                    case 2: AppendLine($"let {target} = {height};"); return; // Height
                                    case 3: AppendLine($"let {target} = {depth};"); return; // Depth
                                    case 4: AppendLine($"let {target} = {width};"); return; // StrideY (Dense)
                                    case 5: AppendLine($"let {target} = {width} * {height};"); return; // StrideZ (Dense)
                                }
                            }
                            else if (is2DView)
                            {
                                switch (value.FieldSpan.Index)
                                {
                                    case 1: AppendLine($"let {target} = {width};"); return; // Width
                                    case 2: AppendLine($"let {target} = {height};"); return; // Height
                                    case 3: AppendLine($"let {target} = {width};"); return; // Stride (Dense)
                                }
                            }
                            else if (is1DView)
                            {
                                // Distinguish ArrayView (Base) vs ArrayView1D (Wrapper)
                                var structType1D = (StructureType)rawType;
                                bool isWrapper = structType1D.Fields[1] is StructureType;

                                if (isWrapper)
                                {
                                    // ArrayView1D (Wrapper)
                                    // Field 0: BaseView (Ptr) - Handled by offset 0 check
                                    // Field 1: Extent (Struct) -> Stride[0] (Length)
                                    // Field 2: Stride (Struct) -> 0 (Dense/Ignore)
                                    switch (value.FieldSpan.Index)
                                    {
                                        case 1: AppendLine($"let {target} = {width};"); return; 
                                        case 2: AppendLine($"let {target} = 0;"); return;
                                    }
                                }
                                else
                                {
                                    // ArrayView (Base)
                                    // Field 0: Buffer (Ptr)
                                    // Field 1: Index (Long) -> 0 (Handled by offset)
                                    // Field 2: Length (Long) -> Stride[0] (Length)
                                    switch (value.FieldSpan.Index)
                                    {
                                        case 1: AppendLine($"let {target} = 0;"); return;
                                        case 2: AppendLine($"let {target} = {width};"); return;
                                    }
                                }
                            }

                            // Fallback
                            AppendLine($"let {target} = i32(arrayLength(&param{param.Index}));");
                            return;
                        }
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
                    else if (EntryPoint.IndexType == IndexType.Index3D)
                    {
                        string comp = value.FieldSpan.Index == 0 ? "x" : (value.FieldSpan.Index == 1 ? "y" : "z");
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

            if (value is global::ILGPU.IR.Values.Load load) return ResolveToParameter(load.Source);
            if (value is LoadElementAddress lea) return ResolveToParameter(lea.Source);
            if (value is LoadFieldAddress lfa) return ResolveToParameter(lfa.Source);

            if (_indexParameterAddress != null && value == _indexParameterAddress)
            {
                return Method.Parameters[0];
            }

            return null;
        }

        #endregion
    }
}