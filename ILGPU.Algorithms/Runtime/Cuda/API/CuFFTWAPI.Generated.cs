// ---------------------------------------------------------------------------------------
//                                   ILGPU Algorithms
//                           Copyright (c) 2021 ILGPU Project
//                                    www.ilgpu.net
//
// File: CuFFTWAPI.Generated.tt/CuFFTWAPI.Generated.cs
//
// This file is part of ILGPU and is distributed under the University of Illinois Open
// Source License. See LICENSE.txt for details.
// ---------------------------------------------------------------------------------------

// ---------------------------------------------------------------------------------------
//                                   ILGPU Algorithms
//                           Copyright (c) 2021 ILGPU Project
//                                    www.ilgpu.net
//
// File: CuFFTW.ttinclude
//
// This file is part of ILGPU and is distributed under the University of Illinois Open
// Source License. See LICENSE.txt for details.
// ---------------------------------------------------------------------------------------


using ILGPU.Util;
using System;
using System.Numerics;

namespace ILGPU.Runtime.Cuda.API
{
    partial class CuFFTWAPI
    {
        #region Basic Interface - Complex to Complex

        /// <summary>
        /// Creates a 1D complex to complex plan.
        /// </summary>
        /// <param name="nx">The transform size.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="sign">The sign of the exponent in the formula.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_dft_1d(
            int nx,
            Span<Complex> @in,
            Span<Complex> @out,
            int sign,
            uint flags)
        {
            fixed (Complex* in_ptr = @in)
            fixed (Complex* out_ptr = @out)
            {
                var plan = fftw_plan_dft_1d(
                    nx,
                    (double*)in_ptr,
                    (double*)out_ptr,
                    sign,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a 2D complex to complex plan.
        /// </summary>
        /// <param name="nx">The transform size in the x dimension.</param>
        /// <param name="ny">The transform size in the y dimension.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="sign">The sign of the exponent in the formula.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_dft_2d(
            int nx,
            int ny,
            Span<Complex> @in,
            Span<Complex> @out,
            int sign,
            uint flags)
        {
            fixed (Complex* in_ptr = @in)
            fixed (Complex* out_ptr = @out)
            {
                var plan = fftw_plan_dft_2d(
                    nx,
                    ny,
                    (double*)in_ptr,
                    (double*)out_ptr,
                    sign,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a 3D complex to complex plan.
        /// </summary>
        /// <param name="nx">The transform size in the x dimension.</param>
        /// <param name="ny">The transform size in the y dimension.</param>
        /// <param name="nz">The transform size in the z dimension.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="sign">The sign of the exponent in the formula.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_dft_3d(
            int nx,
            int ny,
            int nz,
            Span<Complex> @in,
            Span<Complex> @out,
            int sign,
            uint flags)
        {
            fixed (Complex* in_ptr = @in)
            fixed (Complex* out_ptr = @out)
            {
                var plan = fftw_plan_dft_3d(
                    nx,
                    ny,
                    nz,
                    (double*)in_ptr,
                    (double*)out_ptr,
                    sign,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom complex to complex plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="n">The transform dimensions.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="sign">The sign of the exponent in the formula.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_dft(
            int rank,
            ReadOnlySpan<int> n,
            Span<Complex> @in,
            Span<Complex> @out,
            int sign,
            uint flags)
        {
            fixed (int* n_ptr = n)
            fixed (Complex* in_ptr = @in)
            fixed (Complex* out_ptr = @out)
            {
                var plan = fftw_plan_dft(
                    rank,
                    n_ptr,
                    (double*)in_ptr,
                    (double*)out_ptr,
                    sign,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a 1D complex to complex plan.
        /// </summary>
        /// <param name="nx">The transform size.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="sign">The sign of the exponent in the formula.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_dft_1d(
            int nx,
            Span<(double Real, double Imaginary)> @in,
            Span<(double Real, double Imaginary)> @out,
            int sign,
            uint flags)
        {
            fixed ((double Real, double Imaginary)* in_ptr = @in)
            fixed ((double Real, double Imaginary)* out_ptr = @out)
            {
                var plan = fftw_plan_dft_1d(
                    nx,
                    (double*)in_ptr,
                    (double*)out_ptr,
                    sign,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a 2D complex to complex plan.
        /// </summary>
        /// <param name="nx">The transform size in the x dimension.</param>
        /// <param name="ny">The transform size in the y dimension.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="sign">The sign of the exponent in the formula.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_dft_2d(
            int nx,
            int ny,
            Span<(double Real, double Imaginary)> @in,
            Span<(double Real, double Imaginary)> @out,
            int sign,
            uint flags)
        {
            fixed ((double Real, double Imaginary)* in_ptr = @in)
            fixed ((double Real, double Imaginary)* out_ptr = @out)
            {
                var plan = fftw_plan_dft_2d(
                    nx,
                    ny,
                    (double*)in_ptr,
                    (double*)out_ptr,
                    sign,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a 3D complex to complex plan.
        /// </summary>
        /// <param name="nx">The transform size in the x dimension.</param>
        /// <param name="ny">The transform size in the y dimension.</param>
        /// <param name="nz">The transform size in the z dimension.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="sign">The sign of the exponent in the formula.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_dft_3d(
            int nx,
            int ny,
            int nz,
            Span<(double Real, double Imaginary)> @in,
            Span<(double Real, double Imaginary)> @out,
            int sign,
            uint flags)
        {
            fixed ((double Real, double Imaginary)* in_ptr = @in)
            fixed ((double Real, double Imaginary)* out_ptr = @out)
            {
                var plan = fftw_plan_dft_3d(
                    nx,
                    ny,
                    nz,
                    (double*)in_ptr,
                    (double*)out_ptr,
                    sign,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom complex to complex plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="n">The transform dimensions.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="sign">The sign of the exponent in the formula.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_dft(
            int rank,
            ReadOnlySpan<int> n,
            Span<(double Real, double Imaginary)> @in,
            Span<(double Real, double Imaginary)> @out,
            int sign,
            uint flags)
        {
            fixed (int* n_ptr = n)
            fixed ((double Real, double Imaginary)* in_ptr = @in)
            fixed ((double Real, double Imaginary)* out_ptr = @out)
            {
                var plan = fftw_plan_dft(
                    rank,
                    n_ptr,
                    (double*)in_ptr,
                    (double*)out_ptr,
                    sign,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a 1D complex to complex plan.
        /// </summary>
        /// <param name="nx">The transform size.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="sign">The sign of the exponent in the formula.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_dft_1d(
            int nx,
            Span<Double2> @in,
            Span<Double2> @out,
            int sign,
            uint flags)
        {
            fixed (Double2* in_ptr = @in)
            fixed (Double2* out_ptr = @out)
            {
                var plan = fftw_plan_dft_1d(
                    nx,
                    (double*)in_ptr,
                    (double*)out_ptr,
                    sign,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a 2D complex to complex plan.
        /// </summary>
        /// <param name="nx">The transform size in the x dimension.</param>
        /// <param name="ny">The transform size in the y dimension.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="sign">The sign of the exponent in the formula.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_dft_2d(
            int nx,
            int ny,
            Span<Double2> @in,
            Span<Double2> @out,
            int sign,
            uint flags)
        {
            fixed (Double2* in_ptr = @in)
            fixed (Double2* out_ptr = @out)
            {
                var plan = fftw_plan_dft_2d(
                    nx,
                    ny,
                    (double*)in_ptr,
                    (double*)out_ptr,
                    sign,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a 3D complex to complex plan.
        /// </summary>
        /// <param name="nx">The transform size in the x dimension.</param>
        /// <param name="ny">The transform size in the y dimension.</param>
        /// <param name="nz">The transform size in the z dimension.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="sign">The sign of the exponent in the formula.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_dft_3d(
            int nx,
            int ny,
            int nz,
            Span<Double2> @in,
            Span<Double2> @out,
            int sign,
            uint flags)
        {
            fixed (Double2* in_ptr = @in)
            fixed (Double2* out_ptr = @out)
            {
                var plan = fftw_plan_dft_3d(
                    nx,
                    ny,
                    nz,
                    (double*)in_ptr,
                    (double*)out_ptr,
                    sign,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom complex to complex plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="n">The transform dimensions.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="sign">The sign of the exponent in the formula.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_dft(
            int rank,
            ReadOnlySpan<int> n,
            Span<Double2> @in,
            Span<Double2> @out,
            int sign,
            uint flags)
        {
            fixed (int* n_ptr = n)
            fixed (Double2* in_ptr = @in)
            fixed (Double2* out_ptr = @out)
            {
                var plan = fftw_plan_dft(
                    rank,
                    n_ptr,
                    (double*)in_ptr,
                    (double*)out_ptr,
                    sign,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a 1D complex to complex plan.
        /// </summary>
        /// <param name="nx">The transform size.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="sign">The sign of the exponent in the formula.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftwf_plan_dft_1d(
            int nx,
            Span<(float Real, float Imaginary)> @in,
            Span<(float Real, float Imaginary)> @out,
            int sign,
            uint flags)
        {
            fixed ((float Real, float Imaginary)* in_ptr = @in)
            fixed ((float Real, float Imaginary)* out_ptr = @out)
            {
                var plan = fftwf_plan_dft_1d(
                    nx,
                    (float*)in_ptr,
                    (float*)out_ptr,
                    sign,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a 2D complex to complex plan.
        /// </summary>
        /// <param name="nx">The transform size in the x dimension.</param>
        /// <param name="ny">The transform size in the y dimension.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="sign">The sign of the exponent in the formula.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftwf_plan_dft_2d(
            int nx,
            int ny,
            Span<(float Real, float Imaginary)> @in,
            Span<(float Real, float Imaginary)> @out,
            int sign,
            uint flags)
        {
            fixed ((float Real, float Imaginary)* in_ptr = @in)
            fixed ((float Real, float Imaginary)* out_ptr = @out)
            {
                var plan = fftwf_plan_dft_2d(
                    nx,
                    ny,
                    (float*)in_ptr,
                    (float*)out_ptr,
                    sign,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a 3D complex to complex plan.
        /// </summary>
        /// <param name="nx">The transform size in the x dimension.</param>
        /// <param name="ny">The transform size in the y dimension.</param>
        /// <param name="nz">The transform size in the z dimension.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="sign">The sign of the exponent in the formula.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftwf_plan_dft_3d(
            int nx,
            int ny,
            int nz,
            Span<(float Real, float Imaginary)> @in,
            Span<(float Real, float Imaginary)> @out,
            int sign,
            uint flags)
        {
            fixed ((float Real, float Imaginary)* in_ptr = @in)
            fixed ((float Real, float Imaginary)* out_ptr = @out)
            {
                var plan = fftwf_plan_dft_3d(
                    nx,
                    ny,
                    nz,
                    (float*)in_ptr,
                    (float*)out_ptr,
                    sign,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom complex to complex plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="n">The transform dimensions.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="sign">The sign of the exponent in the formula.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftwf_plan_dft(
            int rank,
            ReadOnlySpan<int> n,
            Span<(float Real, float Imaginary)> @in,
            Span<(float Real, float Imaginary)> @out,
            int sign,
            uint flags)
        {
            fixed (int* n_ptr = n)
            fixed ((float Real, float Imaginary)* in_ptr = @in)
            fixed ((float Real, float Imaginary)* out_ptr = @out)
            {
                var plan = fftwf_plan_dft(
                    rank,
                    n_ptr,
                    (float*)in_ptr,
                    (float*)out_ptr,
                    sign,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a 1D complex to complex plan.
        /// </summary>
        /// <param name="nx">The transform size.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="sign">The sign of the exponent in the formula.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftwf_plan_dft_1d(
            int nx,
            Span<Float2> @in,
            Span<Float2> @out,
            int sign,
            uint flags)
        {
            fixed (Float2* in_ptr = @in)
            fixed (Float2* out_ptr = @out)
            {
                var plan = fftwf_plan_dft_1d(
                    nx,
                    (float*)in_ptr,
                    (float*)out_ptr,
                    sign,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a 2D complex to complex plan.
        /// </summary>
        /// <param name="nx">The transform size in the x dimension.</param>
        /// <param name="ny">The transform size in the y dimension.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="sign">The sign of the exponent in the formula.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftwf_plan_dft_2d(
            int nx,
            int ny,
            Span<Float2> @in,
            Span<Float2> @out,
            int sign,
            uint flags)
        {
            fixed (Float2* in_ptr = @in)
            fixed (Float2* out_ptr = @out)
            {
                var plan = fftwf_plan_dft_2d(
                    nx,
                    ny,
                    (float*)in_ptr,
                    (float*)out_ptr,
                    sign,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a 3D complex to complex plan.
        /// </summary>
        /// <param name="nx">The transform size in the x dimension.</param>
        /// <param name="ny">The transform size in the y dimension.</param>
        /// <param name="nz">The transform size in the z dimension.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="sign">The sign of the exponent in the formula.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftwf_plan_dft_3d(
            int nx,
            int ny,
            int nz,
            Span<Float2> @in,
            Span<Float2> @out,
            int sign,
            uint flags)
        {
            fixed (Float2* in_ptr = @in)
            fixed (Float2* out_ptr = @out)
            {
                var plan = fftwf_plan_dft_3d(
                    nx,
                    ny,
                    nz,
                    (float*)in_ptr,
                    (float*)out_ptr,
                    sign,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom complex to complex plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="n">The transform dimensions.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="sign">The sign of the exponent in the formula.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftwf_plan_dft(
            int rank,
            ReadOnlySpan<int> n,
            Span<Float2> @in,
            Span<Float2> @out,
            int sign,
            uint flags)
        {
            fixed (int* n_ptr = n)
            fixed (Float2* in_ptr = @in)
            fixed (Float2* out_ptr = @out)
            {
                var plan = fftwf_plan_dft(
                    rank,
                    n_ptr,
                    (float*)in_ptr,
                    (float*)out_ptr,
                    sign,
                    flags);
                return plan;
            }
        }

        #endregion

        #region Basic Interface - Real to Complex

        /// <summary>
        /// Creates a 1D real to complex plan.
        /// </summary>
        /// <param name="nx">The transform size.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_dft_r2c_1d(
            int nx,
            Span<double> @in,
            Span<Complex> @out,
            uint flags)
        {
            fixed (double* in_ptr = @in)
            fixed (Complex* out_ptr = @out)
            {
                var plan = fftw_plan_dft_r2c_1d(
                    nx,
                    in_ptr,
                    (double*)out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a 2D real to complex plan.
        /// </summary>
        /// <param name="nx">The transform size in the x dimension.</param>
        /// <param name="ny">The transform size in the y dimension.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_dft_r2c_2d(
            int nx,
            int ny,
            Span<double> @in,
            Span<Complex> @out,
            uint flags)
        {
            fixed (double* in_ptr = @in)
            fixed (Complex* out_ptr = @out)
            {
                var plan = fftw_plan_dft_r2c_2d(
                    nx,
                    ny,
                    in_ptr,
                    (double*)out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a 3D real to complex plan.
        /// </summary>
        /// <param name="nx">The transform size in the x dimension.</param>
        /// <param name="ny">The transform size in the y dimension.</param>
        /// <param name="nz">The transform size in the z dimension.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_dft_r2c_3d(
            int nx,
            int ny,
            int nz,
            Span<double> @in,
            Span<Complex> @out,
            uint flags)
        {
            fixed (double* in_ptr = @in)
            fixed (Complex* out_ptr = @out)
            {
                var plan = fftw_plan_dft_r2c_3d(
                    nx,
                    ny,
                    nz,
                    in_ptr,
                    (double*)out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom real to complex plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="n">The transform dimensions.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_dft_r2c(
            int rank,
            ReadOnlySpan<int> n,
            Span<double> @in,
            Span<Complex> @out,
            uint flags)
        {
            fixed (int* n_ptr = n)
            fixed (double* in_ptr = @in)
            fixed (Complex* out_ptr = @out)
            {
                var plan = fftw_plan_dft_r2c(
                    rank,
                    n_ptr,
                    in_ptr,
                    (double*)out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a 1D real to complex plan.
        /// </summary>
        /// <param name="nx">The transform size.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_dft_r2c_1d(
            int nx,
            Span<double> @in,
            Span<(double Real, double Imaginary)> @out,
            uint flags)
        {
            fixed (double* in_ptr = @in)
            fixed ((double Real, double Imaginary)* out_ptr = @out)
            {
                var plan = fftw_plan_dft_r2c_1d(
                    nx,
                    in_ptr,
                    (double*)out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a 2D real to complex plan.
        /// </summary>
        /// <param name="nx">The transform size in the x dimension.</param>
        /// <param name="ny">The transform size in the y dimension.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_dft_r2c_2d(
            int nx,
            int ny,
            Span<double> @in,
            Span<(double Real, double Imaginary)> @out,
            uint flags)
        {
            fixed (double* in_ptr = @in)
            fixed ((double Real, double Imaginary)* out_ptr = @out)
            {
                var plan = fftw_plan_dft_r2c_2d(
                    nx,
                    ny,
                    in_ptr,
                    (double*)out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a 3D real to complex plan.
        /// </summary>
        /// <param name="nx">The transform size in the x dimension.</param>
        /// <param name="ny">The transform size in the y dimension.</param>
        /// <param name="nz">The transform size in the z dimension.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_dft_r2c_3d(
            int nx,
            int ny,
            int nz,
            Span<double> @in,
            Span<(double Real, double Imaginary)> @out,
            uint flags)
        {
            fixed (double* in_ptr = @in)
            fixed ((double Real, double Imaginary)* out_ptr = @out)
            {
                var plan = fftw_plan_dft_r2c_3d(
                    nx,
                    ny,
                    nz,
                    in_ptr,
                    (double*)out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom real to complex plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="n">The transform dimensions.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_dft_r2c(
            int rank,
            ReadOnlySpan<int> n,
            Span<double> @in,
            Span<(double Real, double Imaginary)> @out,
            uint flags)
        {
            fixed (int* n_ptr = n)
            fixed (double* in_ptr = @in)
            fixed ((double Real, double Imaginary)* out_ptr = @out)
            {
                var plan = fftw_plan_dft_r2c(
                    rank,
                    n_ptr,
                    in_ptr,
                    (double*)out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a 1D real to complex plan.
        /// </summary>
        /// <param name="nx">The transform size.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_dft_r2c_1d(
            int nx,
            Span<double> @in,
            Span<Double2> @out,
            uint flags)
        {
            fixed (double* in_ptr = @in)
            fixed (Double2* out_ptr = @out)
            {
                var plan = fftw_plan_dft_r2c_1d(
                    nx,
                    in_ptr,
                    (double*)out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a 2D real to complex plan.
        /// </summary>
        /// <param name="nx">The transform size in the x dimension.</param>
        /// <param name="ny">The transform size in the y dimension.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_dft_r2c_2d(
            int nx,
            int ny,
            Span<double> @in,
            Span<Double2> @out,
            uint flags)
        {
            fixed (double* in_ptr = @in)
            fixed (Double2* out_ptr = @out)
            {
                var plan = fftw_plan_dft_r2c_2d(
                    nx,
                    ny,
                    in_ptr,
                    (double*)out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a 3D real to complex plan.
        /// </summary>
        /// <param name="nx">The transform size in the x dimension.</param>
        /// <param name="ny">The transform size in the y dimension.</param>
        /// <param name="nz">The transform size in the z dimension.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_dft_r2c_3d(
            int nx,
            int ny,
            int nz,
            Span<double> @in,
            Span<Double2> @out,
            uint flags)
        {
            fixed (double* in_ptr = @in)
            fixed (Double2* out_ptr = @out)
            {
                var plan = fftw_plan_dft_r2c_3d(
                    nx,
                    ny,
                    nz,
                    in_ptr,
                    (double*)out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom real to complex plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="n">The transform dimensions.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_dft_r2c(
            int rank,
            ReadOnlySpan<int> n,
            Span<double> @in,
            Span<Double2> @out,
            uint flags)
        {
            fixed (int* n_ptr = n)
            fixed (double* in_ptr = @in)
            fixed (Double2* out_ptr = @out)
            {
                var plan = fftw_plan_dft_r2c(
                    rank,
                    n_ptr,
                    in_ptr,
                    (double*)out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a 1D real to complex plan.
        /// </summary>
        /// <param name="nx">The transform size.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftwf_plan_dft_r2c_1d(
            int nx,
            Span<float> @in,
            Span<(float Real, float Imaginary)> @out,
            uint flags)
        {
            fixed (float* in_ptr = @in)
            fixed ((float Real, float Imaginary)* out_ptr = @out)
            {
                var plan = fftwf_plan_dft_r2c_1d(
                    nx,
                    in_ptr,
                    (float*)out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a 2D real to complex plan.
        /// </summary>
        /// <param name="nx">The transform size in the x dimension.</param>
        /// <param name="ny">The transform size in the y dimension.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftwf_plan_dft_r2c_2d(
            int nx,
            int ny,
            Span<float> @in,
            Span<(float Real, float Imaginary)> @out,
            uint flags)
        {
            fixed (float* in_ptr = @in)
            fixed ((float Real, float Imaginary)* out_ptr = @out)
            {
                var plan = fftwf_plan_dft_r2c_2d(
                    nx,
                    ny,
                    in_ptr,
                    (float*)out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a 3D real to complex plan.
        /// </summary>
        /// <param name="nx">The transform size in the x dimension.</param>
        /// <param name="ny">The transform size in the y dimension.</param>
        /// <param name="nz">The transform size in the z dimension.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftwf_plan_dft_r2c_3d(
            int nx,
            int ny,
            int nz,
            Span<float> @in,
            Span<(float Real, float Imaginary)> @out,
            uint flags)
        {
            fixed (float* in_ptr = @in)
            fixed ((float Real, float Imaginary)* out_ptr = @out)
            {
                var plan = fftwf_plan_dft_r2c_3d(
                    nx,
                    ny,
                    nz,
                    in_ptr,
                    (float*)out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom real to complex plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="n">The transform dimensions.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftwf_plan_dft_r2c(
            int rank,
            ReadOnlySpan<int> n,
            Span<float> @in,
            Span<(float Real, float Imaginary)> @out,
            uint flags)
        {
            fixed (int* n_ptr = n)
            fixed (float* in_ptr = @in)
            fixed ((float Real, float Imaginary)* out_ptr = @out)
            {
                var plan = fftwf_plan_dft_r2c(
                    rank,
                    n_ptr,
                    in_ptr,
                    (float*)out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a 1D real to complex plan.
        /// </summary>
        /// <param name="nx">The transform size.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftwf_plan_dft_r2c_1d(
            int nx,
            Span<float> @in,
            Span<Float2> @out,
            uint flags)
        {
            fixed (float* in_ptr = @in)
            fixed (Float2* out_ptr = @out)
            {
                var plan = fftwf_plan_dft_r2c_1d(
                    nx,
                    in_ptr,
                    (float*)out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a 2D real to complex plan.
        /// </summary>
        /// <param name="nx">The transform size in the x dimension.</param>
        /// <param name="ny">The transform size in the y dimension.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftwf_plan_dft_r2c_2d(
            int nx,
            int ny,
            Span<float> @in,
            Span<Float2> @out,
            uint flags)
        {
            fixed (float* in_ptr = @in)
            fixed (Float2* out_ptr = @out)
            {
                var plan = fftwf_plan_dft_r2c_2d(
                    nx,
                    ny,
                    in_ptr,
                    (float*)out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a 3D real to complex plan.
        /// </summary>
        /// <param name="nx">The transform size in the x dimension.</param>
        /// <param name="ny">The transform size in the y dimension.</param>
        /// <param name="nz">The transform size in the z dimension.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftwf_plan_dft_r2c_3d(
            int nx,
            int ny,
            int nz,
            Span<float> @in,
            Span<Float2> @out,
            uint flags)
        {
            fixed (float* in_ptr = @in)
            fixed (Float2* out_ptr = @out)
            {
                var plan = fftwf_plan_dft_r2c_3d(
                    nx,
                    ny,
                    nz,
                    in_ptr,
                    (float*)out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom real to complex plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="n">The transform dimensions.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftwf_plan_dft_r2c(
            int rank,
            ReadOnlySpan<int> n,
            Span<float> @in,
            Span<Float2> @out,
            uint flags)
        {
            fixed (int* n_ptr = n)
            fixed (float* in_ptr = @in)
            fixed (Float2* out_ptr = @out)
            {
                var plan = fftwf_plan_dft_r2c(
                    rank,
                    n_ptr,
                    in_ptr,
                    (float*)out_ptr,
                    flags);
                return plan;
            }
        }

        #endregion

        #region Basic Interface - Complex to Real

        /// <summary>
        /// Creates a 1D complex to real plan.
        /// </summary>
        /// <param name="nx">The transform size.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_dft_c2r_1d(
            int nx,
            Span<Complex> @in,
            Span<double> @out,
            uint flags)
        {
            fixed (Complex* in_ptr = @in)
            fixed (double* out_ptr = @out)
            {
                var plan = fftw_plan_dft_c2r_1d(
                    nx,
                    (double*)in_ptr,
                    out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a 2D complex to real plan.
        /// </summary>
        /// <param name="nx">The transform size in the x dimension.</param>
        /// <param name="ny">The transform size in the y dimension.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_dft_c2r_2d(
            int nx,
            int ny,
            Span<Complex> @in,
            Span<double> @out,
            uint flags)
        {
            fixed (Complex* in_ptr = @in)
            fixed (double* out_ptr = @out)
            {
                var plan = fftw_plan_dft_c2r_2d(
                    nx,
                    ny,
                    (double*)in_ptr,
                    out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a 3D complex to real plan.
        /// </summary>
        /// <param name="nx">The transform size in the x dimension.</param>
        /// <param name="ny">The transform size in the y dimension.</param>
        /// <param name="nz">The transform size in the z dimension.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_dft_c2r_3d(
            int nx,
            int ny,
            int nz,
            Span<Complex> @in,
            Span<double> @out,
            uint flags)
        {
            fixed (Complex* in_ptr = @in)
            fixed (double* out_ptr = @out)
            {
                var plan = fftw_plan_dft_c2r_3d(
                    nx,
                    ny,
                    nz,
                    (double*)in_ptr,
                    out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom complex to real plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="n">The transform dimensions.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_dft_c2r(
            int rank,
            ReadOnlySpan<int> n,
            Span<Complex> @in,
            Span<double> @out,
            uint flags)
        {
            fixed (int* n_ptr = n)
            fixed (Complex* in_ptr = @in)
            fixed (double* out_ptr = @out)
            {
                var plan = fftw_plan_dft_c2r(
                    rank,
                    n_ptr,
                    (double*)in_ptr,
                    out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a 1D complex to real plan.
        /// </summary>
        /// <param name="nx">The transform size.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_dft_c2r_1d(
            int nx,
            Span<(double Real, double Imaginary)> @in,
            Span<double> @out,
            uint flags)
        {
            fixed ((double Real, double Imaginary)* in_ptr = @in)
            fixed (double* out_ptr = @out)
            {
                var plan = fftw_plan_dft_c2r_1d(
                    nx,
                    (double*)in_ptr,
                    out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a 2D complex to real plan.
        /// </summary>
        /// <param name="nx">The transform size in the x dimension.</param>
        /// <param name="ny">The transform size in the y dimension.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_dft_c2r_2d(
            int nx,
            int ny,
            Span<(double Real, double Imaginary)> @in,
            Span<double> @out,
            uint flags)
        {
            fixed ((double Real, double Imaginary)* in_ptr = @in)
            fixed (double* out_ptr = @out)
            {
                var plan = fftw_plan_dft_c2r_2d(
                    nx,
                    ny,
                    (double*)in_ptr,
                    out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a 3D complex to real plan.
        /// </summary>
        /// <param name="nx">The transform size in the x dimension.</param>
        /// <param name="ny">The transform size in the y dimension.</param>
        /// <param name="nz">The transform size in the z dimension.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_dft_c2r_3d(
            int nx,
            int ny,
            int nz,
            Span<(double Real, double Imaginary)> @in,
            Span<double> @out,
            uint flags)
        {
            fixed ((double Real, double Imaginary)* in_ptr = @in)
            fixed (double* out_ptr = @out)
            {
                var plan = fftw_plan_dft_c2r_3d(
                    nx,
                    ny,
                    nz,
                    (double*)in_ptr,
                    out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom complex to real plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="n">The transform dimensions.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_dft_c2r(
            int rank,
            ReadOnlySpan<int> n,
            Span<(double Real, double Imaginary)> @in,
            Span<double> @out,
            uint flags)
        {
            fixed (int* n_ptr = n)
            fixed ((double Real, double Imaginary)* in_ptr = @in)
            fixed (double* out_ptr = @out)
            {
                var plan = fftw_plan_dft_c2r(
                    rank,
                    n_ptr,
                    (double*)in_ptr,
                    out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a 1D complex to real plan.
        /// </summary>
        /// <param name="nx">The transform size.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_dft_c2r_1d(
            int nx,
            Span<Double2> @in,
            Span<double> @out,
            uint flags)
        {
            fixed (Double2* in_ptr = @in)
            fixed (double* out_ptr = @out)
            {
                var plan = fftw_plan_dft_c2r_1d(
                    nx,
                    (double*)in_ptr,
                    out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a 2D complex to real plan.
        /// </summary>
        /// <param name="nx">The transform size in the x dimension.</param>
        /// <param name="ny">The transform size in the y dimension.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_dft_c2r_2d(
            int nx,
            int ny,
            Span<Double2> @in,
            Span<double> @out,
            uint flags)
        {
            fixed (Double2* in_ptr = @in)
            fixed (double* out_ptr = @out)
            {
                var plan = fftw_plan_dft_c2r_2d(
                    nx,
                    ny,
                    (double*)in_ptr,
                    out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a 3D complex to real plan.
        /// </summary>
        /// <param name="nx">The transform size in the x dimension.</param>
        /// <param name="ny">The transform size in the y dimension.</param>
        /// <param name="nz">The transform size in the z dimension.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_dft_c2r_3d(
            int nx,
            int ny,
            int nz,
            Span<Double2> @in,
            Span<double> @out,
            uint flags)
        {
            fixed (Double2* in_ptr = @in)
            fixed (double* out_ptr = @out)
            {
                var plan = fftw_plan_dft_c2r_3d(
                    nx,
                    ny,
                    nz,
                    (double*)in_ptr,
                    out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom complex to real plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="n">The transform dimensions.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_dft_c2r(
            int rank,
            ReadOnlySpan<int> n,
            Span<Double2> @in,
            Span<double> @out,
            uint flags)
        {
            fixed (int* n_ptr = n)
            fixed (Double2* in_ptr = @in)
            fixed (double* out_ptr = @out)
            {
                var plan = fftw_plan_dft_c2r(
                    rank,
                    n_ptr,
                    (double*)in_ptr,
                    out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a 1D complex to real plan.
        /// </summary>
        /// <param name="nx">The transform size.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftwf_plan_dft_c2r_1d(
            int nx,
            Span<(float Real, float Imaginary)> @in,
            Span<float> @out,
            uint flags)
        {
            fixed ((float Real, float Imaginary)* in_ptr = @in)
            fixed (float* out_ptr = @out)
            {
                var plan = fftwf_plan_dft_c2r_1d(
                    nx,
                    (float*)in_ptr,
                    out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a 2D complex to real plan.
        /// </summary>
        /// <param name="nx">The transform size in the x dimension.</param>
        /// <param name="ny">The transform size in the y dimension.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftwf_plan_dft_c2r_2d(
            int nx,
            int ny,
            Span<(float Real, float Imaginary)> @in,
            Span<float> @out,
            uint flags)
        {
            fixed ((float Real, float Imaginary)* in_ptr = @in)
            fixed (float* out_ptr = @out)
            {
                var plan = fftwf_plan_dft_c2r_2d(
                    nx,
                    ny,
                    (float*)in_ptr,
                    out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a 3D complex to real plan.
        /// </summary>
        /// <param name="nx">The transform size in the x dimension.</param>
        /// <param name="ny">The transform size in the y dimension.</param>
        /// <param name="nz">The transform size in the z dimension.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftwf_plan_dft_c2r_3d(
            int nx,
            int ny,
            int nz,
            Span<(float Real, float Imaginary)> @in,
            Span<float> @out,
            uint flags)
        {
            fixed ((float Real, float Imaginary)* in_ptr = @in)
            fixed (float* out_ptr = @out)
            {
                var plan = fftwf_plan_dft_c2r_3d(
                    nx,
                    ny,
                    nz,
                    (float*)in_ptr,
                    out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom complex to real plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="n">The transform dimensions.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftwf_plan_dft_c2r(
            int rank,
            ReadOnlySpan<int> n,
            Span<(float Real, float Imaginary)> @in,
            Span<float> @out,
            uint flags)
        {
            fixed (int* n_ptr = n)
            fixed ((float Real, float Imaginary)* in_ptr = @in)
            fixed (float* out_ptr = @out)
            {
                var plan = fftwf_plan_dft_c2r(
                    rank,
                    n_ptr,
                    (float*)in_ptr,
                    out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a 1D complex to real plan.
        /// </summary>
        /// <param name="nx">The transform size.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftwf_plan_dft_c2r_1d(
            int nx,
            Span<Float2> @in,
            Span<float> @out,
            uint flags)
        {
            fixed (Float2* in_ptr = @in)
            fixed (float* out_ptr = @out)
            {
                var plan = fftwf_plan_dft_c2r_1d(
                    nx,
                    (float*)in_ptr,
                    out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a 2D complex to real plan.
        /// </summary>
        /// <param name="nx">The transform size in the x dimension.</param>
        /// <param name="ny">The transform size in the y dimension.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftwf_plan_dft_c2r_2d(
            int nx,
            int ny,
            Span<Float2> @in,
            Span<float> @out,
            uint flags)
        {
            fixed (Float2* in_ptr = @in)
            fixed (float* out_ptr = @out)
            {
                var plan = fftwf_plan_dft_c2r_2d(
                    nx,
                    ny,
                    (float*)in_ptr,
                    out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a 3D complex to real plan.
        /// </summary>
        /// <param name="nx">The transform size in the x dimension.</param>
        /// <param name="ny">The transform size in the y dimension.</param>
        /// <param name="nz">The transform size in the z dimension.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftwf_plan_dft_c2r_3d(
            int nx,
            int ny,
            int nz,
            Span<Float2> @in,
            Span<float> @out,
            uint flags)
        {
            fixed (Float2* in_ptr = @in)
            fixed (float* out_ptr = @out)
            {
                var plan = fftwf_plan_dft_c2r_3d(
                    nx,
                    ny,
                    nz,
                    (float*)in_ptr,
                    out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom complex to real plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="n">The transform dimensions.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftwf_plan_dft_c2r(
            int rank,
            ReadOnlySpan<int> n,
            Span<Float2> @in,
            Span<float> @out,
            uint flags)
        {
            fixed (int* n_ptr = n)
            fixed (Float2* in_ptr = @in)
            fixed (float* out_ptr = @out)
            {
                var plan = fftwf_plan_dft_c2r(
                    rank,
                    n_ptr,
                    (float*)in_ptr,
                    out_ptr,
                    flags);
                return plan;
            }
        }

        #endregion

        #region Advanced Interface

        /// <summary>
        /// Creates a custom complex to complex plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="n">The transform dimensions.</param>
        /// <param name="batch">The number of transforms.</param>
        /// <param name="in">The input array.</param>
        /// <param name="inembed">The storage dimensions of the input data.</param>
        /// <param name="istride">The stride of the input data.</param>
        /// <param name="idist">The distance of the input data.</param>
        /// <param name="out">The output array.</param>
        /// <param name="onembed">The storage dimensions of the output data.</param>
        /// <param name="ostride">The stride of the output data.</param>
        /// <param name="odist">The distance of the output data.</param>
        /// <param name="sign">The sign of the exponent in the formula.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_many_dft(
            int rank,
            ReadOnlySpan<int> n,
            int batch,
            Span<Complex> @in,
            ReadOnlySpan<int> inembed,
            int istride,
            int idist,
            Span<Complex> @out,
            ReadOnlySpan<int> onembed,
            int ostride,
            int odist,
            int sign,
            uint flags)
        {
            fixed (int* n_ptr = n)
            fixed (Complex* in_ptr = @in)
            fixed (int* inembed_ptr = inembed)
            fixed (Complex* out_ptr = @out)
            fixed (int* onembed_ptr = onembed)
            {
                var plan = fftw_plan_many_dft(
                    rank,
                    n_ptr,
                    batch,
                    (double*)in_ptr,
                    inembed_ptr,
                    istride,
                    idist,
                    (double*)out_ptr,
                    onembed_ptr,
                    ostride,
                    odist,
                    sign,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom real to complex plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="n">The transform dimensions.</param>
        /// <param name="batch">The number of transforms.</param>
        /// <param name="in">The input array.</param>
        /// <param name="inembed">The storage dimensions of the input data.</param>
        /// <param name="istride">The stride of the input data.</param>
        /// <param name="idist">The distance of the input data.</param>
        /// <param name="out">The output array.</param>
        /// <param name="onembed">The storage dimensions of the output data.</param>
        /// <param name="ostride">The stride of the output data.</param>
        /// <param name="odist">The distance of the output data.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_many_dft_r2c(
            int rank,
            ReadOnlySpan<int> n,
            int batch,
            Span<double> @in,
            ReadOnlySpan<int> inembed,
            int istride,
            int idist,
            Span<Complex> @out,
            ReadOnlySpan<int> onembed,
            int ostride,
            int odist,
            uint flags)
        {
            fixed (int* n_ptr = n)
            fixed (double* in_ptr = @in)
            fixed (int* inembed_ptr = inembed)
            fixed (Complex* out_ptr = @out)
            fixed (int* onembed_ptr = onembed)
            {
                var plan = fftw_plan_many_dft_r2c(
                    rank,
                    n_ptr,
                    batch,
                    in_ptr,
                    inembed_ptr,
                    istride,
                    idist,
                    (double*)out_ptr,
                    onembed_ptr,
                    ostride,
                    odist,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom complex to real plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="n">The transform dimensions.</param>
        /// <param name="batch">The number of transforms.</param>
        /// <param name="in">The input array.</param>
        /// <param name="inembed">The storage dimensions of the input data.</param>
        /// <param name="istride">The stride of the input data.</param>
        /// <param name="idist">The distance of the input data.</param>
        /// <param name="out">The output array.</param>
        /// <param name="onembed">The storage dimensions of the output data.</param>
        /// <param name="ostride">The stride of the output data.</param>
        /// <param name="odist">The distance of the output data.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_many_dft_c2r(
            int rank,
            ReadOnlySpan<int> n,
            int batch,
            Span<Complex> @in,
            ReadOnlySpan<int> inembed,
            int istride,
            int idist,
            Span<double> @out,
            ReadOnlySpan<int> onembed,
            int ostride,
            int odist,
            uint flags)
        {
            fixed (int* n_ptr = n)
            fixed (Complex* in_ptr = @in)
            fixed (int* inembed_ptr = inembed)
            fixed (double* out_ptr = @out)
            fixed (int* onembed_ptr = onembed)
            {
                var plan = fftw_plan_many_dft_c2r(
                    rank,
                    n_ptr,
                    batch,
                    (double*)in_ptr,
                    inembed_ptr,
                    istride,
                    idist,
                    out_ptr,
                    onembed_ptr,
                    ostride,
                    odist,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom complex to complex plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="n">The transform dimensions.</param>
        /// <param name="batch">The number of transforms.</param>
        /// <param name="in">The input array.</param>
        /// <param name="inembed">The storage dimensions of the input data.</param>
        /// <param name="istride">The stride of the input data.</param>
        /// <param name="idist">The distance of the input data.</param>
        /// <param name="out">The output array.</param>
        /// <param name="onembed">The storage dimensions of the output data.</param>
        /// <param name="ostride">The stride of the output data.</param>
        /// <param name="odist">The distance of the output data.</param>
        /// <param name="sign">The sign of the exponent in the formula.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_many_dft(
            int rank,
            ReadOnlySpan<int> n,
            int batch,
            Span<(double Real, double Imaginary)> @in,
            ReadOnlySpan<int> inembed,
            int istride,
            int idist,
            Span<(double Real, double Imaginary)> @out,
            ReadOnlySpan<int> onembed,
            int ostride,
            int odist,
            int sign,
            uint flags)
        {
            fixed (int* n_ptr = n)
            fixed ((double Real, double Imaginary)* in_ptr = @in)
            fixed (int* inembed_ptr = inembed)
            fixed ((double Real, double Imaginary)* out_ptr = @out)
            fixed (int* onembed_ptr = onembed)
            {
                var plan = fftw_plan_many_dft(
                    rank,
                    n_ptr,
                    batch,
                    (double*)in_ptr,
                    inembed_ptr,
                    istride,
                    idist,
                    (double*)out_ptr,
                    onembed_ptr,
                    ostride,
                    odist,
                    sign,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom real to complex plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="n">The transform dimensions.</param>
        /// <param name="batch">The number of transforms.</param>
        /// <param name="in">The input array.</param>
        /// <param name="inembed">The storage dimensions of the input data.</param>
        /// <param name="istride">The stride of the input data.</param>
        /// <param name="idist">The distance of the input data.</param>
        /// <param name="out">The output array.</param>
        /// <param name="onembed">The storage dimensions of the output data.</param>
        /// <param name="ostride">The stride of the output data.</param>
        /// <param name="odist">The distance of the output data.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_many_dft_r2c(
            int rank,
            ReadOnlySpan<int> n,
            int batch,
            Span<double> @in,
            ReadOnlySpan<int> inembed,
            int istride,
            int idist,
            Span<(double Real, double Imaginary)> @out,
            ReadOnlySpan<int> onembed,
            int ostride,
            int odist,
            uint flags)
        {
            fixed (int* n_ptr = n)
            fixed (double* in_ptr = @in)
            fixed (int* inembed_ptr = inembed)
            fixed ((double Real, double Imaginary)* out_ptr = @out)
            fixed (int* onembed_ptr = onembed)
            {
                var plan = fftw_plan_many_dft_r2c(
                    rank,
                    n_ptr,
                    batch,
                    in_ptr,
                    inembed_ptr,
                    istride,
                    idist,
                    (double*)out_ptr,
                    onembed_ptr,
                    ostride,
                    odist,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom complex to real plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="n">The transform dimensions.</param>
        /// <param name="batch">The number of transforms.</param>
        /// <param name="in">The input array.</param>
        /// <param name="inembed">The storage dimensions of the input data.</param>
        /// <param name="istride">The stride of the input data.</param>
        /// <param name="idist">The distance of the input data.</param>
        /// <param name="out">The output array.</param>
        /// <param name="onembed">The storage dimensions of the output data.</param>
        /// <param name="ostride">The stride of the output data.</param>
        /// <param name="odist">The distance of the output data.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_many_dft_c2r(
            int rank,
            ReadOnlySpan<int> n,
            int batch,
            Span<(double Real, double Imaginary)> @in,
            ReadOnlySpan<int> inembed,
            int istride,
            int idist,
            Span<double> @out,
            ReadOnlySpan<int> onembed,
            int ostride,
            int odist,
            uint flags)
        {
            fixed (int* n_ptr = n)
            fixed ((double Real, double Imaginary)* in_ptr = @in)
            fixed (int* inembed_ptr = inembed)
            fixed (double* out_ptr = @out)
            fixed (int* onembed_ptr = onembed)
            {
                var plan = fftw_plan_many_dft_c2r(
                    rank,
                    n_ptr,
                    batch,
                    (double*)in_ptr,
                    inembed_ptr,
                    istride,
                    idist,
                    out_ptr,
                    onembed_ptr,
                    ostride,
                    odist,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom complex to complex plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="n">The transform dimensions.</param>
        /// <param name="batch">The number of transforms.</param>
        /// <param name="in">The input array.</param>
        /// <param name="inembed">The storage dimensions of the input data.</param>
        /// <param name="istride">The stride of the input data.</param>
        /// <param name="idist">The distance of the input data.</param>
        /// <param name="out">The output array.</param>
        /// <param name="onembed">The storage dimensions of the output data.</param>
        /// <param name="ostride">The stride of the output data.</param>
        /// <param name="odist">The distance of the output data.</param>
        /// <param name="sign">The sign of the exponent in the formula.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_many_dft(
            int rank,
            ReadOnlySpan<int> n,
            int batch,
            Span<Double2> @in,
            ReadOnlySpan<int> inembed,
            int istride,
            int idist,
            Span<Double2> @out,
            ReadOnlySpan<int> onembed,
            int ostride,
            int odist,
            int sign,
            uint flags)
        {
            fixed (int* n_ptr = n)
            fixed (Double2* in_ptr = @in)
            fixed (int* inembed_ptr = inembed)
            fixed (Double2* out_ptr = @out)
            fixed (int* onembed_ptr = onembed)
            {
                var plan = fftw_plan_many_dft(
                    rank,
                    n_ptr,
                    batch,
                    (double*)in_ptr,
                    inembed_ptr,
                    istride,
                    idist,
                    (double*)out_ptr,
                    onembed_ptr,
                    ostride,
                    odist,
                    sign,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom real to complex plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="n">The transform dimensions.</param>
        /// <param name="batch">The number of transforms.</param>
        /// <param name="in">The input array.</param>
        /// <param name="inembed">The storage dimensions of the input data.</param>
        /// <param name="istride">The stride of the input data.</param>
        /// <param name="idist">The distance of the input data.</param>
        /// <param name="out">The output array.</param>
        /// <param name="onembed">The storage dimensions of the output data.</param>
        /// <param name="ostride">The stride of the output data.</param>
        /// <param name="odist">The distance of the output data.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_many_dft_r2c(
            int rank,
            ReadOnlySpan<int> n,
            int batch,
            Span<double> @in,
            ReadOnlySpan<int> inembed,
            int istride,
            int idist,
            Span<Double2> @out,
            ReadOnlySpan<int> onembed,
            int ostride,
            int odist,
            uint flags)
        {
            fixed (int* n_ptr = n)
            fixed (double* in_ptr = @in)
            fixed (int* inembed_ptr = inembed)
            fixed (Double2* out_ptr = @out)
            fixed (int* onembed_ptr = onembed)
            {
                var plan = fftw_plan_many_dft_r2c(
                    rank,
                    n_ptr,
                    batch,
                    in_ptr,
                    inembed_ptr,
                    istride,
                    idist,
                    (double*)out_ptr,
                    onembed_ptr,
                    ostride,
                    odist,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom complex to real plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="n">The transform dimensions.</param>
        /// <param name="batch">The number of transforms.</param>
        /// <param name="in">The input array.</param>
        /// <param name="inembed">The storage dimensions of the input data.</param>
        /// <param name="istride">The stride of the input data.</param>
        /// <param name="idist">The distance of the input data.</param>
        /// <param name="out">The output array.</param>
        /// <param name="onembed">The storage dimensions of the output data.</param>
        /// <param name="ostride">The stride of the output data.</param>
        /// <param name="odist">The distance of the output data.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_many_dft_c2r(
            int rank,
            ReadOnlySpan<int> n,
            int batch,
            Span<Double2> @in,
            ReadOnlySpan<int> inembed,
            int istride,
            int idist,
            Span<double> @out,
            ReadOnlySpan<int> onembed,
            int ostride,
            int odist,
            uint flags)
        {
            fixed (int* n_ptr = n)
            fixed (Double2* in_ptr = @in)
            fixed (int* inembed_ptr = inembed)
            fixed (double* out_ptr = @out)
            fixed (int* onembed_ptr = onembed)
            {
                var plan = fftw_plan_many_dft_c2r(
                    rank,
                    n_ptr,
                    batch,
                    (double*)in_ptr,
                    inembed_ptr,
                    istride,
                    idist,
                    out_ptr,
                    onembed_ptr,
                    ostride,
                    odist,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom complex to complex plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="n">The transform dimensions.</param>
        /// <param name="batch">The number of transforms.</param>
        /// <param name="in">The input array.</param>
        /// <param name="inembed">The storage dimensions of the input data.</param>
        /// <param name="istride">The stride of the input data.</param>
        /// <param name="idist">The distance of the input data.</param>
        /// <param name="out">The output array.</param>
        /// <param name="onembed">The storage dimensions of the output data.</param>
        /// <param name="ostride">The stride of the output data.</param>
        /// <param name="odist">The distance of the output data.</param>
        /// <param name="sign">The sign of the exponent in the formula.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftwf_plan_many_dft(
            int rank,
            ReadOnlySpan<int> n,
            int batch,
            Span<(float Real, float Imaginary)> @in,
            ReadOnlySpan<int> inembed,
            int istride,
            int idist,
            Span<(float Real, float Imaginary)> @out,
            ReadOnlySpan<int> onembed,
            int ostride,
            int odist,
            int sign,
            uint flags)
        {
            fixed (int* n_ptr = n)
            fixed ((float Real, float Imaginary)* in_ptr = @in)
            fixed (int* inembed_ptr = inembed)
            fixed ((float Real, float Imaginary)* out_ptr = @out)
            fixed (int* onembed_ptr = onembed)
            {
                var plan = fftwf_plan_many_dft(
                    rank,
                    n_ptr,
                    batch,
                    (float*)in_ptr,
                    inembed_ptr,
                    istride,
                    idist,
                    (float*)out_ptr,
                    onembed_ptr,
                    ostride,
                    odist,
                    sign,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom real to complex plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="n">The transform dimensions.</param>
        /// <param name="batch">The number of transforms.</param>
        /// <param name="in">The input array.</param>
        /// <param name="inembed">The storage dimensions of the input data.</param>
        /// <param name="istride">The stride of the input data.</param>
        /// <param name="idist">The distance of the input data.</param>
        /// <param name="out">The output array.</param>
        /// <param name="onembed">The storage dimensions of the output data.</param>
        /// <param name="ostride">The stride of the output data.</param>
        /// <param name="odist">The distance of the output data.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftwf_plan_many_dft_r2c(
            int rank,
            ReadOnlySpan<int> n,
            int batch,
            Span<float> @in,
            ReadOnlySpan<int> inembed,
            int istride,
            int idist,
            Span<(float Real, float Imaginary)> @out,
            ReadOnlySpan<int> onembed,
            int ostride,
            int odist,
            uint flags)
        {
            fixed (int* n_ptr = n)
            fixed (float* in_ptr = @in)
            fixed (int* inembed_ptr = inembed)
            fixed ((float Real, float Imaginary)* out_ptr = @out)
            fixed (int* onembed_ptr = onembed)
            {
                var plan = fftwf_plan_many_dft_r2c(
                    rank,
                    n_ptr,
                    batch,
                    in_ptr,
                    inembed_ptr,
                    istride,
                    idist,
                    (float*)out_ptr,
                    onembed_ptr,
                    ostride,
                    odist,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom complex to real plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="n">The transform dimensions.</param>
        /// <param name="batch">The number of transforms.</param>
        /// <param name="in">The input array.</param>
        /// <param name="inembed">The storage dimensions of the input data.</param>
        /// <param name="istride">The stride of the input data.</param>
        /// <param name="idist">The distance of the input data.</param>
        /// <param name="out">The output array.</param>
        /// <param name="onembed">The storage dimensions of the output data.</param>
        /// <param name="ostride">The stride of the output data.</param>
        /// <param name="odist">The distance of the output data.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftwf_plan_many_dft_c2r(
            int rank,
            ReadOnlySpan<int> n,
            int batch,
            Span<(float Real, float Imaginary)> @in,
            ReadOnlySpan<int> inembed,
            int istride,
            int idist,
            Span<float> @out,
            ReadOnlySpan<int> onembed,
            int ostride,
            int odist,
            uint flags)
        {
            fixed (int* n_ptr = n)
            fixed ((float Real, float Imaginary)* in_ptr = @in)
            fixed (int* inembed_ptr = inembed)
            fixed (float* out_ptr = @out)
            fixed (int* onembed_ptr = onembed)
            {
                var plan = fftwf_plan_many_dft_c2r(
                    rank,
                    n_ptr,
                    batch,
                    (float*)in_ptr,
                    inembed_ptr,
                    istride,
                    idist,
                    out_ptr,
                    onembed_ptr,
                    ostride,
                    odist,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom complex to complex plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="n">The transform dimensions.</param>
        /// <param name="batch">The number of transforms.</param>
        /// <param name="in">The input array.</param>
        /// <param name="inembed">The storage dimensions of the input data.</param>
        /// <param name="istride">The stride of the input data.</param>
        /// <param name="idist">The distance of the input data.</param>
        /// <param name="out">The output array.</param>
        /// <param name="onembed">The storage dimensions of the output data.</param>
        /// <param name="ostride">The stride of the output data.</param>
        /// <param name="odist">The distance of the output data.</param>
        /// <param name="sign">The sign of the exponent in the formula.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftwf_plan_many_dft(
            int rank,
            ReadOnlySpan<int> n,
            int batch,
            Span<Float2> @in,
            ReadOnlySpan<int> inembed,
            int istride,
            int idist,
            Span<Float2> @out,
            ReadOnlySpan<int> onembed,
            int ostride,
            int odist,
            int sign,
            uint flags)
        {
            fixed (int* n_ptr = n)
            fixed (Float2* in_ptr = @in)
            fixed (int* inembed_ptr = inembed)
            fixed (Float2* out_ptr = @out)
            fixed (int* onembed_ptr = onembed)
            {
                var plan = fftwf_plan_many_dft(
                    rank,
                    n_ptr,
                    batch,
                    (float*)in_ptr,
                    inembed_ptr,
                    istride,
                    idist,
                    (float*)out_ptr,
                    onembed_ptr,
                    ostride,
                    odist,
                    sign,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom real to complex plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="n">The transform dimensions.</param>
        /// <param name="batch">The number of transforms.</param>
        /// <param name="in">The input array.</param>
        /// <param name="inembed">The storage dimensions of the input data.</param>
        /// <param name="istride">The stride of the input data.</param>
        /// <param name="idist">The distance of the input data.</param>
        /// <param name="out">The output array.</param>
        /// <param name="onembed">The storage dimensions of the output data.</param>
        /// <param name="ostride">The stride of the output data.</param>
        /// <param name="odist">The distance of the output data.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftwf_plan_many_dft_r2c(
            int rank,
            ReadOnlySpan<int> n,
            int batch,
            Span<float> @in,
            ReadOnlySpan<int> inembed,
            int istride,
            int idist,
            Span<Float2> @out,
            ReadOnlySpan<int> onembed,
            int ostride,
            int odist,
            uint flags)
        {
            fixed (int* n_ptr = n)
            fixed (float* in_ptr = @in)
            fixed (int* inembed_ptr = inembed)
            fixed (Float2* out_ptr = @out)
            fixed (int* onembed_ptr = onembed)
            {
                var plan = fftwf_plan_many_dft_r2c(
                    rank,
                    n_ptr,
                    batch,
                    in_ptr,
                    inembed_ptr,
                    istride,
                    idist,
                    (float*)out_ptr,
                    onembed_ptr,
                    ostride,
                    odist,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom complex to real plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="n">The transform dimensions.</param>
        /// <param name="batch">The number of transforms.</param>
        /// <param name="in">The input array.</param>
        /// <param name="inembed">The storage dimensions of the input data.</param>
        /// <param name="istride">The stride of the input data.</param>
        /// <param name="idist">The distance of the input data.</param>
        /// <param name="out">The output array.</param>
        /// <param name="onembed">The storage dimensions of the output data.</param>
        /// <param name="ostride">The stride of the output data.</param>
        /// <param name="odist">The distance of the output data.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftwf_plan_many_dft_c2r(
            int rank,
            ReadOnlySpan<int> n,
            int batch,
            Span<Float2> @in,
            ReadOnlySpan<int> inembed,
            int istride,
            int idist,
            Span<float> @out,
            ReadOnlySpan<int> onembed,
            int ostride,
            int odist,
            uint flags)
        {
            fixed (int* n_ptr = n)
            fixed (Float2* in_ptr = @in)
            fixed (int* inembed_ptr = inembed)
            fixed (float* out_ptr = @out)
            fixed (int* onembed_ptr = onembed)
            {
                var plan = fftwf_plan_many_dft_c2r(
                    rank,
                    n_ptr,
                    batch,
                    (float*)in_ptr,
                    inembed_ptr,
                    istride,
                    idist,
                    out_ptr,
                    onembed_ptr,
                    ostride,
                    odist,
                    flags);
                return plan;
            }
        }

        #endregion

        #region Guru Interface

        /// <summary>
        /// Creates a custom complex to complex plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="dims">The transform dimensions.</param>
        /// <param name="batch_rank">The batch rank.</param>
        /// <param name="batch_dims">The batch dimensions.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="sign">The sign of the exponent in the formula.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_guru_dft(
            int rank,
            ReadOnlySpan<iodim> dims,
            int batch_rank,
            ReadOnlySpan<iodim> batch_dims,
            Span<Complex> @in,
            Span<Complex> @out,
            int sign,
            uint flags)
        {
            fixed (iodim* dims_ptr = dims)
            fixed (Complex* in_ptr = @in)
            fixed (iodim* batch_dims_ptr = batch_dims)
            fixed (Complex* out_ptr = @out)
            {
                var plan = fftw_plan_guru_dft(
                    rank,
                    dims_ptr,
                    batch_rank,
                    batch_dims_ptr,
                    (double*)in_ptr,
                    (double*)out_ptr,
                    sign,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom real to complex plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="dims">The transform dimensions.</param>
        /// <param name="batch_rank">The batch rank.</param>
        /// <param name="batch_dims">The batch dimensions.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_guru_dft_r2c(
            int rank,
            ReadOnlySpan<iodim> dims,
            int batch_rank,
            ReadOnlySpan<iodim> batch_dims,
            Span<double> @in,
            Span<Complex> @out,
            uint flags)
        {
            fixed (iodim* dims_ptr = dims)
            fixed (double* in_ptr = @in)
            fixed (iodim* batch_dims_ptr = batch_dims)
            fixed (Complex* out_ptr = @out)
            {
                var plan = fftw_plan_guru_dft_r2c(
                    rank,
                    dims_ptr,
                    batch_rank,
                    batch_dims_ptr,
                    in_ptr,
                    (double*)out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom complex to real plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="dims">The transform dimensions.</param>
        /// <param name="batch_rank">The batch rank.</param>
        /// <param name="batch_dims">The batch dimensions.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_guru_dft_c2r(
            int rank,
            ReadOnlySpan<iodim> dims,
            int batch_rank,
            ReadOnlySpan<iodim> batch_dims,
            Span<Complex> @in,
            Span<double> @out,
            uint flags)
        {
            fixed (iodim* dims_ptr = dims)
            fixed (Complex* in_ptr = @in)
            fixed (iodim* batch_dims_ptr = batch_dims)
            fixed (double* out_ptr = @out)
            {
                var plan = fftw_plan_guru_dft_c2r(
                    rank,
                    dims_ptr,
                    batch_rank,
                    batch_dims_ptr,
                    (double*)in_ptr,
                    out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom complex to complex plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="dims">The transform dimensions.</param>
        /// <param name="batch_rank">The batch rank.</param>
        /// <param name="batch_dims">The batch dimensions.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="sign">The sign of the exponent in the formula.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_guru_dft(
            int rank,
            ReadOnlySpan<iodim> dims,
            int batch_rank,
            ReadOnlySpan<iodim> batch_dims,
            Span<(double Real, double Imaginary)> @in,
            Span<(double Real, double Imaginary)> @out,
            int sign,
            uint flags)
        {
            fixed (iodim* dims_ptr = dims)
            fixed ((double Real, double Imaginary)* in_ptr = @in)
            fixed (iodim* batch_dims_ptr = batch_dims)
            fixed ((double Real, double Imaginary)* out_ptr = @out)
            {
                var plan = fftw_plan_guru_dft(
                    rank,
                    dims_ptr,
                    batch_rank,
                    batch_dims_ptr,
                    (double*)in_ptr,
                    (double*)out_ptr,
                    sign,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom real to complex plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="dims">The transform dimensions.</param>
        /// <param name="batch_rank">The batch rank.</param>
        /// <param name="batch_dims">The batch dimensions.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_guru_dft_r2c(
            int rank,
            ReadOnlySpan<iodim> dims,
            int batch_rank,
            ReadOnlySpan<iodim> batch_dims,
            Span<double> @in,
            Span<(double Real, double Imaginary)> @out,
            uint flags)
        {
            fixed (iodim* dims_ptr = dims)
            fixed (double* in_ptr = @in)
            fixed (iodim* batch_dims_ptr = batch_dims)
            fixed ((double Real, double Imaginary)* out_ptr = @out)
            {
                var plan = fftw_plan_guru_dft_r2c(
                    rank,
                    dims_ptr,
                    batch_rank,
                    batch_dims_ptr,
                    in_ptr,
                    (double*)out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom complex to real plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="dims">The transform dimensions.</param>
        /// <param name="batch_rank">The batch rank.</param>
        /// <param name="batch_dims">The batch dimensions.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_guru_dft_c2r(
            int rank,
            ReadOnlySpan<iodim> dims,
            int batch_rank,
            ReadOnlySpan<iodim> batch_dims,
            Span<(double Real, double Imaginary)> @in,
            Span<double> @out,
            uint flags)
        {
            fixed (iodim* dims_ptr = dims)
            fixed ((double Real, double Imaginary)* in_ptr = @in)
            fixed (iodim* batch_dims_ptr = batch_dims)
            fixed (double* out_ptr = @out)
            {
                var plan = fftw_plan_guru_dft_c2r(
                    rank,
                    dims_ptr,
                    batch_rank,
                    batch_dims_ptr,
                    (double*)in_ptr,
                    out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom complex to complex plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="dims">The transform dimensions.</param>
        /// <param name="batch_rank">The batch rank.</param>
        /// <param name="batch_dims">The batch dimensions.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="sign">The sign of the exponent in the formula.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_guru_dft(
            int rank,
            ReadOnlySpan<iodim> dims,
            int batch_rank,
            ReadOnlySpan<iodim> batch_dims,
            Span<Double2> @in,
            Span<Double2> @out,
            int sign,
            uint flags)
        {
            fixed (iodim* dims_ptr = dims)
            fixed (Double2* in_ptr = @in)
            fixed (iodim* batch_dims_ptr = batch_dims)
            fixed (Double2* out_ptr = @out)
            {
                var plan = fftw_plan_guru_dft(
                    rank,
                    dims_ptr,
                    batch_rank,
                    batch_dims_ptr,
                    (double*)in_ptr,
                    (double*)out_ptr,
                    sign,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom real to complex plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="dims">The transform dimensions.</param>
        /// <param name="batch_rank">The batch rank.</param>
        /// <param name="batch_dims">The batch dimensions.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_guru_dft_r2c(
            int rank,
            ReadOnlySpan<iodim> dims,
            int batch_rank,
            ReadOnlySpan<iodim> batch_dims,
            Span<double> @in,
            Span<Double2> @out,
            uint flags)
        {
            fixed (iodim* dims_ptr = dims)
            fixed (double* in_ptr = @in)
            fixed (iodim* batch_dims_ptr = batch_dims)
            fixed (Double2* out_ptr = @out)
            {
                var plan = fftw_plan_guru_dft_r2c(
                    rank,
                    dims_ptr,
                    batch_rank,
                    batch_dims_ptr,
                    in_ptr,
                    (double*)out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom complex to real plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="dims">The transform dimensions.</param>
        /// <param name="batch_rank">The batch rank.</param>
        /// <param name="batch_dims">The batch dimensions.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_guru_dft_c2r(
            int rank,
            ReadOnlySpan<iodim> dims,
            int batch_rank,
            ReadOnlySpan<iodim> batch_dims,
            Span<Double2> @in,
            Span<double> @out,
            uint flags)
        {
            fixed (iodim* dims_ptr = dims)
            fixed (Double2* in_ptr = @in)
            fixed (iodim* batch_dims_ptr = batch_dims)
            fixed (double* out_ptr = @out)
            {
                var plan = fftw_plan_guru_dft_c2r(
                    rank,
                    dims_ptr,
                    batch_rank,
                    batch_dims_ptr,
                    (double*)in_ptr,
                    out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom complex to complex plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="dims">The transform dimensions.</param>
        /// <param name="batch_rank">The batch rank.</param>
        /// <param name="batch_dims">The batch dimensions.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="sign">The sign of the exponent in the formula.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftwf_plan_guru_dft(
            int rank,
            ReadOnlySpan<iodim> dims,
            int batch_rank,
            ReadOnlySpan<iodim> batch_dims,
            Span<(float Real, float Imaginary)> @in,
            Span<(float Real, float Imaginary)> @out,
            int sign,
            uint flags)
        {
            fixed (iodim* dims_ptr = dims)
            fixed ((float Real, float Imaginary)* in_ptr = @in)
            fixed (iodim* batch_dims_ptr = batch_dims)
            fixed ((float Real, float Imaginary)* out_ptr = @out)
            {
                var plan = fftwf_plan_guru_dft(
                    rank,
                    dims_ptr,
                    batch_rank,
                    batch_dims_ptr,
                    (float*)in_ptr,
                    (float*)out_ptr,
                    sign,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom real to complex plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="dims">The transform dimensions.</param>
        /// <param name="batch_rank">The batch rank.</param>
        /// <param name="batch_dims">The batch dimensions.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftwf_plan_guru_dft_r2c(
            int rank,
            ReadOnlySpan<iodim> dims,
            int batch_rank,
            ReadOnlySpan<iodim> batch_dims,
            Span<float> @in,
            Span<(float Real, float Imaginary)> @out,
            uint flags)
        {
            fixed (iodim* dims_ptr = dims)
            fixed (float* in_ptr = @in)
            fixed (iodim* batch_dims_ptr = batch_dims)
            fixed ((float Real, float Imaginary)* out_ptr = @out)
            {
                var plan = fftwf_plan_guru_dft_r2c(
                    rank,
                    dims_ptr,
                    batch_rank,
                    batch_dims_ptr,
                    in_ptr,
                    (float*)out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom complex to real plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="dims">The transform dimensions.</param>
        /// <param name="batch_rank">The batch rank.</param>
        /// <param name="batch_dims">The batch dimensions.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftwf_plan_guru_dft_c2r(
            int rank,
            ReadOnlySpan<iodim> dims,
            int batch_rank,
            ReadOnlySpan<iodim> batch_dims,
            Span<(float Real, float Imaginary)> @in,
            Span<float> @out,
            uint flags)
        {
            fixed (iodim* dims_ptr = dims)
            fixed ((float Real, float Imaginary)* in_ptr = @in)
            fixed (iodim* batch_dims_ptr = batch_dims)
            fixed (float* out_ptr = @out)
            {
                var plan = fftwf_plan_guru_dft_c2r(
                    rank,
                    dims_ptr,
                    batch_rank,
                    batch_dims_ptr,
                    (float*)in_ptr,
                    out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom complex to complex plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="dims">The transform dimensions.</param>
        /// <param name="batch_rank">The batch rank.</param>
        /// <param name="batch_dims">The batch dimensions.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="sign">The sign of the exponent in the formula.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftwf_plan_guru_dft(
            int rank,
            ReadOnlySpan<iodim> dims,
            int batch_rank,
            ReadOnlySpan<iodim> batch_dims,
            Span<Float2> @in,
            Span<Float2> @out,
            int sign,
            uint flags)
        {
            fixed (iodim* dims_ptr = dims)
            fixed (Float2* in_ptr = @in)
            fixed (iodim* batch_dims_ptr = batch_dims)
            fixed (Float2* out_ptr = @out)
            {
                var plan = fftwf_plan_guru_dft(
                    rank,
                    dims_ptr,
                    batch_rank,
                    batch_dims_ptr,
                    (float*)in_ptr,
                    (float*)out_ptr,
                    sign,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom real to complex plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="dims">The transform dimensions.</param>
        /// <param name="batch_rank">The batch rank.</param>
        /// <param name="batch_dims">The batch dimensions.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftwf_plan_guru_dft_r2c(
            int rank,
            ReadOnlySpan<iodim> dims,
            int batch_rank,
            ReadOnlySpan<iodim> batch_dims,
            Span<float> @in,
            Span<Float2> @out,
            uint flags)
        {
            fixed (iodim* dims_ptr = dims)
            fixed (float* in_ptr = @in)
            fixed (iodim* batch_dims_ptr = batch_dims)
            fixed (Float2* out_ptr = @out)
            {
                var plan = fftwf_plan_guru_dft_r2c(
                    rank,
                    dims_ptr,
                    batch_rank,
                    batch_dims_ptr,
                    in_ptr,
                    (float*)out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom complex to real plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="dims">The transform dimensions.</param>
        /// <param name="batch_rank">The batch rank.</param>
        /// <param name="batch_dims">The batch dimensions.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftwf_plan_guru_dft_c2r(
            int rank,
            ReadOnlySpan<iodim> dims,
            int batch_rank,
            ReadOnlySpan<iodim> batch_dims,
            Span<Float2> @in,
            Span<float> @out,
            uint flags)
        {
            fixed (iodim* dims_ptr = dims)
            fixed (Float2* in_ptr = @in)
            fixed (iodim* batch_dims_ptr = batch_dims)
            fixed (float* out_ptr = @out)
            {
                var plan = fftwf_plan_guru_dft_c2r(
                    rank,
                    dims_ptr,
                    batch_rank,
                    batch_dims_ptr,
                    (float*)in_ptr,
                    out_ptr,
                    flags);
                return plan;
            }
        }

        #endregion

        #region Guru 64-bit Interface

        /// <summary>
        /// Creates a custom complex to complex plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="dims">The transform dimensions.</param>
        /// <param name="batch_rank">The batch rank.</param>
        /// <param name="batch_dims">The batch dimensions.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="sign">The sign of the exponent in the formula.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_guru64_dft(
            int rank,
            ReadOnlySpan<iodim64> dims,
            int batch_rank,
            ReadOnlySpan<iodim64> batch_dims,
            Span<Complex> @in,
            Span<Complex> @out,
            int sign,
            uint flags)
        {
            fixed (iodim64* dims_ptr = dims)
            fixed (Complex* in_ptr = @in)
            fixed (iodim64* batch_dims_ptr = batch_dims)
            fixed (Complex* out_ptr = @out)
            {
                var plan = fftw_plan_guru64_dft(
                    rank,
                    dims_ptr,
                    batch_rank,
                    batch_dims_ptr,
                    (double*)in_ptr,
                    (double*)out_ptr,
                    sign,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom real to complex plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="dims">The transform dimensions.</param>
        /// <param name="batch_rank">The batch rank.</param>
        /// <param name="batch_dims">The batch dimensions.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_guru64_dft_r2c(
            int rank,
            ReadOnlySpan<iodim64> dims,
            int batch_rank,
            ReadOnlySpan<iodim64> batch_dims,
            Span<double> @in,
            Span<Complex> @out,
            uint flags)
        {
            fixed (iodim64* dims_ptr = dims)
            fixed (double* in_ptr = @in)
            fixed (iodim64* batch_dims_ptr = batch_dims)
            fixed (Complex* out_ptr = @out)
            {
                var plan = fftw_plan_guru64_dft_r2c(
                    rank,
                    dims_ptr,
                    batch_rank,
                    batch_dims_ptr,
                    in_ptr,
                    (double*)out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom complex to real plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="dims">The transform dimensions.</param>
        /// <param name="batch_rank">The batch rank.</param>
        /// <param name="batch_dims">The batch dimensions.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_guru64_dft_c2r(
            int rank,
            ReadOnlySpan<iodim64> dims,
            int batch_rank,
            ReadOnlySpan<iodim64> batch_dims,
            Span<Complex> @in,
            Span<double> @out,
            uint flags)
        {
            fixed (iodim64* dims_ptr = dims)
            fixed (Complex* in_ptr = @in)
            fixed (iodim64* batch_dims_ptr = batch_dims)
            fixed (double* out_ptr = @out)
            {
                var plan = fftw_plan_guru64_dft_c2r(
                    rank,
                    dims_ptr,
                    batch_rank,
                    batch_dims_ptr,
                    (double*)in_ptr,
                    out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom complex to complex plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="dims">The transform dimensions.</param>
        /// <param name="batch_rank">The batch rank.</param>
        /// <param name="batch_dims">The batch dimensions.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="sign">The sign of the exponent in the formula.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_guru64_dft(
            int rank,
            ReadOnlySpan<iodim64> dims,
            int batch_rank,
            ReadOnlySpan<iodim64> batch_dims,
            Span<(double Real, double Imaginary)> @in,
            Span<(double Real, double Imaginary)> @out,
            int sign,
            uint flags)
        {
            fixed (iodim64* dims_ptr = dims)
            fixed ((double Real, double Imaginary)* in_ptr = @in)
            fixed (iodim64* batch_dims_ptr = batch_dims)
            fixed ((double Real, double Imaginary)* out_ptr = @out)
            {
                var plan = fftw_plan_guru64_dft(
                    rank,
                    dims_ptr,
                    batch_rank,
                    batch_dims_ptr,
                    (double*)in_ptr,
                    (double*)out_ptr,
                    sign,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom real to complex plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="dims">The transform dimensions.</param>
        /// <param name="batch_rank">The batch rank.</param>
        /// <param name="batch_dims">The batch dimensions.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_guru64_dft_r2c(
            int rank,
            ReadOnlySpan<iodim64> dims,
            int batch_rank,
            ReadOnlySpan<iodim64> batch_dims,
            Span<double> @in,
            Span<(double Real, double Imaginary)> @out,
            uint flags)
        {
            fixed (iodim64* dims_ptr = dims)
            fixed (double* in_ptr = @in)
            fixed (iodim64* batch_dims_ptr = batch_dims)
            fixed ((double Real, double Imaginary)* out_ptr = @out)
            {
                var plan = fftw_plan_guru64_dft_r2c(
                    rank,
                    dims_ptr,
                    batch_rank,
                    batch_dims_ptr,
                    in_ptr,
                    (double*)out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom complex to real plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="dims">The transform dimensions.</param>
        /// <param name="batch_rank">The batch rank.</param>
        /// <param name="batch_dims">The batch dimensions.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_guru64_dft_c2r(
            int rank,
            ReadOnlySpan<iodim64> dims,
            int batch_rank,
            ReadOnlySpan<iodim64> batch_dims,
            Span<(double Real, double Imaginary)> @in,
            Span<double> @out,
            uint flags)
        {
            fixed (iodim64* dims_ptr = dims)
            fixed ((double Real, double Imaginary)* in_ptr = @in)
            fixed (iodim64* batch_dims_ptr = batch_dims)
            fixed (double* out_ptr = @out)
            {
                var plan = fftw_plan_guru64_dft_c2r(
                    rank,
                    dims_ptr,
                    batch_rank,
                    batch_dims_ptr,
                    (double*)in_ptr,
                    out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom complex to complex plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="dims">The transform dimensions.</param>
        /// <param name="batch_rank">The batch rank.</param>
        /// <param name="batch_dims">The batch dimensions.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="sign">The sign of the exponent in the formula.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_guru64_dft(
            int rank,
            ReadOnlySpan<iodim64> dims,
            int batch_rank,
            ReadOnlySpan<iodim64> batch_dims,
            Span<Double2> @in,
            Span<Double2> @out,
            int sign,
            uint flags)
        {
            fixed (iodim64* dims_ptr = dims)
            fixed (Double2* in_ptr = @in)
            fixed (iodim64* batch_dims_ptr = batch_dims)
            fixed (Double2* out_ptr = @out)
            {
                var plan = fftw_plan_guru64_dft(
                    rank,
                    dims_ptr,
                    batch_rank,
                    batch_dims_ptr,
                    (double*)in_ptr,
                    (double*)out_ptr,
                    sign,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom real to complex plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="dims">The transform dimensions.</param>
        /// <param name="batch_rank">The batch rank.</param>
        /// <param name="batch_dims">The batch dimensions.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_guru64_dft_r2c(
            int rank,
            ReadOnlySpan<iodim64> dims,
            int batch_rank,
            ReadOnlySpan<iodim64> batch_dims,
            Span<double> @in,
            Span<Double2> @out,
            uint flags)
        {
            fixed (iodim64* dims_ptr = dims)
            fixed (double* in_ptr = @in)
            fixed (iodim64* batch_dims_ptr = batch_dims)
            fixed (Double2* out_ptr = @out)
            {
                var plan = fftw_plan_guru64_dft_r2c(
                    rank,
                    dims_ptr,
                    batch_rank,
                    batch_dims_ptr,
                    in_ptr,
                    (double*)out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom complex to real plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="dims">The transform dimensions.</param>
        /// <param name="batch_rank">The batch rank.</param>
        /// <param name="batch_dims">The batch dimensions.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftw_plan_guru64_dft_c2r(
            int rank,
            ReadOnlySpan<iodim64> dims,
            int batch_rank,
            ReadOnlySpan<iodim64> batch_dims,
            Span<Double2> @in,
            Span<double> @out,
            uint flags)
        {
            fixed (iodim64* dims_ptr = dims)
            fixed (Double2* in_ptr = @in)
            fixed (iodim64* batch_dims_ptr = batch_dims)
            fixed (double* out_ptr = @out)
            {
                var plan = fftw_plan_guru64_dft_c2r(
                    rank,
                    dims_ptr,
                    batch_rank,
                    batch_dims_ptr,
                    (double*)in_ptr,
                    out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom complex to complex plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="dims">The transform dimensions.</param>
        /// <param name="batch_rank">The batch rank.</param>
        /// <param name="batch_dims">The batch dimensions.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="sign">The sign of the exponent in the formula.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftwf_plan_guru64_dft(
            int rank,
            ReadOnlySpan<iodim64> dims,
            int batch_rank,
            ReadOnlySpan<iodim64> batch_dims,
            Span<(float Real, float Imaginary)> @in,
            Span<(float Real, float Imaginary)> @out,
            int sign,
            uint flags)
        {
            fixed (iodim64* dims_ptr = dims)
            fixed ((float Real, float Imaginary)* in_ptr = @in)
            fixed (iodim64* batch_dims_ptr = batch_dims)
            fixed ((float Real, float Imaginary)* out_ptr = @out)
            {
                var plan = fftwf_plan_guru64_dft(
                    rank,
                    dims_ptr,
                    batch_rank,
                    batch_dims_ptr,
                    (float*)in_ptr,
                    (float*)out_ptr,
                    sign,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom real to complex plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="dims">The transform dimensions.</param>
        /// <param name="batch_rank">The batch rank.</param>
        /// <param name="batch_dims">The batch dimensions.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftwf_plan_guru64_dft_r2c(
            int rank,
            ReadOnlySpan<iodim64> dims,
            int batch_rank,
            ReadOnlySpan<iodim64> batch_dims,
            Span<float> @in,
            Span<(float Real, float Imaginary)> @out,
            uint flags)
        {
            fixed (iodim64* dims_ptr = dims)
            fixed (float* in_ptr = @in)
            fixed (iodim64* batch_dims_ptr = batch_dims)
            fixed ((float Real, float Imaginary)* out_ptr = @out)
            {
                var plan = fftwf_plan_guru64_dft_r2c(
                    rank,
                    dims_ptr,
                    batch_rank,
                    batch_dims_ptr,
                    in_ptr,
                    (float*)out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom complex to real plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="dims">The transform dimensions.</param>
        /// <param name="batch_rank">The batch rank.</param>
        /// <param name="batch_dims">The batch dimensions.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftwf_plan_guru64_dft_c2r(
            int rank,
            ReadOnlySpan<iodim64> dims,
            int batch_rank,
            ReadOnlySpan<iodim64> batch_dims,
            Span<(float Real, float Imaginary)> @in,
            Span<float> @out,
            uint flags)
        {
            fixed (iodim64* dims_ptr = dims)
            fixed ((float Real, float Imaginary)* in_ptr = @in)
            fixed (iodim64* batch_dims_ptr = batch_dims)
            fixed (float* out_ptr = @out)
            {
                var plan = fftwf_plan_guru64_dft_c2r(
                    rank,
                    dims_ptr,
                    batch_rank,
                    batch_dims_ptr,
                    (float*)in_ptr,
                    out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom complex to complex plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="dims">The transform dimensions.</param>
        /// <param name="batch_rank">The batch rank.</param>
        /// <param name="batch_dims">The batch dimensions.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="sign">The sign of the exponent in the formula.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftwf_plan_guru64_dft(
            int rank,
            ReadOnlySpan<iodim64> dims,
            int batch_rank,
            ReadOnlySpan<iodim64> batch_dims,
            Span<Float2> @in,
            Span<Float2> @out,
            int sign,
            uint flags)
        {
            fixed (iodim64* dims_ptr = dims)
            fixed (Float2* in_ptr = @in)
            fixed (iodim64* batch_dims_ptr = batch_dims)
            fixed (Float2* out_ptr = @out)
            {
                var plan = fftwf_plan_guru64_dft(
                    rank,
                    dims_ptr,
                    batch_rank,
                    batch_dims_ptr,
                    (float*)in_ptr,
                    (float*)out_ptr,
                    sign,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom real to complex plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="dims">The transform dimensions.</param>
        /// <param name="batch_rank">The batch rank.</param>
        /// <param name="batch_dims">The batch dimensions.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftwf_plan_guru64_dft_r2c(
            int rank,
            ReadOnlySpan<iodim64> dims,
            int batch_rank,
            ReadOnlySpan<iodim64> batch_dims,
            Span<float> @in,
            Span<Float2> @out,
            uint flags)
        {
            fixed (iodim64* dims_ptr = dims)
            fixed (float* in_ptr = @in)
            fixed (iodim64* batch_dims_ptr = batch_dims)
            fixed (Float2* out_ptr = @out)
            {
                var plan = fftwf_plan_guru64_dft_r2c(
                    rank,
                    dims_ptr,
                    batch_rank,
                    batch_dims_ptr,
                    in_ptr,
                    (float*)out_ptr,
                    flags);
                return plan;
            }
        }

        /// <summary>
        /// Creates a custom complex to real plan.
        /// </summary>
        /// <param name="rank">The transform rank.</param>
        /// <param name="dims">The transform dimensions.</param>
        /// <param name="batch_rank">The batch rank.</param>
        /// <param name="batch_dims">The batch dimensions.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public unsafe IntPtr fftwf_plan_guru64_dft_c2r(
            int rank,
            ReadOnlySpan<iodim64> dims,
            int batch_rank,
            ReadOnlySpan<iodim64> batch_dims,
            Span<Float2> @in,
            Span<float> @out,
            uint flags)
        {
            fixed (iodim64* dims_ptr = dims)
            fixed (Float2* in_ptr = @in)
            fixed (iodim64* batch_dims_ptr = batch_dims)
            fixed (float* out_ptr = @out)
            {
                var plan = fftwf_plan_guru64_dft_c2r(
                    rank,
                    dims_ptr,
                    batch_rank,
                    batch_dims_ptr,
                    (float*)in_ptr,
                    out_ptr,
                    flags);
                return plan;
            }
        }

        #endregion

        #region Plan Execution

        /// <summary>
        /// Executes the plan on different arrays (complex to complex).
        /// </summary>
        /// <param name="plan">The plan handle.</param>
        /// <param name="idata">The input array.</param>
        /// <param name="odata">The output array.</param>
        public unsafe void fftw_execute_dft(
            IntPtr plan,
            Span<Complex> idata,
            Span<Complex> odata)
        {
            fixed (Complex* idataPtr = idata)
            fixed (Complex* odataPtr = odata)
            {
                fftw_execute_dft(
                    plan,
                    (double*)idataPtr,
                    (double*)odataPtr);
            }
        }

        /// <summary>
        /// Executes the plan on different arrays (real to complex).
        /// </summary>
        /// <param name="plan">The plan handle.</param>
        /// <param name="idata">The input array.</param>
        /// <param name="odata">The output array.</param>
        public unsafe void fftw_execute_dft_r2c(
            IntPtr plan,
            Span<double> idata,
            Span<Complex> odata)
        {
            fixed (double* idataPtr = idata)
            fixed (Complex* odataPtr = odata)
            {
                fftw_execute_dft_r2c(
                    plan,
                    idataPtr,
                    (double*)odataPtr);
            }
        }

        /// <summary>
        /// Executes the plan on different arrays (complex to real).
        /// </summary>
        /// <param name="plan">The plan handle.</param>
        /// <param name="idata">The input array.</param>
        /// <param name="odata">The output array.</param>
        public unsafe void fftw_execute_dft_c2r(
            IntPtr plan,
            Span<Complex> idata,
            Span<double> odata)
        {
            fixed (Complex* idataPtr = idata)
            fixed (double* odataPtr = odata)
            {
                fftw_execute_dft_c2r(
                    plan,
                    (double*)idataPtr,
                    odataPtr);
            }
        }

        /// <summary>
        /// Executes the plan on different arrays (complex to complex).
        /// </summary>
        /// <param name="plan">The plan handle.</param>
        /// <param name="idata">The input array.</param>
        /// <param name="odata">The output array.</param>
        public unsafe void fftw_execute_dft(
            IntPtr plan,
            Span<(double Real, double Imaginary)> idata,
            Span<(double Real, double Imaginary)> odata)
        {
            fixed ((double Real, double Imaginary)* idataPtr = idata)
            fixed ((double Real, double Imaginary)* odataPtr = odata)
            {
                fftw_execute_dft(
                    plan,
                    (double*)idataPtr,
                    (double*)odataPtr);
            }
        }

        /// <summary>
        /// Executes the plan on different arrays (real to complex).
        /// </summary>
        /// <param name="plan">The plan handle.</param>
        /// <param name="idata">The input array.</param>
        /// <param name="odata">The output array.</param>
        public unsafe void fftw_execute_dft_r2c(
            IntPtr plan,
            Span<double> idata,
            Span<(double Real, double Imaginary)> odata)
        {
            fixed (double* idataPtr = idata)
            fixed ((double Real, double Imaginary)* odataPtr = odata)
            {
                fftw_execute_dft_r2c(
                    plan,
                    idataPtr,
                    (double*)odataPtr);
            }
        }

        /// <summary>
        /// Executes the plan on different arrays (complex to real).
        /// </summary>
        /// <param name="plan">The plan handle.</param>
        /// <param name="idata">The input array.</param>
        /// <param name="odata">The output array.</param>
        public unsafe void fftw_execute_dft_c2r(
            IntPtr plan,
            Span<(double Real, double Imaginary)> idata,
            Span<double> odata)
        {
            fixed ((double Real, double Imaginary)* idataPtr = idata)
            fixed (double* odataPtr = odata)
            {
                fftw_execute_dft_c2r(
                    plan,
                    (double*)idataPtr,
                    odataPtr);
            }
        }

        /// <summary>
        /// Executes the plan on different arrays (complex to complex).
        /// </summary>
        /// <param name="plan">The plan handle.</param>
        /// <param name="idata">The input array.</param>
        /// <param name="odata">The output array.</param>
        public unsafe void fftw_execute_dft(
            IntPtr plan,
            Span<Double2> idata,
            Span<Double2> odata)
        {
            fixed (Double2* idataPtr = idata)
            fixed (Double2* odataPtr = odata)
            {
                fftw_execute_dft(
                    plan,
                    (double*)idataPtr,
                    (double*)odataPtr);
            }
        }

        /// <summary>
        /// Executes the plan on different arrays (real to complex).
        /// </summary>
        /// <param name="plan">The plan handle.</param>
        /// <param name="idata">The input array.</param>
        /// <param name="odata">The output array.</param>
        public unsafe void fftw_execute_dft_r2c(
            IntPtr plan,
            Span<double> idata,
            Span<Double2> odata)
        {
            fixed (double* idataPtr = idata)
            fixed (Double2* odataPtr = odata)
            {
                fftw_execute_dft_r2c(
                    plan,
                    idataPtr,
                    (double*)odataPtr);
            }
        }

        /// <summary>
        /// Executes the plan on different arrays (complex to real).
        /// </summary>
        /// <param name="plan">The plan handle.</param>
        /// <param name="idata">The input array.</param>
        /// <param name="odata">The output array.</param>
        public unsafe void fftw_execute_dft_c2r(
            IntPtr plan,
            Span<Double2> idata,
            Span<double> odata)
        {
            fixed (Double2* idataPtr = idata)
            fixed (double* odataPtr = odata)
            {
                fftw_execute_dft_c2r(
                    plan,
                    (double*)idataPtr,
                    odataPtr);
            }
        }

        /// <summary>
        /// Executes the plan on different arrays (complex to complex).
        /// </summary>
        /// <param name="plan">The plan handle.</param>
        /// <param name="idata">The input array.</param>
        /// <param name="odata">The output array.</param>
        public unsafe void fftwf_execute_dft(
            IntPtr plan,
            Span<(float Real, float Imaginary)> idata,
            Span<(float Real, float Imaginary)> odata)
        {
            fixed ((float Real, float Imaginary)* idataPtr = idata)
            fixed ((float Real, float Imaginary)* odataPtr = odata)
            {
                fftwf_execute_dft(
                    plan,
                    (float*)idataPtr,
                    (float*)odataPtr);
            }
        }

        /// <summary>
        /// Executes the plan on different arrays (real to complex).
        /// </summary>
        /// <param name="plan">The plan handle.</param>
        /// <param name="idata">The input array.</param>
        /// <param name="odata">The output array.</param>
        public unsafe void fftwf_execute_dft_r2c(
            IntPtr plan,
            Span<float> idata,
            Span<(float Real, float Imaginary)> odata)
        {
            fixed (float* idataPtr = idata)
            fixed ((float Real, float Imaginary)* odataPtr = odata)
            {
                fftwf_execute_dft_r2c(
                    plan,
                    idataPtr,
                    (float*)odataPtr);
            }
        }

        /// <summary>
        /// Executes the plan on different arrays (complex to real).
        /// </summary>
        /// <param name="plan">The plan handle.</param>
        /// <param name="idata">The input array.</param>
        /// <param name="odata">The output array.</param>
        public unsafe void fftwf_execute_dft_c2r(
            IntPtr plan,
            Span<(float Real, float Imaginary)> idata,
            Span<float> odata)
        {
            fixed ((float Real, float Imaginary)* idataPtr = idata)
            fixed (float* odataPtr = odata)
            {
                fftwf_execute_dft_c2r(
                    plan,
                    (float*)idataPtr,
                    odataPtr);
            }
        }

        /// <summary>
        /// Executes the plan on different arrays (complex to complex).
        /// </summary>
        /// <param name="plan">The plan handle.</param>
        /// <param name="idata">The input array.</param>
        /// <param name="odata">The output array.</param>
        public unsafe void fftwf_execute_dft(
            IntPtr plan,
            Span<Float2> idata,
            Span<Float2> odata)
        {
            fixed (Float2* idataPtr = idata)
            fixed (Float2* odataPtr = odata)
            {
                fftwf_execute_dft(
                    plan,
                    (float*)idataPtr,
                    (float*)odataPtr);
            }
        }

        /// <summary>
        /// Executes the plan on different arrays (real to complex).
        /// </summary>
        /// <param name="plan">The plan handle.</param>
        /// <param name="idata">The input array.</param>
        /// <param name="odata">The output array.</param>
        public unsafe void fftwf_execute_dft_r2c(
            IntPtr plan,
            Span<float> idata,
            Span<Float2> odata)
        {
            fixed (float* idataPtr = idata)
            fixed (Float2* odataPtr = odata)
            {
                fftwf_execute_dft_r2c(
                    plan,
                    idataPtr,
                    (float*)odataPtr);
            }
        }

        /// <summary>
        /// Executes the plan on different arrays (complex to real).
        /// </summary>
        /// <param name="plan">The plan handle.</param>
        /// <param name="idata">The input array.</param>
        /// <param name="odata">The output array.</param>
        public unsafe void fftwf_execute_dft_c2r(
            IntPtr plan,
            Span<Float2> idata,
            Span<float> odata)
        {
            fixed (Float2* idataPtr = idata)
            fixed (float* odataPtr = odata)
            {
                fftwf_execute_dft_c2r(
                    plan,
                    (float*)idataPtr,
                    odataPtr);
            }
        }

        #endregion
    }
}