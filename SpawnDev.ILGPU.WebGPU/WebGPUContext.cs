using global::ILGPU;
using SpawnDev.ILGPU.WebGPU.Backend;

namespace SpawnDev.ILGPU.WebGPU
{
    /// <summary>
    /// WebGPU context extensions.
    /// </summary>
    public static class WebGPUContextExtensions
    {
        #region Builder

        /// <summary>
        /// Asynchronously enables all detected WebGPU devices.
        /// </summary>
        /// <param name="builder">The builder instance.</param>
        /// <returns>A task that represents the async operation.</returns>
        public static async System.Threading.Tasks.Task WebGPUAsync(
            this Context.Builder builder)
        {
            await WebGPUILGPUDevice.GetDevicesAsync(
                device => true,
                builder.DeviceRegistry);
        }

        /// <summary>
        /// Asynchronously enables WebGPU devices matching the predicate.
        /// </summary>
        /// <param name="builder">The builder instance.</param>
        /// <param name="predicate">The predicate to include a given device.</param>
        /// <returns>A task that represents the async operation.</returns>
        public static async System.Threading.Tasks.Task WebGPUAsync(
            this Context.Builder builder,
            System.Predicate<WebGPUILGPUDevice> predicate)
        {
            await WebGPUILGPUDevice.GetDevicesAsync(
                predicate,
                builder.DeviceRegistry);
        }

        #endregion

        #region Context

        /// <summary>
        /// Gets the i-th registered WebGPU device.
        /// </summary>
        /// <param name="context">The ILGPU context.</param>
        /// <param name="webGpuDeviceIndex">
        /// The relative device index for the WebGPU device. 0 here refers to the first
        /// WebGPU device, 1 to the second, etc.
        /// </param>
        /// <returns>The registered WebGPU device.</returns>
        public static WebGPUILGPUDevice GetWebGPUDevice(
            this Context context,
            int webGpuDeviceIndex) =>
            context.GetDevice<WebGPUILGPUDevice>(webGpuDeviceIndex);

        /// <summary>
        /// Gets all registered WebGPU devices.
        /// </summary>
        /// <param name="context">The ILGPU context.</param>
        /// <returns>All registered WebGPU devices.</returns>
        public static Context.DeviceCollection<WebGPUILGPUDevice> GetWebGPUDevices(
            this Context context) =>
            context.GetDevices<WebGPUILGPUDevice>();

        /// <summary>
        /// Creates a new WebGPU accelerator asynchronously.
        /// </summary>
        /// <param name="context">The ILGPU context.</param>
        /// <param name="webGpuDeviceIndex">
        /// The relative device index for the WebGPU device. 0 here refers to the first
        /// WebGPU device, 1 to the second, etc.
        /// </param>
        /// <returns>A task that represents the async creation of the WebGPU accelerator.</returns>
        public static Task<WebGPUAccelerator> CreateWebGPUAcceleratorAsync(
            this Context context,
            int webGpuDeviceIndex)
            => CreateWebGPUAcceleratorAsync(context, webGpuDeviceIndex, null);

        /// <summary>
        /// Creates a new WebGPU accelerator asynchronously with the specified options.
        /// </summary>
        /// <param name="context">The ILGPU context.</param>
        /// <param name="webGpuDeviceIndex">
        /// The relative device index for the WebGPU device. 0 here refers to the first
        /// WebGPU device, 1 to the second, etc.
        /// </param>
        /// <param name="options">The backend configuration options (null for defaults).</param>
        /// <returns>A task that represents the async creation of the WebGPU accelerator.</returns>
        public static async Task<WebGPUAccelerator> CreateWebGPUAcceleratorAsync(
            this Context context,
            int webGpuDeviceIndex,
            WebGPUBackendOptions? options)
        {
            var device = context.GetWebGPUDevice(webGpuDeviceIndex);
            return await device.CreateAcceleratorAsync(context, options);
        }

        #endregion
    }
}
