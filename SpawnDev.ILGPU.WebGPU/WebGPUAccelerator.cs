using global::ILGPU;
using global::ILGPU.Backends;
using global::ILGPU.Runtime;
using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.ILGPU.WebGPU.Backend;
using System.Collections.Concurrent;
using System.Reflection;
using System.Reflection.Emit;
using Array = System.Array;

namespace SpawnDev.ILGPU.WebGPU
{
    /// <summary>
    /// WebGPU accelerator implementation for ILGPU.
    /// Provides kernel compilation and execution capabilities using WebGPU compute shaders.
    /// </summary>
    public class WebGPUAccelerator : KernelAccelerator<WebGPUCompiledKernel, WebGPUKernel>
    {
        /// <summary>
        /// Gets the native WebGPU accelerator for low-level GPU access.
        /// </summary>
        public WebGPUNativeAccelerator NativeAccelerator { get; private set; } = null!;

        /// <summary>
        /// Gets the WebGPU backend used for kernel compilation.
        /// </summary>
        public WebGPUBackend Backend { get; private set; } = null!;

        /// <summary>
        /// Method info for the static RunKernel method used by kernel launchers.
        /// </summary>
        public static readonly MethodInfo RunKernelMethod = typeof(WebGPUAccelerator).GetMethod(
            nameof(RunKernel),
            BindingFlags.Public | BindingFlags.Static)!;

        #region Caching Infrastructure

        // Reflection cache: caches PropertyInfo/FieldInfo for dimension extraction per type
        private static readonly ConcurrentDictionary<Type, ReflectionMetadataCache> _reflectionCache = new();

        // Buffer pool for scalar arguments (per-device pools would require instance field)
        [ThreadStatic]
        private static List<GPUBuffer>? _scalarBufferPool;

        private class ReflectionMetadataCache
        {
            public PropertyInfo? BaseViewProperty { get; set; }
            public PropertyInfo? IntLengthProperty { get; set; }
            public PropertyInfo? LengthProperty { get; set; }
            public PropertyInfo? WidthProperty { get; set; }
            public FieldInfo? XField { get; set; }
            public FieldInfo? YField { get; set; }
            public FieldInfo? ZField { get; set; }
            public PropertyInfo? XProperty { get; set; }
            public PropertyInfo? YProperty { get; set; }
            public PropertyInfo? ZProperty { get; set; }
        }

        private static ReflectionMetadataCache GetOrCreateReflectionCache(Type type)
        {
            if (!WebGPUBackend.EnableReflectionCaching)
                return BuildReflectionCache(type);

            return _reflectionCache.GetOrAdd(type, BuildReflectionCache);
        }

        private static ReflectionMetadataCache BuildReflectionCache(Type type)
        {
            var flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            return new ReflectionMetadataCache
            {
                BaseViewProperty = type.GetProperty("BaseView", flags),
                IntLengthProperty = type.GetProperty("IntLength", flags),
                LengthProperty = type.GetProperty("Length", flags),
                WidthProperty = type.GetProperty("Width", flags),
                XField = type.GetField("X", flags),
                YField = type.GetField("Y", flags),
                ZField = type.GetField("Z", flags),
                XProperty = type.GetProperty("X", flags),
                YProperty = type.GetProperty("Y", flags),
                ZProperty = type.GetProperty("Z", flags)
            };
        }

        private static GPUBuffer GetPooledScalarBuffer(GPUDevice device)
        {
            if (!WebGPUBackend.EnableBufferPooling)
                return CreateScalarBuffer(device);

            _scalarBufferPool ??= new List<GPUBuffer>();

            // Try to find a reusable buffer
            if (_scalarBufferPool.Count > 0)
            {
                var buffer = _scalarBufferPool[_scalarBufferPool.Count - 1];
                _scalarBufferPool.RemoveAt(_scalarBufferPool.Count - 1);
                return buffer;
            }

            return CreateScalarBuffer(device);
        }

