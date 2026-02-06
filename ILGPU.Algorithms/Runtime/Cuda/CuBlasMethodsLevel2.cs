// ---------------------------------------------------------------------------------------
//                                   ILGPU Algorithms
//                        Copyright (c) 2020-2021 ILGPU Project
//                                    www.ilgpu.net
//
// File: CuBlasMethodsLevel2.tt/CuBlasMethodsLevel2.cs
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
using System.Runtime.CompilerServices;

// disable: max_line_length

namespace ILGPU.Runtime.Cuda
{
    partial class CuBlas<TPointerModeHandler>
    {
        /// <summary>
        /// Performs the CuBlas Gbmv operation.
        /// </summary>
        public unsafe void Gbmv(
            CuBlasOperation trans,
            int m,
            int n,
            int kl,
            int ku,
            float alpha,
            ArrayView<float> a,
            int lda,
            ArrayView1D<float, Stride1D.General> x,
            float beta,
            ArrayView1D<float, Stride1D.General> y)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Sgbmv_v2(
                    Handle,
                    trans,
                    m,
                    n,
                    kl,
                    ku,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    Unsafe.AsPointer(ref beta),
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Gbmv operation.
        /// </summary>
        public unsafe void Gbmv(
            CuBlasOperation trans,
            int m,
            int n,
            int kl,
            int ku,
            ArrayView<float> alpha,
            ArrayView<float> a,
            int lda,
            ArrayView1D<float, Stride1D.General> x,
            ArrayView<float> beta,
            ArrayView1D<float, Stride1D.General> y)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Sgbmv_v2(
                    Handle,
                    trans,
                    m,
                    n,
                    kl,
                    ku,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(beta),
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Gbmv operation.
        /// </summary>
        public unsafe void Gbmv(
            CuBlasOperation trans,
            int m,
            int n,
            int kl,
            int ku,
            double alpha,
            ArrayView<double> a,
            int lda,
            ArrayView1D<double, Stride1D.General> x,
            double beta,
            ArrayView1D<double, Stride1D.General> y)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Dgbmv_v2(
                    Handle,
                    trans,
                    m,
                    n,
                    kl,
                    ku,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    Unsafe.AsPointer(ref beta),
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Gbmv operation.
        /// </summary>
        public unsafe void Gbmv(
            CuBlasOperation trans,
            int m,
            int n,
            int kl,
            int ku,
            ArrayView<double> alpha,
            ArrayView<double> a,
            int lda,
            ArrayView1D<double, Stride1D.General> x,
            ArrayView<double> beta,
            ArrayView1D<double, Stride1D.General> y)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Dgbmv_v2(
                    Handle,
                    trans,
                    m,
                    n,
                    kl,
                    ku,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(beta),
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Gbmv operation.
        /// </summary>
        public unsafe void Gbmv(
            CuBlasOperation trans,
            int m,
            int n,
            int kl,
            int ku,
            Float2 alpha,
            ArrayView<Float2> a,
            int lda,
            ArrayView1D<Float2, Stride1D.General> x,
            Float2 beta,
            ArrayView1D<Float2, Stride1D.General> y)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Cgbmv_v2(
                    Handle,
                    trans,
                    m,
                    n,
                    kl,
                    ku,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    Unsafe.AsPointer(ref beta),
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Gbmv operation.
        /// </summary>
        public unsafe void Gbmv(
            CuBlasOperation trans,
            int m,
            int n,
            int kl,
            int ku,
            ArrayView<Float2> alpha,
            ArrayView<Float2> a,
            int lda,
            ArrayView1D<Float2, Stride1D.General> x,
            ArrayView<Float2> beta,
            ArrayView1D<Float2, Stride1D.General> y)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Cgbmv_v2(
                    Handle,
                    trans,
                    m,
                    n,
                    kl,
                    ku,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(beta),
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Gbmv operation.
        /// </summary>
        public unsafe void Gbmv(
            CuBlasOperation trans,
            int m,
            int n,
            int kl,
            int ku,
            Double2 alpha,
            ArrayView<Double2> a,
            int lda,
            ArrayView1D<Double2, Stride1D.General> x,
            Double2 beta,
            ArrayView1D<Double2, Stride1D.General> y)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Zgbmv_v2(
                    Handle,
                    trans,
                    m,
                    n,
                    kl,
                    ku,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    Unsafe.AsPointer(ref beta),
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Gbmv operation.
        /// </summary>
        public unsafe void Gbmv(
            CuBlasOperation trans,
            int m,
            int n,
            int kl,
            int ku,
            ArrayView<Double2> alpha,
            ArrayView<Double2> a,
            int lda,
            ArrayView1D<Double2, Stride1D.General> x,
            ArrayView<Double2> beta,
            ArrayView1D<Double2, Stride1D.General> y)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Zgbmv_v2(
                    Handle,
                    trans,
                    m,
                    n,
                    kl,
                    ku,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(beta),
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }


        /// <summary>
        /// Performs the CuBlas Gemv operation.
        /// </summary>
        public unsafe void Gemv(
            CuBlasOperation trans,
            int m,
            int n,
            float alpha,
            ArrayView<float> a,
            int lda,
            ArrayView1D<float, Stride1D.General> x,
            float beta,
            ArrayView1D<float, Stride1D.General> y)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Sgemv_v2(
                    Handle,
                    trans,
                    m,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    Unsafe.AsPointer(ref beta),
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Gemv operation.
        /// </summary>
        public unsafe void Gemv(
            CuBlasOperation trans,
            int m,
            int n,
            ArrayView<float> alpha,
            ArrayView<float> a,
            int lda,
            ArrayView1D<float, Stride1D.General> x,
            ArrayView<float> beta,
            ArrayView1D<float, Stride1D.General> y)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Sgemv_v2(
                    Handle,
                    trans,
                    m,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(beta),
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Gemv operation.
        /// </summary>
        public unsafe void Gemv(
            CuBlasOperation trans,
            int m,
            int n,
            double alpha,
            ArrayView<double> a,
            int lda,
            ArrayView1D<double, Stride1D.General> x,
            double beta,
            ArrayView1D<double, Stride1D.General> y)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Dgemv_v2(
                    Handle,
                    trans,
                    m,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    Unsafe.AsPointer(ref beta),
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Gemv operation.
        /// </summary>
        public unsafe void Gemv(
            CuBlasOperation trans,
            int m,
            int n,
            ArrayView<double> alpha,
            ArrayView<double> a,
            int lda,
            ArrayView1D<double, Stride1D.General> x,
            ArrayView<double> beta,
            ArrayView1D<double, Stride1D.General> y)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Dgemv_v2(
                    Handle,
                    trans,
                    m,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(beta),
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Gemv operation.
        /// </summary>
        public unsafe void Gemv(
            CuBlasOperation trans,
            int m,
            int n,
            Float2 alpha,
            ArrayView<Float2> a,
            int lda,
            ArrayView1D<Float2, Stride1D.General> x,
            Float2 beta,
            ArrayView1D<Float2, Stride1D.General> y)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Cgemv_v2(
                    Handle,
                    trans,
                    m,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    Unsafe.AsPointer(ref beta),
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Gemv operation.
        /// </summary>
        public unsafe void Gemv(
            CuBlasOperation trans,
            int m,
            int n,
            ArrayView<Float2> alpha,
            ArrayView<Float2> a,
            int lda,
            ArrayView1D<Float2, Stride1D.General> x,
            ArrayView<Float2> beta,
            ArrayView1D<Float2, Stride1D.General> y)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Cgemv_v2(
                    Handle,
                    trans,
                    m,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(beta),
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Gemv operation.
        /// </summary>
        public unsafe void Gemv(
            CuBlasOperation trans,
            int m,
            int n,
            Double2 alpha,
            ArrayView<Double2> a,
            int lda,
            ArrayView1D<Double2, Stride1D.General> x,
            Double2 beta,
            ArrayView1D<Double2, Stride1D.General> y)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Zgemv_v2(
                    Handle,
                    trans,
                    m,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    Unsafe.AsPointer(ref beta),
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Gemv operation.
        /// </summary>
        public unsafe void Gemv(
            CuBlasOperation trans,
            int m,
            int n,
            ArrayView<Double2> alpha,
            ArrayView<Double2> a,
            int lda,
            ArrayView1D<Double2, Stride1D.General> x,
            ArrayView<Double2> beta,
            ArrayView1D<Double2, Stride1D.General> y)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Zgemv_v2(
                    Handle,
                    trans,
                    m,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(beta),
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }


        /// <summary>
        /// Performs the CuBlas Ger operation.
        /// </summary>
        public unsafe void Ger(
            int m,
            int n,
            float alpha,
            ArrayView1D<float, Stride1D.General> x,
            ArrayView1D<float, Stride1D.General> y,
            ArrayView<float> a,
            int lda)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Sger_v2(
                    Handle,
                    m,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride,
                    LoadCuBlasAddress(a),
                    lda));
        }

        /// <summary>
        /// Performs the CuBlas Ger operation.
        /// </summary>
        public unsafe void Ger(
            int m,
            int n,
            ArrayView<float> alpha,
            ArrayView1D<float, Stride1D.General> x,
            ArrayView1D<float, Stride1D.General> y,
            ArrayView<float> a,
            int lda)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Sger_v2(
                    Handle,
                    m,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride,
                    LoadCuBlasAddress(a),
                    lda));
        }

        /// <summary>
        /// Performs the CuBlas Ger operation.
        /// </summary>
        public unsafe void Ger(
            int m,
            int n,
            double alpha,
            ArrayView1D<double, Stride1D.General> x,
            ArrayView1D<double, Stride1D.General> y,
            ArrayView<double> a,
            int lda)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Dger_v2(
                    Handle,
                    m,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride,
                    LoadCuBlasAddress(a),
                    lda));
        }

        /// <summary>
        /// Performs the CuBlas Ger operation.
        /// </summary>
        public unsafe void Ger(
            int m,
            int n,
            ArrayView<double> alpha,
            ArrayView1D<double, Stride1D.General> x,
            ArrayView1D<double, Stride1D.General> y,
            ArrayView<double> a,
            int lda)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Dger_v2(
                    Handle,
                    m,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride,
                    LoadCuBlasAddress(a),
                    lda));
        }

        /// <summary>
        /// Performs the CuBlas Ger operation.
        /// </summary>
        public unsafe void Ger(
            int m,
            int n,
            Float2 alpha,
            ArrayView1D<Float2, Stride1D.General> x,
            ArrayView1D<Float2, Stride1D.General> y,
            ArrayView<Float2> a,
            int lda)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Cgeru_v2(
                    Handle,
                    m,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride,
                    LoadCuBlasAddress(a),
                    lda));
        }

        /// <summary>
        /// Performs the CuBlas Ger operation.
        /// </summary>
        public unsafe void Ger(
            int m,
            int n,
            ArrayView<Float2> alpha,
            ArrayView1D<Float2, Stride1D.General> x,
            ArrayView1D<Float2, Stride1D.General> y,
            ArrayView<Float2> a,
            int lda)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Cgeru_v2(
                    Handle,
                    m,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride,
                    LoadCuBlasAddress(a),
                    lda));
        }

        /// <summary>
        /// Performs the CuBlas Ger operation.
        /// </summary>
        public unsafe void Ger(
            int m,
            int n,
            Double2 alpha,
            ArrayView1D<Double2, Stride1D.General> x,
            ArrayView1D<Double2, Stride1D.General> y,
            ArrayView<Double2> a,
            int lda)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Zgeru_v2(
                    Handle,
                    m,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride,
                    LoadCuBlasAddress(a),
                    lda));
        }

