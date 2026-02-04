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

        // Force offset 1 if we have a valid index type, ignoring IsExplicitlyGrouped
        // This fixes cases where SharedMemory usage flags the kernel as explicit but it still has an Index parameter.
        private int KernelParamOffset => EntryPoint.IndexType != IndexType.None ? 1 : 0;

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
            int paramOffset = KernelParamOffset;

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

                IsMultiDim(param.ParameterType, out var isMultiDim, out var isView, out var is1DView, out var is2DView, out var is3DView);

                // STRICT STRIDE LOGIC: Only emit stride buffer for 2D/3D Views.
                // General Structs (even if they mimic views) should NOT have a stride buffer unless they ARE views.
                if (isView && isMultiDim && (is2DView || is3DView))
                {
                    var strideDecl = $"@group(0) @binding({bindingIdx}) var<storage, read> param{param.Index}_stride : array<i32>;";
                    builder.AppendLine(strideDecl);
                    bindingIdx++;
                }
            }
            
            builder.AppendLine();
            
            // Emit shared memory allocations
            foreach (var alloca in Allocas.SharedAllocations)
            {
                var variable = Load(alloca.Alloca);
                declaredVariables.Add(variable.Name);

                var elementType = alloca.ElementType;
                int entryCount = (int)alloca.ArraySize;
                
                var wgslType = TypeGenerator[elementType];
                builder.AppendLine($"var<workgroup> {variable.Name} : array<{wgslType}, {entryCount}>;");
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
                    // Refined Logic:
                    // 1. If this is a Wrapper Struct (like ArrayView2D/3D), its first field is the underlying View.
                    //    We MUST drill down to get the primitive element type (e.g., float).
                    // 2. If this is a Data Struct (user-defined struct), it is the element type itself.
                    //    We MUST return it as-is so we get 'array<MyStruct>'.
                    
                    if (structType.NumFields > 0 && (structType.Fields[0] is ViewType || structType.Fields[0].ToString().Contains("View")))
                    {
                        current = structType.Fields[0];
                        continue;
                    }

                    return structType;
                }
                break;
            }
            return current; // Return whatever we resolved to
        }
        // Add this to your Properties region
        private HashSet<Value> _hoistedIndexFields = new HashSet<Value>();

        private void SetupIndexVariables()
        {
            // If the kernel is explicitly grouped (Shared Memory / Advanced), the user handles indices via Group.* intrinsics
            // However, we still need to map the main Kernel Index parameter if it exists.
            
            if (Method.Parameters.Count == 0) return;
            
            var indexParam = Method.Parameters[0];
            
            // Only map if strictly implicit OR if we detected an IndexType
            if (KernelParamOffset == 0) return;

            var indexVar = Allocate(indexParam);
            _hoistedIndexFields.Clear();

            // 1D Kernel
            if (EntryPoint.IndexType == IndexType.Index1D)
            {
                // Map global_id.x to int32
                AppendLine($"var {indexVar.Name} : i32 = i32(global_id.x);");
            }
            // 2D Kernel
            else if (EntryPoint.IndexType == IndexType.Index2D)
            {
                // Map global_id.xy to vec2<i32>
                AppendLine($"var {indexVar.Name} : vec2<i32> = vec2<i32>(i32(global_id.x), i32(global_id.y));");

                // Handle struct field access (index.X, index.Y) by pre-calculating them
                // This prevents "GetField" later from trying to access a struct field on a vec2
                foreach (var use in indexParam.Uses)
                {
                    if (use.Target is global::ILGPU.IR.Values.GetField gf)
                    {
                        var componentVar = Allocate(gf);
                        _hoistedIndexFields.Add(gf);
                        declaredVariables.Add(componentVar.Name); // Ensure it's marked as declared

                        string comp = gf.FieldSpan.Index == 0 ? "x" : "y";
                        AppendLine($"var {componentVar.Name} : i32 = {indexVar.Name}.{comp};"); // Use vector component
                    }
                }
            }
            // 3D Kernel
            else if (EntryPoint.IndexType == IndexType.Index3D)
            {
                // Map global_id.xyz to vec3<i32>
                AppendLine($"var {indexVar.Name} : vec3<i32> = vec3<i32>(i32(global_id.x), i32(global_id.y), i32(global_id.z));");

                foreach (var use in indexParam.Uses)
                {
                    if (use.Target is global::ILGPU.IR.Values.GetField gf)
                    {
                        var componentVar = Allocate(gf);
                        _hoistedIndexFields.Add(gf);
                        declaredVariables.Add(componentVar.Name);

                        string comp = gf.FieldSpan.Index == 0 ? "x" : (gf.FieldSpan.Index == 1 ? "y" : "z");
                        AppendLine($"var {componentVar.Name} : i32 = {indexVar.Name}.{comp};");
                    }
                }
            }
            else
            {
                // Fallback: Default to 1D if we skipped the param but didn't match specific types
                // This protects against weird IndexType states
                AppendLine($"var {indexVar.Name} : i32 = i32(global_id.x); // Fallback mapping");
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
                    // CRITICAL: Skip NewView to prevent hoisting pointer logic
                    if (value.Value is global::ILGPU.IR.Values.NewView) continue;
                    
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

        void IsMultiDim(TypeNode ParameterType, out bool isMultiDim, out bool isView, out bool is1DView, out bool is2DView, out bool is3DView)
        {
            is1DView = false;
            is2DView = false;
            is3DView = false;
            isMultiDim = false;
            isView = false;

            string typeName = ParameterType.ToString();
            
            // 1. Direct String Check (works for C# types if available, but unreliable for IR strings)
            bool isStringView = typeName.Contains("ArrayView");
            
            // 2. Structural Check on ParameterType (The Wrapper Struct)
            if (ParameterType is global::ILGPU.IR.Types.StructureType st)
            {
                 // Check if it looks like an ArrayView wrapper (Field 0 is View)
                 if (st.NumFields > 0 && (st.Fields[0] is ViewType || st.Fields[0].ToString().Contains("View")))
                 {
                     isView = true;
                     
                     if (st.NumFields == 6 || st.NumFields == 4) // 3D (6 fields usually), 2D (4 fields)
                     {
                         isMultiDim = true;
                         if (st.NumFields == 6) is3DView = true;
                         else is2DView = true;
                     }
                     else if (st.NumFields == 3)
                     {
                         is1DView = true;
                         isMultiDim = false; // 1D doesn't need stride buffers, so we treat as "not multi dim" for stride purposes
                     }
                 }
            }
            
            // 3. Fallback: Combine String check with Structural properties
            if (!isView && isStringView)
            {
                isView = true;
                if (typeName.Contains("2D") || typeName.Contains("3D")) isMultiDim = true;
                if (typeName.Contains("3D")) is3DView = true;
                else if (typeName.Contains("2D")) is2DView = true;
                else if (typeName.Contains("1D")) is1DView = true;
            }
        }

        private void SetupParameterBindings()
        {
            int paramOffset = KernelParamOffset;
            foreach (var param in Method.Parameters)
            {
                if (param.Index < paramOffset) continue;
                var variable = Allocate(param);
                
                IsMultiDim(param.ParameterType, out var isMultiDim, out var isView, out var is1DView, out var is2DView, out var is3DView);

                if (!isView) 
                {
                    // Check if it's an atomic parameter (even if not explicitly a ViewType in C# reflection terms)
                    // Atomic operations in WGSL work on pointers to storage buffer elements.
                    bool isAtomic = _atomicParameters.Contains(param.Index);
                    
                    // Check if it's a Structure (that might contain Views). 
                    // If we try to 'load' a struct from a buffer that is array<f32>, it fails.
                    // We should treat structs as pointers/references so GetField can handle them.
                    bool isStruct = param.ParameterType is global::ILGPU.IR.Types.StructureType;

                    if (isAtomic)
                    {
                        // Treat as pointer/reference
                        AppendLine($"let {variable.Name} = &param{param.Index};");
                    }
                    else if (isStruct)
                    {
                        // Optimization:
                        // If this is a View-Like struct (ArrayView2D/3D), we want to alias it as the Buffer Pointer (&param)
                        // so that GetField can detect it as a Parameter and applying Field 0 logic.
                        // If it is a PURE data struct, we alias as &param[0].
                        
                        if (isMultiDim)
                        {
                             AppendLine($"let {variable.Name} = &param{param.Index};");
                        }
                        else
                        {
                            // Structs are loaded as pointers to the first element of the array
                            // param is array<MyStruct>, so &param is ptr<array<MyStruct>>.
                            // We want ptr<MyStruct>, which is &param[0].
                            AppendLine($"let {variable.Name} = &param{param.Index}[0];");
                        }
                    }
                    else
                    {
                        // Scalar load
                        AppendLine($"var {variable.Name} = param{param.Index}[0];");
                    }
                }
                else
                {
                    AppendLine($"let {variable.Name} = &param{param.Index};");

                    // STRICT STRIDE INITIALIZATION: Only for 2D/3D Views
                    if (isView && isMultiDim && (is2DView || is3DView)) 
                    {
                        AppendLine($"let {variable.Name}_stride = &param{param.Index}_stride;");
                    }
                }
            }
        }
        
        public override void GenerateCode(global::ILGPU.IR.Values.NewView value)
        {
            var target = Load(value);
            var source = Load(value.Pointer);
            
            // NewView result is strictly a pointer (reference) in WGSL
            string refPrefix = "";
            if (value.Pointer.Type is global::ILGPU.IR.Types.PointerType ptrType && 
                ptrType.AddressSpace == MemoryAddressSpace.Shared)
            {
                refPrefix = "&";
            }
            
            // We use 'let' to alias the pointer, ensuring we don't copy the array
            // Optimization: If source is already a pointer (likely), we might not need &
            // But for Shared Memory (var<workgroup> arr), it's treated as value, so we need &
            
            declaredVariables.Add(target.Name);
            AppendLine($"let {target.Name} = {refPrefix}{source};");
        }
        
        public override void GenerateCode(Parameter parameter) { }

        public override void GenerateCode(LoadElementAddress value)
        {
            var target = Load(value);
            var offset = Load(value.Offset);
            if (ResolveToParameter(value.Source) is global::ILGPU.IR.Values.Parameter param)
            {
                int paramOffset = KernelParamOffset;
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
            
            // POINTER DEREFERENCE LOGIC
            // If the source comes from NewView, it's a pointer (let v_3 = &v_4).
            // To access element at offset: (*ptr)[offset] -> &(*ptr)[offset] gives the address
            if (value.Source is global::ILGPU.IR.Values.NewView || value.Source.Type.IsPointerType) 
            {
                Builder.Append($"&(*{sourceVal})[{offset}];");
            }
            else 
            {
                Builder.Append($"&{sourceVal}[{offset}];");
            }
            Builder.AppendLine();
        }

        public override void GenerateCode(global::ILGPU.IR.Values.Load loadVal)
        {
            var target = Load(loadVal);
            var source = Load(loadVal.Source);

            // Special handling for loading an ArrayView parameter (which is a struct).
            // We cannot 'load' the struct from the buffer binding (which is array<T>).
            // Instead, we treat the 'loaded' value as a pointer/alias to the binding.
            
            // CRITICAL FIX: Only alias if the source IS the parameter node itself.
            // Do NOT alias if the source is a derived pointer (e.g. LoadElementAddress), 
            // as that would prevent loading actual data values.
            // Note: loadVal.Source is a ValueReference struct. To pattern match against Value types (classes),
            // we must use .Resolve() to get the underlying Value object.
            if (loadVal.Source.Resolve() is global::ILGPU.IR.Values.Parameter param && 
                param.Type is global::ILGPU.IR.Types.ViewType)
            {
                // Verify index (skip implicit kernel index if any)
                 int paramOffset = KernelParamOffset;
                 if (param.Index >= paramOffset)
                 {
                    // Alias: let v_X = &paramY;
                    AppendLine($"let {target} = &param{param.Index};");
                    return;
                 }
            }

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
            string prefix = GetPrefix(value);

            if (value.Kind == BinaryArithmeticKind.Min || value.Kind == BinaryArithmeticKind.Max || value.Kind == BinaryArithmeticKind.PowF)
            {
                string func = value.Kind switch {
                    BinaryArithmeticKind.Min => "min",
                    BinaryArithmeticKind.Max => "max",
                    BinaryArithmeticKind.PowF => "pow",
                    _ => "min"
                };
                AppendLine($"{prefix}{target} = {func}({left}, {right});");
                return;
            }

            var op = GetArithmeticOp(value.Kind);

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

                    // FORCE CHECK FOR BARRIER
                    if (value.Value is global::ILGPU.IR.Values.Barrier ||
                        value.Value.GetType().Name.Contains("Barrier"))
                    {
                        AppendIndent();
                        Builder.AppendLine("workgroupBarrier();");
                        continue;
                    }

                    // Force visit to use your overrides
                    this.GenerateCodeFor(value.Value);
                }


                // Explicitly handle terminators to force current_block updates
                if (block.Terminator is UnconditionalBranch ub) GenerateCode(ub);
                else if (block.Terminator is IfBranch ib) GenerateCode(ib);
                else if (block.Terminator is ReturnTerminator rt) GenerateCode(rt);
                else if (block.Terminator != null) this.GenerateCodeFor(block.Terminator);

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
            
            // Fix: Handle Vector vs Scalar comparison (e.g. vec2 >= i32)
            string leftType = TypeGenerator[value.Left.Type];
            string rightType = TypeGenerator[value.Right.Type];
            
            bool leftIsVec = leftType.StartsWith("vec");
            bool rightIsVec = rightType.StartsWith("vec");
            
            if (leftIsVec && !rightIsVec)
            {
                 // vec op scalar -> all(vec op vec(scalar))
                 // Use vector type of the vector operand to splat the scalar
                 AppendLine($"{prefix}{target} = all({left} {op} {leftType}({right}));");
            }
            else if (!leftIsVec && rightIsVec)
            {
                 // scalar op vec -> all(vec(scalar) op vec)
                 AppendLine($"{prefix}{target} = all({rightType}({left}) {op} {right});");
            }
            else
            {
                AppendLine($"{prefix}{target} = {left} {op} {right};");
            }
        }
        public override void GenerateCode(ConvertValue value)
        {
            var target = Load(value);
            var source = Load(value.Value);
            var targetType = TypeGenerator[value.Type];

            string prefix = GetPrefix(value);
            
            // Fix: Handle Vector to Scalar conversion (e.g. i32(vec2)) which WGSL forbids
            var sourceType = TypeGenerator[value.Value.Type];

            bool isVectorSource = sourceType.StartsWith("vec");
            bool isScalarTarget = !targetType.StartsWith("vec") && !targetType.StartsWith("mat") && !targetType.StartsWith("array");

            if (isVectorSource && isScalarTarget)
            {
                // Extract X component. 
                AppendLine($"{prefix}{target} = {targetType}({source}.x);");
            }
            else
            {
                AppendLine($"{prefix}{target} = {targetType}({source});");
            }
        }

        public override void GenerateCode(global::ILGPU.IR.Values.GetField value)
        {
            // 1. Safety check: If this is a kernel index component (X, Y, Z) 
            // already hoisted in SetupIndexVariables, skip it.
            if (_hoistedIndexFields.Contains(value)) return;

            // 2. Identify if the object being accessed is DIRECTLY a Parameter (likely an ArrayView)
            // We use direct type check to avoid confusing hierarchical access (View.Stride.X) with Root access (View.Stride)
            if (ResolveToParameter(value.ObjectValue) is global::ILGPU.IR.Values.Parameter param)
            {
                int paramOffset = KernelParamOffset;
                if (param.Index >= paramOffset)
                {
                    IsMultiDim(param.ParameterType, out var isMultiDim, out var isView, out var is1DView, out var is2DView, out var is3DView);
                    if (isView)
                    {
                        var target = Load(value);
                        var rawType = UnwrapType(param.ParameterType);

                        // ROBUST TYPE DETECTION
                        string typeName = param.ParameterType.ToString();

                        if (rawType is global::ILGPU.IR.Types.StructureType st)
                        {


                        // Field 0 is always the actual pointer to the data
                        if (value.FieldSpan.Index == 0)
                        {
                            AppendLine($"let {target} = &param{param.Index}[0];");
                            return;
                        }

                        // Metadata handling (Length and Strides)
                        if (isMultiDim && rawType is StructureType st1)
                        {
                            var totalLen = $"i32(arrayLength(&param{param.Index}))";
                            
                            // Check hoisting to prevent shadowing
                            string prefix = _hoistedPrimitives.Contains(value) ? "" : "let ";

                             if (is3DView)
                            {
                                var width = $"param{param.Index}_stride[0]";
                                var height = $"param{param.Index}_stride[1]";
                                var depth = $"param{param.Index}_stride[2]";

                                // Flattened Access:
                                // 1: Width
                                // 2: Height
                                // 3: Depth
                                // 4: StrideY (Width)
                                // 5: StrideZ (Width*Height)

                                    switch (value.FieldSpan.Index)
                                    {
                                        case 1: AppendLine($"{prefix}{target} = {width};"); return;
                                        case 2: AppendLine($"{prefix}{target} = {height};"); return;
                                        case 3: AppendLine($"{prefix}{target} = {depth};"); return;
                                        case 4: AppendLine($"{prefix}{target} = {width};"); return;
                                        case 5: AppendLine($"{prefix}{target} = {width} * {height};"); return;
                                    }
                            }
                            else if (is2DView)
                            {
                                var width = $"param{param.Index}_stride[0]";
                                var height = $"param{param.Index}_stride[1]";

                                // Flattened Access:
                                // 1: Width
                                // 2: Height
                                // 3: StrideY (Width)

                                switch (value.FieldSpan.Index)
                                {
                                    case 1: AppendLine($"{prefix}{target} = {width};"); return;
                                    case 2: AppendLine($"{prefix}{target} = {height};"); return;
                                    case 3: AppendLine($"{prefix}{target} = {width};"); return;
                                }
                            }
                            else if (is1DView)
                            {
                                // For 1D, we verify if mapped to standard structure
                                // 1D ArrayView is (View, Index, Length) or (View, Length)?
                                // If base View, it has (Buffer, Index, Length).
                                // Usually accessed: Field 2 (Length).
                                
                                switch (value.FieldSpan.Index)
                                {
                                    case 1: AppendLine($"{prefix}{target} = 0;"); return;       // Index (Assume 0 for base view)
                                    case 2: AppendLine($"{prefix}{target} = {totalLen};"); return; // Length
                                }
                            }

                            // Fallback for unknown length access
                            AppendLine($"{prefix}{target} = {totalLen};");
                            return;
                        }
                    }
                }
            }
            }

                // 3. Special handling for Kernel Index Parameter (X, Y components)
            if (ResolveToParameter(value.ObjectValue) is global::ILGPU.IR.Values.Parameter kernelParam) 
            {
                 int paramOffset = KernelParamOffset;
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
                int paramOffset = KernelParamOffset;
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

        public override void GenerateCode(global::ILGPU.IR.Values.Barrier value)
        {
            AppendIndent();
            Builder.AppendLine("workgroupBarrier();");
        }

        public override void GenerateCode(PredicateBarrier value)
        {
            // PredicateBarrier is used for Group.All/Any, but in WGSL we 
            // must still hit the workgroupBarrier to sync memory visibility.
            AppendIndent();
            Builder.AppendLine("workgroupBarrier();");
        }

        public override void GenerateCode(MemoryBarrier value)
        {
            // Memory barriers in WGSL coordinate memory visibility.
            // workgroupBarrier() includes the functionality of a memory barrier.
            AppendIndent();
            Builder.AppendLine("workgroupBarrier();");
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