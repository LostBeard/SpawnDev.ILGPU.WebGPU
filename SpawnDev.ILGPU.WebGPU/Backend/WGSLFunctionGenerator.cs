// ---------------------------------------------------------------------------------------
//                                 SpawnDev.ILGPU.WebGPU
//                        Copyright (c) 2024 SpawnDev Project
//
// File: WGSLFunctionGenerator.cs
//
// WGSL function generator for helper device functions.
// ---------------------------------------------------------------------------------------

using global::ILGPU.IR;
using global::ILGPU.IR.Analyses;
using global::ILGPU.IR.Values;
using System.Text;

namespace SpawnDev.ILGPU.WebGPU.Backend
{
    /// <summary>
    /// Function generator for helper device functions (non-kernel methods).
    /// </summary>
    internal sealed class WGSLFunctionGenerator : WGSLCodeGenerator
    {
        #region Constants

        /// <summary>
        /// Methods with these flags will be skipped during code generation.
        /// </summary>
        private const MethodFlags MethodFlagsToSkip =
            MethodFlags.External |
            MethodFlags.Intrinsic;

        #endregion

        #region Instance

        /// <summary>
        /// Creates a new WGSL function generator.
        /// </summary>
        public WGSLFunctionGenerator(
            in GeneratorArgs args,
            Method method,
            Allocas allocas)
            : base(args, method, allocas)
        { }

        #endregion

        #region Methods

        /// <summary>
        /// Generates a header stub for the current method.
        /// </summary>
        private void GenerateHeaderStub(StringBuilder builder)
        {
            builder.Append("fn ");
            builder.Append(GetMethodName(Method));
            builder.Append("(");
            
            // Emit parameters
            bool first = true;
            foreach (var param in Method.Parameters)
            {
                if (!first) builder.Append(", ");
                first = false;
                
                var paramType = TypeGenerator[param.ParameterType];
                builder.Append($"p_{param.Id} : {paramType}");
            }
            
            builder.Append(") -> ");
            builder.Append(TypeGenerator[Method.ReturnType]);
        }

        /// <summary>
        /// Gets the WGSL function name for the given method.
        /// </summary>
        private static string GetMethodName(Method method)
        {
            var handleName = method.Handle.Name;
            if (method.HasFlags(MethodFlags.External))
            {
                return handleName;
            }
            else
            {
                // Constructor names in MSIL start with a dot
                return handleName.StartsWith(".")
                    ? handleName.Substring(1) + "_" + method.Id
                    : handleName + "_" + method.Id;
            }
        }

        /// <summary>
        /// Generates a function declaration in WGSL code.
        /// </summary>
        public override void GenerateHeader(StringBuilder builder)
        {
            if (Method.HasFlags(MethodFlagsToSkip))
                return;

            GenerateHeaderStub(builder);
            builder.AppendLine(";");
        }

        /// <summary>
        /// Generates WGSL code for the function body.
        /// </summary>
        public override void GenerateCode()
        {
            if (Method.HasFlags(MethodFlagsToSkip))
                return;

            // Declare function and parameters
            GenerateHeaderStub(Builder);
            Builder.AppendLine(" {");
            PushIndent();

            // Bind parameters to local variables
            foreach (var param in Method.Parameters)
            {
                var variable = Allocate(param);
                AppendLine($"var {variable.Name} : {variable.Type} = p_{param.Id};");
            }

            // Generate body
            GenerateCodeInternal();

            PopIndent();
            Builder.AppendLine("}");
        }

        #endregion
    }
}
