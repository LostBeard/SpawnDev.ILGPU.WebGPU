# SpawnDev.ILGPU.WebGPU

[![NuGet](https://img.shields.io/nuget/v/SpawnDev.ILGPU.WebGPU.svg)](https://www.nuget.org/packages/SpawnDev.ILGPU.WebGPU)

**Run ILGPU kernels directly in the browser using WebGPU!**

SpawnDev.ILGPU.WebGPU is a WebGPU backend for [ILGPU](https://github.com/m4rs-mt/ILGPU) that enables GPU-accelerated compute in Blazor WebAssembly applications. Write your GPU kernels once in C# and run them on any WebGPU-capable browser.

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
using SpawnDev.ILGPU.WebGPU;

// Initialize WebGPU context
var context = Context.Create(builder => builder.WebGPU());
var accelerator = context.GetPreferredDevice(preferCPU: false)
    .CreateAccelerator(context);

// Load and run a kernel
var kernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<float>>(MyKernel);

using var buffer = accelerator.Allocate1D<float>(1024);
kernel((int)buffer.Length, buffer.View);
accelerator.Synchronize();

static void MyKernel(Index1D index, ArrayView<float> data)
{
    data[index] = index;
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

## License

This project is licensed under the same terms as ILGPU. See [LICENSE](LICENSE) for details.

## Resources

- [ILGPU Documentation](https://ilgpu.net/)
- [WebGPU Specification](https://www.w3.org/TR/webgpu/)
- [SpawnDev.BlazorJS](https://github.com/LostBeard/SpawnDev.BlazorJS)
