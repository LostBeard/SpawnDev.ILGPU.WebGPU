# SpawnDev.ILGPU.WebGPU
SpawnDev.ILGPU.WebGPU provides WebGPU support for [ILGPU](https://github.com/m4rs-mt/ILGPU), enabling GPU compute in Blazor WebAssembly applications.

## Features
- GPU compute in Blazor WebAssembly applications
- WebGPU backend for ILGPU
- JIT (just-in-time) compiler for high-performance GPU programs written in .Net-based languages
- Entirely written in C# without any native dependencies
- Offers the flexibility and the convenience of C++ AMP on the one hand and the high performance of Cuda programs on the other hand
- Functions in the scope of kernels do not have to be annotated (default C# functions) and are allowed to work on value types
- All kernels (including all hardware features like shared memory and atomics) can be executed and debugged on the CPU using the integrated multi-threaded CPU accelerator

## SpawnDev.ILGPU.WebGPU.Demo
- The demo application is located in the [SpawnDev.ILGPU.WebGPU.Demo](SpawnDev.ILGPU.WebGPU.Demo) directory.
- The unit test app tests can be ran by starting the SpawnDev.ILGPU.WebGPU.Demo project and goiong to the '/tests' page.
- The demo application showcases the capabilities of SpawnDev.ILGPU.WebGPU by running various GPU compute tasks in a Blazor WebAssembly environment.
- The PlaywrightTestRunner can be used to run the unit tests in a headless browser environment.

## PlaywrightTestRunner
- PlaywrightTestRunner is located in the [PlaywrightTestRunner](PlaywrightTestRunner) directory and allows running unit tests in a headless browser environment.
- Build and run Playwright .Net unit tests using `_test.bat` or `_test.sh`.
- Tests are run in a headless browser. To enable the browser to be visible, modify `PlaywrightTestRunner/GlobalSetup.cs` and uncomment the line `Environment.SetEnvironmentVariable("HEADED", "1");`.