        private static void ReturnPooledScalarBuffer(GPUBuffer buffer)
        {
            if (!WebGPUBackend.EnableBufferPooling)
            {
                buffer.Destroy();
                buffer.Dispose();
                return;
            }

            _scalarBufferPool ??= new List<GPUBuffer>();
            // Limit pool size to prevent memory bloat
            if (_scalarBufferPool.Count < 32)
            {
                _scalarBufferPool.Add(buffer);
            }
            else
            {
                buffer.Destroy();
                buffer.Dispose();
            }
        }

        private static GPUBuffer CreateScalarBuffer(GPUDevice device)
        {
            return device.CreateBuffer(new GPUBufferDescriptor
            {
                Label = "PooledScalar",
                Size = 256,
                Usage = GPUBufferUsage.Storage | GPUBufferUsage.CopyDst,
                MappedAtCreation = false
            });
        }

        #endregion

        private WebGPUAccelerator(Context context, Device device) : base(context, device) { }

        /// <summary>
        /// Creates a new WebGPU accelerator asynchronously with default options.
        /// </summary>
        /// <param name="context">The ILGPU context.</param>
        /// <param name="device">The WebGPU device to use.</param>
        /// <returns>A task that represents the async creation of the accelerator.</returns>
        public static Task<WebGPUAccelerator> CreateAsync(Context context, WebGPUILGPUDevice device)
            => CreateAsync(context, device, null);

        /// <summary>
        /// Creates a new WebGPU accelerator asynchronously with the specified options.
        /// </summary>
        /// <param name="context">The ILGPU context.</param>
        /// <param name="device">The WebGPU device to use.</param>
        /// <param name="options">The backend configuration options (null for defaults).</param>
        /// <returns>A task that represents the async creation of the accelerator.</returns>
        public static async Task<WebGPUAccelerator> CreateAsync(Context context, WebGPUILGPUDevice device, WebGPUBackendOptions? options)
        {
            var accelerator = new WebGPUAccelerator(context, device);
            accelerator.NativeAccelerator = await device.NativeDevice.CreateAcceleratorAsync();
            accelerator.Backend = new WebGPUBackend(context, options ?? WebGPUBackendOptions.Default);
            accelerator.Init(accelerator.Backend);
            accelerator.DefaultStream = accelerator.CreateStreamInternal();
            return accelerator;
        }

        /// <inheritdoc/>
        protected override WebGPUKernel CreateKernel(WebGPUCompiledKernel compiledKernel)
        {
            return new WebGPUKernel(this, compiledKernel, null);
        }

        /// <inheritdoc/>
        protected override WebGPUKernel CreateKernel(WebGPUCompiledKernel compiledKernel, MethodInfo launcher)
        {
            return new WebGPUKernel(this, compiledKernel, launcher);
        }

        /// <inheritdoc/>
        protected override MethodInfo GenerateKernelLauncherMethod(WebGPUCompiledKernel kernel, int customGroupSize)
        {
            var parameters = kernel.EntryPoint.Parameters;
            var indexType = kernel.EntryPoint.KernelIndexType;
            var argTypes = new List<Type> { typeof(Kernel), typeof(AcceleratorStream), indexType };
            for (int i = 0; i < parameters.Count; i++) argTypes.Add(parameters[i]);

            var dynamicMethod = new DynamicMethod("WebGPULauncher", typeof(void), argTypes.ToArray(), typeof(WebGPUAccelerator).Module);
            var ilGenerator = dynamicMethod.GetILGenerator();
            var argsLocal = ilGenerator.DeclareLocal(typeof(object[]));

            ilGenerator.Emit(OpCodes.Ldc_I4, parameters.Count);
            ilGenerator.Emit(OpCodes.Newarr, typeof(object));
            ilGenerator.Emit(OpCodes.Stloc, argsLocal);

            for (int i = 0; i < parameters.Count; i++)
            {
                ilGenerator.Emit(OpCodes.Ldloc, argsLocal);
                ilGenerator.Emit(OpCodes.Ldc_I4, i);
                ilGenerator.Emit(OpCodes.Ldarg, i + 3);
                var paramType = parameters[i];
                if (paramType.IsValueType) ilGenerator.Emit(OpCodes.Box, paramType);
                ilGenerator.Emit(OpCodes.Stelem_Ref);
            }

            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Ldarg_1);
            ilGenerator.Emit(OpCodes.Ldarg_2);
            if (indexType.IsValueType) ilGenerator.Emit(OpCodes.Box, indexType);

