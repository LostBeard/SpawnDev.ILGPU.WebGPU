// ---------------------------------------------------------------------------------------
//                                   ILGPU Algorithms
//                           Copyright (c) 2021 ILGPU Project
//                                    www.ilgpu.net
//
// File: CuFFTW.Generated.tt/CuFFTW.Generated.cs
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

namespace ILGPU.Runtime.Cuda
{
    partial class CuFFTW
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
        public CuFFTWPlan Plan1D(
            int nx,
            Span<Complex> @in,
            Span<Complex> @out,
            int sign,
            uint flags)
        {
            var plan = API.fftw_plan_dft_1d(
                nx,
                @in,
                @out,
                sign,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan Plan2D(
            int nx,
            int ny,
            Span<Complex> @in,
            Span<Complex> @out,
            int sign,
            uint flags)
        {
            var plan = API.fftw_plan_dft_2d(
                nx,
                ny,
                @in,
                @out,
                sign,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan Plan3D(
            int nx,
            int ny,
            int nz,
            Span<Complex> @in,
            Span<Complex> @out,
            int sign,
            uint flags)
        {
            var plan = API.fftw_plan_dft_3d(
                nx,
                ny,
                nz,
                @in,
                @out,
                sign,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan Plan(
            int rank,
            int[] n,
            Span<Complex> @in,
            Span<Complex> @out,
            int sign,
            uint flags)
        {
            var plan = API.fftw_plan_dft(
                rank,
                n,
                @in,
                @out,
                sign,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan Plan1D(
            int nx,
            Span<(double Real, double Imaginary)> @in,
            Span<(double Real, double Imaginary)> @out,
            int sign,
            uint flags)
        {
            var plan = API.fftw_plan_dft_1d(
                nx,
                @in,
                @out,
                sign,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan Plan2D(
            int nx,
            int ny,
            Span<(double Real, double Imaginary)> @in,
            Span<(double Real, double Imaginary)> @out,
            int sign,
            uint flags)
        {
            var plan = API.fftw_plan_dft_2d(
                nx,
                ny,
                @in,
                @out,
                sign,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan Plan3D(
            int nx,
            int ny,
            int nz,
            Span<(double Real, double Imaginary)> @in,
            Span<(double Real, double Imaginary)> @out,
            int sign,
            uint flags)
        {
            var plan = API.fftw_plan_dft_3d(
                nx,
                ny,
                nz,
                @in,
                @out,
                sign,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan Plan(
            int rank,
            int[] n,
            Span<(double Real, double Imaginary)> @in,
            Span<(double Real, double Imaginary)> @out,
            int sign,
            uint flags)
        {
            var plan = API.fftw_plan_dft(
                rank,
                n,
                @in,
                @out,
                sign,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan Plan1D(
            int nx,
            Span<Double2> @in,
            Span<Double2> @out,
            int sign,
            uint flags)
        {
            var plan = API.fftw_plan_dft_1d(
                nx,
                @in,
                @out,
                sign,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan Plan2D(
            int nx,
            int ny,
            Span<Double2> @in,
            Span<Double2> @out,
            int sign,
            uint flags)
        {
            var plan = API.fftw_plan_dft_2d(
                nx,
                ny,
                @in,
                @out,
                sign,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan Plan3D(
            int nx,
            int ny,
            int nz,
            Span<Double2> @in,
            Span<Double2> @out,
            int sign,
            uint flags)
        {
            var plan = API.fftw_plan_dft_3d(
                nx,
                ny,
                nz,
                @in,
                @out,
                sign,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan Plan(
            int rank,
            int[] n,
            Span<Double2> @in,
            Span<Double2> @out,
            int sign,
            uint flags)
        {
            var plan = API.fftw_plan_dft(
                rank,
                n,
                @in,
                @out,
                sign,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlanF Plan1D(
            int nx,
            Span<(float Real, float Imaginary)> @in,
            Span<(float Real, float Imaginary)> @out,
            int sign,
            uint flags)
        {
            var plan = API.fftwf_plan_dft_1d(
                nx,
                @in,
                @out,
                sign,
                flags);
            return new CuFFTWPlanF(API, plan);
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
        public CuFFTWPlanF Plan2D(
            int nx,
            int ny,
            Span<(float Real, float Imaginary)> @in,
            Span<(float Real, float Imaginary)> @out,
            int sign,
            uint flags)
        {
            var plan = API.fftwf_plan_dft_2d(
                nx,
                ny,
                @in,
                @out,
                sign,
                flags);
            return new CuFFTWPlanF(API, plan);
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
        public CuFFTWPlanF Plan3D(
            int nx,
            int ny,
            int nz,
            Span<(float Real, float Imaginary)> @in,
            Span<(float Real, float Imaginary)> @out,
            int sign,
            uint flags)
        {
            var plan = API.fftwf_plan_dft_3d(
                nx,
                ny,
                nz,
                @in,
                @out,
                sign,
                flags);
            return new CuFFTWPlanF(API, plan);
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
        public CuFFTWPlanF Plan(
            int rank,
            int[] n,
            Span<(float Real, float Imaginary)> @in,
            Span<(float Real, float Imaginary)> @out,
            int sign,
            uint flags)
        {
            var plan = API.fftwf_plan_dft(
                rank,
                n,
                @in,
                @out,
                sign,
                flags);
            return new CuFFTWPlanF(API, plan);
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
        public CuFFTWPlanF Plan1D(
            int nx,
            Span<Float2> @in,
            Span<Float2> @out,
            int sign,
            uint flags)
        {
            var plan = API.fftwf_plan_dft_1d(
                nx,
                @in,
                @out,
                sign,
                flags);
            return new CuFFTWPlanF(API, plan);
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
        public CuFFTWPlanF Plan2D(
            int nx,
            int ny,
            Span<Float2> @in,
            Span<Float2> @out,
            int sign,
            uint flags)
        {
            var plan = API.fftwf_plan_dft_2d(
                nx,
                ny,
                @in,
                @out,
                sign,
                flags);
            return new CuFFTWPlanF(API, plan);
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
        public CuFFTWPlanF Plan3D(
            int nx,
            int ny,
            int nz,
            Span<Float2> @in,
            Span<Float2> @out,
            int sign,
            uint flags)
        {
            var plan = API.fftwf_plan_dft_3d(
                nx,
                ny,
                nz,
                @in,
                @out,
                sign,
                flags);
            return new CuFFTWPlanF(API, plan);
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
        public CuFFTWPlanF Plan(
            int rank,
            int[] n,
            Span<Float2> @in,
            Span<Float2> @out,
            int sign,
            uint flags)
        {
            var plan = API.fftwf_plan_dft(
                rank,
                n,
                @in,
                @out,
                sign,
                flags);
            return new CuFFTWPlanF(API, plan);
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
        public CuFFTWPlan Plan1D_R2C(
            int nx,
            Span<double> @in,
            Span<Complex> @out,
            uint flags)
        {
            var plan = API.fftw_plan_dft_r2c_1d(
                nx,
                @in,
                @out,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan Plan2D_R2C(
            int nx,
            int ny,
            Span<double> @in,
            Span<Complex> @out,
            uint flags)
        {
            var plan = API.fftw_plan_dft_r2c_2d(
                nx,
                ny,
                @in,
                @out,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan Plan3D_R2C(
            int nx,
            int ny,
            int nz,
            Span<double> @in,
            Span<Complex> @out,
            uint flags)
        {
            var plan = API.fftw_plan_dft_r2c_3d(
                nx,
                ny,
                nz,
                @in,
                @out,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan Plan_R2C(
            int rank,
            int[] n,
            Span<double> @in,
            Span<Complex> @out,
            uint flags)
        {
            var plan = API.fftw_plan_dft_r2c(
                rank,
                n,
                @in,
                @out,
                flags);
            return new CuFFTWPlan(API, plan);
        }

        /// <summary>
        /// Creates a 1D real to complex plan.
        /// </summary>
        /// <param name="nx">The transform size.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public CuFFTWPlan Plan1D_R2C(
            int nx,
            Span<double> @in,
            Span<(double Real, double Imaginary)> @out,
            uint flags)
        {
            var plan = API.fftw_plan_dft_r2c_1d(
                nx,
                @in,
                @out,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan Plan2D_R2C(
            int nx,
            int ny,
            Span<double> @in,
            Span<(double Real, double Imaginary)> @out,
            uint flags)
        {
            var plan = API.fftw_plan_dft_r2c_2d(
                nx,
                ny,
                @in,
                @out,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan Plan3D_R2C(
            int nx,
            int ny,
            int nz,
            Span<double> @in,
            Span<(double Real, double Imaginary)> @out,
            uint flags)
        {
            var plan = API.fftw_plan_dft_r2c_3d(
                nx,
                ny,
                nz,
                @in,
                @out,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan Plan_R2C(
            int rank,
            int[] n,
            Span<double> @in,
            Span<(double Real, double Imaginary)> @out,
            uint flags)
        {
            var plan = API.fftw_plan_dft_r2c(
                rank,
                n,
                @in,
                @out,
                flags);
            return new CuFFTWPlan(API, plan);
        }

        /// <summary>
        /// Creates a 1D real to complex plan.
        /// </summary>
        /// <param name="nx">The transform size.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public CuFFTWPlan Plan1D_R2C(
            int nx,
            Span<double> @in,
            Span<Double2> @out,
            uint flags)
        {
            var plan = API.fftw_plan_dft_r2c_1d(
                nx,
                @in,
                @out,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan Plan2D_R2C(
            int nx,
            int ny,
            Span<double> @in,
            Span<Double2> @out,
            uint flags)
        {
            var plan = API.fftw_plan_dft_r2c_2d(
                nx,
                ny,
                @in,
                @out,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan Plan3D_R2C(
            int nx,
            int ny,
            int nz,
            Span<double> @in,
            Span<Double2> @out,
            uint flags)
        {
            var plan = API.fftw_plan_dft_r2c_3d(
                nx,
                ny,
                nz,
                @in,
                @out,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan Plan_R2C(
            int rank,
            int[] n,
            Span<double> @in,
            Span<Double2> @out,
            uint flags)
        {
            var plan = API.fftw_plan_dft_r2c(
                rank,
                n,
                @in,
                @out,
                flags);
            return new CuFFTWPlan(API, plan);
        }

        /// <summary>
        /// Creates a 1D real to complex plan.
        /// </summary>
        /// <param name="nx">The transform size.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public CuFFTWPlanF Plan1D_R2C(
            int nx,
            Span<float> @in,
            Span<(float Real, float Imaginary)> @out,
            uint flags)
        {
            var plan = API.fftwf_plan_dft_r2c_1d(
                nx,
                @in,
                @out,
                flags);
            return new CuFFTWPlanF(API, plan);
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
        public CuFFTWPlanF Plan2D_R2C(
            int nx,
            int ny,
            Span<float> @in,
            Span<(float Real, float Imaginary)> @out,
            uint flags)
        {
            var plan = API.fftwf_plan_dft_r2c_2d(
                nx,
                ny,
                @in,
                @out,
                flags);
            return new CuFFTWPlanF(API, plan);
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
        public CuFFTWPlanF Plan3D_R2C(
            int nx,
            int ny,
            int nz,
            Span<float> @in,
            Span<(float Real, float Imaginary)> @out,
            uint flags)
        {
            var plan = API.fftwf_plan_dft_r2c_3d(
                nx,
                ny,
                nz,
                @in,
                @out,
                flags);
            return new CuFFTWPlanF(API, plan);
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
        public CuFFTWPlanF Plan_R2C(
            int rank,
            int[] n,
            Span<float> @in,
            Span<(float Real, float Imaginary)> @out,
            uint flags)
        {
            var plan = API.fftwf_plan_dft_r2c(
                rank,
                n,
                @in,
                @out,
                flags);
            return new CuFFTWPlanF(API, plan);
        }

        /// <summary>
        /// Creates a 1D real to complex plan.
        /// </summary>
        /// <param name="nx">The transform size.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public CuFFTWPlanF Plan1D_R2C(
            int nx,
            Span<float> @in,
            Span<Float2> @out,
            uint flags)
        {
            var plan = API.fftwf_plan_dft_r2c_1d(
                nx,
                @in,
                @out,
                flags);
            return new CuFFTWPlanF(API, plan);
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
        public CuFFTWPlanF Plan2D_R2C(
            int nx,
            int ny,
            Span<float> @in,
            Span<Float2> @out,
            uint flags)
        {
            var plan = API.fftwf_plan_dft_r2c_2d(
                nx,
                ny,
                @in,
                @out,
                flags);
            return new CuFFTWPlanF(API, plan);
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
        public CuFFTWPlanF Plan3D_R2C(
            int nx,
            int ny,
            int nz,
            Span<float> @in,
            Span<Float2> @out,
            uint flags)
        {
            var plan = API.fftwf_plan_dft_r2c_3d(
                nx,
                ny,
                nz,
                @in,
                @out,
                flags);
            return new CuFFTWPlanF(API, plan);
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
        public CuFFTWPlanF Plan_R2C(
            int rank,
            int[] n,
            Span<float> @in,
            Span<Float2> @out,
            uint flags)
        {
            var plan = API.fftwf_plan_dft_r2c(
                rank,
                n,
                @in,
                @out,
                flags);
            return new CuFFTWPlanF(API, plan);
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
        public CuFFTWPlan Plan1D_C2R(
            int nx,
            Span<Complex> @in,
            Span<double> @out,
            uint flags)
        {
            var plan = API.fftw_plan_dft_c2r_1d(
                nx,
                @in,
                @out,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan Plan2D_C2R(
            int nx,
            int ny,
            Span<Complex> @in,
            Span<double> @out,
            uint flags)
        {
            var plan = API.fftw_plan_dft_c2r_2d(
                nx,
                ny,
                @in,
                @out,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan Plan3D_C2R(
            int nx,
            int ny,
            int nz,
            Span<Complex> @in,
            Span<double> @out,
            uint flags)
        {
            var plan = API.fftw_plan_dft_c2r_3d(
                nx,
                ny,
                nz,
                @in,
                @out,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan Plan_C2R(
            int rank,
            int[] n,
            Span<Complex> @in,
            Span<double> @out,
            uint flags)
        {
            var plan = API.fftw_plan_dft_c2r(
                rank,
                n,
                @in,
                @out,
                flags);
            return new CuFFTWPlan(API, plan);
        }

        /// <summary>
        /// Creates a 1D complex to real plan.
        /// </summary>
        /// <param name="nx">The transform size.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public CuFFTWPlan Plan1D_C2R(
            int nx,
            Span<(double Real, double Imaginary)> @in,
            Span<double> @out,
            uint flags)
        {
            var plan = API.fftw_plan_dft_c2r_1d(
                nx,
                @in,
                @out,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan Plan2D_C2R(
            int nx,
            int ny,
            Span<(double Real, double Imaginary)> @in,
            Span<double> @out,
            uint flags)
        {
            var plan = API.fftw_plan_dft_c2r_2d(
                nx,
                ny,
                @in,
                @out,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan Plan3D_C2R(
            int nx,
            int ny,
            int nz,
            Span<(double Real, double Imaginary)> @in,
            Span<double> @out,
            uint flags)
        {
            var plan = API.fftw_plan_dft_c2r_3d(
                nx,
                ny,
                nz,
                @in,
                @out,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan Plan_C2R(
            int rank,
            int[] n,
            Span<(double Real, double Imaginary)> @in,
            Span<double> @out,
            uint flags)
        {
            var plan = API.fftw_plan_dft_c2r(
                rank,
                n,
                @in,
                @out,
                flags);
            return new CuFFTWPlan(API, plan);
        }

        /// <summary>
        /// Creates a 1D complex to real plan.
        /// </summary>
        /// <param name="nx">The transform size.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public CuFFTWPlan Plan1D_C2R(
            int nx,
            Span<Double2> @in,
            Span<double> @out,
            uint flags)
        {
            var plan = API.fftw_plan_dft_c2r_1d(
                nx,
                @in,
                @out,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan Plan2D_C2R(
            int nx,
            int ny,
            Span<Double2> @in,
            Span<double> @out,
            uint flags)
        {
            var plan = API.fftw_plan_dft_c2r_2d(
                nx,
                ny,
                @in,
                @out,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan Plan3D_C2R(
            int nx,
            int ny,
            int nz,
            Span<Double2> @in,
            Span<double> @out,
            uint flags)
        {
            var plan = API.fftw_plan_dft_c2r_3d(
                nx,
                ny,
                nz,
                @in,
                @out,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan Plan_C2R(
            int rank,
            int[] n,
            Span<Double2> @in,
            Span<double> @out,
            uint flags)
        {
            var plan = API.fftw_plan_dft_c2r(
                rank,
                n,
                @in,
                @out,
                flags);
            return new CuFFTWPlan(API, plan);
        }

        /// <summary>
        /// Creates a 1D complex to real plan.
        /// </summary>
        /// <param name="nx">The transform size.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public CuFFTWPlanF Plan1D_C2R(
            int nx,
            Span<(float Real, float Imaginary)> @in,
            Span<float> @out,
            uint flags)
        {
            var plan = API.fftwf_plan_dft_c2r_1d(
                nx,
                @in,
                @out,
                flags);
            return new CuFFTWPlanF(API, plan);
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
        public CuFFTWPlanF Plan2D_C2R(
            int nx,
            int ny,
            Span<(float Real, float Imaginary)> @in,
            Span<float> @out,
            uint flags)
        {
            var plan = API.fftwf_plan_dft_c2r_2d(
                nx,
                ny,
                @in,
                @out,
                flags);
            return new CuFFTWPlanF(API, plan);
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
        public CuFFTWPlanF Plan3D_C2R(
            int nx,
            int ny,
            int nz,
            Span<(float Real, float Imaginary)> @in,
            Span<float> @out,
            uint flags)
        {
            var plan = API.fftwf_plan_dft_c2r_3d(
                nx,
                ny,
                nz,
                @in,
                @out,
                flags);
            return new CuFFTWPlanF(API, plan);
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
        public CuFFTWPlanF Plan_C2R(
            int rank,
            int[] n,
            Span<(float Real, float Imaginary)> @in,
            Span<float> @out,
            uint flags)
        {
            var plan = API.fftwf_plan_dft_c2r(
                rank,
                n,
                @in,
                @out,
                flags);
            return new CuFFTWPlanF(API, plan);
        }

        /// <summary>
        /// Creates a 1D complex to real plan.
        /// </summary>
        /// <param name="nx">The transform size.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="flags">The planner flags.</param>
        /// <returns>The created plan.</returns>
        public CuFFTWPlanF Plan1D_C2R(
            int nx,
            Span<Float2> @in,
            Span<float> @out,
            uint flags)
        {
            var plan = API.fftwf_plan_dft_c2r_1d(
                nx,
                @in,
                @out,
                flags);
            return new CuFFTWPlanF(API, plan);
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
        public CuFFTWPlanF Plan2D_C2R(
            int nx,
            int ny,
            Span<Float2> @in,
            Span<float> @out,
            uint flags)
        {
            var plan = API.fftwf_plan_dft_c2r_2d(
                nx,
                ny,
                @in,
                @out,
                flags);
            return new CuFFTWPlanF(API, plan);
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
        public CuFFTWPlanF Plan3D_C2R(
            int nx,
            int ny,
            int nz,
            Span<Float2> @in,
            Span<float> @out,
            uint flags)
        {
            var plan = API.fftwf_plan_dft_c2r_3d(
                nx,
                ny,
                nz,
                @in,
                @out,
                flags);
            return new CuFFTWPlanF(API, plan);
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
        public CuFFTWPlanF Plan_C2R(
            int rank,
            int[] n,
            Span<Float2> @in,
            Span<float> @out,
            uint flags)
        {
            var plan = API.fftwf_plan_dft_c2r(
                rank,
                n,
                @in,
                @out,
                flags);
            return new CuFFTWPlanF(API, plan);
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
        public CuFFTWPlan PlanMany(
            int rank,
            int[] n,
            int batch,
            Span<Complex> @in,
            int[] inembed,
            int istride,
            int idist,
            Span<Complex> @out,
            int[] onembed,
            int ostride,
            int odist,
            int sign,
            uint flags)
        {
            var plan = API.fftw_plan_many_dft(
                rank,
                n,
                batch,
                @in,
                inembed,
                istride,
                idist,
                @out,
                onembed,
                ostride,
                odist,
                sign,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan PlanMany_R2C(
            int rank,
            int[] n,
            int batch,
            Span<double> @in,
            int[] inembed,
            int istride,
            int idist,
            Span<Complex> @out,
            int[] onembed,
            int ostride,
            int odist,
            uint flags)
        {
            var plan = API.fftw_plan_many_dft_r2c(
                rank,
                n,
                batch,
                @in,
                inembed,
                istride,
                idist,
                @out,
                onembed,
                ostride,
                odist,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan PlanMany_C2R(
            int rank,
            int[] n,
            int batch,
            Span<Complex> @in,
            int[] inembed,
            int istride,
            int idist,
            Span<double> @out,
            int[] onembed,
            int ostride,
            int odist,
            uint flags)
        {
            var plan = API.fftw_plan_many_dft_c2r(
                rank,
                n,
                batch,
                @in,
                inembed,
                istride,
                idist,
                @out,
                onembed,
                ostride,
                odist,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan PlanMany(
            int rank,
            int[] n,
            int batch,
            Span<(double Real, double Imaginary)> @in,
            int[] inembed,
            int istride,
            int idist,
            Span<(double Real, double Imaginary)> @out,
            int[] onembed,
            int ostride,
            int odist,
            int sign,
            uint flags)
        {
            var plan = API.fftw_plan_many_dft(
                rank,
                n,
                batch,
                @in,
                inembed,
                istride,
                idist,
                @out,
                onembed,
                ostride,
                odist,
                sign,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan PlanMany_R2C(
            int rank,
            int[] n,
            int batch,
            Span<double> @in,
            int[] inembed,
            int istride,
            int idist,
            Span<(double Real, double Imaginary)> @out,
            int[] onembed,
            int ostride,
            int odist,
            uint flags)
        {
            var plan = API.fftw_plan_many_dft_r2c(
                rank,
                n,
                batch,
                @in,
                inembed,
                istride,
                idist,
                @out,
                onembed,
                ostride,
                odist,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan PlanMany_C2R(
            int rank,
            int[] n,
            int batch,
            Span<(double Real, double Imaginary)> @in,
            int[] inembed,
            int istride,
            int idist,
            Span<double> @out,
            int[] onembed,
            int ostride,
            int odist,
            uint flags)
        {
            var plan = API.fftw_plan_many_dft_c2r(
                rank,
                n,
                batch,
                @in,
                inembed,
                istride,
                idist,
                @out,
                onembed,
                ostride,
                odist,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan PlanMany(
            int rank,
            int[] n,
            int batch,
            Span<Double2> @in,
            int[] inembed,
            int istride,
            int idist,
            Span<Double2> @out,
            int[] onembed,
            int ostride,
            int odist,
            int sign,
            uint flags)
        {
            var plan = API.fftw_plan_many_dft(
                rank,
                n,
                batch,
                @in,
                inembed,
                istride,
                idist,
                @out,
                onembed,
                ostride,
                odist,
                sign,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan PlanMany_R2C(
            int rank,
            int[] n,
            int batch,
            Span<double> @in,
            int[] inembed,
            int istride,
            int idist,
            Span<Double2> @out,
            int[] onembed,
            int ostride,
            int odist,
            uint flags)
        {
            var plan = API.fftw_plan_many_dft_r2c(
                rank,
                n,
                batch,
                @in,
                inembed,
                istride,
                idist,
                @out,
                onembed,
                ostride,
                odist,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan PlanMany_C2R(
            int rank,
            int[] n,
            int batch,
            Span<Double2> @in,
            int[] inembed,
            int istride,
            int idist,
            Span<double> @out,
            int[] onembed,
            int ostride,
            int odist,
            uint flags)
        {
            var plan = API.fftw_plan_many_dft_c2r(
                rank,
                n,
                batch,
                @in,
                inembed,
                istride,
                idist,
                @out,
                onembed,
                ostride,
                odist,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlanF PlanMany(
            int rank,
            int[] n,
            int batch,
            Span<(float Real, float Imaginary)> @in,
            int[] inembed,
            int istride,
            int idist,
            Span<(float Real, float Imaginary)> @out,
            int[] onembed,
            int ostride,
            int odist,
            int sign,
            uint flags)
        {
            var plan = API.fftwf_plan_many_dft(
                rank,
                n,
                batch,
                @in,
                inembed,
                istride,
                idist,
                @out,
                onembed,
                ostride,
                odist,
                sign,
                flags);
            return new CuFFTWPlanF(API, plan);
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
        public CuFFTWPlanF PlanMany_R2C(
            int rank,
            int[] n,
            int batch,
            Span<float> @in,
            int[] inembed,
            int istride,
            int idist,
            Span<(float Real, float Imaginary)> @out,
            int[] onembed,
            int ostride,
            int odist,
            uint flags)
        {
            var plan = API.fftwf_plan_many_dft_r2c(
                rank,
                n,
                batch,
                @in,
                inembed,
                istride,
                idist,
                @out,
                onembed,
                ostride,
                odist,
                flags);
            return new CuFFTWPlanF(API, plan);
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
        public CuFFTWPlanF PlanMany_C2R(
            int rank,
            int[] n,
            int batch,
            Span<(float Real, float Imaginary)> @in,
            int[] inembed,
            int istride,
            int idist,
            Span<float> @out,
            int[] onembed,
            int ostride,
            int odist,
            uint flags)
        {
            var plan = API.fftwf_plan_many_dft_c2r(
                rank,
                n,
                batch,
                @in,
                inembed,
                istride,
                idist,
                @out,
                onembed,
                ostride,
                odist,
                flags);
            return new CuFFTWPlanF(API, plan);
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
        public CuFFTWPlanF PlanMany(
            int rank,
            int[] n,
            int batch,
            Span<Float2> @in,
            int[] inembed,
            int istride,
            int idist,
            Span<Float2> @out,
            int[] onembed,
            int ostride,
            int odist,
            int sign,
            uint flags)
        {
            var plan = API.fftwf_plan_many_dft(
                rank,
                n,
                batch,
                @in,
                inembed,
                istride,
                idist,
                @out,
                onembed,
                ostride,
                odist,
                sign,
                flags);
            return new CuFFTWPlanF(API, plan);
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
        public CuFFTWPlanF PlanMany_R2C(
            int rank,
            int[] n,
            int batch,
            Span<float> @in,
            int[] inembed,
            int istride,
            int idist,
            Span<Float2> @out,
            int[] onembed,
            int ostride,
            int odist,
            uint flags)
        {
            var plan = API.fftwf_plan_many_dft_r2c(
                rank,
                n,
                batch,
                @in,
                inembed,
                istride,
                idist,
                @out,
                onembed,
                ostride,
                odist,
                flags);
            return new CuFFTWPlanF(API, plan);
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
        public CuFFTWPlanF PlanMany_C2R(
            int rank,
            int[] n,
            int batch,
            Span<Float2> @in,
            int[] inembed,
            int istride,
            int idist,
            Span<float> @out,
            int[] onembed,
            int ostride,
            int odist,
            uint flags)
        {
            var plan = API.fftwf_plan_many_dft_c2r(
                rank,
                n,
                batch,
                @in,
                inembed,
                istride,
                idist,
                @out,
                onembed,
                ostride,
                odist,
                flags);
            return new CuFFTWPlanF(API, plan);
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
        public CuFFTWPlan PlanGuru(
            int rank,
            iodim[] dims,
            int batch_rank,
            iodim[] batch_dims,
            Span<Complex> @in,
            Span<Complex> @out,
            int sign,
            uint flags)
        {
            var plan = API.fftw_plan_guru_dft(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                sign,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan PlanGuru_R2C(
            int rank,
            iodim[] dims,
            int batch_rank,
            iodim[] batch_dims,
            Span<double> @in,
            Span<Complex> @out,
            uint flags)
        {
            var plan = API.fftw_plan_guru_dft_r2c(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan PlanGuru_C2R(
            int rank,
            iodim[] dims,
            int batch_rank,
            iodim[] batch_dims,
            Span<Complex> @in,
            Span<double> @out,
            uint flags)
        {
            var plan = API.fftw_plan_guru_dft_c2r(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan PlanGuru(
            int rank,
            iodim[] dims,
            int batch_rank,
            iodim[] batch_dims,
            Span<(double Real, double Imaginary)> @in,
            Span<(double Real, double Imaginary)> @out,
            int sign,
            uint flags)
        {
            var plan = API.fftw_plan_guru_dft(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                sign,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan PlanGuru_R2C(
            int rank,
            iodim[] dims,
            int batch_rank,
            iodim[] batch_dims,
            Span<double> @in,
            Span<(double Real, double Imaginary)> @out,
            uint flags)
        {
            var plan = API.fftw_plan_guru_dft_r2c(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan PlanGuru_C2R(
            int rank,
            iodim[] dims,
            int batch_rank,
            iodim[] batch_dims,
            Span<(double Real, double Imaginary)> @in,
            Span<double> @out,
            uint flags)
        {
            var plan = API.fftw_plan_guru_dft_c2r(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan PlanGuru(
            int rank,
            iodim[] dims,
            int batch_rank,
            iodim[] batch_dims,
            Span<Double2> @in,
            Span<Double2> @out,
            int sign,
            uint flags)
        {
            var plan = API.fftw_plan_guru_dft(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                sign,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan PlanGuru_R2C(
            int rank,
            iodim[] dims,
            int batch_rank,
            iodim[] batch_dims,
            Span<double> @in,
            Span<Double2> @out,
            uint flags)
        {
            var plan = API.fftw_plan_guru_dft_r2c(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan PlanGuru_C2R(
            int rank,
            iodim[] dims,
            int batch_rank,
            iodim[] batch_dims,
            Span<Double2> @in,
            Span<double> @out,
            uint flags)
        {
            var plan = API.fftw_plan_guru_dft_c2r(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlanF PlanGuru(
            int rank,
            iodim[] dims,
            int batch_rank,
            iodim[] batch_dims,
            Span<(float Real, float Imaginary)> @in,
            Span<(float Real, float Imaginary)> @out,
            int sign,
            uint flags)
        {
            var plan = API.fftwf_plan_guru_dft(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                sign,
                flags);
            return new CuFFTWPlanF(API, plan);
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
        public CuFFTWPlanF PlanGuru_R2C(
            int rank,
            iodim[] dims,
            int batch_rank,
            iodim[] batch_dims,
            Span<float> @in,
            Span<(float Real, float Imaginary)> @out,
            uint flags)
        {
            var plan = API.fftwf_plan_guru_dft_r2c(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);
            return new CuFFTWPlanF(API, plan);
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
        public CuFFTWPlanF PlanGuru_C2R(
            int rank,
            iodim[] dims,
            int batch_rank,
            iodim[] batch_dims,
            Span<(float Real, float Imaginary)> @in,
            Span<float> @out,
            uint flags)
        {
            var plan = API.fftwf_plan_guru_dft_c2r(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);
            return new CuFFTWPlanF(API, plan);
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
        public CuFFTWPlanF PlanGuru(
            int rank,
            iodim[] dims,
            int batch_rank,
            iodim[] batch_dims,
            Span<Float2> @in,
            Span<Float2> @out,
            int sign,
            uint flags)
        {
            var plan = API.fftwf_plan_guru_dft(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                sign,
                flags);
            return new CuFFTWPlanF(API, plan);
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
        public CuFFTWPlanF PlanGuru_R2C(
            int rank,
            iodim[] dims,
            int batch_rank,
            iodim[] batch_dims,
            Span<float> @in,
            Span<Float2> @out,
            uint flags)
        {
            var plan = API.fftwf_plan_guru_dft_r2c(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);
            return new CuFFTWPlanF(API, plan);
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
        public CuFFTWPlanF PlanGuru_C2R(
            int rank,
            iodim[] dims,
            int batch_rank,
            iodim[] batch_dims,
            Span<Float2> @in,
            Span<float> @out,
            uint flags)
        {
            var plan = API.fftwf_plan_guru_dft_c2r(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);
            return new CuFFTWPlanF(API, plan);
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
        public CuFFTWPlan PlanGuru(
            int rank,
            iodim64[] dims,
            int batch_rank,
            iodim64[] batch_dims,
            Span<Complex> @in,
            Span<Complex> @out,
            int sign,
            uint flags)
        {
            var plan = API.fftw_plan_guru64_dft(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                sign,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan PlanGuru_R2C(
            int rank,
            iodim64[] dims,
            int batch_rank,
            iodim64[] batch_dims,
            Span<double> @in,
            Span<Complex> @out,
            uint flags)
        {
            var plan = API.fftw_plan_guru64_dft_r2c(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan PlanGuru_C2R(
            int rank,
            iodim64[] dims,
            int batch_rank,
            iodim64[] batch_dims,
            Span<Complex> @in,
            Span<double> @out,
            uint flags)
        {
            var plan = API.fftw_plan_guru64_dft_c2r(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan PlanGuru(
            int rank,
            iodim64[] dims,
            int batch_rank,
            iodim64[] batch_dims,
            Span<(double Real, double Imaginary)> @in,
            Span<(double Real, double Imaginary)> @out,
            int sign,
            uint flags)
        {
            var plan = API.fftw_plan_guru64_dft(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                sign,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan PlanGuru_R2C(
            int rank,
            iodim64[] dims,
            int batch_rank,
            iodim64[] batch_dims,
            Span<double> @in,
            Span<(double Real, double Imaginary)> @out,
            uint flags)
        {
            var plan = API.fftw_plan_guru64_dft_r2c(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan PlanGuru_C2R(
            int rank,
            iodim64[] dims,
            int batch_rank,
            iodim64[] batch_dims,
            Span<(double Real, double Imaginary)> @in,
            Span<double> @out,
            uint flags)
        {
            var plan = API.fftw_plan_guru64_dft_c2r(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan PlanGuru(
            int rank,
            iodim64[] dims,
            int batch_rank,
            iodim64[] batch_dims,
            Span<Double2> @in,
            Span<Double2> @out,
            int sign,
            uint flags)
        {
            var plan = API.fftw_plan_guru64_dft(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                sign,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan PlanGuru_R2C(
            int rank,
            iodim64[] dims,
            int batch_rank,
            iodim64[] batch_dims,
            Span<double> @in,
            Span<Double2> @out,
            uint flags)
        {
            var plan = API.fftw_plan_guru64_dft_r2c(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlan PlanGuru_C2R(
            int rank,
            iodim64[] dims,
            int batch_rank,
            iodim64[] batch_dims,
            Span<Double2> @in,
            Span<double> @out,
            uint flags)
        {
            var plan = API.fftw_plan_guru64_dft_c2r(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);
            return new CuFFTWPlan(API, plan);
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
        public CuFFTWPlanF PlanGuru(
            int rank,
            iodim64[] dims,
            int batch_rank,
            iodim64[] batch_dims,
            Span<(float Real, float Imaginary)> @in,
            Span<(float Real, float Imaginary)> @out,
            int sign,
            uint flags)
        {
            var plan = API.fftwf_plan_guru64_dft(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                sign,
                flags);
            return new CuFFTWPlanF(API, plan);
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
        public CuFFTWPlanF PlanGuru_R2C(
            int rank,
            iodim64[] dims,
            int batch_rank,
            iodim64[] batch_dims,
            Span<float> @in,
            Span<(float Real, float Imaginary)> @out,
            uint flags)
        {
            var plan = API.fftwf_plan_guru64_dft_r2c(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);
            return new CuFFTWPlanF(API, plan);
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
        public CuFFTWPlanF PlanGuru_C2R(
            int rank,
            iodim64[] dims,
            int batch_rank,
            iodim64[] batch_dims,
            Span<(float Real, float Imaginary)> @in,
            Span<float> @out,
            uint flags)
        {
            var plan = API.fftwf_plan_guru64_dft_c2r(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);
            return new CuFFTWPlanF(API, plan);
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
        public CuFFTWPlanF PlanGuru(
            int rank,
            iodim64[] dims,
            int batch_rank,
            iodim64[] batch_dims,
            Span<Float2> @in,
            Span<Float2> @out,
            int sign,
            uint flags)
        {
            var plan = API.fftwf_plan_guru64_dft(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                sign,
                flags);
            return new CuFFTWPlanF(API, plan);
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
        public CuFFTWPlanF PlanGuru_R2C(
            int rank,
            iodim64[] dims,
            int batch_rank,
            iodim64[] batch_dims,
            Span<float> @in,
            Span<Float2> @out,
            uint flags)
        {
            var plan = API.fftwf_plan_guru64_dft_r2c(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);
            return new CuFFTWPlanF(API, plan);
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
        public CuFFTWPlanF PlanGuru_C2R(
            int rank,
            iodim64[] dims,
            int batch_rank,
            iodim64[] batch_dims,
            Span<Float2> @in,
            Span<float> @out,
            uint flags)
        {
            var plan = API.fftwf_plan_guru64_dft_c2r(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);
            return new CuFFTWPlanF(API, plan);
        }

        #endregion

        #region Utilities

        /// <summary>
        /// Sets time limit for planning.
        /// </summary>
        public void SetTimeLimit(double seconds) =>
            API.fftw_set_timelimit(seconds);

        /// <summary>
        /// Cleanup CuFFTW plans and accumulated wisdom.
        /// </summary>
        public void Cleanup() =>
            API.fftw_cleanup();

        /// <summary>
        /// Sets time limit for planning.
        /// </summary>
        public void SetTimeLimitF(double seconds) =>
            API.fftwf_set_timelimit(seconds);

        /// <summary>
        /// Cleanup CuFFTW plans and accumulated wisdom.
        /// </summary>
        public void CleanupF() =>
            API.fftwf_cleanup();

        #endregion
    }
}