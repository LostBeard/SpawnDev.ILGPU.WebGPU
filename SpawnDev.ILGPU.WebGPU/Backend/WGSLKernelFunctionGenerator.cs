// ---------------------------------------------------------------------------------------
//                                 SpawnDev.ILGPU.WebGPU
//                        Copyright (c) 2024 SpawnDev Project
//
// File: WGSLKernelFunctionGenerator.cs
//
// WGSL kernel function generator for main compute shader entry points.
// ---------------------------------------------------------------------------------------

using global::ILGPU.Backends.EntryPoints;
using global::ILGPU.IR;
using global::ILGPU.IR.Analyses;
using global::ILGPU.IR.Types;
using global::ILGPU.IR.Values;
using global::ILGPU;
using System.Text;

namespace SpawnDev.ILGPU.WebGPU.Backend
{
    /// <summary>
    /// Kernel function generator for main compute shader entry points.
    /// Generates WGSL @compute functions with buffer bindings and workgroup configuration.
    /// </summary>
    internal sealed class WGSLKernelFunctionGenerator : WGSLCodeGenerator
    {
        #region Constants

        /// <summary>
        /// Format string for kernel view parameter names.
        /// </summary>
        public const string KernelViewNameFormat = "view_{0}";

        #endregion

        #region Instance

        /// <summary>
        /// Creates a new WGSL kernel function generator.
        /// </summary>
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

        /// <summary>
        /// Returns the associated entry point.
        /// </summary>
        public EntryPoint EntryPoint { get; }