            ilGenerator.Emit(OpCodes.Ldloc, argsLocal);
            ilGenerator.EmitCall(OpCodes.Call, RunKernelMethod, null);
            ilGenerator.Emit(OpCodes.Ret);

            return dynamicMethod;
        }

        // Helper to robustly extract dimensions (X, Y, Z) using Duck Typing
        private static int[] ExtractDimensionsFromView(object view, Type viewType)
        {
            try
            {
                var flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

                int[] GetXYZ(object d)
                {
                    if (d == null) return Array.Empty<int>();
                    var t = d.GetType();
                    int x = -1, y = -1, z = -1;

                    // Try to get X
                    var fX = t.GetField("X", flags);
                    if (fX != null) x = Convert.ToInt32(fX.GetValue(d));
                    else
                    {
                        var pX = t.GetProperty("X", flags);
                        if (pX != null) x = Convert.ToInt32(pX.GetValue(d));
                    }

                    // Try to get Y
                    var fY = t.GetField("Y", flags);
                    if (fY != null) y = Convert.ToInt32(fY.GetValue(d));
                    else
                    {
                        var pY = t.GetProperty("Y", flags);
                        if (pY != null) y = Convert.ToInt32(pY.GetValue(d));
                    }

                    // Try to get Z
                    var fZ = t.GetField("Z", flags);
                    if (fZ != null) z = Convert.ToInt32(fZ.GetValue(d));
                    else
                    {
                        var pZ = t.GetProperty("Z", flags);
                        if (pZ != null) z = Convert.ToInt32(pZ.GetValue(d));
                    }

                    if (x >= 0)
                    {
                        if (y >= 0)
                        {
                            if (z >= 0) return new int[] { x, y, z };
                            return new int[] { x, y };
                        }
                        return new int[] { x };
                    }
                    return Array.Empty<int>();
                }

                foreach (var field in viewType.GetFields(flags))
                {
                    if (field.FieldType.IsPrimitive || field.FieldType.IsPointer) continue;
                    try
                    {
                        var val = field.GetValue(view);
                        var res = GetXYZ(val);
                        if (res.Length > 0 && res[0] > 0) return res;
                    }
                    catch { }
                }

                // DIRECT PROPERTY CHECK (Fallback for 1D ArrayView/Base)
                var pIntLength = viewType.GetProperty("IntLength", flags);
                if (pIntLength != null)
                {
                    try
                    {
                        var val = (int)pIntLength.GetValue(view);
                        return new int[] { val };
                    }
                    catch { }
                }

                // Fallback to Length (Long)
                var pLength = viewType.GetProperty("Length", flags);
                if (pLength != null && (pLength.PropertyType == typeof(int) || pLength.PropertyType == typeof(long)))
                {
                    try
                    {
                        var val = Convert.ToInt32(pLength.GetValue(view));
                        return new int[] { val };
                    }
                    catch { }
                }

                foreach (var prop in viewType.GetProperties(flags))
                {
                    if (prop.GetIndexParameters().Length > 0) continue;
                    if (prop.PropertyType.IsPrimitive || prop.PropertyType.IsPointer) continue;
                    try
                    {
                        var val = prop.GetValue(view);
                        var res = GetXYZ(val);
                        if (res.Length > 0 && res[0] > 0) return res;
                    }
                    catch { }
                }

                var directWidth = viewType.GetProperty("Width", flags);
                if (directWidth != null)
                {
                    int x = Convert.ToInt32(directWidth.GetValue(view));
                    if (x > 0) return new int[] { x, 0 };
                }
            }
            catch { }
            return Array.Empty<int>();
        }

