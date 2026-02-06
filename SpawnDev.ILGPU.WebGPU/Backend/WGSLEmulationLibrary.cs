// ---------------------------------------------------------------------------------------
//                                 SpawnDev.ILGPU.WebGPU
//                        Copyright (c) 2024 SpawnDev Project
//
// File: WGSLEmulationLibrary.cs
//
// Provides WGSL helper functions for f64 and i64 emulation.
// f64: Double-float technique using vec2<f32> (high + low)
// i64: Double-word technique using vec2<u32> (low + high)
// ---------------------------------------------------------------------------------------

namespace SpawnDev.ILGPU.WebGPU.Backend
{
    /// <summary>
    /// Provides WGSL code strings for 64-bit type emulation functions.
    /// These functions are prepended to the shader when emulation is used.
    /// </summary>
    public static class WGSLEmulationLibrary
    {
        #region f64 Emulation (Double-Float using vec2<f32>)

        /// <summary>
        /// WGSL type alias for emulated f64.
        /// </summary>
        public const string F64TypeAlias = "alias f64 = vec2<f32>;";

        /// <summary>
        /// WGSL helper functions for f64 emulation.
        /// Uses the double-float technique where f64 = high + low.
        /// </summary>
        public const string F64Functions = @"
// ============================================================================
// f64 Emulation Functions (Double-Float: vec2<f32> where x=high, y=low)
// ============================================================================

// --- IEEE 754 double bits to double-float conversion ---
// When CPU sends a raw 64-bit double, we receive it as vec2<u32> (lo, hi bits)
// This function converts those raw bits to our double-float representation
fn f64_from_ieee754_bits(lo: u32, hi: u32) -> f64 {
    // Extract IEEE 754 components from the 64-bit double
    let sign_bit = (hi >> 31u) & 1u;
    let exponent = (hi >> 20u) & 0x7FFu; // 11 bits
    let mantissa_hi = hi & 0xFFFFFu; // top 20 bits of 52-bit mantissa
    let mantissa_lo = lo; // bottom 32 bits of mantissa
    
    // Handle special cases
    if (exponent == 0u && mantissa_hi == 0u && mantissa_lo == 0u) {
        // Zero
        return f64(0.0, 0.0);
    }
    if (exponent == 0x7FFu) {
        // Infinity or NaN - return max or 0
        return f64(0.0, 0.0);
    }
    
    // Convert to f32 (with precision loss)
    // The key is to get the value into our double-float representation
    let exp_bias: i32 = 1023; // IEEE 754 double bias
    let exp_val: i32 = i32(exponent) - exp_bias;
    
    // Build the f32 representation
    let f32_exp_bias: i32 = 127;
    let f32_exp: i32 = exp_val + f32_exp_bias;
    
    // Check if exponent fits in f32 range (-126 to 127)
    if (f32_exp <= 0 || f32_exp >= 255) {
        // Overflow or underflow for f32
        let val_approx = f32(hi) * 0.00000000023283064; // rough approximation
        return f64(val_approx, 0.0);
    }
    
    // Take top 23 bits of mantissa for f32
    let f32_mantissa = mantissa_hi >> 0u; // We only have 20 bits in hi, need to shift
    let f32_bits = (sign_bit << 31u) | (u32(f32_exp) << 23u) | (mantissa_hi << 3u);
    let val = bitcast<f32>(f32_bits);
    
    return f64(val, 0.0);
}

// Store f64 back to IEEE 754 bits for buffer write (approximate - loses precision)
fn f64_to_ieee754_bits(v: f64) -> vec2<u32> {
    let val = v.x + v.y; // Combine to single f32
    if (val == 0.0) {
        return vec2<u32>(0u, 0u);
    }
    
    let f32_bits = bitcast<u32>(val);
    let sign = (f32_bits >> 31u) & 1u;
    let f32_exp = (f32_bits >> 23u) & 0xFFu;
    let f32_mantissa = f32_bits & 0x7FFFFFu;
    
    // Convert f32 exponent to f64 exponent
    let f32_bias: i32 = 127;
    let f64_bias: i32 = 1023;
    let exp_val: i32 = i32(f32_exp) - f32_bias;
    let f64_exp: u32 = u32(exp_val + f64_bias);
    
    // Extend 23-bit mantissa to 52-bit (left-shift, zero-fill low bits)
    let mantissa_hi = f32_mantissa >> 3u; // top 20 bits
    let mantissa_lo = (f32_mantissa & 0x7u) << 29u; // bottom 3 bits shifted up
    
    let hi = (sign << 31u) | (f64_exp << 20u) | mantissa_hi;
    let lo = mantissa_lo;
    
    return vec2<u32>(lo, hi);
}

// Create f64 from a single f32 value
fn f64_from_f32(v: f32) -> f64 {
    return f64(v, 0.0);
}

// Convert f64 back to f32 (loses precision)
fn f64_to_f32(v: f64) -> f32 {
    return v.x + v.y;
}

// Create f64 from high and low components
fn f64_new(hi: f32, lo: f32) -> f64 {
    return f64(hi, lo);
}

// f64 negation
fn f64_neg(a: f64) -> f64 {
    return f64(-a.x, -a.y);
}

// f64 addition using Dekker's algorithm
fn f64_add(a: f64, b: f64) -> f64 {
    let s = a.x + b.x;
    let v = s - a.x;
    let e = (a.x - (s - v)) + (b.x - v) + a.y + b.y;
    let z_hi = s + e;
    let z_lo = e - (z_hi - s);
    return f64(z_hi, z_lo);
}

// f64 subtraction
fn f64_sub(a: f64, b: f64) -> f64 {
    return f64_add(a, f64_neg(b));
}

// Helper: split f32 into high and low parts for multiplication
fn f64_split(a: f32) -> vec2<f32> {
    let c = 4097.0 * a;  // 2^12 + 1
    let a_hi = c - (c - a);
    let a_lo = a - a_hi;
    return vec2<f32>(a_hi, a_lo);
}

// Helper: two-product algorithm (exact a*b = p + e)
fn f64_two_prod(a: f32, b: f32) -> f64 {
    let p = a * b;
    let a_s = f64_split(a);
    let b_s = f64_split(b);
    let e = ((a_s.x * b_s.x - p) + a_s.x * b_s.y + a_s.y * b_s.x) + a_s.y * b_s.y;
    return f64(p, e);
}

// f64 multiplication
fn f64_mul(a: f64, b: f64) -> f64 {
    let p = f64_two_prod(a.x, b.x);
    let e = a.x * b.y + a.y * b.x + p.y;
    let z_hi = p.x + e;
    let z_lo = e - (z_hi - p.x);
    return f64(z_hi, z_lo);
}

// f64 division (approximate)
fn f64_div(a: f64, b: f64) -> f64 {
    let q = a.x / b.x;
    let r = f64_sub(a, f64_mul(b, f64_from_f32(q)));
    let q2 = r.x / b.x;
    return f64_add(f64_from_f32(q), f64_from_f32(q2));
}

// f64 comparison: less than
fn f64_lt(a: f64, b: f64) -> bool {
    return (a.x < b.x) || (a.x == b.x && a.y < b.y);
}

// f64 comparison: less than or equal
fn f64_le(a: f64, b: f64) -> bool {
    return (a.x < b.x) || (a.x == b.x && a.y <= b.y);
}

// f64 comparison: greater than
fn f64_gt(a: f64, b: f64) -> bool {
    return (a.x > b.x) || (a.x == b.x && a.y > b.y);
}

// f64 comparison: greater than or equal
fn f64_ge(a: f64, b: f64) -> bool {
    return (a.x > b.x) || (a.x == b.x && a.y >= b.y);
}

// f64 comparison: equal
fn f64_eq(a: f64, b: f64) -> bool {
    return a.x == b.x && a.y == b.y;
}

// f64 comparison: not equal
fn f64_ne(a: f64, b: f64) -> bool {
    return a.x != b.x || a.y != b.y;
}

// f64 absolute value
fn f64_abs(a: f64) -> f64 {
    if (a.x < 0.0 || (a.x == 0.0 && a.y < 0.0)) {
        return f64_neg(a);
    }
    return a;
}

// f64 minimum
fn f64_min(a: f64, b: f64) -> f64 {
    if (f64_lt(a, b)) { return a; }
    return b;
}

// f64 maximum
fn f64_max(a: f64, b: f64) -> f64 {
    if (f64_gt(a, b)) { return a; }
    return b;
}
";

