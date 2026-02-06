// ---------------------------------------------------------------------------------------
//                                   ILGPU Algorithms
//                        Copyright (c) 2021-2023 ILGPU Project
//                                    www.ilgpu.net
//
// File: CuFFTWPlan.tt/CuFFTWPlan.cs
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


using ILGPU.Runtime.Cuda.API;
using ILGPU.Util;
using System;
using System.Numerics;

#pragma warning disable CA1707 // Identifiers should not contain underscores

namespace ILGPU.Runtime.Cuda
{
    /// <summary>
    /// Represents a cuFFTW plan for "double" type.
    /// </summary>
    public sealed class CuFFTWPlan : DisposeBase
    {
        /// <summary>
        /// Constructs a new instance to wrap a cuFFT plan.
        /// </summary>
        internal CuFFTWPlan(CuFFTWAPI api, IntPtr plan)
        {
            API = api;
            PlanHandle = plan;
        }

        /// <inheritdoc />
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                API.fftw_destroy_plan(PlanHandle);
                PlanHandle = IntPtr.Zero;
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// The underlying API wrapper.
        /// </summary>
        public CuFFTWAPI API { get; }

        /// <summary>
        /// The native plan handle.
        /// </summary>
        public IntPtr PlanHandle { get; private set; }

        /// <summary>
        /// Executes the plan.
        /// </summary>
        public void Execute() =>
            API.fftw_execute(PlanHandle);

        /// <summary>
        /// Executes the plan on different arrays (complex to complex).
        /// </summary>
        /// <param name="idata">The input array.</param>
        /// <param name="odata">The output array.</param>
        public void Execute(
            Span<Complex> idata,
            Span<Complex> odata) =>
            API.fftw_execute_dft(PlanHandle, idata, odata);

        /// <summary>
        /// Executes the plan on different arrays (real to complex).
        /// </summary>
        /// <param name="idata">The input array.</param>
        /// <param name="odata">The output array.</param>
        public void Execute_R2C(
            Span<double> idata,
            Span<Complex> odata) =>
            API.fftw_execute_dft_r2c(PlanHandle, idata, odata);

        /// <summary>
        /// Executes the plan on different arrays (complex to real).
        /// </summary>
        /// <param name="idata">The input array.</param>
        /// <param name="odata">The output array.</param>
        public void Execute_C2R(
            Span<Complex> idata,
            Span<double> odata) =>
            API.fftw_execute_dft_c2r(PlanHandle, idata, odata);

        /// <summary>
        /// Executes the plan on different arrays (complex to complex).
        /// </summary>
        /// <param name="idata">The input array.</param>
        /// <param name="odata">The output array.</param>
        public void Execute(
            Span<(double Real, double Imaginary)> idata,
            Span<(double Real, double Imaginary)> odata) =>
            API.fftw_execute_dft(PlanHandle, idata, odata);

        /// <summary>
        /// Executes the plan on different arrays (real to complex).
        /// </summary>
        /// <param name="idata">The input array.</param>
        /// <param name="odata">The output array.</param>
        public void Execute_R2C(
            Span<double> idata,
            Span<(double Real, double Imaginary)> odata) =>
            API.fftw_execute_dft_r2c(PlanHandle, idata, odata);

        /// <summary>
        /// Executes the plan on different arrays (complex to real).
        /// </summary>
        /// <param name="idata">The input array.</param>
        /// <param name="odata">The output array.</param>
        public void Execute_C2R(
            Span<(double Real, double Imaginary)> idata,
            Span<double> odata) =>
            API.fftw_execute_dft_c2r(PlanHandle, idata, odata);

        /// <summary>
        /// Executes the plan on different arrays (complex to complex).
        /// </summary>
        /// <param name="idata">The input array.</param>
        /// <param name="odata">The output array.</param>
        public void Execute(
            Span<Double2> idata,
            Span<Double2> odata) =>
            API.fftw_execute_dft(PlanHandle, idata, odata);

