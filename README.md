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

## Tests
- Playwright tests are located in the [PlaywrightTestRunner](PlaywrightTestRunner) directory. 
- Build and run Playwright .Net unit tests using `_test.bat` or `_test.sh`.
- Tests are run in a headless browser. To enable the browser to be visible, modify `PlaywrightTestRunner/GlobalSetup.cs` and uncomment the line `Environment.SetEnvironmentVariable("HEADED", "1");`.

