// ---------------------------------------------------------------------------------------
//                                 SpawnDev.ILGPU.WebGPU
//                        Copyright (c) 2024 SpawnDev Project
//
// File: WGSLCodeGenerator.cs
//
// Base WGSL code generator implementing IBackendCodeGenerator for WebGPU backend.
// ---------------------------------------------------------------------------------------

using global::ILGPU;
using global::ILGPU.Backends;
using global::ILGPU.Backends.EntryPoints;
using global::ILGPU.IR;
using global::ILGPU.IR.Analyses;
using global::ILGPU.IR.Types;
using global::ILGPU.IR.Values;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpawnDev.ILGPU.WebGPU.Backend
{
    /// <summary>
    /// Base class for WGSL code generation. Generates WGSL compute shader source
    /// from ILGPU IR values by implementing the IBackendCodeGenerator interface.
    /// </summary>
    public abstract partial class WGSLCodeGenerator : IBackendCodeGenerator<StringBuilder>
    {
        #region Nested Types

        /// <summary>
        /// Generation arguments for WGSL code generator construction.
        /// </summary>
        public readonly struct GeneratorArgs
        {
            /// <summary>
            /// Creates new generator args.
            /// </summary>
            public GeneratorArgs(
                WebGPUBackend backend,
                WGSLTypeGenerator typeGenerator,
                EntryPoint entryPoint,
                AllocaKindInformation sharedAllocations,
                AllocaKindInformation dynamicSharedAllocations)
            {
                Backend = backend;
                TypeGenerator = typeGenerator;
                EntryPoint = entryPoint;
                SharedAllocations = sharedAllocations;
                DynamicSharedAllocations = dynamicSharedAllocations;
            }

            /// <summary>The parent backend.</summary>
            public WebGPUBackend Backend { get; }

            /// <summary>The type generator.</summary>
            public WGSLTypeGenerator TypeGenerator { get; }

            /// <summary>The kernel entry point.</summary>
            public EntryPoint EntryPoint { get; }

            /// <summary>Shared memory allocations.</summary>
            public AllocaKindInformation SharedAllocations { get; }

            /// <summary>Dynamic shared memory allocations.</summary>
            public AllocaKindInformation DynamicSharedAllocations { get; }
        }

        /// <summary>
        /// Represents a variable in WGSL code.
        /// </summary>
        protected class Variable
        {
            public Variable(string name, string type)
            {
                Name = name;
                Type = type;
            }

            public string Name { get; }
            public string Type { get; }

            public override string ToString() => Name;
        }

        #endregion

        #region Instance

        private int varCounter = 0;
        private int labelCounter = 0;
        private readonly Dictionary<Value, Variable> valueVariables = new();
        private readonly Dictionary<BasicBlock, string> blockLabels = new();
        
        private StringBuilder prefixBuilder = new StringBuilder();
        private StringBuilder suffixBuilder = new StringBuilder();

        /// <summary>
        /// Constructs a new WGSL code generator.
        /// </summary>
        protected WGSLCodeGenerator(in GeneratorArgs args, Method method, Allocas allocas)
        {
            Backend = args.Backend;
            TypeGenerator = args.TypeGenerator;
            Method = method;
            Allocas = allocas;

            Builder = prefixBuilder;
        }

        #endregion

        #region Properties

        /// <summary>The parent backend.</summary>
        public WebGPUBackend Backend { get; }

        /// <summary>The type generator.</summary>
        public WGSLTypeGenerator TypeGenerator { get; }

        /// <summary>The current method being generated.</summary>
        public Method Method { get; }

        /// <summary>All local allocas.</summary>
        public Allocas Allocas { get; }

        /// <summary>The current string builder.</summary>
        public StringBuilder Builder { get; protected set; }

        /// <summary>Builder for variable declarations.</summary>
        public StringBuilder VariableBuilder { get; } = new StringBuilder();

        /// <summary>Current indentation level.</summary>
        protected int IndentLevel { get; set; } = 0;

        #endregion

        #region IBackendCodeGenerator

        /// <summary>
        /// Generates a function declaration header.
        /// </summary>
        public abstract void GenerateHeader(StringBuilder builder);

        /// <summary>
        /// Generates the function body code.
        /// </summary>
        public abstract void GenerateCode();

        /// <summary>
        /// Generates constant declarations (not used for WGSL).
        /// </summary>
        public void GenerateConstants(StringBuilder builder) { }

        /// <summary>
        /// Merges the generated code into the main builder.
        /// </summary>
        public void Merge(StringBuilder builder) => builder.Append(Builder);

        #endregion

        #region Variable Management

        /// <summary>
        /// Allocates a variable for a value.
        /// </summary>
        protected Variable Allocate(Value value)
        {
            var name = $"v_{varCounter++}";
            var type = TypeGenerator[value.Type];
            var variable = new Variable(name, type);
            valueVariables[value] = variable;
            return variable;
        }

        /// <summary>
        /// Allocates a variable for a type.
        /// </summary>
        protected Variable AllocateType(TypeNode type)
        {
            var name = $"v_{varCounter++}";
            var wgslType = TypeGenerator[type];
            return new Variable(name, wgslType);
        }

        /// <summary>
        /// Gets the variable for a value, allocating if necessary.
        /// </summary>
        protected Variable Load(Value value)
        {
            if (!valueVariables.TryGetValue(value, out var variable))
            {
                variable = Allocate(value);
            }
            return variable;
        }

        /// <summary>
        /// Binds a value to a variable.
        /// </summary>
        protected void Bind(Value value, Variable variable)
        {
            valueVariables[value] = variable;
        }

        protected readonly HashSet<string> declaredVariables = new();

        /// <summary>
        /// Declares a variable in the current scope.
        /// </summary>
        protected void Declare(Variable variable)
        {
            if (declaredVariables.Contains(variable.Name)) return;
            declaredVariables.Add(variable.Name);
            
            AppendIndent();
            Builder.Append("var ");
            Builder.Append(variable.Name);
            Builder.Append(" : ");
            Builder.Append(variable.Type);
            Builder.AppendLine(";");
        }

        #endregion

        #region Label Management

        /// <summary>
        /// Declares a new label for a block.
        /// </summary>
        protected string DeclareLabel()
        {
            return $"L_{Method.Id}_{labelCounter++}";
        }

        /// <summary>
        /// Gets or creates a label for a block.
        /// </summary>
        protected string GetBlockLabel(BasicBlock block)
        {
            if (!blockLabels.TryGetValue(block, out var label))
            {
                label = DeclareLabel();
                blockLabels[block] = label;
            }
            return label;
        }

        /// <summary>
        /// Marks a label in the output.
        /// </summary>
        protected void MarkLabel(string label)
        {
            // WGSL doesn't have labels like C, use block IDs in switch
        }

        #endregion

        #region Code Emission Helpers

        /// <summary>
        /// Appends indentation to the builder.
        /// </summary>
        protected void AppendIndent()
        {
            for (int i = 0; i < IndentLevel; i++)
                Builder.Append("    ");
        }

        /// <summary>
        /// Increases indentation.
        /// </summary>
        protected void PushIndent() => IndentLevel++;

        /// <summary>
        /// Decreases indentation.
        /// </summary>
        protected void PopIndent() => IndentLevel--;

        /// <summary>
        /// Appends a line with indentation.
        /// </summary>
        protected void AppendLine(string line)
        {
            AppendIndent();
            Builder.AppendLine(line);
        }

        /// <summary>
        /// Appends a line without indentation.
        /// </summary>
        protected void AppendLineRaw(string line)
        {
            Builder.AppendLine(line);
        }

        /// <summary>
        /// Begins a function body.
        /// </summary>
        protected void BeginFunctionBody()
        {
            Builder.AppendLine("{");
            PushIndent();
        }

        /// <summary>
        /// Finishes a function body.
        /// </summary>
        protected void FinishFunctionBody()
        {
            PopIndent();
            Builder.AppendLine("}");
        }

        #endregion

        #region IR Traversal

        /// <summary>
        /// Generates code for all blocks in the method.
        /// </summary>
        protected void GenerateCodeInternal()
        {
            var blocks = Method.Blocks;
            
            // Setup local allocations
            SetupAllocations(Allocas.LocalAllocations, MemoryAddressSpace.Local);

            // Simple case: single block, no control flow
            if (blocks.Count == 1)
            {
            foreach (var valueEntry in blocks.First())
                {
                    GenerateCodeFor(valueEntry.Value);
                }
                return;
            }

            // Multiple blocks: use loop/switch pattern for structured control flow
            // WGSL doesn't have gotos, so we emulate with a state machine
            AppendLine("var current_block : i32 = 0;");
            AppendLine("loop {");
            PushIndent();
            AppendLine("switch (current_block) {");
            PushIndent();

            int blockIndex = 0;
            foreach (var block in blocks)
            {
                AppendLine($"case {blockIndex}: {{");
                PushIndent();

                foreach (var valueEntry in block)
                {
                    GenerateCodeFor(valueEntry.Value);
                }

                PopIndent();
                AppendLine("}");
                blockIndex++;
            }

            AppendLine("default: { break; }");
            PopIndent();
            AppendLine("}");
            AppendLine("if (current_block == -1) { break; }");
            PopIndent();
            AppendLine("}");
        }

        /// <summary>
        /// Gets the block index for control flow.
        /// </summary>
        protected int GetBlockIndex(BasicBlock block)
        {
            int index = 0;
            foreach (var b in Method.Blocks)
            {
                if (b == block) return index;
                index++;
            }
            return -1;
        }

        /// <summary>
        /// Sets up local/shared memory allocations.
        /// </summary>
        protected void SetupAllocations(AllocaKindInformation allocas, MemoryAddressSpace addressSpace)
        {
            foreach (var allocaInfo in allocas)
            {
                var variable = Allocate(allocaInfo.Alloca);
                var elementType = TypeGenerator[allocaInfo.ElementType];
                
                if (allocaInfo.IsArray)
                {
                    AppendLine($"var {variable.Name} : array<{elementType}, {allocaInfo.ArraySize}>;");
                }
                else
                {
                    AppendLine($"var {variable.Name} : {elementType};");
                }
            }
        }

        #endregion

        #region Value Visitors - Dispatch

        /// <summary>
        /// Generates code for a value using the visitor pattern.
        /// </summary>
        protected void GenerateCodeFor(Value value)
        {
            // Skip void values and already-handled values
            if (value.Type.IsVoidType && 
                !(value is TerminatorValue) && 
                !(value is Store) &&
                !(value is MemoryBarrier))
                return;

            // TRACE LOGGING
            AppendLine($"// Visit: {value.GetType().Name} [DISPATCHED]");

            switch (value)
            {
                // Parameters
                case global::ILGPU.IR.Values.Parameter p:
                    GenerateCode(p);
                    break;
                
                case global::ILGPU.IR.Values.MethodCall v:
                     GenerateCode(v);
                     break;

                // Arithmetic
                case global::ILGPU.IR.Values.BinaryArithmeticValue v:
                    GenerateCode(v);
                    break;
                case global::ILGPU.IR.Values.UnaryArithmeticValue v:
                    GenerateUnOp(v);
                    break;
                case global::ILGPU.IR.Values.TernaryArithmeticValue v:
                    GenerateCode(v);
                    break;

                // Comparisons
                case global::ILGPU.IR.Values.CompareValue v:
                    GenerateCode(v);
                    break;

                // Conversions
                case global::ILGPU.IR.Values.ConvertValue v:
                    GenerateCode(v);
                    break;

                // Memory Operations
                case global::ILGPU.IR.Values.Load v:
                    GenerateCode(v);
                    break;
                case global::ILGPU.IR.Values.Store v:
                    GenerateCode(v);
                    break;
                case global::ILGPU.IR.Values.LoadElementAddress v:
                    GenerateCode(v);
                    break;
                case global::ILGPU.IR.Values.LoadFieldAddress v:
                    GenerateCode(v);
                    break;
                case global::ILGPU.IR.Values.Alloca v:
                    GenerateCode(v);
                    break;
                case global::ILGPU.IR.Values.NewView v:
                    GenerateCode(v);
                    break;

                // Constants
                case global::ILGPU.IR.Values.PrimitiveValue v:
                    GenerateCode(v);
                    break;
                case global::ILGPU.IR.Values.NullValue v:
                    GenerateCode(v);
                    break;
                case global::ILGPU.IR.Values.StringValue v:
                    GenerateCode(v);
                    break;

                // Phi
                case global::ILGPU.IR.Values.PhiValue v:
                    GenerateCode(v);
                    break;

                // Structures
                case global::ILGPU.IR.Values.StructureValue v:
                    GenerateCode(v);
                    break;
                case global::ILGPU.IR.Values.GetField v:
                    GenerateCode(v);
                    break;
                case global::ILGPU.IR.Values.SetField v:
                    GenerateCode(v);
                    break;

                // Device Constants
                case global::ILGPU.IR.Values.GridIndexValue v:
                    GenerateCode(v);
                    break;
                case global::ILGPU.IR.Values.GroupIndexValue v:
                    GenerateCode(v);
                    break;
                case global::ILGPU.IR.Values.GridDimensionValue v:
                    GenerateCode(v);
                    break;
                case global::ILGPU.IR.Values.GroupDimensionValue v:
                    GenerateCode(v);
                    break;
                case global::ILGPU.IR.Values.WarpSizeValue v:
                    GenerateCode(v);
                    break;
                case global::ILGPU.IR.Values.LaneIdxValue v:
                    GenerateCode(v);
                    break;

                // Control Flow
                case global::ILGPU.IR.Values.ReturnTerminator v:
                    GenerateCode(v);
                    break;
                case global::ILGPU.IR.Values.UnconditionalBranch v:
                    GenerateCode(v);
                    break;
                case global::ILGPU.IR.Values.IfBranch v:
                    GenerateCode(v);
                    break;
                case global::ILGPU.IR.Values.SwitchBranch v:
                    GenerateCode(v);
                    break;



                // Casts
                case global::ILGPU.IR.Values.IntAsPointerCast v:
                    GenerateCode(v);
                    break;
                case global::ILGPU.IR.Values.PointerAsIntCast v:
                    GenerateCode(v);
                    break;
                case global::ILGPU.IR.Values.PointerCast v:
                    GenerateCode(v);
                    break;
                case global::ILGPU.IR.Values.AddressSpaceCast v:
                    GenerateCode(v);
                    break;
                case global::ILGPU.IR.Values.FloatAsIntCast v:
                    GenerateCode(v);
                    break;
                case global::ILGPU.IR.Values.IntAsFloatCast v:
                    GenerateCode(v);
                    break;

                // Atomics & Barriers
                case global::ILGPU.IR.Values.GenericAtomic v:
                    GenerateCode(v);
                    break;
                case global::ILGPU.IR.Values.AtomicCAS v:
                    GenerateCode(v);
                    break;
                case global::ILGPU.IR.Values.MemoryBarrier v:
                    GenerateCode(v);
                    break;
                case global::ILGPU.IR.Values.Barrier v:
                    GenerateCode(v);
                    break;
                case global::ILGPU.IR.Values.PredicateBarrier v:
                    GenerateCode(v);
                    break;

                // Warp Operations
                case global::ILGPU.IR.Values.Broadcast v:
                    GenerateCode(v);
                    break;
                case global::ILGPU.IR.Values.WarpShuffle v:
                    GenerateCode(v);
                    break;
                case global::ILGPU.IR.Values.SubWarpShuffle v:
                    GenerateCode(v);
                    break;

                // Debug/IO
                case global::ILGPU.IR.Values.DebugAssertOperation v:
                    GenerateCode(v);
                    break;
                case global::ILGPU.IR.Values.WriteToOutput v:
                    GenerateCode(v);
                    break;

                // Other
                case global::ILGPU.IR.Values.Predicate v:
                    GenerateCode(v);
                    break;
                case global::ILGPU.IR.Values.DynamicMemoryLengthValue v:
                    GenerateCode(v);
                    break;
                case global::ILGPU.IR.Values.AlignTo v:
                    GenerateCode(v);
                    break;
                case global::ILGPU.IR.Values.AsAligned v:
                    GenerateCode(v);
                    break;
                case global::ILGPU.IR.Values.LanguageEmitValue v:
                    GenerateCode(v);
                    break;

                default:
                    AppendLine($"// Unhandled value type: {value.GetType().Name}");
                    break;
            }
        }

        #endregion

        #region Value Visitors - Implementation

        // Parameters
        public virtual void GenerateCode(Parameter parameter)
        {
            // Parameters are typically handled in the kernel generator
        }

        // Arithmetic
        public virtual void GenerateCode(BinaryArithmeticValue value)
        {
            var target = Load(value);
            var left = Load(value.Left);
            var right = Load(value.Right);

            string op = value.Kind switch
            {
                BinaryArithmeticKind.Add => "+",
                BinaryArithmeticKind.Sub => "-",
                BinaryArithmeticKind.Mul => "*",
                BinaryArithmeticKind.Div => "/",
                BinaryArithmeticKind.Rem => "%",
                BinaryArithmeticKind.And => "&",
                BinaryArithmeticKind.Or => "|",
                BinaryArithmeticKind.Xor => "^",
                BinaryArithmeticKind.Shl => "<<",
                BinaryArithmeticKind.Shr => ">>",
                BinaryArithmeticKind.Min => "min",
                BinaryArithmeticKind.Max => "max",
                _ => "+"
            };

            Declare(target);

            // Handle pointer arithmetic (e.g., &(*ptr)[offset])
            if (value.Kind == BinaryArithmeticKind.Add)
            {
                if (value.Left.Type.IsPointerType)
                {
                    AppendLine($"{target} = &(*{left})[{right}];");
                    return;
                }
                else if (value.Right.Type.IsPointerType)
                {
                    AppendLine($"{target} = &(*{right})[{left}];");
                    return;
                }
            }

            if (value.Kind == BinaryArithmeticKind.Min || value.Kind == BinaryArithmeticKind.Max)
            {
                AppendLine($"{target} = {op}({left}, {right});");
            }
            else
            {
                AppendLine($"{target} = {left} {op} {right};");
            }
        }

        public virtual void GenerateCode(UnaryArithmeticValue value)
        {
            GenerateUnOp(value);
        }

        private void GenerateUnOp(UnaryArithmeticValue value)
        {
            var target = Load(value);
            var operand = Load(value.Value);
            Declare(target);

            string result = value.Kind switch
            {
                UnaryArithmeticKind.Neg => $"-{operand}",
                UnaryArithmeticKind.Not => TypeGenerator[value.Value.Type] == "bool" ? $"!{operand}" : $"~{operand}",
                
                // Math Intrinsics (Float)
                UnaryArithmeticKind.Abs => $"abs({operand})",
                UnaryArithmeticKind.SinF => $"sin({operand})",
                UnaryArithmeticKind.CosF => $"cos({operand})",
                UnaryArithmeticKind.TanF => $"tan({operand})",
                UnaryArithmeticKind.AsinF => $"asin({operand})",
                UnaryArithmeticKind.AcosF => $"acos({operand})",
                UnaryArithmeticKind.AtanF => $"atan({operand})",
                UnaryArithmeticKind.SinhF => $"sinh({operand})",
                UnaryArithmeticKind.CoshF => $"cosh({operand})",
                UnaryArithmeticKind.TanhF => $"tanh({operand})",
                UnaryArithmeticKind.ExpF => $"exp({operand})",
                UnaryArithmeticKind.Exp2F => $"exp2({operand})",
                UnaryArithmeticKind.LogF => $"log({operand})",
                UnaryArithmeticKind.Log2F => $"log2({operand})",
                UnaryArithmeticKind.SqrtF => $"sqrt({operand})",
                UnaryArithmeticKind.RsqrtF => $"inverseSqrt({operand})",
                UnaryArithmeticKind.FloorF => $"floor({operand})",
                UnaryArithmeticKind.CeilingF => $"ceil({operand})",

                _ => "DEBUG_MISSING"
            };

            if (result == "DEBUG_MISSING")
            {
                AppendLine($"// [WGSL] Unhandled UnaryArithmeticKind: {value.Kind}");
                result = $"unhandled_unary({operand})"; 
            }

            AppendLine($"{target} = {result};");
        }

        public virtual void GenerateCode(TernaryArithmeticValue value)
        {
            var target = Load(value);
            var first = Load(value.First);
            var second = Load(value.Second);
            var third = Load(value.Third);
            Declare(target);

            string result = value.Kind switch
            {
                TernaryArithmeticKind.MultiplyAdd => $"fma({first}, {second}, {third})",
                _ => $"({first} * {second} + {third})"
            };

            AppendLine($"{target} = {result};");
        }

        // Comparisons
        public virtual void GenerateCode(CompareValue value)
        {
            var target = Load(value);
            var left = Load(value.Left);
            var right = Load(value.Right);
            Declare(target);

            string op = value.Kind switch
            {
                CompareKind.Equal => "==",
                CompareKind.NotEqual => "!=",
                CompareKind.LessThan => "<",
                CompareKind.LessEqual => "<=",
                CompareKind.GreaterThan => ">",
                CompareKind.GreaterEqual => ">=",
                _ => "=="
            };

            AppendLine($"{target} = {left} {op} {right};");
        }

        // Conversions
        public virtual void GenerateCode(ConvertValue value)
        {
            var target = Load(value);
            var source = Load(value.Value);
            var targetType = TypeGenerator[value.Type];
            Declare(target);
            AppendLine($"{target} = {targetType}({source});");
        }

        // Memory Operations
        public virtual void GenerateCode(global::ILGPU.IR.Values.Load loadVal)
        {
            var target = Load(loadVal);
            var source = Load(loadVal.Source);
            Declare(target);

            var targetType = TypeGenerator[loadVal.Type];
            string sourceType = targetType; 
            bool isAtomic = IsAtomicPointer(loadVal.Source);

            if (loadVal.Source.Type is global::ILGPU.IR.Types.PointerType ptrType)
            {
                var elemType = ptrType.ElementType;
                sourceType = TypeGenerator[elemType];
            }

            if (isAtomic)
            {
                 AppendLine($"{target} = atomicLoad({source});");
            }
            else if (targetType != sourceType)
            {
                AppendLine($"{target} = bitcast<{targetType}>(*{source});");
            }
            else
            {
                AppendLine($"{target} = *{source};");
            }
        }

        public virtual void GenerateCode(global::ILGPU.IR.Values.Store storeVal)
        {
            var address = Load(storeVal.Target);
            var val = Load(storeVal.Value);

            bool isAtomic = IsAtomicPointer(storeVal.Target);

            if (isAtomic)
            {
                AppendLine($"atomicStore({address}, {val});");
            }
            else
            {
                AppendLine($"*{address} = {val};");
            }
        }

        protected virtual bool IsAtomicPointer(Value ptr)
        {
            if (ptr.Type is global::ILGPU.IR.Types.PointerType ptrType)
            {
                var elemTypeStr = TypeGenerator[ptrType.ElementType];
                if (elemTypeStr.Contains("atomic")) return true;
                var elemType = ptrType.ElementType;
                if (elemType.ToString().Contains("Index1D") || elemType.ToString().Contains("LongIndex1D"))
                    return true;
            }
            return false;
        }

        public virtual void GenerateCode(LoadElementAddress value)
        {
            var target = Load(value);
            var source = Load(value.Source);
            var offset = Load(value.Offset);
            AppendIndent();
            Builder.Append("let ");
            Builder.Append(target.Name);
            Builder.Append(" = ");
            Builder.Append($"&{source}[{offset}];");
            Builder.AppendLine();
        }

        public virtual void GenerateCode(global::ILGPU.IR.Values.NewView value)
        {
            var target = Load(value);
            var source = Load(value.Pointer);
            Declare(target);
            AppendLine($"{target} = {source}; // newView");
        }

        public virtual void GenerateCode(LoadFieldAddress value)
        {
            var target = Load(value);
            var source = Load(value.Source);
            AppendIndent();
            Builder.Append("let ");
            Builder.Append(target.Name);
            Builder.Append(" = ");
            
            string fieldName = $"field_{value.FieldSpan.Index}";
            if (IsIndexType(value.Source.Type))
            {
                fieldName = value.FieldSpan.Index switch {
                    0 => "x",
                    1 => "y",
                    2 => "z",
                    _ => fieldName
                };
            }
            
            Builder.Append($"&(*{source}).{fieldName};");
            Builder.AppendLine();
        }

        public virtual void GenerateCode(Alloca value)
        {
            // Already handled in SetupAllocations
        }

        // Constants
        public virtual void GenerateCode(PrimitiveValue value)
        {
            var target = Load(value);
            var type = TypeGenerator[value.Type];
            Declare(target);

            string valStr = value.BasicValueType switch
            {
                BasicValueType.Int1 => value.Int1Value ? "true" : "false",
                BasicValueType.Int8 => value.Int8Value.ToString(),
                BasicValueType.Int16 => value.Int16Value.ToString(),
                BasicValueType.Int32 => value.Int32Value.ToString(),
                BasicValueType.Int64 => value.Int64Value.ToString(),
                BasicValueType.Float16 => FormatFloat(value.Float32Value),
                BasicValueType.Float32 => FormatFloat(value.Float32Value),
                BasicValueType.Float64 => FormatFloat((float)value.Float64Value),
                _ => "0"
            };

            if (value.BasicValueType != BasicValueType.Int1)
            {
                AppendLine($"{target} = {type}({valStr});");
            }
            else
            {
                AppendLine($"{target} = {valStr};");
            }
        }

        private string FormatFloat(float value)
        {
            if (float.IsNaN(value)) return "0.0";
            if (float.IsPositiveInfinity(value)) return "3.402823e+38";
            if (float.IsNegativeInfinity(value)) return "-3.402823e+38";
            
            var str = value.ToString("G9");
            if (!str.Contains('.') && !str.Contains('e') && !str.Contains('E'))
                str += ".0";
            return str;
        }

        public virtual void GenerateCode(NullValue value)
        {
            var target = Load(value);
            Declare(target);
            AppendLine($"{target} = {target.Type}(); // null");
        }

        public virtual void GenerateCode(StringValue value)
        {
            AppendLine($"// String: {value.String}");
        }

        // Phi
        public virtual void GenerateCode(PhiValue value)
        {
            var target = Load(value);
            Declare(target);
        }

        // Structures
        public virtual void GenerateCode(StructureValue value)
        {
            var target = Load(value);
            Declare(target);
            var sb = new StringBuilder();
            sb.Append($"{target} = {target.Type}(");
            for (int i = 0; i < value.Count; i++)
            {
                if (i > 0) sb.Append(", ");
                sb.Append(Load(value[i]));
            }
            sb.Append(");");
            AppendLine(sb.ToString());
        }

        public virtual void GenerateCode(GetField value)
        {
            var target = Load(value);
            var source = Load(value.ObjectValue);
            Declare(target);
            
            string fieldName = $"field_{value.FieldSpan.Index}";
            if (IsIndexType(value.ObjectValue.Type))
            {
                fieldName = value.FieldSpan.Index switch {
                    0 => "x",
                    1 => "y",
                    2 => "z",
                    _ => fieldName
                };
            }
            
            AppendLine($"{target} = {source}.{fieldName};");
        }

        public virtual void GenerateCode(SetField value)
        {
            var target = Load(value);
            var source = Load(value.ObjectValue);
            var fieldValue = Load(value.Value);
            Declare(target);
            AppendLine($"{target} = {source};");
            
            string fieldName = $"field_{value.FieldSpan.Index}";
            if (IsIndexType(value.ObjectValue.Type))
            {
                fieldName = value.FieldSpan.Index switch {
                    0 => "x",
                    1 => "y",
                    2 => "z",
                    _ => fieldName
                };
            }
            
            AppendLine($"{target}.{fieldName} = {fieldValue};");
        }
        
        protected bool IsIndexType(TypeNode type)
        {
            var typeName = type.ToString();
            return typeName.Contains("Index") && 
                   (typeName.Contains("1D") || typeName.Contains("2D") || typeName.Contains("3D"));
        }

        // Device Constants
        public virtual void GenerateCode(GridIndexValue value)
        {
            var target = Load(value);
            Declare(target);
            string dim = value.Dimension switch
            {
                DeviceConstantDimension3D.X => "x",
                DeviceConstantDimension3D.Y => "y",
                DeviceConstantDimension3D.Z => "z",
                _ => "x"
            };
            AppendLine($"{target} = global_id.{dim};");
        }

        public virtual void GenerateCode(GroupIndexValue value)
        {
            var target = Load(value);
            Declare(target);
            string dim = value.Dimension switch
            {
                DeviceConstantDimension3D.X => "x",
                DeviceConstantDimension3D.Y => "y",
                DeviceConstantDimension3D.Z => "z",
                _ => "x"
            };
            AppendLine($"{target} = local_id.{dim};");
        }

        public virtual void GenerateCode(GridDimensionValue value)
        {
            var target = Load(value);
            Declare(target);
            string dim = value.Dimension switch
            {
                DeviceConstantDimension3D.X => "x",
                DeviceConstantDimension3D.Y => "y",
                DeviceConstantDimension3D.Z => "z",
                _ => "x"
            };
            AppendLine($"{target} = num_workgroups.{dim} * workgroup_size.{dim};");
        }

        public virtual void GenerateCode(GroupDimensionValue value)
        {
            var target = Load(value);
            Declare(target);
            string dim = value.Dimension switch
            {
                DeviceConstantDimension3D.X => "x",
                DeviceConstantDimension3D.Y => "y",
                DeviceConstantDimension3D.Z => "z",
                _ => "x"
            };
            AppendLine($"{target} = workgroup_size.{dim};");
        }

        public virtual void GenerateCode(WarpSizeValue value)
        {
            var target = Load(value);
            Declare(target);
            AppendLine($"{target} = 32u; // WGSL subgroup size estimate");
        }

        public virtual void GenerateCode(LaneIdxValue value)
        {
            var target = Load(value);
            Declare(target);
            AppendLine($"{target} = subgroup_invocation_id;");
        }

        // Control Flow
        public virtual void GenerateCode(ReturnTerminator value)
        {
            if (value.IsVoidReturn)
            {
                AppendLine("current_block = -1; // return");
                AppendLine("break;");
            }
            else
            {
                var retVal = Load(value.ReturnValue);
                AppendLine($"// return {retVal}");
                AppendLine("current_block = -1;");
                AppendLine("break;");
            }
        }

        public virtual void GenerateCode(UnconditionalBranch branch)
        {
            EmitPhiAssignments(branch.BasicBlock, branch.Target);
            int targetIdx = GetBlockIndex(branch.Target);
            AppendLine($"current_block = {targetIdx};");
            AppendLine("continue;");
        }

        public virtual void GenerateCode(IfBranch branch)
        {
            var cond = Load(branch.Condition);
            int trueIdx = GetBlockIndex(branch.TrueTarget);
            int falseIdx = GetBlockIndex(branch.FalseTarget);

            AppendLine($"if ({cond}) {{");
            PushIndent();
            EmitPhiAssignments(branch.BasicBlock, branch.TrueTarget);
            AppendLine($"current_block = {trueIdx};");
            PopIndent();
            AppendLine("} else {");
            PushIndent();
            EmitPhiAssignments(branch.BasicBlock, branch.FalseTarget);
            AppendLine($"current_block = {falseIdx};");
            PopIndent();
            AppendLine("}");
            AppendLine("continue;");
        }

        public virtual void GenerateCode(SwitchBranch branch)
        {
            var selector = Load(branch.Condition);
            AppendLine($"switch ({selector}) {{");
            PushIndent();
            
            for (int i = 0; i < branch.NumCasesWithoutDefault; i++)
            {
                var target = branch.GetCaseTarget(i);
                int targetIdx = GetBlockIndex(target);
                AppendLine($"case {i}: {{");
                PushIndent();
                EmitPhiAssignments(branch.BasicBlock, target);
                AppendLine($"current_block = {targetIdx};");
                PopIndent();
                AppendLine("}");
            }

            int defaultIdx = GetBlockIndex(branch.DefaultBlock);
            AppendLine("default: {");
            PushIndent();
            EmitPhiAssignments(branch.BasicBlock, branch.DefaultBlock);
            AppendLine($"current_block = {defaultIdx};");
            PopIndent();
            AppendLine("}");

            PopIndent();
            AppendLine("}");
            AppendLine("continue;");
        }

        protected void EmitPhiAssignments(BasicBlock sourceBlock, BasicBlock targetBlock)
        {
            foreach (var valueEntry in targetBlock)
            {
                if (valueEntry.Value is PhiValue phi)
                {
                    var phiVar = Load(phi);
                    var srcValue = phi.GetValue(sourceBlock);
                    if (srcValue != null)
                    {
                        var srcVar = Load(srcValue);
                        AppendLine($"{phiVar} = {srcVar};");
                    }
                }
            }
        }

        // Method Calls
        public virtual void GenerateCode(MethodCall methodCall)
        {
            var target = Load(methodCall);
            Declare(target);
            
            string name = methodCall.Target.Name;
            // Map common intrinsics if they appear as method calls
            string? wgslFunc = name switch
            {
                var n when n.Contains("Sin") => "sin",
                var n when n.Contains("Cos") => "cos",
                var n when n.Contains("Tan") => "tan",
                var n when n.Contains("Asin") => "asin",
                var n when n.Contains("Acos") => "acos",
                var n when n.Contains("Atan") => "atan",
                var n when n.Contains("Sqrt") => "sqrt",
                var n when n.Contains("Abs") => "abs",
                var n when n.Contains("Pow") => "pow",
                var n when n.Contains("Log") => "log",
                var n when n.Contains("Exp") => "exp",
                var n when n.Contains("Floor") => "floor",
                var n when n.Contains("Ceiling") => "ceil",
                var n when n.Contains("Min") => "min",
                var n when n.Contains("Max") => "max",
                var n when n.Contains("FusedMultiplyAdd") => "fma",
                _ => null
            };

            if (wgslFunc != null)
            {
                if (methodCall.Count == 1)
                {
                    var arg = Load(methodCall[0]);
                    AppendLine($"{target} = {wgslFunc}({arg});");
                    return;
                }
                else if (methodCall.Count == 2)
                {
                    var arg1 = Load(methodCall[0]);
                    var arg2 = Load(methodCall[1]);
                    AppendLine($"{target} = {wgslFunc}({arg1}, {arg2});");
                    return;
                }
            }

            AppendLine($"// Call: {methodCall.Target.Name} (Unmapped)");
            // Probe Value 2
            AppendLine($"{target} = 12345.0;"); 
        }

        // Casts
        public virtual void GenerateCode(IntAsPointerCast value)
        {
            var target = Load(value);
            var source = Load(value.Value);
            Declare(target);
            AppendLine($"{target} = {source}; // intAsPtr");
        }

        public virtual void GenerateCode(PointerAsIntCast value)
        {
            var target = Load(value);
            var source = Load(value.Value);
            Declare(target);
            AppendLine($"{target} = {target.Type}({source}); // ptrAsInt");
        }

        public virtual void GenerateCode(PointerCast value)
        {
            var target = Load(value);
            var source = Load(value.Value);
            Declare(target);
            AppendLine($"{target} = {source}; // ptrCast");
        }

        public virtual void GenerateCode(AddressSpaceCast value)
        {
            var target = Load(value);
            var source = Load(value.Value);
            Declare(target);
            AppendLine($"{target} = {source}; // addrSpaceCast");
        }

        public virtual void GenerateCode(FloatAsIntCast value)
        {
            var target = Load(value);
            var source = Load(value.Value);
            Declare(target);
            AppendLine($"{target} = bitcast<{target.Type}>({source});");
        }

        public virtual void GenerateCode(IntAsFloatCast value)
        {
            var target = Load(value);
            var source = Load(value.Value);
            Declare(target);
            AppendLine($"{target} = bitcast<{target.Type}>({source});");
        }

        // Atomics & Barriers
        public virtual void GenerateCode(GenericAtomic value)
        {
            var target = Load(value);
            var ptr = Load(value.Target);
            var val = Load(value.Value);
            Declare(target);

            string op = value.Kind switch
            {
                AtomicKind.Add => "atomicAdd",
                AtomicKind.And => "atomicAnd",
                AtomicKind.Or => "atomicOr",
                AtomicKind.Xor => "atomicXor",
                AtomicKind.Max => "atomicMax",
                AtomicKind.Min => "atomicMin",
                AtomicKind.Exchange => "atomicExchange",
                _ => "atomicAdd"
            };

            AppendLine($"{target} = {op}({ptr}, {val});");
        }

        public virtual void GenerateCode(AtomicCAS value)
        {
            var target = Load(value);
            var ptr = Load(value.Target);
            var cmp = Load(value.Value);
            var val = Load(value.CompareValue);
            Declare(target);
            AppendLine($"{target} = atomicCompareExchangeWeak({ptr}, {cmp}, {val}).old_value;");
        }

        public virtual void GenerateCode(MemoryBarrier value)
        {
            AppendLine("storageBarrier();");
        }

        public virtual void GenerateCode(global::ILGPU.IR.Values.Barrier value)
        {
            AppendLine("workgroupBarrier();");
        }

        public virtual void GenerateCode(PredicateBarrier value)
        {
            AppendLine("workgroupBarrier();");
        }

        // Warp Operations
        public virtual void GenerateCode(Broadcast value)
        {
            var target = Load(value);
            var source = Load(value.Variable);
            Declare(target);
            AppendLine($"{target} = subgroupBroadcastFirst({source});");
        }

        public virtual void GenerateCode(WarpShuffle value)
        {
            var target = Load(value);
            var source = Load(value.Variable);
            var origin = Load(value.Origin);
            Declare(target);
            AppendLine($"{target} = subgroupShuffle({source}, {origin});");
        }

        public virtual void GenerateCode(SubWarpShuffle value)
        {
            var target = Load(value);
            var source = Load(value.Variable);
            var origin = Load(value.Origin);
            Declare(target);
            AppendLine($"{target} = subgroupShuffle({source}, {origin});");
        }

        // Debug/IO
        public virtual void GenerateCode(DebugAssertOperation value)
        {
            // WGSL doesn't support debug assertions
        }

        public virtual void GenerateCode(WriteToOutput value)
        {
            // WGSL doesn't support stdout
        }

        // Other
        public virtual void GenerateCode(Predicate value)
        {
            var target = Load(value);
            var cond = Load(value.Condition);
            var trueVal = Load(value.TrueValue);
            var falseVal = Load(value.FalseValue);
            Declare(target);
            AppendLine($"{target} = select({falseVal}, {trueVal}, {cond});");
        }

        public virtual void GenerateCode(DynamicMemoryLengthValue value)
        {
            var target = Load(value);
            Declare(target);
            AppendLine($"{target} = 0u; // dynamic memory length");
        }

        public virtual void GenerateCode(AlignTo value)
        {
            var target = Load(value);
            var source = Load(value.Source);
            Declare(target);
            AppendLine($"{target} = {source}; // alignTo");
        }

        public virtual void GenerateCode(AsAligned value)
        {
            var target = Load(value);
            var source = Load(value.Source);
            Declare(target);
            AppendLine($"{target} = {source}; // asAligned");
        }

        public virtual void GenerateCode(LanguageEmitValue value)
        {
            // Raw WGSL emission - not commonly used
        }

        #endregion
    }
}