        /// <summary>
        /// Performs the CuBlas Ger operation.
        /// </summary>
        public unsafe void Ger(
            int m,
            int n,
            ArrayView<Double2> alpha,
            ArrayView1D<Double2, Stride1D.General> x,
            ArrayView1D<Double2, Stride1D.General> y,
            ArrayView<Double2> a,
            int lda)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Zgeru_v2(
                    Handle,
                    m,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride,
                    LoadCuBlasAddress(a),
                    lda));
        }


        /// <summary>
        /// Performs the CuBlas Sbmv operation.
        /// </summary>
        public unsafe void Sbmv(
            CuBlasFillMode uplo,
            int n,
            int k,
            float alpha,
            ArrayView<float> a,
            int lda,
            ArrayView1D<float, Stride1D.General> x,
            float beta,
            ArrayView1D<float, Stride1D.General> y)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Ssbmv_v2(
                    Handle,
                    uplo,
                    n,
                    k,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    Unsafe.AsPointer(ref beta),
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Sbmv operation.
        /// </summary>
        public unsafe void Sbmv(
            CuBlasFillMode uplo,
            int n,
            int k,
            ArrayView<float> alpha,
            ArrayView<float> a,
            int lda,
            ArrayView1D<float, Stride1D.General> x,
            ArrayView<float> beta,
            ArrayView1D<float, Stride1D.General> y)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Ssbmv_v2(
                    Handle,
                    uplo,
                    n,
                    k,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(beta),
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Sbmv operation.
        /// </summary>
        public unsafe void Sbmv(
            CuBlasFillMode uplo,
            int n,
            int k,
            double alpha,
            ArrayView<double> a,
            int lda,
            ArrayView1D<double, Stride1D.General> x,
            double beta,
            ArrayView1D<double, Stride1D.General> y)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Dsbmv_v2(
                    Handle,
                    uplo,
                    n,
                    k,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    Unsafe.AsPointer(ref beta),
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Sbmv operation.
        /// </summary>
        public unsafe void Sbmv(
            CuBlasFillMode uplo,
            int n,
            int k,
            ArrayView<double> alpha,
            ArrayView<double> a,
            int lda,
            ArrayView1D<double, Stride1D.General> x,
            ArrayView<double> beta,
            ArrayView1D<double, Stride1D.General> y)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Dsbmv_v2(
                    Handle,
                    uplo,
                    n,
                    k,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(beta),
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Sbmv operation.
        /// </summary>
        public unsafe void Sbmv(
            CuBlasFillMode uplo,
            int n,
            int k,
            Float2 alpha,
            ArrayView<Float2> a,
            int lda,
            ArrayView1D<Float2, Stride1D.General> x,
            Float2 beta,
            ArrayView1D<Float2, Stride1D.General> y)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Chbmv_v2(
                    Handle,
                    uplo,
                    n,
                    k,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    Unsafe.AsPointer(ref beta),
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Sbmv operation.
        /// </summary>
        public unsafe void Sbmv(
            CuBlasFillMode uplo,
            int n,
            int k,
            ArrayView<Float2> alpha,
            ArrayView<Float2> a,
            int lda,
            ArrayView1D<Float2, Stride1D.General> x,
            ArrayView<Float2> beta,
            ArrayView1D<Float2, Stride1D.General> y)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Chbmv_v2(
                    Handle,
                    uplo,
                    n,
                    k,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(beta),
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Sbmv operation.
        /// </summary>
        public unsafe void Sbmv(
            CuBlasFillMode uplo,
            int n,
            int k,
            Double2 alpha,
            ArrayView<Double2> a,
            int lda,
            ArrayView1D<Double2, Stride1D.General> x,
            Double2 beta,
            ArrayView1D<Double2, Stride1D.General> y)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Zhbmv_v2(
                    Handle,
                    uplo,
                    n,
                    k,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    Unsafe.AsPointer(ref beta),
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Sbmv operation.
        /// </summary>
        public unsafe void Sbmv(
            CuBlasFillMode uplo,
            int n,
            int k,
            ArrayView<Double2> alpha,
            ArrayView<Double2> a,
            int lda,
            ArrayView1D<Double2, Stride1D.General> x,
            ArrayView<Double2> beta,
            ArrayView1D<Double2, Stride1D.General> y)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Zhbmv_v2(
                    Handle,
                    uplo,
                    n,
                    k,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(beta),
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }


        /// <summary>
        /// Performs the CuBlas Spmv operation.
        /// </summary>
        public unsafe void Spmv(
            CuBlasFillMode uplo,
            int n,
            float alpha,
            ArrayView<float> ap,
            ArrayView1D<float, Stride1D.General> x,
            float beta,
            ArrayView1D<float, Stride1D.General> y)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Sspmv_v2(
                    Handle,
                    uplo,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(ap),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    Unsafe.AsPointer(ref beta),
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Spmv operation.
        /// </summary>
        public unsafe void Spmv(
            CuBlasFillMode uplo,
            int n,
            ArrayView<float> alpha,
            ArrayView<float> ap,
            ArrayView1D<float, Stride1D.General> x,
            ArrayView<float> beta,
            ArrayView1D<float, Stride1D.General> y)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Sspmv_v2(
                    Handle,
                    uplo,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(ap),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(beta),
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Spmv operation.
        /// </summary>
        public unsafe void Spmv(
            CuBlasFillMode uplo,
            int n,
            double alpha,
            ArrayView<double> ap,
            ArrayView1D<double, Stride1D.General> x,
            double beta,
            ArrayView1D<double, Stride1D.General> y)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Dspmv_v2(
                    Handle,
                    uplo,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(ap),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    Unsafe.AsPointer(ref beta),
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Spmv operation.
        /// </summary>
        public unsafe void Spmv(
            CuBlasFillMode uplo,
            int n,
            ArrayView<double> alpha,
            ArrayView<double> ap,
            ArrayView1D<double, Stride1D.General> x,
            ArrayView<double> beta,
            ArrayView1D<double, Stride1D.General> y)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Dspmv_v2(
                    Handle,
                    uplo,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(ap),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(beta),
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Spmv operation.
        /// </summary>
        public unsafe void Spmv(
            CuBlasFillMode uplo,
            int n,
            Float2 alpha,
            ArrayView<Float2> ap,
            ArrayView1D<Float2, Stride1D.General> x,
            Float2 beta,
            ArrayView1D<Float2, Stride1D.General> y)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Chpmv_v2(
                    Handle,
                    uplo,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(ap),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    Unsafe.AsPointer(ref beta),
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Spmv operation.
        /// </summary>
        public unsafe void Spmv(
            CuBlasFillMode uplo,
            int n,
            ArrayView<Float2> alpha,
            ArrayView<Float2> ap,
            ArrayView1D<Float2, Stride1D.General> x,
            ArrayView<Float2> beta,
            ArrayView1D<Float2, Stride1D.General> y)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Chpmv_v2(
                    Handle,
                    uplo,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(ap),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(beta),
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Spmv operation.
        /// </summary>
        public unsafe void Spmv(
            CuBlasFillMode uplo,
            int n,
            Double2 alpha,
            ArrayView<Double2> ap,
            ArrayView1D<Double2, Stride1D.General> x,
            Double2 beta,
            ArrayView1D<Double2, Stride1D.General> y)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Zhpmv_v2(
                    Handle,
                    uplo,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(ap),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    Unsafe.AsPointer(ref beta),
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Spmv operation.
        /// </summary>
        public unsafe void Spmv(
            CuBlasFillMode uplo,
            int n,
            ArrayView<Double2> alpha,
            ArrayView<Double2> ap,
            ArrayView1D<Double2, Stride1D.General> x,
            ArrayView<Double2> beta,
            ArrayView1D<Double2, Stride1D.General> y)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Zhpmv_v2(
                    Handle,
                    uplo,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(ap),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(beta),
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }


        /// <summary>
        /// Performs the CuBlas Spr operation.
        /// </summary>
        public unsafe void Spr(
            CuBlasFillMode uplo,
            int n,
            float alpha,
            ArrayView1D<float, Stride1D.General> x,
            ArrayView<float> ap)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Sspr_v2(
                    Handle,
                    uplo,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(ap)));
        }

        /// <summary>
        /// Performs the CuBlas Spr operation.
        /// </summary>
        public unsafe void Spr(
            CuBlasFillMode uplo,
            int n,
            ArrayView<float> alpha,
            ArrayView1D<float, Stride1D.General> x,
            ArrayView<float> ap)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Sspr_v2(
                    Handle,
                    uplo,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(ap)));
        }

        /// <summary>
        /// Performs the CuBlas Spr operation.
        /// </summary>
        public unsafe void Spr(
            CuBlasFillMode uplo,
            int n,
            double alpha,
            ArrayView1D<double, Stride1D.General> x,
            ArrayView<double> ap)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Dspr_v2(
                    Handle,
                    uplo,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(ap)));
        }

        /// <summary>
        /// Performs the CuBlas Spr operation.
        /// </summary>
        public unsafe void Spr(
            CuBlasFillMode uplo,
            int n,
            ArrayView<double> alpha,
            ArrayView1D<double, Stride1D.General> x,
            ArrayView<double> ap)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Dspr_v2(
                    Handle,
                    uplo,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(ap)));
        }

        /// <summary>
        /// Performs the CuBlas Spr operation.
        /// </summary>
        public unsafe void Spr(
            CuBlasFillMode uplo,
            int n,
            Float2 alpha,
            ArrayView1D<Float2, Stride1D.General> x,
            ArrayView<Float2> ap)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Chpr_v2(
                    Handle,
                    uplo,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(ap)));
        }

        /// <summary>
        /// Performs the CuBlas Spr operation.
        /// </summary>
        public unsafe void Spr(
            CuBlasFillMode uplo,
            int n,
            ArrayView<Float2> alpha,
            ArrayView1D<Float2, Stride1D.General> x,
            ArrayView<Float2> ap)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Chpr_v2(
                    Handle,
                    uplo,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(ap)));
        }

        /// <summary>
        /// Performs the CuBlas Spr operation.
        /// </summary>
        public unsafe void Spr(
            CuBlasFillMode uplo,
            int n,
            Double2 alpha,
            ArrayView1D<Double2, Stride1D.General> x,
            ArrayView<Double2> ap)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Zhpr_v2(
                    Handle,
                    uplo,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(ap)));
        }

        /// <summary>
        /// Performs the CuBlas Spr operation.
        /// </summary>
        public unsafe void Spr(
            CuBlasFillMode uplo,
            int n,
            ArrayView<Double2> alpha,
            ArrayView1D<Double2, Stride1D.General> x,
            ArrayView<Double2> ap)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Zhpr_v2(
                    Handle,
                    uplo,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(ap)));
        }


        /// <summary>
        /// Performs the CuBlas Spr2 operation.
        /// </summary>
        public unsafe void Spr2(
            CuBlasFillMode uplo,
            int n,
            float alpha,
            ArrayView1D<float, Stride1D.General> x,
            ArrayView1D<float, Stride1D.General> y,
            ArrayView<float> ap)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Sspr2_v2(
                    Handle,
                    uplo,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride,
                    LoadCuBlasAddress(ap)));
        }

        /// <summary>
        /// Performs the CuBlas Spr2 operation.
        /// </summary>
        public unsafe void Spr2(
            CuBlasFillMode uplo,
            int n,
            ArrayView<float> alpha,
            ArrayView1D<float, Stride1D.General> x,
            ArrayView1D<float, Stride1D.General> y,
            ArrayView<float> ap)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Sspr2_v2(
                    Handle,
                    uplo,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride,
                    LoadCuBlasAddress(ap)));
        }

        /// <summary>
        /// Performs the CuBlas Spr2 operation.
        /// </summary>
        public unsafe void Spr2(
            CuBlasFillMode uplo,
            int n,
            double alpha,
            ArrayView1D<double, Stride1D.General> x,
            ArrayView1D<double, Stride1D.General> y,
            ArrayView<double> ap)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Dspr2_v2(
                    Handle,
                    uplo,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride,
                    LoadCuBlasAddress(ap)));
        }

        /// <summary>
        /// Performs the CuBlas Spr2 operation.
        /// </summary>
        public unsafe void Spr2(
            CuBlasFillMode uplo,
            int n,
            ArrayView<double> alpha,
            ArrayView1D<double, Stride1D.General> x,
            ArrayView1D<double, Stride1D.General> y,
            ArrayView<double> ap)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Dspr2_v2(
                    Handle,
                    uplo,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride,
                    LoadCuBlasAddress(ap)));
        }

        /// <summary>
        /// Performs the CuBlas Spr2 operation.
        /// </summary>
        public unsafe void Spr2(
            CuBlasFillMode uplo,
            int n,
            Float2 alpha,
            ArrayView1D<Float2, Stride1D.General> x,
            ArrayView1D<Float2, Stride1D.General> y,
            ArrayView<Float2> ap)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Chpr2_v2(
                    Handle,
                    uplo,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride,
                    LoadCuBlasAddress(ap)));
        }

        /// <summary>
        /// Performs the CuBlas Spr2 operation.
        /// </summary>
        public unsafe void Spr2(
            CuBlasFillMode uplo,
            int n,
            ArrayView<Float2> alpha,
            ArrayView1D<Float2, Stride1D.General> x,
            ArrayView1D<Float2, Stride1D.General> y,
            ArrayView<Float2> ap)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Chpr2_v2(
                    Handle,
                    uplo,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride,
                    LoadCuBlasAddress(ap)));
        }

        /// <summary>
        /// Performs the CuBlas Spr2 operation.
        /// </summary>
        public unsafe void Spr2(
            CuBlasFillMode uplo,
            int n,
            Double2 alpha,
            ArrayView1D<Double2, Stride1D.General> x,
            ArrayView1D<Double2, Stride1D.General> y,
            ArrayView<Double2> ap)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Zhpr2_v2(
                    Handle,
                    uplo,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride,
                    LoadCuBlasAddress(ap)));
        }

        /// <summary>
        /// Performs the CuBlas Spr2 operation.
        /// </summary>
        public unsafe void Spr2(
            CuBlasFillMode uplo,
            int n,
            ArrayView<Double2> alpha,
            ArrayView1D<Double2, Stride1D.General> x,
            ArrayView1D<Double2, Stride1D.General> y,
            ArrayView<Double2> ap)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Zhpr2_v2(
                    Handle,
                    uplo,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride,
                    LoadCuBlasAddress(ap)));
        }


        /// <summary>
        /// Performs the CuBlas Symv operation.
        /// </summary>
        public unsafe void Symv(
            CuBlasFillMode uplo,
            int n,
            float alpha,
            ArrayView<float> a,
            int lda,
            ArrayView1D<float, Stride1D.General> x,
            float beta,
            ArrayView1D<float, Stride1D.General> y)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Ssymv_v2(
                    Handle,
                    uplo,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    Unsafe.AsPointer(ref beta),
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Symv operation.
        /// </summary>
        public unsafe void Symv(
            CuBlasFillMode uplo,
            int n,
            ArrayView<float> alpha,
            ArrayView<float> a,
            int lda,
            ArrayView1D<float, Stride1D.General> x,
            ArrayView<float> beta,
            ArrayView1D<float, Stride1D.General> y)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Ssymv_v2(
                    Handle,
                    uplo,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(beta),
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Symv operation.
        /// </summary>
        public unsafe void Symv(
            CuBlasFillMode uplo,
            int n,
            double alpha,
            ArrayView<double> a,
            int lda,
            ArrayView1D<double, Stride1D.General> x,
            double beta,
            ArrayView1D<double, Stride1D.General> y)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Dsymv_v2(
                    Handle,
                    uplo,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    Unsafe.AsPointer(ref beta),
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Symv operation.
        /// </summary>
        public unsafe void Symv(
            CuBlasFillMode uplo,
            int n,
            ArrayView<double> alpha,
            ArrayView<double> a,
            int lda,
            ArrayView1D<double, Stride1D.General> x,
            ArrayView<double> beta,
            ArrayView1D<double, Stride1D.General> y)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Dsymv_v2(
                    Handle,
                    uplo,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(beta),
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Symv operation.
        /// </summary>
        public unsafe void Symv(
            CuBlasFillMode uplo,
            int n,
            Float2 alpha,
            ArrayView<Float2> a,
            int lda,
            ArrayView1D<Float2, Stride1D.General> x,
            Float2 beta,
            ArrayView1D<Float2, Stride1D.General> y)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Csymv_v2(
                    Handle,
                    uplo,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    Unsafe.AsPointer(ref beta),
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Symv operation.
        /// </summary>
        public unsafe void Symv(
            CuBlasFillMode uplo,
            int n,
            ArrayView<Float2> alpha,
            ArrayView<Float2> a,
            int lda,
            ArrayView1D<Float2, Stride1D.General> x,
            ArrayView<Float2> beta,
            ArrayView1D<Float2, Stride1D.General> y)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Csymv_v2(
                    Handle,
                    uplo,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(beta),
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Symv operation.
        /// </summary>
        public unsafe void Symv(
            CuBlasFillMode uplo,
            int n,
            Double2 alpha,
            ArrayView<Double2> a,
            int lda,
            ArrayView1D<Double2, Stride1D.General> x,
            Double2 beta,
            ArrayView1D<Double2, Stride1D.General> y)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Zsymv_v2(
                    Handle,
                    uplo,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    Unsafe.AsPointer(ref beta),
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Symv operation.
        /// </summary>
        public unsafe void Symv(
            CuBlasFillMode uplo,
            int n,
            ArrayView<Double2> alpha,
            ArrayView<Double2> a,
            int lda,
            ArrayView1D<Double2, Stride1D.General> x,
            ArrayView<Double2> beta,
            ArrayView1D<Double2, Stride1D.General> y)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Zsymv_v2(
                    Handle,
                    uplo,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(beta),
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride));
        }


        /// <summary>
        /// Performs the CuBlas Syr operation.
        /// </summary>
        public unsafe void Syr(
            CuBlasFillMode uplo,
            int n,
            float alpha,
            ArrayView1D<float, Stride1D.General> x,
            ArrayView<float> a,
            int lda)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Ssyr_v2(
                    Handle,
                    uplo,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(a),
                    lda));
        }

        /// <summary>
        /// Performs the CuBlas Syr operation.
        /// </summary>
        public unsafe void Syr(
            CuBlasFillMode uplo,
            int n,
            ArrayView<float> alpha,
            ArrayView1D<float, Stride1D.General> x,
            ArrayView<float> a,
            int lda)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Ssyr_v2(
                    Handle,
                    uplo,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(a),
                    lda));
        }

        /// <summary>
        /// Performs the CuBlas Syr operation.
        /// </summary>
        public unsafe void Syr(
            CuBlasFillMode uplo,
            int n,
            double alpha,
            ArrayView1D<double, Stride1D.General> x,
            ArrayView<double> a,
            int lda)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Dsyr_v2(
                    Handle,
                    uplo,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(a),
                    lda));
        }

        /// <summary>
        /// Performs the CuBlas Syr operation.
        /// </summary>
        public unsafe void Syr(
            CuBlasFillMode uplo,
            int n,
            ArrayView<double> alpha,
            ArrayView1D<double, Stride1D.General> x,
            ArrayView<double> a,
            int lda)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Dsyr_v2(
                    Handle,
                    uplo,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(a),
                    lda));
        }

        /// <summary>
        /// Performs the CuBlas Syr operation.
        /// </summary>
        public unsafe void Syr(
            CuBlasFillMode uplo,
            int n,
            Float2 alpha,
            ArrayView1D<Float2, Stride1D.General> x,
            ArrayView<Float2> a,
            int lda)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Csyr_v2(
                    Handle,
                    uplo,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(a),
                    lda));
        }

        /// <summary>
        /// Performs the CuBlas Syr operation.
        /// </summary>
        public unsafe void Syr(
            CuBlasFillMode uplo,
            int n,
            ArrayView<Float2> alpha,
            ArrayView1D<Float2, Stride1D.General> x,
            ArrayView<Float2> a,
            int lda)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Csyr_v2(
                    Handle,
                    uplo,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(a),
                    lda));
        }

        /// <summary>
        /// Performs the CuBlas Syr operation.
        /// </summary>
        public unsafe void Syr(
            CuBlasFillMode uplo,
            int n,
            Double2 alpha,
            ArrayView1D<Double2, Stride1D.General> x,
            ArrayView<Double2> a,
            int lda)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Zsyr_v2(
                    Handle,
                    uplo,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(a),
                    lda));
        }

        /// <summary>
        /// Performs the CuBlas Syr operation.
        /// </summary>
        public unsafe void Syr(
            CuBlasFillMode uplo,
            int n,
            ArrayView<Double2> alpha,
            ArrayView1D<Double2, Stride1D.General> x,
            ArrayView<Double2> a,
            int lda)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Zsyr_v2(
                    Handle,
                    uplo,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(a),
                    lda));
        }


        /// <summary>
        /// Performs the CuBlas Syr2 operation.
        /// </summary>
        public unsafe void Syr2(
            CuBlasFillMode uplo,
            int n,
            float alpha,
            ArrayView1D<float, Stride1D.General> x,
            ArrayView1D<float, Stride1D.General> y,
            ArrayView<float> a,
            int lda)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Ssyr2_v2(
                    Handle,
                    uplo,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride,
                    LoadCuBlasAddress(a),
                    lda));
        }

        /// <summary>
        /// Performs the CuBlas Syr2 operation.
        /// </summary>
        public unsafe void Syr2(
            CuBlasFillMode uplo,
            int n,
            ArrayView<float> alpha,
            ArrayView1D<float, Stride1D.General> x,
            ArrayView1D<float, Stride1D.General> y,
            ArrayView<float> a,
            int lda)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Ssyr2_v2(
                    Handle,
                    uplo,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride,
                    LoadCuBlasAddress(a),
                    lda));
        }

        /// <summary>
        /// Performs the CuBlas Syr2 operation.
        /// </summary>
        public unsafe void Syr2(
            CuBlasFillMode uplo,
            int n,
            double alpha,
            ArrayView1D<double, Stride1D.General> x,
            ArrayView1D<double, Stride1D.General> y,
            ArrayView<double> a,
            int lda)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Dsyr2_v2(
                    Handle,
                    uplo,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride,
                    LoadCuBlasAddress(a),
                    lda));
        }

        /// <summary>
        /// Performs the CuBlas Syr2 operation.
        /// </summary>
        public unsafe void Syr2(
            CuBlasFillMode uplo,
            int n,
            ArrayView<double> alpha,
            ArrayView1D<double, Stride1D.General> x,
            ArrayView1D<double, Stride1D.General> y,
            ArrayView<double> a,
            int lda)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Dsyr2_v2(
                    Handle,
                    uplo,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride,
                    LoadCuBlasAddress(a),
                    lda));
        }

        /// <summary>
        /// Performs the CuBlas Syr2 operation.
        /// </summary>
        public unsafe void Syr2(
            CuBlasFillMode uplo,
            int n,
            Float2 alpha,
            ArrayView1D<Float2, Stride1D.General> x,
            ArrayView1D<Float2, Stride1D.General> y,
            ArrayView<Float2> a,
            int lda)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Csyr2_v2(
                    Handle,
                    uplo,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride,
                    LoadCuBlasAddress(a),
                    lda));
        }

        /// <summary>
        /// Performs the CuBlas Syr2 operation.
        /// </summary>
        public unsafe void Syr2(
            CuBlasFillMode uplo,
            int n,
            ArrayView<Float2> alpha,
            ArrayView1D<Float2, Stride1D.General> x,
            ArrayView1D<Float2, Stride1D.General> y,
            ArrayView<Float2> a,
            int lda)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Csyr2_v2(
                    Handle,
                    uplo,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride,
                    LoadCuBlasAddress(a),
                    lda));
        }

        /// <summary>
        /// Performs the CuBlas Syr2 operation.
        /// </summary>
        public unsafe void Syr2(
            CuBlasFillMode uplo,
            int n,
            Double2 alpha,
            ArrayView1D<Double2, Stride1D.General> x,
            ArrayView1D<Double2, Stride1D.General> y,
            ArrayView<Double2> a,
            int lda)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Zsyr2_v2(
                    Handle,
                    uplo,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride,
                    LoadCuBlasAddress(a),
                    lda));
        }

        /// <summary>
        /// Performs the CuBlas Syr2 operation.
        /// </summary>
        public unsafe void Syr2(
            CuBlasFillMode uplo,
            int n,
            ArrayView<Double2> alpha,
            ArrayView1D<Double2, Stride1D.General> x,
            ArrayView1D<Double2, Stride1D.General> y,
            ArrayView<Double2> a,
            int lda)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Zsyr2_v2(
                    Handle,
                    uplo,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(y.BaseView),
                    y.Stride.XStride,
                    LoadCuBlasAddress(a),
                    lda));
        }


        /// <summary>
        /// Performs the CuBlas Tbmv operation.
        /// </summary>
        public unsafe void Tbmv(
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            CuBlasDiagType diag,
            int n, 
            int k,
            ArrayView<float> a,
            int lda,
            ArrayView1D<float, Stride1D.General> x)
        {
            EnsureAcceleratorBinding();

            CuBlasException.ThrowIfFailed(
                API.Stbmv_v2(
                    Handle,
                    uplo,
                    trans,
                    diag,
                    n,
                    k,
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Tbmv operation.
        /// </summary>
        public unsafe void Tbmv(
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            CuBlasDiagType diag,
            int n, 
            int k,
            ArrayView<double> a,
            int lda,
            ArrayView1D<double, Stride1D.General> x)
        {
            EnsureAcceleratorBinding();

            CuBlasException.ThrowIfFailed(
                API.Dtbmv_v2(
                    Handle,
                    uplo,
                    trans,
                    diag,
                    n,
                    k,
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Tbmv operation.
        /// </summary>
        public unsafe void Tbmv(
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            CuBlasDiagType diag,
            int n, 
            int k,
            ArrayView<Float2> a,
            int lda,
            ArrayView1D<Float2, Stride1D.General> x)
        {
            EnsureAcceleratorBinding();

            CuBlasException.ThrowIfFailed(
                API.Ctbmv_v2(
                    Handle,
                    uplo,
                    trans,
                    diag,
                    n,
                    k,
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Tbmv operation.
        /// </summary>
        public unsafe void Tbmv(
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            CuBlasDiagType diag,
            int n, 
            int k,
            ArrayView<Double2> a,
            int lda,
            ArrayView1D<Double2, Stride1D.General> x)
        {
            EnsureAcceleratorBinding();

            CuBlasException.ThrowIfFailed(
                API.Ztbmv_v2(
                    Handle,
                    uplo,
                    trans,
                    diag,
                    n,
                    k,
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Tbsv operation.
        /// </summary>
        public unsafe void Tbsv(
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            CuBlasDiagType diag,
            int n, 
            int k,
            ArrayView<float> a,
            int lda,
            ArrayView1D<float, Stride1D.General> x)
        {
            EnsureAcceleratorBinding();

            CuBlasException.ThrowIfFailed(
                API.Stbsv_v2(
                    Handle,
                    uplo,
                    trans,
                    diag,
                    n,
                    k,
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Tbsv operation.
        /// </summary>
        public unsafe void Tbsv(
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            CuBlasDiagType diag,
            int n, 
            int k,
            ArrayView<double> a,
            int lda,
            ArrayView1D<double, Stride1D.General> x)
        {
            EnsureAcceleratorBinding();

            CuBlasException.ThrowIfFailed(
                API.Dtbsv_v2(
                    Handle,
                    uplo,
                    trans,
                    diag,
                    n,
                    k,
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Tbsv operation.
        /// </summary>
        public unsafe void Tbsv(
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            CuBlasDiagType diag,
            int n, 
            int k,
            ArrayView<Float2> a,
            int lda,
            ArrayView1D<Float2, Stride1D.General> x)
        {
            EnsureAcceleratorBinding();

            CuBlasException.ThrowIfFailed(
                API.Ctbsv_v2(
                    Handle,
                    uplo,
                    trans,
                    diag,
                    n,
                    k,
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Tbsv operation.
        /// </summary>
        public unsafe void Tbsv(
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            CuBlasDiagType diag,
            int n, 
            int k,
            ArrayView<Double2> a,
            int lda,
            ArrayView1D<Double2, Stride1D.General> x)
        {
            EnsureAcceleratorBinding();

            CuBlasException.ThrowIfFailed(
                API.Ztbsv_v2(
                    Handle,
                    uplo,
                    trans,
                    diag,
                    n,
                    k,
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride));
        }


        /// <summary>
        /// Performs the CuBlas Tpmv operation.
        /// </summary>
        public unsafe void Tpmv(
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            CuBlasDiagType diag,
            int n, 
            ArrayView<float> ap,
            ArrayView1D<float, Stride1D.General> x)
        {
            EnsureAcceleratorBinding();

            CuBlasException.ThrowIfFailed(
                API.Stpmv_v2(
                    Handle,
                    uplo,
                    trans,
                    diag,
                    n,
                    LoadCuBlasAddress(ap),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Tpmv operation.
        /// </summary>
        public unsafe void Tpmv(
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            CuBlasDiagType diag,
            int n, 
            ArrayView<double> ap,
            ArrayView1D<double, Stride1D.General> x)
        {
            EnsureAcceleratorBinding();

            CuBlasException.ThrowIfFailed(
                API.Dtpmv_v2(
                    Handle,
                    uplo,
                    trans,
                    diag,
                    n,
                    LoadCuBlasAddress(ap),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Tpmv operation.
        /// </summary>
        public unsafe void Tpmv(
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            CuBlasDiagType diag,
            int n, 
            ArrayView<Float2> ap,
            ArrayView1D<Float2, Stride1D.General> x)
        {
            EnsureAcceleratorBinding();

            CuBlasException.ThrowIfFailed(
                API.Ctpmv_v2(
                    Handle,
                    uplo,
                    trans,
                    diag,
                    n,
                    LoadCuBlasAddress(ap),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Tpmv operation.
        /// </summary>
        public unsafe void Tpmv(
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            CuBlasDiagType diag,
            int n, 
            ArrayView<Double2> ap,
            ArrayView1D<Double2, Stride1D.General> x)
        {
            EnsureAcceleratorBinding();

            CuBlasException.ThrowIfFailed(
                API.Ztpmv_v2(
                    Handle,
                    uplo,
                    trans,
                    diag,
                    n,
                    LoadCuBlasAddress(ap),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Tpsv operation.
        /// </summary>
        public unsafe void Tpsv(
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            CuBlasDiagType diag,
            int n, 
            ArrayView<float> ap,
            ArrayView1D<float, Stride1D.General> x)
        {
            EnsureAcceleratorBinding();

            CuBlasException.ThrowIfFailed(
                API.Stpsv_v2(
                    Handle,
                    uplo,
                    trans,
                    diag,
                    n,
                    LoadCuBlasAddress(ap),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Tpsv operation.
        /// </summary>
        public unsafe void Tpsv(
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            CuBlasDiagType diag,
            int n, 
            ArrayView<double> ap,
            ArrayView1D<double, Stride1D.General> x)
        {
            EnsureAcceleratorBinding();

            CuBlasException.ThrowIfFailed(
                API.Dtpsv_v2(
                    Handle,
                    uplo,
                    trans,
                    diag,
                    n,
                    LoadCuBlasAddress(ap),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Tpsv operation.
        /// </summary>
        public unsafe void Tpsv(
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            CuBlasDiagType diag,
            int n, 
            ArrayView<Float2> ap,
            ArrayView1D<Float2, Stride1D.General> x)
        {
            EnsureAcceleratorBinding();

            CuBlasException.ThrowIfFailed(
                API.Ctpsv_v2(
                    Handle,
                    uplo,
                    trans,
                    diag,
                    n,
                    LoadCuBlasAddress(ap),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Tpsv operation.
        /// </summary>
        public unsafe void Tpsv(
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            CuBlasDiagType diag,
            int n, 
            ArrayView<Double2> ap,
            ArrayView1D<Double2, Stride1D.General> x)
        {
            EnsureAcceleratorBinding();

            CuBlasException.ThrowIfFailed(
                API.Ztpsv_v2(
                    Handle,
                    uplo,
                    trans,
                    diag,
                    n,
                    LoadCuBlasAddress(ap),
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride));
        }


        /// <summary>
        /// Performs the CuBlas Trmv operation.
        /// </summary>
        public unsafe void Trmv(
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            CuBlasDiagType diag,
            int n, 
            ArrayView<float> a,
            int lda,
            ArrayView1D<float, Stride1D.General> x)
        {
            EnsureAcceleratorBinding();

            CuBlasException.ThrowIfFailed(
                API.Strmv_v2(
                    Handle,
                    uplo,
                    trans,
                    diag,
                    n,
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Trmv operation.
        /// </summary>
        public unsafe void Trmv(
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            CuBlasDiagType diag,
            int n, 
            ArrayView<double> a,
            int lda,
            ArrayView1D<double, Stride1D.General> x)
        {
            EnsureAcceleratorBinding();

            CuBlasException.ThrowIfFailed(
                API.Dtrmv_v2(
                    Handle,
                    uplo,
                    trans,
                    diag,
                    n,
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Trmv operation.
        /// </summary>
        public unsafe void Trmv(
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            CuBlasDiagType diag,
            int n, 
            ArrayView<Float2> a,
            int lda,
            ArrayView1D<Float2, Stride1D.General> x)
        {
            EnsureAcceleratorBinding();

            CuBlasException.ThrowIfFailed(
                API.Ctrmv_v2(
                    Handle,
                    uplo,
                    trans,
                    diag,
                    n,
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Trmv operation.
        /// </summary>
        public unsafe void Trmv(
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            CuBlasDiagType diag,
            int n, 
            ArrayView<Double2> a,
            int lda,
            ArrayView1D<Double2, Stride1D.General> x)
        {
            EnsureAcceleratorBinding();

            CuBlasException.ThrowIfFailed(
                API.Ztrmv_v2(
                    Handle,
                    uplo,
                    trans,
                    diag,
                    n,
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Trsv operation.
        /// </summary>
        public unsafe void Trsv(
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            CuBlasDiagType diag,
            int n, 
            ArrayView<float> a,
            int lda,
            ArrayView1D<float, Stride1D.General> x)
        {
            EnsureAcceleratorBinding();

            CuBlasException.ThrowIfFailed(
                API.Strsv_v2(
                    Handle,
                    uplo,
                    trans,
                    diag,
                    n,
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Trsv operation.
        /// </summary>
        public unsafe void Trsv(
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            CuBlasDiagType diag,
            int n, 
            ArrayView<double> a,
            int lda,
            ArrayView1D<double, Stride1D.General> x)
        {
            EnsureAcceleratorBinding();

            CuBlasException.ThrowIfFailed(
                API.Dtrsv_v2(
                    Handle,
                    uplo,
                    trans,
                    diag,
                    n,
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Trsv operation.
        /// </summary>
        public unsafe void Trsv(
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            CuBlasDiagType diag,
            int n, 
            ArrayView<Float2> a,
            int lda,
            ArrayView1D<Float2, Stride1D.General> x)
        {
            EnsureAcceleratorBinding();

            CuBlasException.ThrowIfFailed(
                API.Ctrsv_v2(
                    Handle,
                    uplo,
                    trans,
                    diag,
                    n,
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride));
        }

        /// <summary>
        /// Performs the CuBlas Trsv operation.
        /// </summary>
        public unsafe void Trsv(
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            CuBlasDiagType diag,
            int n, 
            ArrayView<Double2> a,
            int lda,
            ArrayView1D<Double2, Stride1D.General> x)
        {
            EnsureAcceleratorBinding();

            CuBlasException.ThrowIfFailed(
                API.Ztrsv_v2(
                    Handle,
                    uplo,
                    trans,
                    diag,
                    n,
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride));
        }

    }
}