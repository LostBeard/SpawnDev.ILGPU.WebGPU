using System.Runtime.CompilerServices;

namespace SpawnDev.ILGPU.WebGPU.Backend
{
    public static class WebGPUIntrinsics
    {
        // Unary
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static float Abs(float val) => val < 0 ? -val : val;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int Sign(float val) => val > 0 ? 1 : val < 0 ? -1 : 0;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static float Round(float val) => val;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static float Truncate(float val) => val;

        // Binary
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static float Atan2(float y, float x) => y;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static float Max(float val1, float val2) => val1 > val2 ? val1 : val2;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static float Min(float val1, float val2) => val1 < val2 ? val1 : val2;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static float Pow(float x, float y) => x;

        // Ternary
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static float Clamp(float value, float min, float max) => value < min ? min : value > max ? max : value;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static float FusedMultiplyAdd(float x, float y, float z) => x * y + z;
        // Unary (Int)
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int Abs(int val) => val < 0 ? -val : val;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int Sign(int val) => val > 0 ? 1 : val < 0 ? -1 : 0;

        // Binary (Int)
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int Max(int val1, int val2) => val1 > val2 ? val1 : val2;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int Min(int val1, int val2) => val1 < val2 ? val1 : val2;

        // Ternary (Int)
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int Clamp(int value, int min, int max) => value < min ? min : value > max ? max : value;

        // Rsqrt and Rcp for XMath compatibility
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static float Rsqrt(float val) => 1.0f / MathF.Sqrt(val);

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static double Rsqrt(double val) => 1.0 / Math.Sqrt(val);

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static float Rcp(float val) => 1.0f / val;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static double Rcp(double val) => 1.0 / val;

        // Additional integer types for IntrinsicMath compatibility
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static sbyte Abs(sbyte val) => val < 0 ? (sbyte)(-val) : val;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static short Abs(short val) => val < 0 ? (short)(-val) : val;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static long Abs(long val) => val < 0 ? -val : val;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static double Abs(double val) => val < 0 ? -val : val;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static sbyte Min(sbyte val1, sbyte val2) => val1 < val2 ? val1 : val2;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static short Min(short val1, short val2) => val1 < val2 ? val1 : val2;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static long Min(long val1, long val2) => val1 < val2 ? val1 : val2;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static double Min(double val1, double val2) => val1 < val2 ? val1 : val2;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static sbyte Max(sbyte val1, sbyte val2) => val1 > val2 ? val1 : val2;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static short Max(short val1, short val2) => val1 > val2 ? val1 : val2;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static long Max(long val1, long val2) => val1 > val2 ? val1 : val2;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static double Max(double val1, double val2) => val1 > val2 ? val1 : val2;
    }
}
