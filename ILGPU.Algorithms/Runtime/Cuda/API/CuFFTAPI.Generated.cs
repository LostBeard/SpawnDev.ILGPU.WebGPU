// ---------------------------------------------------------------------------------------
//                                   ILGPU Algorithms
//                           Copyright (c) 2021 ILGPU Project
//                                    www.ilgpu.net
//
// File: CuFFTAPI.Generated.tt/CuFFTAPI.Generated.cs
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
using System;
using System.Numerics;

namespace ILGPU.Runtime.Cuda.API
{
    partial class CuFFTAPI
    {
        #region Execution

        /// <summary>
        /// Executes the plan on the given arrays - complex to complex (single-precision).
        /// </summary>
        /// <param name="plan">The plan handle.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="direction">The transform direction.</param>
        /// <returns>The error code.</returns>
        public CuFFTResult ExecC2C(
            IntPtr plan,
            ArrayView<(float Real, float Imaginary)> @in,
            ArrayView<(float Real, float Imaginary)> @out,
            CuFFTDirection direction) =>
            ExecC2C(
                plan,
                @in.LoadEffectiveAddressAsPtr(),
                @out.LoadEffectiveAddressAsPtr(),
                direction);

        /// <summary>
        /// Executes the plan on the given arrays - complex to complex (single-precision).
        /// </summary>
        /// <param name="plan">The plan handle.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="direction">The transform direction.</param>
        /// <returns>The error code.</returns>
        public CuFFTResult ExecC2C(
            IntPtr plan,
            ArrayView<Float2> @in,
            ArrayView<Float2> @out,
            CuFFTDirection direction) =>
            ExecC2C(
                plan,
                @in.LoadEffectiveAddressAsPtr(),
                @out.LoadEffectiveAddressAsPtr(),
                direction);

        /// <summary>
        /// Executes the plan on the given arrays - complex to real (single-precision).
        /// </summary>
        /// <param name="plan">The plan handle.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <returns>The error code.</returns>
        public CuFFTResult ExecC2R(
            IntPtr plan,
            ArrayView<(float Real, float Imaginary)> @in,
            ArrayView<float> @out) =>
            ExecC2R(
                plan,
                @in.LoadEffectiveAddressAsPtr(),
                @out.LoadEffectiveAddressAsPtr());

        /// <summary>
        /// Executes the plan on the given arrays - complex to real (single-precision).
        /// </summary>
        /// <param name="plan">The plan handle.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <returns>The error code.</returns>
        public CuFFTResult ExecC2R(
            IntPtr plan,
            ArrayView<Float2> @in,
            ArrayView<float> @out) =>
            ExecC2R(
                plan,
                @in.LoadEffectiveAddressAsPtr(),
                @out.LoadEffectiveAddressAsPtr());

        /// <summary>
        /// Executes the plan on the given arrays - real to complex (single-precision).
        /// </summary>
        /// <param name="plan">The plan handle.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <returns>The error code.</returns>
        public CuFFTResult ExecR2C(
            IntPtr plan,
            ArrayView<float> @in,
            ArrayView<(float Real, float Imaginary)> @out) =>
            ExecR2C(
                plan,
                @in.LoadEffectiveAddressAsPtr(),
                @out.LoadEffectiveAddressAsPtr());

        /// <summary>
        /// Executes the plan on the given arrays - real to complex (single-precision).
        /// </summary>
        /// <param name="plan">The plan handle.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <returns>The error code.</returns>
        public CuFFTResult ExecR2C(
            IntPtr plan,
            ArrayView<float> @in,
            ArrayView<Float2> @out) =>
            ExecR2C(
                plan,
                @in.LoadEffectiveAddressAsPtr(),
                @out.LoadEffectiveAddressAsPtr());

        /// <summary>
        /// Executes the plan on the given arrays - complex to complex (double-precision).
        /// </summary>
        /// <param name="plan">The plan handle.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="direction">The transform direction.</param>
        /// <returns>The error code.</returns>
        public CuFFTResult ExecZ2Z(
            IntPtr plan,
            ArrayView<Complex> @in,
            ArrayView<Complex> @out,
            CuFFTDirection direction) =>
            ExecZ2Z(
                plan,
                @in.LoadEffectiveAddressAsPtr(),
                @out.LoadEffectiveAddressAsPtr(),
                direction);

