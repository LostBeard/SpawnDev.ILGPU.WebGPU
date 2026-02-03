// ---------------------------------------------------------------------------------------
//                                 SpawnDev.ILGPU.WebGPU
//                        Copyright (c) 2024 SpawnDev Project
//
// File: WGSLIntrinsic.cs
//
// WGSL intrinsic handler delegate for WebGPU backend code generation.
// ---------------------------------------------------------------------------------------

using global::ILGPU.IR.Values;

namespace SpawnDev.ILGPU.WebGPU.Backend
{
    /// <summary>
    /// Contains intrinsic handler definitions for WGSL code generation.
    /// </summary>
    public static class WGSLIntrinsic
    {
        /// <summary>
        /// Represents a handler for WGSL intrinsic code generation.
        /// </summary>
        /// <param name="backend">The parent WebGPU backend.</param>
        /// <param name="codeGenerator">The code generator to use.</param>
        /// <param name="value">The value to generate code for.</param>
        public delegate void Handler(
            WebGPUBackend backend,
            WGSLCodeGenerator codeGenerator,
            global::ILGPU.IR.Value value);
    }
}
