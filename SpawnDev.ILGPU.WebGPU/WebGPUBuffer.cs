// ---------------------------------------------------------------------------------------
//                               SpawnDev.ILGPU.WebGPU
//                 WebGPU Compute Library for Blazor WebAssembly
//
// File: WebGPUBuffer.cs
// ---------------------------------------------------------------------------------------

using SpawnDev.BlazorJS.JSObjects;
using System.Runtime.InteropServices;

namespace SpawnDev.ILGPU.WebGPU
{
    /// <summary>
    /// Represents a typed GPU memory buffer in WebGPU.
    /// </summary>
    public sealed class WebGPUBuffer<T> : IDisposable where T : unmanaged
    {
        #region Instance

        private GPUBuffer? _buffer;
        private bool _disposed;

        /// <summary>
        /// Constructs a new WebGPU buffer.
        /// </summary>
        internal WebGPUBuffer(WebGPUAccelerator accelerator, long length)
        {
            Accelerator = accelerator ?? throw new ArgumentNullException(nameof(accelerator));
            Length = length;
            ElementSize = Marshal.SizeOf<T>();
            LengthInBytes = length * ElementSize;

            var device = accelerator.NativeDevice;
            if (device == null)
                throw new InvalidOperationException("GPU device not initialized");

            // Create GPU buffer
            var descriptor = new GPUBufferDescriptor
            {
                Size = (ulong)LengthInBytes,
                Usage = GPUBufferUsage.Storage | GPUBufferUsage.CopySrc | GPUBufferUsage.CopyDst,
                MappedAtCreation = false
            };

            _buffer = device.CreateBuffer(descriptor);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Returns the parent accelerator.
        /// </summary>
        public WebGPUAccelerator Accelerator { get; }

        /// <summary>
        /// Returns the native GPU buffer.
        /// </summary>
        public GPUBuffer? NativeBuffer => _buffer;

        /// <summary>
        /// Returns the number of elements.
        /// </summary>
        public long Length { get; }

        /// <summary>
        /// Returns the element size in bytes.
        /// </summary>
        public int ElementSize { get; }

        /// <summary>
        /// Returns the total size in bytes.
        /// </summary>
        public long LengthInBytes { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Copies data from a host array to the GPU buffer.
        /// </summary>
        public void CopyFromHost(T[] sourceArray, long targetOffset = 0)
        {
            if (_buffer == null)
                throw new ObjectDisposedException(nameof(WebGPUBuffer<T>));
            if (sourceArray.Length > Length - targetOffset)
                throw new ArgumentException("Source array is too large for the buffer");

            var queue = Accelerator.Queue;
            if (queue == null)
                throw new InvalidOperationException("GPU queue not available");

            // Convert to bytes
            var byteArray = new byte[sourceArray.Length * ElementSize];
            var handle = GCHandle.Alloc(sourceArray, GCHandleType.Pinned);
            try
            {
                Marshal.Copy(handle.AddrOfPinnedObject(), byteArray, 0, byteArray.Length);
            }
            finally
            {
                handle.Free();
            }

            queue.WriteBuffer(_buffer, (long)(targetOffset * ElementSize), byteArray);
        }

        /// <summary>
        /// Copies data from the GPU buffer to a host array asynchronously.
        /// </summary>
        public async Task<T[]> CopyToHostAsync(long sourceOffset = 0, long? length = null)
        {
            if (_buffer == null)
                throw new ObjectDisposedException(nameof(WebGPUBuffer<T>));

            var copyLength = length ?? Length - sourceOffset;
            var result = new T[copyLength];

            var device = Accelerator.NativeDevice;
            if (device == null)
                throw new InvalidOperationException("GPU device not initialized");

            // Create a staging buffer for reading
            var stagingSize = copyLength * ElementSize;
            var stagingDescriptor = new GPUBufferDescriptor
            {
                Size = (ulong)stagingSize,
                Usage = GPUBufferUsage.CopyDst | GPUBufferUsage.MapRead,
                MappedAtCreation = false
            };

            using var stagingBuffer = device.CreateBuffer(stagingDescriptor);

            // Create command encoder to copy
            using var encoder = device.CreateCommandEncoder();
            encoder.CopyBufferToBuffer(
                _buffer,
                (ulong)(sourceOffset * ElementSize),
                stagingBuffer,
                0,
                (ulong)stagingSize);

            using var commandBuffer = encoder.Finish();
            Accelerator.Queue?.Submit(new[] { commandBuffer });

            // Map and read
            await stagingBuffer.MapAsync(GPUMapMode.Read);
            var mappedRange = stagingBuffer.GetMappedRange();
            if (mappedRange != null)
            {
                var byteArray = mappedRange.ReadBytes();

                // Convert from bytes
                var handle = GCHandle.Alloc(result, GCHandleType.Pinned);
                try
                {
                    Marshal.Copy(byteArray, 0, handle.AddrOfPinnedObject(), byteArray.Length);
                }
                finally
                {
                    handle.Free();
                }
            }
            stagingBuffer.Unmap();

            return result;
        }

        /// <summary>
        /// Fills the buffer with a value.
        /// </summary>
        public void Fill(T value)
        {
            var data = new T[Length];
            System.Array.Fill(data, value);
            CopyFromHost(data);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            if (_disposed) return;
            _disposed = true;

            _buffer?.Destroy();
            _buffer?.Dispose();
            _buffer = null;
        }

        #endregion
    }
}
