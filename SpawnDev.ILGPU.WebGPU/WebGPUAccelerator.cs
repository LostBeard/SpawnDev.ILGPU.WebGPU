using global::ILGPU;
using global::ILGPU.Backends;
using global::ILGPU.Backends.EntryPoints;
using global::ILGPU.Backends.IL;
using global::ILGPU.Runtime;
using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.ILGPU.WebGPU.Backend;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace SpawnDev.ILGPU.WebGPU
{
    public class WebGPUAccelerator : KernelAccelerator<WebGPUCompiledKernel, WebGPUKernel>
    {
        public WebGPUNativeAccelerator NativeAccelerator { get; private set; } = null!;

        public WebGPUBackend Backend { get; private set; } = null!;

        public static readonly MethodInfo RunKernelMethod = typeof(WebGPUAccelerator).GetMethod(
            nameof(RunKernel),
            BindingFlags.Public | BindingFlags.Static)!;

        private WebGPUAccelerator(Context context, Device device)
            : base(context, device)
        {
        }

        public static async Task<WebGPUAccelerator> CreateAsync(Context context, WebGPUILGPUDevice device)
        {
            var accelerator = new WebGPUAccelerator(context, device);
            accelerator.NativeAccelerator = await device.NativeDevice.CreateAcceleratorAsync();
            accelerator.Backend = new WebGPUBackend(context);
            accelerator.Init(accelerator.Backend);
            accelerator.DefaultStream = accelerator.CreateStreamInternal();
            return accelerator;
        }

        protected override WebGPUKernel CreateKernel(WebGPUCompiledKernel compiledKernel)
        {
            return new WebGPUKernel(this, compiledKernel, null);
        }

        protected override WebGPUKernel CreateKernel(
            WebGPUCompiledKernel compiledKernel,
            MethodInfo launcher)
        {
            return new WebGPUKernel(this, compiledKernel, launcher);
        }

        protected override MethodInfo GenerateKernelLauncherMethod(
            WebGPUCompiledKernel kernel,
            int customGroupSize)
        {
            var parameters = kernel.EntryPoint.Parameters;
            var indexType = kernel.EntryPoint.KernelIndexType;

            var argTypes = new List<Type>();
            argTypes.Add(typeof(Kernel));
            argTypes.Add(typeof(AcceleratorStream));
            argTypes.Add(indexType);
            for (int i = 0; i < parameters.Count; i++)
            {
                argTypes.Add(parameters[i]);
            }

            var dynamicMethod = new DynamicMethod(
                "WebGPULauncher",
                typeof(void),
                argTypes.ToArray(),
                typeof(WebGPUAccelerator).Module);

            var ilGenerator = dynamicMethod.GetILGenerator();
            var emitter = new ILEmitter(ilGenerator);

            var argsLocal = emitter.DeclareLocal(typeof(object[]));
            ilGenerator.Emit(OpCodes.Ldc_I4, parameters.Count);
            ilGenerator.Emit(OpCodes.Newarr, typeof(object));
            emitter.Emit(LocalOperation.Store, argsLocal);

            for (int i = 0; i < parameters.Count; i++)
            {
                emitter.Emit(LocalOperation.Load, argsLocal);
                ilGenerator.Emit(OpCodes.Ldc_I4, i);
                emitter.Emit(ArgumentOperation.Load, i + 3);

                var paramType = parameters[i];
                if (paramType.IsValueType)
                    ilGenerator.Emit(OpCodes.Box, paramType);

                ilGenerator.Emit(OpCodes.Stelem_Ref);
            }

            emitter.Emit(ArgumentOperation.Load, 0);
            emitter.Emit(ArgumentOperation.Load, 1);
            emitter.Emit(ArgumentOperation.Load, 2);

            if (indexType.IsValueType)
            {
                ilGenerator.Emit(OpCodes.Box, indexType);
            }

            emitter.Emit(LocalOperation.Load, argsLocal);
            ilGenerator.EmitCall(OpCodes.Call, RunKernelMethod, null);
            ilGenerator.Emit(OpCodes.Ret);

            return dynamicMethod;
        }

        // Helper to robustly extract Stride (Width) from ArrayView2D/3D using Brute Force Reflection
        private static int ExtractStrideFromView(object view, Type viewType)
        {
            try
            {
                // We use IgnoreCase and look for ANY field/property that returns Index2D/Index3D
                var flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.IgnoreCase;

                // Helper to extract X from an Index object
                int GetX(object d)
                {
                    var t = d.GetType();
                    var fX = t.GetField("X", flags);
                    if (fX != null) return Convert.ToInt32(fX.GetValue(d));
                    var pX = t.GetProperty("X", flags);
                    if (pX != null) return Convert.ToInt32(pX.GetValue(d));
                    return 0;
                }

                // 1. Direct "Width" Property check (Fastest)
                var directWidth = viewType.GetProperty("Width", flags);
                if (directWidth != null)
                {
                    int val = Convert.ToInt32(directWidth.GetValue(view));
                    if (val > 0) return val;
                }

                // 2. Iterate ALL Fields (Robust - catches backing fields)
                foreach (var field in viewType.GetFields(flags))
                {
                    if (field.FieldType.Name.Contains("Index2D") || field.FieldType.Name.Contains("Index3D"))
                    {
                        var dims = field.GetValue(view);
                        if (dims != null)
                        {
                            int x = GetX(dims);
                            if (x > 0) return x;
                        }
                    }
                }

                // 3. Iterate ALL Properties (Robust)
                foreach (var prop in viewType.GetProperties(flags))
                {
                    if (prop.GetIndexParameters().Length > 0) continue;

                    if (prop.PropertyType.Name.Contains("Index2D") || prop.PropertyType.Name.Contains("Index3D"))
                    {
                        try
                        {
                            var dims = prop.GetValue(view);
                            if (dims != null)
                            {
                                int x = GetX(dims);
                                if (x > 0) return x;
                            }
                        }
                        catch { }
                    }
                }
            }
            catch { /* Ignore errors during extraction */ }
            return 0;
        }

        public static void RunKernel(Kernel kernel, AcceleratorStream stream, object dimension, object[] args)
        {
            var webGpuAccel = (WebGPUAccelerator)kernel.Accelerator;
            var nativeAccel = webGpuAccel.NativeAccelerator;
            var webGpuKernel = (WebGPUKernel)kernel;
            var compiledKernel = webGpuKernel.CompiledKernel;

            var shader = nativeAccel.CreateComputeShader(compiledKernel.WGSLSource);
            var device = nativeAccel.NativeDevice!;
            var entries = new List<GPUBindGroupEntry>();

            // Debug log commented out for performance
            // Console.WriteLine($"[WebGPU] RunKernel: Starting kernel dispatch with {args.Length} arguments");

            try
            {
                int currentBindingIndex = 0;
                for (int i = 0; i < args.Length; i++)
                {
                    var paramType = compiledKernel.EntryPoint.Parameters[i];

                    if (i == 0 && (paramType == typeof(Index1D) || paramType == typeof(Index2D) || paramType == typeof(Index3D) ||
                                   paramType == typeof(LongIndex1D) || paramType == typeof(LongIndex2D) || paramType == typeof(LongIndex3D)))
                        continue;

                    var arg = args[i];

                    IArrayView? arrayView = arg as IArrayView;
                    int strideVal = 0;

                    if (arg != null)
                    {
                        var argType = arg.GetType();

                        // Extract Stride if it is a MultiDim view
                        if (argType.Name.Contains("ArrayView2D") || argType.Name.Contains("ArrayView3D"))
                        {
                            strideVal = ExtractStrideFromView(arg, argType);
                        }

                        if (arrayView == null)
                        {
                            if (argType.Name.Contains("ArrayView2D") || argType.Name.Contains("ArrayView3D"))
                            {
                                var baseViewProp = argType.GetProperty("BaseView");
                                if (baseViewProp != null)
                                {
                                    arrayView = baseViewProp.GetValue(arg) as IArrayView;
                                }
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

                        if (contiguous == null) throw new Exception($"Argument {i} ({arg.GetType()}) is not a contiguous WebGPU buffer");

                        var buffer = contiguous.Buffer as WebGPUMemoryBuffer;
                        if (buffer == null) throw new Exception($"Argument {i} is not a WebGPU buffer (Buffer is null or wrong type)");

                        var nativeBuffer = buffer.NativeBuffer.NativeBuffer!;
                        var offset = (ulong)((long)contiguous.IndexInBytes);
                        var size = (ulong)((long)contiguous.LengthInBytes);

                        resource = new GPUBufferBinding
                        {
                            Buffer = nativeBuffer,
                            Offset = offset,
                            Size = size
                        };
                    }
                    else
                    {
                        // Scalar Handling
                        var size = 256;
                        var bufferDesc = new GPUBufferDescriptor
                        {
                            Label = $"ScalarArg_{i}",
                            Size = (ulong)size,
                            Usage = GPUBufferUsage.Storage | GPUBufferUsage.CopyDst,
                            MappedAtCreation = false
                        };
                        var uBuffer = device.CreateBuffer(bufferDesc);

                        if (arg is int iVal) device.Queue.WriteBuffer(uBuffer, 0, BitConverter.GetBytes(iVal));
                        else if (arg is float fVal) device.Queue.WriteBuffer(uBuffer, 0, BitConverter.GetBytes(fVal));
                        else if (arg is uint uiVal) device.Queue.WriteBuffer(uBuffer, 0, BitConverter.GetBytes(uiVal));
                        else if (arg is long lVal) device.Queue.WriteBuffer(uBuffer, 0, BitConverter.GetBytes((int)lVal));
                        else if (arg is ulong ulVal) device.Queue.WriteBuffer(uBuffer, 0, BitConverter.GetBytes((uint)ulVal));
                        else if (arg is double dVal) device.Queue.WriteBuffer(uBuffer, 0, BitConverter.GetBytes((float)dVal));
                        else if (arg is byte bVal) device.Queue.WriteBuffer(uBuffer, 0, new byte[] { bVal });
                        else if (arg is bool blVal) device.Queue.WriteBuffer(uBuffer, 0, BitConverter.GetBytes(blVal ? 1u : 0u));
                        else throw new NotSupportedException($"Unsupported scalar argument type: {arg.GetType()}");

                        resource = new GPUBufferBinding
                        {
                            Buffer = uBuffer,
                            Offset = 0,
                            Size = (ulong)size
                        };
                    }

                    entries.Add(new GPUBindGroupEntry
                    {
                        Binding = (uint)currentBindingIndex,
                        Resource = resource!
                    });
                    currentBindingIndex++;

                    // Argument Decomposition for ArrayView2D/3D
                    string pTypeName = paramType.Name;
                    if (pTypeName.Contains("ArrayView2D") || pTypeName.Contains("ArrayView3D"))
                    {
                        var strideSize = 256;
                        var strideDesc = new GPUBufferDescriptor
                        {
                            Label = $"StrideArg_{i}",
                            Size = (ulong)strideSize,
                            Usage = GPUBufferUsage.Storage | GPUBufferUsage.CopyDst,
                            MappedAtCreation = false
                        };
                        var strideBuffer = device.CreateBuffer(strideDesc);

                        // Console.WriteLine($"[WebGPU] Created Stride Buffer: Binding={currentBindingIndex}, Val={strideVal}");

                        device.Queue.WriteBuffer(strideBuffer, 0, BitConverter.GetBytes(strideVal));

                        entries.Add(new GPUBindGroupEntry
                        {
                            Binding = (uint)currentBindingIndex,
                            Resource = new GPUBufferBinding
                            {
                                Buffer = strideBuffer,
                                Offset = 0,
                                Size = (ulong)strideSize
                            }
                        });
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
                if (dimension is Index1D i1) workX = (uint)Math.Ceiling(i1.X / 64.0);
                else if (dimension is Index2D i2) { workX = (uint)Math.Ceiling(i2.X / 8.0); workY = (uint)Math.Ceiling(i2.Y / 8.0); }
                else if (dimension is Index3D i3) { workX = (uint)Math.Ceiling(i3.X / 4.0); workY = (uint)Math.Ceiling(i3.Y / 4.0); workZ = (uint)Math.Ceiling(i3.Z / 4.0); }
                else if (dimension is LongIndex1D l1) workX = (uint)Math.Ceiling(l1.X / 64.0);
                else if (dimension is LongIndex2D l2) { workX = (uint)Math.Ceiling(l2.X / 8.0); workY = (uint)Math.Ceiling(l2.Y / 8.0); }
                else if (dimension is LongIndex3D l3) { workX = (uint)Math.Ceiling(l3.X / 4.0); workY = (uint)Math.Ceiling(l3.Y / 4.0); workZ = (uint)Math.Ceiling(l3.Z / 4.0); }

                using var encoder = device.CreateCommandEncoder();
                using var pass = encoder.BeginComputePass();
                pass.SetPipeline(shader.Pipeline);
                pass.SetBindGroup(0, bindGroup);

                // Console.WriteLine($"[WebGPU] Dispatching Kernel: ({workX}, {workY}, {workZ})");
                pass.DispatchWorkgroups(workX, workY, workZ);

                pass.End();
                using var cmd = encoder.Finish();
                nativeAccel.Queue!.Submit(new[] { cmd });
                // Console.WriteLine("[WebGPU] Queue Submitted");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[WebGPU] Error running kernel: {ex}");
                throw;
            }
        }

        protected override MemoryBuffer AllocateRawInternal(long length, int elementSize)
        {
            return new WebGPUMemoryBuffer(this, length, elementSize);
        }

        protected override AcceleratorStream CreateStreamInternal()
        {
            return new WebGPUStream(this);
        }

        protected override void SynchronizeInternal()
        {
            // WebGPU queue.onSubmittedWorkDone() could be here but blocking is not allowed.
            // Console.WriteLine("[WebGPU] SynchronizeInternal (No-op non-blocking)");
        }

        protected override void OnBind() { }
        protected override void OnUnbind() { }

        protected override void DisposeAccelerator_SyncRoot(bool disposing)
        {
            if (disposing) NativeAccelerator.Dispose();
        }

        public override TExtension CreateExtension<TExtension, TExtensionProvider>(TExtensionProvider provider)
        {
            return default;
        }

        protected override PageLockScope<T> CreatePageLockFromPinnedInternal<T>(IntPtr ptr, long numElements)
        {
            throw new NotSupportedException();
        }

        protected override int EstimateGroupSizeInternal(Kernel kernel, int dynamicSharedMemorySize, int maxGridSize, out int groupSize)
        {
            groupSize = 64;
            return 64;
        }

        protected override int EstimateGroupSizeInternal(Kernel kernel, Func<int, int> computeSharedMemorySize, int maxGridSize, out int groupSize)
        {
            groupSize = 64;
            return 64;
        }

        protected override int EstimateMaxActiveGroupsPerMultiprocessorInternal(Kernel kernel, int groupSize, int dynamicSharedMemorySize) => 1;

        protected override void EnablePeerAccessInternal(Accelerator other) { }
        protected override void DisablePeerAccessInternal(Accelerator other) { }
        protected override bool CanAccessPeerInternal(Accelerator other) => false;

        private class WebGPUStream : AcceleratorStream
        {
            public WebGPUStream(Accelerator acc) : base(acc) { }

            protected override void DisposeAcceleratorObject(bool disposing) { }

            public override void Synchronize() { }

            protected override global::ILGPU.Runtime.ProfilingMarker AddProfilingMarkerInternal()
            {
                throw new NotSupportedException();
            }
        }
    }

    public class WebGPUKernel : Kernel
    {
        public WebGPUKernel(Accelerator accelerator, CompiledKernel compiledKernel, MethodInfo launcher)
            : base(accelerator, compiledKernel, launcher)
        {
        }

        public new WebGPUCompiledKernel CompiledKernel => (WebGPUCompiledKernel)base.CompiledKernel;

        protected override void DisposeAcceleratorObject(bool disposing)
        {
        }
    }
}