        /// <summary>
        /// Executes the plan on the given arrays - complex to complex (double-precision).
        /// </summary>
        /// <param name="plan">The plan handle.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="direction">The transform direction.</param>
        /// <returns>The error code.</returns>
        public CuFFTResult ExecZ2Z(
            IntPtr plan,
            ArrayView<(double Real, double Imaginary)> @in,
            ArrayView<(double Real, double Imaginary)> @out,
            CuFFTDirection direction) =>
            ExecZ2Z(
                plan,
                @in.LoadEffectiveAddressAsPtr(),
                @out.LoadEffectiveAddressAsPtr(),
                direction);

        /// <summary>
        /// Executes the plan on the given arrays - complex to complex (double-precision).
        /// </summary>
        /// <param name="plan">The plan handle.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <param name="direction">The transform direction.</param>
        /// <returns>The error code.</returns>
        public CuFFTResult ExecZ2Z(
            IntPtr plan,
            ArrayView<Double2> @in,
            ArrayView<Double2> @out,
            CuFFTDirection direction) =>
            ExecZ2Z(
                plan,
                @in.LoadEffectiveAddressAsPtr(),
                @out.LoadEffectiveAddressAsPtr(),
                direction);

        /// <summary>
        /// Executes the plan on the given arrays - complex to real (double-precision).
        /// </summary>
        /// <param name="plan">The plan handle.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <returns>The error code.</returns>
        public CuFFTResult ExecZ2D(
            IntPtr plan,
            ArrayView<Complex> @in,
            ArrayView<double> @out) =>
            ExecZ2D(
                plan,
                @in.LoadEffectiveAddressAsPtr(),
                @out.LoadEffectiveAddressAsPtr());

        /// <summary>
        /// Executes the plan on the given arrays - complex to real (double-precision).
        /// </summary>
        /// <param name="plan">The plan handle.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <returns>The error code.</returns>
        public CuFFTResult ExecZ2D(
            IntPtr plan,
            ArrayView<(double Real, double Imaginary)> @in,
            ArrayView<double> @out) =>
            ExecZ2D(
                plan,
                @in.LoadEffectiveAddressAsPtr(),
                @out.LoadEffectiveAddressAsPtr());

        /// <summary>
        /// Executes the plan on the given arrays - complex to real (double-precision).
        /// </summary>
        /// <param name="plan">The plan handle.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <returns>The error code.</returns>
        public CuFFTResult ExecZ2D(
            IntPtr plan,
            ArrayView<Double2> @in,
            ArrayView<double> @out) =>
            ExecZ2D(
                plan,
                @in.LoadEffectiveAddressAsPtr(),
                @out.LoadEffectiveAddressAsPtr());

        /// <summary>
        /// Executes the plan on the given arrays - real to complex (double-precision).
        /// </summary>
        /// <param name="plan">The plan handle.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <returns>The error code.</returns>
        public CuFFTResult ExecD2Z(
            IntPtr plan,
            ArrayView<double> @in,
            ArrayView<Complex> @out) =>
            ExecD2Z(
                plan,
                @in.LoadEffectiveAddressAsPtr(),
                @out.LoadEffectiveAddressAsPtr());

        /// <summary>
        /// Executes the plan on the given arrays - real to complex (double-precision).
        /// </summary>
        /// <param name="plan">The plan handle.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <returns>The error code.</returns>
        public CuFFTResult ExecD2Z(
            IntPtr plan,
            ArrayView<double> @in,
            ArrayView<(double Real, double Imaginary)> @out) =>
            ExecD2Z(
                plan,
                @in.LoadEffectiveAddressAsPtr(),
                @out.LoadEffectiveAddressAsPtr());

        /// <summary>
        /// Executes the plan on the given arrays - real to complex (double-precision).
        /// </summary>
        /// <param name="plan">The plan handle.</param>
        /// <param name="in">The input array.</param>
        /// <param name="out">The output array.</param>
        /// <returns>The error code.</returns>
        public CuFFTResult ExecD2Z(
            IntPtr plan,
            ArrayView<double> @in,
            ArrayView<Double2> @out) =>
            ExecD2Z(
                plan,
                @in.LoadEffectiveAddressAsPtr(),
                @out.LoadEffectiveAddressAsPtr());

        #endregion
    }
}