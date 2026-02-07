// ---------------------------------------------------------------------------------------
//                               SpawnDev.ILGPU.WebGPU
//                 WebGPU Compute Library for Blazor WebAssembly
//
// File: WebGPUComputeShader.cs
// ---------------------------------------------------------------------------------------

using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.ILGPU.WebGPU
{
    /// <summary>
    /// Represents a WebGPU compute shader.
    /// </summary>
    public sealed class WebGPUComputeShader : IDisposable
    {
        #region Instance

        private GPUShaderModule? _shaderModule;
        private GPUComputePipeline? _pipeline;
        private GPUBindGroup? _bindGroup;
        private GPUBindGroupLayout? _bindGroupLayout;
        private readonly List<WebGPUBufferBinding> _bindings = new();
        private bool _disposed;

        /// <summary>
        /// Constructs a new compute shader from WGSL source.
        /// </summary>
        internal WebGPUComputeShader(
            WebGPUNativeAccelerator accelerator,
            string wgslSource,
            string entryPoint,
            Dictionary<string, object>? overrideConstants = null)
        {
            Accelerator = accelerator ?? throw new ArgumentNullException(nameof(accelerator));
            WGSLSource = wgslSource ?? throw new ArgumentNullException(nameof(wgslSource));
            EntryPoint = entryPoint ?? throw new ArgumentNullException(nameof(entryPoint));

            var device = accelerator.NativeDevice;
            if (device == null)
                throw new InvalidOperationException("GPU device not initialized");

            // Create shader module from WGSL source
            accelerator._lastCompiledWGSL = wgslSource;
            var shaderDescriptor = new GPUShaderModuleDescriptor
            {
                Code = wgslSource
            };
            _shaderModule = device.CreateShaderModule(shaderDescriptor);

            // Create compute pipeline with optional override constants
            var programmableStage = new GPUProgrammableStage
            {
                Module = _shaderModule,
                EntryPoint = entryPoint,
                Constants = overrideConstants
            };

            var pipelineDescriptor = new GPUComputePipelineDescriptor
            {
                Layout = "auto",
                Compute = programmableStage
            };
            _pipeline = device.CreateComputePipeline(pipelineDescriptor);

            // Get bind group layout
            _bindGroupLayout = _pipeline.GetBindGroupLayout(0);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Returns the parent accelerator.
        /// </summary>
        public WebGPUNativeAccelerator Accelerator { get; }

        /// <summary>
        /// Returns the WGSL source code.
        /// </summary>
        public string WGSLSource { get; }

        /// <summary>
        /// Returns the entry point function name.
        /// </summary>
        public string EntryPoint { get; }

        /// <summary>
        /// Returns the shader module.
        /// </summary>
        public GPUShaderModule? ShaderModule => _shaderModule;

        /// <summary>
        /// Returns the compute pipeline.
        /// </summary>
        public GPUComputePipeline? Pipeline => _pipeline;

        /// <summary>
        /// Returns the current bind group.
        /// </summary>
        public GPUBindGroup? BindGroup => _bindGroup;

        #endregion

        #region Methods

        /// <summary>
        /// Binds a buffer to the specified binding index.
        /// </summary>
        public WebGPUComputeShader SetBuffer<T>(int bindingIndex, WebGPUBuffer<T> buffer) where T : unmanaged
        {
            if (buffer?.NativeBuffer == null)
                throw new ArgumentNullException(nameof(buffer));

            // Remove any existing binding at this index
            _bindings.RemoveAll(b => b.Index == bindingIndex);

            _bindings.Add(new WebGPUBufferBinding(bindingIndex, buffer.NativeBuffer));

            // Rebuild bind group
            RebuildBindGroup();

            return this;
        }

        /// <summary>
        /// Dispatches the compute shader.
        /// </summary>
        public void Dispatch(uint workgroupCountX, uint workgroupCountY = 1, uint workgroupCountZ = 1)
        {
            Accelerator.Dispatch(this, workgroupCountX, workgroupCountY, workgroupCountZ);
        }

        private void RebuildBindGroup()
        {
            var device = Accelerator.NativeDevice;
            if (device == null || _bindGroupLayout == null)
                return;

            // Dispose old bind group
            _bindGroup?.Dispose();

            // Create new bind group
            var entries = _bindings
                .OrderBy(b => b.Index)
                .Select(b => new GPUBindGroupEntry
                {
                    Binding = (uint)b.Index,
                    Resource = new GPUBufferBinding { Buffer = b.Buffer }
                })
                .ToArray();

            var descriptor = new GPUBindGroupDescriptor
            {
                Layout = _bindGroupLayout,
                Entries = entries
            };

            _bindGroup = device.CreateBindGroup(descriptor);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            if (_disposed) return;
            _disposed = true;

            _bindGroup?.Dispose();
            _pipeline?.Dispose();
            _shaderModule?.Dispose();
            _bindGroupLayout?.Dispose();
        }

        #endregion

        #region Nested Types

        private readonly struct WebGPUBufferBinding
        {
            public WebGPUBufferBinding(int index, GPUBuffer buffer)
            {
                Index = index;
                Buffer = buffer;
            }

            public int Index { get; }
            public GPUBuffer Buffer { get; }
        }

        #endregion
    }
}
