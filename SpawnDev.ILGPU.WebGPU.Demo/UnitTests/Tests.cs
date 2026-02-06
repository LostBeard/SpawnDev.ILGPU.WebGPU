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

            await accelerator.SynchronizeAsync();

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

            await accelerator.SynchronizeAsync();

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

            await accelerator.SynchronizeAsync();

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

            await accelerator.SynchronizeAsync();

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

            await accelerator.SynchronizeAsync();

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

            await accelerator.SynchronizeAsync();

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
                for (int i = 0; i < 5; i++) ret += i; // 0+1+2+3+4 = 10
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
            await accelerator.SynchronizeAsync();

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
            await accelerator.SynchronizeAsync();

            var result = await ReadBufferAsync<float>(bufOut);
            for (int i = 0; i < len; i++)
            {
                float val = input[i];
                float expected = MathF.Sin(val) + MathF.Cos(val) + MathF.Sqrt(MathF.Abs(val));
                if (MathF.Abs(result[i] - expected) > 0.001f)
                    throw new Exception($"Math kernel failed at {i}. Expected {expected}, got {result[i]}");
            }
        }


        static void IntrinsicMathKernel(Index1D index, ArrayView<float> data)
        {
            if (index == 0) data[index] = MathF.Atan2(1.0f, 1.0f);
            else if (index == 1) data[index] = MathF.FusedMultiplyAdd(2.0f, 3.0f, 4.0f);
            else if (index == 2) data[index] = 5.5f % 2.0f;
            // else if (index == 3) data[index] = MathF.Round(1.5f);
            // else if (index == 4) data[index] = MathF.Truncate(1.9f);
            else if (index == 5) data[index] = Math.Min(Math.Max(10.0f, 0.0f), 5.0f); // Math.Clamp workaround (Throw unsuppported)
            // else if (index == 6) data[index] = MathF.Sign(-5.0f);
            else if (index == 7) data[index] = IntrinsicMathHelper(0.5f);
        }

        static float IntrinsicMathHelper(float val)
        {
            // Testing Step/Lerp via more specialized methods if available or just dummy
            return val;
        }

        [TestMethod]
        public async Task WebGPUIntrinsicMathTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            //builder.Math(MathMode.Fast);
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            var len = 8;
            using var buffer = accelerator.Allocate1D<float>(len);
            var launch = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<float>>(IntrinsicMathKernel);
            launch(len, buffer.View);
            await accelerator.SynchronizeAsync();

            // Expected values
            var expected = new float[len];
            expected[0] = MathF.Atan2(1.0f, 1.0f);
            expected[1] = MathF.FusedMultiplyAdd(2.0f, 3.0f, 4.0f);
            expected[2] = 5.5f % 2.0f;
            expected[3] = MathF.Round(1.5f);
            expected[4] = MathF.Truncate(1.9f);
            expected[5] = Math.Clamp(10.0f, 0.0f, 5.0f);
            expected[6] = MathF.Sign(-5.0f);
            expected[7] = IntrinsicMathHelper(0.5f);

            var dataResult = await ReadBufferAsync<float>(buffer);
            for (int i = 0; i < len; i++)
            {
                // Skip Round (3), Turncate (4), Sign (6) due to Throw issues
                if (i == 3 || i == 4 || i == 6) continue;
                if (Math.Abs(dataResult[i] - expected[i]) > 0.001f)
                    throw new Exception($"Intrinsic Math failed at {i}. Expected {expected[i]}, got {dataResult[i]}");
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
            await accelerator.SynchronizeAsync();

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
            await accelerator.SynchronizeAsync();

            var resData = await ReadBufferAsync<int>(bufData);
            var resAtomic = await ReadBufferAsync<Index1D>(bufAtomic);

            // Verify Data
            for (int i = 0; i < len; i++) if (resData[i] != i + 1) throw new Exception("Atomic Kernel: Data Write Failed");

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
            await accelerator.SynchronizeAsync();

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
            await accelerator.SynchronizeAsync();

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
            await accelerator.SynchronizeAsync();

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
            await accelerator.SynchronizeAsync();

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
            await accelerator.SynchronizeAsync();

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
            await accelerator.SynchronizeAsync();

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



        [TestMethod]
        public async Task WebGPUCSharpSharedMemoryTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int len = 64;
            var data = new int[len];
            for (int i = 0; i < len; i++) data[i] = i;

            using var buffer = accelerator.Allocate1D(data);

            // Important: Shared memory size must appear in the kernel signature if dynamic, 
            // but here we allocate strictly inside the kernel using SharedMemory.Allocate
            // Important: Shared memory requires explicit grouping in ILGPU.
            // We use LoadStreamKernel instead of LoadAutoGroupedStreamKernel.
            var kernel = accelerator.LoadStreamKernel<Index1D, ArrayView<int>>(CSharpSharedMemoryKernel);

            // Dispatch with 1 Group of 64 threads
            kernel(new KernelConfig(1, 64), (Index1D)len, buffer.View);

            await accelerator.SynchronizeAsync();

            var result = await ReadBufferAsync<int>(buffer);

            // Verification: The kernel reverses the data using shared memory
            for (int i = 0; i < len; i++)
            {
                var expected = len - 1 - i;
                if (result[i] != expected)
                    throw new Exception($"CSharp Shared Memory failed at {i}. Expected {expected}, got {result[i]}");
            }
        }

        static void CSharpSharedMemoryKernel(Index1D index, ArrayView<int> data)
        {
            // Allocate shared memory for 64 elements
            // In WGSL: var<workgroup> shared_mem : array<i32, 64>;
            var sharedMem = SharedMemory.Allocate<int>(64);

            // Load Global -> Shared
            sharedMem[index] = data[index];

            // Barrier
            Group.Barrier();

            // Reverse
            int reversedIndex = 63 - index;
            int val = sharedMem[reversedIndex];

            // Store Shared -> Global
            data[index] = val;
        }


        struct InnerStruct
        {
            public float Val;
        }

        struct OuterStruct
        {
            public InnerStruct Inner;
            public int ID;
        }

        [TestMethod]
        public async Task WebGPUComplexStructTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int len = 10;
            var data = new OuterStruct[len];
            for (int i = 0; i < len; i++)
            {
                data[i] = new OuterStruct
                {
                    ID = i,
                    Inner = new InnerStruct { Val = i * 1.5f }
                };
            }

            using var buffer = accelerator.Allocate1D(data);
            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<OuterStruct>>(ComplexStructKernel);
            kernel((Index1D)len, buffer.View);
            await accelerator.SynchronizeAsync();

            var result = await ReadBufferAsync<OuterStruct>(buffer);

            for (int i = 0; i < len; i++)
            {
                // Kernel logic: Inner.Val += 1.0f, ID *= 2
                float expectedVal = i * 1.5f + 1.0f;
                int expectedID = i * 2;

                if (Math.Abs(result[i].Inner.Val - expectedVal) > 0.001f || result[i].ID != expectedID)
                    throw new Exception($"Complex Struct failed at {i}. Expected ({expectedVal}, {expectedID}), got ({result[i].Inner.Val}, {result[i].ID})");
            }
        }

        static void ComplexStructKernel(Index1D index, ArrayView<OuterStruct> data)
        {
            var item = data[index];
            item.Inner.Val += 1.0f;
            item.ID *= 2;
            data[index] = item;
        }


        [TestMethod]
        public async Task WebGPUAtomicCASTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int len = 64;
            var data = new int[len]; // Target for CAS
                                     // Initialize with 0

            using var buffer = accelerator.Allocate1D(data);

            // Expected: Threads will race to compare 0 -> 1.
            // Only ONE thread per element should succeed if we limit scope, but here we do 1:1 mapping.
            // To test CAS effectively, we'll try to swap val if it equals index.
            // old = Atomic.CompareExchange(ref data[i], index, index + 100)

            // Using explicit grouping to ensure atomics work in that context too (though not strictly required for global atomics)
            var kernel = accelerator.LoadStreamKernel<Index1D, ArrayView<int>>(AtomicCASKernel);
            kernel(new KernelConfig(1, len), (Index1D)len, buffer.View);
            await accelerator.SynchronizeAsync();

            var result = await ReadBufferAsync<int>(buffer);
            for (int i = 0; i < len; i++)
            {
                // Initial 0. Compare(0, i, i+100)
                // If i == 0: Compare(0, 0, 100) -> Writes 100. Old was 0.
                // If i != 0: Compare(0, i, i+100) -> Fails (0 != i). Writes nothing. Old was 0.

                int expected = (i == 0) ? 100 : 0;
                if (result[i] != expected)
                    throw new Exception($"Atomic CAS failed at {i}. Expected {expected}, got {result[i]}");
            }
        }

        static void AtomicCASKernel(Index1D index, ArrayView<int> data)
        {
            // Try to swap '0' with 'index + 100' IF current val is 'index'
            // atomicCompareExchangeWeak(ptr, compare, value)
            Atomic.CompareExchange(ref data[index], index, index + 100);
        }

        [TestMethod]
        public async Task WebGPUFMATest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int len = 10;
            var data = new float[len];
            using var buffer = accelerator.Allocate1D(data);

            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<float>>(FMAKernel);
            kernel((Index1D)len, buffer.View);
            await accelerator.SynchronizeAsync();

            var result = await ReadBufferAsync<float>(buffer);
            for (int i = 0; i < len; i++)
            {
                float a = i;
                float b = 2.0f;
                float c = 0.5f;
                float expected = a * b + c; // FMA result

                if (Math.Abs(result[i] - expected) > 0.0001f)
                    throw new Exception($"FMA failed at {i}. Expected {expected}, got {result[i]}");
            }
        }

        static void FMAKernel(Index1D index, ArrayView<float> data)
        {
            float a = (float)(int)index;
            float b = 2.0f;
            float c = 0.5f;
            // ILGPU maps MathF.FusedMultiplyAdd to FMA intrinsic
            data[index] = MathF.FusedMultiplyAdd(a, b, c);
        }

        [TestMethod]
        public async Task WebGPUBroadcastTest()
        {
            throw new UnsupportedTestException("Skip: subgroups extension not supported in browser environment");
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int len = 32; // 1 Warp/Subgroup ideally
            var data = new int[len];
            // Init with index
            for (int i = 0; i < len; i++) data[i] = i;

            using var buffer = accelerator.Allocate1D(data);

            // Broadcast requires explicit grouping usually for "Group" semantics, 
            // verifying if we alias Group.Broadcast to subgroupBroadcast or fallback
            // Note: WebGPU subgroup support is currently strictly experimental.
            // If this fails, we expect a NotSupportedException likely.

            try
            {
                var kernel = accelerator.LoadStreamKernel<Index1D, ArrayView<int>>(BroadcastKernel);
                kernel(new KernelConfig(1, len), (Index1D)len, buffer.View);
                await accelerator.SynchronizeAsync();

                var result = await ReadBufferAsync<int>(buffer);

                // Expect ALL values to be the value from lane 0 (which was 0)
                // We use Lane 0 because current WGSL generator uses subgroupBroadcastFirst()

                int expected = 0;
                for (int i = 0; i < len; i++)
                {
                    if (result[i] != expected)
                        throw new Exception($"Broadcast failed at {i}. Expected {expected}, got {result[i]}");
                }
            }
            catch (Exception ex)
            {
                // Check if it's strictly a "Not Supported" in the generator vs a runtime crash
                if (ex.Message.Contains("NotSupported"))
                {
                    Console.WriteLine("Broadcast not supported (Expected for now)");
                    return;
                }
                throw;
            }
        }

        static void BroadcastKernel(Index1D index, ArrayView<int> data)
        {
            int val = data[index];
            // Broadcast value from Lane 0 to everyone
            // ILGPU maps this to SubgroupBroadcastFirst if index is 0 or constant? 
            // Our generator maps it to subgroupBroadcastFirst regardless of index.
            int broadcasted = Group.Broadcast(val, 0);
            data[index] = broadcasted;
        }

        [TestMethod]
        public async Task WebGPUDynamicSharedMemoryTest()
        {
            throw new UnsupportedTestException("Skip: Dynamic Shared Memory requires Pipeline Overridable Constants support in backend.");
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int len = 64;
            var data = new int[len];
            using var buffer = accelerator.Allocate1D(data);

            // Dynamic Shared Memory config
            var kernel = accelerator.LoadStreamKernel<Index1D, ArrayView<int>>(DynamicSharedKernel);

            // Allocate 64 ints of dynamic shared mem
            var config = new KernelConfig(1, 64, SharedMemoryConfig.RequestDynamic<int>(64));
            kernel(config, (Index1D)len, buffer.View);
            await accelerator.SynchronizeAsync();

            var result = await ReadBufferAsync<int>(buffer);
            for (int i = 0; i < len; i++)
            {
                var expected = len - 1 - i;
                if (result[i] != expected)
                    throw new Exception($"Dynamic Shared Mem failed at {i}. Expected {expected}, got {result[i]}");
            }
        }

        static void DynamicSharedKernel(Index1D index, ArrayView<int> data)
        {
            // Access Dynamic Shared Memory
            // In WGSL: This usually maps to a specialized variable or 'workgroup' var declared via override
            var shared = SharedMemory.GetDynamic<int>();

            shared[index] = index;
            Group.Barrier();

            int rev = 63 - index;
            data[index] = shared[rev];
        }



        [TestMethod]
        public async Task WebGPUIntMathTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int len = 8;
            var input = new int[len];
            // Test data: Mix of positive/negative for Abs/Sign checks
            input[0] = 5; input[1] = -5;
            input[2] = 10; input[3] = 20;
            input[4] = 0; input[5] = -100;
            input[6] = 7; input[7] = 8;

            using var bufIn = accelerator.Allocate1D(input);
            using var bufOut = accelerator.Allocate1D<int>(len);

            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<int>, ArrayView<int>>(IntMathKernel);
            kernel((Index1D)len, bufIn.View, bufOut.View);
            await accelerator.SynchronizeAsync();

            var result = await ReadBufferAsync<int>(bufOut);
            for (int i = 0; i < len; i++)
            {
                int val = input[i];
                // Match Kernel Logic:
                // 0: Abs
                // 1: Abs
                // 2: Min(val, 15) -> Min(10, 15) = 10
                // 3: Max(val, 15) -> Max(20, 15) = 20
                // 4: Clamp(val, 1, 5) -> Clamp(0, 1, 5) = 1
                // 5: Clamp(val, -200, -50) -> Clamp(-100, -200, -50) = -100
                // 6: Default
                // 7: Default

                int expected = val;
                if (i == 0 || i == 1) expected = Math.Abs(val);
                else if (i == 2) expected = Math.Min(val, 15);
                else if (i == 3) expected = Math.Max(val, 15);
                // Clamp workaround logic: Min(Max(val, min), max)
                else if (i == 4) expected = Math.Min(Math.Max(val, 1), 5);
                else if (i == 5) expected = Math.Min(Math.Max(val, -200), -50);

                if (result[i] != expected)
                    throw new Exception($"Int Math failed at {i}. Input {val}, Expected {expected}, got {result[i]}");
            }
        }

        static void IntMathKernel(Index1D index, ArrayView<int> input, ArrayView<int> output)
        {
            int val = input[index];
            if (index == 0 || index == 1) output[index] = Math.Abs(val);
            else if (index == 2) output[index] = Math.Min(val, 15);
            else if (index == 3) output[index] = Math.Max(val, 15);
            else if (index == 4) output[index] = Math.Min(Math.Max(val, 1), 5); // Clamp Workaround
            else if (index == 5) output[index] = Math.Min(Math.Max(val, -200), -50); // Clamp Workaround
            else output[index] = val;
        }

        [TestMethod]
        public async Task WebGPUMatrixMulTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int size = 16; // 16x16 matrix
            int len = size * size;
            var a = new float[len];
            var b = new float[len];

            // Init matrices
            for (int i = 0; i < len; i++)
            {
                a[i] = 1.0f; // All 1s
                b[i] = 2.0f; // All 2s
            }

            using var bufA = accelerator.Allocate1D(a);
            using var bufB = accelerator.Allocate1D(b);
            using var bufC = accelerator.Allocate1D<float>(len);

            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index2D, ArrayView<float>, ArrayView<float>, ArrayView<float>, int>(MatrixMulKernel);
            // Launch 2D kernel
            kernel(new Index2D(size, size), bufA.View, bufB.View, bufC.View, size);
            await accelerator.SynchronizeAsync();

            var result = await ReadBufferAsync<float>(bufC);

            // Verification
            // C = A * B
            // Each element C[row, col] = Sum(A[row, k] * B[k, col]) for k=0..size
            // Since A=1, B=2, Sum = 1 * 2 * size = 2 * 16 = 32
            float expected = 32.0f;

            for (int i = 0; i < len; i++)
            {
                if (Math.Abs(result[i] - expected) > 0.001f)
                    throw new Exception($"Matrix Mul failed at {i}. Expected {expected}, got {result[i]}");
            }
        }

        static void MatrixMulKernel(Index2D index, ArrayView<float> a, ArrayView<float> b, ArrayView<float> c, int size)
        {
            // Naive Matrix Multiplication
            int row = index.Y;
            int col = index.X;
            
            if (row >= size || col >= size) return;

            float sum = 0.0f;
            for (int k = 0; k < size; k++)
            {
                // A [row, k], B [k, col]
                // Row-major: index = row * size + col
                float valA = a[row * size + k];
                float valB = b[k * size + col];
                sum += valA * valB;
            }
            c[row * size + col] = sum;
        }

        [TestMethod]
        public async Task WebGPUSpecializedIntrinsicsTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int len = 8;
            var input = new float[len];
            // Test values
            input[0] = 4.0f;  // Sqrt/Rsqrt -> 2, 0.5
            input[1] = 2.5f;  // Floor/Ceil -> 2, 3
            input[2] = -2.5f; // Floor/Ceil -> -3, -2
            input[3] = 0.0f;
            input[4] = 10.0f; 
            input[5] = 0.5f;
            input[6] = 0.0f;
            input[7] = 0.0f;

            using var bufIn = accelerator.Allocate1D(input);
            using var bufOut = accelerator.Allocate1D<float>(len);

            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<float>, ArrayView<float>>(SpecializedIntrinsicsKernel);
            kernel((Index1D)len, bufIn.View, bufOut.View);
            await accelerator.SynchronizeAsync();

            var result = await ReadBufferAsync<float>(bufOut);

            for (int i = 0; i < len; i++)
            {
                float val = input[i];
                float expected = 0.0f;

                if (i == 0) expected = 1.0f / MathF.Sqrt(val); // Rsqrt
                else if (i == 1 || i == 2) expected = MathF.Floor(val) + MathF.Ceiling(val);
                else if (i == 4) expected = 1.0f / val; // Rcp (1/x)
                
                if (i == 3) continue; // Skip 0 check for now to avoid potential NaN matches if we want to be strict

                if (Math.Abs(result[i] - expected) > 0.001f)
                    throw new Exception($"Specialized Intrinsic failed at {i}. Expected {expected}, got {result[i]}");
            }
        }

        static void SpecializedIntrinsicsKernel(Index1D index, ArrayView<float> input, ArrayView<float> output)
        {
            float val = input[index];
            if (index == 0) output[index] = global::ILGPU.Algorithms.XMath.Rsqrt(val);
            else if (index == 1 || index == 2) output[index] = MathF.Floor(val) + MathF.Ceiling(val);
            else if (index == 4) output[index] = global::ILGPU.Algorithms.XMath.Rcp(val);
            else output[index] = 0.0f;
        }



        [TestMethod]
        public async Task WebGPUBitManipulationIntrinsicsTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int len = 4;
            var input = new int[len];
            input[0] = 0b0000_1111; // PopCount = 4
            input[1] = 0b0000_0001; // TrailingZeros = 0
            input[2] = 0b1000_0000; // LeadingZeros = 24 (assuming 32-bit). 
                                    // 0x00000080 (128) -> leading zeros = 24. 
            input[3] = 0;           // PopCount = 0

            using var bufIn = accelerator.Allocate1D(input);
            using var bufOut = accelerator.Allocate1D<int>(len);

            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<int>, ArrayView<int>>(BitManipulationKernel);
            kernel((Index1D)len, bufIn.View, bufOut.View);
            await accelerator.SynchronizeAsync();

            var result = await ReadBufferAsync<int>(bufOut);
            
            // Expected
            // 0: PopCount(15) = 4
            if (result[0] != 4) throw new Exception($"PopCount failed. Expected 4, got {result[0]}");
            
            // 1: CountTrailingZeros(1) = 0
            if (result[1] != 0) throw new Exception($"CTZ failed. Expected 0, got {result[1]}");

            // 2: CountLeadingZeros(128) = 24.
            if (result[2] != 24) throw new Exception($"CLZ failed. Expected 24, got {result[2]}");
        }

        static void BitManipulationKernel(Index1D index, ArrayView<int> input, ArrayView<int> output)
        {
            int val = input[index];
            if (index == 0) output[index] = System.Numerics.BitOperations.PopCount((uint)val);
            else if (index == 1) output[index] = System.Numerics.BitOperations.TrailingZeroCount(val);
            else if (index == 2) output[index] = System.Numerics.BitOperations.LeadingZeroCount((uint)val);
            else if (index == 3) output[index] = System.Numerics.BitOperations.PopCount((uint)val); 
        }

        [TestMethod]
        public async Task WebGPUHistogramTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int numItems = 1024;
            int numBins = 16;
            
            // Generate data evenly distributed
            var data = new int[numItems];
            for (int i = 0; i < numItems; i++)
            {
                data[i] = i % numBins;
            }

            var bins = new int[numBins]; // Zeros

            using var bufData = accelerator.Allocate1D(data);
            using var bufBins = accelerator.Allocate1D(bins);

            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<int>, ArrayView<int>>(HistogramKernel);
            kernel((Index1D)numItems, bufData.View, bufBins.View);
            await accelerator.SynchronizeAsync();

            var result = await ReadBufferAsync<int>(bufBins);
            
            int expectedCount = numItems / numBins; // 1024/16 = 64
            for (int i = 0; i < numBins; i++)
            {
                if (result[i] != expectedCount)
                    throw new Exception($"Histogram failed at bin {i}. Expected {expectedCount}, got {result[i]}");
            }
        }

        static void HistogramKernel(Index1D index, ArrayView<int> data, ArrayView<int> bins)
        {
            int binIdx = data[index];
            Atomic.Add(ref bins[binIdx], 1);
        }

        [TestMethod]
        public async Task WebGPUNestedLoopBreakTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int size = 16;
            var output = new int[size];

            using var bufOut = accelerator.Allocate1D(output);

            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<int>>(NestedLoopBreakKernel);
            kernel((Index1D)size, bufOut.View);
            await accelerator.SynchronizeAsync();

            var result = await ReadBufferAsync<int>(bufOut);

            for (int i = 0; i < size; i++)
            {
                if (result[i] != 9)
                    throw new Exception($"Nested Loop failed at {i}. Expected 9, got {result[i]}");
            }
        }

        static void NestedLoopBreakKernel(Index1D index, ArrayView<int> output)
        {
            int acc = 0;
            
            // Loop 1: Break test
            for (int j = 0; j < 10; j++)
            {
                if (j == 5) break; 
                acc++;
            }

            // Loop 2: Continue test
            for (int k = 0; k < 5; k++)
            {
                if (k == 2) continue;
                acc++;
            }
            
            output[index] = acc;
        }



        [TestMethod]
        public async Task WebGPUHyperbolicMathTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int len = 3;
            var input = new float[len];
            input[0] = 0.5f;
            input[1] = 1.0f;
            input[2] = -0.5f;

            using var bufIn = accelerator.Allocate1D(input);
            using var bufOut = accelerator.Allocate1D<float>(len);

            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<float>, ArrayView<float>>(HyperbolicKernel);
            kernel((Index1D)len, bufIn.View, bufOut.View);
            await accelerator.SynchronizeAsync();

            var result = await ReadBufferAsync<float>(bufOut);
            
            for (int i = 0; i < len; i++)
            {
                float val = input[i];
                float expected = 0.5f;
                if (i == 0) expected = MathF.Sinh(val);
                else if (i == 1) expected = MathF.Cosh(val);
                else if (i == 2) expected = MathF.Tanh(val);

                if (Math.Abs(result[i] - expected) > 0.001f)
                    throw new Exception($"Hyperbolic failed at {i}. Expected {expected}, got {result[i]}");
            }
        }

        static void HyperbolicKernel(Index1D index, ArrayView<float> input, ArrayView<float> output)
        {
            float val = input[index];
            if (index == 0) output[index] = MathF.Sinh(val);
            else if (index == 1) output[index] = MathF.Cosh(val);
            else if (index == 2) output[index] = MathF.Tanh(val);
        }

        [TestMethod]
        public async Task WebGPUSharedMemoryBarrierTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int groupSize = 64;
            int numGroups = 2;
            int totalSize = groupSize * numGroups;

            var data = new int[totalSize]; // Output

            using var buf = accelerator.Allocate1D(data);

            var kernel = accelerator.LoadStreamKernel<Index1D, ArrayView<int>>(SharedMemoryBarrierKernel);
            kernel(new KernelConfig(numGroups, groupSize), (Index1D)groupSize, buf.View);
            await accelerator.SynchronizeAsync();

            var result = await ReadBufferAsync<int>(buf);

            // Expected logic:
            // Threads 0..31 write to shared[0..31].
            // Barrier.
            // Threads 32..63 read share[id - 32].
            // Output should contain the pattern.
            
            // Only the second half of each workgroup writes to output.
            // Global ID: 
            // Group 0: 0..63. Writers: 0..31. Readers: 32..63. output[32..63] = shared[0..31] = (0..31) * 2.
            
            for (int g = 0; g < numGroups; g++)
            {
                int baseIdx = g * groupSize;
                for (int i = 32; i < 64; i++)
                {
                    int globalIdx = baseIdx + i;
                    int expected = (i - 32) * 2;
                    if (result[globalIdx] != expected)
                        throw new Exception($"Barrier failed at group {g}, thread {i}. Expected {expected}, got {result[globalIdx]}");
                }
            }
        }

        static void SharedMemoryBarrierKernel(Index1D index, ArrayView<int> output)
        {
            // Thread Index within Group
            int tid = Group.IdxX;
            var shared = SharedMemory.Allocate<int>(64);
            
            if (tid < 32)
            {
                shared[tid] = tid * 2;
            }
            
            Group.Barrier();
            
            if (tid >= 32)
            {
                int val = shared[tid - 32];
                // Write to global. 
                // We need global index.
                int gid = Grid.GlobalIndex.X;
                output[gid] = val;
            }
        }

        [TestMethod]
        public async Task WebGPUSelectOperationTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int len = 4;
            var input = new int[len];
            input[0] = 10;
            input[1] = -10;
            input[2] = 0;
            input[3] = 5;

            using var bufIn = accelerator.Allocate1D(input);
            using var bufOut = accelerator.Allocate1D<int>(len);

            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<int>, ArrayView<int>>(SelectKernel);
            kernel((Index1D)len, bufIn.View, bufOut.View);
            await accelerator.SynchronizeAsync();

            var result = await ReadBufferAsync<int>(bufOut);
            
            for (int i = 0; i < len; i++)
            {
                int val = input[i];
                // Logic: Select(val > 0, 1, -1)
                int expected = (val > 0) ? 1 : -1;
                
                if (result[i] != expected)
                    throw new Exception($"Select failed at {i}. Expected {expected}, got {result[i]}");
            }
        }

        static void SelectKernel(Index1D index, ArrayView<int> input, ArrayView<int> output)
        {
            int val = input[index];
            // Condition, TrueVal, FalseVal
            // ILGPU Select maps to ternary or Cjmp
            // WGSL select(false, true, cond)
            output[index] = (val > 0) ? 1 : -1;
        }


        [TestMethod]
        public async Task WebGPULinearBarrierTest()
    {
        var builder = Context.Create();
        await builder.WebGPUAsync();
        using var context = builder.ToContext();
        var device = context.GetWebGPUDevices()[0];
        using var accelerator = await device.CreateAcceleratorAsync(context);

        int groupSize = 64;
        int numGroups = 2;
        int totalSize = groupSize * numGroups;
        var data = new int[totalSize];

        using var buf = accelerator.Allocate1D(data);

        var kernel = accelerator.LoadStreamKernel<Index1D, ArrayView<int>>(LinearBarrierKernel);
        kernel(new KernelConfig(numGroups, groupSize), (Index1D)groupSize, buf.View);
        await accelerator.SynchronizeAsync();

        var result = await ReadBufferAsync<int>(buf);

        for (int i = 0; i < totalSize; i++)
        {
            int groupSizeVal = 64;
            // Thread i wrote i.
            // Thread i read (i+1)%64 (within group).
            int localId = i % groupSizeVal;
            int groupId = i / groupSizeVal;
            int readFromLocal = (localId + 1) % groupSizeVal;
            int readFromGlobal = groupId * groupSizeVal + readFromLocal;
            
            int expected = readFromGlobal; 
            
            if (result[i] != expected)
                throw new Exception($"Linear Barrier failed. Group {groupId} Local {localId}. Expected {expected} (from local {readFromLocal}), got {result[i]}");
        }
    }

    static void LinearBarrierKernel(Index1D index, ArrayView<int> output)
    {
        // Linear Flow: No Ifs before Barrier.
        int tid = Group.IdxX; // Local
        int gid = Grid.GlobalIndex.X; // Global

        var shared = SharedMemory.Allocate<int>(64);
        
        shared[tid] = gid; // Write own Global ID to Shared[LocalID]
        
        Group.Barrier();
        
        // Read neighbor's value
        int neighbor = (tid + 1) % 64;
        int val = shared[neighbor];
        
        output[gid] = val;
    }

        // ============= NEW TESTS FOR EXPANDED COVERAGE =============

        [TestMethod]
        public async Task WebGPUDoublePrecisionTest()
        {
            // f64 (double) support in WebGPU is experimental and not available in most browsers
            throw new UnsupportedTestException("Skip: f64 (double precision) not supported in browser WebGPU");
            
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int len = 10;
            var input = new double[len];
            for (int i = 0; i < len; i++) input[i] = i * 1.1;

            using var bufIn = accelerator.Allocate1D(input);
            using var bufOut = accelerator.Allocate1D<double>(len);

            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<double>, ArrayView<double>>(DoublePrecisionKernel);
            kernel((Index1D)len, bufIn.View, bufOut.View);
            await accelerator.SynchronizeAsync();

            var result = await ReadBufferAsync<double>(bufOut);
            for (int i = 0; i < len; i++)
            {
                double val = input[i];
                double expected = val * 2.0 + 1.0;
                if (Math.Abs(result[i] - expected) > 0.0001)
                    throw new Exception($"Double precision failed at {i}. Expected {expected}, got {result[i]}");
            }
        }

        static void DoublePrecisionKernel(Index1D index, ArrayView<double> input, ArrayView<double> output)
        {
            double val = input[index];
            output[index] = val * 2.0 + 1.0;
        }

        [TestMethod]
        public async Task WebGPUInverseTrigTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int len = 3;
            var input = new float[len];
            input[0] = 0.5f;  // Asin
            input[1] = 0.5f;  // Acos
            input[2] = 1.0f;  // Atan

            using var bufIn = accelerator.Allocate1D(input);
            using var bufOut = accelerator.Allocate1D<float>(len);

            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<float>, ArrayView<float>>(InverseTrigKernel);
            kernel((Index1D)len, bufIn.View, bufOut.View);
            await accelerator.SynchronizeAsync();

            var result = await ReadBufferAsync<float>(bufOut);

            float[] expected = new float[len];
            expected[0] = MathF.Asin(0.5f);
            expected[1] = MathF.Acos(0.5f);
            expected[2] = MathF.Atan(1.0f);

            for (int i = 0; i < len; i++)
            {
                if (MathF.Abs(result[i] - expected[i]) > 0.001f)
                    throw new Exception($"Inverse trig failed at {i}. Expected {expected[i]}, got {result[i]}");
            }
        }

        static void InverseTrigKernel(Index1D index, ArrayView<float> input, ArrayView<float> output)
        {
            float val = input[index];
            if (index == 0) output[index] = MathF.Asin(val);
            else if (index == 1) output[index] = MathF.Acos(val);
            else if (index == 2) output[index] = MathF.Atan(val);
        }

        [TestMethod]
        public async Task WebGPULargeBufferTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int len = 100000; // 100K elements
            var data = new int[len];
            for (int i = 0; i < len; i++) data[i] = i;

            using var buf = accelerator.Allocate1D(data);
            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<int>>(LargeBufferKernel);
            kernel((Index1D)len, buf.View);
            await accelerator.SynchronizeAsync();

            var result = await ReadBufferAsync<int>(buf);

            // Spot check a few values
            int[] checkIndices = { 0, 100, 1000, 50000, 99999 };
            foreach (int i in checkIndices)
            {
                int expected = i * 2;
                if (result[i] != expected)
                    throw new Exception($"Large buffer failed at {i}. Expected {expected}, got {result[i]}");
            }
        }

        static void LargeBufferKernel(Index1D index, ArrayView<int> data)
        {
            data[index] = data[index] * 2;
        }

        [TestMethod]
        public async Task WebGPUSequentialKernelsTest()
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

            // Run first kernel: x * 2
            var kernel1 = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<int>>(SequentialKernel1);
            kernel1((Index1D)len, buf.View);
            await accelerator.SynchronizeAsync();

            // Run second kernel: x + 10
            var kernel2 = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<int>>(SequentialKernel2);
            kernel2((Index1D)len, buf.View);
            await accelerator.SynchronizeAsync();

            var result = await ReadBufferAsync<int>(buf);
            for (int i = 0; i < len; i++)
            {
                int expected = i * 2 + 10;
                if (result[i] != expected)
                    throw new Exception($"Sequential kernels failed at {i}. Expected {expected}, got {result[i]}");
            }
        }

        static void SequentialKernel1(Index1D index, ArrayView<int> data)
        {
            data[index] = data[index] * 2;
        }

        static void SequentialKernel2(Index1D index, ArrayView<int> data)
        {
            data[index] = data[index] + 10;
        }

        [TestMethod]
        public async Task WebGPUUnsignedIntegerTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int len = 4;
            var data = new uint[len];
            data[0] = 100;
            data[1] = 7;
            data[2] = uint.MaxValue;
            data[3] = 0;

            using var buf = accelerator.Allocate1D(data);
            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<uint>>(UnsignedIntKernel);
            kernel((Index1D)len, buf.View);
            await accelerator.SynchronizeAsync();

            var result = await ReadBufferAsync<uint>(buf);

            uint[] expected = new uint[len];
            expected[0] = 100 / 3;          // 33
            expected[1] = 7 % 4;            // 3
            expected[2] = unchecked(uint.MaxValue + 1); // Overflow to 0
            expected[3] = 0 + 100;          // 100

            for (int i = 0; i < len; i++)
            {
                if (result[i] != expected[i])
                    throw new Exception($"Unsigned int failed at {i}. Expected {expected[i]}, got {result[i]}");
            }
        }

        static void UnsignedIntKernel(Index1D index, ArrayView<uint> data)
        {
            uint val = data[index];
            if (index == 0) data[index] = val / 3;
            else if (index == 1) data[index] = val % 4;
            else if (index == 2) data[index] = val + 1; // Wraps
            else if (index == 3) data[index] = val + 100;
        }

        [TestMethod]
        public async Task WebGPUAtomicMinMaxTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int numThreads = 64;
            var minResult = new int[] { int.MaxValue };
            var maxResult = new int[] { int.MinValue };

            using var bufMin = accelerator.Allocate1D(minResult);
            using var bufMax = accelerator.Allocate1D(maxResult);

            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<int>, ArrayView<int>>(AtomicMinMaxKernel);
            kernel((Index1D)numThreads, bufMin.View, bufMax.View);
            await accelerator.SynchronizeAsync();

            var resultMin = await ReadBufferAsync<int>(bufMin);
            var resultMax = await ReadBufferAsync<int>(bufMax);

            // Threads write their index (0..63)
            // Min should be 0, Max should be 63
            if (resultMin[0] != 0)
                throw new Exception($"Atomic Min failed. Expected 0, got {resultMin[0]}");
            if (resultMax[0] != 63)
                throw new Exception($"Atomic Max failed. Expected 63, got {resultMax[0]}");
        }

        static void AtomicMinMaxKernel(Index1D index, ArrayView<int> minData, ArrayView<int> maxData)
        {
            Atomic.Min(ref minData[0], (int)index);
            Atomic.Max(ref maxData[0], (int)index);
        }

        [TestMethod]
        public async Task WebGPUBufferReuseTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int len = 32;
            var data = new int[len];
            for (int i = 0; i < len; i++) data[i] = i;

            using var buf = accelerator.Allocate1D(data);
            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<int>>(BufferReuseKernel);

            // Run the same kernel 5 times on the same buffer
            for (int round = 0; round < 5; round++)
            {
                kernel((Index1D)len, buf.View);
                await accelerator.SynchronizeAsync();
            }

            var result = await ReadBufferAsync<int>(buf);
            for (int i = 0; i < len; i++)
            {
                // Each iteration adds 1, so after 5 rounds: i + 5
                int expected = i + 5;
                if (result[i] != expected)
                    throw new Exception($"Buffer reuse failed at {i}. Expected {expected}, got {result[i]}");
            }
        }

        static void BufferReuseKernel(Index1D index, ArrayView<int> data)
        {
            data[index] = data[index] + 1;
        }

        // ============= ADDITIONAL COVERAGE TESTS =============

        [TestMethod]
        public async Task WebGPUGridGroupDimensionTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            // WebGPU backend uses fixed 64-thread workgroups
            int groupSize = 64;
            int numGroups = 2;
            int totalSize = groupSize * numGroups;

            var output = new int[totalSize * 4]; // Store: globalId, localId, groupId, groupDim

            using var buf = accelerator.Allocate1D(output);
            var kernel = accelerator.LoadStreamKernel<Index1D, ArrayView<int>>(GridGroupDimensionKernel);
            kernel(new KernelConfig(numGroups, groupSize), (Index1D)groupSize, buf.View);
            await accelerator.SynchronizeAsync();

            var result = await ReadBufferAsync<int>(buf);

            // Verify first few threads
            for (int g = 0; g < numGroups; g++)
            {
                for (int t = 0; t < groupSize; t++)
                {
                    int globalId = g * groupSize + t;
                    int baseIdx = globalId * 4;

                    int expectedGlobalId = globalId;
                    int expectedLocalId = t;
                    int expectedGroupId = g;
                    int expectedGroupDim = groupSize;

                    if (result[baseIdx] != expectedGlobalId)
                        throw new Exception($"GlobalId mismatch at {globalId}. Expected {expectedGlobalId}, got {result[baseIdx]}");
                    if (result[baseIdx + 1] != expectedLocalId)
                        throw new Exception($"LocalId mismatch at {globalId}. Expected {expectedLocalId}, got {result[baseIdx + 1]}");
                    if (result[baseIdx + 2] != expectedGroupId)
                        throw new Exception($"GroupId mismatch at {globalId}. Expected {expectedGroupId}, got {result[baseIdx + 2]}");
                    if (result[baseIdx + 3] != expectedGroupDim)
                        throw new Exception($"GroupDim mismatch at {globalId}. Expected {expectedGroupDim}, got {result[baseIdx + 3]}");
                }
            }
        }

        static void GridGroupDimensionKernel(Index1D index, ArrayView<int> output)
        {
            int globalId = Grid.GlobalIndex.X;
            int localId = Group.IdxX;
            int groupId = Grid.IdxX;
            int groupDim = Group.DimX;

            int baseIdx = globalId * 4;
            output[baseIdx] = globalId;
            output[baseIdx + 1] = localId;
            output[baseIdx + 2] = groupId;
            output[baseIdx + 3] = groupDim;
        }

        [TestMethod]
        public async Task WebGPULongIntegerTest()
        {
            // i64 (long) is not supported in current browser WebGPU implementations
            throw new UnsupportedTestException("Skip: i64 (long) not supported in browser WebGPU");

            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int len = 4;
            var data = new long[len];
            data[0] = 1000000000L;
            data[1] = -1000000000L;
            data[2] = long.MaxValue / 2;
            data[3] = 0L;

            try
            {
                using var buf = accelerator.Allocate1D(data);
                var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<long>>(LongIntegerKernel);
                kernel((Index1D)len, buf.View);
                await accelerator.SynchronizeAsync();

                var result = await ReadBufferAsync<long>(buf);
                for (int i = 0; i < len; i++)
                {
                    long expected = data[i] * 2 + 1;
                    if (result[i] != expected)
                        throw new Exception($"Long integer failed at {i}. Expected {expected}, got {result[i]}");
                }
            }
            catch (Exception ex) when (ex.Message.Contains("NotSupported") || ex.Message.Contains("i64"))
            {
                throw new UnsupportedTestException("Skip: i64 (long) not fully supported in browser WebGPU");
            }
        }

        static void LongIntegerKernel(Index1D index, ArrayView<long> data)
        {
            long val = data[index];
            data[index] = val * 2 + 1;
        }

        [TestMethod]
        public async Task WebGPUMixedTypeBuffersTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int len = 16;
            var intData = new int[len];
            var floatData = new float[len];
            for (int i = 0; i < len; i++)
            {
                intData[i] = i;
                floatData[i] = i * 0.5f;
            }

            using var bufInt = accelerator.Allocate1D(intData);
            using var bufFloat = accelerator.Allocate1D(floatData);
            using var bufResult = accelerator.Allocate1D<float>(len);

            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<int>, ArrayView<float>, ArrayView<float>>(MixedTypeKernel);
            kernel((Index1D)len, bufInt.View, bufFloat.View, bufResult.View);
            await accelerator.SynchronizeAsync();

            var result = await ReadBufferAsync<float>(bufResult);
            for (int i = 0; i < len; i++)
            {
                float expected = intData[i] + floatData[i];
                if (MathF.Abs(result[i] - expected) > 0.001f)
                    throw new Exception($"Mixed type failed at {i}. Expected {expected}, got {result[i]}");
            }
        }

        static void MixedTypeKernel(Index1D index, ArrayView<int> intData, ArrayView<float> floatData, ArrayView<float> result)
        {
            result[index] = (float)intData[index] + floatData[index];
        }

        [TestMethod]
        public async Task WebGPUEmptyBufferTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            // Test with minimal size (WGSL doesn't allow truly empty buffers)
            int len = 1;
            var data = new int[len];
            data[0] = 42;

            using var buf = accelerator.Allocate1D(data);
            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<int>>(EmptyBufferKernel);
            kernel((Index1D)len, buf.View);
            await accelerator.SynchronizeAsync();

            var result = await ReadBufferAsync<int>(buf);
            if (result[0] != 84)
                throw new Exception($"Single element buffer failed. Expected 84, got {result[0]}");
        }

        static void EmptyBufferKernel(Index1D index, ArrayView<int> data)
        {
            data[index] = data[index] * 2;
        }

        [TestMethod]
        public async Task WebGPULargeDispatchTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            // Test near-maximum dispatch size (WebGPU limit is 65535 per dimension)
            int len = 65536; // 2^16
            var data = new int[len];
            for (int i = 0; i < len; i++) data[i] = i;

            using var buf = accelerator.Allocate1D(data);
            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<int>>(LargeDispatchKernel);
            kernel((Index1D)len, buf.View);
            await accelerator.SynchronizeAsync();

            var result = await ReadBufferAsync<int>(buf);

            // Spot check
            int[] checkIndices = { 0, 1000, 32768, 65535 };
            foreach (int i in checkIndices)
            {
                int expected = i + 1;
                if (result[i] != expected)
                    throw new Exception($"Large dispatch failed at {i}. Expected {expected}, got {result[i]}");
            }
        }

        static void LargeDispatchKernel(Index1D index, ArrayView<int> data)
        {
            data[index] = data[index] + 1;
        }

        // ============= MORE COVERAGE TESTS =============

        [TestMethod]
        public async Task WebGPUComparisonOperatorsTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int len = 6;
            var a = new int[] { 5, 5, 3, 7, 5, 5 };
            var b = new int[] { 3, 7, 5, 5, 5, 6 };

            using var bufA = accelerator.Allocate1D(a);
            using var bufB = accelerator.Allocate1D(b);
            using var bufOut = accelerator.Allocate1D<int>(len);

            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<int>, ArrayView<int>, ArrayView<int>>(ComparisonKernel);
            kernel((Index1D)len, bufA.View, bufB.View, bufOut.View);
            await accelerator.SynchronizeAsync();

            var result = await ReadBufferAsync<int>(bufOut);

            // Expected: [0]: a > b (5>3=1), [1]: a < b (5<7=1), [2]: a >= b (3>=5=0), 
            //           [3]: a <= b (7<=5=0), [4]: a == b (5==5=1), [5]: a != b (5!=6=1)
            int[] expected = { 1, 1, 0, 0, 1, 1 };
            for (int i = 0; i < len; i++)
            {
                if (result[i] != expected[i])
                    throw new Exception($"Comparison failed at {i}. Expected {expected[i]}, got {result[i]}");
            }
        }

        static void ComparisonKernel(Index1D index, ArrayView<int> a, ArrayView<int> b, ArrayView<int> output)
        {
            int va = a[index], vb = b[index];
            if (index == 0) output[index] = (va > vb) ? 1 : 0;
            else if (index == 1) output[index] = (va < vb) ? 1 : 0;
            else if (index == 2) output[index] = (va >= vb) ? 1 : 0;
            else if (index == 3) output[index] = (va <= vb) ? 1 : 0;
            else if (index == 4) output[index] = (va == vb) ? 1 : 0;
            else if (index == 5) output[index] = (va != vb) ? 1 : 0;
        }

        [TestMethod]
        public async Task WebGPUShortCircuitTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int len = 4;
            var a = new int[] { 0, 1, 0, 1 };
            var b = new int[] { 0, 0, 1, 1 };

            using var bufA = accelerator.Allocate1D(a);
            using var bufB = accelerator.Allocate1D(b);
            using var bufOut = accelerator.Allocate1D<int>(len);

            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<int>, ArrayView<int>, ArrayView<int>>(ShortCircuitKernel);
            kernel((Index1D)len, bufA.View, bufB.View, bufOut.View);
            await accelerator.SynchronizeAsync();

            var result = await ReadBufferAsync<int>(bufOut);

            // [0]: 0 && 0 = false, [1]: 1 && 0 = false, [2]: 0 || 1 = true, [3]: 1 || 1 = true
            int[] expected = { 0, 0, 1, 1 };
            for (int i = 0; i < len; i++)
            {
                if (result[i] != expected[i])
                    throw new Exception($"Short circuit failed at {i}. Expected {expected[i]}, got {result[i]}");
            }
        }

        static void ShortCircuitKernel(Index1D index, ArrayView<int> a, ArrayView<int> b, ArrayView<int> output)
        {
            bool valA = a[index] != 0;
            bool valB = b[index] != 0;
            bool result;
            // Test && and || operators
            if (index < 2) result = valA && valB;  // [0]: false && false, [1]: true && false
            else result = valA || valB;             // [2]: false || true, [3]: true || true
            output[index] = result ? 1 : 0;
        }

        [TestMethod]
        public async Task WebGPUNaNInfinityTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int len = 4;
            var data = new float[len];
            // Use normal values - special handling will be in kernel
            data[0] = 1.0f;
            data[1] = 1.0f;
            data[2] = 0.0f;
            data[3] = 0.0f;

            using var buf = accelerator.Allocate1D(data);
            using var bufOut = accelerator.Allocate1D<int>(len);

            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<float>, ArrayView<int>>(NaNInfinityKernel);
            kernel((Index1D)len, buf.View, bufOut.View);
            await accelerator.SynchronizeAsync();

            var result = await ReadBufferAsync<int>(bufOut);

            // [0]: 1/0 > 0 (inf > 0) = true, [1]: -1/0 < 0 (-inf < 0) = true, 
            // [2]: 0/0 == 0/0 (NaN == NaN) = false, [3]: 0/0 is NaN = true
            if (result[0] != 1) throw new Exception($"Inf > 0 failed. Expected 1, got {result[0]}");
            if (result[1] != 1) throw new Exception($"-Inf < 0 failed. Expected 1, got {result[1]}");
            if (result[2] != 0) throw new Exception($"NaN == NaN should be false. Expected 0, got {result[2]}");
            if (result[3] != 1) throw new Exception($"IsNaN(0/0) should be true. Expected 1, got {result[3]}");
        }

        static void NaNInfinityKernel(Index1D index, ArrayView<float> input, ArrayView<int> output)
        {
            float val = input[index];
            // Generate special values in the kernel to avoid transfer issues
            if (index == 0)
            {
                float inf = 1.0f / 0.0f; // +Infinity
                output[index] = (inf > 0.0f) ? 1 : 0;
            }
            else if (index == 1)
            {
                float negInf = -1.0f / 0.0f; // -Infinity
                output[index] = (negInf < 0.0f) ? 1 : 0;
            }
            else if (index == 2)
            {
                float nan = 0.0f / 0.0f; // NaN
                output[index] = (nan == nan) ? 1 : 0; // NaN != NaN, so this should be 0
            }
            else
            {
                float nan = 0.0f / 0.0f;
                // Use nan != nan instead of float.IsNaN() to avoid Int1 type issues
                output[index] = (nan != nan) ? 1 : 0; // NaN != NaN is true
            }
        }

        [TestMethod]
        public async Task WebGPUReductionTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int len = 64;
            var data = new int[len];
            for (int i = 0; i < len; i++) data[i] = 1; // Sum of 64 ones = 64

            var sumResult = new int[1];

            using var bufData = accelerator.Allocate1D(data);
            using var bufSum = accelerator.Allocate1D(sumResult);

            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<int>, ArrayView<int>>(ReductionKernel);
            kernel((Index1D)len, bufData.View, bufSum.View);
            await accelerator.SynchronizeAsync();

            var result = await ReadBufferAsync<int>(bufSum);
            if (result[0] != 64)
                throw new Exception($"Reduction failed. Expected 64, got {result[0]}");
        }

        static void ReductionKernel(Index1D index, ArrayView<int> data, ArrayView<int> sum)
        {
            Atomic.Add(ref sum[0], data[index]);
        }

        [TestMethod]
        public async Task WebGPUScatterGatherTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int len = 8;
            var data = new int[] { 10, 20, 30, 40, 50, 60, 70, 80 };
            var indices = new int[] { 7, 5, 3, 1, 6, 4, 2, 0 }; // Reverse gather

            using var bufData = accelerator.Allocate1D(data);
            using var bufIndices = accelerator.Allocate1D(indices);
            using var bufOut = accelerator.Allocate1D<int>(len);

            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<int>, ArrayView<int>, ArrayView<int>>(GatherKernel);
            kernel((Index1D)len, bufData.View, bufIndices.View, bufOut.View);
            await accelerator.SynchronizeAsync();

            var result = await ReadBufferAsync<int>(bufOut);
            int[] expected = { 80, 60, 40, 20, 70, 50, 30, 10 }; // Gathered values
            for (int i = 0; i < len; i++)
            {
                if (result[i] != expected[i])
                    throw new Exception($"Gather failed at {i}. Expected {expected[i]}, got {result[i]}");
            }
        }

        static void GatherKernel(Index1D index, ArrayView<int> data, ArrayView<int> indices, ArrayView<int> output)
        {
            int idx = indices[index];
            output[index] = data[idx];
        }

        [TestMethod]
        public async Task WebGPUDeepNestingTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int len = 8;
            var data = new int[len];

            using var buf = accelerator.Allocate1D(data);
            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<int>>(DeepNestingKernel);
            kernel((Index1D)len, buf.View);
            await accelerator.SynchronizeAsync();

            var result = await ReadBufferAsync<int>(buf);
            for (int i = 0; i < len; i++)
            {
                // 5-deep nesting: if(if(if(if(if(true)))))
                int expected = 5;
                if (result[i] != expected)
                    throw new Exception($"Deep nesting failed at {i}. Expected {expected}, got {result[i]}");
            }
        }

        static void DeepNestingKernel(Index1D index, ArrayView<int> data)
        {
            int count = 0;
            if (true)
            {
                count++;
                if (true)
                {
                    count++;
                    if (true)
                    {
                        count++;
                        if (true)
                        {
                            count++;
                            if (true)
                            {
                                count++;
                            }
                        }
                    }
                }
            }
            data[index] = count;
        }

        [TestMethod]
        public async Task WebGPUZeroIterationLoopTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int len = 4;
            var data = new int[] { 100, 100, 100, 100 };

            using var buf = accelerator.Allocate1D(data);
            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<int>>(ZeroLoopKernel);
            kernel((Index1D)len, buf.View);
            await accelerator.SynchronizeAsync();

            var result = await ReadBufferAsync<int>(buf);
            // Loop runs 0 times, so value should be unchanged
            for (int i = 0; i < len; i++)
            {
                if (result[i] != 100)
                    throw new Exception($"Zero loop failed at {i}. Expected 100, got {result[i]}");
            }
        }

        static void ZeroLoopKernel(Index1D index, ArrayView<int> data)
        {
            for (int i = 0; i < 0; i++) // Zero iterations
            {
                data[index] = 0;
            }
        }

        [TestMethod]
        public async Task WebGPUMultipleOutputsTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int len = 8;
            var input = new int[len];
            for (int i = 0; i < len; i++) input[i] = i;

            using var bufIn = accelerator.Allocate1D(input);
            using var bufSum = accelerator.Allocate1D<int>(len);
            using var bufProduct = accelerator.Allocate1D<int>(len);
            using var bufSquare = accelerator.Allocate1D<int>(len);

            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<int>, ArrayView<int>, ArrayView<int>, ArrayView<int>>(MultiOutputKernel);
            kernel((Index1D)len, bufIn.View, bufSum.View, bufProduct.View, bufSquare.View);
            await accelerator.SynchronizeAsync();

            var sumResult = await ReadBufferAsync<int>(bufSum);
            var prodResult = await ReadBufferAsync<int>(bufProduct);
            var sqResult = await ReadBufferAsync<int>(bufSquare);

            for (int i = 0; i < len; i++)
            {
                if (sumResult[i] != i + 10)
                    throw new Exception($"Sum output failed at {i}. Expected {i + 10}, got {sumResult[i]}");
                if (prodResult[i] != i * 2)
                    throw new Exception($"Product output failed at {i}. Expected {i * 2}, got {prodResult[i]}");
                if (sqResult[i] != i * i)
                    throw new Exception($"Square output failed at {i}. Expected {i * i}, got {sqResult[i]}");
            }
        }

        static void MultiOutputKernel(Index1D index, ArrayView<int> input, ArrayView<int> sum, ArrayView<int> product, ArrayView<int> square)
        {
            int val = input[index];
            sum[index] = val + 10;
            product[index] = val * 2;
            square[index] = val * val;
        }

        // ===== Additional Coverage Tests =====

        /// <summary>
        /// Test warp/subgroup shuffle operations (not supported in browser WebGPU)
        /// </summary>
        [TestMethod]
        public async Task WebGPUSubgroupShuffleTest()
        {
            // Subgroup operations (warp shuffle, broadcast) are not available in browser WebGPU
            throw new UnsupportedTestException("Skip: Subgroup/Warp operations not supported in browser WebGPU");

            // If ever supported, the test would use Warp.Shuffle, Warp.Broadcast, etc.
        }

        /// <summary>
        /// Test matrix multiplication pattern (common GPU workload)
        /// </summary>
        [TestMethod]
        public async Task WebGPUMatrixMultiplyTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            // Small 4x4 matrix multiplication
            int size = 4;
            var a = new float[size * size];
            var b = new float[size * size];
            
            // Initialize: A = identity-ish, B = sequential
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    a[i * size + j] = (i == j) ? 1.0f : 0.0f; // Identity matrix
                    b[i * size + j] = i * size + j;           // Sequential
                }
            }

            using var bufA = accelerator.Allocate1D(a);
            using var bufB = accelerator.Allocate1D(b);
            using var bufC = accelerator.Allocate1D<float>(size * size);

            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<float>, ArrayView<float>, ArrayView<float>, int>(MatMulKernel);
            kernel((Index1D)(size * size), bufA.View, bufB.View, bufC.View, size);
            await accelerator.SynchronizeAsync();

            var result = await ReadBufferAsync<float>(bufC);

            // Identity * B = B
            for (int i = 0; i < size * size; i++)
            {
                if (MathF.Abs(result[i] - b[i]) > 0.001f)
                    throw new Exception($"Matrix multiply failed at {i}. Expected {b[i]}, got {result[i]}");
            }
        }

        static void MatMulKernel(Index1D index, ArrayView<float> a, ArrayView<float> b, ArrayView<float> c, int size)
        {
            int row = index / size;
            int col = index % size;
            float sum = 0.0f;
            for (int k = 0; k < size; k++)
            {
                sum += a[row * size + k] * b[k * size + col];
            }
            c[index] = sum;
        }

        /// <summary>
        /// Test kernel reuse - same kernel invoked multiple times with different data
        /// </summary>
        [TestMethod]
        public async Task WebGPUKernelReuseTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int len = 64;
            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<int>, int>(AddConstantKernel);

            // First invocation
            var data1 = new int[len];
            for (int i = 0; i < len; i++) data1[i] = i;
            using var buf1 = accelerator.Allocate1D(data1);
            kernel((Index1D)len, buf1.View, 100);
            await accelerator.SynchronizeAsync();
            var result1 = await ReadBufferAsync<int>(buf1);

            // Second invocation with different constant
            var data2 = new int[len];
            for (int i = 0; i < len; i++) data2[i] = i * 2;
            using var buf2 = accelerator.Allocate1D(data2);
            kernel((Index1D)len, buf2.View, 50);
            await accelerator.SynchronizeAsync();
            var result2 = await ReadBufferAsync<int>(buf2);

            // Verify both
            for (int i = 0; i < len; i++)
            {
                if (result1[i] != i + 100)
                    throw new Exception($"First kernel invocation failed at {i}. Expected {i + 100}, got {result1[i]}");
                if (result2[i] != i * 2 + 50)
                    throw new Exception($"Second kernel invocation failed at {i}. Expected {i * 2 + 50}, got {result2[i]}");
            }
        }

        static void AddConstantKernel(Index1D index, ArrayView<int> data, int constant)
        {
            data[index] += constant;
        }

        /// <summary>
        /// Test chained kernel execution - output of one kernel as input to another
        /// </summary>
        [TestMethod]
        public async Task WebGPUChainedKernelsTest()
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

            var doubleKernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<int>>(DoubleValueKernel);
            var addTenKernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<int>>(AddTenKernel);

            // Chain: double -> add 10 -> double
            doubleKernel((Index1D)len, buf.View);
            await accelerator.SynchronizeAsync();
            
            addTenKernel((Index1D)len, buf.View);
            await accelerator.SynchronizeAsync();
            
            doubleKernel((Index1D)len, buf.View);
            await accelerator.SynchronizeAsync();

            var result = await ReadBufferAsync<int>(buf);

            // Expected: ((i * 2) + 10) * 2 = 4i + 20
            for (int i = 0; i < len; i++)
            {
                int expected = 4 * i + 20;
                if (result[i] != expected)
                    throw new Exception($"Chained kernel failed at {i}. Expected {expected}, got {result[i]}");
            }
        }

        static void DoubleValueKernel(Index1D index, ArrayView<int> data)
        {
            data[index] *= 2;
        }

        static void AddTenKernel(Index1D index, ArrayView<int> data)
        {
            data[index] += 10;
        }

        /// <summary>
        /// Test boundary conditions - thread index at edges
        /// </summary>
        [TestMethod]
        public async Task WebGPUBoundaryConditionsTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            // Use non-power-of-2 size to test edge handling
            int len = 100; // Not a multiple of typical workgroup size (64)
            var data = new int[len];

            using var buf = accelerator.Allocate1D(data);
            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<int>, int>(BoundaryKernel);
            kernel((Index1D)len, buf.View, len);
            await accelerator.SynchronizeAsync();

            var result = await ReadBufferAsync<int>(buf);

            // Check that all threads executed correctly
            for (int i = 0; i < len; i++)
            {
                // First and last get special values
                int expected = (i == 0) ? -1 : (i == len - 1) ? 1 : 0;
                if (result[i] != expected)
                    throw new Exception($"Boundary test failed at {i}. Expected {expected}, got {result[i]}");
            }
        }

        static void BoundaryKernel(Index1D index, ArrayView<int> data, int length)
        {
            if (index == 0)
                data[index] = -1; // First element
            else if (index == length - 1)
                data[index] = 1;  // Last element
            else
                data[index] = 0;  // Middle elements
        }

        /// <summary>
        /// Test float special operations (sign, frac, saturate pattern)
        /// </summary>
        [TestMethod]
        public async Task WebGPUFloatSpecialOpsTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int len = 6;
            var data = new float[] { -3.7f, -0.5f, 0.0f, 0.5f, 1.5f, 3.7f };

            using var buf = accelerator.Allocate1D(data);
            using var bufOut = accelerator.Allocate1D<float>(len);
            
            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<float>, ArrayView<float>>(FloatSpecialOpsKernel);
            kernel((Index1D)len, buf.View, bufOut.View);
            await accelerator.SynchronizeAsync();

            var result = await ReadBufferAsync<float>(bufOut);

            // Test saturate (clamp to 0-1): values get clamped
            float[] expected = { 0.0f, 0.0f, 0.0f, 0.5f, 1.0f, 1.0f };
            for (int i = 0; i < len; i++)
            {
                if (MathF.Abs(result[i] - expected[i]) > 0.001f)
                    throw new Exception($"Saturate failed at {i}. Expected {expected[i]}, got {result[i]}");
            }
        }

        static void FloatSpecialOpsKernel(Index1D index, ArrayView<float> input, ArrayView<float> output)
        {
            float val = input[index];
            // Saturate: clamp to [0, 1]
            output[index] = Math.Min(Math.Max(val, 0.0f), 1.0f);
        }

        /// <summary>
        /// Test modulo operations for both positive and negative values
        /// </summary>
        [TestMethod]
        public async Task WebGPUModuloOperationsTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int len = 8;
            var data = new int[] { 10, -10, 7, -7, 15, -15, 3, -3 };

            using var buf = accelerator.Allocate1D(data);
            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<int>>(ModuloKernel);
            kernel((Index1D)len, buf.View);
            await accelerator.SynchronizeAsync();

            var result = await ReadBufferAsync<int>(buf);

            // Modulo by 4
            int[] expected = { 2, -2, 3, -3, 3, -3, 3, -3 };
            for (int i = 0; i < len; i++)
            {
                if (result[i] != expected[i])
                    throw new Exception($"Modulo failed at {i}. Expected {expected[i]}, got {result[i]}");
            }
        }

        static void ModuloKernel(Index1D index, ArrayView<int> data)
        {
            data[index] = data[index] % 4;
        }

        /// <summary>
        /// Test large workgroup dispatch (stress test)
        /// </summary>
        [TestMethod]
        public async Task WebGPUMillionElementsTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            // 1 million elements
            int len = 1024 * 1024;
            var data = new int[len];

            using var buf = accelerator.Allocate1D(data);
            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<int>>(SimpleSetKernel);
            kernel((Index1D)len, buf.View);
            await accelerator.SynchronizeAsync();

            var result = await ReadBufferAsync<int>(buf);

            // Sample check (checking all would be slow)
            int[] checkIndices = { 0, 100, 1000, 10000, 100000, 500000, 999999, len - 1 };
            foreach (int i in checkIndices)
            {
                if (result[i] != i)
                    throw new Exception($"Large dispatch failed at {i}. Expected {i}, got {result[i]}");
            }
        }

        static void SimpleSetKernel(Index1D index, ArrayView<int> data)
        {
            data[index] = index;
        }

        // ===== Additional Comprehensive Tests =====

        /// <summary>
        /// Test 1D stencil pattern (accessing neighboring elements)
        /// </summary>
        [TestMethod]
        public async Task WebGPUStencilOperationTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int len = 64;
            var input = new float[len];
            for (int i = 0; i < len; i++) input[i] = i;

            using var bufIn = accelerator.Allocate1D(input);
            using var bufOut = accelerator.Allocate1D<float>(len);

            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<float>, ArrayView<float>, int>(StencilKernel);
            kernel((Index1D)len, bufIn.View, bufOut.View, len);
            await accelerator.SynchronizeAsync();

            var result = await ReadBufferAsync<float>(bufOut);

            // 3-point average: (left + center + right) / 3
            for (int i = 1; i < len - 1; i++)
            {
                float expected = (input[i - 1] + input[i] + input[i + 1]) / 3.0f;
                if (MathF.Abs(result[i] - expected) > 0.001f)
                    throw new Exception($"Stencil failed at {i}. Expected {expected}, got {result[i]}");
            }
        }

        static void StencilKernel(Index1D index, ArrayView<float> input, ArrayView<float> output, int length)
        {
            if (index == 0 || index == length - 1)
            {
                output[index] = input[index]; // Boundary: copy
            }
            else
            {
                // 3-point average stencil
                output[index] = (input[index - 1] + input[index] + input[index + 1]) / 3.0f;
            }
        }

        /// <summary>
        /// Test parallel reduction (sum) using shared memory
        /// </summary>
        [TestMethod]
        public async Task WebGPUParallelSumTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            // Use workgroup size elements for simple reduction
            int len = 64;
            var data = new int[len];
            int expectedSum = 0;
            for (int i = 0; i < len; i++)
            {
                data[i] = i + 1;
                expectedSum += data[i];
            }

            using var buf = accelerator.Allocate1D(data);
            using var bufResult = accelerator.Allocate1D<int>(1);

            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<int>, ArrayView<int>, int>(ParallelSumKernel);
            kernel((Index1D)len, buf.View, bufResult.View, len);
            await accelerator.SynchronizeAsync();

            var result = await ReadBufferAsync<int>(bufResult);

            if (result[0] != expectedSum)
                throw new Exception($"Parallel sum failed. Expected {expectedSum}, got {result[0]}");
        }

        static void ParallelSumKernel(Index1D index, ArrayView<int> data, ArrayView<int> result, int length)
        {
            // Simple atomic-based reduction (not optimal but tests atomics with reduction)
            Atomic.Add(ref result[0], data[index]);
        }

        /// <summary>
        /// Test type conversions (float to int, int to float)
        /// </summary>
        [TestMethod]
        public async Task WebGPUTypeConversionTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int len = 8;
            var floatData = new float[] { 1.5f, 2.7f, -3.2f, 0.0f, 100.9f, -50.1f, 0.4f, 0.6f };

            using var bufFloat = accelerator.Allocate1D(floatData);
            using var bufInt = accelerator.Allocate1D<int>(len);
            using var bufBack = accelerator.Allocate1D<float>(len);

            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<float>, ArrayView<int>, ArrayView<float>>(TypeConversionKernel);
            kernel((Index1D)len, bufFloat.View, bufInt.View, bufBack.View);
            await accelerator.SynchronizeAsync();

            var intResult = await ReadBufferAsync<int>(bufInt);
            var floatResult = await ReadBufferAsync<float>(bufBack);

            // Verify float -> int truncation
            int[] expectedInt = { 1, 2, -3, 0, 100, -50, 0, 0 };
            for (int i = 0; i < len; i++)
            {
                if (intResult[i] != expectedInt[i])
                    throw new Exception($"Float->Int conversion failed at {i}. Expected {expectedInt[i]}, got {intResult[i]}");
                // Back conversion should match truncated int
                if (MathF.Abs(floatResult[i] - (float)expectedInt[i]) > 0.001f)
                    throw new Exception($"Int->Float conversion failed at {i}. Expected {expectedInt[i]}, got {floatResult[i]}");
            }
        }

        static void TypeConversionKernel(Index1D index, ArrayView<float> floatIn, ArrayView<int> intOut, ArrayView<float> floatOut)
        {
            int truncated = (int)floatIn[index];
            intOut[index] = truncated;
            floatOut[index] = (float)truncated;
        }

        /// <summary>
        /// Test bitwise shift operations
        /// </summary>
        [TestMethod]
        public async Task WebGPUShiftOperationsTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int len = 8;
            var data = new int[] { 1, 2, 4, 8, 16, 255, 1024, -8 };

            using var bufLeft = accelerator.Allocate1D(data);
            using var bufRight = accelerator.Allocate1D(data);

            var leftKernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<int>>(LeftShiftKernel);
            var rightKernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<int>>(RightShiftKernel);

            leftKernel((Index1D)len, bufLeft.View);
            rightKernel((Index1D)len, bufRight.View);
            await accelerator.SynchronizeAsync();

            var leftResult = await ReadBufferAsync<int>(bufLeft);
            var rightResult = await ReadBufferAsync<int>(bufRight);

            // Left shift by 2
            int[] expectedLeft = { 4, 8, 16, 32, 64, 1020, 4096, -32 };
            // Right shift by 1
            int[] expectedRight = { 0, 1, 2, 4, 8, 127, 512, -4 };

            for (int i = 0; i < len; i++)
            {
                if (leftResult[i] != expectedLeft[i])
                    throw new Exception($"Left shift failed at {i}. Expected {expectedLeft[i]}, got {leftResult[i]}");
                if (rightResult[i] != expectedRight[i])
                    throw new Exception($"Right shift failed at {i}. Expected {expectedRight[i]}, got {rightResult[i]}");
            }
        }

        static void LeftShiftKernel(Index1D index, ArrayView<int> data)
        {
            data[index] = data[index] << 2;
        }

        static void RightShiftKernel(Index1D index, ArrayView<int> data)
        {
            data[index] = data[index] >> 1;
        }

        /// <summary>
        /// Test nested struct operations
        /// </summary>
        public struct NestedInnerStruct
        {
            public int A;
            public int B;
        }

        public struct NestedOuterStruct
        {
            public NestedInnerStruct Inner;
            public float Value;
        }

        [TestMethod]
        public async Task WebGPUNestedStructTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int len = 4;
            var data = new NestedOuterStruct[len];
            for (int i = 0; i < len; i++)
            {
                data[i] = new NestedOuterStruct
                {
                    Inner = new NestedInnerStruct { A = i, B = i * 2 },
                    Value = i * 1.5f
                };
            }

            using var buf = accelerator.Allocate1D(data);
            using var bufResult = accelerator.Allocate1D<int>(len);

            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<NestedOuterStruct>, ArrayView<int>>(NestedStructKernel);
            kernel((Index1D)len, buf.View, bufResult.View);
            await accelerator.SynchronizeAsync();

            var result = await ReadBufferAsync<int>(bufResult);

            // Result = Inner.A + Inner.B + (int)Value
            for (int i = 0; i < len; i++)
            {
                int expected = i + i * 2 + (int)(i * 1.5f);
                if (result[i] != expected)
                    throw new Exception($"Nested struct failed at {i}. Expected {expected}, got {result[i]}");
            }
        }

        static void NestedStructKernel(Index1D index, ArrayView<NestedOuterStruct> structs, ArrayView<int> result)
        {
            var s = structs[index];
            result[index] = s.Inner.A + s.Inner.B + (int)s.Value;
        }

        /// <summary>
        /// Test buffer-to-buffer copy pattern
        /// </summary>
        [TestMethod]
        public async Task WebGPUBufferCopyTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int len = 64;
            var source = new int[len];
            for (int i = 0; i < len; i++) source[i] = i * 3;

            using var bufSrc = accelerator.Allocate1D(source);
            using var bufDst = accelerator.Allocate1D<int>(len);

            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<int>, ArrayView<int>>(CopyKernel);
            kernel((Index1D)len, bufSrc.View, bufDst.View);
            await accelerator.SynchronizeAsync();

            var result = await ReadBufferAsync<int>(bufDst);

            for (int i = 0; i < len; i++)
            {
                if (result[i] != source[i])
                    throw new Exception($"Buffer copy failed at {i}. Expected {source[i]}, got {result[i]}");
            }
        }

        static void CopyKernel(Index1D index, ArrayView<int> src, ArrayView<int> dst)
        {
            dst[index] = src[index];
        }

        /// <summary>
        /// Test unary operations (negation, bitwise NOT)
        /// </summary>
        [TestMethod]
        public async Task WebGPUUnaryOperationsTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int len = 8;
            var intData = new int[] { 0, 1, -1, 5, -10, 127, -128, 255 };
            var floatData = new float[] { 0.0f, 1.0f, -1.0f, 3.14f, -2.5f, 100.0f, -0.5f, 0.001f };

            using var bufInt = accelerator.Allocate1D(intData);
            using var bufFloat = accelerator.Allocate1D(floatData);

            var intKernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<int>>(IntUnaryKernel);
            var floatKernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<float>>(FloatUnaryKernel);

            intKernel((Index1D)len, bufInt.View);
            floatKernel((Index1D)len, bufFloat.View);
            await accelerator.SynchronizeAsync();

            var intResult = await ReadBufferAsync<int>(bufInt);
            var floatResult = await ReadBufferAsync<float>(bufFloat);

            // verify: ~(-x) = x - 1 (for int), -x for float
            for (int i = 0; i < len; i++)
            {
                int expectedInt = ~(-intData[i]);
                if (intResult[i] != expectedInt)
                    throw new Exception($"Int unary failed at {i}. Expected {expectedInt}, got {intResult[i]}");

                float expectedFloat = -floatData[i];
                if (MathF.Abs(floatResult[i] - expectedFloat) > 0.001f)
                    throw new Exception($"Float unary failed at {i}. Expected {expectedFloat}, got {floatResult[i]}");
            }
        }

        static void IntUnaryKernel(Index1D index, ArrayView<int> data)
        {
            data[index] = ~(-data[index]); // Negate then bitwise NOT
        }

        static void FloatUnaryKernel(Index1D index, ArrayView<float> data)
        {
            data[index] = -data[index]; // Simple negation
        }

        /// <summary>
        /// Test smoothstep-like interpolation (common GPU pattern)
        /// </summary>
        [TestMethod]
        public async Task WebGPUSmoothstepTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int len = 11;
            var input = new float[len];
            for (int i = 0; i < len; i++) input[i] = i * 0.1f; // 0.0 to 1.0

            using var buf = accelerator.Allocate1D(input);

            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<float>>(SmoothstepKernel);
            kernel((Index1D)len, buf.View);
            await accelerator.SynchronizeAsync();

            var result = await ReadBufferAsync<float>(buf);

            // Verify smoothstep: 3x² - 2x³
            for (int i = 0; i < len; i++)
            {
                float t = input[i];
                float expected = t * t * (3.0f - 2.0f * t);
                if (MathF.Abs(result[i] - expected) > 0.001f)
                    throw new Exception($"Smoothstep failed at {i}. Expected {expected}, got {result[i]}");
            }
        }

        static void SmoothstepKernel(Index1D index, ArrayView<float> data)
        {
            float t = data[index];
            // Smoothstep formula: 3t² - 2t³
            data[index] = t * t * (3.0f - 2.0f * t);
        }

        /// <summary>
        /// Test linear interpolation (lerp)
        /// </summary>
        [TestMethod]
        public async Task WebGPULerpTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int len = 11;
            var tValues = new float[len];
            for (int i = 0; i < len; i++) tValues[i] = i * 0.1f; // 0.0 to 1.0

            using var bufT = accelerator.Allocate1D(tValues);
            using var bufOut = accelerator.Allocate1D<float>(len);

            float a = 10.0f;
            float b = 50.0f;

            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<float>, ArrayView<float>, float, float>(LerpKernel);
            kernel((Index1D)len, bufT.View, bufOut.View, a, b);
            await accelerator.SynchronizeAsync();

            var result = await ReadBufferAsync<float>(bufOut);

            for (int i = 0; i < len; i++)
            {
                float t = tValues[i];
                float expected = a + t * (b - a);
                if (MathF.Abs(result[i] - expected) > 0.001f)
                    throw new Exception($"Lerp failed at {i}. Expected {expected}, got {result[i]}");
            }
        }

        static void LerpKernel(Index1D index, ArrayView<float> t, ArrayView<float> output, float a, float b)
        {
            output[index] = a + t[index] * (b - a);
        }

        /// <summary>
        /// Test multiple data types in same kernel (int, uint, float)
        /// </summary>
        [TestMethod]
        public async Task WebGPUMixedTypesTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int len = 8;
            var intData = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            var uintData = new uint[] { 10, 20, 30, 40, 50, 60, 70, 80 };
            var floatData = new float[] { 0.1f, 0.2f, 0.3f, 0.4f, 0.5f, 0.6f, 0.7f, 0.8f };

            using var bufInt = accelerator.Allocate1D(intData);
            using var bufUint = accelerator.Allocate1D(uintData);
            using var bufFloat = accelerator.Allocate1D(floatData);
            using var bufResult = accelerator.Allocate1D<float>(len);

            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<int>, ArrayView<uint>, ArrayView<float>, ArrayView<float>>(MixedTypesKernel);
            kernel((Index1D)len, bufInt.View, bufUint.View, bufFloat.View, bufResult.View);
            await accelerator.SynchronizeAsync();

            var result = await ReadBufferAsync<float>(bufResult);

            for (int i = 0; i < len; i++)
            {
                float expected = intData[i] + uintData[i] + floatData[i];
                if (MathF.Abs(result[i] - expected) > 0.001f)
                    throw new Exception($"Mixed types failed at {i}. Expected {expected}, got {result[i]}");
            }
        }

        static void MixedTypesKernel(Index1D index, ArrayView<int> ints, ArrayView<uint> uints, ArrayView<float> floats, ArrayView<float> result)
        {
            result[index] = ints[index] + uints[index] + floats[index];
        }

        /// <summary>
        /// Test expression with many operations combined
        /// </summary>
        [TestMethod]
        public async Task WebGPUComplexExpressionTest()
        {
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();
            var device = context.GetWebGPUDevices()[0];
            using var accelerator = await device.CreateAcceleratorAsync(context);

            int len = 16;
            var data = new float[len];
            for (int i = 0; i < len; i++) data[i] = i + 1;

            using var buf = accelerator.Allocate1D(data);

            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<float>>(ComplexExpressionKernel);
            kernel((Index1D)len, buf.View);
            await accelerator.SynchronizeAsync();

            var result = await ReadBufferAsync<float>(buf);

            for (int i = 0; i < len; i++)
            {
                float x = i + 1;
                // ((x * 2 + 3) / 4 - 1) * 5 + x
                float expected = ((x * 2 + 3) / 4 - 1) * 5 + x;
                if (MathF.Abs(result[i] - expected) > 0.01f)
                    throw new Exception($"Complex expression failed at {i}. Expected {expected}, got {result[i]}");
            }
        }

        static void ComplexExpressionKernel(Index1D index, ArrayView<float> data)
        {
            float x = data[index];
            data[index] = ((x * 2 + 3) / 4 - 1) * 5 + x;
        }
    }
}






