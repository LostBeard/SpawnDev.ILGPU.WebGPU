using System.Runtime.CompilerServices;

namespace SpawnDev.ILGPU.WebGPU.Backend
{
    /// <summary>
    /// Provides WebGPU-specific mathematical intrinsic implementations.
    /// These methods are used as fallbacks during ILGPU-to-WGSL transpilation
    /// when the standard math operations require special handling.
    /// </summary>
    public static class WebGPUIntrinsics
    {
        // Unary float operations

        /// <summary>Returns the absolute value of a float.</summary>
        /// <param name="val">The input value.</param>
        /// <returns>The absolute value.</returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static float Abs(float val) => val < 0 ? -val : val;

        /// <summary>Returns the sign of a float (-1, 0, or 1).</summary>
        /// <param name="val">The input value.</param>
        /// <returns>-1 if negative, 1 if positive, 0 if zero.</returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int Sign(float val) => val > 0 ? 1 : val < 0 ? -1 : 0;

        /// <summary>Rounds a float to the nearest integer value.</summary>
        /// <param name="val">The input value.</param>
        /// <returns>The rounded value.</returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static float Round(float val) => val;

        /// <summary>Truncates a float toward zero.</summary>
        /// <param name="val">The input value.</param>
        /// <returns>The truncated value.</returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static float Truncate(float val) => val;

        // Binary float operations

        /// <summary>Returns the angle whose tangent is the quotient of y and x.</summary>
        /// <param name="y">The y coordinate.</param>
        /// <param name="x">The x coordinate.</param>
        /// <returns>The angle in radians.</returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static float Atan2(float y, float x) => y;

        /// <summary>Returns the larger of two float values.</summary>
        /// <param name="val1">The first value.</param>
        /// <param name="val2">The second value.</param>
        /// <returns>The larger value.</returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static float Max(float val1, float val2) => val1 > val2 ? val1 : val2;

        /// <summary>Returns the smaller of two float values.</summary>
        /// <param name="val1">The first value.</param>
        /// <param name="val2">The second value.</param>
        /// <returns>The smaller value.</returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static float Min(float val1, float val2) => val1 < val2 ? val1 : val2;

        /// <summary>Returns x raised to the power of y.</summary>
        /// <param name="x">The base.</param>
        /// <param name="y">The exponent.</param>
        /// <returns>x raised to the power y.</returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static float Pow(float x, float y) => x;

        // Ternary float operations

        /// <summary>Clamps a float value to the specified range.</summary>
        /// <param name="value">The value to clamp.</param>
        /// <param name="min">The minimum bound.</param>
        /// <param name="max">The maximum bound.</param>
        /// <returns>The clamped value.</returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static float Clamp(float value, float min, float max) => value < min ? min : value > max ? max : value;

        /// <summary>Computes (x * y) + z with a single rounding.</summary>
        /// <param name="x">The first multiplicand.</param>
        /// <param name="y">The second multiplicand.</param>
        /// <param name="z">The addend.</param>
        /// <returns>The fused multiply-add result.</returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static float FusedMultiplyAdd(float x, float y, float z) => x * y + z;

        // Unary int operations

        /// <summary>Returns the absolute value of an int.</summary>
        /// <param name="val">The input value.</param>
        /// <returns>The absolute value.</returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int Abs(int val) => val < 0 ? -val : val;

        /// <summary>Returns the sign of an int (-1, 0, or 1).</summary>
        /// <param name="val">The input value.</param>
        /// <returns>-1 if negative, 1 if positive, 0 if zero.</returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int Sign(int val) => val > 0 ? 1 : val < 0 ? -1 : 0;

        // Binary int operations

        /// <summary>Returns the larger of two int values.</summary>
        /// <param name="val1">The first value.</param>
        /// <param name="val2">The second value.</param>
        /// <returns>The larger value.</returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int Max(int val1, int val2) => val1 > val2 ? val1 : val2;

        /// <summary>Returns the smaller of two int values.</summary>
        /// <param name="val1">The first value.</param>
        /// <param name="val2">The second value.</param>
        /// <returns>The smaller value.</returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int Min(int val1, int val2) => val1 < val2 ? val1 : val2;

        // Ternary int operations

