// ---------------------------------------------------------------------------------------
//                                 SpawnDev.ILGPU.WebGPU
//                        Copyright (c) 2024 SpawnDev Project
//
// File: WebGPUBackendOptions.cs
//
// Configuration options for the WebGPU backend.
// ---------------------------------------------------------------------------------------

namespace SpawnDev.ILGPU.WebGPU.Backend
{
    /// <summary>
    /// Configuration options for the WebGPU backend.
    /// Pass to the context builder to configure backend behavior.
    /// </summary>
    public record WebGPUBackendOptions
    {
        /// <summary>
        /// Enables f64 (double) emulation using two f32 values (double-float technique).
        /// When enabled, f64 operations use vec2&lt;f32&gt; with software emulation.
        /// When disabled, f64 is promoted to f32 (default behavior, loses precision).
        /// </summary>
        public bool EnableF64Emulation { get; init; } = false;

        /// <summary>
        /// Enables i64 (long) emulation using two u32 values (double-word technique).
        /// When enabled, i64 operations use vec2&lt;u32&gt; with software emulation.
        /// When disabled, i64 is promoted to i32 (default behavior, loses range).
        /// </summary>
        public bool EnableI64Emulation { get; init; } = false;

        /// <summary>
        /// Default options with no emulation enabled.
        /// </summary>
        public static WebGPUBackendOptions Default { get; } = new();
    }
}
