// ---------------------------------------------------------------------------------------
//                                   ILGPU Algorithms
//                        Copyright (c) 2020-2021 ILGPU Project
//                                    www.ilgpu.net
//
// File: CuBlasMethodsLevel3.tt/CuBlasMethodsLevel3.cs
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
        /// Performs the CuBlas Gemm operation.
        /// </summary>
        public unsafe void Gemm(
            CuBlasOperation transa,
            CuBlasOperation transb,
            int m, 
            int n,
            int k,
            float alpha,
            ArrayView<float> a,
            int lda,
            ArrayView<float> b,
            int ldb,
            float beta,
            ArrayView<float> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Sgemm_v2(
                    Handle,
                    transa,
                    transb,
                    m,
                    n,
                    k,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(b),
                    ldb,
                    Unsafe.AsPointer(ref beta),
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Gemm operation.
        /// </summary>
        public unsafe void Gemm(
            CuBlasOperation transa,
            CuBlasOperation transb,
            int m, 
            int n,
            int k,
            ArrayView<float> alpha,
            ArrayView<float> a,
            int lda,
            ArrayView<float> b,
            int ldb,
            ArrayView<float> beta,
            ArrayView<float> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Sgemm_v2(
                    Handle,
                    transa,
                    transb,
                    m,
                    n,
                    k,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(b),
                    ldb,
                    LoadCuBlasAddress(beta),
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Gemm operation.
        /// </summary>
        public unsafe void Gemm(
            CuBlasOperation transa,
            CuBlasOperation transb,
            int m, 
            int n,
            int k,
            double alpha,
            ArrayView<double> a,
            int lda,
            ArrayView<double> b,
            int ldb,
            double beta,
            ArrayView<double> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Dgemm_v2(
                    Handle,
                    transa,
                    transb,
                    m,
                    n,
                    k,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(b),
                    ldb,
                    Unsafe.AsPointer(ref beta),
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Gemm operation.
        /// </summary>
        public unsafe void Gemm(
            CuBlasOperation transa,
            CuBlasOperation transb,
            int m, 
            int n,
            int k,
            ArrayView<double> alpha,
            ArrayView<double> a,
            int lda,
            ArrayView<double> b,
            int ldb,
            ArrayView<double> beta,
            ArrayView<double> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Dgemm_v2(
                    Handle,
                    transa,
                    transb,
                    m,
                    n,
                    k,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(b),
                    ldb,
                    LoadCuBlasAddress(beta),
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Gemm operation.
        /// </summary>
        public unsafe void Gemm(
            CuBlasOperation transa,
            CuBlasOperation transb,
            int m, 
            int n,
            int k,
            Float2 alpha,
            ArrayView<Float2> a,
            int lda,
            ArrayView<Float2> b,
            int ldb,
            Float2 beta,
            ArrayView<Float2> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Cgemm_v2(
                    Handle,
                    transa,
                    transb,
                    m,
                    n,
                    k,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(b),
                    ldb,
                    Unsafe.AsPointer(ref beta),
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Gemm operation.
        /// </summary>
        public unsafe void Gemm(
            CuBlasOperation transa,
            CuBlasOperation transb,
            int m, 
            int n,
            int k,
            ArrayView<Float2> alpha,
            ArrayView<Float2> a,
            int lda,
            ArrayView<Float2> b,
            int ldb,
            ArrayView<Float2> beta,
            ArrayView<Float2> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Cgemm_v2(
                    Handle,
                    transa,
                    transb,
                    m,
                    n,
                    k,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(b),
                    ldb,
                    LoadCuBlasAddress(beta),
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Gemm operation.
        /// </summary>
        public unsafe void Gemm(
            CuBlasOperation transa,
            CuBlasOperation transb,
            int m, 
            int n,
            int k,
            Double2 alpha,
            ArrayView<Double2> a,
            int lda,
            ArrayView<Double2> b,
            int ldb,
            Double2 beta,
            ArrayView<Double2> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Zgemm_v2(
                    Handle,
                    transa,
                    transb,
                    m,
                    n,
                    k,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(b),
                    ldb,
                    Unsafe.AsPointer(ref beta),
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Gemm operation.
        /// </summary>
        public unsafe void Gemm(
            CuBlasOperation transa,
            CuBlasOperation transb,
            int m, 
            int n,
            int k,
            ArrayView<Double2> alpha,
            ArrayView<Double2> a,
            int lda,
            ArrayView<Double2> b,
            int ldb,
            ArrayView<Double2> beta,
            ArrayView<Double2> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Zgemm_v2(
                    Handle,
                    transa,
                    transb,
                    m,
                    n,
                    k,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(b),
                    ldb,
                    LoadCuBlasAddress(beta),
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Gemm operation.
        /// </summary>
        public unsafe void Gemm(
            CuBlasOperation transa,
            CuBlasOperation transb,
            int m, 
            int n,
            int k,
            Half alpha,
            ArrayView<Half> a,
            int lda,
            ArrayView<Half> b,
            int ldb,
            Half beta,
            ArrayView<Half> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Hgemm(
                    Handle,
                    transa,
                    transb,
                    m,
                    n,
                    k,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(b),
                    ldb,
                    Unsafe.AsPointer(ref beta),
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Gemm operation.
        /// </summary>
        public unsafe void Gemm(
            CuBlasOperation transa,
            CuBlasOperation transb,
            int m, 
            int n,
            int k,
            ArrayView<Half> alpha,
            ArrayView<Half> a,
            int lda,
            ArrayView<Half> b,
            int ldb,
            ArrayView<Half> beta,
            ArrayView<Half> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Hgemm(
                    Handle,
                    transa,
                    transb,
                    m,
                    n,
                    k,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(b),
                    ldb,
                    LoadCuBlasAddress(beta),
                    LoadCuBlasAddress(c),
                    ldc));
        }


        /// <summary>
        /// Performs the CuBlas Symm operation.
        /// </summary>
        public unsafe void Symm(
            CuBlasSideMode side,
            CuBlasFillMode uplo,
            int m, 
            int n,
            float alpha,
            ArrayView<float> a,
            int lda,
            ArrayView<float> b,
            int ldb,
            float beta,
            ArrayView<float> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Ssymm_v2(
                    Handle,
                    side,
                    uplo,
                    m,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(b),
                    ldb,
                    Unsafe.AsPointer(ref beta),
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Symm operation.
        /// </summary>
        public unsafe void Symm(
            CuBlasSideMode side,
            CuBlasFillMode uplo,
            int m, 
            int n,
            ArrayView<float> alpha,
            ArrayView<float> a,
            int lda,
            ArrayView<float> b,
            int ldb,
            ArrayView<float> beta,
            ArrayView<float> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Ssymm_v2(
                    Handle,
                    side,
                    uplo,
                    m,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(b),
                    ldb,
                    LoadCuBlasAddress(beta),
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Symm operation.
        /// </summary>
        public unsafe void Symm(
            CuBlasSideMode side,
            CuBlasFillMode uplo,
            int m, 
            int n,
            double alpha,
            ArrayView<double> a,
            int lda,
            ArrayView<double> b,
            int ldb,
            double beta,
            ArrayView<double> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Dsymm_v2(
                    Handle,
                    side,
                    uplo,
                    m,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(b),
                    ldb,
                    Unsafe.AsPointer(ref beta),
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Symm operation.
        /// </summary>
        public unsafe void Symm(
            CuBlasSideMode side,
            CuBlasFillMode uplo,
            int m, 
            int n,
            ArrayView<double> alpha,
            ArrayView<double> a,
            int lda,
            ArrayView<double> b,
            int ldb,
            ArrayView<double> beta,
            ArrayView<double> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Dsymm_v2(
                    Handle,
                    side,
                    uplo,
                    m,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(b),
                    ldb,
                    LoadCuBlasAddress(beta),
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Symm operation.
        /// </summary>
        public unsafe void Symm(
            CuBlasSideMode side,
            CuBlasFillMode uplo,
            int m, 
            int n,
            Float2 alpha,
            ArrayView<Float2> a,
            int lda,
            ArrayView<Float2> b,
            int ldb,
            Float2 beta,
            ArrayView<Float2> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Csymm_v2(
                    Handle,
                    side,
                    uplo,
                    m,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(b),
                    ldb,
                    Unsafe.AsPointer(ref beta),
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Symm operation.
        /// </summary>
        public unsafe void Symm(
            CuBlasSideMode side,
            CuBlasFillMode uplo,
            int m, 
            int n,
            ArrayView<Float2> alpha,
            ArrayView<Float2> a,
            int lda,
            ArrayView<Float2> b,
            int ldb,
            ArrayView<Float2> beta,
            ArrayView<Float2> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Csymm_v2(
                    Handle,
                    side,
                    uplo,
                    m,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(b),
                    ldb,
                    LoadCuBlasAddress(beta),
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Symm operation.
        /// </summary>
        public unsafe void Symm(
            CuBlasSideMode side,
            CuBlasFillMode uplo,
            int m, 
            int n,
            Double2 alpha,
            ArrayView<Double2> a,
            int lda,
            ArrayView<Double2> b,
            int ldb,
            Double2 beta,
            ArrayView<Double2> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Zsymm_v2(
                    Handle,
                    side,
                    uplo,
                    m,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(b),
                    ldb,
                    Unsafe.AsPointer(ref beta),
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Symm operation.
        /// </summary>
        public unsafe void Symm(
            CuBlasSideMode side,
            CuBlasFillMode uplo,
            int m, 
            int n,
            ArrayView<Double2> alpha,
            ArrayView<Double2> a,
            int lda,
            ArrayView<Double2> b,
            int ldb,
            ArrayView<Double2> beta,
            ArrayView<Double2> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Zsymm_v2(
                    Handle,
                    side,
                    uplo,
                    m,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(b),
                    ldb,
                    LoadCuBlasAddress(beta),
                    LoadCuBlasAddress(c),
                    ldc));
        }


        /// <summary>
        /// Performs the CuBlas Syrk operation.
        /// </summary>
        public unsafe void Syrk(
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            int m, 
            int n,
            float alpha,
            ArrayView<float> a,
            int lda,
            float beta,
            ArrayView<float> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Ssyrk_v2(
                    Handle,
                    uplo,
                    trans,
                    m,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    Unsafe.AsPointer(ref beta),
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Syrk operation.
        /// </summary>
        public unsafe void Syrk(
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            int m, 
            int n,
            ArrayView<float> alpha,
            ArrayView<float> a,
            int lda,
            ArrayView<float> beta,
            ArrayView<float> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Ssyrk_v2(
                    Handle,
                    uplo,
                    trans,
                    m,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(beta),
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Syrk operation.
        /// </summary>
        public unsafe void Syrk(
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            int m, 
            int n,
            double alpha,
            ArrayView<double> a,
            int lda,
            double beta,
            ArrayView<double> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Dsyrk_v2(
                    Handle,
                    uplo,
                    trans,
                    m,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    Unsafe.AsPointer(ref beta),
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Syrk operation.
        /// </summary>
        public unsafe void Syrk(
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            int m, 
            int n,
            ArrayView<double> alpha,
            ArrayView<double> a,
            int lda,
            ArrayView<double> beta,
            ArrayView<double> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Dsyrk_v2(
                    Handle,
                    uplo,
                    trans,
                    m,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(beta),
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Syrk operation.
        /// </summary>
        public unsafe void Syrk(
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            int m, 
            int n,
            Float2 alpha,
            ArrayView<Float2> a,
            int lda,
            Float2 beta,
            ArrayView<Float2> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Csyrk_v2(
                    Handle,
                    uplo,
                    trans,
                    m,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    Unsafe.AsPointer(ref beta),
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Syrk operation.
        /// </summary>
        public unsafe void Syrk(
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            int m, 
            int n,
            ArrayView<Float2> alpha,
            ArrayView<Float2> a,
            int lda,
            ArrayView<Float2> beta,
            ArrayView<Float2> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Csyrk_v2(
                    Handle,
                    uplo,
                    trans,
                    m,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(beta),
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Syrk operation.
        /// </summary>
        public unsafe void Syrk(
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            int m, 
            int n,
            Double2 alpha,
            ArrayView<Double2> a,
            int lda,
            Double2 beta,
            ArrayView<Double2> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Zsyrk_v2(
                    Handle,
                    uplo,
                    trans,
                    m,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    Unsafe.AsPointer(ref beta),
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Syrk operation.
        /// </summary>
        public unsafe void Syrk(
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            int m, 
            int n,
            ArrayView<Double2> alpha,
            ArrayView<Double2> a,
            int lda,
            ArrayView<Double2> beta,
            ArrayView<Double2> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Zsyrk_v2(
                    Handle,
                    uplo,
                    trans,
                    m,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(beta),
                    LoadCuBlasAddress(c),
                    ldc));
        }


        /// <summary>
        /// Performs the CuBlas Syr2k operation.
        /// </summary>
        public unsafe void Syr2k(
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            int n, 
            int k,
            float alpha,
            ArrayView<float> a,
            int lda,
            ArrayView<float> b,
            int ldb,
            float beta,
            ArrayView<float> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Ssyr2k_v2(
                    Handle,
                    uplo,
                    trans,
                    n,
                    k,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(b),
                    ldb,
                    Unsafe.AsPointer(ref beta),
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Syr2k operation.
        /// </summary>
        public unsafe void Syr2k(
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            int n, 
            int k,
            ArrayView<float> alpha,
            ArrayView<float> a,
            int lda,
            ArrayView<float> b,
            int ldb,
            ArrayView<float> beta,
            ArrayView<float> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Ssyr2k_v2(
                    Handle,
                    uplo,
                    trans,
                    n,
                    k,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(b),
                    ldb,
                    LoadCuBlasAddress(beta),
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Syr2k operation.
        /// </summary>
        public unsafe void Syr2k(
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            int n, 
            int k,
            double alpha,
            ArrayView<double> a,
            int lda,
            ArrayView<double> b,
            int ldb,
            double beta,
            ArrayView<double> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Dsyr2k_v2(
                    Handle,
                    uplo,
                    trans,
                    n,
                    k,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(b),
                    ldb,
                    Unsafe.AsPointer(ref beta),
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Syr2k operation.
        /// </summary>
        public unsafe void Syr2k(
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            int n, 
            int k,
            ArrayView<double> alpha,
            ArrayView<double> a,
            int lda,
            ArrayView<double> b,
            int ldb,
            ArrayView<double> beta,
            ArrayView<double> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Dsyr2k_v2(
                    Handle,
                    uplo,
                    trans,
                    n,
                    k,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(b),
                    ldb,
                    LoadCuBlasAddress(beta),
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Syr2k operation.
        /// </summary>
        public unsafe void Syr2k(
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            int n, 
            int k,
            Float2 alpha,
            ArrayView<Float2> a,
            int lda,
            ArrayView<Float2> b,
            int ldb,
            Float2 beta,
            ArrayView<Float2> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Csyr2k_v2(
                    Handle,
                    uplo,
                    trans,
                    n,
                    k,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(b),
                    ldb,
                    Unsafe.AsPointer(ref beta),
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Syr2k operation.
        /// </summary>
        public unsafe void Syr2k(
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            int n, 
            int k,
            ArrayView<Float2> alpha,
            ArrayView<Float2> a,
            int lda,
            ArrayView<Float2> b,
            int ldb,
            ArrayView<Float2> beta,
            ArrayView<Float2> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Csyr2k_v2(
                    Handle,
                    uplo,
                    trans,
                    n,
                    k,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(b),
                    ldb,
                    LoadCuBlasAddress(beta),
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Syr2k operation.
        /// </summary>
        public unsafe void Syr2k(
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            int n, 
            int k,
            Double2 alpha,
            ArrayView<Double2> a,
            int lda,
            ArrayView<Double2> b,
            int ldb,
            Double2 beta,
            ArrayView<Double2> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Zsyr2k_v2(
                    Handle,
                    uplo,
                    trans,
                    n,
                    k,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(b),
                    ldb,
                    Unsafe.AsPointer(ref beta),
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Syr2k operation.
        /// </summary>
        public unsafe void Syr2k(
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            int n, 
            int k,
            ArrayView<Double2> alpha,
            ArrayView<Double2> a,
            int lda,
            ArrayView<Double2> b,
            int ldb,
            ArrayView<Double2> beta,
            ArrayView<Double2> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Zsyr2k_v2(
                    Handle,
                    uplo,
                    trans,
                    n,
                    k,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(b),
                    ldb,
                    LoadCuBlasAddress(beta),
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Syrkx operation.
        /// </summary>
        public unsafe void Syrkx(
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            int n, 
            int k,
            float alpha,
            ArrayView<float> a,
            int lda,
            ArrayView<float> b,
            int ldb,
            float beta,
            ArrayView<float> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Ssyrkx(
                    Handle,
                    uplo,
                    trans,
                    n,
                    k,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(b),
                    ldb,
                    Unsafe.AsPointer(ref beta),
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Syrkx operation.
        /// </summary>
        public unsafe void Syrkx(
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            int n, 
            int k,
            ArrayView<float> alpha,
            ArrayView<float> a,
            int lda,
            ArrayView<float> b,
            int ldb,
            ArrayView<float> beta,
            ArrayView<float> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Ssyrkx(
                    Handle,
                    uplo,
                    trans,
                    n,
                    k,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(b),
                    ldb,
                    LoadCuBlasAddress(beta),
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Syrkx operation.
        /// </summary>
        public unsafe void Syrkx(
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            int n, 
            int k,
            double alpha,
            ArrayView<double> a,
            int lda,
            ArrayView<double> b,
            int ldb,
            double beta,
            ArrayView<double> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Dsyrkx(
                    Handle,
                    uplo,
                    trans,
                    n,
                    k,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(b),
                    ldb,
                    Unsafe.AsPointer(ref beta),
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Syrkx operation.
        /// </summary>
        public unsafe void Syrkx(
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            int n, 
            int k,
            ArrayView<double> alpha,
            ArrayView<double> a,
            int lda,
            ArrayView<double> b,
            int ldb,
            ArrayView<double> beta,
            ArrayView<double> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Dsyrkx(
                    Handle,
                    uplo,
                    trans,
                    n,
                    k,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(b),
                    ldb,
                    LoadCuBlasAddress(beta),
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Syrkx operation.
        /// </summary>
        public unsafe void Syrkx(
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            int n, 
            int k,
            Float2 alpha,
            ArrayView<Float2> a,
            int lda,
            ArrayView<Float2> b,
            int ldb,
            Float2 beta,
            ArrayView<Float2> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Csyrkx(
                    Handle,
                    uplo,
                    trans,
                    n,
                    k,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(b),
                    ldb,
                    Unsafe.AsPointer(ref beta),
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Syrkx operation.
        /// </summary>
        public unsafe void Syrkx(
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            int n, 
            int k,
            ArrayView<Float2> alpha,
            ArrayView<Float2> a,
            int lda,
            ArrayView<Float2> b,
            int ldb,
            ArrayView<Float2> beta,
            ArrayView<Float2> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Csyrkx(
                    Handle,
                    uplo,
                    trans,
                    n,
                    k,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(b),
                    ldb,
                    LoadCuBlasAddress(beta),
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Syrkx operation.
        /// </summary>
        public unsafe void Syrkx(
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            int n, 
            int k,
            Double2 alpha,
            ArrayView<Double2> a,
            int lda,
            ArrayView<Double2> b,
            int ldb,
            Double2 beta,
            ArrayView<Double2> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Zsyrkx(
                    Handle,
                    uplo,
                    trans,
                    n,
                    k,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(b),
                    ldb,
                    Unsafe.AsPointer(ref beta),
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Syrkx operation.
        /// </summary>
        public unsafe void Syrkx(
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            int n, 
            int k,
            ArrayView<Double2> alpha,
            ArrayView<Double2> a,
            int lda,
            ArrayView<Double2> b,
            int ldb,
            ArrayView<Double2> beta,
            ArrayView<Double2> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Zsyrkx(
                    Handle,
                    uplo,
                    trans,
                    n,
                    k,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(b),
                    ldb,
                    LoadCuBlasAddress(beta),
                    LoadCuBlasAddress(c),
                    ldc));
        }


        /// <summary>
        /// Performs the CuBlas Trmm operation.
        /// </summary>
        public unsafe void Trmm(
            CuBlasSideMode side,
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            CuBlasDiagType diag,
            int m,
            int n,
            float alpha,
            ArrayView<float> a,
            int lda,
            ArrayView<float> b,
            int ldb,
            ArrayView<float> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Strmm_v2(
                    Handle,
                    side,
                    uplo,
                    trans,
                    diag,
                    m,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(b),
                    ldb,
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Trmm operation.
        /// </summary>
        public unsafe void Trmm(
            CuBlasSideMode side,
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            CuBlasDiagType diag,
            int m,
            int n,
            ArrayView<float> alpha,
            ArrayView<float> a,
            int lda,
            ArrayView<float> b,
            int ldb,
            ArrayView<float> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Strmm_v2(
                    Handle,
                    side,
                    uplo,
                    trans,
                    diag,
                    m,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(b),
                    ldb,
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Trmm operation.
        /// </summary>
        public unsafe void Trmm(
            CuBlasSideMode side,
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            CuBlasDiagType diag,
            int m,
            int n,
            double alpha,
            ArrayView<double> a,
            int lda,
            ArrayView<double> b,
            int ldb,
            ArrayView<double> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Dtrmm_v2(
                    Handle,
                    side,
                    uplo,
                    trans,
                    diag,
                    m,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(b),
                    ldb,
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Trmm operation.
        /// </summary>
        public unsafe void Trmm(
            CuBlasSideMode side,
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            CuBlasDiagType diag,
            int m,
            int n,
            ArrayView<double> alpha,
            ArrayView<double> a,
            int lda,
            ArrayView<double> b,
            int ldb,
            ArrayView<double> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Dtrmm_v2(
                    Handle,
                    side,
                    uplo,
                    trans,
                    diag,
                    m,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(b),
                    ldb,
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Trmm operation.
        /// </summary>
        public unsafe void Trmm(
            CuBlasSideMode side,
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            CuBlasDiagType diag,
            int m,
            int n,
            Float2 alpha,
            ArrayView<Float2> a,
            int lda,
            ArrayView<Float2> b,
            int ldb,
            ArrayView<Float2> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Ctrmm_v2(
                    Handle,
                    side,
                    uplo,
                    trans,
                    diag,
                    m,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(b),
                    ldb,
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Trmm operation.
        /// </summary>
        public unsafe void Trmm(
            CuBlasSideMode side,
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            CuBlasDiagType diag,
            int m,
            int n,
            ArrayView<Float2> alpha,
            ArrayView<Float2> a,
            int lda,
            ArrayView<Float2> b,
            int ldb,
            ArrayView<Float2> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Ctrmm_v2(
                    Handle,
                    side,
                    uplo,
                    trans,
                    diag,
                    m,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(b),
                    ldb,
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Trmm operation.
        /// </summary>
        public unsafe void Trmm(
            CuBlasSideMode side,
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            CuBlasDiagType diag,
            int m,
            int n,
            Double2 alpha,
            ArrayView<Double2> a,
            int lda,
            ArrayView<Double2> b,
            int ldb,
            ArrayView<Double2> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Ztrmm_v2(
                    Handle,
                    side,
                    uplo,
                    trans,
                    diag,
                    m,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(b),
                    ldb,
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Trmm operation.
        /// </summary>
        public unsafe void Trmm(
            CuBlasSideMode side,
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            CuBlasDiagType diag,
            int m,
            int n,
            ArrayView<Double2> alpha,
            ArrayView<Double2> a,
            int lda,
            ArrayView<Double2> b,
            int ldb,
            ArrayView<Double2> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Ztrmm_v2(
                    Handle,
                    side,
                    uplo,
                    trans,
                    diag,
                    m,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(b),
                    ldb,
                    LoadCuBlasAddress(c),
                    ldc));
        }


        /// <summary>
        /// Performs the CuBlas Trsm operation.
        /// </summary>
        public unsafe void Trsm(
            CuBlasSideMode side,
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            CuBlasDiagType diag,
            int m,
            int n,
            float alpha,
            ArrayView<float> a,
            int lda,
            ArrayView<float> b,
            int ldb)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Strsm_v2(
                    Handle,
                    side,
                    uplo,
                    trans,
                    diag,
                    m,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(b),
                    ldb));
        }

        /// <summary>
        /// Performs the CuBlas Trsm operation.
        /// </summary>
        public unsafe void Trsm(
            CuBlasSideMode side,
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            CuBlasDiagType diag,
            int m,
            int n,
            ArrayView<float> alpha,
            ArrayView<float> a,
            int lda,
            ArrayView<float> b,
            int ldb)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Strsm_v2(
                    Handle,
                    side,
                    uplo,
                    trans,
                    diag,
                    m,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(b),
                    ldb));
        }

        /// <summary>
        /// Performs the CuBlas Trsm operation.
        /// </summary>
        public unsafe void Trsm(
            CuBlasSideMode side,
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            CuBlasDiagType diag,
            int m,
            int n,
            double alpha,
            ArrayView<double> a,
            int lda,
            ArrayView<double> b,
            int ldb)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Dtrsm_v2(
                    Handle,
                    side,
                    uplo,
                    trans,
                    diag,
                    m,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(b),
                    ldb));
        }

        /// <summary>
        /// Performs the CuBlas Trsm operation.
        /// </summary>
        public unsafe void Trsm(
            CuBlasSideMode side,
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            CuBlasDiagType diag,
            int m,
            int n,
            ArrayView<double> alpha,
            ArrayView<double> a,
            int lda,
            ArrayView<double> b,
            int ldb)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Dtrsm_v2(
                    Handle,
                    side,
                    uplo,
                    trans,
                    diag,
                    m,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(b),
                    ldb));
        }

        /// <summary>
        /// Performs the CuBlas Trsm operation.
        /// </summary>
        public unsafe void Trsm(
            CuBlasSideMode side,
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            CuBlasDiagType diag,
            int m,
            int n,
            Float2 alpha,
            ArrayView<Float2> a,
            int lda,
            ArrayView<Float2> b,
            int ldb)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Ctrsm_v2(
                    Handle,
                    side,
                    uplo,
                    trans,
                    diag,
                    m,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(b),
                    ldb));
        }

        /// <summary>
        /// Performs the CuBlas Trsm operation.
        /// </summary>
        public unsafe void Trsm(
            CuBlasSideMode side,
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            CuBlasDiagType diag,
            int m,
            int n,
            ArrayView<Float2> alpha,
            ArrayView<Float2> a,
            int lda,
            ArrayView<Float2> b,
            int ldb)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Ctrsm_v2(
                    Handle,
                    side,
                    uplo,
                    trans,
                    diag,
                    m,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(b),
                    ldb));
        }

        /// <summary>
        /// Performs the CuBlas Trsm operation.
        /// </summary>
        public unsafe void Trsm(
            CuBlasSideMode side,
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            CuBlasDiagType diag,
            int m,
            int n,
            Double2 alpha,
            ArrayView<Double2> a,
            int lda,
            ArrayView<Double2> b,
            int ldb)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Ztrsm_v2(
                    Handle,
                    side,
                    uplo,
                    trans,
                    diag,
                    m,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(b),
                    ldb));
        }

        /// <summary>
        /// Performs the CuBlas Trsm operation.
        /// </summary>
        public unsafe void Trsm(
            CuBlasSideMode side,
            CuBlasFillMode uplo,
            CuBlasOperation trans,
            CuBlasDiagType diag,
            int m,
            int n,
            ArrayView<Double2> alpha,
            ArrayView<Double2> a,
            int lda,
            ArrayView<Double2> b,
            int ldb)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Ztrsm_v2(
                    Handle,
                    side,
                    uplo,
                    trans,
                    diag,
                    m,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(b),
                    ldb));
        }


        /// <summary>
        /// Performs the CuBlas Geam operation.
        /// </summary>
        public unsafe void Geam(
            CuBlasOperation transa,
            CuBlasOperation transb,
            int m,
            int n,
            float alpha,
            ArrayView<float> a,
            int lda,
            float beta,
            ArrayView<float> b,
            int ldb,
            ArrayView<float> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Sgeam(
                    Handle,
                    transa,
                    transb,
                    m,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    Unsafe.AsPointer(ref beta),
                    LoadCuBlasAddress(b),
                    ldb,
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Geam operation.
        /// </summary>
        public unsafe void Geam(
            CuBlasOperation transa,
            CuBlasOperation transb,
            int m,
            int n,
            ArrayView<float> alpha,
            ArrayView<float> a,
            int lda,
            ArrayView<float> beta,
            ArrayView<float> b,
            int ldb,
            ArrayView<float> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Sgeam(
                    Handle,
                    transa,
                    transb,
                    m,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(beta),
                    LoadCuBlasAddress(b),
                    ldb,
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Geam operation.
        /// </summary>
        public unsafe void Geam(
            CuBlasOperation transa,
            CuBlasOperation transb,
            int m,
            int n,
            double alpha,
            ArrayView<double> a,
            int lda,
            double beta,
            ArrayView<double> b,
            int ldb,
            ArrayView<double> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Dgeam(
                    Handle,
                    transa,
                    transb,
                    m,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    Unsafe.AsPointer(ref beta),
                    LoadCuBlasAddress(b),
                    ldb,
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Geam operation.
        /// </summary>
        public unsafe void Geam(
            CuBlasOperation transa,
            CuBlasOperation transb,
            int m,
            int n,
            ArrayView<double> alpha,
            ArrayView<double> a,
            int lda,
            ArrayView<double> beta,
            ArrayView<double> b,
            int ldb,
            ArrayView<double> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Dgeam(
                    Handle,
                    transa,
                    transb,
                    m,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(beta),
                    LoadCuBlasAddress(b),
                    ldb,
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Geam operation.
        /// </summary>
        public unsafe void Geam(
            CuBlasOperation transa,
            CuBlasOperation transb,
            int m,
            int n,
            Float2 alpha,
            ArrayView<Float2> a,
            int lda,
            Float2 beta,
            ArrayView<Float2> b,
            int ldb,
            ArrayView<Float2> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Cgeam(
                    Handle,
                    transa,
                    transb,
                    m,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    Unsafe.AsPointer(ref beta),
                    LoadCuBlasAddress(b),
                    ldb,
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Geam operation.
        /// </summary>
        public unsafe void Geam(
            CuBlasOperation transa,
            CuBlasOperation transb,
            int m,
            int n,
            ArrayView<Float2> alpha,
            ArrayView<Float2> a,
            int lda,
            ArrayView<Float2> beta,
            ArrayView<Float2> b,
            int ldb,
            ArrayView<Float2> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Cgeam(
                    Handle,
                    transa,
                    transb,
                    m,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(beta),
                    LoadCuBlasAddress(b),
                    ldb,
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Geam operation.
        /// </summary>
        public unsafe void Geam(
            CuBlasOperation transa,
            CuBlasOperation transb,
            int m,
            int n,
            Double2 alpha,
            ArrayView<Double2> a,
            int lda,
            Double2 beta,
            ArrayView<Double2> b,
            int ldb,
            ArrayView<Double2> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Host);

            CuBlasException.ThrowIfFailed(
                API.Zgeam(
                    Handle,
                    transa,
                    transb,
                    m,
                    n,
                    Unsafe.AsPointer(ref alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    Unsafe.AsPointer(ref beta),
                    LoadCuBlasAddress(b),
                    ldb,
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Geam operation.
        /// </summary>
        public unsafe void Geam(
            CuBlasOperation transa,
            CuBlasOperation transb,
            int m,
            int n,
            ArrayView<Double2> alpha,
            ArrayView<Double2> a,
            int lda,
            ArrayView<Double2> beta,
            ArrayView<Double2> b,
            int ldb,
            ArrayView<Double2> c,
            int ldc)
        {
            EnsureAcceleratorBinding();
            EnsurePointerMode(CuBlasPointerMode.Device);

            CuBlasException.ThrowIfFailed(
                API.Zgeam(
                    Handle,
                    transa,
                    transb,
                    m,
                    n,
                    LoadCuBlasAddress(alpha),
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(beta),
                    LoadCuBlasAddress(b),
                    ldb,
                    LoadCuBlasAddress(c),
                    ldc));
        }


        /// <summary>
        /// Performs the CuBlas Dgmm operation.
        /// </summary>
        public unsafe void Dgmm(
            CuBlasSideMode mode,
            int m,
            int n,
            ArrayView<float> a,
            int lda,
            ArrayView1D<float, Stride1D.General> x,
            ArrayView<float> c,
            int ldc)
        {
            EnsureAcceleratorBinding();

            CuBlasException.ThrowIfFailed(
                API.Sdgmm(
                    Handle,
                    mode,
                    m,
                    n,
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Dgmm operation.
        /// </summary>
        public unsafe void Dgmm(
            CuBlasSideMode mode,
            int m,
            int n,
            ArrayView<double> a,
            int lda,
            ArrayView1D<double, Stride1D.General> x,
            ArrayView<double> c,
            int ldc)
        {
            EnsureAcceleratorBinding();

            CuBlasException.ThrowIfFailed(
                API.Ddgmm(
                    Handle,
                    mode,
                    m,
                    n,
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Dgmm operation.
        /// </summary>
        public unsafe void Dgmm(
            CuBlasSideMode mode,
            int m,
            int n,
            ArrayView<Float2> a,
            int lda,
            ArrayView1D<Float2, Stride1D.General> x,
            ArrayView<Float2> c,
            int ldc)
        {
            EnsureAcceleratorBinding();

            CuBlasException.ThrowIfFailed(
                API.Cdgmm(
                    Handle,
                    mode,
                    m,
                    n,
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(c),
                    ldc));
        }

        /// <summary>
        /// Performs the CuBlas Dgmm operation.
        /// </summary>
        public unsafe void Dgmm(
            CuBlasSideMode mode,
            int m,
            int n,
            ArrayView<Double2> a,
            int lda,
            ArrayView1D<Double2, Stride1D.General> x,
            ArrayView<Double2> c,
            int ldc)
        {
            EnsureAcceleratorBinding();

            CuBlasException.ThrowIfFailed(
                API.Zdgmm(
                    Handle,
                    mode,
                    m,
                    n,
                    LoadCuBlasAddress(a),
                    lda,
                    LoadCuBlasAddress(x.BaseView),
                    x.Stride.XStride,
                    LoadCuBlasAddress(c),
                    ldc));
        }

    }
}