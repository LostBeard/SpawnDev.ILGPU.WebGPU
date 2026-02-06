# SpawnDev.ILGPU.WebGPU

[![NuGet](https://img.shields.io/nuget/v/SpawnDev.ILGPU.WebGPU.svg)](https://www.nuget.org/packages/SpawnDev.ILGPU.WebGPU)

**Run [ILGPU](https://github.com/m4rs-mt/ILGPU) kernels directly in the browser using WebGPU!**  
Write GPU compute shaders in C# and compile them to WGSL automatically.

## Features

- **ILGPU-compatible** - Use familiar ILGPU APIs (`ArrayView`, `Index1D/2D/3D`, math intrinsics, etc.)
- **WGSL transpilation** - C# kernels are automatically compiled to WebGPU Shading Language (WGSL)
- **64-bit Emulation** - Support for `double` (f64) and `long` (i64) types via emulated WGSL logic
- **Perturbation Theory** - Support for ultra-deep Mandelbrot zooms (~10^26) using hybrid CPU/GPU algorithms
- **Blazor WebAssembly** - Seamless integration via [SpawnDev.BlazorJS](https://github.com/LostBeard/SpawnDev.BlazorJS)
- **Shared memory & atomics** - Supports static/dynamic workgroup memory, barriers, and atomic operations
- **No native dependencies** - Entirely written in C#

## Installation

```bash
dotnet add package SpawnDev.ILGPU.WebGPU
```

### 1. Configure Program.cs

SpawnDev.ILGPU.WebGPU requires [SpawnDev.BlazorJS](https://github.com/LostBeard/SpawnDev.BlazorJS) for WebGPU interop.

```csharp
using SpawnDev.BlazorJS;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Add BlazorJS services
builder.Services.AddBlazorJSRuntime();

await builder.Build().BlazorJSRunAsync();
```

### 2. Using ILGPU with WebGPU

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
using var accelerator = await device.CreateWebGPUAcceleratorAsync(0);

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
- View [Live Demo](https://lostbeard.github.io/SpawnDev.ILGPU.WebGPU/)

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

## Test Coverage

**95 tests** covering all core ILGPU features supported by WebGPU.

### Coverage by Area

| Area | What's Tested | Status |
|------|---------------|--------|
| **Memory** | Allocation, transfer, copy, views | ✅ Complete |
| **Indexing** | 1D, 2D, 3D kernels, boundary conditions | ✅ Complete |
| **Arithmetic** | +, -, *, /, %, negation, complex expressions | ✅ Complete |
| **Bitwise** | AND, OR, XOR, NOT, shifts (<<, >>) | ✅ Complete |
| **Math Functions** | sin, cos, tan, exp, log, sqrt, pow, abs, min, max | ✅ Complete |
| **Trigonometric** | sin, cos, tan, asin, acos, atan, sinh, cosh, tanh | ✅ Complete |
| **Atomics** | Add, Min, Max, CompareExchange, Xor | ✅ Complete |
| **Control Flow** | if/else, loops, nested, short-circuit | ✅ Complete |
| **Structs** | Simple, nested, with arrays | ✅ Complete |
| **Type Casting** | float↔int, uint, mixed precision | ✅ Complete |
| **64-bit Emulation** | Support for `double` and `long` via Software Emulation | ✅ Complete |
| **GPU Patterns** | Stencil, reduction, matrix multiply, lerp, smoothstep | ✅ Complete |
| **Shared Memory** | Static and Dynamic workgroup memory, length extraction | ✅ Complete |
| **Synchronization** | Barriers, atomic reduction | ✅ Complete |
| **Special Values** | NaN, Infinity detection | ✅ Complete |
| **Scalability** | 65K+ elements, 1M element stress test | ✅ Complete |

### Not Supported (Hardware/Spec Limitations)

| Feature | Reason |
|---------|--------|
| **Subgroups/Warps** | Browser WebGPU extension not available |

## Browser Requirements

WebGPU is required. Supported browsers:
- Chrome 113+
- Edge 113+
- Firefox Nightly (with `dom.webgpu.enabled` flag)

## Configuration

### 64-bit Emulation

WebGPU hardware typically only supports 32-bit float and integer operations. SpawnDev.ILGPU.WebGPU provides software emulation for 64-bit types (`double`/f64 and `long`/i64) via the `WebGPUBackendOptions` configuration.

**Configure when creating the accelerator:**

```csharp
using SpawnDev.ILGPU.WebGPU.Backend;

// Create options with 64-bit emulation enabled
var options = new WebGPUBackendOptions { EnableF64Emulation = true };

// Pass options when creating the accelerator
using var accelerator = await device.CreateAcceleratorAsync(context, options);
```

Or use the context extension method:

```csharp
var options = new WebGPUBackendOptions { EnableF64Emulation = true };
using var accelerator = await context.CreateWebGPUAcceleratorAsync(0, options);
```

**Available Options:**

| Option | Default | Description |
|--------|---------|-------------|
| `EnableF64Emulation` | `false` | Enable 64-bit float (`double`) emulation via `vec2<f32>` |
| `EnableI64Emulation` | `false` | Enable 64-bit integer (`long`) emulation via `vec2<u32>` |

> **Note:** Use `WebGPUBackendOptions` when creating an accelerator to configure 64-bit emulation per-instance.

## Known Limitations

- Subgroups extension not available in all browsers
- **FP64 Precision**: Native FP64 (`double`) is not supported by most WebGPU hardware. While this library provides emulation, extreme zoom levels (beyond ~10^12) may require **Perturbation Theory** to avoid artifacts. This library includes built-in support for hybrid CPU/GPU perturbation rendering in the demo.

## Async Synchronization

In Blazor WebAssembly, the main thread cannot block. Use `SynchronizeAsync()` instead of `Synchronize()`:

```csharp
// ❌ Don't use - non-blocking in Blazor WASM
accelerator.Synchronize();

// ✅ Use async version
await accelerator.SynchronizeAsync();
```

The standard `Synchronize()` method will log a warning and return immediately without waiting.

## Blazor WebAssembly Configuration

When publishing your Blazor WebAssembly application, specific MSBuild properties are required in your `.csproj` to ensure ILGPU functions correctly in a production environment:

```xml
<PropertyGroup>
  <!-- Disable IL trimming to preserve ILGPU kernel methods and reflection metadata -->
  <PublishTrimmed>false</PublishTrimmed>
  <!-- Disable AOT compilation - ILGPU requires IL reflection to work -->
  <RunAOTCompilation>false</RunAOTCompilation>
</PropertyGroup>
```

### Why are these required?

- **`PublishTrimmed = false`**: ILGPU uses reflection-like techniques to extract information from kernel methods at runtime. The standard .NET IL Linker (trimmer) may remove essential methods or metadata if it cannot statically determine their usage, leading to `MissingMethodException`.
- **`RunAOTCompilation = false`**: The ILGPU frontend performs dynamic analysis of IL code which is currently incompatible with Blazor WebAssembly AOT compilation.

## License

This project is licensed under the same terms as ILGPU. See [LICENSE](LICENSE) for details.

## Resources

- [ILGPU Documentation](https://ilgpu.net/)
- [WebGPU Specification](https://www.w3.org/TR/webgpu/)
- [SpawnDev.BlazorJS](https://github.com/LostBeard/SpawnDev.BlazorJS)
