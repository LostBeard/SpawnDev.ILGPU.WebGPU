using ILGPU = global::ILGPU;
using SpawnDev.Blazor.UnitTesting;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using SpawnDev.ILGPU.WebGPU.Backend;
using ILGPU;
using ILGPU.Runtime;

namespace SpawnDev.ILGPU.WebGPU.Demo.UnitTests
{
    /// <summary>
    /// Contains unit tests that verify the SpawnDev.ILGPU.WebGPU is working correctly
    /// </summary>
    public class Tests
    {
        [TestMethod]
        public async Task WebGPUAcceleratorBasicTest()
        {
            // Basic test of ILGPU WebGPU accelerator initialization
            var devices = await WebGPU.WebGPUDevice.GetDevicesAsync();
            if (devices.Length == 0)
                throw new UnsupportedTestException("No WebGPU devices found");
            var device = devices[0];
            using var accelerator = await device.CreateAcceleratorAsync();
            if (!accelerator.IsInitialized)
                throw new Exception("WebGPUAccelerator is not initialized");

            // Allocate a buffer and verify its size
            using var buffer = accelerator.Allocate<int>(1024);
            if (buffer.Length != 1024)
                throw new Exception("Buffer length mismatch");
        }

        [TestMethod]
        public async Task WebGPUBufferTransferTest()
        {
            var device = await WebGPU.WebGPUDevice.GetDefaultDeviceAsync();
            if (device == null)
                throw new UnsupportedTestException("No WebGPU devices found");

            using var accelerator = await device.CreateAcceleratorAsync();
            
            int length = 128;
            var data = Enumerable.Range(0, length).ToArray();
            
            // Allocate and copy to device
            using var buffer = accelerator.Allocate(data);
            
            // Copy back to host
            var readBack = await buffer.CopyToHostAsync();
            
            if (readBack.Length != length)
                throw new Exception($"Readback length mismatch. Expected {length}, got {readBack.Length}");

            for (int i = 0; i < length; i++)
            {
                if (readBack[i] != data[i])
                    throw new Exception($"Data mismatch at index {i}. Expected {data[i]}, got {readBack[i]}");
            }
        }

        [TestMethod]
        public async Task WebGPUComputeTest()
        {
            var device = await WebGPU.WebGPUDevice.GetDefaultDeviceAsync();
            if (device == null)
                throw new UnsupportedTestException("No WebGPU devices found");

            using var accelerator = await device.CreateAcceleratorAsync();

            int length = 64;
            var input = Enumerable.Range(0, length).Select(i => (float)i).ToArray();
            var zeros = new float[length];
            
            using var bufferIn = accelerator.Allocate(input);
            using var bufferOut = accelerator.Allocate(zeros); // Output buffer initialized to zeros

            string wgsl = @"
@group(0) @binding(0) var<storage, read> input : array<f32>;
@group(0) @binding(1) var<storage, read_write> output : array<f32>;

@compute @workgroup_size(64)
fn main(@builtin(global_invocation_id) global_id : vec3<u32>) {
    let i = global_id.x;
    if (i >= arrayLength(&output)) {
        return;
    }
    output[i] = input[i] * 2.0;
}
";
            using var shader = accelerator.CreateComputeShader(wgsl);
            
            shader.SetBuffer(0, bufferIn)
                  .SetBuffer(1, bufferOut);
            
            // Dispatch 1 group of 64
            shader.Dispatch(1);

            var result = await bufferOut.CopyToHostAsync();
            
            for (int i = 0; i < length; i++)
            {
                var expected = input[i] * 2.0f;
                if (Math.Abs(result[i] - expected) > 0.0001f)
                    throw new Exception($"Compute error at {i}. Expected {expected}, got {result[i]}");
            }
        }

