// ---------------------------------------------------------------------------------------
//                                  SpawnDev.ILGPU.WebGPU
//                         Copyright (c) 2024 SpawnDev Project
//
// File: WGSLKernelFunctionGenerator.cs
// ---------------------------------------------------------------------------------------

using global::ILGPU;
using global::ILGPU.Backends.EntryPoints;
using global::ILGPU.IR;
using global::ILGPU.IR.Analyses;
using global::ILGPU.IR.Types;
using global::ILGPU.IR.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpawnDev.ILGPU.WebGPU.Backend
{
    internal sealed class WGSLKernelFunctionGenerator : WGSLCodeGenerator
    {
        #region Instance

        private HashSet<int> _atomicParameters = new HashSet<int>();
        private HashSet<Value> _hoistedPrimitives = new HashSet<Value>();
        public WGSLKernelFunctionGenerator(
            in GeneratorArgs args,
            Method method,
            Allocas allocas)
            : base(args, method, allocas)
        {
            EntryPoint = args.EntryPoint;
            DynamicSharedAllocations = args.DynamicSharedAllocations;

            ScanForAtomicUsage();

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

        private void ScanForAtomicUsage()
        {
            foreach (var block in Method.Blocks)
            {
                foreach (var entry in block)
                {
                    if (entry.Value is global::ILGPU.IR.Values.GenericAtomic atomic)
                    {
                        if (ResolveToParameter(atomic.Target) is global::ILGPU.IR.Values.Parameter param)
                        {
                            _atomicParameters.Add(param.Index);
                        }
                    }
                    else if (entry.Value is global::ILGPU.IR.Values.AtomicCAS cas)
                    {
                        if (ResolveToParameter(cas.Target) is global::ILGPU.IR.Values.Parameter param)
                        {
                            _atomicParameters.Add(param.Index);
                        }
                    }
                }
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
                if (current is global::ILGPU.IR.Types.PointerType ptr)
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
            // Emit struct definitions first
            TypeGenerator.GenerateTypeDefinitions(builder);

            int bindingIdx = 0;
            int paramOffset = EntryPoint.IsExplicitlyGrouped ? 0 : 1;

            foreach (var param in Method.Parameters)
            {
                if (param.Index < paramOffset) continue;

                var elementType = GetBufferElementType(param.ParameterType);
                var wgslType = TypeGenerator[elementType];
                string accessMode = "read_write";

                // Debug info
                builder.AppendLine($"// Param {param.Index}: {param.ParameterType} (Element: {elementType})");

                if (_atomicParameters.Contains(param.Index))
                {
                    wgslType = $"atomic<{wgslType}>";
                }

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
            Builder.AppendLine(") {");
            PushIndent();

            // 1. Scan and declare hoisted variables
            HoistCrossBlockVariables();

            // 2. Setup standard bindings
            SetupIndexVariables();
            SetupParameterBindings();

            // 3. START THE STATE MACHINE
            AppendLine("var current_block : i32 = 0;");
            AppendLine("loop {");
            PushIndent();

            // THE MISSING LINE:
            AppendLine("switch (current_block) {");
            PushIndent();

            // This calls your 'new' GenerateCodeInternal that emits the 'case X:' blocks
            GenerateCodeInternal();

            // THE CLOSING BOILERPLATE:
            PopIndent();
            AppendLine("default: { break; }"); // Should never happen
            AppendLine("}"); // End Switch

            AppendLine("if (current_block == -1) { break; }"); // Safety break

            PopIndent();
            AppendLine("}"); // End Loop

            PopIndent();
            Builder.AppendLine("}"); // End Function
        }
        private string GetPrefix(Value value)
        {
            // If the variable was hoisted to the top of main(), it's already a 'var'
            // and we must use a direct assignment (no prefix).
            // Otherwise, we use 'let ' to declare it locally.
            return _hoistedPrimitives.Contains(value) ? "" : "let ";
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
                if (current is global::ILGPU.IR.Types.PointerType ptrType) return ptrType.ElementType;
                if (current is global::ILGPU.IR.Types.StructureType structType)
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
        // Add this to your Properties region
        private HashSet<Value> _hoistedIndexFields = new HashSet<Value>();

        private void SetupIndexVariables()
        {
            if (EntryPoint.IsExplicitlyGrouped) return;
            if (Method.Parameters.Count > 0)
            {
                var indexParam = Method.Parameters[0];
                var indexVar = Allocate(indexParam);
                _hoistedIndexFields.Clear();

                if (EntryPoint.IndexType == IndexType.Index1D)
                {
                    AppendLine($"var {indexVar.Name} : i32 = i32(global_id.x);");
                }
                else if (EntryPoint.IndexType == IndexType.Index2D)
                {
                    AppendLine($"var {indexVar.Name} : vec2<i32> = vec2<i32>(i32(global_id.x), i32(global_id.y));");

                    foreach (var use in indexParam.Uses)
                    {
                        if (use.Target is global::ILGPU.IR.Values.GetField gf)
                        {
                            var componentVar = Allocate(gf);
                            _hoistedIndexFields.Add(gf);

                            // ILGPU Field 0 is X (Col), Field 1 is Y (Row) - Standard Mapping
                            string comp = gf.FieldSpan.Index == 0 ? "x" : "y";
                            AppendLine($"var {componentVar.Name} : i32 = {indexVar.Name}.{comp};");
                        }
                    }
                }
                else if (EntryPoint.IndexType == IndexType.Index3D)
                {
                    AppendLine($"var {indexVar.Name} : vec3<i32> = vec3<i32>(i32(global_id.x), i32(global_id.y), i32(global_id.z));");

                    foreach (var use in indexParam.Uses)
                    {
                        if (use.Target is global::ILGPU.IR.Values.GetField gf)
                        {
                            var componentVar = Allocate(gf);
                            _hoistedIndexFields.Add(gf);

                            // ILGPU Field 0 is X, 1 is Y, 2 is Z
                            string comp = gf.FieldSpan.Index == 0 ? "x" : (gf.FieldSpan.Index == 1 ? "y" : "z");
                            AppendLine($"var {componentVar.Name} : i32 = {indexVar.Name}.{comp};");
                        }
                    }
                }
            }
        }


        private void HoistCrossBlockVariables()
        {
            var defBlocks = new Dictionary<Value, BasicBlock>();
            _hoistedPrimitives.Clear(); // Initialize the restored set

            foreach (var block in Method.Blocks)
                foreach (var value in block)
                    defBlocks[value.Value] = block;

            foreach (var block in Method.Blocks)
            {
                foreach (var value in block)
                {
                    if (value.Value is PhiValue)
                    {
                        _hoistedPrimitives.Add(value.Value);
                    }
                    foreach (var use in value.Value.Uses)
                    {
                        if (defBlocks.TryGetValue(use.Target, out var defBlock) && defBlock != block)
                        {
                            if (!value.Value.Type.IsPointerType && !value.Value.Type.IsVoidType)
                            {
                                _hoistedPrimitives.Add(value.Value);
                            }
                        }
                    }
                }
            }

            foreach (var val in _hoistedPrimitives)
            {
                var variable = Allocate(val);
                var wgslType = TypeGenerator[val.Type];
                var basicType = val.Type.BasicValueType;

                string init = " = 0";
                if (basicType == BasicValueType.Int1) init = " = false";
                else if (basicType == BasicValueType.Float16 || basicType == BasicValueType.Float32 || basicType == BasicValueType.Float64) init = " = 0.0";

                AppendLine($"var {variable.Name} : {wgslType}{init};");
            }
        }

        //private void HoistCrossBlockVariables()
        //{
        //    var defBlocks = new Dictionary<Value, BasicBlock>();
        //    var crossBlockVars = new HashSet<Value>();

        //    // Pass 1: Map where every value is defined
        //    foreach (var block in Method.Blocks)
        //    {
        //        foreach (var value in block)
        //        {
        //            defBlocks[value.Value] = block;
        //        }
        //    }

        //    // Pass 2: Find values used in a different block
        //    foreach (var block in Method.Blocks)
        //    {
        //        foreach (var value in block)
        //        {
        //            foreach (var use in value.Value.Uses)
        //            {
        //                // Note: Using use.Target as you mentioned this works for your build
        //                if (defBlocks.TryGetValue(use.Target, out var defBlock) && defBlock != block)
        //                {
        //                    // Only hoist primitives (WGSL var rules)
        //                    if (!value.Value.Type.IsPointerType && !value.Value.Type.IsVoidType)
        //                    {
        //                        crossBlockVars.Add(value.Value);
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    // Pass 3: Emit declarations at the top of main
        //    foreach (var val in crossBlockVars)
        //    {
        //        var variable = Allocate(val);
        //        var wgslType = TypeGenerator[val.Type];

        //        var basicType = val.Type.BasicValueType;
        //        string init = "";

        //        // 1. Check for Booleans specifically (Int1)
        //        if (basicType == BasicValueType.Int1)
        //        {
        //            init = " = false";
        //        }
        //        // 2. Check for Floats
        //        else if (basicType == BasicValueType.Float16 ||
        //                 basicType == BasicValueType.Float32 ||
        //                 basicType == BasicValueType.Float64)
        //        {
        //            init = " = 0.0";
        //        }
        //        // 3. Everything else (Int8, Int16, Int32, Int64) is an integer
        //        // This includes u32/u64 which ILGPU maps to Int32/Int64 basic types
        //        else
        //        {
        //            init = " = 0";
        //        }
        //        AppendLine($"var {variable.Name} : {wgslType}{init};");
        //    }
        //}

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
                    if (!isMultiDim && rawType is global::ILGPU.IR.Types.StructureType structType)
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

        public override void GenerateCode(global::ILGPU.IR.Values.Load loadVal)
        {
            var target = Load(loadVal);
            var source = Load(loadVal.Source);

            // Check if we already declared this at the top
            if (_hoistedPrimitives.Contains(loadVal))
            {
                AppendLine($"{target} = *{source};");
            }
            else
            {
                // Fallback to your stable declaration logic
                Declare(target);
                AppendLine($"{target} = *{source};");
            }
        }

        public override void GenerateCode(global::ILGPU.IR.Values.Store storeVal)
        {
            var address = Load(storeVal.Target);
            var val = Load(storeVal.Value);
            AppendLine($"*{address} = {val};");
        }

        public override void GenerateCode(BinaryArithmeticValue value)
        {
            var target = Load(value);
            var left = Load(value.Left);
            var right = Load(value.Right);
            var op = GetArithmeticOp(value.Kind);

            string prefix = GetPrefix(value);

            if (value.Kind == BinaryArithmeticKind.Shl || value.Kind == BinaryArithmeticKind.Shr)
                AppendLine($"{prefix}{target} = {left} {op} u32({right});");
            else
                AppendLine($"{prefix}{target} = {left} {op} {right};");
        }

        private int GetBlockIndex(BasicBlock block)
        {
            int index = 0;
            foreach (var b in Method.Blocks)
            {
                if (b == block) return index;
                index++;
            }
            return -1;
        }

        private void PushPhiValues(BasicBlock targetBlock, BasicBlock sourceBlock)
        {
            foreach (var value in targetBlock)
            {
                if (value.Value is PhiValue phi)
                {
                    var targetVar = Load(phi);
                    // PhiValue in ILGPU implements a collection of (SourceBlock, Value) pairs
                    for (int i = 0; i < phi.Count; i++)
                    {
                        if (phi.Sources[i] == sourceBlock)
                        {
                            var sourceVal = Load(phi[i]);
                            AppendLine($"{targetVar} = {sourceVal};");
                        }
                    }
                }
            }
        }
        public override void GenerateCode(UnaryArithmeticValue value)
        {
            var target = Load(value);
            var source = Load(value.Value);
            string op = value.Kind switch
            {
                UnaryArithmeticKind.Neg => "-",
                UnaryArithmeticKind.Not => "!",
                _ => ""
            };
            string prefix = GetPrefix(value);
            AppendLine($"{prefix}{target} = {op}({source});");
        }
        public override void GenerateCode(UnconditionalBranch branch)
        {
            // 1. Move Phi data (v_11 = v_19, etc.)
            PushPhiValues(branch.Target, branch.BasicBlock);

            // 2. Force the State Machine transition
            var targetIndex = GetBlockIndex(branch.Target);
            AppendIndent();
            Builder.AppendLine($"current_block = {targetIndex};");
            AppendIndent();
            Builder.AppendLine("continue;");
        }
        protected new void GenerateCodeInternal()
        {
            foreach (var block in Method.Blocks)
            {
                AppendIndent();
                Builder.AppendLine($"case {GetBlockIndex(block)}: {{");
                PushIndent();

                foreach (var value in block)
                {
                    if (value.Value is TerminatorValue) continue;
                    // Force visit to use your overrides
                    this.GenerateCodeFor(value.Value);
                }

                // Explicitly handle terminators to force current_block updates
                if (block.Terminator is UnconditionalBranch ub) GenerateCode(ub);
                else if (block.Terminator is IfBranch ib) GenerateCode(ib);
                else if (block.Terminator is ReturnTerminator rt) GenerateCode(rt);
                else this.GenerateCodeFor(block.Terminator);

                PopIndent();
                AppendIndent();
                Builder.AppendLine("}");
            }
        }
        public override void GenerateCode(IfBranch branch)
        {
            var condition = Load(branch.Condition);
            var trueIndex = GetBlockIndex(branch.TrueTarget);
            var falseIndex = GetBlockIndex(branch.FalseTarget);

            AppendIndent();
            Builder.AppendLine($"if ({condition}) {{");
            PushIndent();
            PushPhiValues(branch.TrueTarget, branch.BasicBlock);
            AppendIndent();
            Builder.AppendLine($"current_block = {trueIndex};");
            PopIndent();

            AppendIndent();
            Builder.AppendLine("} else {");
            PushIndent();
            PushPhiValues(branch.FalseTarget, branch.BasicBlock);
            AppendIndent();
            Builder.AppendLine($"current_block = {falseIndex};");
            PopIndent();

            AppendIndent();
            Builder.AppendLine("}");

            AppendIndent();
            Builder.AppendLine("continue;");
        }
        // 3. Handles 'return' to exit the kernel
        public override void GenerateCode(ReturnTerminator returnTerminator)
        {
            // In WGSL compute shaders, we simply return to exit the main function
            AppendIndent();
            AppendLine("return;");
        }

        public override void GenerateCode(CompareValue value)
        {
            var target = Load(value);
            var left = Load(value.Left);
            var right = Load(value.Right);
            var op = GetCompareOp(value.Kind);

            string prefix = GetPrefix(value);
            AppendLine($"{prefix}{target} = {left} {op} {right};");
        }
        public override void GenerateCode(ConvertValue value)
        {
            var target = Load(value);
            var source = Load(value.Value);
            var targetType = TypeGenerator[value.Type];

            string prefix = GetPrefix(value);
            AppendLine($"{prefix}{target} = {targetType}({source});");
        }

        public override void GenerateCode(global::ILGPU.IR.Values.GetField value)
        {
            // 1. Safety check: If this is a kernel index component (X, Y, Z) 
            // already hoisted in SetupIndexVariables, skip it.
            if (_hoistedIndexFields.Contains(value)) return;

            // 2. Identify if the object being accessed is DIRECTLY a Parameter (likely an ArrayView)
            // We use direct type check to avoid confusing hierarchical access (View.Stride.X) with Root access (View.Stride)
            if (value.ObjectValue.Resolve() is global::ILGPU.IR.Values.Parameter param)
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
                        bool isMultiDim = typeName.Contains("ArrayView") || rawType.ToString().Contains("ArrayView");
                        bool is3DView = typeName.Contains("3D");
                        bool is2DView = false;
                        bool is1DView = false;

                        if (rawType is global::ILGPU.IR.Types.StructureType st)
                        {
                            if (st.NumFields == 6) { is3DView = true; isMultiDim = true; }
                            else if (st.NumFields == 4) { is2DView = true; isMultiDim = true; }
                            else if (st.NumFields == 3) { is1DView = true; isMultiDim = true; }
                        }

                        // Field 0 is always the actual pointer to the data
                        if (value.FieldSpan.Index == 0)
                        {
                            AppendLine($"let {target} = &param{param.Index};");
                            return;
                        }

                        // Metadata handling (Length and Strides)
                        if (isMultiDim && rawType is StructureType st1)
                        {
                            var width = $"param{param.Index}_stride[0]";
                            var height = $"param{param.Index}_stride[1]";
                            var totalLen = $"i32(arrayLength(&param{param.Index}))";
                            
                            // Check hoisting to prevent shadowing
                            string prefix = _hoistedPrimitives.Contains(value) ? "" : "let ";

                             if (is3DView)
                            {
                                // TODO: 3D Implementation if needed
                                // Assuming 3D Stride buffer has [W, H, D]
                                // Length: vec3(width, height, depth)
                                // Stride: vec3(1, width, width*height)
                                switch (value.FieldSpan.Index)
                                {
                                    case 1: AppendLine($"{prefix}{target} = {width};"); return;     // Width
                                    case 2: AppendLine($"{prefix}{target} = {height};"); return;    // Height
                                    case 3: AppendLine($"{prefix}{target} = param{param.Index}_stride[2];"); return; // Depth
                                    case 4: AppendLine($"{prefix}{target} = {width};"); return;     // StrideY
                                    case 5: AppendLine($"{prefix}{target} = {width} * {height};"); return; // StrideZ
                                }
                            }
                            else if (is2DView)
                            {
                                switch (value.FieldSpan.Index)
                                {
                                    // Field 1: Width (i32)
                                    case 1: AppendLine($"{prefix}{target} = {width};"); return; 
                                    
                                    // Field 2: Height (i32)
                                    case 2: AppendLine($"{prefix}{target} = {height};"); return;

                                    // Field 3: Stride (i32)
                                    case 3: AppendLine($"{prefix}{target} = {width};"); return;
                                }
                            }
                            else if (is1DView)
                            {
                                var structType1D = (global::ILGPU.IR.Types.StructureType)rawType;
                                bool isWrapper = structType1D.Fields[1] is global::ILGPU.IR.Types.StructureType;

                                if (isWrapper)
                                {
                                    switch (value.FieldSpan.Index)
                                    {
                                        case 1: AppendLine($"{prefix}{target} = {width};"); return; // Length
                                        case 2: AppendLine($"{prefix}{target} = 0;"); return;       // Stride
                                    }
                                }
                                else
                                {
                                    switch (value.FieldSpan.Index)
                                    {
                                        case 1: AppendLine($"{prefix}{target} = 0;"); return;       // Index
                                        case 2: AppendLine($"{prefix}{target} = {width};"); return; // Length
                                    }
                                }
                            }

                            // Fallback for length
                            AppendLine($"{prefix}{target} = {totalLen};");
                            return;
                        }
                    }
                }
            }

                // 3. Special handling for Kernel Index Parameter (X, Y components)
            if (ResolveToParameter(value.ObjectValue) is global::ILGPU.IR.Values.Parameter kernelParam) 
            {
                 int paramOffset = EntryPoint.IsExplicitlyGrouped ? 0 : 1;
                 if (kernelParam.Index < paramOffset)
                 {
                    var target = Load(value);
                    var source = Load(value.ObjectValue);
                    string prefix = _hoistedPrimitives.Contains(value) ? "" : "let ";

                    if (EntryPoint.IndexType == IndexType.Index2D)
                    {
                        // Standard: Field 0 is X, Field 1 is Y
                        string comp = value.FieldSpan.Index == 0 ? "x" : "y";
                        AppendLine($"{prefix}{target} = {source}.{comp};");
                        return;
                    }
                    else if (EntryPoint.IndexType == IndexType.Index3D)
                    {
                        string comp = value.FieldSpan.Index == 0 ? "x" : (value.FieldSpan.Index == 1 ? "y" : "z");
                        AppendLine($"{prefix}{target} = {source}.{comp};");
                        return;
                    }
                    else if (EntryPoint.IndexType == IndexType.Index1D)
                    {
                        if (value.FieldSpan.Index == 0) AppendLine($"{prefix}{target} = {source};");
                        else AppendLine($"{prefix}{target} = 0;");
                        return;
                    }
                 }
            }

            // 4. Standard Field Access (not a View or Kernel Index)
            var standardTarget = Load(value);
            var standardSource = Load(value.ObjectValue);

            // Check hoisting for the final result
            string finalPrefix = _hoistedPrimitives.Contains(value) ? "" : "let ";

            if (value.Type.IsPointerType)
            {
                AppendLine($"{finalPrefix}{standardTarget} = &({standardSource}).field_{value.FieldSpan.Index};");
            }
            else
            {
                // WGSL supports vector/struct swizzles/access
                // If source is a vec2/vec3 and we want field 0/1, use x/y/z
                // BUT ILGPU IR 'Index2D' is a struct, so it might be treating it as such
                // If we forced Index2D to be vec2<i32>, we need .x/.y access.
                // However, standard structs use struct members.
                // WE MUST CHECK TYPE.
                
                string fieldAccess = $".field_{value.FieldSpan.Index}";
                
                // Heuristic: If source is a vector type string, use x/y/z/w
                var typeStr = TypeGenerator[value.ObjectValue.Type];
                if (typeStr.Contains("vec2")) 
                {
                     fieldAccess = value.FieldSpan.Index == 0 ? ".x" : ".y";
                }
                
                AppendLine($"{finalPrefix}{standardTarget} = {standardSource}{fieldAccess};");
            }
        }

        public override void GenerateCode(global::ILGPU.IR.Values.SetField value)
        {
            var target = Load(value.ObjectValue);
            var val = Load(value.Value);
            // Directly update the field of the hoisted variable
            // Note: This relies on 'target' being a mutable 'var' (hoisted primitive)
            AppendLine($"{target}.field_{value.FieldSpan.Index} = {val};");
            
            // Define the result value to maintain connectivity for downstream users (like Phi)
            // Since we mutated 'target' in place, the result 'value' is logically equivalent to 'target'
            var res = Allocate(value);
            AppendLine($"let {res.Name} = {target};");
        }

        private static string GetArithmeticOp(BinaryArithmeticKind kind)
        {
            switch (kind)
            {
                case BinaryArithmeticKind.Add: return "+";
                case BinaryArithmeticKind.Sub: return "-";
                case BinaryArithmeticKind.Mul: return "*";
                case BinaryArithmeticKind.Div: return "/";
                case BinaryArithmeticKind.Rem: return "%";
                case BinaryArithmeticKind.And: return "&";
                case BinaryArithmeticKind.Or: return "|";
                case BinaryArithmeticKind.Xor: return "^";
                case BinaryArithmeticKind.Shl: return "<<";
                case BinaryArithmeticKind.Shr: return ">>";
                default: throw new NotSupportedException($"Binary op {kind} not supported.");
            }
        }
        private static string GetCompareOp(CompareKind kind)
        {
            switch (kind)
            {
                case CompareKind.Equal: return "==";
                case CompareKind.NotEqual: return "!=";
                case CompareKind.LessThan: return "<";
                case CompareKind.LessEqual: return "<=";
                case CompareKind.GreaterThan: return ">";
                case CompareKind.GreaterEqual: return ">=";
                default: throw new NotSupportedException($"Compare op {kind} not supported.");
            }
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

        public override void GenerateCode(PhiValue phiValue)
        {
            // Phi values are handled at the branch level in this state-machine model.
            // We don't emit code here, but the values will be pulled by the branching logic.
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

        protected override bool IsAtomicPointer(Value ptr)
        {
            if (ResolveToParameter(ptr) is global::ILGPU.IR.Values.Parameter param)
            {
                return _atomicParameters.Contains(param.Index);
            }
            return base.IsAtomicPointer(ptr);
        }

        #endregion
            

        }
    }