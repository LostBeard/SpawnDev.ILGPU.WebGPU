// ---------------------------------------------------------------------------------------
//                               SpawnDev.ILGPU.WebGPU
//                 WebGPU Compute Library for Blazor WebAssembly
//
// File: WebGPUILGPUDevice.cs
// ---------------------------------------------------------------------------------------

using global::ILGPU;
using global::ILGPU.Runtime;

namespace SpawnDev.ILGPU.WebGPU
{
    /// <summary>
    /// Represents an ILGPU Device implementation for WebGPU.
    /// </summary>
    [DeviceType(AcceleratorType.WebGPU)]
    public sealed class WebGPUILGPUDevice : Device
    {
        #region Static

        /// <summary>
        /// Asynchronously detects all available WebGPU devices and registers them.
        /// </summary>
        public static async Task<DeviceRegistry> GetDevicesAsync()
        {
            var registry = new DeviceRegistry();
            await GetDevicesAsync(device => true, registry);
            return registry;
        }

        /// <summary>
        /// Asynchronously detects WebGPU devices matching the predicate.
        /// </summary>
        public static async Task GetDevicesAsync(
            Predicate<WebGPUILGPUDevice> predicate,
            DeviceRegistry registry)
        {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            if (registry is null)
                throw new ArgumentNullException(nameof(registry));

            var webGpuDevices = await WebGPUDevice.GetDevicesAsync();
            for (int i = 0; i < webGpuDevices.Length; i++)
            {
                var device = new WebGPUILGPUDevice(webGpuDevices[i], i);
                registry.Register(device, predicate);
            }
        }

        #endregion

        #region Instance

        private readonly WebGPUDevice nativeDevice;

        /// <summary>
        /// Constructs a new WebGPU ILGPU device.
        /// </summary>
        public WebGPUILGPUDevice(WebGPUDevice device, int deviceIndex)
        {
            nativeDevice = device ?? throw new ArgumentNullException(nameof(device));

            // Set device properties from native WebGPU device
            Name = device.Name;
            WarpSize = 32; // WebGPU subgroup size is typically 32 (similar to CUDA warps)
            
            // Map WebGPU workgroup limits to ILGPU concepts
            MaxGroupSize = new Index3D(
                device.MaxComputeWorkgroupSizeX,
                device.MaxComputeWorkgroupSizeY,
                device.MaxComputeWorkgroupSizeZ);
            
            MaxNumThreadsPerGroup = device.MaxComputeInvocationsPerWorkgroup;
            
            // WebGPU doesn't expose multiprocessor count directly
            // Use a reasonable estimate based on workgroup capacity
            NumMultiprocessors = 16; // Conservative estimate
            MaxNumThreadsPerMultiprocessor = device.MaxComputeInvocationsPerWorkgroup;
            
            // Grid size (dispatch) limits
            MaxGridSize = new Index3D(
                device.MaxComputeWorkgroupsPerDimension,
                device.MaxComputeWorkgroupsPerDimension,
                device.MaxComputeWorkgroupsPerDimension);
            
            // Memory limits
            MemorySize = device.MaxBufferSize;
            MaxSharedMemoryPerGroup = device.MaxComputeWorkgroupStorageSize;
            MaxConstantMemory = 65536; // WebGPU uniform buffer limit
            
            // Create basic capability context
            Capabilities = new WebGPUCapabilityContext();
        }

        /// <summary>
        /// Gets the native WebGPU device.
        /// </summary>
        public WebGPUDevice NativeDevice => nativeDevice;

        #endregion

        #region Methods

        /// <summary>
        /// Creates a new WebGPU accelerator synchronously.
        /// NOTE: This will throw as WebGPU requires async initialization.
        /// Use CreateAcceleratorAsync instead.
        /// </summary>
        public override Accelerator CreateAccelerator(Context context)
        {
            throw new NotSupportedException(
                "WebGPU requires async initialization. Use CreateAcceleratorAsync instead.");
        }

        /// <summary>
        /// Creates a new WebGPU accelerator asynchronously.
        /// </summary>
        public override async Task<Accelerator> CreateAcceleratorAsync(Context context)
        {
            return await WebGPUAccelerator.CreateAsync(context, this);
        }

        #endregion
    }
}
