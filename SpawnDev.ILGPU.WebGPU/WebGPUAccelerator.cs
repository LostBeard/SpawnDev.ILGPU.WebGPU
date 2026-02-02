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

        public WebGPUBackend Backend { get; private set; }

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

            // Manual DynamicMethod creation since EntryPoint.CreateLauncherMethod is internal
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

            // Create args array: var args = new object[parameters.Count];
            var argsLocal = emitter.DeclareLocal(typeof(object[]));
            ilGenerator.Emit(OpCodes.Ldc_I4, parameters.Count);
            ilGenerator.Emit(OpCodes.Newarr, typeof(object));
            emitter.Emit(LocalOperation.Store, argsLocal);

            // Fill args array
            for (int i = 0; i < parameters.Count; i++)
            {
                emitter.Emit(LocalOperation.Load, argsLocal);
                ilGenerator.Emit(OpCodes.Ldc_I4, i);
                
                // Load argument (Offset 3 because arg 0=Kernel, 1=Stream, 2=Dimension)
                emitter.Emit(ArgumentOperation.Load, i + 3);

                var paramType = parameters[i];
                if (paramType.IsValueType)
                    ilGenerator.Emit(OpCodes.Box, paramType);

                ilGenerator.Emit(OpCodes.Stelem_Ref);
            }

            // Call RunKernel(kernel, stream, dimension, args)
            emitter.Emit(ArgumentOperation.Load, 0); // Kernel
            emitter.Emit(ArgumentOperation.Load, 1); // Stream
            emitter.Emit(ArgumentOperation.Load, 2); // Dimension (Index)
            
            // Box index if needed
            if (indexType.IsValueType)
            {
                 ilGenerator.Emit(OpCodes.Box, indexType); 
            }

            emitter.Emit(LocalOperation.Load, argsLocal);
            
            ilGenerator.EmitCall(OpCodes.Call, RunKernelMethod, null);
            ilGenerator.Emit(OpCodes.Ret);
            
            // finish() not needed for DynamicMethod/ILGenerator
            return dynamicMethod;
        }

        public static void RunKernel(Kernel kernel, AcceleratorStream stream, object dimension, object[] args)
        {
            var webGpuAccel = (WebGPUAccelerator)kernel.Accelerator;
            var nativeAccel = webGpuAccel.NativeAccelerator;
            var webGpuKernel = (WebGPUKernel)kernel;
            var compiledKernel = webGpuKernel.CompiledKernel;
            
            // 1. Get/Create Compute Shader
            var shader = nativeAccel.CreateComputeShader(compiledKernel.WGSLSource);
            
            // 2. Create Bind Group
            var device = nativeAccel.NativeDevice!;
            var entries = new List<GPUBindGroupEntry>();
            var allocatedBuffers = new List<GPUBuffer>();
            
            try 
            {
                int bindingIndex = 0;
                for(int i=0; i<args.Length; i++)
                {
                    var paramType = compiledKernel.EntryPoint.Parameters[i];
                    
                    // Skip index parameter (param 0 usually) - handled by built-ins in WGSL
                    if (i == 0 && (paramType == typeof(Index1D) || paramType == typeof(Index2D) || paramType == typeof(Index3D) ||
                                   paramType == typeof(LongIndex1D) || paramType == typeof(LongIndex2D) || paramType == typeof(LongIndex3D)))
                        continue;

                    var arg = args[i];
                    GPUBufferBinding? resource = null;
                    
                    if (arg is IContiguousArrayView arrayView) 
                    {
                        var buffer = arrayView.Buffer as WebGPUMemoryBuffer;
                        if (buffer == null) throw new Exception($"Argument {i} is not a WebGPU buffer");
                        
                        var nativeBuffer = buffer.NativeBuffer.NativeBuffer!;
                        var offset = (ulong)((long)arrayView.IndexInBytes);
                        var size = (ulong)((long)arrayView.LengthInBytes);
                        
                        resource = new GPUBufferBinding 
                        {
                            Buffer = nativeBuffer,
                            Offset = offset,
                            Size = size
                        };
                    }
                    else 
                    {
                        // Scalar - Create uniform buffer
                        // Use 16 bytes for alignment/padding safety
                        var size = 16;
                        
                        var bufferDesc = new GPUBufferDescriptor {
                            Size = (ulong)size,
                            Usage = GPUBufferUsage.Uniform | GPUBufferUsage.CopyDst,
                            MappedAtCreation = false
                        };
                        var uBuffer = device.CreateBuffer(bufferDesc);
                        allocatedBuffers.Add(uBuffer);
                        
                        byte[] scalarData;
                        if (arg is int iVal) scalarData = BitConverter.GetBytes(iVal);
                        else if (arg is float fVal) scalarData = BitConverter.GetBytes(fVal);
                        else if (arg is double dVal) scalarData = BitConverter.GetBytes(dVal);
                        else if (arg is long lVal) scalarData = BitConverter.GetBytes(lVal);
                        else if (arg is uint uiVal) scalarData = BitConverter.GetBytes(uiVal);
                        else if (arg is ulong ulVal) scalarData = BitConverter.GetBytes(ulVal);
                        else throw new NotSupportedException($"Unsupported scalar argument type: {arg.GetType()}");
                        
                        nativeAccel.Queue!.WriteBuffer(uBuffer, (long)0, scalarData);
                        
                        resource = new GPUBufferBinding {
                            Buffer = uBuffer
                        };
                    }
                    
                    entries.Add(new GPUBindGroupEntry {
                        Binding = (uint)bindingIndex,
                        Resource = resource!
                    });
                    bindingIndex++;
                }
                
                var bindGroupDesc = new GPUBindGroupDescriptor {
                    Layout = shader.Pipeline!.GetBindGroupLayout(0),
                    Entries = entries.ToArray()
                };
                
                using var bindGroup = device.CreateBindGroup(bindGroupDesc);
                
                // 3. Dispatch
                uint x=1, y=1, z=1;
                if (dimension is Index1D d1) { x = (uint)d1.X; }
                else if (dimension is Index2D d2) { x = (uint)d2.X; y = (uint)d2.Y; }
                else if (dimension is Index3D d3) { x = (uint)d3.X; y = (uint)d3.Y; z = (uint)d3.Z; }
                
                using var encoder = device.CreateCommandEncoder();
                using var pass = encoder.BeginComputePass();
                pass.SetPipeline(shader.Pipeline);
                pass.SetBindGroup(0, bindGroup);
                
                // Hardcoded 64 workgroup size from WGSL generator
                pass.DispatchWorkgroups(
                    (uint)Math.Ceiling(x / 64.0), 
                    y, 
                    z); 
                    
                pass.End();
                using var cmd = encoder.Finish();
                nativeAccel.Queue!.Submit(new[] { cmd });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error running kernel: {ex}");
                throw;
            }
            finally 
            {
                // LEAK: Deferring disposal of buffers to avoid GPU errors during async execution
                // In a production app, these should be pooled or disposed when the stream/accelerator is synchronized.
                // foreach(var b in allocatedBuffers) b.Dispose();
                
                // Shader module and pipeline should also stay alive until GPU is finished
                // shader.Dispose(); // Commented out to be safe
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
            // No-op.
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
            public WebGPUStream(Accelerator acc) : base(acc) {}

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
