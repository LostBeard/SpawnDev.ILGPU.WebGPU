// ---------------------------------------------------------------------------------------
//                               SpawnDev.ILGPU.WebGPU
//                 WebGPU Compute Library for Blazor WebAssembly
//
// File: WebGPUDevice.cs
// ---------------------------------------------------------------------------------------

using SpawnDev.BlazorJS;
using SpawnDev.BlazorJS.JSObjects;
using System.Collections.Immutable;

namespace SpawnDev.ILGPU.WebGPU
{
    /// <summary>
    /// Represents a WebGPU device available in the browser.
    /// </summary>
    public sealed class WebGPUDevice : IDisposable
    {
        #region Static

        /// <summary>
        /// Checks if WebGPU is supported in the current browser.
        /// </summary>
        public static bool IsSupported
        {
            get
            {
                try
                {
                    var navigator = BlazorJSRuntime.JS.Get<Navigator>("navigator");
                    return navigator.Gpu != null;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Asynchronously detects all available WebGPU devices.
        /// </summary>
        public static async Task<ImmutableArray<WebGPUDevice>> GetDevicesAsync()
        {
            var devices = ImmutableArray.CreateBuilder<WebGPUDevice>();

            if (!IsSupported)
                return devices.ToImmutable();

            try
            {
                var navigator = BlazorJSRuntime.JS.Get<Navigator>("navigator");
                var gpu = navigator.Gpu;

                if (gpu == null)
                    return devices.ToImmutable();

                // Request the default adapter
                var adapter = await gpu.RequestAdapter();
                if (adapter != null)
                {
                    var device = new WebGPUDevice(adapter, 0);
                    devices.Add(device);
                }

                // Try requesting a high-performance adapter
                var highPerfOptions = new GPURequestAdapterOptions
                {
                    PowerPreference = "high-performance"
                };
                var highPerfAdapter = await gpu.RequestAdapter(highPerfOptions);

                if (highPerfAdapter != null &&
                    adapter != null &&
                    highPerfAdapter.Info?.Device != adapter.Info?.Device)
                {
                    var device = new WebGPUDevice(highPerfAdapter, devices.Count);
                    devices.Add(device);
                }
            }
            catch (Exception)
            {
                // WebGPU not available or error occurred
            }

            return devices.ToImmutable();
        }

        /// <summary>
        /// Gets the first available WebGPU device.
        /// </summary>
        public static async Task<WebGPUDevice?> GetDefaultDeviceAsync()
        {
            var devices = await GetDevicesAsync();
            return devices.Length > 0 ? devices[0] : null;
        }

        #endregion

        #region Instance

        private readonly GPUAdapter _adapter;
        private readonly int _deviceIndex;
        private bool _disposed;

        /// <summary>
        /// Constructs a new WebGPU device.
        /// </summary>
        internal WebGPUDevice(GPUAdapter adapter, int deviceIndex)
        {
            _adapter = adapter ?? throw new ArgumentNullException(nameof(adapter));
            _deviceIndex = deviceIndex;

            // Get adapter info safely
            try
            {
                var info = adapter.Info;
                Name = info?.Device ?? "WebGPU Device";
                Vendor = info?.Vendor ?? "Unknown";
                Architecture = info?.Architecture ?? "Unknown";
            }
            catch
            {
                Name = "WebGPU Device";
                Vendor = "Unknown";
                Architecture = "Unknown";
            }

            try
            {
                IsFallbackAdapter = adapter.IsFallbackAdapter;
            }
            catch
            {
                IsFallbackAdapter = false;
            }

            // Get limits safely
            try
            {
                var limits = adapter.Limits;
                MaxComputeWorkgroupSizeX = (int)(limits?.MaxComputeWorkgroupSizeX ?? 256);
                MaxComputeWorkgroupSizeY = (int)(limits?.MaxComputeWorkgroupSizeY ?? 256);
                MaxComputeWorkgroupSizeZ = (int)(limits?.MaxComputeWorkgroupSizeZ ?? 64);
                MaxComputeInvocationsPerWorkgroup = (int)(limits?.MaxComputeInvocationsPerWorkgroup ?? 256);
                MaxComputeWorkgroupsPerDimension = (int)(limits?.MaxComputeWorkgroupsPerDimension ?? 65535);
                MaxComputeWorkgroupStorageSize = (int)(limits?.MaxComputeWorkgroupStorageSize ?? 16384);
                MaxBufferSize = (long)(limits?.MaxBufferSize ?? 268435456); // 256 MB fallback
            }
            catch
            {
                // Use safe defaults if limits cannot be read
                MaxComputeWorkgroupSizeX = 256;
                MaxComputeWorkgroupSizeY = 256;
                MaxComputeWorkgroupSizeZ = 64;
                MaxComputeInvocationsPerWorkgroup = 256;
                MaxComputeWorkgroupsPerDimension = 65535;
                MaxComputeWorkgroupStorageSize = 16384;
                MaxBufferSize = 268435456;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Returns the native WebGPU adapter.
        /// </summary>
        public GPUAdapter Adapter => _adapter;

        /// <summary>
        /// Returns the device name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Returns the adapter vendor name.
        /// </summary>
        public string Vendor { get; }

        /// <summary>
        /// Returns the adapter architecture.
        /// </summary>
        public string Architecture { get; }

        /// <summary>
        /// Returns whether this is a fallback (software) adapter.
        /// </summary>
        public bool IsFallbackAdapter { get; }

        /// <summary>
        /// Gets the maximum workgroup size in X dimension.
        /// </summary>
        public int MaxComputeWorkgroupSizeX { get; }

        /// <summary>
        /// Gets the maximum workgroup size in Y dimension.
        /// </summary>
        public int MaxComputeWorkgroupSizeY { get; }

        /// <summary>
        /// Gets the maximum workgroup size in Z dimension.
        /// </summary>
        public int MaxComputeWorkgroupSizeZ { get; }

        /// <summary>
        /// Gets the maximum compute invocations per workgroup.
        /// </summary>
        public int MaxComputeInvocationsPerWorkgroup { get; }

        /// <summary>
        /// Gets the maximum dispatch dimensions.
        /// </summary>
        public int MaxComputeWorkgroupsPerDimension { get; }

        /// <summary>
        /// Gets the maximum workgroup storage size in bytes.
        /// </summary>
        public int MaxComputeWorkgroupStorageSize { get; }

        /// <summary>
        /// Gets the maximum buffer size in bytes.
        /// </summary>
        public long MaxBufferSize { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Creates a new WebGPU accelerator from this device.
        /// </summary>
        public async Task<WebGPUNativeAccelerator> CreateAcceleratorAsync()
        {
            return await WebGPUNativeAccelerator.CreateAsync(this);
        }

        /// <summary>
        /// Prints device information to the console.
        /// </summary>
        public void PrintInfo(TextWriter writer)
        {
            writer.WriteLine($"WebGPU Device: {Name}");
            writer.WriteLine($"  Vendor:       {Vendor}");
            writer.WriteLine($"  Architecture: {Architecture}");
            writer.WriteLine($"  Fallback:     {IsFallbackAdapter}");
            writer.WriteLine($"  Max Workgroup Size: ({MaxComputeWorkgroupSizeX}, {MaxComputeWorkgroupSizeY}, {MaxComputeWorkgroupSizeZ})");
            writer.WriteLine($"  Max Invocations:    {MaxComputeInvocationsPerWorkgroup}");
            writer.WriteLine($"  Max Workgroups:     {MaxComputeWorkgroupsPerDimension}");
            writer.WriteLine($"  Max Shared Memory:  {MaxComputeWorkgroupStorageSize} bytes");
            writer.WriteLine($"  Max Buffer Size:    {MaxBufferSize / (1024 * 1024)} MB");
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            if (_disposed) return;
            _disposed = true;
            _adapter?.Dispose();
        }

        #endregion
    }
}