        /// <summary>
        /// Executes a WebGPU kernel with the specified parameters.
        /// </summary>
        /// <param name="kernel">The kernel to execute.</param>
        /// <param name="stream">The accelerator stream (not used in WebGPU).</param>
        /// <param name="dimension">The launch dimensions.</param>
        /// <param name="args">The kernel arguments.</param>
        public static void RunKernel(Kernel kernel, AcceleratorStream stream, object dimension, object[] args)
        {
            var webGpuAccel = (WebGPUAccelerator)kernel.Accelerator;
            var nativeAccel = webGpuAccel.NativeAccelerator;
            var webGpuKernel = (WebGPUKernel)kernel;
            var compiledKernel = webGpuKernel.CompiledKernel;

            // ---- DEBUG LOGGING: WGSL SOURCE ----
            WebGPUBackend.Log("\n[WebGPU-Debug] ---- GENERATED WGSL ----");
            WebGPUBackend.Log(compiledKernel.WGSLSource);
            WebGPUBackend.Log("[WebGPU-Debug] ------------------------\n");
            // ------------------------------------

            var shader = nativeAccel.GetOrCreateComputeShader(compiledKernel.WGSLSource);
            var device = nativeAccel.NativeDevice!;

            // Track scalar buffers for pool return
            var scalarBuffersToReturn = new List<GPUBuffer>();

            try
            {
                int currentBindingIndex = 0;
                var entries = new List<GPUBindGroupEntry>();

                for (int i = 0; i < args.Length; i++)
                {
                    var paramType = compiledKernel.EntryPoint.Parameters[i];

                    if (i == 0 && (paramType == typeof(Index1D) || paramType == typeof(Index2D) || paramType == typeof(Index3D) ||
                                   paramType == typeof(LongIndex1D) || paramType == typeof(LongIndex2D) || paramType == typeof(LongIndex3D)))
                        continue;

                    var arg = args[i];
                    IArrayView? arrayView = arg as IArrayView;
                    int[] dims = Array.Empty<int>();

                    if (arg != null)
                    {
                        var argType = arg.GetType();
                        if (argType.Name.Contains("ArrayView"))
                        {
                            dims = ExtractDimensionsFromView(arg, argType);
                        }

                        if (arrayView == null)
                        {
                            var baseViewProp = argType.GetProperty("BaseView");
                            if (baseViewProp != null)
                            {
                                arrayView = baseViewProp.GetValue(arg) as IArrayView;
                            }
                        }
                    }

                    GPUBufferBinding? resource = null;

                    if (arrayView != null)
                    {
                        var contiguous = arrayView as IContiguousArrayView;
                        if (contiguous == null)
                        {
                            var baseViewProp = arrayView.GetType().GetProperty("BaseView");
                            contiguous = (baseViewProp != null ? baseViewProp.GetValue(arrayView) : arrayView) as IContiguousArrayView;
                        }

                        if (contiguous == null) throw new Exception($"Argument {i} is not a contiguous WebGPU buffer");

                        var nativeBuffer = contiguous.Buffer as WebGPUMemoryBuffer;
                        var gpuBuffer = nativeBuffer!.NativeBuffer.NativeBuffer!;

                        // DEBUG LOG
                        WebGPUBackend.Log($"[WebGPU-Debug] Arg {i}: Binding Buffer. Size={contiguous.LengthInBytes}, Offset={contiguous.IndexInBytes}");

                        resource = new GPUBufferBinding
                        {
                            Buffer = gpuBuffer,
                            Offset = (ulong)((long)contiguous.IndexInBytes),
                            Size = (ulong)((long)contiguous.LengthInBytes)
                        };
                    }
                    else
                    {
                        var size = 256;
                        var uBuffer = GetPooledScalarBuffer(device);
                        scalarBuffersToReturn.Add(uBuffer);

                        // DEBUG LOG
                        WebGPUBackend.Log($"[WebGPU-Debug] Arg {i}: Binding Scalar. Value={arg}");

                        if (arg is int iVal) device.Queue.WriteBuffer(uBuffer, 0, BitConverter.GetBytes(iVal));
                        else if (arg is float fVal) device.Queue.WriteBuffer(uBuffer, 0, BitConverter.GetBytes(fVal));
                        else if (arg is uint uiVal) device.Queue.WriteBuffer(uBuffer, 0, BitConverter.GetBytes(uiVal));
                        else if (arg is long lVal) device.Queue.WriteBuffer(uBuffer, 0, BitConverter.GetBytes((int)lVal));
                        else if (arg is ulong ulVal) device.Queue.WriteBuffer(uBuffer, 0, BitConverter.GetBytes((uint)ulVal));
                        else if (arg is double dVal)
                        {
                            if (webGpuAccel.Backend.Options.EnableF64Emulation)
                            {
                                // CRITICAL: For f64 emulation, write full 64-bit IEEE-754 representation as 2 u32 values
                                // The shader will read these as (lo, hi) and convert using f64_from_ieee754_bits
                                device.Queue.WriteBuffer(uBuffer, 0, BitConverter.GetBytes(dVal));
                            }
                            else
                            {
                                // Without emulation, truncate to float (loses precision but matches shader expectation)
                                device.Queue.WriteBuffer(uBuffer, 0, BitConverter.GetBytes((float)dVal));
                            }
                        }
                        else if (arg is byte bVal) device.Queue.WriteBuffer(uBuffer, 0, new byte[] { bVal });
                        else if (arg is bool blVal) device.Queue.WriteBuffer(uBuffer, 0, BitConverter.GetBytes(blVal ? 1u : 0u));
                        else throw new NotSupportedException($"Unsupported scalar argument type: {arg.GetType()}");

                        resource = new GPUBufferBinding { Buffer = uBuffer, Offset = 0, Size = (ulong)size };
                    }

                    entries.Add(new GPUBindGroupEntry { Binding = (uint)currentBindingIndex, Resource = resource! });
                    currentBindingIndex++;

                    if (dims.Length > 1)
                    {
                        WebGPUBackend.Log($"[WebGPU-Debug] Arg {i}: Binding Stride Buffer. Values=[{string.Join(", ", dims)}]");

                        var strideSize = 256;
                        var strideBuffer = GetPooledScalarBuffer(device);
                        scalarBuffersToReturn.Add(strideBuffer);

                        var strideData = new int[dims.Length];
                        Array.Copy(dims, strideData, dims.Length);
                        var byteData = new byte[dims.Length * 4];
                        Buffer.BlockCopy(strideData, 0, byteData, 0, byteData.Length);

                        device.Queue.WriteBuffer(strideBuffer, 0, byteData);

                        entries.Add(new GPUBindGroupEntry { Binding = (uint)currentBindingIndex, Resource = new GPUBufferBinding { Buffer = strideBuffer, Offset = 0, Size = (ulong)strideSize } });
                        currentBindingIndex++;
                    }
                }

                var bindGroupDesc = new GPUBindGroupDescriptor
                {
                    Layout = shader.Pipeline!.GetBindGroupLayout(0),
                    Entries = entries.ToArray()
                };

                using var bindGroup = device.CreateBindGroup(bindGroupDesc);

                uint workX = 1, workY = 1, workZ = 1;

                // Handle KernelConfig for explicit launches
                if (dimension is KernelConfig config)
                {
                    // For explicit kernels, the GridDim IS the number of groups or related.
                    // ILGPU KernelConfig: GridDim is the number of groups if explicit?
                    // "The grid dimension specifies the number of blocks per grid."
                    workX = (uint)config.GridDim.X;
                    workY = (uint)config.GridDim.Y;
                    workZ = (uint)config.GridDim.Z;
                }
                else if (dimension is Index1D i1) workX = (uint)Math.Ceiling(i1.X / 64.0);
                else if (dimension is Index2D i2) { workX = (uint)Math.Ceiling(i2.X / 8.0); workY = (uint)Math.Ceiling(i2.Y / 8.0); }
                else if (dimension is Index3D i3) { workX = (uint)Math.Ceiling(i3.X / 4.0); workY = (uint)Math.Ceiling(i3.Y / 4.0); workZ = (uint)Math.Ceiling(i3.Z / 4.0); }
                else if (dimension is LongIndex1D l1) workX = (uint)Math.Ceiling(l1.X / 64.0);
                else if (dimension is LongIndex2D l2) { workX = (uint)Math.Ceiling(l2.X / 8.0); workY = (uint)Math.Ceiling(l2.Y / 8.0); }
                else if (dimension is LongIndex3D l3) { workX = (uint)Math.Ceiling(l3.X / 4.0); workY = (uint)Math.Ceiling(l3.Y / 4.0); workZ = (uint)Math.Ceiling(l3.Z / 4.0); }

                WebGPUBackend.Log($"[WebGPU-Debug] Dispatching: ({workX}, {workY}, {workZ})");

                using var encoder = device.CreateCommandEncoder();
                using var pass = encoder.BeginComputePass();
                pass.SetPipeline(shader.Pipeline);
                pass.SetBindGroup(0, bindGroup);
                pass.DispatchWorkgroups(workX, workY, workZ);
                pass.End();
                using var cmd = encoder.Finish();
                nativeAccel.Queue!.Submit(new[] { cmd });
            }
            catch (Exception ex)
            {
                WebGPUBackend.Log($"[WebGPU] Error running kernel: {ex}");
                throw;
            }
            finally
            {
                // Return scalar buffers to pool
                foreach (var buffer in scalarBuffersToReturn)
                {
                    ReturnPooledScalarBuffer(buffer);
                }
            }
        }

