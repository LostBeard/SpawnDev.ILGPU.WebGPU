// ---------------------------------------------------------------------------------------
//                                   ILGPU Algorithms
//                        Copyright (c) 2020-2021 ILGPU Project
//                                    www.ilgpu.net
//
// File: CuBlasMethodsLevel1.tt/CuBlasMethodsLevel1.cs
//
// This file is part of ILGPU and is distributed under the University of Illinois Open
// Source License. See LICENSE.txt for details.
// ---------------------------------------------------------------------------------------

// ---------------------------------------------------------------------------------------
//                                   ILGPU Algorithms
//                        Copyright (c) 2020-2024 ILGPU Project
//                                    www.ilgpu.net
//
// File: CuBlasMappings.ttinclude
//
// This file is part of ILGPU and is distributed under the University of Illinois Open
// Source License. See LICENSE.txt for details.
// ---------------------------------------------------------------------------------------


using ILGPU.Util;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// disable: max_line_length

namespace ILGPU.Runtime.Cuda
{
    partial class CuBlas<TPointerModeHandler>
    {
        /// <summary>
        /// Performs the CuBlas Amax operation.
        /// </summary>
        /// <param name="input">The input view.</param>
        /// <returns>The computed value.</returns>
        public unsafe int Amax(ArrayView1D<float, Stride1D.General> input)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            int result;
            CuBlasException.ThrowIfFailed(
                API.Isamax_v2(
                    Handle,
                    input.IntLength,
                    LoadCuBlasAddress(input.BaseView),
                    input.Stride.XStride,
                    &result));
            return result;
        }

