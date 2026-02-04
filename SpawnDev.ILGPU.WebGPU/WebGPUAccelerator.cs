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
using Array = System.Array;

namespace SpawnDev.ILGPU.WebGPU
{
    public class WebGPUAccelerator : KernelAccelerator<WebGPUCompiledKernel, WebGPUKernel>
    {
        public WebGPUNativeAccelerator NativeAccelerator { get; private set; } = null!;
        public WebGPUBackend Backend { get; private set; } = null!;

        public static readonly MethodInfo RunKernelMethod = typeof(WebGPUAccelerator).GetMethod(
            nameof(RunKernel),
            BindingFlags.Public | BindingFlags.Static)!;

        private WebGPUAccelerator(Context context, Device device) : base(context, device) { }

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

        protected override WebGPUKernel CreateKernel(WebGPUCompiledKernel compiledKernel, MethodInfo launcher)
        {
            return new WebGPUKernel(this, compiledKernel, launcher);
        }

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
                     } catch {}
                }

                // Fallback to Length (Long)
                 var pLength = viewType.GetProperty("Length", flags);
                if (pLength != null && (pLength.PropertyType == typeof(int) || pLength.PropertyType == typeof(long))) 
                {
                     try 
                     {
                        var val = Convert.ToInt32(pLength.GetValue(view));
                        return new int[] { val };
                     } catch {}
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

        public static void RunKernel(Kernel kernel, AcceleratorStream stream, object dimension, object[] args)
        {
            var webGpuAccel = (WebGPUAccelerator)kernel.Accelerator;
            var nativeAccel = webGpuAccel.NativeAccelerator;
            var webGpuKernel = (WebGPUKernel)kernel;
            var compiledKernel = webGpuKernel.CompiledKernel;

            // ---- DEBUG LOGGING: WGSL SOURCE ----
            Console.WriteLine("\n[WebGPU-Debug] ---- GENERATED WGSL ----");
            Console.WriteLine(compiledKernel.WGSLSource);
            Console.WriteLine("[WebGPU-Debug] ------------------------\n");
            // ------------------------------------

            var shader = nativeAccel.CreateComputeShader(compiledKernel.WGSLSource);
            var device = nativeAccel.NativeDevice!;

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
                        Console.WriteLine($"[WebGPU-Debug] Arg {i}: Binding Buffer. Size={contiguous.LengthInBytes}, Offset={contiguous.IndexInBytes}");

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
                        var bufferDesc = new GPUBufferDescriptor
                        {
                            Label = $"ScalarArg_{i}",
                            Size = (ulong)size,
                            Usage = GPUBufferUsage.Storage | GPUBufferUsage.CopyDst,
                            MappedAtCreation = false
                        };
                        var uBuffer = device.CreateBuffer(bufferDesc);

                        // DEBUG LOG
                        Console.WriteLine($"[WebGPU-Debug] Arg {i}: Binding Scalar. Value={arg}");

                        if (arg is int iVal) device.Queue.WriteBuffer(uBuffer, 0, BitConverter.GetBytes(iVal));
                        else if (arg is float fVal) device.Queue.WriteBuffer(uBuffer, 0, BitConverter.GetBytes(fVal));
                        else if (arg is uint uiVal) device.Queue.WriteBuffer(uBuffer, 0, BitConverter.GetBytes(uiVal));
                        else if (arg is long lVal) device.Queue.WriteBuffer(uBuffer, 0, BitConverter.GetBytes((int)lVal));
                        else if (arg is ulong ulVal) device.Queue.WriteBuffer(uBuffer, 0, BitConverter.GetBytes((uint)ulVal));
                        else if (arg is double dVal) device.Queue.WriteBuffer(uBuffer, 0, BitConverter.GetBytes((float)dVal));
                        else if (arg is byte bVal) device.Queue.WriteBuffer(uBuffer, 0, new byte[] { bVal });
                        else if (arg is bool blVal) device.Queue.WriteBuffer(uBuffer, 0, BitConverter.GetBytes(blVal ? 1u : 0u));
                        else throw new NotSupportedException($"Unsupported scalar argument type: {arg.GetType()}");

                        resource = new GPUBufferBinding { Buffer = uBuffer, Offset = 0, Size = (ulong)size };
                    }

                    entries.Add(new GPUBindGroupEntry { Binding = (uint)currentBindingIndex, Resource = resource! });
                    currentBindingIndex++;

                    if (dims.Length > 1)
                    {
                        Console.WriteLine($"[WebGPU-Debug] Arg {i}: Binding Stride Buffer. Values=[{string.Join(", ", dims)}]");

                        var strideSize = 256;
                        var strideDesc = new GPUBufferDescriptor
                        {
                            Label = $"StrideArg_{i}",
                            Size = (ulong)strideSize,
                            Usage = GPUBufferUsage.Storage | GPUBufferUsage.CopyDst,
                            MappedAtCreation = false
                        };
                        var strideBuffer = device.CreateBuffer(strideDesc);

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
                if (dimension is Index1D i1) workX = (uint)Math.Ceiling(i1.X / 64.0);
                else if (dimension is Index2D i2) { workX = (uint)Math.Ceiling(i2.X / 8.0); workY = (uint)Math.Ceiling(i2.Y / 8.0); }
                else if (dimension is Index3D i3) { workX = (uint)Math.Ceiling(i3.X / 4.0); workY = (uint)Math.Ceiling(i3.Y / 4.0); workZ = (uint)Math.Ceiling(i3.Z / 4.0); }
                else if (dimension is LongIndex1D l1) workX = (uint)Math.Ceiling(l1.X / 64.0);
                else if (dimension is LongIndex2D l2) { workX = (uint)Math.Ceiling(l2.X / 8.0); workY = (uint)Math.Ceiling(l2.Y / 8.0); }
                else if (dimension is LongIndex3D l3) { workX = (uint)Math.Ceiling(l3.X / 4.0); workY = (uint)Math.Ceiling(l3.Y / 4.0); workZ = (uint)Math.Ceiling(l3.Z / 4.0); }

                Console.WriteLine($"[WebGPU-Debug] Dispatching: ({workX}, {workY}, {workZ})");

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
                Console.WriteLine($"[WebGPU] Error running kernel: {ex}");
                throw;
            }
        }

        protected override MemoryBuffer AllocateRawInternal(long length, int elementSize) => new WebGPUMemoryBuffer(this, length, elementSize);
        protected override AcceleratorStream CreateStreamInternal() => new WebGPUStream(this);
        protected override void SynchronizeInternal() { }
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

    public class WebGPUKernel : Kernel
    {
        public WebGPUKernel(Accelerator accelerator, CompiledKernel compiledKernel, MethodInfo launcher) : base(accelerator, compiledKernel, launcher) { }
        public new WebGPUCompiledKernel CompiledKernel => (WebGPUCompiledKernel)base.CompiledKernel;
        protected override void DisposeAcceleratorObject(bool disposing) { }
    }
}