        /// <summary>
        /// All dynamic shared memory allocations.
        /// </summary>
        public AllocaKindInformation DynamicSharedAllocations { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Generates buffer binding declarations.
        /// </summary>
        public override void GenerateHeader(StringBuilder builder)
        {
            // Emit type definitions first
            TypeGenerator.GenerateTypeDefinitions(builder);
            
            // Emit buffer bindings for parameters
            int bindingIdx = 0;
            
            // Skip index parameter if present (handled via global_id)
            int paramOffset = EntryPoint.IsExplicitlyGrouped ? 0 : 1;
            
            foreach (var param in Method.Parameters)
            {
                if (param.Index < paramOffset)
                    continue;
                
                var elementType = GetBufferElementType(param.ParameterType);
                var wgslType = TypeGenerator[elementType];
                
                // Determine if read-only or read-write
                string accessMode = "read_write";
                
                builder.AppendLine($"@group(0) @binding({bindingIdx}) var<storage, {accessMode}> param{param.Index} : array<{wgslType}>;");
                bindingIdx++;
            }
            
            builder.AppendLine();
        }

        /// <summary>
        /// Generates the compute shader entry point.
        /// </summary>
        public override void GenerateCode()
        {
            // Determine workgroup size based on index type
            string workgroupSize = GetWorkgroupSize();
            
            Builder.AppendLine($"@compute @workgroup_size({workgroupSize})");
            Builder.Append("fn main(");
            Builder.Append("@builtin(global_invocation_id) global_id : vec3<u32>");
            
            // Add optional builtins for explicitly grouped kernels
            if (EntryPoint.IsExplicitlyGrouped)
            {
                Builder.Append(", @builtin(local_invocation_id) local_id : vec3<u32>");
                Builder.Append(", @builtin(workgroup_id) workgroup_id : vec3<u32>");
                Builder.Append(", @builtin(num_workgroups) num_workgroups : vec3<u32>");
            }
            
            Builder.AppendLine(") {");
            PushIndent();

            // Setup index variables
            SetupIndexVariables();
            
            // Setup parameter bindings
            SetupParameterBindings();

            // Generate the kernel body
            GenerateCodeInternal();

            PopIndent();
            
            // Debug: Print generated WGSL
            Console.WriteLine("---------------- WGSL KERNEL ----------------");
            Console.WriteLine(Builder.ToString());
            Console.WriteLine("---------------------------------------------");
            
            Builder.AppendLine("}");
        }

        /// <summary>
        /// Gets the workgroup size string based on index type.
        /// </summary>
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


        /// <summary>
        /// Gets the element type for buffer binding.
        /// </summary>
        /// <summary>
        /// Gets the element type for buffer binding.
        /// </summary>
        private TypeNode GetBufferElementType(TypeNode type)
        {
            // Recursively unwrap structures to find the underlying pointer for Arrays/Views
            var current = type;
            
            while (current != null)
            {
                if (current is ViewType viewType)
                {
                    return viewType.ElementType;
                }
                else if (current is PointerType ptrType)
                {
                    return ptrType.ElementType;
                }
                else if (current is StructureType structType)
                {
                    // Only unwrap ILGPU ArrayView wrappers (2D, 3D)
                    // These are structs wrapping the actual View
                    if (structType.ToString().Contains("ArrayView") && structType.NumFields > 0)
                    {
                        current = structType.Fields[0];
                        continue;
                    }
                    break;
                }
                else
                {
                    break;
                }
            }
            
            return type;
        }

        /// <summary>
        /// Sets up index variable bindings from global_id.
        /// </summary>
        private void SetupIndexVariables()
        {
            if (EntryPoint.IsExplicitlyGrouped)
                return;
            
            // For implicitly grouped kernels, first parameter is the index
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

        /// <summary>
        /// Sets up parameter bindings.
        /// </summary>
        private void SetupParameterBindings()
        {
            int paramOffset = EntryPoint.IsExplicitlyGrouped ? 0 : 1;
            
            foreach (var param in Method.Parameters)
            {
                if (param.Index < paramOffset)
                    continue;
                
                // Parameters are already bound as global buffers
                var variable = Allocate(param);
                
                var bufferType = GetBufferElementType(param.ParameterType);
                bool isView = bufferType != param.ParameterType;

                // Check if parameter is scalar (primitive type) or simple struct (not a view)
                if (param.ParameterType.IsPrimitiveType || !isView)
                {
                    // For scalars/structs, load the value from the first element of the buffer
                    AppendLine($"var {variable.Name} = param{param.Index}[0];");
                }
                else
                {
                    // For structures (views) and pointers, bind to the buffer reference
                    AppendLine($"let {variable.Name} = &param{param.Index};");
                }
            }
        }

        /// <summary>
        /// Override to handle parameter access specially.
        /// </summary>
        public override void GenerateCode(Parameter parameter)
        {
            // Parameters are handled in SetupParameterBindings
        }

        /// <summary>
        /// Override LoadElementAddress to use buffer bindings.
        /// </summary>
        public override void GenerateCode(LoadElementAddress value)
        {
            var target = Load(value);
            var offset = Load(value.Offset);

            // Helper to try resolving parameter from source
            global::ILGPU.IR.Values.Parameter? ResolveParameter(global::ILGPU.IR.Value source)
            {
                if (source is global::ILGPU.IR.Values.Parameter p) return p;
                // GetField.ObjectValue is ValueReference, need to resolve to Value
                if (source is GetField gf && gf.ObjectValue.Resolve() is global::ILGPU.IR.Values.Parameter p2) return p2;
                return null;
            }

            // value.Source is ValueReference. Need to resolve to Value first?
            // LoadElementAddress.Source IS ValueReference.
            // But ResolveParameter takes Value.
            // Convert Reference to Value via Resolve()
            if (ResolveParameter(value.Source.Resolve()) is global::ILGPU.IR.Values.Parameter param)
            {
                int paramOffset = EntryPoint.IsExplicitlyGrouped ? 0 : 1;
                if (param.Index >= paramOffset)
                {
                    // Direct buffer access
                    // Use 'let' for consistency
                    AppendIndent();
                    Builder.Append("let ");
                    Builder.Append(target.Name);
                    Builder.Append(" = ");
                    Builder.Append($"&param{param.Index}[{offset}];");
                    Builder.AppendLine();
                    return;
                }
            }

            // Use 'let' for the result pointer
            var sourceVal = Load(value.Source);
            AppendIndent();
            Builder.Append("let ");
            Builder.Append(target.Name);
            Builder.Append(" = ");
            // Handle pointer indexing if source is a pointer variable (workaround for WGSL limitations)
            if (value.Source.Type.IsPointerType)
            {
                 // Check if it's a pointer to array we generated?
                 // Naive C-style indexing: &(*source)[offset]
                 Builder.Append($"&(*{sourceVal})[{offset}];");
            }
            else
            {
                 Builder.Append($"&{sourceVal}[{offset}];");
            }
            Builder.AppendLine();
        }

        /// <summary>
        /// Override Load to handle buffer element loads.
        /// </summary>
        public override void GenerateCode(global::ILGPU.IR.Values.Load load)
        {
            var target = Load(load);
            var source = Load(load.Source);
            Declare(target);
            
            // Check if loading from a pointer we created
            AppendLine($"{target} = *{source};");
        }

        /// <summary>
        /// Override Store to handle buffer element stores.
        /// </summary>
        public override void GenerateCode(Store store)
        {
            var address = Load(store.Target);
            var val = Load(store.Value);
            AppendLine($"*{address} = {val};");
        }

        /// <summary>
        /// Override GetField to handle ArrayView fields (Ptr, Length).
        /// </summary>
        public override void GenerateCode(GetField value)
        {
            // Handle Constants/Parameters
            if (value.ObjectValue.Resolve() is global::ILGPU.IR.Values.Parameter param)
            {
                int paramOffset = EntryPoint.IsExplicitlyGrouped ? 0 : 1;
               
                // 1. Handle Regular Kernel Arguments (ArrayViews, Pointers)
                // 1. Handle Regular Kernel Arguments (ArrayViews, Pointers)
                if (param.Index >= paramOffset)
                {
                    var bufferType = GetBufferElementType(param.ParameterType);
                    bool isView = bufferType != param.ParameterType;

                    if (isView)
                    {
                        var target = Load(value);
                        // Declare(target); // Use let for inference

                        // ArrayView Layout assumptions:
                        // Field 0: Buffer/Pointer -> Returns &paramN
                        // Field 1: Index/Offset -> Returns 0
                        // Field 2/3: Length -> Returns arrayLength
                        
                        // Check for multi-dimensional views to prevent using arrayLength as stride
                        bool isMultiDim = param.ParameterType.ToString().Contains("ArrayView2D") || 
                                          param.ParameterType.ToString().Contains("ArrayView3D");

                        if (value.FieldSpan.Index == 0)
                        {
                            // Return pointer to buffer
                            AppendLine($"let {target} = &param{param.Index};");
                            return;
                        }
                        
                        if (isMultiDim)
                        {
                            // Temporary: Return 0 for stride/length metadata on 2D/3D views
                            // prevents out-of-bounds access until metadata binding is implemented
                            AppendLine($"let {target} = 0;");
                            return;
                        }
                        else if (value.FieldSpan.Index == 1) // Index/Offset
                        {
                            string zero = "0"; 
                            AppendLine($"let {target} = {zero};");
                            return;
                        }
                        else if (value.FieldSpan.Index == 2 || value.FieldSpan.Index == 3) // Lengths
                        {
                            // Return array length
                            bool isInt64 = value.Type is PrimitiveType pt2 && pt2.BasicValueType == BasicValueType.Int64;
                            string cast = isInt64 ? "i32" : "i32"; 
                            AppendLine($"let {target} = bitcast<{cast}>(arrayLength(&param{param.Index}));");
                            return;
                        }
                    }
                }
                
                // 2. Handle Kernel Index Parameter (Index1D/2D/3D)
                // The Index parameter is mapped to i32/vec2/vec3 in WGSL.
                if (param.Index < paramOffset)
                {
                    // Index1D -> i32 (Field 0 = value)
                    // Index2D -> vec2 (Field 0 = x, Field 1 = y)
                    // Index3D -> vec3 (Field 0 = x, Field 1 = y, Field 2 = z)
                    
                    var target = Load(value);
                    // Declare(target); // Use let
                    var source = Load(value.ObjectValue);
                    
                    if (EntryPoint.IndexType == IndexType.Index1D)
                    {
                        if (value.FieldSpan.Index == 0)
                            AppendLine($"let {target} = {source};");
                         else
                            AppendLine($"let {target} = 0;");
                    }
                    else if (EntryPoint.IndexType == IndexType.Index2D)
                    {
                        string comp = value.FieldSpan.Index == 0 ? "x" : "y";
                        AppendLine($"let {target} = {source}.{comp};");
                    }
                    else if (EntryPoint.IndexType == IndexType.Index3D)
                    {
                        string comp = value.FieldSpan.Index == 0 ? "x" : (value.FieldSpan.Index == 1 ? "y" : "z");
                        AppendLine($"let {target} = {source}.{comp};");
                    }
                    
                    return;
                }
            }

            // Fallback to base implementation for non-parameter fields
            base.GenerateCode(value);
        }

        public override void GenerateCode(LoadFieldAddress value)
        {
            if (value.Source.Resolve() is global::ILGPU.IR.Values.Parameter param)
            {
                 int paramOffset = EntryPoint.IsExplicitlyGrouped ? 0 : 1;
                 if (param.Index < paramOffset)
                 {
                    var target = Load(value);
                    // Declare(target); // Use let
                    var source = Load(value.Source);
                    
                    // IF Index1D: Field 0 is the value.
                    if (EntryPoint.IndexType == IndexType.Index1D)
                    {
                         if (value.FieldSpan.Index == 0)
                            AppendLine($"let {target} = &{source};");
                         else
                         {
                            // Should not happen for Index1D usually, but if it does, return pointer to 0?
                            AppendLine($"var temp_{target.Name} : i32 = 0;");
                            AppendLine($"let {target} = &temp_{target.Name};");
                         }
                    }
                    else
                    {
                        // Index2D/3D
                        string comp = "x";
                        if (EntryPoint.IndexType == IndexType.Index2D)
                            comp = value.FieldSpan.Index == 0 ? "x" : "y";
                        else
                             comp = value.FieldSpan.Index == 0 ? "x" : (value.FieldSpan.Index == 1 ? "y" : "z");
                        
                        // We cannot take address of vector component directly.
                        // Create a temporary var copy.
                        // Note: Modifications to this pointer won't propagate back to Index!
                        // But Index is read-only usually.
                        var typeName = "i32"; // Components are i32
                        AppendLine($"var temp_{target.Name} : {typeName} = {source}.{comp};");
                        AppendLine($"let {target} = &temp_{target.Name};");
                    }
                    return;
                 }
            }
            base.GenerateCode(value);
        }

        #endregion
    }
}