        [TestMethod]
        public async Task WebGPUMultipleDispatchTest()
        {
             var device = await WebGPU.WebGPUDevice.GetDefaultDeviceAsync();
            if (device == null)
                throw new UnsupportedTestException("No WebGPU devices found");

            using var accelerator = await device.CreateAcceleratorAsync();
            
            float[] data = new float[] { 1.0f };
            using var buffer = accelerator.Allocate(data);

             string wgsl = @"
@group(0) @binding(0) var<storage, read_write> data : array<f32>;

@compute @workgroup_size(1)
fn main(@builtin(global_invocation_id) global_id : vec3<u32>) {
    if (global_id.x == 0u) {
        data[0] = data[0] + 1.0;
    }
}
";
            using var shader = accelerator.CreateComputeShader(wgsl);
            shader.SetBuffer(0, buffer);

            // Dispatch 5 times
            for(int i=0; i<5; i++)
            {
                shader.Dispatch(1);
            }

            var result = await buffer.CopyToHostAsync();
            // Initial 1.0 + 5 additions = 6.0
            if (Math.Abs(result[0] - 6.0f) > 0.0001f)
                 throw new Exception($"Multiple dispatch error. Expected 6.0, got {result[0]}");
        }

        [TestMethod]
        public async Task WebGPU2DDispatchTest()
        {
            var device = await WebGPU.WebGPUDevice.GetDefaultDeviceAsync();
            if (device == null)
                throw new UnsupportedTestException("No WebGPU devices found");

            using var accelerator = await device.CreateAcceleratorAsync();

            int width = 8;
            int height = 8;
            int length = width * height;
            var output = new float[length];
            using var bufferOut = accelerator.Allocate(output);

            string wgsl = @"
struct Params {
    width : u32,
}

@group(0) @binding(0) var<storage, read_write> output : array<f32>;

@compute @workgroup_size(1, 1)
fn main(@builtin(global_invocation_id) global_id : vec3<u32>) {
    let x = global_id.x;
    let y = global_id.y;
    let width = 8u; // Hardcoded for simplicity in this test
    let index = y * width + x;
    output[index] = f32(x) + f32(y) * 100.0;
}
";
            using var shader = accelerator.CreateComputeShader(wgsl);
            shader.SetBuffer(0, bufferOut);

            // Dispatch 8x8
            shader.Dispatch((uint)width, (uint)height);

            var result = await bufferOut.CopyToHostAsync();

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int index = y * width + x;
                    float expected = x + y * 100.0f;
                    if (Math.Abs(result[index] - expected) > 0.0001f)
                        throw new Exception($"2D dispatch error at ({x},{y}). Expected {expected}, got {result[index]}");
                }
            }
        }

        [TestMethod]
        public async Task WebGPUWorkgroupBarrierTest()
        {
            var device = await WebGPU.WebGPUDevice.GetDefaultDeviceAsync();
            if (device == null)
                throw new UnsupportedTestException("No WebGPU devices found");

            using var accelerator = await device.CreateAcceleratorAsync();

            int length = 64;
            var input = Enumerable.Range(0, length).Select(i => (float)i).ToArray();
            var zeros = new float[length];

            using var bufferIn = accelerator.Allocate(input);
            using var bufferOut = accelerator.Allocate(zeros);

            // This shader reverses the array within the workgroup using shared memory
            string wgsl = @"
var<workgroup> shared_data : array<f32, 64>;

@group(0) @binding(0) var<storage, read> input : array<f32>;
@group(0) @binding(1) var<storage, read_write> output : array<f32>;

@compute @workgroup_size(64)
fn main(@builtin(local_invocation_id) local_id : vec3<u32>, @builtin(workgroup_id) workgroup_id : vec3<u32>) {
    let i = local_id.x;
    
    // Load into shared memory
    shared_data[i] = input[i];
    
    // Wait for all threads to load
    workgroupBarrier();
    
    // Write out in reverse order
    let reverse_i = 63u - i;
    output[i] = shared_data[reverse_i];
}
";
            using var shader = accelerator.CreateComputeShader(wgsl);
            
            shader.SetBuffer(0, bufferIn)
                  .SetBuffer(1, bufferOut);
            
            shader.Dispatch(1);

            var result = await bufferOut.CopyToHostAsync();

            for (int i = 0; i < length; i++)
            {
                float expected = input[length - 1 - i];
                if (Math.Abs(result[i] - expected) > 0.0001f)
                    throw new Exception($"Barrier test error at {i}. Expected {expected}, got {result[i]}");
            }
        }

        [TestMethod]
        public async Task WebGPUKernelTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var devices = context.GetWebGPUDevices();
            if (devices.Count == 0) throw new UnsupportedTestException("No WebGPU devices found");
            var device = devices[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);
                
            var data = new int[64];
            using var buffer = accelerator.Allocate1D(data);

            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<int>, int>(MyKernel);
            kernel((Index1D)buffer.Length, buffer.View, 33);

            accelerator.Synchronize();
            
            var result = await ReadBufferAsync<int>(buffer);

            for (int i = 0; i < data.Length; i++)
            {
                var expected = i + 33;
                if (result[i] != expected)
                    throw new Exception($"Kernel execution failed at {i}. Expected {expected}, got {result[i]}");
            }
        }

        [TestMethod]
        public async Task WebGPUVectorAddKernelTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var devices = context.GetWebGPUDevices();
            if (devices.Count == 0) throw new UnsupportedTestException("No WebGPU devices found");
            var device = devices[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int length = 64;
            var a = Enumerable.Range(0, length).Select(i => (float)i).ToArray();
            var b = Enumerable.Range(0, length).Select(i => (float)i * 2.0f).ToArray();
            
            using var bufA = accelerator.Allocate1D(a);
            using var bufB = accelerator.Allocate1D(b);
            using var bufC = accelerator.Allocate1D<float>(length);

            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<float>, ArrayView<float>, ArrayView<float>>(VectorAddKernel);
            kernel((Index1D)length, bufA.View, bufB.View, bufC.View);

            accelerator.Synchronize();

            var result = await ReadBufferAsync<float>(bufC);

            for (int i = 0; i < length; i++)
            {
                var expected = a[i] + b[i];
                if (Math.Abs(result[i] - expected) > 0.0001f)
                    throw new Exception($"Vector addition failed at {i}. Expected {expected}, got {result[i]}");
            }
        }

        [TestMethod]
        public async Task WebGPUKernel2DTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var devices = context.GetWebGPUDevices();
            if (devices.Count == 0) throw new UnsupportedTestException("No WebGPU devices found");
            var device = devices[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            LongIndex2D extent = new LongIndex2D(8, 8);
            using var buffer = accelerator.Allocate2DDenseX<float>(extent);

            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index2D, ArrayView2D<float, Stride2D.DenseX>>(Kernel2D);
            kernel((Index2D)extent, buffer.View);

            accelerator.Synchronize();

            var result = await ReadBufferAsync<float>(buffer);

            for (int y = 0; y < extent.Y; y++)
            {
                for (int x = 0; x < extent.X; x++)
                {
                    var expected = x + y * 100.0f;
                    var actual = result[y * extent.X + x];
                    if (Math.Abs(actual - expected) > 0.0001f)
                        throw new Exception($"2D kernel failed at ({x},{y}). Expected {expected}, got {actual}");
                }
            }
        }

        [TestMethod]
        public async Task WebGPUKernelFloatTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var devices = context.GetWebGPUDevices();
            if (devices.Count == 0) throw new UnsupportedTestException("No WebGPU devices found");
            var device = devices[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int length = 64;
            using var buffer = accelerator.Allocate1D<float>(length);

            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<float>, float>(FloatKernel);
            kernel((Index1D)length, buffer.View, 0.5f);

            accelerator.Synchronize();

            var result = await ReadBufferAsync<float>(buffer);

            for (int i = 0; i < length; i++)
            {
                var expected = i * 2.0f + 0.5f;
                if (Math.Abs(result[i] - expected) > 0.0001f)
                    throw new Exception($"Float kernel failed at {i}. Expected {expected}, got {result[i]}");
            }
        }

        [TestMethod]
        public async Task WebGPUMultiScalarKernelTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var devices = context.GetWebGPUDevices();
            if (devices.Count == 0) throw new UnsupportedTestException("No WebGPU devices found");
            var device = devices[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int length = 64;
            using var buffer = accelerator.Allocate1D<int>(length);

            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<int>, int, int>(MultiScalarKernel);
            kernel((Index1D)length, buffer.View, 10, 20);

            accelerator.Synchronize();

            var result = await ReadBufferAsync<int>(buffer);

            for (int i = 0; i < length; i++)
            {
                var expected = i + 10 + 20;
                if (result[i] != expected)
                    throw new Exception($"Multi-scalar kernel failed at {i}. Expected {expected}, got {result[i]}");
            }
        }

        private async Task<T[]> ReadBufferAsync<T>(MemoryBuffer buffer) where T : unmanaged
        {
            var iView = (IArrayView)buffer;
            var internalBuffer = iView.Buffer as WebGPUMemoryBuffer;
            if (internalBuffer == null) throw new Exception("Could not get WebGPUMemoryBuffer");
            
            var byteResults = await internalBuffer.NativeBuffer.CopyToHostAsync();
            var result = new T[buffer.Length];
            MemoryMarshal.Cast<byte, T>(byteResults).CopyTo(new Span<T>(result));
            return result;
        }

        [TestMethod]
        public async Task WebGPUKernel3DTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var devices = context.GetWebGPUDevices();
            if (devices.Count == 0) throw new UnsupportedTestException("No WebGPU devices found");
            var device = devices[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            LongIndex3D extent = new LongIndex3D(4, 4, 4);
            using var buffer = accelerator.Allocate3DDenseXY<float>(extent);

            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index3D, ArrayView3D<float, Stride3D.DenseXY>>(Kernel3D);
            kernel((Index3D)extent, buffer.View);

            accelerator.Synchronize();

            var result = await ReadBufferAsync<float>(buffer);

            for (int z = 0; z < extent.Z; z++)
            {
                for (int y = 0; y < extent.Y; y++)
                {
                    for (int x = 0; x < extent.X; x++)
                    {
                        var expected = x + y * 100.0f + z * 1000.0f;
                        var actual = result[z * extent.X * extent.Y + y * extent.X + x];
                        if (Math.Abs(actual - expected) > 0.0001f)
                            throw new Exception($"3D kernel failed at ({x},{y},{z}). Expected {expected}, got {actual}");
                    }
                }
            }
        }

        /// <summary>
        /// A simple 1D kernel. Simple kernels also support other dimensions via Index2 and Index3.
        /// Note that the first argument of a kernel method is always the current index. All other parameters
        /// are optional. Furthermore, kernels can only receive structures as arguments; reference types are
        /// not supported.
        /// 
        /// Memory buffers are accessed via ArrayViews (<see cref="ArrayView{T}"/>, <see cref="ArrayView{T, TIndex}"/>).
        /// These views encapsulate all memory accesses and hide the underlying native pointer operations.
        /// Similar to ArrayViews, a VariableView (<see cref="VariableView{T}"/>) points to a single variable in memory.
        /// In other words, a VariableView is a special ArrayView with a length of 1.
        /// </summary>
        /// <param name="index">The current thread index.</param>
        /// <param name="dataView">The view pointing to our memory buffer.</param>
        /// <param name="constant">A uniform constant.</param>
        static void MyKernel(
            Index1D index,             // The global thread index (1D in this case)
            ArrayView<int> dataView,   // A view to a chunk of memory (1D in this case)
            int constant)              // A sample uniform constant
        {
            dataView[index] = index + constant;
            // dataView[index] = 123;
        }

        static void FloatKernel(
            Index1D index,
            ArrayView<float> dataView,
            float constant)
        {
            dataView[index] = index * 2.0f + constant;
        }

        static void MultiScalarKernel(
            Index1D index,
            ArrayView<int> dataView,
            int c1,
            int c2)
        {
            dataView[index] = index + c1 + c2;
        }

        static void Kernel2D(
            Index2D index,
            ArrayView2D<float, Stride2D.DenseX> dataView)
        {
            dataView[index] = index.X + index.Y * 100.0f;
        }

        struct MyPoint
        {
            public float X;
            public float Y;
        }

        static void StructKernel(Index1D index, ArrayView<MyPoint> data)
        {
            var p = data[index];
            p.X += 1.0f;
            p.Y *= 2.0f;
            data[index] = p;
        }

        static void MathKernel(Index1D index, ArrayView<float> input, ArrayView<float> output)
        {
            float val = input[index];
            // Check Sin, Cos, Sqrt, Abs
            output[index] = MathF.Sin(val) + MathF.Cos(val) + MathF.Sqrt(MathF.Abs(val));
        }

        static void ControlFlowKernel(Index1D index, ArrayView<int> data)
        {
            int val = data[index];
            int ret = 0;
            if (val % 2 == 0)
            {
                for(int i=0; i<5; i++) ret += i; // 0+1+2+3+4 = 10
            }
            else
            {
                ret = -1;
            }
            data[index] = ret;
        }

        [TestMethod]
        public async Task WebGPUStructKernelTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int len = 10;
            var data = new MyPoint[len];
            for (int i = 0; i < len; i++) data[i] = new MyPoint { X = i, Y = i };

            using var buf = accelerator.Allocate1D(data);
            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<MyPoint>>(StructKernel);
            kernel((Index1D)len, buf.View);
            accelerator.Synchronize();

            var result = await ReadBufferAsync<MyPoint>(buf);
            for (int i = 0; i < len; i++)
            {
                if (result[i].X != i + 1.0f || result[i].Y != i * 2.0f)
                    throw new Exception($"Struct kernel failed at {i}. Expected ({i + 1},{i * 2}), got ({result[i].X},{result[i].Y})");
            }
        }

        [TestMethod]
        public async Task WebGPUMathKernelTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int len = 10;
            var input = new float[len];
            for (int i = 0; i < len; i++) input[i] = i - 5;

            using var bufIn = accelerator.Allocate1D(input);
            using var bufOut = accelerator.Allocate1D<float>(len);

            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<float>, ArrayView<float>>(MathKernel);
            kernel((Index1D)len, bufIn.View, bufOut.View);
            accelerator.Synchronize();

            var result = await ReadBufferAsync<float>(bufOut);
            for (int i = 0; i < len; i++)
            {
                float val = input[i];
                float expected = MathF.Sin(val) + MathF.Cos(val) + MathF.Sqrt(MathF.Abs(val));
                if (MathF.Abs(result[i] - expected) > 0.001f)
                    throw new Exception($"Math kernel failed at {i}. Expected {expected}, got {result[i]}");
            }
        }

        [TestMethod]
        public async Task WebGPUControlFlowTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int len = 10;
            var data = new int[len];
            for (int i = 0; i < len; i++) data[i] = i;

            using var buf = accelerator.Allocate1D(data);
            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<int>>(ControlFlowKernel);
            kernel((Index1D)len, buf.View);
            accelerator.Synchronize();

            var result = await ReadBufferAsync<int>(buf);
            for (int i = 0; i < len; i++)
            {
                int expected = (i % 2 == 0) ? 10 : -1;
                if (result[i] != expected)
                    throw new Exception($"Control flow kernel failed at {i}. Expected {expected}, got {result[i]}");
            }
        }

        [TestMethod]
        public async Task WebGPUAtomicKernelTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int len = 64;
            var data = new int[len];
            var atomic = new Index1D[1]; // Accumulator using Index1D (supported by Atomic.Add)
            
            using var bufData = accelerator.Allocate1D(data);
            using var bufAtomic = accelerator.Allocate1D(atomic);

            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<int>, ArrayView<Index1D>>(AtomicKernel);
            kernel((Index1D)len, bufData.View, bufAtomic.View);
            accelerator.Synchronize();

            var resData = await ReadBufferAsync<int>(bufData);
            var resAtomic = await ReadBufferAsync<Index1D>(bufAtomic);

            // Verify Data
            for(int i=0; i<len; i++) if(resData[i] != i+1) throw new Exception("Atomic Kernel: Data Write Failed");

            // Verify Atomic Sum (Sum of 1..64)
            int expectedSum = len * (len + 1) / 2; // n(n+1)/2 => 64*65/2 = 2080
            if (resAtomic[0] != expectedSum)
                throw new Exception($"Atomic Add failed. Expected {expectedSum}, got {resAtomic[0]}");
        }

        static void AtomicKernel(Index1D index, ArrayView<int> data, ArrayView<Index1D> atomicData)
        {
            data[index] = index + 1;
            Atomic.Add(ref atomicData[0], (Index1D)(index + 1));
        }

        static void Kernel3D(Index3D index, ArrayView3D<float, Stride3D.DenseXY> dataView)
        {
            dataView[index] = index.X + index.Y * 100.0f + index.Z * 1000.0f;
        }

        /// <summary>
        /// Vector add kernel for testing.
        /// </summary>
        static void VectorAddKernel(
            Index1D index,
            ArrayView<float> a,
            ArrayView<float> b,
            ArrayView<float> c)
        {
            c[index] = a[index] + b[index];
        }

        [TestMethod]
        public async Task WebGPUILGPUDeviceRegistrationTest()
        {
            // Test that WebGPU devices are properly registered with ILGPU context
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();

            var devices = context.GetWebGPUDevices();
            Console.WriteLine($"Found {devices.Count} WebGPU devices:");
            
            foreach (var device in devices)
            {
                Console.WriteLine($"  - {device.Name}");
                Console.WriteLine($"    AcceleratorType: {device.AcceleratorType}");
                
                if (device.AcceleratorType != AcceleratorType.WebGPU)
                    throw new Exception($"Device has wrong AcceleratorType: {device.AcceleratorType}");
            }
            
            if (devices.Count == 0)
            {
                throw new UnsupportedTestException("No WebGPU devices found");
            }
        }

        [TestMethod]
        public async Task WebGPUAdvancedMathTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int len = 10;
            var input = new float[len];
            for (int i = 0; i < len; i++) input[i] = (i + 1) * 0.5f;

            using var bufIn = accelerator.Allocate1D(input);
            using var bufOut = accelerator.Allocate1D<float>(len);

            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<float>, ArrayView<float>>(AdvancedMathKernel);
            kernel((Index1D)len, bufIn.View, bufOut.View);
            accelerator.Synchronize();

            var result = await ReadBufferAsync<float>(bufOut);
            for (int i = 0; i < len; i++)
            {
                float val = input[i];
                // Tan + Exp + Log + Pow(2) + Min + Max
                float expected = MathF.Tan(val) + MathF.Exp(val) + MathF.Log(MathF.Abs(val) + 1.0f) + MathF.Pow(val, 2.0f) + MathF.Min(val, 2.0f) + MathF.Max(val, 3.0f);
                if (MathF.Abs(result[i] - expected) > 0.01f) // Relaxed tolerance
                    throw new Exception($"Advanced Math failed at {i}. Expected {expected}, got {result[i]}");
            }
        }

        [TestMethod]
        public async Task WebGPUBitwiseTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int len = 10;
            var data = new int[len];
            for (int i = 0; i < len; i++) data[i] = i + 1; // 1..10

            using var buf = accelerator.Allocate1D(data);
            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<int>>(BitwiseKernel);
            kernel((Index1D)len, buf.View);
            accelerator.Synchronize();

            var result = await ReadBufferAsync<int>(buf);
            for (int i = 0; i < len; i++)
            {
                int val = i + 1;
                // (<< 1) + (>> 1) + (& 1) + (| 1) + (^ 1) + (~val)
                // Note: ~val matches C# ~ operator behavior
                int expected = (val << 1) + (val >> 1) + (val & 1) + (val | 1) + (val ^ 1) + (~val);
                if (result[i] != expected)
                    throw new Exception($"Bitwise failed at {i}. Expected {expected}, got {result[i]}");
            }
        }

        static void AdvancedMathKernel(Index1D index, ArrayView<float> input, ArrayView<float> output)
        {
            float val = input[index];
            output[index] = MathF.Tan(val) + MathF.Exp(val) + MathF.Log(MathF.Abs(val) + 1.0f) + MathF.Pow(val, 2.0f) + MathF.Min(val, 2.0f) + MathF.Max(val, 3.0f);
        }

        static void BitwiseKernel(Index1D index, ArrayView<int> data)
        {
            int val = data[index];
            int res = (val << 1) + (val >> 1) + (val & 1) + (val | 1) + (val ^ 1) + (~val);
            data[index] = res;
        }

        [TestMethod]
        public async Task WebGPUConversionTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int len = 10;
            var input = new float[len];
            for (int i = 0; i < len; i++) input[i] = i + 0.5f;

            using var buf = accelerator.Allocate1D(input);
            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<float>>(ConversionKernel);
            kernel((Index1D)len, buf.View);
            accelerator.Synchronize();

            var result = await ReadBufferAsync<float>(buf);
            for (int i = 0; i < len; i++)
            {
                // (int)(i + 0.5f) -> i
                // (float)i -> i.0
                float expected = (float)((int)(i + 0.5f));
                if (result[i] != expected)
                    throw new Exception($"Conversion failed at {i}. Expected {expected}, got {result[i]}");
            }
        }

        [TestMethod]
        public async Task WebGPUSharedMemoryTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int len = 64;
            var data = new int[len];
            for (int i = 0; i < len; i++) data[i] = i;

            using var buf = accelerator.Allocate1D(data);
            var kernel = accelerator.LoadStreamKernel<Index1D, ArrayView<int>>(SharedMemoryKernel);
            kernel(new KernelConfig(len / 64, 64), (Index1D)len, buf.View);
            accelerator.Synchronize();

            var result = await ReadBufferAsync<int>(buf);
            for (int i = 0; i < len; i++)
            {
                // Each thread reads neighbor (i+1)%64
                int expected = (i + 1) % len;
                if (result[i] != expected)
                    throw new Exception($"Shared Memory failed at {i}. Expected {expected}, got {result[i]}");
            }
        }

        [TestMethod]
        public async Task WebGPUNestedControlFlowTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int len = 10;
            var data = new int[len];
            
            using var buf = accelerator.Allocate1D(data);
            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<int>>(NestedControlFlowKernel);
            kernel((Index1D)len, buf.View);
            accelerator.Synchronize();

            var result = await ReadBufferAsync<int>(buf);
            for (int i = 0; i < len; i++)
            {
                // Logic:
                // sum = 0
                // for j in 0..2:
                //   for k in 0..2:
                //     sum += k
                //   if (j == 1) sum += 10
                // Total:
                // j=0: k=0,1,2 -> sum=3
                // j=1: k=0,1,2 -> sum=6 -> 16
                // j=2: k=0,1,2 -> sum=19
                int expected = 19;
                if (result[i] != expected)
                    throw new Exception($"Nested Control Flow failed at {i}. Expected {expected}, got {result[i]}");
            }
        }

        [TestMethod]
        public async Task WebGPUFunctionCallTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int len = 10;
            var data = new int[len];
            
            using var buf = accelerator.Allocate1D(data);
            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<int>>(FunctionCallKernel);
            kernel((Index1D)len, buf.View);
            accelerator.Synchronize();

            var result = await ReadBufferAsync<int>(buf);
            for (int i = 0; i < len; i++)
            {
                // MyAdd(i, 100) -> i + 100
                int expected = i + 100;
                if (result[i] != expected)
                    throw new Exception($"Function Call failed at {i}. Expected {expected}, got {result[i]}");
            }
        }

        static void ConversionKernel(Index1D index, ArrayView<float> data)
        {
            float val = data[index];
            int intVal = (int)val;
            float floatVal = (float)intVal;
            data[index] = floatVal;
        }

        static void SharedMemoryKernel(Index1D index, ArrayView<int> data)
        {
            var shared = SharedMemory.Allocate<int>(64);
            shared[index] = data[index];
            Group.Barrier();
            int neighbor = (index + 1) % 64;
            data[index] = shared[neighbor];
        }

        static void NestedControlFlowKernel(Index1D index, ArrayView<int> data)
        {
            int sum = 0;
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    sum += k;
                }
                if (j == 1) sum += 10;
            }
            data[index] = sum;
        }

        static int MyAdd(int a, int b) { return a + b; }

        static void FunctionCallKernel(Index1D index, ArrayView<int> data)
        {
            data[index] = MyAdd(index, 100);
        }

    }
}