        #endregion

        #region i64 Emulation (Double-Word using vec2<u32>)

        /// <summary>
        /// WGSL type alias for emulated i64.
        /// x = low 32 bits, y = high 32 bits (little-endian style)
        /// </summary>
        public const string I64TypeAlias = "alias i64 = vec2<u32>;";

        /// <summary>
        /// WGSL type alias for emulated u64.
        /// </summary>
        public const string U64TypeAlias = "alias u64 = vec2<u32>;";

        /// <summary>
        /// WGSL helper functions for i64/u64 emulation.
        /// Uses double-word technique where i64 = (low, high).
        /// </summary>
        public const string I64Functions = @"
// ============================================================================
// i64/u64 Emulation Functions (Double-Word: vec2<u32> where x=low, y=high)
// ============================================================================

// Create i64 from i32 (sign-extend)
fn i64_from_i32(v: i32) -> i64 {
    let lo = bitcast<u32>(v);
    let hi = select(0u, 0xFFFFFFFFu, v < 0);
    return i64(lo, hi);
}

// Create u64 from u32
fn u64_from_u32(v: u32) -> u64 {
    return u64(v, 0u);
}

// Convert i64 to i32 (truncate)
fn i64_to_i32(v: i64) -> i32 {
    return bitcast<i32>(v.x);
}

// Convert u64 to u32 (truncate)
fn u64_to_u32(v: u64) -> u32 {
    return v.x;
}

// Create i64 from low and high u32 parts
fn i64_new(lo: u32, hi: u32) -> i64 {
    return i64(lo, hi);
}

// i64/u64 addition with carry
fn i64_add(a: i64, b: i64) -> i64 {
    let lo = a.x + b.x;
    let carry = select(0u, 1u, lo < a.x);
    let hi = a.y + b.y + carry;
    return i64(lo, hi);
}

// i64/u64 subtraction with borrow
fn i64_sub(a: i64, b: i64) -> i64 {
    let borrow = select(0u, 1u, a.x < b.x);
    let lo = a.x - b.x;
    let hi = a.y - b.y - borrow;
    return i64(lo, hi);
}

// i64 negation (two's complement)
fn i64_neg(a: i64) -> i64 {
    let inv = i64(~a.x, ~a.y);
    return i64_add(inv, i64(1u, 0u));
}

// u64 multiplication (full 64x64 -> 64-bit result, ignoring overflow)
fn u64_mul(a: u64, b: u64) -> u64 {
    // Split into 16-bit parts for WGSL compatibility
    let a_lo = a.x & 0xFFFFu;
    let a_hi = a.x >> 16u;
    let b_lo = b.x & 0xFFFFu;
    let b_hi = b.x >> 16u;
    
    // Partial products
    let p0 = a_lo * b_lo;
    let p1 = a_lo * b_hi;
    let p2 = a_hi * b_lo;
    let p3 = a_hi * b_hi;
    
    // Combine low parts
    let mid = (p0 >> 16u) + (p1 & 0xFFFFu) + (p2 & 0xFFFFu);
    let lo = (p0 & 0xFFFFu) | ((mid & 0xFFFFu) << 16u);
    
    // Combine high parts
    let hi = p3 + (p1 >> 16u) + (p2 >> 16u) + (mid >> 16u) + a.x * b.y + a.y * b.x;
    
    return u64(lo, hi);
}

// i64 multiplication (uses u64_mul internally)
fn i64_mul(a: i64, b: i64) -> i64 {
    let neg_a = (a.y & 0x80000000u) != 0u;
    let neg_b = (b.y & 0x80000000u) != 0u;
    var abs_a = a;
    var abs_b = b;
    if (neg_a) { abs_a = i64_neg(a); }
    if (neg_b) { abs_b = i64_neg(b); }
    var result = u64_mul(abs_a, abs_b);
    if (neg_a != neg_b) { result = i64_neg(result); }
    return result;
}

// Bitwise AND
fn i64_and(a: i64, b: i64) -> i64 {
    return i64(a.x & b.x, a.y & b.y);
}

// Bitwise OR
fn i64_or(a: i64, b: i64) -> i64 {
    return i64(a.x | b.x, a.y | b.y);
}

// Bitwise XOR
fn i64_xor(a: i64, b: i64) -> i64 {
    return i64(a.x ^ b.x, a.y ^ b.y);
}

// Bitwise NOT
fn i64_not(a: i64) -> i64 {
    return i64(~a.x, ~a.y);
}

// Left shift (0 <= shift < 64)
fn i64_shl(a: i64, shift: u32) -> i64 {
    if (shift == 0u) { return a; }
    if (shift >= 64u) { return i64(0u, 0u); }
    if (shift >= 32u) {
        return i64(0u, a.x << (shift - 32u));
    }
    let lo = a.x << shift;
    let hi = (a.y << shift) | (a.x >> (32u - shift));
    return i64(lo, hi);
}

// Logical right shift (0 <= shift < 64)
fn u64_shr(a: u64, shift: u32) -> u64 {
    if (shift == 0u) { return a; }
    if (shift >= 64u) { return u64(0u, 0u); }
    if (shift >= 32u) {
        return u64(a.y >> (shift - 32u), 0u);
    }
    let lo = (a.x >> shift) | (a.y << (32u - shift));
    let hi = a.y >> shift;
    return u64(lo, hi);
}

// Arithmetic right shift (sign-extending)
fn i64_shr(a: i64, shift: u32) -> i64 {
    if (shift == 0u) { return a; }
    let sign = a.y & 0x80000000u;
    if (shift >= 64u) {
        let fill = select(0u, 0xFFFFFFFFu, sign != 0u);
        return i64(fill, fill);
    }
    if (shift >= 32u) {
        // Arithmetic right shift - need to use signed integer then convert back
        let signed_y = bitcast<i32>(a.y);
        let shift_amt = shift - 32u;
        let shifted = signed_y >> shift_amt;
        let lo = bitcast<u32>(shifted);
        let hi = select(0u, 0xFFFFFFFFu, sign != 0u);
        return i64(lo, hi);
    }
    let lo = (a.x >> shift) | (a.y << (32u - shift));
    // Arithmetic right shift on high word
    let signed_y = bitcast<i32>(a.y);
    let shifted = signed_y >> shift;
    let hi = bitcast<u32>(shifted);
    return i64(lo, hi);
}

// Signed comparison: less than
fn i64_lt(a: i64, b: i64) -> bool {
    let a_neg = (a.y & 0x80000000u) != 0u;
    let b_neg = (b.y & 0x80000000u) != 0u;
    if (a_neg && !b_neg) { return true; }
    if (!a_neg && b_neg) { return false; }
    // Same sign: compare as unsigned
    if (a.y != b.y) { return a.y < b.y; }
    return a.x < b.x;
}

// Signed comparison: less than or equal
fn i64_le(a: i64, b: i64) -> bool {
    return i64_lt(a, b) || i64_eq(a, b);
}

// Signed comparison: greater than
fn i64_gt(a: i64, b: i64) -> bool {
    return i64_lt(b, a);
}

// Signed comparison: greater than or equal
fn i64_ge(a: i64, b: i64) -> bool {
    return !i64_lt(a, b);
}

// Comparison: equal
fn i64_eq(a: i64, b: i64) -> bool {
    return a.x == b.x && a.y == b.y;
}

// Comparison: not equal
fn i64_ne(a: i64, b: i64) -> bool {
    return a.x != b.x || a.y != b.y;
}

// Unsigned comparison: less than
fn u64_lt(a: u64, b: u64) -> bool {
    if (a.y != b.y) { return a.y < b.y; }
    return a.x < b.x;
}

// Unsigned comparison: less than or equal
fn u64_le(a: u64, b: u64) -> bool {
    return u64_lt(a, b) || i64_eq(a, b);
}

// Unsigned comparison: greater than
fn u64_gt(a: u64, b: u64) -> bool {
    return u64_lt(b, a);
}

// Unsigned comparison: greater than or equal
fn u64_ge(a: u64, b: u64) -> bool {
    return !u64_lt(a, b);
}

// i64 absolute value
fn i64_abs(a: i64) -> i64 {
    if ((a.y & 0x80000000u) != 0u) {
        return i64_neg(a);
    }
    return a;
}
";

        #endregion

        #region Combined Library

        /// <summary>
        /// Gets the full emulation library based on which features are enabled.
        /// </summary>
        public static string GetEmulationLibrary(bool includeF64, bool includeI64)
        {
            var sb = new System.Text.StringBuilder();

            if (includeF64)
            {
                sb.AppendLine(F64TypeAlias);
                sb.AppendLine(F64Functions);
            }

            if (includeI64)
            {
                sb.AppendLine(I64TypeAlias);
                sb.AppendLine(U64TypeAlias);
                sb.AppendLine(I64Functions);
            }

            return sb.ToString();
        }

        #endregion
    }
}