        /// <summary>
        /// Performs the CuBlas Amax operation.
        /// </summary>
        /// <param name="input">The input view.</param>
        /// <param name="output">The output view.</param>
        public unsafe void Amax(
            ArrayView1D<float, Stride1D.General> input,
            ArrayView<int> output)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Isamax_v2(
                    Handle,
                    input.IntLength,
                    LoadCuBlasAddress(input.BaseView),
                    input.Stride.XStride,
                    LoadCuBlasAddress(output)));
        }

        /// <summary>
        /// Performs the CuBlas Amax operation.
        /// </summary>
        /// <param name="input">The input view.</param>
        /// <returns>The computed value.</returns>
        public unsafe int Amax(ArrayView1D<double, Stride1D.General> input)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            int result;
            CuBlasException.ThrowIfFailed(
                API.Idamax_v2(
                    Handle,
                    input.IntLength,
                    LoadCuBlasAddress(input.BaseView),
                    input.Stride.XStride,
                    &result));
            return result;
        }

        /// <summary>
        /// Performs the CuBlas Amax operation.
        /// </summary>
        /// <param name="input">The input view.</param>
        /// <param name="output">The output view.</param>
        public unsafe void Amax(
            ArrayView1D<double, Stride1D.General> input,
            ArrayView<int> output)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Idamax_v2(
                    Handle,
                    input.IntLength,
                    LoadCuBlasAddress(input.BaseView),
                    input.Stride.XStride,
                    LoadCuBlasAddress(output)));
        }

        /// <summary>
        /// Performs the CuBlas Amax operation.
        /// </summary>
        /// <param name="input">The input view.</param>
        /// <returns>The computed value.</returns>
        public unsafe int Amax(ArrayView1D<Float2, Stride1D.General> input)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            int result;
            CuBlasException.ThrowIfFailed(
                API.Icamax_v2(
                    Handle,
                    input.IntLength,
                    LoadCuBlasAddress(input.BaseView),
                    input.Stride.XStride,
                    &result));
            return result;
        }

        /// <summary>
        /// Performs the CuBlas Amax operation.
        /// </summary>
        /// <param name="input">The input view.</param>
        /// <param name="output">The output view.</param>
        public unsafe void Amax(
            ArrayView1D<Float2, Stride1D.General> input,
            ArrayView<int> output)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Icamax_v2(
                    Handle,
                    input.IntLength,
                    LoadCuBlasAddress(input.BaseView),
                    input.Stride.XStride,
                    LoadCuBlasAddress(output)));
        }

        /// <summary>
        /// Performs the CuBlas Amax operation.
        /// </summary>
        /// <param name="input">The input view.</param>
        /// <returns>The computed value.</returns>
        public unsafe int Amax(ArrayView1D<Double2, Stride1D.General> input)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            int result;
            CuBlasException.ThrowIfFailed(
                API.Izamax_v2(
                    Handle,
                    input.IntLength,
                    LoadCuBlasAddress(input.BaseView),
                    input.Stride.XStride,
                    &result));
            return result;
        }

        /// <summary>
        /// Performs the CuBlas Amax operation.
        /// </summary>
        /// <param name="input">The input view.</param>
        /// <param name="output">The output view.</param>
        public unsafe void Amax(
            ArrayView1D<Double2, Stride1D.General> input,
            ArrayView<int> output)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Izamax_v2(
                    Handle,
                    input.IntLength,
                    LoadCuBlasAddress(input.BaseView),
                    input.Stride.XStride,
                    LoadCuBlasAddress(output)));
        }

        /// <summary>
        /// Performs the CuBlas Amin operation.
        /// </summary>
        /// <param name="input">The input view.</param>
        /// <returns>The computed value.</returns>
        public unsafe int Amin(ArrayView1D<float, Stride1D.General> input)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            int result;
            CuBlasException.ThrowIfFailed(
                API.Isamin_v2(
                    Handle,
                    input.IntLength,
                    LoadCuBlasAddress(input.BaseView),
                    input.Stride.XStride,
                    &result));
            return result;
        }

        /// <summary>
        /// Performs the CuBlas Amin operation.
        /// </summary>
        /// <param name="input">The input view.</param>
        /// <param name="output">The output view.</param>
        public unsafe void Amin(
            ArrayView1D<float, Stride1D.General> input,
            ArrayView<int> output)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Isamin_v2(
                    Handle,
                    input.IntLength,
                    LoadCuBlasAddress(input.BaseView),
                    input.Stride.XStride,
                    LoadCuBlasAddress(output)));
        }

        /// <summary>
        /// Performs the CuBlas Amin operation.
        /// </summary>
        /// <param name="input">The input view.</param>
        /// <returns>The computed value.</returns>
        public unsafe int Amin(ArrayView1D<double, Stride1D.General> input)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            int result;
            CuBlasException.ThrowIfFailed(
                API.Idamin_v2(
                    Handle,
                    input.IntLength,
                    LoadCuBlasAddress(input.BaseView),
                    input.Stride.XStride,
                    &result));
            return result;
        }

        /// <summary>
        /// Performs the CuBlas Amin operation.
        /// </summary>
        /// <param name="input">The input view.</param>
        /// <param name="output">The output view.</param>
        public unsafe void Amin(
            ArrayView1D<double, Stride1D.General> input,
            ArrayView<int> output)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Idamin_v2(
                    Handle,
                    input.IntLength,
                    LoadCuBlasAddress(input.BaseView),
                    input.Stride.XStride,
                    LoadCuBlasAddress(output)));
        }

        /// <summary>
        /// Performs the CuBlas Amin operation.
        /// </summary>
        /// <param name="input">The input view.</param>
        /// <returns>The computed value.</returns>
        public unsafe int Amin(ArrayView1D<Float2, Stride1D.General> input)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            int result;
            CuBlasException.ThrowIfFailed(
                API.Icamin_v2(
                    Handle,
                    input.IntLength,
                    LoadCuBlasAddress(input.BaseView),
                    input.Stride.XStride,
                    &result));
            return result;
        }

        /// <summary>
        /// Performs the CuBlas Amin operation.
        /// </summary>
        /// <param name="input">The input view.</param>
        /// <param name="output">The output view.</param>
        public unsafe void Amin(
            ArrayView1D<Float2, Stride1D.General> input,
            ArrayView<int> output)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Icamin_v2(
                    Handle,
                    input.IntLength,
                    LoadCuBlasAddress(input.BaseView),
                    input.Stride.XStride,
                    LoadCuBlasAddress(output)));
        }

        /// <summary>
        /// Performs the CuBlas Amin operation.
        /// </summary>
        /// <param name="input">The input view.</param>
        /// <returns>The computed value.</returns>
        public unsafe int Amin(ArrayView1D<Double2, Stride1D.General> input)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            int result;
            CuBlasException.ThrowIfFailed(
                API.Izamin_v2(
                    Handle,
                    input.IntLength,
                    LoadCuBlasAddress(input.BaseView),
                    input.Stride.XStride,
                    &result));
            return result;
        }

        /// <summary>
        /// Performs the CuBlas Amin operation.
        /// </summary>
        /// <param name="input">The input view.</param>
        /// <param name="output">The output view.</param>
        public unsafe void Amin(
            ArrayView1D<Double2, Stride1D.General> input,
            ArrayView<int> output)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Izamin_v2(
                    Handle,
                    input.IntLength,
                    LoadCuBlasAddress(input.BaseView),
                    input.Stride.XStride,
                    LoadCuBlasAddress(output)));
        }


        /// <summary>
        /// Performs the CuBlas Asum operation.
        /// </summary>
        /// <param name="input">The input view.</param>
        /// <returns>The computed value.</returns>
        public unsafe float Asum(
            ArrayView1D<float, Stride1D.General> input)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            float result = default;
            CuBlasException.ThrowIfFailed(
                API.Sasum_v2(
                    Handle,
                    input.IntLength,
                    LoadCuBlasAddress(input.BaseView),
                    input.Stride.XStride,
                    Unsafe.AsPointer(ref result)));
            return result;
        }

        /// <summary>
        /// Performs the CuBlas Asum operation.
        /// </summary>
        /// <param name="input">The input view.</param>
        /// <param name="output">The output view.</param>
        public unsafe void Asum(
            ArrayView1D<float, Stride1D.General> input,
            ArrayView<float> output)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Sasum_v2(
                    Handle,
                    input.IntLength,
                    LoadCuBlasAddress(input.BaseView),
                    input.Stride.XStride,
                    LoadCuBlasAddress(output)));
        }

        /// <summary>
        /// Performs the CuBlas Asum operation.
        /// </summary>
        /// <param name="input">The input view.</param>
        /// <returns>The computed value.</returns>
        public unsafe double Asum(
            ArrayView1D<double, Stride1D.General> input)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            double result = default;
            CuBlasException.ThrowIfFailed(
                API.Dasum_v2(
                    Handle,
                    input.IntLength,
                    LoadCuBlasAddress(input.BaseView),
                    input.Stride.XStride,
                    Unsafe.AsPointer(ref result)));
            return result;
        }

        /// <summary>
        /// Performs the CuBlas Asum operation.
        /// </summary>
        /// <param name="input">The input view.</param>
        /// <param name="output">The output view.</param>
        public unsafe void Asum(
            ArrayView1D<double, Stride1D.General> input,
            ArrayView<double> output)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Dasum_v2(
                    Handle,
                    input.IntLength,
                    LoadCuBlasAddress(input.BaseView),
                    input.Stride.XStride,
                    LoadCuBlasAddress(output)));
        }

        /// <summary>
        /// Performs the CuBlas Asum operation.
        /// </summary>
        /// <param name="input">The input view.</param>
        /// <returns>The computed value.</returns>
        public unsafe Float2 Asum(
            ArrayView1D<Float2, Stride1D.General> input)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            Float2 result = default;
            CuBlasException.ThrowIfFailed(
                API.Scasum_v2(
                    Handle,
                    input.IntLength,
                    LoadCuBlasAddress(input.BaseView),
                    input.Stride.XStride,
                    Unsafe.AsPointer(ref result)));
            return result;
        }

        /// <summary>
        /// Performs the CuBlas Asum operation.
        /// </summary>
        /// <param name="input">The input view.</param>
        /// <param name="output">The output view.</param>
        public unsafe void Asum(
            ArrayView1D<Float2, Stride1D.General> input,
            ArrayView<Float2> output)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Scasum_v2(
                    Handle,
                    input.IntLength,
                    LoadCuBlasAddress(input.BaseView),
                    input.Stride.XStride,
                    LoadCuBlasAddress(output)));
        }

        /// <summary>
        /// Performs the CuBlas Asum operation.
        /// </summary>
        /// <param name="input">The input view.</param>
        /// <returns>The computed value.</returns>
        public unsafe Double2 Asum(
            ArrayView1D<Double2, Stride1D.General> input)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            Double2 result = default;
            CuBlasException.ThrowIfFailed(
                API.Dzasum_v2(
                    Handle,
                    input.IntLength,
                    LoadCuBlasAddress(input.BaseView),
                    input.Stride.XStride,
                    Unsafe.AsPointer(ref result)));
            return result;
        }

        /// <summary>
        /// Performs the CuBlas Asum operation.
        /// </summary>
        /// <param name="input">The input view.</param>
        /// <param name="output">The output view.</param>
        public unsafe void Asum(
            ArrayView1D<Double2, Stride1D.General> input,
            ArrayView<Double2> output)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Dzasum_v2(
                    Handle,
                    input.IntLength,
                    LoadCuBlasAddress(input.BaseView),
                    input.Stride.XStride,
                    LoadCuBlasAddress(output)));
        }

        /// <summary>
        /// Performs the CuBlas Nrm2 operation.
        /// </summary>
        /// <param name="input">The input view.</param>
        /// <returns>The computed value.</returns>
        public unsafe float Nrm2(
            ArrayView1D<float, Stride1D.General> input)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            float result = default;
            CuBlasException.ThrowIfFailed(
                API.Snrm2_v2(
                    Handle,
                    input.IntLength,
                    LoadCuBlasAddress(input.BaseView),
                    input.Stride.XStride,
                    Unsafe.AsPointer(ref result)));
            return result;
        }

        /// <summary>
        /// Performs the CuBlas Nrm2 operation.
        /// </summary>
        /// <param name="input">The input view.</param>
        /// <param name="output">The output view.</param>
        public unsafe void Nrm2(
            ArrayView1D<float, Stride1D.General> input,
            ArrayView<float> output)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Snrm2_v2(
                    Handle,
                    input.IntLength,
                    LoadCuBlasAddress(input.BaseView),
                    input.Stride.XStride,
                    LoadCuBlasAddress(output)));
        }

        /// <summary>
        /// Performs the CuBlas Nrm2 operation.
        /// </summary>
        /// <param name="input">The input view.</param>
        /// <returns>The computed value.</returns>
        public unsafe double Nrm2(
            ArrayView1D<double, Stride1D.General> input)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            double result = default;
            CuBlasException.ThrowIfFailed(
                API.Dnrm2_v2(
                    Handle,
                    input.IntLength,
                    LoadCuBlasAddress(input.BaseView),
                    input.Stride.XStride,
                    Unsafe.AsPointer(ref result)));
            return result;
        }

        /// <summary>
        /// Performs the CuBlas Nrm2 operation.
        /// </summary>
        /// <param name="input">The input view.</param>
        /// <param name="output">The output view.</param>
        public unsafe void Nrm2(
            ArrayView1D<double, Stride1D.General> input,
            ArrayView<double> output)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Dnrm2_v2(
                    Handle,
                    input.IntLength,
                    LoadCuBlasAddress(input.BaseView),
                    input.Stride.XStride,
                    LoadCuBlasAddress(output)));
        }

        /// <summary>
        /// Performs the CuBlas Nrm2 operation.
        /// </summary>
        /// <param name="input">The input view.</param>
        /// <returns>The computed value.</returns>
        public unsafe Float2 Nrm2(
            ArrayView1D<Float2, Stride1D.General> input)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            Float2 result = default;
            CuBlasException.ThrowIfFailed(
                API.Scnrm2_v2(
                    Handle,
                    input.IntLength,
                    LoadCuBlasAddress(input.BaseView),
                    input.Stride.XStride,
                    Unsafe.AsPointer(ref result)));
            return result;
        }

        /// <summary>
        /// Performs the CuBlas Nrm2 operation.
        /// </summary>
        /// <param name="input">The input view.</param>
        /// <param name="output">The output view.</param>
        public unsafe void Nrm2(
            ArrayView1D<Float2, Stride1D.General> input,
            ArrayView<Float2> output)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Scnrm2_v2(
                    Handle,
                    input.IntLength,
                    LoadCuBlasAddress(input.BaseView),
                    input.Stride.XStride,
                    LoadCuBlasAddress(output)));
        }

        /// <summary>
        /// Performs the CuBlas Nrm2 operation.
        /// </summary>
        /// <param name="input">The input view.</param>
        /// <returns>The computed value.</returns>
        public unsafe Double2 Nrm2(
            ArrayView1D<Double2, Stride1D.General> input)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            Double2 result = default;
            CuBlasException.ThrowIfFailed(
                API.Dznrm2_v2(
                    Handle,
                    input.IntLength,
                    LoadCuBlasAddress(input.BaseView),
                    input.Stride.XStride,
                    Unsafe.AsPointer(ref result)));
            return result;
        }

        /// <summary>
        /// Performs the CuBlas Nrm2 operation.
        /// </summary>
        /// <param name="input">The input view.</param>
        /// <param name="output">The output view.</param>
        public unsafe void Nrm2(
            ArrayView1D<Double2, Stride1D.General> input,
            ArrayView<Double2> output)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Dznrm2_v2(
                    Handle,
                    input.IntLength,
                    LoadCuBlasAddress(input.BaseView),
                    input.Stride.XStride,
                    LoadCuBlasAddress(output)));
        }


        /// <summary>
        /// Performs the CuBlas Axpy operation.
        /// </summary>
        /// <param name="alpha">The alpha value.</param>
        /// <param name="x">The x vector.</param>
        /// <param name="y">The y vector.</param>
        public unsafe void Axpy(
            float alpha,
            ArrayView1D<float, Stride1D.General> x,
            ArrayView1D<float, Stride1D.General> y)
        {
            Debug.Assert(x.Length == y.Length, "Invalid length");
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Saxpy_v2(
                    Handle,
                    x.IntLength,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Axpy operation.
        /// </summary>
        /// <param name="alpha">The alpha value.</param>
        /// <param name="x">The x vector.</param>
        /// <param name="y">The y vector.</param>
        public unsafe void Axpy(
            ArrayView<float> alpha,
            ArrayView1D<float, Stride1D.General> x,
            ArrayView1D<float, Stride1D.General> y)
        {
            Debug.Assert(x.Length == y.Length, "Invalid length");
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Saxpy_v2(
                    Handle,
                    x.IntLength,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Axpy operation.
        /// </summary>
        /// <param name="alpha">The alpha value.</param>
        /// <param name="x">The x vector.</param>
        /// <param name="y">The y vector.</param>
        public unsafe void Axpy(
            double alpha,
            ArrayView1D<double, Stride1D.General> x,
            ArrayView1D<double, Stride1D.General> y)
        {
            Debug.Assert(x.Length == y.Length, "Invalid length");
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Daxpy_v2(
                    Handle,
                    x.IntLength,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Axpy operation.
        /// </summary>
        /// <param name="alpha">The alpha value.</param>
        /// <param name="x">The x vector.</param>
        /// <param name="y">The y vector.</param>
        public unsafe void Axpy(
            ArrayView<double> alpha,
            ArrayView1D<double, Stride1D.General> x,
            ArrayView1D<double, Stride1D.General> y)
        {
            Debug.Assert(x.Length == y.Length, "Invalid length");
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Daxpy_v2(
                    Handle,
                    x.IntLength,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Axpy operation.
        /// </summary>
        /// <param name="alpha">The alpha value.</param>
        /// <param name="x">The x vector.</param>
        /// <param name="y">The y vector.</param>
        public unsafe void Axpy(
            Float2 alpha,
            ArrayView1D<Float2, Stride1D.General> x,
            ArrayView1D<Float2, Stride1D.General> y)
        {
            Debug.Assert(x.Length == y.Length, "Invalid length");
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Caxpy_v2(
                    Handle,
                    x.IntLength,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Axpy operation.
        /// </summary>
        /// <param name="alpha">The alpha value.</param>
        /// <param name="x">The x vector.</param>
        /// <param name="y">The y vector.</param>
        public unsafe void Axpy(
            ArrayView<Float2> alpha,
            ArrayView1D<Float2, Stride1D.General> x,
            ArrayView1D<Float2, Stride1D.General> y)
        {
            Debug.Assert(x.Length == y.Length, "Invalid length");
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Caxpy_v2(
                    Handle,
                    x.IntLength,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Axpy operation.
        /// </summary>
        /// <param name="alpha">The alpha value.</param>
        /// <param name="x">The x vector.</param>
        /// <param name="y">The y vector.</param>
        public unsafe void Axpy(
            Double2 alpha,
            ArrayView1D<Double2, Stride1D.General> x,
            ArrayView1D<Double2, Stride1D.General> y)
        {
            Debug.Assert(x.Length == y.Length, "Invalid length");
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Zaxpy_v2(
                    Handle,
                    x.IntLength,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Axpy operation.
        /// </summary>
        /// <param name="alpha">The alpha value.</param>
        /// <param name="x">The x vector.</param>
        /// <param name="y">The y vector.</param>
        public unsafe void Axpy(
            ArrayView<Double2> alpha,
            ArrayView1D<Double2, Stride1D.General> x,
            ArrayView1D<Double2, Stride1D.General> y)
        {
            Debug.Assert(x.Length == y.Length, "Invalid length");
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Zaxpy_v2(
                    Handle,
                    x.IntLength,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }


        /// <summary>
        /// Performs the CuBlas Dot operation.
        /// </summary>
        /// <param name="x">The x vector.</param>
        /// <param name="y">The y vector.</param>
        /// <returns>The computed value.</returns>
        public unsafe float Dot(
            ArrayView1D<float, Stride1D.General> x,
            ArrayView1D<float, Stride1D.General> y)
        {
            Debug.Assert(x.Length == y.Length, "Invalid length");
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            float result = default;
            CuBlasException.ThrowIfFailed(
                API.Sdot_v2(
                    Handle,
                    x.IntLength,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride,
                    Unsafe.AsPointer(ref result)));
            return result;
        }

        /// <summary>
        /// Performs the CuBlas Dot operation.
        /// </summary>
        /// <param name="x">The x vector.</param>
        /// <param name="y">The y vector.</param>
        /// <param name="output">The output view.</param>
        public unsafe void Dot(
            ArrayView1D<float, Stride1D.General> x,
            ArrayView1D<float, Stride1D.General> y,
            ArrayView<float> output)
        {
            Debug.Assert(x.Length == y.Length, "Invalid length");
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Sdot_v2(
                    Handle,
                    x.IntLength,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride,
                    LoadCuBlasAddress(output)));
        }

        /// <summary>
        /// Performs the CuBlas Dot operation.
        /// </summary>
        /// <param name="x">The x vector.</param>
        /// <param name="y">The y vector.</param>
        /// <returns>The computed value.</returns>
        public unsafe double Dot(
            ArrayView1D<double, Stride1D.General> x,
            ArrayView1D<double, Stride1D.General> y)
        {
            Debug.Assert(x.Length == y.Length, "Invalid length");
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            double result = default;
            CuBlasException.ThrowIfFailed(
                API.Ddot_v2(
                    Handle,
                    x.IntLength,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride,
                    Unsafe.AsPointer(ref result)));
            return result;
        }

        /// <summary>
        /// Performs the CuBlas Dot operation.
        /// </summary>
        /// <param name="x">The x vector.</param>
        /// <param name="y">The y vector.</param>
        /// <param name="output">The output view.</param>
        public unsafe void Dot(
            ArrayView1D<double, Stride1D.General> x,
            ArrayView1D<double, Stride1D.General> y,
            ArrayView<double> output)
        {
            Debug.Assert(x.Length == y.Length, "Invalid length");
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Ddot_v2(
                    Handle,
                    x.IntLength,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride,
                    LoadCuBlasAddress(output)));
        }

        /// <summary>
        /// Performs the CuBlas Dot operation.
        /// </summary>
        /// <param name="x">The x vector.</param>
        /// <param name="y">The y vector.</param>
        /// <returns>The computed value.</returns>
        public unsafe Float2 Dot(
            ArrayView1D<Float2, Stride1D.General> x,
            ArrayView1D<Float2, Stride1D.General> y)
        {
            Debug.Assert(x.Length == y.Length, "Invalid length");
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            Float2 result = default;
            CuBlasException.ThrowIfFailed(
                API.Cdotu_v2(
                    Handle,
                    x.IntLength,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride,
                    Unsafe.AsPointer(ref result)));
            return result;
        }

        /// <summary>
        /// Performs the CuBlas Dot operation.
        /// </summary>
        /// <param name="x">The x vector.</param>
        /// <param name="y">The y vector.</param>
        /// <param name="output">The output view.</param>
        public unsafe void Dot(
            ArrayView1D<Float2, Stride1D.General> x,
            ArrayView1D<Float2, Stride1D.General> y,
            ArrayView<Float2> output)
        {
            Debug.Assert(x.Length == y.Length, "Invalid length");
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Cdotu_v2(
                    Handle,
                    x.IntLength,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride,
                    LoadCuBlasAddress(output)));
        }

        /// <summary>
        /// Performs the CuBlas Dot operation.
        /// </summary>
        /// <param name="x">The x vector.</param>
        /// <param name="y">The y vector.</param>
        /// <returns>The computed value.</returns>
        public unsafe Double2 Dot(
            ArrayView1D<Double2, Stride1D.General> x,
            ArrayView1D<Double2, Stride1D.General> y)
        {
            Debug.Assert(x.Length == y.Length, "Invalid length");
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            Double2 result = default;
            CuBlasException.ThrowIfFailed(
                API.Cdotc_v2(
                    Handle,
                    x.IntLength,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride,
                    Unsafe.AsPointer(ref result)));
            return result;
        }

        /// <summary>
        /// Performs the CuBlas Dot operation.
        /// </summary>
        /// <param name="x">The x vector.</param>
        /// <param name="y">The y vector.</param>
        /// <param name="output">The output view.</param>
        public unsafe void Dot(
            ArrayView1D<Double2, Stride1D.General> x,
            ArrayView1D<Double2, Stride1D.General> y,
            ArrayView<Double2> output)
        {
            Debug.Assert(x.Length == y.Length, "Invalid length");
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Cdotc_v2(
                    Handle,
                    x.IntLength,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride,
                    LoadCuBlasAddress(output)));
        }


        /// <summary>
        /// Performs the CuBlas Rot operation.
        /// </summary>
        /// <param name="x">The x vector.</param>
        /// <param name="y">The y vector.</param>
        /// <param name="c">The cos angle.</param>
        /// <param name="s">The sin angle.</param>
        public unsafe void Rot(
            ArrayView1D<float, Stride1D.General> x,
            ArrayView1D<float, Stride1D.General> y,
            float c,
            float s)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Srot_v2(
                    Handle,
                    x.IntLength,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride,
                    Unsafe.AsPointer(ref c),
                    Unsafe.AsPointer(ref s)));
        }

        /// <summary>
        /// Performs the CuBlas Rot operation.
        /// </summary>
        /// <param name="x">The x vector.</param>
        /// <param name="y">The y vector.</param>
        /// <param name="c">The cos angle.</param>
        /// <param name="s">The sin angle.</param>
        public unsafe void Rot(
            ArrayView1D<float, Stride1D.General> x,
            ArrayView1D<float, Stride1D.General> y,
            ArrayView<float> c,
            ArrayView<float> s)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Srot_v2(
                    Handle,
                    x.IntLength,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride,
                    LoadCuBlasAddress(c),
                    LoadCuBlasAddress(s)));
        }

        /// <summary>
        /// Performs the CuBlas Rot operation.
        /// </summary>
        /// <param name="x">The x vector.</param>
        /// <param name="y">The y vector.</param>
        /// <param name="c">The cos angle.</param>
        /// <param name="s">The sin angle.</param>
        public unsafe void Rot(
            ArrayView1D<double, Stride1D.General> x,
            ArrayView1D<double, Stride1D.General> y,
            double c,
            double s)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Drot_v2(
                    Handle,
                    x.IntLength,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride,
                    Unsafe.AsPointer(ref c),
                    Unsafe.AsPointer(ref s)));
        }

        /// <summary>
        /// Performs the CuBlas Rot operation.
        /// </summary>
        /// <param name="x">The x vector.</param>
        /// <param name="y">The y vector.</param>
        /// <param name="c">The cos angle.</param>
        /// <param name="s">The sin angle.</param>
        public unsafe void Rot(
            ArrayView1D<double, Stride1D.General> x,
            ArrayView1D<double, Stride1D.General> y,
            ArrayView<double> c,
            ArrayView<double> s)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Drot_v2(
                    Handle,
                    x.IntLength,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride,
                    LoadCuBlasAddress(c),
                    LoadCuBlasAddress(s)));
        }

        /// <summary>
        /// Performs the CuBlas Rot operation.
        /// </summary>
        /// <param name="x">The x vector.</param>
        /// <param name="y">The y vector.</param>
        /// <param name="c">The cos angle.</param>
        /// <param name="s">The sin angle.</param>
        public unsafe void Rot(
            ArrayView1D<Float2, Stride1D.General> x,
            ArrayView1D<Float2, Stride1D.General> y,
            Float2 c,
            Float2 s)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Csrot_v2(
                    Handle,
                    x.IntLength,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride,
                    Unsafe.AsPointer(ref c),
                    Unsafe.AsPointer(ref s)));
        }

        /// <summary>
        /// Performs the CuBlas Rot operation.
        /// </summary>
        /// <param name="x">The x vector.</param>
        /// <param name="y">The y vector.</param>
        /// <param name="c">The cos angle.</param>
        /// <param name="s">The sin angle.</param>
        public unsafe void Rot(
            ArrayView1D<Float2, Stride1D.General> x,
            ArrayView1D<Float2, Stride1D.General> y,
            ArrayView<Float2> c,
            ArrayView<Float2> s)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Csrot_v2(
                    Handle,
                    x.IntLength,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride,
                    LoadCuBlasAddress(c),
                    LoadCuBlasAddress(s)));
        }

        /// <summary>
        /// Performs the CuBlas Rot operation.
        /// </summary>
        /// <param name="x">The x vector.</param>
        /// <param name="y">The y vector.</param>
        /// <param name="c">The cos angle.</param>
        /// <param name="s">The sin angle.</param>
        public unsafe void Rot(
            ArrayView1D<Double2, Stride1D.General> x,
            ArrayView1D<Double2, Stride1D.General> y,
            Double2 c,
            Double2 s)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Zdrot_v2(
                    Handle,
                    x.IntLength,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride,
                    Unsafe.AsPointer(ref c),
                    Unsafe.AsPointer(ref s)));
        }

        /// <summary>
        /// Performs the CuBlas Rot operation.
        /// </summary>
        /// <param name="x">The x vector.</param>
        /// <param name="y">The y vector.</param>
        /// <param name="c">The cos angle.</param>
        /// <param name="s">The sin angle.</param>
        public unsafe void Rot(
            ArrayView1D<Double2, Stride1D.General> x,
            ArrayView1D<Double2, Stride1D.General> y,
            ArrayView<Double2> c,
            ArrayView<Double2> s)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Zdrot_v2(
                    Handle,
                    x.IntLength,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride,
                    LoadCuBlasAddress(c),
                    LoadCuBlasAddress(s)));
        }


        /// <summary>
        /// Performs the CuBlas RotG operation.
        /// </summary>
        /// <param name="a">The a value.</param>
        /// <param name="b">The b value.</param>
        /// <param name="c">The cos angle.</param>
        /// <param name="s">The sin angle.</param>
        public unsafe void RotG(
            float a,
            float b,
            float c,
            float s)
        {
            EnsureAcceleratorBinding();

            CuBlasException.ThrowIfFailed(
                API.Srotg_v2(
                    Handle,
                    Unsafe.AsPointer(ref a),
                    Unsafe.AsPointer(ref b),
                    Unsafe.AsPointer(ref c),
                    Unsafe.AsPointer(ref s)));
        }

        /// <summary>
        /// Performs the CuBlas RotG operation.
        /// </summary>
        /// <param name="a">The a value.</param>
        /// <param name="b">The b value.</param>
        /// <param name="c">The cos angle.</param>
        /// <param name="s">The sin angle.</param>
        public unsafe void RotG(
            ArrayView<float> a,
            ArrayView<float> b,
            ArrayView<float> c,
            ArrayView<float> s)
        {
            EnsureAcceleratorBinding();

            CuBlasException.ThrowIfFailed(
                API.Srotg_v2(
                    Handle,
                    LoadCuBlasAddress(a),
                    LoadCuBlasAddress(b),
                    LoadCuBlasAddress(c),
                    LoadCuBlasAddress(s)));
        }

        /// <summary>
        /// Performs the CuBlas RotG operation.
        /// </summary>
        /// <param name="a">The a value.</param>
        /// <param name="b">The b value.</param>
        /// <param name="c">The cos angle.</param>
        /// <param name="s">The sin angle.</param>
        public unsafe void RotG(
            double a,
            double b,
            double c,
            double s)
        {
            EnsureAcceleratorBinding();

            CuBlasException.ThrowIfFailed(
                API.Drotg_v2(
                    Handle,
                    Unsafe.AsPointer(ref a),
                    Unsafe.AsPointer(ref b),
                    Unsafe.AsPointer(ref c),
                    Unsafe.AsPointer(ref s)));
        }

        /// <summary>
        /// Performs the CuBlas RotG operation.
        /// </summary>
        /// <param name="a">The a value.</param>
        /// <param name="b">The b value.</param>
        /// <param name="c">The cos angle.</param>
        /// <param name="s">The sin angle.</param>
        public unsafe void RotG(
            ArrayView<double> a,
            ArrayView<double> b,
            ArrayView<double> c,
            ArrayView<double> s)
        {
            EnsureAcceleratorBinding();

            CuBlasException.ThrowIfFailed(
                API.Drotg_v2(
                    Handle,
                    LoadCuBlasAddress(a),
                    LoadCuBlasAddress(b),
                    LoadCuBlasAddress(c),
                    LoadCuBlasAddress(s)));
        }

        /// <summary>
        /// Performs the CuBlas RotG operation.
        /// </summary>
        /// <param name="a">The a value.</param>
        /// <param name="b">The b value.</param>
        /// <param name="c">The cos angle.</param>
        /// <param name="s">The sin angle.</param>
        public unsafe void RotG(
            Float2 a,
            Float2 b,
            float c,
            Float2 s)
        {
            EnsureAcceleratorBinding();

            CuBlasException.ThrowIfFailed(
                API.Crotg_v2(
                    Handle,
                    Unsafe.AsPointer(ref a),
                    Unsafe.AsPointer(ref b),
                    Unsafe.AsPointer(ref c),
                    Unsafe.AsPointer(ref s)));
        }

        /// <summary>
        /// Performs the CuBlas RotG operation.
        /// </summary>
        /// <param name="a">The a value.</param>
        /// <param name="b">The b value.</param>
        /// <param name="c">The cos angle.</param>
        /// <param name="s">The sin angle.</param>
        public unsafe void RotG(
            ArrayView<Float2> a,
            ArrayView<Float2> b,
            ArrayView<float> c,
            ArrayView<Float2> s)
        {
            EnsureAcceleratorBinding();

            CuBlasException.ThrowIfFailed(
                API.Crotg_v2(
                    Handle,
                    LoadCuBlasAddress(a),
                    LoadCuBlasAddress(b),
                    LoadCuBlasAddress(c),
                    LoadCuBlasAddress(s)));
        }

        /// <summary>
        /// Performs the CuBlas RotG operation.
        /// </summary>
        /// <param name="a">The a value.</param>
        /// <param name="b">The b value.</param>
        /// <param name="c">The cos angle.</param>
        /// <param name="s">The sin angle.</param>
        public unsafe void RotG(
            Double2 a,
            Double2 b,
            double c,
            Double2 s)
        {
            EnsureAcceleratorBinding();

            CuBlasException.ThrowIfFailed(
                API.Zrotg_v2(
                    Handle,
                    Unsafe.AsPointer(ref a),
                    Unsafe.AsPointer(ref b),
                    Unsafe.AsPointer(ref c),
                    Unsafe.AsPointer(ref s)));
        }

        /// <summary>
        /// Performs the CuBlas RotG operation.
        /// </summary>
        /// <param name="a">The a value.</param>
        /// <param name="b">The b value.</param>
        /// <param name="c">The cos angle.</param>
        /// <param name="s">The sin angle.</param>
        public unsafe void RotG(
            ArrayView<Double2> a,
            ArrayView<Double2> b,
            ArrayView<double> c,
            ArrayView<Double2> s)
        {
            EnsureAcceleratorBinding();

            CuBlasException.ThrowIfFailed(
                API.Zrotg_v2(
                    Handle,
                    LoadCuBlasAddress(a),
                    LoadCuBlasAddress(b),
                    LoadCuBlasAddress(c),
                    LoadCuBlasAddress(s)));
        }


        /// <summary>
        /// Performs the CuBlas RotM operation.
        /// </summary>
        /// <param name="x">The x vector.</param>
        /// <param name="y">The y vector.</param>
        /// <param name="param">The Givens param.</param>
        public unsafe void RotM(
            ArrayView1D<float, Stride1D.General> x,
            ArrayView1D<float, Stride1D.General> y,
            ref float param)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Srotm_v2(
                    Handle,
                    x.IntLength,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride,
                    Unsafe.AsPointer(ref param)));
        }

        /// <summary>
        /// Performs the CuBlas RotM operation.
        /// </summary>
        /// <param name="x">The x vector.</param>
        /// <param name="y">The y vector.</param>
        /// <param name="param">The Givens param.</param>
        public unsafe void RotM(
            ArrayView1D<float, Stride1D.General> x,
            ArrayView1D<float, Stride1D.General> y,
            ArrayView<float> param)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Srotm_v2(
                    Handle,
                    x.IntLength,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride,
                    LoadCuBlasAddress(param)));
        }

        /// <summary>
        /// Performs the CuBlas RotM operation.
        /// </summary>
        /// <param name="x">The x vector.</param>
        /// <param name="y">The y vector.</param>
        /// <param name="param">The Givens param.</param>
        public unsafe void RotM(
            ArrayView1D<double, Stride1D.General> x,
            ArrayView1D<double, Stride1D.General> y,
            ref double param)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Drotm_v2(
                    Handle,
                    x.IntLength,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride,
                    Unsafe.AsPointer(ref param)));
        }

        /// <summary>
        /// Performs the CuBlas RotM operation.
        /// </summary>
        /// <param name="x">The x vector.</param>
        /// <param name="y">The y vector.</param>
        /// <param name="param">The Givens param.</param>
        public unsafe void RotM(
            ArrayView1D<double, Stride1D.General> x,
            ArrayView1D<double, Stride1D.General> y,
            ArrayView<double> param)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Drotm_v2(
                    Handle,
                    x.IntLength,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride,
                    LoadCuBlasAddress(param)));
        }


        /// <summary>
        /// Performs the CuBlas Scal operation.
        /// </summary>
        /// <param name="alpha">The alpha value.</param>
        /// <param name="x">The x vector.</param>
        public unsafe void Scal(
            float alpha,
            ArrayView1D<float, Stride1D.General> x)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Sscal_v2(
                    Handle,
                    x.IntLength,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Scal operation.
        /// </summary>
        /// <param name="alpha">The alpha value.</param>
        /// <param name="x">The x vector.</param>
        public unsafe void Scal(
            ArrayView<float> alpha,
            ArrayView1D<float, Stride1D.General> x)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Sscal_v2(
                    Handle,
                    x.IntLength,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Scal operation.
        /// </summary>
        /// <param name="alpha">The alpha value.</param>
        /// <param name="x">The x vector.</param>
        public unsafe void Scal(
            double alpha,
            ArrayView1D<double, Stride1D.General> x)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Dscal_v2(
                    Handle,
                    x.IntLength,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Scal operation.
        /// </summary>
        /// <param name="alpha">The alpha value.</param>
        /// <param name="x">The x vector.</param>
        public unsafe void Scal(
            ArrayView<double> alpha,
            ArrayView1D<double, Stride1D.General> x)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Dscal_v2(
                    Handle,
                    x.IntLength,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Scal operation.
        /// </summary>
        /// <param name="alpha">The alpha value.</param>
        /// <param name="x">The x vector.</param>
        public unsafe void Scal(
            Float2 alpha,
            ArrayView1D<Float2, Stride1D.General> x)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Cscal_v2(
                    Handle,
                    x.IntLength,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Scal operation.
        /// </summary>
        /// <param name="alpha">The alpha value.</param>
        /// <param name="x">The x vector.</param>
        public unsafe void Scal(
            ArrayView<Float2> alpha,
            ArrayView1D<Float2, Stride1D.General> x)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Cscal_v2(
                    Handle,
                    x.IntLength,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Scal operation.
        /// </summary>
        /// <param name="alpha">The alpha value.</param>
        /// <param name="x">The x vector.</param>
        public unsafe void Scal(
            Double2 alpha,
            ArrayView1D<Double2, Stride1D.General> x)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Zscal_v2(
                    Handle,
                    x.IntLength,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Scal operation.
        /// </summary>
        /// <param name="alpha">The alpha value.</param>
        /// <param name="x">The x vector.</param>
        public unsafe void Scal(
            ArrayView<Double2> alpha,
            ArrayView1D<Double2, Stride1D.General> x)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Zscal_v2(
                    Handle,
                    x.IntLength,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride));
        }


        /// <summary>
        /// Performs the CuBlas Swap operation.
        /// </summary>
        /// <param name="x">The x vector.</param>
        /// <param name="y">The y vector.</param>
        public unsafe void Swap(
            ArrayView1D<float, Stride1D.General> x,
            ArrayView1D<float, Stride1D.General> y)
        {
            Debug.Assert(x.Length == y.Length, "Invalid length");
            EnsureAcceleratorBinding();

            CuBlasException.ThrowIfFailed(
                API.Sswap_v2(
                    Handle,
                    x.IntLength,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Swap operation.
        /// </summary>
        /// <param name="x">The x vector.</param>
        /// <param name="y">The y vector.</param>
        public unsafe void Swap(
            ArrayView1D<double, Stride1D.General> x,
            ArrayView1D<double, Stride1D.General> y)
        {
            Debug.Assert(x.Length == y.Length, "Invalid length");
            EnsureAcceleratorBinding();

            CuBlasException.ThrowIfFailed(
                API.Dswap_v2(
                    Handle,
                    x.IntLength,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Swap operation.
        /// </summary>
        /// <param name="x">The x vector.</param>
        /// <param name="y">The y vector.</param>
        public unsafe void Swap(
            ArrayView1D<Float2, Stride1D.General> x,
            ArrayView1D<Float2, Stride1D.General> y)
        {
            Debug.Assert(x.Length == y.Length, "Invalid length");
            EnsureAcceleratorBinding();

            CuBlasException.ThrowIfFailed(
                API.Cswap_v2(
                    Handle,
                    x.IntLength,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Swap operation.
        /// </summary>
        /// <param name="x">The x vector.</param>
        /// <param name="y">The y vector.</param>
        public unsafe void Swap(
            ArrayView1D<Double2, Stride1D.General> x,
            ArrayView1D<Double2, Stride1D.General> y)
        {
            Debug.Assert(x.Length == y.Length, "Invalid length");
            EnsureAcceleratorBinding();

            CuBlasException.ThrowIfFailed(
                API.Zswap_v2(
                    Handle,
                    x.IntLength,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }

    }
}