// ---------------------------------------------------------------------------------------
//                               SpawnDev.ILGPU.WebGPU
//                 WebGPU Compute Library for Blazor WebAssembly
//
// File: WebGPUAcceleratorExtensions.cs
// ---------------------------------------------------------------------------------------

namespace SpawnDev.ILGPU.WebGPU
{
    /// <summary>
    /// Extension methods for WebGPUAccelerator.
    /// </summary>
    public static class WebGPUAcceleratorExtensions
    {
        /// <summary>
        /// Asynchronously waits for all submitted GPU work to complete.
        /// </summary>
        /// <remarks>
        /// In Blazor WebAssembly, blocking synchronization is not possible.
        /// Use this async method instead of Synchronize() to wait for GPU completion.
        /// </remarks>
        /// <param name="accelerator">The WebGPU accelerator.</param>
        /// <returns>A task that completes when all GPU work is done.</returns>
        public static async Task SynchronizeAsync(this WebGPUAccelerator accelerator)
        {
            var queue = accelerator.NativeAccelerator.Queue;
            if (queue != null)
            {
                await queue.OnSubmittedWorkDone();
            }
        }

        /// <summary>
        /// Asynchronously waits for all submitted GPU work to complete on the native accelerator.
        /// </summary>
        /// <param name="accelerator">The native WebGPU accelerator.</param>
        /// <returns>A task that completes when all GPU work is done.</returns>
        public static async Task SynchronizeAsync(this WebGPUNativeAccelerator accelerator)
        {
            var queue = accelerator.Queue;
            if (queue != null)
            {
                await queue.OnSubmittedWorkDone();
            }
        }

        /// <summary>
        /// Asynchronously waits for all submitted GPU work to complete.
        /// Works with the ILGPU Accelerator base type when it's a WebGPUAccelerator.
        /// </summary>
        /// <param name="accelerator">The ILGPU accelerator.</param>
        /// <returns>A task that completes when all GPU work is done.</returns>
        public static async Task SynchronizeAsync(this global::ILGPU.Runtime.Accelerator accelerator)
        {
            if (accelerator is WebGPUAccelerator webGpuAccelerator)
            {
                await webGpuAccelerator.SynchronizeAsync();
            }
            else
            {
                // For non-WebGPU accelerators, use synchronous method
                accelerator.Synchronize();
            }
        }
    }
}
