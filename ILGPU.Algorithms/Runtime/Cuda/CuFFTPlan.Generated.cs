// ---------------------------------------------------------------------------------------
//                                   ILGPU Algorithms
//                           Copyright (c) 2021 ILGPU Project
//                                    www.ilgpu.net
//
// File: CuFFTPlan.Generated.tt/CuFFTPlan.Generated.cs
//
// This file is part of ILGPU and is distributed under the University of Illinois Open
// Source License. See LICENSE.txt for details.
// ---------------------------------------------------------------------------------------

// ---------------------------------------------------------------------------------------
//                                   ILGPU Algorithms
//                           Copyright (c) 2021 ILGPU Project
//                                    www.ilgpu.net
//
// File: CuFFT.ttinclude
//
// This file is part of ILGPU and is distributed under the University of Illinois Open
// Source License. See LICENSE.txt for details.
// ---------------------------------------------------------------------------------------


using ILGPU.Util;
using System.Numerics;

namespace ILGPU.Runtime.Cuda
{
    partial class CuFFTPlan
    {
        #region Execution

        /// <summary>
        /// Executes the plan on the given arrays - complex to complex (single-precision).
        /// </summary>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="direction">The transform direction.</param>
        /// <returns>The error code.</returns>
        public CuFFTResult ExecC2C(
            ArrayView<(float Real, float Imaginary)> @in,
            ArrayView<(float Real, float Imaginary)> @out,
            CuFFTDirection direction) =>
            API.ExecC2C(
                PlanHandle,
                @in,
                @out,
                direction);

        /// <summary>
        /// Executes the plan on the given arrays - complex to complex (single-precision).
        /// </summary>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="direction">The transform direction.</param>
        /// <returns>The error code.</returns>
        public CuFFTResult ExecC2C(
            ArrayView<Float2> @in,
            ArrayView<Float2> @out,
            CuFFTDirection direction) =>
            API.ExecC2C(
                PlanHandle,
                @in,
                @out,
                direction);

        /// <summary>
        /// Executes the plan on the given arrays - complex to real (single-precision).
        /// </summary>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <returns>The error code.</returns>
        public CuFFTResult ExecC2R(
            ArrayView<(float Real, float Imaginary)> @in,
            ArrayView<float> @out) =>
            API.ExecC2R(
                PlanHandle,
                @in,
                @out);

        /// <summary>
        /// Executes the plan on the given arrays - complex to real (single-precision).
        /// </summary>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <returns>The error code.</returns>
        public CuFFTResult ExecC2R(
            ArrayView<Float2> @in,
            ArrayView<float> @out) =>
            API.ExecC2R(
                PlanHandle,
                @in,
                @out);

        /// <summary>
        /// Executes the plan on the given arrays - real to complex (single-precision).
        /// </summary>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <returns>The error code.</returns>
        public CuFFTResult ExecR2C(
            ArrayView<float> @in,
            ArrayView<(float Real, float Imaginary)> @out) =>
            API.ExecR2C(
                PlanHandle,
                @in,
                @out);

        /// <summary>
        /// Executes the plan on the given arrays - real to complex (single-precision).
        /// </summary>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <returns>The error code.</returns>
        public CuFFTResult ExecR2C(
            ArrayView<float> @in,
            ArrayView<Float2> @out) =>
            API.ExecR2C(
                PlanHandle,
                @in,
                @out);

        /// <summary>
        /// Executes the plan on the given arrays - complex to complex (double-precision).
        /// </summary>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="direction">The transform direction.</param>
        /// <returns>The error code.</returns>
        public CuFFTResult ExecZ2Z(
            ArrayView<Complex> @in,
            ArrayView<Complex> @out,
            CuFFTDirection direction) =>
            API.ExecZ2Z(
                PlanHandle,
                @in,
                @out,
                direction);

        /// <summary>
        /// Executes the plan on the given arrays - complex to complex (double-precision).
        /// </summary>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="direction">The transform direction.</param>
        /// <returns>The error code.</returns>
        public CuFFTResult ExecZ2Z(
            ArrayView<(double Real, double Imaginary)> @in,
            ArrayView<(double Real, double Imaginary)> @out,
            CuFFTDirection direction) =>
            API.ExecZ2Z(
                PlanHandle,
                @in,
                @out,
                direction);

        /// <summary>
        /// Executes the plan on the given arrays - complex to complex (double-precision).
        /// </summary>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="direction">The transform direction.</param>
        /// <returns>The error code.</returns>
        public CuFFTResult ExecZ2Z(
            ArrayView<Double2> @in,
            ArrayView<Double2> @out,
            CuFFTDirection direction) =>
            API.ExecZ2Z(
                PlanHandle,
                @in,
                @out,
                direction);

        /// <summary>
        /// Executes the plan on the given arrays - complex to real (double-precision).
        /// </summary>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <returns>The error code.</returns>
        public CuFFTResult ExecZ2D(
            ArrayView<Complex> @in,
            ArrayView<double> @out) =>
            API.ExecZ2D(
                PlanHandle,
                @in,
                @out);

        /// <summary>
        /// Executes the plan on the given arrays - complex to real (double-precision).
        /// </summary>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <returns>The error code.</returns>
        public CuFFTResult ExecZ2D(
            ArrayView<(double Real, double Imaginary)> @in,
            ArrayView<double> @out) =>
            API.ExecZ2D(
                PlanHandle,
                @in,
                @out);

        /// <summary>
        /// Executes the plan on the given arrays - complex to real (double-precision).
        /// </summary>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <returns>The error code.</returns>
        public CuFFTResult ExecZ2D(
            ArrayView<Double2> @in,
            ArrayView<double> @out) =>
            API.ExecZ2D(
                PlanHandle,
                @in,
                @out);

        /// <summary>
        /// Executes the plan on the given arrays - real to complex (double-precision).
        /// </summary>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <returns>The error code.</returns>
        public CuFFTResult ExecD2Z(
            ArrayView<double> @in,
            ArrayView<Complex> @out) =>
            API.ExecD2Z(
                PlanHandle,
                @in,
                @out);

        /// <summary>
        /// Executes the plan on the given arrays - real to complex (double-precision).
        /// </summary>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <returns>The error code.</returns>
        public CuFFTResult ExecD2Z(
            ArrayView<double> @in,
            ArrayView<(double Real, double Imaginary)> @out) =>
            API.ExecD2Z(
                PlanHandle,
                @in,
                @out);

        /// <summary>
        /// Executes the plan on the given arrays - real to complex (double-precision).
        /// </summary>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <returns>The error code.</returns>
        public CuFFTResult ExecD2Z(
            ArrayView<double> @in,
            ArrayView<Double2> @out) =>
            API.ExecD2Z(
                PlanHandle,
                @in,
                @out);

        #endregion
    }
}