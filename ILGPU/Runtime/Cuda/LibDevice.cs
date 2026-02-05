// ---------------------------------------------------------------------------------------
//                                        ILGPU
//                        Copyright (c) 2021-2023 ILGPU Project
//                                    www.ilgpu.net
//
// File: LibDevice.tt/LibDevice.cs
//
// This file is part of ILGPU and is distributed under the University of Illinois Open
// Source License. See LICENSE.txt for details.
// ---------------------------------------------------------------------------------------

// ---------------------------------------------------------------------------------------
//                                        ILGPU
//                           Copyright (c) 2021 ILGPU Project
//                                    www.ilgpu.net
//
// File: TextTransformHelpers.ttinclude
//
// This file is part of ILGPU and is distributed under the University of Illinois Open
// Source License. See LICENSE.txt for details.
// ---------------------------------------------------------------------------------------


// ---------------------------------------------------------------------------------------
//                                        ILGPU
//                        Copyright (c) 2016-2024 ILGPU Project
//                                    www.ilgpu.net
//
// File: TypeInformation.ttinclude
//
// This file is part of ILGPU and is distributed under the University of Illinois Open
// Source License. See LICENSE.txt for details.
// ---------------------------------------------------------------------------------------


// ---------------------------------------------------------------------------------------
//                                        ILGPU
//                           Copyright (c) 2021 ILGPU Project
//                                    www.ilgpu.net
//
// File: CudaLibDevice.ttinclude
//
// This file is part of ILGPU and is distributed under the University of Illinois Open
// Source License. See LICENSE.txt for details.
// ---------------------------------------------------------------------------------------


using ILGPU.Backends.PTX;
using System.Runtime.CompilerServices;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable IDE0018 // Inline variable declaration
#pragma warning disable IDE1006 // Naming Styles

