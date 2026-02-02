using SpawnDev.Blazor.UnitTesting;
using System;
using System.Linq;
using ILGPU;
using ILGPU.Runtime;
using SpawnDev.ILGPU.WebGPU.Backend;

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
            // 1. Create Context with WebGPU devices registered asynchronously
            var builder = Context.Create();
            await builder.WebGPUAsync();
            using var context = builder.ToContext();

            // 2. Get Device 
            var devices = context.GetWebGPUDevices();
            if (devices.Count == 0)
            {
                throw new UnsupportedTestException("No WebGPU/ILGPU devices found via Context");
            }
            
            var device = devices[0];
            
            // 3. Create Accelerator asynchronously
            using var accelerator = await device.CreateAcceleratorAsync(context);
                
            // 4. Data
            var data = new int[64];
            using var buffer = accelerator.Allocate1D(data);

            // 5. Load Kernel
            var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<int>, int>(MyKernel);

            // 6. Launch
            kernel((Index1D)buffer.Length, buffer.View, 33);

            // 7. Verify
            accelerator.Synchronize();
            
            // WebGPU requires async readback
            // Convert to byte buffer for reading
            var iView = (IArrayView)buffer;
            var internalBuffer = iView.Buffer as WebGPUMemoryBuffer;
            if (internalBuffer == null) throw new Exception("Could not get WebGPUMemoryBuffer");
            
            // Read from native buffer (returns byte[])
            var byteResults = await internalBuffer.NativeBuffer.CopyToHostAsync();
            
            // Convert byte[] to int[]
            var result = new int[data.Length];
            Buffer.BlockCopy(byteResults, 0, result, 0, byteResults.Length);

            for (int i = 0; i < data.Length; i++)
            {
                // The kernel adds index + constant
                var expected = i + 33;
                if (result[i] != expected)
                    throw new Exception($"Kernel execution failed at {i}. Expected {expected}, got {result[i]}");
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

    }
}