        /// <summary>
        /// Executes the plan on different arrays (real to complex).
        /// </summary>
        /// <param name="idata">The input array.</param>
        /// <param name="odata">The output array.</param>
        public void Execute_R2C(
            Span<double> idata,
            Span<Double2> odata) =>
            API.fftw_execute_dft_r2c(PlanHandle, idata, odata);

        /// <summary>
        /// Executes the plan on different arrays (complex to real).
        /// </summary>
        /// <param name="idata">The input array.</param>
        /// <param name="odata">The output array.</param>
        public void Execute_C2R(
            Span<Double2> idata,
            Span<double> odata) =>
            API.fftw_execute_dft_c2r(PlanHandle, idata, odata);

    }

    /// <summary>
    /// Represents a cuFFTW plan for "float" type.
    /// </summary>
    public sealed class CuFFTWPlanF : DisposeBase
    {
        /// <summary>
        /// Constructs a new instance to wrap a cuFFT plan.
        /// </summary>
        internal CuFFTWPlanF(CuFFTWAPI api, IntPtr plan)
        {
            API = api;
            PlanHandle = plan;
        }

        /// <inheritdoc />
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                API.fftwf_destroy_plan(PlanHandle);
                PlanHandle = IntPtr.Zero;
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// The underlying API wrapper.
        /// </summary>
        public CuFFTWAPI API { get; }

        /// <summary>
        /// The native plan handle.
        /// </summary>
        public IntPtr PlanHandle { get; private set; }

        /// <summary>
        /// Executes the plan.
        /// </summary>
        public void Execute() =>
            API.fftwf_execute(PlanHandle);

        /// <summary>
        /// Executes the plan on different arrays (complex to complex).
        /// </summary>
        /// <param name="idata">The input array.</param>
        /// <param name="odata">The output array.</param>
        public void Execute(
            Span<(float Real, float Imaginary)> idata,
            Span<(float Real, float Imaginary)> odata) =>
            API.fftwf_execute_dft(PlanHandle, idata, odata);

        /// <summary>
        /// Executes the plan on different arrays (real to complex).
        /// </summary>
        /// <param name="idata">The input array.</param>
        /// <param name="odata">The output array.</param>
        public void Execute_R2C(
            Span<float> idata,
            Span<(float Real, float Imaginary)> odata) =>
            API.fftwf_execute_dft_r2c(PlanHandle, idata, odata);

        /// <summary>
        /// Executes the plan on different arrays (complex to real).
        /// </summary>
        /// <param name="idata">The input array.</param>
        /// <param name="odata">The output array.</param>
        public void Execute_C2R(
            Span<(float Real, float Imaginary)> idata,
            Span<float> odata) =>
            API.fftwf_execute_dft_c2r(PlanHandle, idata, odata);

        /// <summary>
        /// Executes the plan on different arrays (complex to complex).
        /// </summary>
        /// <param name="idata">The input array.</param>
        /// <param name="odata">The output array.</param>
        public void Execute(
            Span<Float2> idata,
            Span<Float2> odata) =>
            API.fftwf_execute_dft(PlanHandle, idata, odata);

        /// <summary>
        /// Executes the plan on different arrays (real to complex).
        /// </summary>
        /// <param name="idata">The input array.</param>
        /// <param name="odata">The output array.</param>
        public void Execute_R2C(
            Span<float> idata,
            Span<Float2> odata) =>
            API.fftwf_execute_dft_r2c(PlanHandle, idata, odata);

        /// <summary>
        /// Executes the plan on different arrays (complex to real).
        /// </summary>
        /// <param name="idata">The input array.</param>
        /// <param name="odata">The output array.</param>
        public void Execute_C2R(
            Span<Float2> idata,
            Span<float> odata) =>
            API.fftwf_execute_dft_c2r(PlanHandle, idata, odata);

    }

}

#pragma warning restore CA1707 // Identifiers should not contain underscores