        /// <summary>Clamps an int value to the specified range.</summary>
        /// <param name="value">The value to clamp.</param>
        /// <param name="min">The minimum bound.</param>
        /// <param name="max">The maximum bound.</param>
        /// <returns>The clamped value.</returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int Clamp(int value, int min, int max) => value < min ? min : value > max ? max : value;

        // Rsqrt and Rcp for XMath compatibility

        /// <summary>Returns the reciprocal square root (1/sqrt(x)) of a float.</summary>
        /// <param name="val">The input value.</param>
        /// <returns>The reciprocal square root.</returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static float Rsqrt(float val) => 1.0f / MathF.Sqrt(val);

        /// <summary>Returns the reciprocal square root (1/sqrt(x)) of a double.</summary>
        /// <param name="val">The input value.</param>
        /// <returns>The reciprocal square root.</returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static double Rsqrt(double val) => 1.0 / Math.Sqrt(val);

        /// <summary>Returns the reciprocal (1/x) of a float.</summary>
        /// <param name="val">The input value.</param>
        /// <returns>The reciprocal.</returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static float Rcp(float val) => 1.0f / val;

        /// <summary>Returns the reciprocal (1/x) of a double.</summary>
        /// <param name="val">The input value.</param>
        /// <returns>The reciprocal.</returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static double Rcp(double val) => 1.0 / val;

        // Additional integer types for IntrinsicMath compatibility

        /// <summary>Returns the absolute value of an sbyte.</summary>
        /// <param name="val">The input value.</param>
        /// <returns>The absolute value.</returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static sbyte Abs(sbyte val) => val < 0 ? (sbyte)(-val) : val;

        /// <summary>Returns the absolute value of a short.</summary>
        /// <param name="val">The input value.</param>
        /// <returns>The absolute value.</returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static short Abs(short val) => val < 0 ? (short)(-val) : val;

        /// <summary>Returns the absolute value of a long.</summary>
        /// <param name="val">The input value.</param>
        /// <returns>The absolute value.</returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static long Abs(long val) => val < 0 ? -val : val;

        /// <summary>Returns the absolute value of a double.</summary>
        /// <param name="val">The input value.</param>
        /// <returns>The absolute value.</returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static double Abs(double val) => val < 0 ? -val : val;

        /// <summary>Returns the smaller of two sbyte values.</summary>
        /// <param name="val1">The first value.</param>
        /// <param name="val2">The second value.</param>
        /// <returns>The smaller value.</returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static sbyte Min(sbyte val1, sbyte val2) => val1 < val2 ? val1 : val2;

        /// <summary>Returns the smaller of two short values.</summary>
        /// <param name="val1">The first value.</param>
        /// <param name="val2">The second value.</param>
        /// <returns>The smaller value.</returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static short Min(short val1, short val2) => val1 < val2 ? val1 : val2;

        /// <summary>Returns the smaller of two long values.</summary>
        /// <param name="val1">The first value.</param>
        /// <param name="val2">The second value.</param>
        /// <returns>The smaller value.</returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static long Min(long val1, long val2) => val1 < val2 ? val1 : val2;

        /// <summary>Returns the smaller of two double values.</summary>
        /// <param name="val1">The first value.</param>
        /// <param name="val2">The second value.</param>
        /// <returns>The smaller value.</returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static double Min(double val1, double val2) => val1 < val2 ? val1 : val2;

        /// <summary>Returns the larger of two sbyte values.</summary>
        /// <param name="val1">The first value.</param>
        /// <param name="val2">The second value.</param>
        /// <returns>The larger value.</returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static sbyte Max(sbyte val1, sbyte val2) => val1 > val2 ? val1 : val2;

        /// <summary>Returns the larger of two short values.</summary>
        /// <param name="val1">The first value.</param>
        /// <param name="val2">The second value.</param>
        /// <returns>The larger value.</returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static short Max(short val1, short val2) => val1 > val2 ? val1 : val2;

        /// <summary>Returns the larger of two long values.</summary>
        /// <param name="val1">The first value.</param>
        /// <param name="val2">The second value.</param>
        /// <returns>The larger value.</returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static long Max(long val1, long val2) => val1 > val2 ? val1 : val2;

        /// <summary>Returns the larger of two double values.</summary>
        /// <param name="val1">The first value.</param>
        /// <param name="val2">The second value.</param>
        /// <returns>The larger value.</returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static double Max(double val1, double val2) => val1 > val2 ? val1 : val2;
    }
}
