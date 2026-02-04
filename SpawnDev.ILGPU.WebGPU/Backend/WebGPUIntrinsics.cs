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
    }
}