        protected override MemoryBuffer AllocateRawInternal(long length, int elementSize) => new WebGPUMemoryBuffer(this, length, elementSize);
        protected override AcceleratorStream CreateStreamInternal() => new WebGPUStream(this);
        protected override void SynchronizeInternal()
        {
            // WebGPU in Blazor WASM cannot block. Use SynchronizeAsync() instead.
            WebGPUBackend.Log("[WebGPU Warning] Synchronize() is non-blocking in Blazor WASM. Use 'await accelerator.SynchronizeAsync()' for async waiting.");
        }
        protected override void OnBind() { }
        protected override void OnUnbind() { }
        protected override void DisposeAccelerator_SyncRoot(bool disposing) { if (disposing) NativeAccelerator.Dispose(); }
        public override TExtension CreateExtension<TExtension, TExtensionProvider>(TExtensionProvider provider) => default;
        protected override PageLockScope<T> CreatePageLockFromPinnedInternal<T>(IntPtr ptr, long numElements) => throw new NotSupportedException();
        protected override int EstimateGroupSizeInternal(Kernel kernel, int dynamicSharedMemorySize, int maxGridSize, out int groupSize) { groupSize = 64; return 64; }
        protected override int EstimateGroupSizeInternal(Kernel kernel, Func<int, int> computeSharedMemorySize, int maxGridSize, out int groupSize) { groupSize = 64; return 64; }
        protected override int EstimateMaxActiveGroupsPerMultiprocessorInternal(Kernel kernel, int groupSize, int dynamicSharedMemorySize) => 1;
        protected override void EnablePeerAccessInternal(Accelerator other) { }
        protected override void DisablePeerAccessInternal(Accelerator other) { }
        protected override bool CanAccessPeerInternal(Accelerator other) => false;
        private class WebGPUStream : AcceleratorStream
        {
            public WebGPUStream(Accelerator acc) : base(acc) { }
            protected override void DisposeAcceleratorObject(bool disposing) { }
            public override void Synchronize() { }
            protected override global::ILGPU.Runtime.ProfilingMarker AddProfilingMarkerInternal() => throw new NotSupportedException();
        }
    }

    /// <summary>
    /// Represents a compiled WebGPU kernel ready for execution.
    /// </summary>
    public class WebGPUKernel : Kernel
    {
        /// <summary>
        /// Creates a new WebGPU kernel instance.
        /// </summary>
        /// <param name="accelerator">The parent accelerator.</param>
        /// <param name="compiledKernel">The compiled kernel.</param>
        /// <param name="launcher">The launcher method info.</param>
        public WebGPUKernel(Accelerator accelerator, CompiledKernel compiledKernel, MethodInfo launcher) : base(accelerator, compiledKernel, launcher) { }

        /// <summary>
        /// Gets the WebGPU-specific compiled kernel.
        /// </summary>
        public new WebGPUCompiledKernel CompiledKernel => (WebGPUCompiledKernel)base.CompiledKernel;

        /// <inheritdoc/>
        protected override void DisposeAcceleratorObject(bool disposing) { }
    }
}