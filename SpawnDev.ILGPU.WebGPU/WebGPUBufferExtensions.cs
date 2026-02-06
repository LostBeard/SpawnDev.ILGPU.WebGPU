using global::ILGPU;
using global::ILGPU.Runtime;
using SpawnDev.ILGPU.WebGPU.Backend;
using System.Runtime.InteropServices;

namespace SpawnDev.ILGPU.WebGPU
{
    /// <summary>
    /// Extension methods for ILGPU buffer types to support async readback in WebGPU.
    /// </summary>
    public static class WebGPUBufferExtensions
    {
        /// <summary>
        /// Copies data from the GPU buffer back to the host asynchronously.
        /// This is the recommended way to read data from GPU buffers in the WebGPU backend.
        /// </summary>
        /// <typeparam name="T">The element type of the buffer.</typeparam>
        /// <param name="buffer">The MemoryBuffer to read from.</param>
        /// <returns>An array containing the buffer data.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the buffer is not backed by WebGPU.</exception>
        public static async Task<T[]> CopyToHostAsync<T>(this MemoryBuffer1D<T, Stride1D.Dense> buffer) where T : unmanaged
        {
            var internalBuffer = GetWebGPUBuffer((MemoryBuffer)buffer);
            var byteData = await internalBuffer.NativeBuffer.CopyToHostAsync();
            var result = new T[buffer.Length];
            MemoryMarshal.Cast<byte, T>(byteData).CopyTo(new Span<T>(result));
            return result;
        }

        /// <summary>
        /// Copies data from the GPU buffer back to the host asynchronously.
        /// This overload works with any MemoryBuffer (for 2D, 3D, etc.).
        /// </summary>
        /// <typeparam name="T">The element type of the buffer.</typeparam>
        /// <param name="buffer">The MemoryBuffer to read from.</param>
        /// <returns>An array containing the buffer data (flattened for multi-dimensional buffers).</returns>
        /// <exception cref="InvalidOperationException">Thrown if the buffer is not backed by WebGPU.</exception>
        public static async Task<T[]> CopyToHostAsync<T>(this MemoryBuffer buffer) where T : unmanaged
        {
            var internalBuffer = GetWebGPUBuffer(buffer);
            var byteData = await internalBuffer.NativeBuffer.CopyToHostAsync();
            var result = new T[buffer.Length];
            MemoryMarshal.Cast<byte, T>(byteData).CopyTo(new Span<T>(result));
            return result;
        }

        /// <summary>
        /// Gets the underlying WebGPUMemoryBuffer from an ILGPU MemoryBuffer.
        /// </summary>
        private static WebGPUMemoryBuffer GetWebGPUBuffer(MemoryBuffer buffer)
        {
            var iView = (IArrayView)buffer;
            if (iView.Buffer is WebGPUMemoryBuffer webGpuBuffer)
                return webGpuBuffer;
            throw new InvalidOperationException("CopyToHostAsync is only supported for WebGPU-backed buffers. The buffer must be allocated on a WebGPUAccelerator.");
        }
    }
}
