# WGSL Expert Reference: Syntax & Typing
## 1. Strict Typing (NO IMPLICIT CASTS)
WGSL does not allow implicit conversion between data types.
- **BAD (HLSL style):** `let x: f32 = 1;` (Error: mismatch i32 and f32)
- **BAD (Mixed Math):** `let y = x + 1;` (Error: cannot add f32 and i32)
- **GOOD:** `let x: f32 = 1.0;`
- **GOOD:** `let y = x + f32(1);`

## 2. Casting Syntax
- **Float to Int:** `i32(float_val)`
- **Int to Float:** `f32(int_val)`
- **Bitcast (Reinterpret Bits):** `bitcast<f32>(int_val)` (Essential for low-level ILGPU ops)
- **Bool to Int:** `u32(bool_val)` (Returns 1u or 0u)

## 3. Vector Constructors
- **HLSL:** `float3(1, 2, 3)` -> **WGSL:** `vec3<f32>(1.0, 2.0, 3.0)`
- **HLSL:** `int2(1, 1)` -> **WGSL:** `vec2<i32>(1, 1)`
- **Splatting:** `vec3<f32>(0.0)` creates `(0.0, 0.0, 0.0)`

## 4. Address Spaces (The "Ptr" Requirement)
Every pointer MUST have an address space.
- **Function Local:** `var<function> temp: i32;` (pointers are `ptr<function, i32>`)
- **Private Global:** `var<private> stack_ptr: i32;`
- **Workgroup (Shared):** `var<workgroup> shared_mem: array<i32, 64>;`
- **Storage Buffer:** `var<storage, read_write> buffer: array<i32>;`

## 5. Function Name Hallucination Guard
The agent often defaults to HLSL names. Use this lookup table:

| HLSL / C# Math | WGSL Equivalent | Note |
| :--- | :--- | :--- |
| `lerp(a, b, t)` | `mix(a, b, t)` | Linear interpolation |
| `frac(x)` | `fract(x)` | Fractional part |
| `fmod(x, y)` | `x % y` | Floating point modulo supported |
| `rsqrt(x)` | `inverseSqrt(x)` | |
| `ddx(v)` | `dpdx(v)` | Derivative x |
| `ddy(v)` | `dpdy(v)` | Derivative y |
| `saturate(x)` | `clamp(x, 0.0, 1.0)` | No built-in saturate |
| `mul(m, v)` | `m * v` | Standard operator |
| `discard` | `discard;` | Keyword, not function |

## 6. Atomic Operations
Atomic operations only work on `atomic<i32>` or `atomic<u32>` types in `storage` or `workgroup` memory.
- **Load:** `atomicLoad(&ptr)`
- **Store:** `atomicStore(&ptr, val)`
- **Add:** `atomicAdd(&ptr, val)`
- **Exchange:** `atomicExchange(&ptr, val)`
- **CompareExchange:** `atomicCompareExchangeWeak(&ptr, compare, value)` (Returns struct `{old_value, exchanged}`)

