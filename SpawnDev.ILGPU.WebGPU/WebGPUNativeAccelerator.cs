// ---------------------------------------------------------------------------------------
//                               SpawnDev.ILGPU.WebGPU
//                 WebGPU Compute Library for Blazor WebAssembly
//
// File: WebGPUNativeAccelerator.cs
// ---------------------------------------------------------------------------------------

using SpawnDev.BlazorJS;
using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.ILGPU.WebGPU.Backend;
using System.Linq;

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

        // Shader cache: key is WGSL source, value is compiled shader
        private readonly Dictionary<string, WebGPUComputeShader> _shaderCache = new();

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

            // Request device with higher storage buffer limits.
            // WebGPU defaults to 8 maxStorageBuffersPerShaderStage, but complex kernels
            // with many parameters may need more. Most adapters support at least 10.
            try
            {
                // Use JS interop to call requestDevice with requiredLimits directly,
                // since the C# GPUDeviceDescriptor doesn't expose requiredLimits property.
                _gpuDevice = await adapter.JSRef!.CallAsync<GPUDevice>("requestDevice", new
                {
                    requiredLimits = new
                    {
                        maxStorageBuffersPerShaderStage = 10
                    }
                });
            }
            catch
            {
                // Fall back to default limits if higher limits aren't supported
                _gpuDevice = await adapter.RequestDevice();
            }
            if (_gpuDevice == null)
                throw new InvalidOperationException("Failed to request WebGPU device");

            // Listen for uncaptured GPU errors (e.g., Invalid ComputePipeline, validation errors)
            _gpuDevice.OnUncapturedError += OnGPUUncapturedError;

            _queue = _gpuDevice.Queue;
            _isInitialized = true;
        }

        /// <summary>
        /// Handles uncaptured GPU validation errors.
        /// </summary>
        private void OnGPUUncapturedError(GPUUncapturedErrorEvent e)
        {
            var message = e.Error?.Message ?? "Unknown GPU error";
            Console.Error.WriteLine($"[WebGPU ERROR] {message}");
            if (_lastCompiledWGSL != null)
            {
                Console.Error.WriteLine($"[WebGPU ERROR] Last WGSL source ({_lastCompiledWGSL.Length} chars):");
                // Dump first 2000 chars to avoid flooding
                var snippet = _lastCompiledWGSL.Length > 2000 ? _lastCompiledWGSL.Substring(0, 2000) + "\n...TRUNCATED..." : _lastCompiledWGSL;
                Console.Error.WriteLine(snippet);
            }
        }

        /// <summary>
        /// The last WGSL source that was compiled, for error debugging.
        /// </summary>
        internal string? _lastCompiledWGSL;

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
        public WebGPUComputeShader CreateComputeShader(
            string wgslSource,
            string entryPoint = "main",
            Dictionary<string, object>? overrideConstants = null)
        {
            EnsureInitialized();
            return new WebGPUComputeShader(this, wgslSource, entryPoint, overrideConstants);
        }

        /// <summary>
        /// Gets a cached compute shader or creates a new one.
        /// When caching is enabled, shaders are reused across kernel invocations.
        /// Override constants are part of the cache key since they affect pipeline creation.
        /// </summary>
        public WebGPUComputeShader GetOrCreateComputeShader(
            string wgslSource,
            string entryPoint = "main",
            Dictionary<string, object>? overrideConstants = null)
        {
            if (!WebGPUBackend.EnableShaderCaching)
                return CreateComputeShader(wgslSource, entryPoint, overrideConstants);

            // Build cache key: WGSL source + sorted override constants
            string cacheKey = wgslSource;
            if (overrideConstants != null && overrideConstants.Count > 0)
            {
                var constantsKey = string.Join(",",
                    overrideConstants.OrderBy(kv => kv.Key).Select(kv => $"{kv.Key}={kv.Value}"));
                cacheKey = $"{wgslSource}\n__CONSTANTS__:{constantsKey}";
            }

            if (_shaderCache.TryGetValue(cacheKey, out var cached))
            {
                WebGPUBackend.Log("[WebGPU] Using cached shader");
                return cached;
            }

            WebGPUBackend.Log("[WebGPU] Creating and caching new shader");
            var shader = CreateComputeShader(wgslSource, entryPoint, overrideConstants);
            _shaderCache[cacheKey] = shader;
            return shader;
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

            // Dispose cached shaders
            foreach (var shader in _shaderCache.Values)
            {
                shader.Dispose();
            }
            _shaderCache.Clear();

            _gpuDevice?.Destroy();
            _gpuDevice?.Dispose();
        }

        #endregion
    }
}
