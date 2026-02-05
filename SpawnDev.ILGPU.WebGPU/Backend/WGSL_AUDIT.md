# WGSL Code Gen Audit

## 1. Structure Member Alignment (std140 / std430)
The current generator avoids most alignment issues by **flattening** types in `GetBufferElementType`.
- It recursively drills down into structures until it finds a primitive.
- Result: Most buffers are declared as `array<f32>` or `array<i32>`.
- **Pros**: Avoids WGSL `vec3` padding issues (16-byte alignment vs 12-byte packed C# data).
- **Cons**: Requires index arithmetic adjustments. If ILGPU IR `LoadElementAddress` provides an index in "Elements", but the buffer is declared as "Primitives", we must multiply the index by the struct size (in primitives).
- **Risk**: **HIGH**. If `offset` in `LoadElementAddress` is an element index, accessing `array<f32>` at that index gets the wrong data for any struct > 1 primitive.

## 2. 64-bit Integer Packing
- The generator detects `Int64` / `LongIndex` views and attempts to map them to `i32` pairs.
- **Implementation**: Hardcoded field indices (1/2 for Length, 3/4 for Width, etc.).
- **WGSL Compatibility**: Uses `array<i32>` for strides. Returns `0` for high bits.
- **Validity**: Valid for values < 2^31.
- **Issue**: If actual 64-bit values are needed (e.g. large arrays), this logic truncates.
- **Recommendation**: Ensure `shader-int64` feature is checked or use `vec2<u32>` for true 64-bit support if needed.

## 3. Storage Buffer vs Uniform
- Strides are passed as `var<storage, read>`.
- **correctness**: Correct. `storage` is flexible. `uniform` could be used for small constant data like strides for performance, but `storage` is safer for varying sizes.

## 4. Bind Group Layout
- Current uses `@group(0) @binding(N)`.
- **correctness**: Valid. Simple monotonically increasing bindings.

## 5. ArrayView3D Stride Logic
- The custom logic for Field 9 (StrideY) and Field 11 (StrideZ) maps to `stride[0]` (`width`) and `stride[0]*stride[1]` (`width*height`).
- **correctness**: This assumes `DenseXY` packing. 
- **Conflict**: If the user passes a strided view (e.g. `Slice` of 3D array), the expected strides are NOT `width` and `width*height`. They should be loaded from the stride buffer values if provided.
- **Bug**: The generator *hardcodes* calculation of Dense strides from Width/Height instead of using the values passed in the stride buffer (which comes from `ExtractDimensions`).
- **Fix**: The stride buffer values (if passed correctly from `ExtractDimensions`) should be used directly if possible, or `ExtractDimensions` should extract actual strides, not just logical dimensions. `Ensure stride buffer contains STRIDES, not DIMENSIONS.`

**Critical Logic Flaw Identified**:
`WebGPUAccelerator.cs` `ExtractDimensionsFromView` extracts `X`, `Y`, `Z` (Dimensions).
`WGSLKernelFunctionGenerator.cs` calculates strides from these dimensions: `width * height`.
This **forces** Dense layout.
If `ArrayView3D` is a subview/slice, `dimensions` are small, but `strides` should be large (parent array strides).
**Current implementation breaks slicing.**
For the *Failing Test* (`Allocate3DDenseXY`), it *should* work because it is dense.
However, if `ArrayView3D` expects `Field 9` to be StrideY.
My code: `let {target} = {width};` (StrideY = Width).
This is correct for DenseXY.

## 6. Type Mismatch in `GetBufferElementType`
- If `ArrayView<Vector3>` is used. IR Type is `View<Vector3>`.
- `GetBufferElementType` returns `float`.
- WGSL `var ... : array<f32>`.
- IR `LoadElementAddress` source is `View<Vector3>`. Offset is `int`.
- Generator emits: `&param[offset]`.
- Mismatch: `param` is float array. `offset` is Vector3 index.
- **IMMEDIATE FIX REQUIRED**: `GetBufferElementType` should NOT unwrap structs unless they are handled by special logic. It should usually preserve the struct type, OR the generator must scale the offset.