namespace ILGPU.Runtime.Cuda
{
    /// <summary>
    /// Provides bindings for Cuda LibDevice functions.
    /// </summary>
    /// <remarks>
    /// Deals with thunking the Cuda LibDevice functions, because the compiled PTX uses:
    /// - b32 registers rather than f16 registers (Half type).
    /// - b32 registers rather than f32 registers (float type).
    /// - b64 registers rather than f64 registers (double type).
    /// </remarks>
    public static class LibDevice
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Abs(
            int x)
        {
            var arg0 = x;

            var result = PTXLibDeviceMethods.__nv_abs(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Acos(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_acos(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Acos(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_acosf(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Acosh(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_acosh(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Acosh(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_acoshf(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Asin(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_asin(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Asin(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_asinf(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Asinh(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_asinh(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Asinh(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_asinhf(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Atan(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_atan(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Atan(
            double x,
            double y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);

            var result = PTXLibDeviceMethods.__nv_atan2(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Atan(
            float x,
            float y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);

            var result = PTXLibDeviceMethods.__nv_atan2f(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Atan(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_atanf(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Atanh(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_atanh(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Atanh(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_atanhf(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BitReverse(
            int x)
        {
            var arg0 = x;

            var result = PTXLibDeviceMethods.__nv_brev(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long BitReverse(
            long x)
        {
            var arg0 = x;

            var result = PTXLibDeviceMethods.__nv_brevll(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BytePerm(
            int x,
            int y,
            int z)
        {
            var arg0 = x;
            var arg1 = y;
            var arg2 = z;

            var result = PTXLibDeviceMethods.__nv_byte_perm(
                arg0,
                arg1,
                arg2);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Cbrt(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_cbrt(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Cbrt(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_cbrtf(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Ceil(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_ceil(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Ceil(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_ceilf(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CountLeadingZero(
            int x)
        {
            var arg0 = x;

            var result = PTXLibDeviceMethods.__nv_clz(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long CountLeadingZero(
            long x)
        {
            var arg0 = x;

            var result = PTXLibDeviceMethods.__nv_clzll(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CopySign(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_copysign(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float CopySign(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_copysignf(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Cos(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_cos(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Cos(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_cosf(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Cosh(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_cosh(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Cosh(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_coshf(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CosPi(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_cospi(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float CosPi(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_cospif(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double AddRoundDown(
            double x,
            double y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);

            var result = PTXLibDeviceMethods.__nv_dadd_rd(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double AddRoundEven(
            double x,
            double y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);

            var result = PTXLibDeviceMethods.__nv_dadd_rn(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double AddRoundUp(
            double x,
            double y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);

            var result = PTXLibDeviceMethods.__nv_dadd_ru(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double AddRoundZero(
            double x,
            double y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);

            var result = PTXLibDeviceMethods.__nv_dadd_rz(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double DivRoundDown(
            double x,
            double y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);

            var result = PTXLibDeviceMethods.__nv_ddiv_rd(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double DivRoundEven(
            double x,
            double y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);

            var result = PTXLibDeviceMethods.__nv_ddiv_rn(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double DivRoundUp(
            double x,
            double y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);

            var result = PTXLibDeviceMethods.__nv_ddiv_ru(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double DivRoundZero(
            double x,
            double y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);

            var result = PTXLibDeviceMethods.__nv_ddiv_rz(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double MulRoundDown(
            double x,
            double y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);

            var result = PTXLibDeviceMethods.__nv_dmul_rd(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double MulRoundEven(
            double x,
            double y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);

            var result = PTXLibDeviceMethods.__nv_dmul_rn(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double MulRoundUp(
            double x,
            double y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);

            var result = PTXLibDeviceMethods.__nv_dmul_ru(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double MulRoundZero(
            double x,
            double y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);

            var result = PTXLibDeviceMethods.__nv_dmul_rz(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float DoubleToFloatRoundDown(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_double2float_rd(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float DoubleToFloatRoundEven(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_double2float_rn(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float DoubleToFloatRoundUp(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_double2float_ru(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float DoubleToFloatRoundZero(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_double2float_rz(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int DoubleToHiInt(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_double2hiint(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int DoubleToIntRoundDown(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_double2int_rd(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int DoubleToIntRoundEven(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_double2int_rn(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int DoubleToIntRoundUp(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_double2int_ru(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int DoubleToIntRoundZero(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_double2int_rz(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long DoubleToLongRoundDown(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_double2ll_rd(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long DoubleToLongRoundEven(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_double2ll_rn(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long DoubleToLongRoundUp(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_double2ll_ru(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long DoubleToLongRoundZero(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_double2ll_rz(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int DoubleToLoInt(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_double2loint(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint DoubleToUIntRoundDown(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_double2uint_rd(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint DoubleToUIntRoundEven(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_double2uint_rn(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint DoubleToUIntRoundUp(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_double2uint_ru(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint DoubleToUIntRoundZero(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_double2uint_rz(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong DoubleToULongRoundDown(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_double2ull_rd(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong DoubleToULongRoundEven(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_double2ull_rn(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong DoubleToULongRoundUp(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_double2ull_ru(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong DoubleToULongRoundZero(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_double2ull_rz(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long DoubleAsLong(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_double_as_longlong(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double RcpRoundDown(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_drcp_rd(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double RcpRoundEven(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_drcp_rn(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double RcpRoundUp(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_drcp_ru(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double RcpRoundZero(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_drcp_rz(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SqrtRoundDown(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_dsqrt_rd(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SqrtRoundEven(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_dsqrt_rn(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SqrtRoundUp(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_dsqrt_ru(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SqrtRoundZero(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_dsqrt_rz(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Erf(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_erf(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Erfc(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_erfc(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Erfc(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_erfcf(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ErfcInv(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_erfcinv(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ErfcInv(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_erfcinvf(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Erfcx(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_erfcx(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Erfcx(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_erfcxf(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Erf(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_erff(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ErfInv(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_erfinv(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ErfInv(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_erfinvf(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Exp(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_exp(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Exp10(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_exp10(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Exp10(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_exp10f(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Exp2(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_exp2(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Exp2(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_exp2f(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Exp(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_expf(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Expm1(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_expm1(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Expm1(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_expm1f(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Abs(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_fabs(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Abs(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_fabsf(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float AddRoundDown(
            float x,
            float y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);

            var result = PTXLibDeviceMethods.__nv_fadd_rd(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float AddRoundEven(
            float x,
            float y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);

            var result = PTXLibDeviceMethods.__nv_fadd_rn(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float AddRoundUp(
            float x,
            float y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);

            var result = PTXLibDeviceMethods.__nv_fadd_ru(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float AddRoundZero(
            float x,
            float y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);

            var result = PTXLibDeviceMethods.__nv_fadd_rz(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float FastCos(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_fast_cosf(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float FastExp10(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_fast_exp10f(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float FastExp(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_fast_expf(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float FastDivide(
            float x,
            float y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);

            var result = PTXLibDeviceMethods.__nv_fast_fdividef(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float FastLog10(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_fast_log10f(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float FastLog2(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_fast_log2f(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float FastLog(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_fast_logf(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float FastPow(
            float x,
            float y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);

            var result = PTXLibDeviceMethods.__nv_fast_powf(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FastSinCos(
            float x,
            out float sin,
            out float cos)
        {
            var arg0 = Interop.FloatAsInt(x);
            uint arg1;
            uint arg2;

            PTXLibDeviceMethods.__nv_fast_sincosf(
                arg0,
                out arg1,
                out arg2);

            sin = Interop.IntAsFloat(arg1);
            cos = Interop.IntAsFloat(arg2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float FastSin(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_fast_sinf(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float FastTan(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_fast_tanf(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Dim(
            double x,
            double y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);

            var result = PTXLibDeviceMethods.__nv_fdim(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Dim(
            float x,
            float y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);

            var result = PTXLibDeviceMethods.__nv_fdimf(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float DivRoundDown(
            float x,
            float y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);

            var result = PTXLibDeviceMethods.__nv_fdiv_rd(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float DivRoundEven(
            float x,
            float y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);

            var result = PTXLibDeviceMethods.__nv_fdiv_rn(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float DivRoundUp(
            float x,
            float y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);

            var result = PTXLibDeviceMethods.__nv_fdiv_ru(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float DivRoundZero(
            float x,
            float y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);

            var result = PTXLibDeviceMethods.__nv_fdiv_rz(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindFirstSignificant(
            int x)
        {
            var arg0 = x;

            var result = PTXLibDeviceMethods.__nv_ffs(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindFirstSignificant(
            long x)
        {
            var arg0 = x;

            var result = PTXLibDeviceMethods.__nv_ffsll(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Finite(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_finitef(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Half FloatToHalfRoundEven(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_float2half_rn(
                arg0);

            return (Half)result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FloatToIntRoundDown(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_float2int_rd(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FloatToIntRoundEven(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_float2int_rn(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FloatToIntRoundUp(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_float2int_ru(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FloatToIntRoundZero(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_float2int_rz(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long FloatToLongRoundDown(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_float2ll_rd(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long FloatToLongRoundEven(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_float2ll_rn(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long FloatToLongRoundUp(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_float2ll_ru(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long FloatToLongRoundZero(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_float2ll_rz(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint FloatToUIntRoundDown(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_float2uint_rd(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint FloatToUIntRoundEven(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_float2uint_rn(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint FloatToUIntRoundUp(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_float2uint_ru(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint FloatToUIntRoundZero(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_float2uint_rz(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong FloatToULongRoundDown(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_float2ull_rd(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong FloatToULongRoundEven(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_float2ull_rn(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong FloatToULongRoundUp(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_float2ull_ru(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong FloatToULongRoundZero(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_float2ull_rz(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FloatAsInt(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_float_as_int(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Floor(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_floor(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Floor(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_floorf(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double FusedMultiplyAdd(
            double x,
            double y,
            double z)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);
            var arg2 = Interop.FloatAsInt(z);

            var result = PTXLibDeviceMethods.__nv_fma(
                arg0,
                arg1,
                arg2);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double FusedMultiplyAddRoundDown(
            double x,
            double y,
            double z)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);
            var arg2 = Interop.FloatAsInt(z);

            var result = PTXLibDeviceMethods.__nv_fma_rd(
                arg0,
                arg1,
                arg2);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double FusedMultiplyAddRoundEven(
            double x,
            double y,
            double z)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);
            var arg2 = Interop.FloatAsInt(z);

            var result = PTXLibDeviceMethods.__nv_fma_rn(
                arg0,
                arg1,
                arg2);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double FusedMultiplyAddRoundUp(
            double x,
            double y,
            double z)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);
            var arg2 = Interop.FloatAsInt(z);

            var result = PTXLibDeviceMethods.__nv_fma_ru(
                arg0,
                arg1,
                arg2);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double FusedMultiplyAddRoundZero(
            double x,
            double y,
            double z)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);
            var arg2 = Interop.FloatAsInt(z);

            var result = PTXLibDeviceMethods.__nv_fma_rz(
                arg0,
                arg1,
                arg2);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float FusedMultiplyAdd(
            float x,
            float y,
            float z)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);
            var arg2 = Interop.FloatAsInt(z);

            var result = PTXLibDeviceMethods.__nv_fmaf(
                arg0,
                arg1,
                arg2);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float FusedMultiplyAddRoundDown(
            float x,
            float y,
            float z)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);
            var arg2 = Interop.FloatAsInt(z);

            var result = PTXLibDeviceMethods.__nv_fmaf_rd(
                arg0,
                arg1,
                arg2);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float FusedMultiplyAddRoundEven(
            float x,
            float y,
            float z)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);
            var arg2 = Interop.FloatAsInt(z);

            var result = PTXLibDeviceMethods.__nv_fmaf_rn(
                arg0,
                arg1,
                arg2);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float FusedMultiplyAddRoundUp(
            float x,
            float y,
            float z)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);
            var arg2 = Interop.FloatAsInt(z);

            var result = PTXLibDeviceMethods.__nv_fmaf_ru(
                arg0,
                arg1,
                arg2);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float FusedMultiplyAddRoundZero(
            float x,
            float y,
            float z)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);
            var arg2 = Interop.FloatAsInt(z);

            var result = PTXLibDeviceMethods.__nv_fmaf_rz(
                arg0,
                arg1,
                arg2);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Max(
            double x,
            double y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);

            var result = PTXLibDeviceMethods.__nv_fmax(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Max(
            float x,
            float y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);

            var result = PTXLibDeviceMethods.__nv_fmaxf(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Min(
            double x,
            double y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);

            var result = PTXLibDeviceMethods.__nv_fmin(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Min(
            float x,
            float y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);

            var result = PTXLibDeviceMethods.__nv_fminf(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Fmod(
            double x,
            double y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);

            var result = PTXLibDeviceMethods.__nv_fmod(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Fmod(
            float x,
            float y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);

            var result = PTXLibDeviceMethods.__nv_fmodf(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float MulRoundDown(
            float x,
            float y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);

            var result = PTXLibDeviceMethods.__nv_fmul_rd(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float MulRoundEven(
            float x,
            float y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);

            var result = PTXLibDeviceMethods.__nv_fmul_rn(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float MulRoundUp(
            float x,
            float y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);

            var result = PTXLibDeviceMethods.__nv_fmul_ru(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float MulRoundZero(
            float x,
            float y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);

            var result = PTXLibDeviceMethods.__nv_fmul_rz(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float RcpRoundDown(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_frcp_rd(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float RcpRoundEven(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_frcp_rn(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float RcpRoundUp(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_frcp_ru(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float RcpRoundZero(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_frcp_rz(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Rexp(
            double x,
            out int y)
        {
            var arg0 = Interop.FloatAsInt(x);
            int arg1;

            var result = PTXLibDeviceMethods.__nv_frexp(
                arg0,
                out arg1);

            y = arg1;
            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Rexp(
            float x,
            out int y)
        {
            var arg0 = Interop.FloatAsInt(x);
            int arg1;

            var result = PTXLibDeviceMethods.__nv_frexpf(
                arg0,
                out arg1);

            y = arg1;
            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float RsqrtRoundEven(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_frsqrt_rn(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SqrtRoundDown(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_fsqrt_rd(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SqrtRoundEven(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_fsqrt_rb(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SqrtRoundUp(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_fsqrt_ru(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SqrtRoundZero(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_fsqrt_rz(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SubRoundDown(
            float x,
            float y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);

            var result = PTXLibDeviceMethods.__nv_fsub_rd(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SubRoundEven(
            float x,
            float y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);

            var result = PTXLibDeviceMethods.__nv_fsub_rn(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SubRoundUp(
            float x,
            float y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);

            var result = PTXLibDeviceMethods.__nv_fsub_ru(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SubRoundZero(
            float x,
            float y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);

            var result = PTXLibDeviceMethods.__nv_fsub_rz(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Hadd(
            int x,
            int y)
        {
            var arg0 = x;
            var arg1 = y;

            var result = PTXLibDeviceMethods.__nv_hadd(
                arg0,
                arg1);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float HalfToFloat(
            Half x)
        {
            var arg0 = (uint)x;

            var result = PTXLibDeviceMethods.__nv_half2float(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double HiLoIntToDouble(
            int x,
            int y)
        {
            var arg0 = x;
            var arg1 = y;

            var result = PTXLibDeviceMethods.__nv_hiloint2double(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Hypot(
            double x,
            double y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);

            var result = PTXLibDeviceMethods.__nv_hypot(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Hypot(
            float x,
            float y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);

            var result = PTXLibDeviceMethods.__nv_hypotf(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ILogB(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_ilogb(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ILogB(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_ilogbf(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double IntToDoubleRoundEven(
            int x)
        {
            var arg0 = x;

            var result = PTXLibDeviceMethods.__nv_int2double_rn(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float IntToFloatRoundDown(
            int x)
        {
            var arg0 = x;

            var result = PTXLibDeviceMethods.__nv_int2float_rd(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float IntToFloatRoundEven(
            int x)
        {
            var arg0 = x;

            var result = PTXLibDeviceMethods.__nv_int2float_rn(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float IntToFloatRoundUp(
            int x)
        {
            var arg0 = x;

            var result = PTXLibDeviceMethods.__nv_int2float_ru(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float IntToFloatRoundZero(
            int x)
        {
            var arg0 = x;

            var result = PTXLibDeviceMethods.__nv_int2float_rz(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float IntAsFloat(
            int x)
        {
            var arg0 = x;

            var result = PTXLibDeviceMethods.__nv_int_as_float(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int IsFinite(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_isfinited(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int IsInfinity(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_isinfd(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int IsInfinity(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_isinff(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int IsNaN(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_isnand(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int IsNaN(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_isnanf(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double J0(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_j0(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float J0(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_j0f(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double J1(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_j1(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float J1(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_j1f(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double JN(
            int x,
            double y)
        {
            var arg0 = x;
            var arg1 = Interop.FloatAsInt(y);

            var result = PTXLibDeviceMethods.__nv_jn(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float JN(
            int x,
            float y)
        {
            var arg0 = x;
            var arg1 = Interop.FloatAsInt(y);

            var result = PTXLibDeviceMethods.__nv_jnf(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Exp(
            double x,
            int y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = y;

            var result = PTXLibDeviceMethods.__nv_ldexp(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Exp(
            float x,
            int y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = y;

            var result = PTXLibDeviceMethods.__nv_ldexpf(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Gamma(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_lgamma(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Gamma(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_lgammaf(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double LongToDoubleRoundDown(
            long x)
        {
            var arg0 = x;

            var result = PTXLibDeviceMethods.__nv_ll2double_rd(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double LongToDoubleRoundEven(
            long x)
        {
            var arg0 = x;

            var result = PTXLibDeviceMethods.__nv_ll2double_rn(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double LongToDoubleRoundUp(
            long x)
        {
            var arg0 = x;

            var result = PTXLibDeviceMethods.__nv_ll2double_ru(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double LongToDoubleRoundZero(
            long x)
        {
            var arg0 = x;

            var result = PTXLibDeviceMethods.__nv_ll2double_rz(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float LongToFloatRoundDown(
            long x)
        {
            var arg0 = x;

            var result = PTXLibDeviceMethods.__nv_ll2float_rd(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float LongToFloatRoundEven(
            long x)
        {
            var arg0 = x;

            var result = PTXLibDeviceMethods.__nv_ll2float_rn(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float LongToFloatRoundUp(
            long x)
        {
            var arg0 = x;

            var result = PTXLibDeviceMethods.__nv_ll2float_ru(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float LongToFloatRoundZero(
            long x)
        {
            var arg0 = x;

            var result = PTXLibDeviceMethods.__nv_ll2float_rz(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Abs(
            long x)
        {
            var arg0 = x;

            var result = PTXLibDeviceMethods.__nv_llabs(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Max(
            long x,
            long y)
        {
            var arg0 = x;
            var arg1 = y;

            var result = PTXLibDeviceMethods.__nv_llmax(
                arg0,
                arg1);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Min(
            long x,
            long y)
        {
            var arg0 = x;
            var arg1 = y;

            var result = PTXLibDeviceMethods.__nv_llmin(
                arg0,
                arg1);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long LRint(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_llrint(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long LRint(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_llrintf(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long LRound(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_llround(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long LRound(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_llroundf(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Log(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_log(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Log10(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_log10(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Log10(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_log10f(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Log1P(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_log1p(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Log1P(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_log1pf(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Log2(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_log2(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Log2(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_log2f(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double LogB(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_logb(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float LogB(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_logbf(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Log(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_logf(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double LongAsDouble(
            long x)
        {
            var arg0 = x;

            var result = PTXLibDeviceMethods.__nv_longlong_as_double(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Max(
            int x,
            int y)
        {
            var arg0 = x;
            var arg1 = y;

            var result = PTXLibDeviceMethods.__nv_max(
                arg0,
                arg1);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Min(
            int x,
            int y)
        {
            var arg0 = x;
            var arg1 = y;

            var result = PTXLibDeviceMethods.__nv_min(
                arg0,
                arg1);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Modf(
            double x,
            out double b)
        {
            var arg0 = Interop.FloatAsInt(x);
            ulong arg1;

            var result = PTXLibDeviceMethods.__nv_modf(
                arg0,
                out arg1);

            b = Interop.IntAsFloat(arg1);
            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Modf(
            float x,
            out float b)
        {
            var arg0 = Interop.FloatAsInt(x);
            uint arg1;

            var result = PTXLibDeviceMethods.__nv_modff(
                arg0,
                out arg1);

            b = Interop.IntAsFloat(arg1);
            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Mul24(
            int x,
            int y)
        {
            var arg0 = x;
            var arg1 = y;

            var result = PTXLibDeviceMethods.__nv_mul24(
                arg0,
                arg1);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Mul64Hi(
            long x,
            long y)
        {
            var arg0 = x;
            var arg1 = y;

            var result = PTXLibDeviceMethods.__nv_mul64hi(
                arg0,
                arg1);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int MulHi(
            int x,
            int y)
        {
            var arg0 = x;
            var arg1 = y;

            var result = PTXLibDeviceMethods.__nv_mulhi(
                arg0,
                arg1);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double NaN(
            string tagp)
        {
            var arg0 = tagp;

            var result = PTXLibDeviceMethods.__nv_nan(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float NaNF(
            string tagp)
        {
            var arg0 = tagp;

            var result = PTXLibDeviceMethods.__nv_nanf(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double NearbyInt(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_nearbyint(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float NearbyInt(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_nearbyintf(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double NextAfter(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_nextafter(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float NextAfter(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_nextafterf(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Normcdf(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_normcdf(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Normcdf(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_normcdff(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double NormcdfInv(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_normcdfinv(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float NormcdfInv(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_normcdfinvf(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int PopCount(
            int x)
        {
            var arg0 = x;

            var result = PTXLibDeviceMethods.__nv_popc(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int PopCount(
            long x)
        {
            var arg0 = x;

            var result = PTXLibDeviceMethods.__nv_popcll(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Pow(
            double x,
            double y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);

            var result = PTXLibDeviceMethods.__nv_pow(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Pow(
            float x,
            float y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);

            var result = PTXLibDeviceMethods.__nv_powf(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Pow(
            double x,
            int y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = y;

            var result = PTXLibDeviceMethods.__nv_powi(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Pow(
            float x,
            int y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = y;

            var result = PTXLibDeviceMethods.__nv_powif(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Rcbrt(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_rcbrt(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Rcbrt(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_rcbrtf(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Remainder(
            double x,
            double y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);

            var result = PTXLibDeviceMethods.__nv_remainder(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Remainder(
            float x,
            float y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);

            var result = PTXLibDeviceMethods.__nv_remainderf(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double RemQuo(
            double x,
            double y,
            out int quo)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);
            int arg2;

            var result = PTXLibDeviceMethods.__nv_remquo(
                arg0,
                arg1,
                out arg2);

            quo = arg2;
            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float RemQuo(
            float x,
            float y,
            out int quo)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = Interop.FloatAsInt(y);
            int arg2;

            var result = PTXLibDeviceMethods.__nv_remquof(
                arg0,
                arg1,
                out arg2);

            quo = arg2;
            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Rhadd(
            int x,
            int y)
        {
            var arg0 = x;
            var arg1 = y;

            var result = PTXLibDeviceMethods.__nv_rhadd(
                arg0,
                arg1);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Rint(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_rint(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Rint(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_rintf(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Round(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_round(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Round(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_roundf(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Rsqrt(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_rsqrt(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Rsqrt(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_rsqrtf(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sad(
            int x,
            int y,
            int z)
        {
            var arg0 = x;
            var arg1 = y;
            var arg2 = z;

            var result = PTXLibDeviceMethods.__nv_sad(
                arg0,
                arg1,
                arg2);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Saturate(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_saturatef(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Scalbn(
            double x,
            int y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = y;

            var result = PTXLibDeviceMethods.__nv_scalbn(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Scalbn(
            float x,
            int y)
        {
            var arg0 = Interop.FloatAsInt(x);
            var arg1 = y;

            var result = PTXLibDeviceMethods.__nv_scalbnf(
                arg0,
                arg1);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SignBit(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_signbitd(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SignBit(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_signbitf(
                arg0);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sin(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_sin(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SinCos(
            double x,
            out double sin,
            out double cos)
        {
            var arg0 = Interop.FloatAsInt(x);
            ulong arg1;
            ulong arg2;

            PTXLibDeviceMethods.__nv_sincos(
                arg0,
                out arg1,
                out arg2);

            sin = Interop.IntAsFloat(arg1);
            cos = Interop.IntAsFloat(arg2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SinCos(
            float x,
            out float sin,
            out float cos)
        {
            var arg0 = Interop.FloatAsInt(x);
            uint arg1;
            uint arg2;

            PTXLibDeviceMethods.__nv_sincosf(
                arg0,
                out arg1,
                out arg2);

            sin = Interop.IntAsFloat(arg1);
            cos = Interop.IntAsFloat(arg2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SinCosPi(
            double x,
            out double sin,
            out double cos)
        {
            var arg0 = Interop.FloatAsInt(x);
            ulong arg1;
            ulong arg2;

            PTXLibDeviceMethods.__nv_sincospi(
                arg0,
                out arg1,
                out arg2);

            sin = Interop.IntAsFloat(arg1);
            cos = Interop.IntAsFloat(arg2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SinCosPi(
            float x,
            out float sin,
            out float cos)
        {
            var arg0 = Interop.FloatAsInt(x);
            uint arg1;
            uint arg2;

            PTXLibDeviceMethods.__nv_sincospif(
                arg0,
                out arg1,
                out arg2);

            sin = Interop.IntAsFloat(arg1);
            cos = Interop.IntAsFloat(arg2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sin(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_sinf(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sinh(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_sinh(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sinh(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_sinhf(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SinPi(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_sinpi(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SinPi(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_sinpif(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sqrt(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_sqrt(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sqrt(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_sqrtf(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Tan(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_tan(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Tan(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_tanf(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Tanh(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_tanh(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Tanh(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_tanhf(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Tgamma(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_tgamma(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Tgamma(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_tgammaf(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Trunc(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_trunc(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Trunc(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_truncf(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Uhadd(
            int x,
            int y)
        {
            var arg0 = x;
            var arg1 = y;

            var result = PTXLibDeviceMethods.__nv_uhadd(
                arg0,
                arg1);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double UIntToDoubleRoundEven(
            int x)
        {
            var arg0 = x;

            var result = PTXLibDeviceMethods.__nv_uint2double_rn(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float UIntToFloatRoundDown(
            int x)
        {
            var arg0 = x;

            var result = PTXLibDeviceMethods.__nv_uint2float_rd(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float UIntToFloatRoundEven(
            int x)
        {
            var arg0 = x;

            var result = PTXLibDeviceMethods.__nv_uint2float_rn(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float UIntToFloatRoundUp(
            int x)
        {
            var arg0 = x;

            var result = PTXLibDeviceMethods.__nv_uint2float_ru(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float UIntToFloatRoundZero(
            int x)
        {
            var arg0 = x;

            var result = PTXLibDeviceMethods.__nv_uint2float_rz(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ULongToDoubleRoundDown(
            ulong x)
        {
            var arg0 = x;

            var result = PTXLibDeviceMethods.__nv_ull2double_rd(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double LongToDoubleRoundEven(
            ulong x)
        {
            var arg0 = x;

            var result = PTXLibDeviceMethods.__nv_ull2double_rn(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ULongToDoubleRoundUp(
            ulong x)
        {
            var arg0 = x;

            var result = PTXLibDeviceMethods.__nv_ull2double_ru(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ULongToDoubleRoundZero(
            ulong x)
        {
            var arg0 = x;

            var result = PTXLibDeviceMethods.__nv_ull2double_rz(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ULongToFloatRoundDown(
            ulong x)
        {
            var arg0 = x;

            var result = PTXLibDeviceMethods.__nv_ull2float_rd(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ULongToFloatRoundEven(
            ulong x)
        {
            var arg0 = x;

            var result = PTXLibDeviceMethods.__nv_ull2float_rn(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ULongToFloatRoundUp(
            ulong x)
        {
            var arg0 = x;

            var result = PTXLibDeviceMethods.__nv_ull2float_ru(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ULongToFloatRoundZero(
            ulong x)
        {
            var arg0 = x;

            var result = PTXLibDeviceMethods.__nv_ull2float_rz(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong Max(
            ulong x,
            ulong y)
        {
            var arg0 = x;
            var arg1 = y;

            var result = PTXLibDeviceMethods.__nv_ullmax(
                arg0,
                arg1);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong Min(
            ulong x,
            ulong y)
        {
            var arg0 = x;
            var arg1 = y;

            var result = PTXLibDeviceMethods.__nv_ullmin(
                arg0,
                arg1);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Max(
            uint x,
            uint y)
        {
            var arg0 = x;
            var arg1 = y;

            var result = PTXLibDeviceMethods.__nv_umax(
                arg0,
                arg1);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Min(
            uint x,
            uint y)
        {
            var arg0 = x;
            var arg1 = y;

            var result = PTXLibDeviceMethods.__nv_umin(
                arg0,
                arg1);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Mul24(
            uint x,
            uint y)
        {
            var arg0 = x;
            var arg1 = y;

            var result = PTXLibDeviceMethods.__nv_umul24(
                arg0,
                arg1);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong Mul64Hi(
            ulong x,
            ulong y)
        {
            var arg0 = x;
            var arg1 = y;

            var result = PTXLibDeviceMethods.__nv_umul64hi(
                arg0,
                arg1);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint MulHi(
            uint x,
            uint y)
        {
            var arg0 = x;
            var arg1 = y;

            var result = PTXLibDeviceMethods.__nv_umulhi(
                arg0,
                arg1);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Rhadd(
            uint x,
            uint y)
        {
            var arg0 = x;
            var arg1 = y;

            var result = PTXLibDeviceMethods.__nv_urhadd(
                arg0,
                arg1);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Sad(
            uint x,
            uint y,
            uint z)
        {
            var arg0 = x;
            var arg1 = y;
            var arg2 = z;

            var result = PTXLibDeviceMethods.__nv_usad(
                arg0,
                arg1,
                arg2);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Y0(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_y0(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Y0(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_y0f(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Y1(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_y1(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Y1(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_y1f(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double YN(
            double x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_yn(
                arg0);

            return Interop.IntAsFloat(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float YN(
            float x)
        {
            var arg0 = Interop.FloatAsInt(x);

            var result = PTXLibDeviceMethods.__nv_ynf(
                arg0);

            return Interop.IntAsFloat(result);
        }

    }
}

#pragma warning restore IDE1006 // Naming Styles
#pragma warning restore IDE0018 // Inline variable declaration
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

