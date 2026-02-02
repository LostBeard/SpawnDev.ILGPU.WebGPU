using ILGPU.Backends;
using ILGPU.Runtime;

namespace SpawnDev.ILGPU.WebGPU
{
    /// <summary>
    /// Represents the capabilities of the WebGPU backend.
    /// </summary>
    public sealed class WebGPUCapabilityContext : CapabilityContext
    {
        /// <summary>
        /// Creates a new WebGPU capability context.
        /// </summary>
        public WebGPUCapabilityContext()
        {
            // WebGPU does not guarantee Float16 support yet (shader-f16)
            Float16 = false;
            
            // WebGPU requires 'shader-float64' for double
            Float64 = false;
            
            // WebGPU requires 'shader-int64' for long
            Int64 = false;
        }

        /// <summary>
        /// Supports Float64 (double) data type.
        /// </summary>
        public bool Float64 { get; internal set; }

        /// <summary>
        /// Supports Int64 (long) data type.
        /// </summary>
        public bool Int64 { get; internal set; }
    }
}
