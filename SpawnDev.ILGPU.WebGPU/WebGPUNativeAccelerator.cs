// ---------------------------------------------------------------------------------------
//                               SpawnDev.ILGPU.WebGPU
//                 WebGPU Compute Library for Blazor WebAssembly
//
// File: WebGPUNativeAccelerator.cs
// ---------------------------------------------------------------------------------------

using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.ILGPU.WebGPU
{
    /// <summary>
    /// Represents a WebGPU accelerator for GPU compute in the browser.
    /// </summary>
    public sealed class WebGPUNativeAccelerator : IDisposable
    {
        #region Static

        /// <summary>
        /// Creates a WebGPU accelerator asynchronously.
        /// </summary>
        public static async Task<WebGPUNativeAccelerator> CreateAsync(WebGPUDevice device)
        {
            var accelerator = new WebGPUNativeAccelerator(device);
            await accelerator.InitializeAsync();
            return accelerator;
        }

        #endregion

        #region Instance

        private GPUDevice? _gpuDevice;
        private GPUQueue? _queue;
        private bool _isInitialized;
        private bool _disposed;

        /// <summary>
        /// Constructs a new WebGPU accelerator.
        /// </summary>
        private WebGPUNativeAccelerator(WebGPUDevice device)
        {
            Device = device ?? throw new ArgumentNullException(nameof(device));
        }

        /// <summary>
        /// Initializes the accelerator by requesting the GPU device.
        /// </summary>
        private async Task InitializeAsync()
        {
            if (_isInitialized)
                return;

            var adapter = Device.Adapter;

            // Request device with required features
            _gpuDevice = await adapter.RequestDevice();
            if (_gpuDevice == null)
                throw new InvalidOperationException("Failed to request WebGPU device");

            _queue = _gpuDevice.Queue;
            _isInitialized = true;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Returns the parent WebGPU device.
        /// </summary>
        public WebGPUDevice Device { get; }

        /// <summary>
        /// Returns the native GPU device.
        /// </summary>
        public GPUDevice? NativeDevice => _gpuDevice;

        /// <summary>
        /// Returns the GPU command queue.
        /// </summary>
        public GPUQueue? Queue => _queue;

        /// <summary>
        /// Returns whether the accelerator is initialized.
        /// </summary>
        public bool IsInitialized => _isInitialized;

        #endregion

        #region Buffer Methods

        /// <summary>
        /// Allocates a GPU buffer with the specified size.
        /// </summary>
        public WebGPUBuffer<T> Allocate<T>(long length) where T : unmanaged
        {
            EnsureInitialized();
            return new WebGPUBuffer<T>(this, length);
        }

        /// <summary>
        /// Allocates a GPU buffer and copies data from an array.
        /// </summary>
        public WebGPUBuffer<T> Allocate<T>(T[] data) where T : unmanaged
        {
            EnsureInitialized();
            var buffer = new WebGPUBuffer<T>(this, data.Length);
            buffer.CopyFromHost(data);
            return buffer;
        }

        #endregion

        #region Compute Methods

        /// <summary>
        /// Creates a compute shader from WGSL source code.
        /// </summary>
        public WebGPUComputeShader CreateComputeShader(string wgslSource, string entryPoint = "main")
        {
            EnsureInitialized();
            return new WebGPUComputeShader(this, wgslSource, entryPoint);
        }

        /// <summary>
        /// Runs a compute shader with the specified dispatch size.
        /// </summary>
        public void Dispatch(WebGPUComputeShader shader, uint workgroupCountX, uint workgroupCountY = 1, uint workgroupCountZ = 1)
        {
            EnsureInitialized();

            var encoder = _gpuDevice!.CreateCommandEncoder();
            var passEncoder = encoder.BeginComputePass();

            passEncoder.SetPipeline(shader.Pipeline!);

            if (shader.BindGroup != null)
            {
                passEncoder.SetBindGroup(0, shader.BindGroup);
            }

            passEncoder.DispatchWorkgroups(workgroupCountX, workgroupCountY, workgroupCountZ);
            passEncoder.End();

            var commandBuffer = encoder.Finish();
            _queue!.Submit(new[] { commandBuffer });

            // Clean up
            commandBuffer.Dispose();
            passEncoder.Dispose();
            encoder.Dispose();
        }

        #endregion

        #region Helpers

        private void EnsureInitialized()
        {
            if (!_isInitialized)
                throw new InvalidOperationException(
                    "Accelerator not initialized. Call InitializeAsync first.");
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            if (_disposed) return;
            _disposed = true;

            _gpuDevice?.Destroy();
            _gpuDevice?.Dispose();
        }

        #endregion
    }
}
