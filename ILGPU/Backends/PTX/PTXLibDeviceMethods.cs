// ---------------------------------------------------------------------------------------
//                                        ILGPU
//                        Copyright (c) 2021-2022 ILGPU Project
//                                    www.ilgpu.net
//
// File: PTXLibDeviceMethods.tt/PTXLibDeviceMethods.cs
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


using ILGPU.Frontend;
using ILGPU.IR;
using System.Runtime.CompilerServices;

#pragma warning disable IDE1006 // Naming Styles

namespace ILGPU.Backends.PTX
{
    /// <summary>
    /// Contains methods for matching the signature of the Cuda LibDevice functions when
    /// compiled to PTX.
    /// </summary>
    internal static class PTXLibDeviceMethods
    {
        internal static bool IsLibDeviceMethod(Method method) =>
            method.HasSource &&
            method.Source.DeclaringType == typeof(PTXLibDeviceMethods);

        [External("__ilgpu__nv_abs")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int __nv_abs(
            int x) => default;

        [External("__ilgpu__nv_acos")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_acos(
            ulong x) => default;

        [External("__ilgpu__nv_acosf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_acosf(
            uint x) => default;

        [External("__ilgpu__nv_acosh")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_acosh(
            ulong x) => default;

        [External("__ilgpu__nv_acoshf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_acoshf(
            uint x) => default;

        [External("__ilgpu__nv_asin")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_asin(
            ulong x) => default;

        [External("__ilgpu__nv_asinf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_asinf(
            uint x) => default;

        [External("__ilgpu__nv_asinh")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_asinh(
            ulong x) => default;

        [External("__ilgpu__nv_asinhf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_asinhf(
            uint x) => default;

        [External("__ilgpu__nv_atan")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_atan(
            ulong x) => default;

        [External("__ilgpu__nv_atan2")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_atan2(
            ulong x,
            ulong y) => default;

        [External("__ilgpu__nv_atan2f")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_atan2f(
            uint x,
            uint y) => default;

        [External("__ilgpu__nv_atanf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_atanf(
            uint x) => default;

        [External("__ilgpu__nv_atanh")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_atanh(
            ulong x) => default;

        [External("__ilgpu__nv_atanhf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_atanhf(
            uint x) => default;

        [External("__ilgpu__nv_brev")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int __nv_brev(
            int x) => default;

        [External("__ilgpu__nv_brevll")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long __nv_brevll(
            long x) => default;

        [External("__ilgpu__nv_byte_perm")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int __nv_byte_perm(
            int x,
            int y,
            int z) => default;

        [External("__ilgpu__nv_cbrt")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_cbrt(
            ulong x) => default;

        [External("__ilgpu__nv_cbrtf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_cbrtf(
            uint x) => default;

        [External("__ilgpu__nv_ceil")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_ceil(
            ulong x) => default;

        [External("__ilgpu__nv_ceilf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_ceilf(
            uint x) => default;

        [External("__ilgpu__nv_clz")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int __nv_clz(
            int x) => default;

        [External("__ilgpu__nv_clzll")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long __nv_clzll(
            long x) => default;

        [External("__ilgpu__nv_copysign")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_copysign(
            ulong x) => default;

        [External("__ilgpu__nv_copysignf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_copysignf(
            uint x) => default;

        [External("__ilgpu__nv_cos")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_cos(
            ulong x) => default;

        [External("__ilgpu__nv_cosf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_cosf(
            uint x) => default;

        [External("__ilgpu__nv_cosh")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_cosh(
            ulong x) => default;

        [External("__ilgpu__nv_coshf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_coshf(
            uint x) => default;

        [External("__ilgpu__nv_cospi")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_cospi(
            ulong x) => default;

        [External("__ilgpu__nv_cospif")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_cospif(
            uint x) => default;

        [External("__ilgpu__nv_dadd_rd")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_dadd_rd(
            ulong x,
            ulong y) => default;

        [External("__ilgpu__nv_dadd_rn")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_dadd_rn(
            ulong x,
            ulong y) => default;

        [External("__ilgpu__nv_dadd_ru")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_dadd_ru(
            ulong x,
            ulong y) => default;

        [External("__ilgpu__nv_dadd_rz")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_dadd_rz(
            ulong x,
            ulong y) => default;

        [External("__ilgpu__nv_ddiv_rd")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_ddiv_rd(
            ulong x,
            ulong y) => default;

        [External("__ilgpu__nv_ddiv_rn")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_ddiv_rn(
            ulong x,
            ulong y) => default;

        [External("__ilgpu__nv_ddiv_ru")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_ddiv_ru(
            ulong x,
            ulong y) => default;

        [External("__ilgpu__nv_ddiv_rz")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_ddiv_rz(
            ulong x,
            ulong y) => default;

        [External("__ilgpu__nv_dmul_rd")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_dmul_rd(
            ulong x,
            ulong y) => default;

        [External("__ilgpu__nv_dmul_rn")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_dmul_rn(
            ulong x,
            ulong y) => default;

        [External("__ilgpu__nv_dmul_ru")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_dmul_ru(
            ulong x,
            ulong y) => default;

        [External("__ilgpu__nv_dmul_rz")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_dmul_rz(
            ulong x,
            ulong y) => default;

        [External("__ilgpu__nv_double2float_rd")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_double2float_rd(
            ulong x) => default;

        [External("__ilgpu__nv_double2float_rn")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_double2float_rn(
            ulong x) => default;

        [External("__ilgpu__nv_double2float_ru")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_double2float_ru(
            ulong x) => default;

        [External("__ilgpu__nv_double2float_rz")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_double2float_rz(
            ulong x) => default;

        [External("__ilgpu__nv_double2hiint")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int __nv_double2hiint(
            ulong x) => default;

        [External("__ilgpu__nv_double2int_rd")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int __nv_double2int_rd(
            ulong x) => default;

        [External("__ilgpu__nv_double2int_rn")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int __nv_double2int_rn(
            ulong x) => default;

        [External("__ilgpu__nv_double2int_ru")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int __nv_double2int_ru(
            ulong x) => default;

        [External("__ilgpu__nv_double2int_rz")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int __nv_double2int_rz(
            ulong x) => default;

        [External("__ilgpu__nv_double2ll_rd")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long __nv_double2ll_rd(
            ulong x) => default;

        [External("__ilgpu__nv_double2ll_rn")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long __nv_double2ll_rn(
            ulong x) => default;

        [External("__ilgpu__nv_double2ll_ru")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long __nv_double2ll_ru(
            ulong x) => default;

        [External("__ilgpu__nv_double2ll_rz")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long __nv_double2ll_rz(
            ulong x) => default;

        [External("__ilgpu__nv_double2loint")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int __nv_double2loint(
            ulong x) => default;

        [External("__ilgpu__nv_double2uint_rd")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_double2uint_rd(
            ulong x) => default;

        [External("__ilgpu__nv_double2uint_rn")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_double2uint_rn(
            ulong x) => default;

        [External("__ilgpu__nv_double2uint_ru")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_double2uint_ru(
            ulong x) => default;

        [External("__ilgpu__nv_double2uint_rz")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_double2uint_rz(
            ulong x) => default;

        [External("__ilgpu__nv_double2ull_rd")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_double2ull_rd(
            ulong x) => default;

        [External("__ilgpu__nv_double2ull_rn")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_double2ull_rn(
            ulong x) => default;

        [External("__ilgpu__nv_double2ull_ru")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_double2ull_ru(
            ulong x) => default;

        [External("__ilgpu__nv_double2ull_rz")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_double2ull_rz(
            ulong x) => default;

        [External("__ilgpu__nv_double_as_longlong")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long __nv_double_as_longlong(
            ulong x) => default;

        [External("__ilgpu__nv_drcp_rd")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_drcp_rd(
            ulong x) => default;

        [External("__ilgpu__nv_drcp_rn")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_drcp_rn(
            ulong x) => default;

        [External("__ilgpu__nv_drcp_ru")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_drcp_ru(
            ulong x) => default;

        [External("__ilgpu__nv_drcp_rz")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_drcp_rz(
            ulong x) => default;

        [External("__ilgpu__nv_dsqrt_rd")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_dsqrt_rd(
            ulong x) => default;

        [External("__ilgpu__nv_dsqrt_rn")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_dsqrt_rn(
            ulong x) => default;

        [External("__ilgpu__nv_dsqrt_ru")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_dsqrt_ru(
            ulong x) => default;

        [External("__ilgpu__nv_dsqrt_rz")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_dsqrt_rz(
            ulong x) => default;

        [External("__ilgpu__nv_erf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_erf(
            ulong x) => default;

        [External("__ilgpu__nv_erfc")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_erfc(
            ulong x) => default;

        [External("__ilgpu__nv_erfcf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_erfcf(
            uint x) => default;

        [External("__ilgpu__nv_erfcinv")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_erfcinv(
            ulong x) => default;

        [External("__ilgpu__nv_erfcinvf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_erfcinvf(
            uint x) => default;

        [External("__ilgpu__nv_erfcx")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_erfcx(
            ulong x) => default;

        [External("__ilgpu__nv_erfcxf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_erfcxf(
            uint x) => default;

        [External("__ilgpu__nv_erff")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_erff(
            uint x) => default;

        [External("__ilgpu__nv_erfinv")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_erfinv(
            ulong x) => default;

        [External("__ilgpu__nv_erfinvf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_erfinvf(
            uint x) => default;

        [External("__ilgpu__nv_exp")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_exp(
            ulong x) => default;

        [External("__ilgpu__nv_exp10")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_exp10(
            ulong x) => default;

        [External("__ilgpu__nv_exp10f")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_exp10f(
            uint x) => default;

        [External("__ilgpu__nv_exp2")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_exp2(
            ulong x) => default;

        [External("__ilgpu__nv_exp2f")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_exp2f(
            uint x) => default;

        [External("__ilgpu__nv_expf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_expf(
            uint x) => default;

        [External("__ilgpu__nv_expm1")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_expm1(
            ulong x) => default;

        [External("__ilgpu__nv_expm1f")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_expm1f(
            uint x) => default;

        [External("__ilgpu__nv_fabs")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_fabs(
            ulong x) => default;

        [External("__ilgpu__nv_fabsf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_fabsf(
            uint x) => default;

        [External("__ilgpu__nv_fadd_rd")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_fadd_rd(
            uint x,
            uint y) => default;

        [External("__ilgpu__nv_fadd_rn")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_fadd_rn(
            uint x,
            uint y) => default;

        [External("__ilgpu__nv_fadd_ru")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_fadd_ru(
            uint x,
            uint y) => default;

        [External("__ilgpu__nv_fadd_rz")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_fadd_rz(
            uint x,
            uint y) => default;

        [External("__ilgpu__nv_fast_cosf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_fast_cosf(
            uint x) => default;

        [External("__ilgpu__nv_fast_exp10f")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_fast_exp10f(
            uint x) => default;

        [External("__ilgpu__nv_fast_expf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_fast_expf(
            uint x) => default;

        [External("__ilgpu__nv_fast_fdividef")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_fast_fdividef(
            uint x,
            uint y) => default;

        [External("__ilgpu__nv_fast_log10f")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_fast_log10f(
            uint x) => default;

        [External("__ilgpu__nv_fast_log2f")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_fast_log2f(
            uint x) => default;

        [External("__ilgpu__nv_fast_logf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_fast_logf(
            uint x) => default;

        [External("__ilgpu__nv_fast_powf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_fast_powf(
            uint x,
            uint y) => default;

        [External("__ilgpu__nv_fast_sincosf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void __nv_fast_sincosf(
            uint x,
            out uint sin,
            out uint cos)
        {
            sin = default;
            cos = default;
        }

        [External("__ilgpu__nv_fast_sinf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_fast_sinf(
            uint x) => default;

        [External("__ilgpu__nv_fast_tanf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_fast_tanf(
            uint x) => default;

        [External("__ilgpu__nv_fdim")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_fdim(
            ulong x,
            ulong y) => default;

        [External("__ilgpu__nv_fdimf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_fdimf(
            uint x,
            uint y) => default;

        [External("__ilgpu__nv_fdiv_rd")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_fdiv_rd(
            uint x,
            uint y) => default;

        [External("__ilgpu__nv_fdiv_rn")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_fdiv_rn(
            uint x,
            uint y) => default;

        [External("__ilgpu__nv_fdiv_ru")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_fdiv_ru(
            uint x,
            uint y) => default;

        [External("__ilgpu__nv_fdiv_rz")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_fdiv_rz(
            uint x,
            uint y) => default;

        [External("__ilgpu__nv_ffs")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int __nv_ffs(
            int x) => default;

        [External("__ilgpu__nv_ffsll")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int __nv_ffsll(
            long x) => default;

        [External("__ilgpu__nv_finitef")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int __nv_finitef(
            uint x) => default;

        [External("__ilgpu__nv_float2half_rn")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_float2half_rn(
            uint x) => default;

        [External("__ilgpu__nv_float2int_rd")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int __nv_float2int_rd(
            uint x) => default;

        [External("__ilgpu__nv_float2int_rn")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int __nv_float2int_rn(
            uint x) => default;

        [External("__ilgpu__nv_float2int_ru")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int __nv_float2int_ru(
            uint x) => default;

        [External("__ilgpu__nv_float2int_rz")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int __nv_float2int_rz(
            uint x) => default;

        [External("__ilgpu__nv_float2ll_rd")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long __nv_float2ll_rd(
            uint x) => default;

        [External("__ilgpu__nv_float2ll_rn")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long __nv_float2ll_rn(
            uint x) => default;

        [External("__ilgpu__nv_float2ll_ru")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long __nv_float2ll_ru(
            uint x) => default;

        [External("__ilgpu__nv_float2ll_rz")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long __nv_float2ll_rz(
            uint x) => default;

        [External("__ilgpu__nv_float2uint_rd")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_float2uint_rd(
            uint x) => default;

        [External("__ilgpu__nv_float2uint_rn")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_float2uint_rn(
            uint x) => default;

        [External("__ilgpu__nv_float2uint_ru")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_float2uint_ru(
            uint x) => default;

        [External("__ilgpu__nv_float2uint_rz")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_float2uint_rz(
            uint x) => default;

        [External("__ilgpu__nv_float2ull_rd")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_float2ull_rd(
            uint x) => default;

        [External("__ilgpu__nv_float2ull_rn")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_float2ull_rn(
            uint x) => default;

        [External("__ilgpu__nv_float2ull_ru")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_float2ull_ru(
            uint x) => default;

        [External("__ilgpu__nv_float2ull_rz")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_float2ull_rz(
            uint x) => default;

        [External("__ilgpu__nv_float_as_int")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int __nv_float_as_int(
            uint x) => default;

        [External("__ilgpu__nv_floor")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_floor(
            ulong x) => default;

        [External("__ilgpu__nv_floorf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_floorf(
            uint x) => default;

        [External("__ilgpu__nv_fma")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_fma(
            ulong x,
            ulong y,
            ulong z) => default;

        [External("__ilgpu__nv_fma_rd")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_fma_rd(
            ulong x,
            ulong y,
            ulong z) => default;

        [External("__ilgpu__nv_fma_rn")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_fma_rn(
            ulong x,
            ulong y,
            ulong z) => default;

        [External("__ilgpu__nv_fma_ru")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_fma_ru(
            ulong x,
            ulong y,
            ulong z) => default;

        [External("__ilgpu__nv_fma_rz")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_fma_rz(
            ulong x,
            ulong y,
            ulong z) => default;

        [External("__ilgpu__nv_fmaf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_fmaf(
            uint x,
            uint y,
            uint z) => default;

        [External("__ilgpu__nv_fmaf_rd")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_fmaf_rd(
            uint x,
            uint y,
            uint z) => default;

        [External("__ilgpu__nv_fmaf_rn")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_fmaf_rn(
            uint x,
            uint y,
            uint z) => default;

        [External("__ilgpu__nv_fmaf_ru")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_fmaf_ru(
            uint x,
            uint y,
            uint z) => default;

        [External("__ilgpu__nv_fmaf_rz")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_fmaf_rz(
            uint x,
            uint y,
            uint z) => default;

        [External("__ilgpu__nv_fmax")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_fmax(
            ulong x,
            ulong y) => default;

        [External("__ilgpu__nv_fmaxf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_fmaxf(
            uint x,
            uint y) => default;

        [External("__ilgpu__nv_fmin")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_fmin(
            ulong x,
            ulong y) => default;

        [External("__ilgpu__nv_fminf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_fminf(
            uint x,
            uint y) => default;

        [External("__ilgpu__nv_fmod")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_fmod(
            ulong x,
            ulong y) => default;

        [External("__ilgpu__nv_fmodf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_fmodf(
            uint x,
            uint y) => default;

        [External("__ilgpu__nv_fmul_rd")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_fmul_rd(
            uint x,
            uint y) => default;

        [External("__ilgpu__nv_fmul_rn")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_fmul_rn(
            uint x,
            uint y) => default;

        [External("__ilgpu__nv_fmul_ru")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_fmul_ru(
            uint x,
            uint y) => default;

        [External("__ilgpu__nv_fmul_rz")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_fmul_rz(
            uint x,
            uint y) => default;

        [External("__ilgpu__nv_frcp_rd")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_frcp_rd(
            uint x) => default;

        [External("__ilgpu__nv_frcp_rn")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_frcp_rn(
            uint x) => default;

        [External("__ilgpu__nv_frcp_ru")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_frcp_ru(
            uint x) => default;

        [External("__ilgpu__nv_frcp_rz")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_frcp_rz(
            uint x) => default;

        [External("__ilgpu__nv_frexp")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_frexp(
            ulong x,
            out int y)
        {
            y = default;
            return default;
        }

        [External("__ilgpu__nv_frexpf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_frexpf(
            uint x,
            out int y)
        {
            y = default;
            return default;
        }

        [External("__ilgpu__nv_frsqrt_rn")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_frsqrt_rn(
            uint x) => default;

        [External("__ilgpu__nv_fsqrt_rd")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_fsqrt_rd(
            uint x) => default;

        [External("__ilgpu__nv_fsqrt_rb")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_fsqrt_rb(
            uint x) => default;

        [External("__ilgpu__nv_fsqrt_ru")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_fsqrt_ru(
            uint x) => default;

        [External("__ilgpu__nv_fsqrt_rz")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_fsqrt_rz(
            uint x) => default;

        [External("__ilgpu__nv_fsub_rd")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_fsub_rd(
            uint x,
            uint y) => default;

        [External("__ilgpu__nv_fsub_rn")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_fsub_rn(
            uint x,
            uint y) => default;

        [External("__ilgpu__nv_fsub_ru")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_fsub_ru(
            uint x,
            uint y) => default;

        [External("__ilgpu__nv_fsub_rz")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_fsub_rz(
            uint x,
            uint y) => default;

        [External("__ilgpu__nv_hadd")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int __nv_hadd(
            int x,
            int y) => default;

        [External("__ilgpu__nv_half2float")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_half2float(
            uint x) => default;

        [External("__ilgpu__nv_hiloint2double")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_hiloint2double(
            int x,
            int y) => default;

        [External("__ilgpu__nv_hypot")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_hypot(
            ulong x,
            ulong y) => default;

        [External("__ilgpu__nv_hypotf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_hypotf(
            uint x,
            uint y) => default;

        [External("__ilgpu__nv_ilogb")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int __nv_ilogb(
            ulong x) => default;

        [External("__ilgpu__nv_ilogbf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int __nv_ilogbf(
            uint x) => default;

        [External("__ilgpu__nv_int2double_rn")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_int2double_rn(
            int x) => default;

        [External("__ilgpu__nv_int2float_rd")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_int2float_rd(
            int x) => default;

        [External("__ilgpu__nv_int2float_rn")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_int2float_rn(
            int x) => default;

        [External("__ilgpu__nv_int2float_ru")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_int2float_ru(
            int x) => default;

        [External("__ilgpu__nv_int2float_rz")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_int2float_rz(
            int x) => default;

        [External("__ilgpu__nv_int_as_float")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_int_as_float(
            int x) => default;

        [External("__ilgpu__nv_isfinited")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int __nv_isfinited(
            ulong x) => default;

        [External("__ilgpu__nv_isinfd")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int __nv_isinfd(
            ulong x) => default;

        [External("__ilgpu__nv_isinff")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int __nv_isinff(
            uint x) => default;

        [External("__ilgpu__nv_isnand")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int __nv_isnand(
            ulong x) => default;

        [External("__ilgpu__nv_isnanf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int __nv_isnanf(
            uint x) => default;

        [External("__ilgpu__nv_j0")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_j0(
            ulong x) => default;

        [External("__ilgpu__nv_j0f")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_j0f(
            uint x) => default;

        [External("__ilgpu__nv_j1")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_j1(
            ulong x) => default;

        [External("__ilgpu__nv_j1f")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_j1f(
            uint x) => default;

        [External("__ilgpu__nv_jn")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_jn(
            int x,
            ulong y) => default;

        [External("__ilgpu__nv_jnf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_jnf(
            int x,
            uint y) => default;

        [External("__ilgpu__nv_ldexp")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_ldexp(
            ulong x,
            int y) => default;

        [External("__ilgpu__nv_ldexpf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_ldexpf(
            uint x,
            int y) => default;

        [External("__ilgpu__nv_lgamma")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_lgamma(
            ulong x) => default;

        [External("__ilgpu__nv_lgammaf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_lgammaf(
            uint x) => default;

        [External("__ilgpu__nv_ll2double_rd")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_ll2double_rd(
            long x) => default;

        [External("__ilgpu__nv_ll2double_rn")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_ll2double_rn(
            long x) => default;

        [External("__ilgpu__nv_ll2double_ru")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_ll2double_ru(
            long x) => default;

        [External("__ilgpu__nv_ll2double_rz")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_ll2double_rz(
            long x) => default;

        [External("__ilgpu__nv_ll2float_rd")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_ll2float_rd(
            long x) => default;

        [External("__ilgpu__nv_ll2float_rn")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_ll2float_rn(
            long x) => default;

        [External("__ilgpu__nv_ll2float_ru")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_ll2float_ru(
            long x) => default;

        [External("__ilgpu__nv_ll2float_rz")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_ll2float_rz(
            long x) => default;

        [External("__ilgpu__nv_llabs")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long __nv_llabs(
            long x) => default;

        [External("__ilgpu__nv_llmax")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long __nv_llmax(
            long x,
            long y) => default;

        [External("__ilgpu__nv_llmin")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long __nv_llmin(
            long x,
            long y) => default;

        [External("__ilgpu__nv_llrint")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long __nv_llrint(
            ulong x) => default;

        [External("__ilgpu__nv_llrintf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long __nv_llrintf(
            uint x) => default;

        [External("__ilgpu__nv_llround")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long __nv_llround(
            ulong x) => default;

        [External("__ilgpu__nv_llroundf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long __nv_llroundf(
            uint x) => default;

        [External("__ilgpu__nv_log")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_log(
            ulong x) => default;

        [External("__ilgpu__nv_log10")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_log10(
            ulong x) => default;

        [External("__ilgpu__nv_log10f")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_log10f(
            uint x) => default;

        [External("__ilgpu__nv_log1p")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_log1p(
            ulong x) => default;

        [External("__ilgpu__nv_log1pf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_log1pf(
            uint x) => default;

        [External("__ilgpu__nv_log2")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_log2(
            ulong x) => default;

        [External("__ilgpu__nv_log2f")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_log2f(
            uint x) => default;

        [External("__ilgpu__nv_logb")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_logb(
            ulong x) => default;

        [External("__ilgpu__nv_logbf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_logbf(
            uint x) => default;

        [External("__ilgpu__nv_logf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_logf(
            uint x) => default;

        [External("__ilgpu__nv_longlong_as_double")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_longlong_as_double(
            long x) => default;

        [External("__ilgpu__nv_max")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int __nv_max(
            int x,
            int y) => default;

        [External("__ilgpu__nv_min")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int __nv_min(
            int x,
            int y) => default;

        [External("__ilgpu__nv_modf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_modf(
            ulong x,
            out ulong b)
        {
            b = default;
            return default;
        }

        [External("__ilgpu__nv_modff")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_modff(
            uint x,
            out uint b)
        {
            b = default;
            return default;
        }

        [External("__ilgpu__nv_mul24")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int __nv_mul24(
            int x,
            int y) => default;

        [External("__ilgpu__nv_mul64hi")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long __nv_mul64hi(
            long x,
            long y) => default;

        [External("__ilgpu__nv_mulhi")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int __nv_mulhi(
            int x,
            int y) => default;

        [External("__ilgpu__nv_nan")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_nan(
            string tagp) => default;

        [External("__ilgpu__nv_nanf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_nanf(
            string tagp) => default;

        [External("__ilgpu__nv_nearbyint")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_nearbyint(
            ulong x) => default;

        [External("__ilgpu__nv_nearbyintf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_nearbyintf(
            uint x) => default;

        [External("__ilgpu__nv_nextafter")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_nextafter(
            ulong x) => default;

        [External("__ilgpu__nv_nextafterf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_nextafterf(
            uint x) => default;

        [External("__ilgpu__nv_normcdf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_normcdf(
            ulong x) => default;

        [External("__ilgpu__nv_normcdff")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_normcdff(
            uint x) => default;

        [External("__ilgpu__nv_normcdfinv")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_normcdfinv(
            ulong x) => default;

        [External("__ilgpu__nv_normcdfinvf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_normcdfinvf(
            uint x) => default;

        [External("__ilgpu__nv_popc")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int __nv_popc(
            int x) => default;

        [External("__ilgpu__nv_popcll")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int __nv_popcll(
            long x) => default;

        [External("__ilgpu__nv_pow")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_pow(
            ulong x,
            ulong y) => default;

        [External("__ilgpu__nv_powf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_powf(
            uint x,
            uint y) => default;

        [External("__ilgpu__nv_powi")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_powi(
            ulong x,
            int y) => default;

        [External("__ilgpu__nv_powif")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_powif(
            uint x,
            int y) => default;

        [External("__ilgpu__nv_rcbrt")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_rcbrt(
            ulong x) => default;

        [External("__ilgpu__nv_rcbrtf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_rcbrtf(
            uint x) => default;

        [External("__ilgpu__nv_remainder")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_remainder(
            ulong x,
            ulong y) => default;

        [External("__ilgpu__nv_remainderf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_remainderf(
            uint x,
            uint y) => default;

        [External("__ilgpu__nv_remquo")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_remquo(
            ulong x,
            ulong y,
            out int quo)
        {
            quo = default;
            return default;
        }

        [External("__ilgpu__nv_remquof")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_remquof(
            uint x,
            uint y,
            out int quo)
        {
            quo = default;
            return default;
        }

        [External("__ilgpu__nv_rhadd")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int __nv_rhadd(
            int x,
            int y) => default;

        [External("__ilgpu__nv_rint")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_rint(
            ulong x) => default;

        [External("__ilgpu__nv_rintf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_rintf(
            uint x) => default;

        [External("__ilgpu__nv_round")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_round(
            ulong x) => default;

        [External("__ilgpu__nv_roundf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_roundf(
            uint x) => default;

        [External("__ilgpu__nv_rsqrt")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_rsqrt(
            ulong x) => default;

        [External("__ilgpu__nv_rsqrtf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_rsqrtf(
            uint x) => default;

        [External("__ilgpu__nv_sad")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int __nv_sad(
            int x,
            int y,
            int z) => default;

        [External("__ilgpu__nv_saturatef")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_saturatef(
            uint x) => default;

        [External("__ilgpu__nv_scalbn")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_scalbn(
            ulong x,
            int y) => default;

        [External("__ilgpu__nv_scalbnf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_scalbnf(
            uint x,
            int y) => default;

        [External("__ilgpu__nv_signbitd")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int __nv_signbitd(
            ulong x) => default;

        [External("__ilgpu__nv_signbitf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int __nv_signbitf(
            uint x) => default;

        [External("__ilgpu__nv_sin")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_sin(
            ulong x) => default;

        [External("__ilgpu__nv_sincos")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void __nv_sincos(
            ulong x,
            out ulong sin,
            out ulong cos)
        {
            sin = default;
            cos = default;
        }

        [External("__ilgpu__nv_sincosf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void __nv_sincosf(
            uint x,
            out uint sin,
            out uint cos)
        {
            sin = default;
            cos = default;
        }

        [External("__ilgpu__nv_sincospi")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void __nv_sincospi(
            ulong x,
            out ulong sin,
            out ulong cos)
        {
            sin = default;
            cos = default;
        }

        [External("__ilgpu__nv_sincospif")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void __nv_sincospif(
            uint x,
            out uint sin,
            out uint cos)
        {
            sin = default;
            cos = default;
        }

        [External("__ilgpu__nv_sinf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_sinf(
            uint x) => default;

        [External("__ilgpu__nv_sinh")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_sinh(
            ulong x) => default;

        [External("__ilgpu__nv_sinhf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_sinhf(
            uint x) => default;

        [External("__ilgpu__nv_sinpi")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_sinpi(
            ulong x) => default;

        [External("__ilgpu__nv_sinpif")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_sinpif(
            uint x) => default;

        [External("__ilgpu__nv_sqrt")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_sqrt(
            ulong x) => default;

        [External("__ilgpu__nv_sqrtf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_sqrtf(
            uint x) => default;

        [External("__ilgpu__nv_tan")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_tan(
            ulong x) => default;

        [External("__ilgpu__nv_tanf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_tanf(
            uint x) => default;

        [External("__ilgpu__nv_tanh")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_tanh(
            ulong x) => default;

        [External("__ilgpu__nv_tanhf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_tanhf(
            uint x) => default;

        [External("__ilgpu__nv_tgamma")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_tgamma(
            ulong x) => default;

        [External("__ilgpu__nv_tgammaf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_tgammaf(
            uint x) => default;

        [External("__ilgpu__nv_trunc")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_trunc(
            ulong x) => default;

        [External("__ilgpu__nv_truncf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_truncf(
            uint x) => default;

        [External("__ilgpu__nv_uhadd")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int __nv_uhadd(
            int x,
            int y) => default;

        [External("__ilgpu__nv_uint2double_rn")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_uint2double_rn(
            int x) => default;

        [External("__ilgpu__nv_uint2float_rd")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_uint2float_rd(
            int x) => default;

        [External("__ilgpu__nv_uint2float_rn")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_uint2float_rn(
            int x) => default;

        [External("__ilgpu__nv_uint2float_ru")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_uint2float_ru(
            int x) => default;

        [External("__ilgpu__nv_uint2float_rz")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_uint2float_rz(
            int x) => default;

        [External("__ilgpu__nv_ull2double_rd")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_ull2double_rd(
            ulong x) => default;

        [External("__ilgpu__nv_ull2double_rn")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_ull2double_rn(
            ulong x) => default;

        [External("__ilgpu__nv_ull2double_ru")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_ull2double_ru(
            ulong x) => default;

        [External("__ilgpu__nv_ull2double_rz")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_ull2double_rz(
            ulong x) => default;

        [External("__ilgpu__nv_ull2float_rd")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_ull2float_rd(
            ulong x) => default;

        [External("__ilgpu__nv_ull2float_rn")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_ull2float_rn(
            ulong x) => default;

        [External("__ilgpu__nv_ull2float_ru")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_ull2float_ru(
            ulong x) => default;

        [External("__ilgpu__nv_ull2float_rz")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_ull2float_rz(
            ulong x) => default;

        [External("__ilgpu__nv_ullmax")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_ullmax(
            ulong x,
            ulong y) => default;

        [External("__ilgpu__nv_ullmin")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_ullmin(
            ulong x,
            ulong y) => default;

        [External("__ilgpu__nv_umax")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_umax(
            uint x,
            uint y) => default;

        [External("__ilgpu__nv_umin")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_umin(
            uint x,
            uint y) => default;

        [External("__ilgpu__nv_umul24")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_umul24(
            uint x,
            uint y) => default;

        [External("__ilgpu__nv_umul64hi")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_umul64hi(
            ulong x,
            ulong y) => default;

        [External("__ilgpu__nv_umulhi")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_umulhi(
            uint x,
            uint y) => default;

        [External("__ilgpu__nv_urhadd")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_urhadd(
            uint x,
            uint y) => default;

        [External("__ilgpu__nv_usad")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_usad(
            uint x,
            uint y,
            uint z) => default;

        [External("__ilgpu__nv_y0")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_y0(
            ulong x) => default;

        [External("__ilgpu__nv_y0f")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_y0f(
            uint x) => default;

        [External("__ilgpu__nv_y1")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_y1(
            ulong x) => default;

        [External("__ilgpu__nv_y1f")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_y1f(
            uint x) => default;

        [External("__ilgpu__nv_yn")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __nv_yn(
            ulong x) => default;

        [External("__ilgpu__nv_ynf")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint __nv_ynf(
            uint x) => default;

    }
}

#pragma warning restore IDE1006 // Naming Styles
