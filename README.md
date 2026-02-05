# SpawnDev.ILGPU.WebGPU

[![NuGet](https://img.shields.io/nuget/v/SpawnDev.ILGPU.WebGPU.svg)](https://www.nuget.org/packages/SpawnDev.ILGPU.WebGPU)

**Run [ILGPU](https://github.com/m4rs-mt/ILGPU) kernels directly in the browser using WebGPU!**  
Write GPU compute shaders in C# and compile them to WGSL automatically.

## Features

- **ILGPU-compatible** - Use familiar ILGPU APIs (`ArrayView`, `Index1D/2D/3D`, math intrinsics, etc.)
- **WGSL transpilation** - C# kernels are automatically compiled to WebGPU Shading Language (WGSL)
- **Blazor WebAssembly** - Seamless integration via [SpawnDev.BlazorJS](https://github.com/LostBeard/SpawnDev.BlazorJS)
- **Shared memory & atomics** - Supports workgroup shared memory, barriers, and atomic operations
- **No native dependencies** - Entirely written in C#

## Installation

```bash
dotnet add package SpawnDev.ILGPU.WebGPU
```

## Quick Start

```csharp
using ILGPU;
using ILGPU.Runtime;
using SpawnDev.ILGPU.WebGPU;

// Initialize ILGPU context with WebGPU backend
var builder = Context.Create();
await builder.WebGPUAsync();
using var context = builder.ToContext();

// Get WebGPU device and create accelerator
var devices = context.GetWebGPUDevices();
var device = devices[0];
using var accelerator = await device.CreateAcceleratorAsync(context);

// Allocate buffers
int length = 64;
var a = Enumerable.Range(0, length).Select(i => (float)i).ToArray();
var b = Enumerable.Range(0, length).Select(i => (float)i * 2.0f).ToArray();

using var bufA = accelerator.Allocate1D(a);
using var bufB = accelerator.Allocate1D(b);
using var bufC = accelerator.Allocate1D<float>(length);

// Load and execute kernel
var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<float>, ArrayView<float>, ArrayView<float>>(VectorAddKernel);
kernel((Index1D)length, bufA.View, bufB.View, bufC.View);

// Wait for GPU to complete (async required in Blazor WASM)
await accelerator.SynchronizeAsync();

// Read back the results
var results = await bufC.CopyToHostAsync();

// Define the kernel
static void VectorAddKernel(Index1D index, ArrayView<float> a, ArrayView<float> b, ArrayView<float> c)
{
    c[index] = a[index] + b[index];
}
```

## Demo Application

The demo application is located in [SpawnDev.ILGPU.WebGPU.Demo](SpawnDev.ILGPU.WebGPU.Demo) and showcases:
- GPU compute tasks running in Blazor WebAssembly
- Interactive Mandelbrot renderer
- Comprehensive unit tests at `/tests`

### Running the Demo

```bash
cd SpawnDev.ILGPU.WebGPU.Demo
dotnet run
```

Navigate to `https://localhost:5181` in a WebGPU-capable browser (Chrome, Edge, or Firefox Nightly).

## Testing

### Browser Tests
Start the demo app and navigate to `/tests` to run the unit test suite.

### Automated Tests (Playwright)
```bash
# Windows
_test.bat

# Linux/macOS
./_test.sh
```

The PlaywrightTestRunner runs tests in a headless browser. To view the browser during tests, uncomment `Environment.SetEnvironmentVariable("HEADED", "1");` in `PlaywrightTestRunner/GlobalSetup.cs`.

## Browser Requirements

WebGPU is required. Supported browsers:
- Chrome 113+
- Edge 113+
- Firefox Nightly (with `dom.webgpu.enabled` flag)

## Known Limitations

- Some advanced ILGPU features may not yet be supported
- Subgroups extension not available in all browsers
- Dynamic shared memory requires Pipeline Overridable Constants (not yet implemented)

## Async Synchronization

In Blazor WebAssembly, the main thread cannot block. Use `SynchronizeAsync()` instead of `Synchronize()`:

```csharp
// ❌ Don't use - non-blocking in Blazor WASM
accelerator.Synchronize();

// ✅ Use async version
await accelerator.SynchronizeAsync();
```

The standard `Synchronize()` method will log a warning and return immediately without waiting.

## License

This project is licensed under the same terms as ILGPU. See [LICENSE](LICENSE) for details.

## Resources

- [ILGPU Documentation](https://ilgpu.net/)
- [WebGPU Specification](https://www.w3.org/TR/webgpu/)
- [SpawnDev.BlazorJS](https://github.com/LostBeard/SpawnDev.BlazorJS)
