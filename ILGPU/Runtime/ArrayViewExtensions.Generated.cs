// ---------------------------------------------------------------------------------------
//                                        ILGPU
//                        Copyright (c) 2016-2024 ILGPU Project
//                                    www.ilgpu.net
//
// File: ArrayViewExtensions.Generated.tt/ArrayViewExtensions.Generated.cs
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

using ILGPU.Resources;
using System;
using System.Runtime.CompilerServices;

namespace ILGPU.Runtime
{
    partial class ArrayViewExtensions
    {
        #region Cast Methods

        /// <summary>
        /// Casts the given array view into another array-view type.
        /// </summary>
        /// <typeparam name="T">The current element type.</typeparam>
        /// <typeparam name="TOther">The target element type.</typeparam>
        /// <returns>The casted array view.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArrayView1D<TOther, Stride1D.Dense> Cast<T, TOther>(
            this ArrayView1D<T, Stride1D.Dense> view)
            where T : unmanaged
            where TOther : unmanaged
        {
            var (extent, stride) = view.Stride.Cast(
                StrideExtensions.CreateCastContext(
                    ArrayView<T>.ElementSize,
                    ArrayView<TOther>.ElementSize),
                view.Extent);
            return new ArrayView1D<TOther, Stride1D.Dense>(
                view.BaseView.Cast<TOther>(),
                extent,
                stride);
        }

        /// <summary>
        /// Casts the given array view into another array-view type.
        /// </summary>
        /// <typeparam name="T">The current element type.</typeparam>
        /// <typeparam name="TOther">The target element type.</typeparam>
        /// <returns>The casted array view.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArrayView2D<TOther, Stride2D.DenseX> Cast<T, TOther>(
            this ArrayView2D<T, Stride2D.DenseX> view)
            where T : unmanaged
            where TOther : unmanaged
        {
            var (extent, stride) = view.Stride.Cast(
                StrideExtensions.CreateCastContext(
                    ArrayView<T>.ElementSize,
                    ArrayView<TOther>.ElementSize),
                view.Extent);
            return new ArrayView2D<TOther, Stride2D.DenseX>(
                view.BaseView.Cast<TOther>(),
                extent,
                stride);
        }

        /// <summary>
        /// Casts the given array view into another array-view type.
        /// </summary>
        /// <typeparam name="T">The current element type.</typeparam>
        /// <typeparam name="TOther">The target element type.</typeparam>
        /// <returns>The casted array view.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArrayView2D<TOther, Stride2D.DenseY> Cast<T, TOther>(
            this ArrayView2D<T, Stride2D.DenseY> view)
            where T : unmanaged
            where TOther : unmanaged
        {
            var (extent, stride) = view.Stride.Cast(
                StrideExtensions.CreateCastContext(
                    ArrayView<T>.ElementSize,
                    ArrayView<TOther>.ElementSize),
                view.Extent);
            return new ArrayView2D<TOther, Stride2D.DenseY>(
                view.BaseView.Cast<TOther>(),
                extent,
                stride);
        }

        /// <summary>
        /// Casts the given array view into another array-view type.
        /// </summary>
        /// <typeparam name="T">The current element type.</typeparam>
        /// <typeparam name="TOther">The target element type.</typeparam>
        /// <returns>The casted array view.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArrayView3D<TOther, Stride3D.DenseXY> Cast<T, TOther>(
            this ArrayView3D<T, Stride3D.DenseXY> view)
            where T : unmanaged
            where TOther : unmanaged
        {
            var (extent, stride) = view.Stride.Cast(
                StrideExtensions.CreateCastContext(
                    ArrayView<T>.ElementSize,
                    ArrayView<TOther>.ElementSize),
                view.Extent);
            return new ArrayView3D<TOther, Stride3D.DenseXY>(
                view.BaseView.Cast<TOther>(),
                extent,
                stride);
        }

        /// <summary>
        /// Casts the given array view into another array-view type.
        /// </summary>
        /// <typeparam name="T">The current element type.</typeparam>
        /// <typeparam name="TOther">The target element type.</typeparam>
        /// <returns>The casted array view.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArrayView3D<TOther, Stride3D.DenseZY> Cast<T, TOther>(
            this ArrayView3D<T, Stride3D.DenseZY> view)
            where T : unmanaged
            where TOther : unmanaged
        {
            var (extent, stride) = view.Stride.Cast(
                StrideExtensions.CreateCastContext(
                    ArrayView<T>.ElementSize,
                    ArrayView<TOther>.ElementSize),
                view.Extent);
            return new ArrayView3D<TOther, Stride3D.DenseZY>(
                view.BaseView.Cast<TOther>(),
                extent,
                stride);
        }

        #endregion

        #region MemSet

        /// <summary>
        /// Sets the contents of the given buffer to zero using the default accelerator
        /// stream.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="view">The view instance.</param>
        /// <remarks>This method is not supported on accelerators.</remarks>
        [NotInsideKernel]
        public static void MemSetToZero<T>(this ArrayView1D<T, Stride1D.Infinite> view)
            where T : unmanaged =>
            view.BaseView.MemSetToZero();

        /// <summary>
        /// Sets the contents of the current buffer to zero.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="view">The view instance.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <remarks>This method is not supported on accelerators.</remarks>
        [NotInsideKernel]
        public static void MemSetToZero<T>(
            this ArrayView1D<T, Stride1D.Infinite> view,
            AcceleratorStream stream)
            where T : unmanaged =>
            view.BaseView.MemSetToZero(stream);

        /// <summary>
        /// Sets the contents of the given buffer to the given byte value using the
        /// default accelerator stream.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="view">The view instance.</param>
        /// <param name="value">The value to write into the memory buffer.</param>
        /// <remarks>This method is not supported on accelerators.</remarks>
        [NotInsideKernel]
        public static void MemSet<T>(
            this ArrayView1D<T, Stride1D.Infinite> view,
            byte value)
            where T : unmanaged =>
            view.BaseView.MemSet(value);

        /// <summary>
        /// Sets the contents of the current buffer to the given byte value.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="view">The view instance.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="value">The value to write into the memory buffer.</param>
        /// <remarks>This method is not supported on accelerators.</remarks>
        [NotInsideKernel]
        public static void MemSet<T>(
            this ArrayView1D<T, Stride1D.Infinite> view,
            AcceleratorStream stream,
            byte value)
            where T : unmanaged =>
            view.BaseView.MemSet(stream, value);

        /// <summary>
        /// Sets the contents of the given buffer to zero using the default accelerator
        /// stream.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="view">The view instance.</param>
        /// <remarks>This method is not supported on accelerators.</remarks>
        [NotInsideKernel]
        public static void MemSetToZero<T>(this ArrayView1D<T, Stride1D.Dense> view)
            where T : unmanaged =>
            view.BaseView.MemSetToZero();

        /// <summary>
        /// Sets the contents of the current buffer to zero.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="view">The view instance.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <remarks>This method is not supported on accelerators.</remarks>
        [NotInsideKernel]
        public static void MemSetToZero<T>(
            this ArrayView1D<T, Stride1D.Dense> view,
            AcceleratorStream stream)
            where T : unmanaged =>
            view.BaseView.MemSetToZero(stream);

        /// <summary>
        /// Sets the contents of the given buffer to the given byte value using the
        /// default accelerator stream.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="view">The view instance.</param>
        /// <param name="value">The value to write into the memory buffer.</param>
        /// <remarks>This method is not supported on accelerators.</remarks>
        [NotInsideKernel]
        public static void MemSet<T>(
            this ArrayView1D<T, Stride1D.Dense> view,
            byte value)
            where T : unmanaged =>
            view.BaseView.MemSet(value);

        /// <summary>
        /// Sets the contents of the current buffer to the given byte value.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="view">The view instance.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="value">The value to write into the memory buffer.</param>
        /// <remarks>This method is not supported on accelerators.</remarks>
        [NotInsideKernel]
        public static void MemSet<T>(
            this ArrayView1D<T, Stride1D.Dense> view,
            AcceleratorStream stream,
            byte value)
            where T : unmanaged =>
            view.BaseView.MemSet(stream, value);

        #endregion

        #region Copy from/to Views

        /// <summary>
        /// Copies from the source view into the target view.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="source">The source view instance.</param>
        /// <param name="target">The target view instance.</param>
        /// <remarks>This method is not supported on accelerators.</remarks>
        [NotInsideKernel]
        public static void CopyTo<T>(
            this ArrayView1D<T, Stride1D.Infinite> source,
            ArrayView1D<T, Stride1D.Infinite> target)
            where T : unmanaged =>
            source.BaseView.CopyTo(target.BaseView);

        /// <summary>
        /// Copies from the source view into the target view.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="source">The source view instance.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="target">The target view instance.</param>
        /// <remarks>This method is not supported on accelerators.</remarks>
        [NotInsideKernel]
        public static void CopyTo<T>(
            this ArrayView1D<T, Stride1D.Infinite> source,
            AcceleratorStream stream,
            in ArrayView1D<T, Stride1D.Infinite> target)
            where T : unmanaged =>
            source.BaseView.CopyTo(stream, target.BaseView);

        /// <summary>
        /// Copies from the source view into the target view.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="source">The source view instance.</param>
        /// <param name="target">The target view instance.</param>
        /// <remarks>This method is not supported on accelerators.</remarks>
        [NotInsideKernel]
        public static void CopyFrom<T>(
            this ArrayView1D<T, Stride1D.Infinite> target,
            in ArrayView1D<T, Stride1D.Infinite> source)
            where T : unmanaged =>
            target.BaseView.CopyFrom(source.BaseView);

        /// <summary>
        /// Copies from the source view into the target view.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="target">The target view instance.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="source">The source view instance.</param>
        /// <remarks>This method is not supported on accelerators.</remarks>
        [NotInsideKernel]
        public static void CopyFrom<T>(
            this ArrayView1D<T, Stride1D.Infinite> target,
            AcceleratorStream stream,
            in ArrayView1D<T, Stride1D.Infinite> source)
            where T : unmanaged =>
            target.BaseView.CopyFrom(stream, source.BaseView);

        /// <summary>
        /// Copies from the source view into the target view.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="source">The source view instance.</param>
        /// <param name="target">The target view instance.</param>
        /// <remarks>This method is not supported on accelerators.</remarks>
        [NotInsideKernel]
        public static void CopyTo<T>(
            this ArrayView1D<T, Stride1D.Dense> source,
            ArrayView1D<T, Stride1D.Dense> target)
            where T : unmanaged =>
            source.BaseView.CopyTo(target.BaseView);

        /// <summary>
        /// Copies from the source view into the target view.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="source">The source view instance.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="target">The target view instance.</param>
        /// <remarks>This method is not supported on accelerators.</remarks>
        [NotInsideKernel]
        public static void CopyTo<T>(
            this ArrayView1D<T, Stride1D.Dense> source,
            AcceleratorStream stream,
            in ArrayView1D<T, Stride1D.Dense> target)
            where T : unmanaged =>
            source.BaseView.CopyTo(stream, target.BaseView);

        /// <summary>
        /// Copies from the source view into the target view.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="source">The source view instance.</param>
        /// <param name="target">The target view instance.</param>
        /// <remarks>This method is not supported on accelerators.</remarks>
        [NotInsideKernel]
        public static void CopyFrom<T>(
            this ArrayView1D<T, Stride1D.Dense> target,
            in ArrayView1D<T, Stride1D.Dense> source)
            where T : unmanaged =>
            target.BaseView.CopyFrom(source.BaseView);

        /// <summary>
        /// Copies from the source view into the target view.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="target">The target view instance.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="source">The source view instance.</param>
        /// <remarks>This method is not supported on accelerators.</remarks>
        [NotInsideKernel]
        public static void CopyFrom<T>(
            this ArrayView1D<T, Stride1D.Dense> target,
            AcceleratorStream stream,
            in ArrayView1D<T, Stride1D.Dense> source)
            where T : unmanaged =>
            target.BaseView.CopyFrom(stream, source.BaseView);

        #endregion

        #region Copy elements to/from CPU

        /// <summary>
        /// Copies from the source view into the given CPU target address while
        /// synchronizing the current accelerator stream.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="source">The source view instance.</param>
        /// <param name="cpuData">The base address of the CPU buffer.</param>
        /// <param name="length">The number of elements to copy.</param>
        /// <remarks>This method is not supported on accelerators.</remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyToCPU<T>(
            this ArrayView1D<T, Stride1D.Infinite> source,
            ref T cpuData,
            long length)
            where T : unmanaged =>
            source.BaseView.CopyToCPU(ref cpuData, length);

        /// <summary>
        /// Copies from the source view into the given CPU target address while
        /// synchronizing the current accelerator stream.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="source">The source view instance.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="cpuData">The base address of the CPU buffer.</param>
        /// <param name="length">The number of elements to copy.</param>
        /// <remarks>This method is not supported on accelerators.</remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyToCPU<T>(
            this ArrayView1D<T, Stride1D.Infinite> source,
            AcceleratorStream stream,
            ref T cpuData,
            long length)
            where T : unmanaged =>
            source.BaseView.CopyToCPU(stream, ref cpuData, length);

        /// <summary>
        /// Copies from the CPU source address into the given target view while
        /// synchronizing the current accelerator stream.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="target">The target view instance.</param>
        /// <param name="cpuData">The base address of the CPU buffer.</param>
        /// <param name="length">The number of elements to copy.</param>
        /// <remarks>This method is not supported on accelerators.</remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyFromCPU<T>(
            this ArrayView1D<T, Stride1D.Infinite> target,
            ref T cpuData,
            long length)
            where T : unmanaged =>
            target.BaseView.CopyFromCPU(ref cpuData, length);

        /// <summary>
        /// Copies from the CPU source address into the given target view while
        /// synchronizing the current accelerator stream.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="target">The target view instance.</param>
        /// <param name="cpuData">The base address of the CPU buffer.</param>
        /// <param name="length">The number of elements to copy.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <remarks>This method is not supported on accelerators.</remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyFromCPU<T>(
            this ArrayView1D<T, Stride1D.Infinite> target,
            AcceleratorStream stream,
            ref T cpuData,
            long length)
            where T : unmanaged =>
            target.BaseView.CopyFromCPU(stream, ref cpuData, length);

        /// <summary>
        /// Copies from the source view into the given CPU target address while
        /// synchronizing the current accelerator stream.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="source">The source view instance.</param>
        /// <param name="cpuData">The base address of the CPU buffer.</param>
        /// <param name="length">The number of elements to copy.</param>
        /// <remarks>This method is not supported on accelerators.</remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyToCPU<T>(
            this ArrayView1D<T, Stride1D.Dense> source,
            ref T cpuData,
            long length)
            where T : unmanaged =>
            source.BaseView.CopyToCPU(ref cpuData, length);

        /// <summary>
        /// Copies from the source view into the given CPU target address while
        /// synchronizing the current accelerator stream.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="source">The source view instance.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="cpuData">The base address of the CPU buffer.</param>
        /// <param name="length">The number of elements to copy.</param>
        /// <remarks>This method is not supported on accelerators.</remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyToCPU<T>(
            this ArrayView1D<T, Stride1D.Dense> source,
            AcceleratorStream stream,
            ref T cpuData,
            long length)
            where T : unmanaged =>
            source.BaseView.CopyToCPU(stream, ref cpuData, length);

        /// <summary>
        /// Copies from the CPU source address into the given target view while
        /// synchronizing the current accelerator stream.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="target">The target view instance.</param>
        /// <param name="cpuData">The base address of the CPU buffer.</param>
        /// <param name="length">The number of elements to copy.</param>
        /// <remarks>This method is not supported on accelerators.</remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyFromCPU<T>(
            this ArrayView1D<T, Stride1D.Dense> target,
            ref T cpuData,
            long length)
            where T : unmanaged =>
            target.BaseView.CopyFromCPU(ref cpuData, length);

        /// <summary>
        /// Copies from the CPU source address into the given target view while
        /// synchronizing the current accelerator stream.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="target">The target view instance.</param>
        /// <param name="cpuData">The base address of the CPU buffer.</param>
        /// <param name="length">The number of elements to copy.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <remarks>This method is not supported on accelerators.</remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyFromCPU<T>(
            this ArrayView1D<T, Stride1D.Dense> target,
            AcceleratorStream stream,
            ref T cpuData,
            long length)
            where T : unmanaged =>
            target.BaseView.CopyFromCPU(stream, ref cpuData, length);

        #endregion

        #region Copy from/to Spans

        /// <summary>
        /// Copies from the source view into the given CPU data array while
        /// synchronizing the current accelerator stream.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="source">The source view instance.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="span">The CPU data target.</param>
        /// <remarks>This method is not supported on accelerators.</remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyToCPU<T>(
            this ArrayView1D<T, Stride1D.Infinite> source,
            AcceleratorStream stream,
            in Span<T> span)
            where T : unmanaged =>
            source.BaseView.CopyToCPU(stream, span);

        /// <summary>
        /// Copies from the CPU source span into the given target view while
        /// synchronizing the current accelerator stream.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="target">The target view instance.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="span">The CPU data source.</param>
        /// <remarks>This method is not supported on accelerators.</remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyFromCPU<T>(
            this ArrayView1D<T, Stride1D.Infinite> target,
            AcceleratorStream stream,
            in ReadOnlySpan<T> span)
            where T : unmanaged =>
            target.BaseView.CopyFromCPU(stream, span);

        /// <summary>
        /// Copies from the source view into the given CPU data array while
        /// synchronizing the current accelerator stream.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="source">The source view instance.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="span">The CPU data target.</param>
        /// <remarks>This method is not supported on accelerators.</remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyToCPU<T>(
            this ArrayView1D<T, Stride1D.Dense> source,
            AcceleratorStream stream,
            in Span<T> span)
            where T : unmanaged =>
            source.BaseView.CopyToCPU(stream, span);

        /// <summary>
        /// Copies from the CPU source span into the given target view while
        /// synchronizing the current accelerator stream.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="target">The target view instance.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="span">The CPU data source.</param>
        /// <remarks>This method is not supported on accelerators.</remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyFromCPU<T>(
            this ArrayView1D<T, Stride1D.Dense> target,
            AcceleratorStream stream,
            in ReadOnlySpan<T> span)
            where T : unmanaged =>
            target.BaseView.CopyFromCPU(stream, span);

        #endregion

        #region Data Allocations

        /// <summary>
        /// Allocates a buffer with the specified content on the given accelerator
        /// using the default stream.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="accelerator">The parent accelerator.</param>
        /// <param name="data">The source CPU data.</param>
        /// <returns>An allocated buffer on this accelerator.</returns>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        public static 
            MemoryBuffer2D<T, Stride2D.DenseX>
            Allocate2DDenseX<T>(
            this Accelerator accelerator,
            T[,] data)
            where T : unmanaged =>
            Allocate2DDenseX<T>(
                accelerator,
                accelerator.DefaultStream,
                data);

        /// <summary>
        /// Allocates a buffer with the specified content on the given accelerator.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="accelerator">The parent accelerator.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="data">The source CPU data.</param>
        /// <returns>An allocated buffer on this accelerator.</returns>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        public static 
            MemoryBuffer2D<T, Stride2D.DenseX>
            Allocate2DDenseX<T>(
            this Accelerator accelerator,
            AcceleratorStream stream,
            T[,] data)
            where T : unmanaged
        {
            if (accelerator is null)
                throw new ArgumentNullException(nameof(accelerator));
            if (data is null)
                throw new ArgumentNullException(nameof(data));
            if (data.Length < 1)
            {
                return new MemoryBuffer2D
                    <T, Stride2D.DenseX>(
                    accelerator,
                    ArrayView2D<T, Stride2D.DenseX>.Empty);
            }

            // Allocate the raw buffer
            var extent = new LongIndex2D(
                data.GetLength(0), data.GetLength(1));
            var buffer = accelerator
                .Allocate2DDenseX<T>(extent);

            // Copy the data
            buffer.View.CopyFromCPU(stream, data);

            return buffer;
        }

        /// <summary>
        /// Allocates a buffer with the specified content on the given accelerator
        /// using the default stream.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="accelerator">The parent accelerator.</param>
        /// <param name="data">The source CPU data.</param>
        /// <returns>An allocated buffer on this accelerator.</returns>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        public static 
            MemoryBuffer2D<T, Stride2D.DenseY>
            Allocate2DDenseY<T>(
            this Accelerator accelerator,
            T[,] data)
            where T : unmanaged =>
            Allocate2DDenseY<T>(
                accelerator,
                accelerator.DefaultStream,
                data);

        /// <summary>
        /// Allocates a buffer with the specified content on the given accelerator.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="accelerator">The parent accelerator.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="data">The source CPU data.</param>
        /// <returns>An allocated buffer on this accelerator.</returns>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        public static 
            MemoryBuffer2D<T, Stride2D.DenseY>
            Allocate2DDenseY<T>(
            this Accelerator accelerator,
            AcceleratorStream stream,
            T[,] data)
            where T : unmanaged
        {
            if (accelerator is null)
                throw new ArgumentNullException(nameof(accelerator));
            if (data is null)
                throw new ArgumentNullException(nameof(data));
            if (data.Length < 1)
            {
                return new MemoryBuffer2D
                    <T, Stride2D.DenseY>(
                    accelerator,
                    ArrayView2D<T, Stride2D.DenseY>.Empty);
            }

            // Allocate the raw buffer
            var extent = new LongIndex2D(
                data.GetLength(0), data.GetLength(1));
            var buffer = accelerator
                .Allocate2DDenseY<T>(extent);

            // Copy the data
            buffer.View.CopyFromCPU(stream, data);

            return buffer;
        }

        /// <summary>
        /// Allocates a buffer with the specified content on the given accelerator
        /// using the default stream.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="accelerator">The parent accelerator.</param>
        /// <param name="data">The source CPU data.</param>
        /// <returns>An allocated buffer on this accelerator.</returns>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        public static 
            MemoryBuffer3D<T, Stride3D.DenseXY>
            Allocate3DDenseXY<T>(
            this Accelerator accelerator,
            T[,,] data)
            where T : unmanaged =>
            Allocate3DDenseXY<T>(
                accelerator,
                accelerator.DefaultStream,
                data);

        /// <summary>
        /// Allocates a buffer with the specified content on the given accelerator.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="accelerator">The parent accelerator.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="data">The source CPU data.</param>
        /// <returns>An allocated buffer on this accelerator.</returns>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        public static 
            MemoryBuffer3D<T, Stride3D.DenseXY>
            Allocate3DDenseXY<T>(
            this Accelerator accelerator,
            AcceleratorStream stream,
            T[,,] data)
            where T : unmanaged
        {
            if (accelerator is null)
                throw new ArgumentNullException(nameof(accelerator));
            if (data is null)
                throw new ArgumentNullException(nameof(data));
            if (data.Length < 1)
            {
                return new MemoryBuffer3D
                    <T, Stride3D.DenseXY>(
                    accelerator,
                    ArrayView3D<T, Stride3D.DenseXY>.Empty);
            }

            // Allocate the raw buffer
            var extent = new LongIndex3D(
                data.GetLength(0), data.GetLength(1), data.GetLength(2));
            var buffer = accelerator
                .Allocate3DDenseXY<T>(extent);

            // Copy the data
            buffer.View.CopyFromCPU(stream, data);

            return buffer;
        }

        /// <summary>
        /// Allocates a buffer with the specified content on the given accelerator
        /// using the default stream.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="accelerator">The parent accelerator.</param>
        /// <param name="data">The source CPU data.</param>
        /// <returns>An allocated buffer on this accelerator.</returns>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        public static 
            MemoryBuffer3D<T, Stride3D.DenseZY>
            Allocate3DDenseZY<T>(
            this Accelerator accelerator,
            T[,,] data)
            where T : unmanaged =>
            Allocate3DDenseZY<T>(
                accelerator,
                accelerator.DefaultStream,
                data);

        /// <summary>
        /// Allocates a buffer with the specified content on the given accelerator.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="accelerator">The parent accelerator.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="data">The source CPU data.</param>
        /// <returns>An allocated buffer on this accelerator.</returns>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        public static 
            MemoryBuffer3D<T, Stride3D.DenseZY>
            Allocate3DDenseZY<T>(
            this Accelerator accelerator,
            AcceleratorStream stream,
            T[,,] data)
            where T : unmanaged
        {
            if (accelerator is null)
                throw new ArgumentNullException(nameof(accelerator));
            if (data is null)
                throw new ArgumentNullException(nameof(data));
            if (data.Length < 1)
            {
                return new MemoryBuffer3D
                    <T, Stride3D.DenseZY>(
                    accelerator,
                    ArrayView3D<T, Stride3D.DenseZY>.Empty);
            }

            // Allocate the raw buffer
            var extent = new LongIndex3D(
                data.GetLength(0), data.GetLength(1), data.GetLength(2));
            var buffer = accelerator
                .Allocate3DDenseZY<T>(extent);

            // Copy the data
            buffer.View.CopyFromCPU(stream, data);

            return buffer;
        }


        #endregion

        #region Copy to/from arrays

        /// <summary>
        /// Copies the contents of the 2D view into the given
        /// 2D array using the default accelerator stream.
        /// </summary>
        /// <param name="view">The source view.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyToCPU<T>(
            this ArrayView2D<T, Stride2D.DenseX> view,
            T[,] data)
            where T : unmanaged =>
            CopyToCPU(view, view.GetDefaultStream(), data);

        /// <summary>
        /// Copies the contents of the 2D view into the given
        /// 2D array using the given accelerator stream.
        /// </summary>
        /// <param name="view">The source view.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        public static unsafe void CopyToCPU<T>(
            this ArrayView2D<T, Stride2D.DenseX> view,
            AcceleratorStream stream,
            T[,] data)
            where T : unmanaged
            => view.AsGeneral().CopyToCPU(stream, data);

        /// <summary>
        /// Copies the contents of the 2D array into the given
        /// 2D view using the default accelerator stream.
        /// </summary>
        /// <param name="view">The source view.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyFromCPU<T>(
            this ArrayView2D<T, Stride2D.DenseX> view,
            T[,] data)
            where T : unmanaged =>
            CopyFromCPU(view, view.GetDefaultStream(), data);

        /// <summary>
        /// Copies the contents of the 2D array into the given
        /// 2D view using the given stream.
        /// </summary>
        /// <param name="view">The source view.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        public static unsafe void CopyFromCPU<T>(
            this ArrayView2D<T, Stride2D.DenseX> view,
            AcceleratorStream stream,
            T[,] data)
            where T : unmanaged
            => view.AsGeneral().CopyFromCPU(stream, data);

        /// <summary>
        /// Copies the contents of the 2D view into the given
        /// 2D array using the default accelerator stream.
        /// </summary>
        /// <param name="view">The source view.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyToCPU<T>(
            this ArrayView2D<T, Stride2D.DenseY> view,
            T[,] data)
            where T : unmanaged =>
            CopyToCPU(view, view.GetDefaultStream(), data);

        /// <summary>
        /// Copies the contents of the 2D view into the given
        /// 2D array using the given accelerator stream.
        /// </summary>
        /// <param name="view">The source view.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        public static unsafe void CopyToCPU<T>(
            this ArrayView2D<T, Stride2D.DenseY> view,
            AcceleratorStream stream,
            T[,] data)
            where T : unmanaged
        {
            if (data is null)
                throw new ArgumentNullException(nameof(data));
            if (data.Length < 1)
                return;
            // Check if we need to transpose the output on the CPU
            if (view.Extent.Y % view.Stride.XStride != 0
                )
            {
                throw new NotSupportedException(
                    RuntimeErrorMessages.NotSupportedEfficientStrideCopy);
            }
            if (data.GetLength(0) <
                view.Extent.X)
            {
                throw new ArgumentOutOfRangeException(nameof(data));
            }
            if (data.GetLength(1) <
                view.Extent.Y)
            {
                throw new ArgumentOutOfRangeException(nameof(data));
            }

            fixed (T* ptr = data)
            {
                view.BaseView.CopyToCPU(
                    stream,
                    new Span<T>(ptr, data.Length));
            }
        }

        /// <summary>
        /// Copies the contents of the 2D array into the given
        /// 2D view using the default accelerator stream.
        /// </summary>
        /// <param name="view">The source view.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyFromCPU<T>(
            this ArrayView2D<T, Stride2D.DenseY> view,
            T[,] data)
            where T : unmanaged =>
            CopyFromCPU(view, view.GetDefaultStream(), data);

        /// <summary>
        /// Copies the contents of the 2D array into the given
        /// 2D view using the given stream.
        /// </summary>
        /// <param name="view">The source view.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        public static unsafe void CopyFromCPU<T>(
            this ArrayView2D<T, Stride2D.DenseY> view,
            AcceleratorStream stream,
            T[,] data)
            where T : unmanaged
        {
            if (data is null)
                throw new ArgumentNullException(nameof(data));
            if (view.HasNoData())
                return;
            // Check if we need to transpose the output on the CPU
            if (view.Extent.Y % view.Stride.XStride != 0
                )
            {
                throw new NotSupportedException(
                    RuntimeErrorMessages.NotSupportedEfficientStrideCopy);
            }
            if (data.GetLength(0) <
                view.Extent.X)
            {
                throw new ArgumentOutOfRangeException(nameof(data));
            }
            if (data.GetLength(1) <
                view.Extent.Y)
            {
                throw new ArgumentOutOfRangeException(nameof(data));
            }

            var tempBuffer = data;
            fixed (T* ptr = tempBuffer)
            {
                view.BaseView.CopyFromCPU(
                    stream,
                    new ReadOnlySpan<T>(ptr, tempBuffer.Length));
            }
        }

        /// <summary>
        /// Copies the contents of the 3D view into the given
        /// 3D array using the default accelerator stream.
        /// </summary>
        /// <param name="view">The source view.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyToCPU<T>(
            this ArrayView3D<T, Stride3D.DenseXY> view,
            T[,,] data)
            where T : unmanaged =>
            CopyToCPU(view, view.GetDefaultStream(), data);

        /// <summary>
        /// Copies the contents of the 3D view into the given
        /// 3D array using the given accelerator stream.
        /// </summary>
        /// <param name="view">The source view.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        public static unsafe void CopyToCPU<T>(
            this ArrayView3D<T, Stride3D.DenseXY> view,
            AcceleratorStream stream,
            T[,,] data)
            where T : unmanaged
            => view.AsGeneral().CopyToCPU(stream, data);

        /// <summary>
        /// Copies the contents of the 3D array into the given
        /// 3D view using the default accelerator stream.
        /// </summary>
        /// <param name="view">The source view.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyFromCPU<T>(
            this ArrayView3D<T, Stride3D.DenseXY> view,
            T[,,] data)
            where T : unmanaged =>
            CopyFromCPU(view, view.GetDefaultStream(), data);

        /// <summary>
        /// Copies the contents of the 3D array into the given
        /// 3D view using the given stream.
        /// </summary>
        /// <param name="view">The source view.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        public static unsafe void CopyFromCPU<T>(
            this ArrayView3D<T, Stride3D.DenseXY> view,
            AcceleratorStream stream,
            T[,,] data)
            where T : unmanaged
            => view.AsGeneral().CopyFromCPU(stream, data);

        /// <summary>
        /// Copies the contents of the 3D view into the given
        /// 3D array using the default accelerator stream.
        /// </summary>
        /// <param name="view">The source view.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyToCPU<T>(
            this ArrayView3D<T, Stride3D.DenseZY> view,
            T[,,] data)
            where T : unmanaged =>
            CopyToCPU(view, view.GetDefaultStream(), data);

        /// <summary>
        /// Copies the contents of the 3D view into the given
        /// 3D array using the given accelerator stream.
        /// </summary>
        /// <param name="view">The source view.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        public static unsafe void CopyToCPU<T>(
            this ArrayView3D<T, Stride3D.DenseZY> view,
            AcceleratorStream stream,
            T[,,] data)
            where T : unmanaged
        {
            if (data is null)
                throw new ArgumentNullException(nameof(data));
            if (data.Length < 1)
                return;
            // Check if we need to transpose the output on the CPU
            if (view.Extent.Y % view.Stride.XStride != 0
                && view.Extent.Z % (view.Stride.XStride / view.Stride.YStride) != 0
                )
            {
                throw new NotSupportedException(
                    RuntimeErrorMessages.NotSupportedEfficientStrideCopy);
            }
            if (data.GetLength(0) <
                view.Extent.X)
            {
                throw new ArgumentOutOfRangeException(nameof(data));
            }
            if (data.GetLength(1) <
                view.Extent.Y)
            {
                throw new ArgumentOutOfRangeException(nameof(data));
            }
            if (data.GetLength(2) <
                view.Extent.Z)
            {
                throw new ArgumentOutOfRangeException(nameof(data));
            }

            fixed (T* ptr = data)
            {
                view.BaseView.CopyToCPU(
                    stream,
                    new Span<T>(ptr, data.Length));
            }
        }

        /// <summary>
        /// Copies the contents of the 3D array into the given
        /// 3D view using the default accelerator stream.
        /// </summary>
        /// <param name="view">The source view.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyFromCPU<T>(
            this ArrayView3D<T, Stride3D.DenseZY> view,
            T[,,] data)
            where T : unmanaged =>
            CopyFromCPU(view, view.GetDefaultStream(), data);

        /// <summary>
        /// Copies the contents of the 3D array into the given
        /// 3D view using the given stream.
        /// </summary>
        /// <param name="view">The source view.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        public static unsafe void CopyFromCPU<T>(
            this ArrayView3D<T, Stride3D.DenseZY> view,
            AcceleratorStream stream,
            T[,,] data)
            where T : unmanaged
        {
            if (data is null)
                throw new ArgumentNullException(nameof(data));
            if (view.HasNoData())
                return;
            // Check if we need to transpose the output on the CPU
            if (view.Extent.Y % view.Stride.XStride != 0
                && view.Extent.Z % (view.Stride.XStride / view.Stride.YStride) != 0
                )
            {
                throw new NotSupportedException(
                    RuntimeErrorMessages.NotSupportedEfficientStrideCopy);
            }
            if (data.GetLength(0) <
                view.Extent.X)
            {
                throw new ArgumentOutOfRangeException(nameof(data));
            }
            if (data.GetLength(1) <
                view.Extent.Y)
            {
                throw new ArgumentOutOfRangeException(nameof(data));
            }
            if (data.GetLength(2) <
                view.Extent.Z)
            {
                throw new ArgumentOutOfRangeException(nameof(data));
            }

            var tempBuffer = data;
            fixed (T* ptr = tempBuffer)
            {
                view.BaseView.CopyFromCPU(
                    stream,
                    new ReadOnlySpan<T>(ptr, tempBuffer.Length));
            }
        }

        /// <summary>
        /// Copies the contents of the 1D view into the given
        /// 1D array using the default accelerator stream.
        /// </summary>
        /// <param name="view">The source view.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyToCPU<T>(
            this ArrayView1D<T, Stride1D.Dense> view,
            T[] data)
            where T : unmanaged =>
            CopyToCPU(view, view.GetDefaultStream(), data);

        /// <summary>
        /// Copies the contents of the 1D view into the given
        /// 1D array using the given accelerator stream.
        /// </summary>
        /// <param name="view">The source view.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        public static unsafe void CopyToCPU<T>(
            this ArrayView1D<T, Stride1D.Dense> view,
            AcceleratorStream stream,
            T[] data)
            where T : unmanaged
        {
            if (data is null)
                throw new ArgumentNullException(nameof(data));
            if (data.Length < 1)
                return;
            if (data.GetLength(0) <
                view.Extent.X)
            {
                throw new ArgumentOutOfRangeException(nameof(data));
            }

            fixed (T* ptr = data)
            {
                view.BaseView.CopyToCPU(
                    stream,
                    new Span<T>(ptr, data.Length));
            }
        }

        /// <summary>
        /// Copies the contents of the 1D array into the given
        /// 1D view using the default accelerator stream.
        /// </summary>
        /// <param name="view">The source view.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyFromCPU<T>(
            this ArrayView1D<T, Stride1D.Dense> view,
            T[] data)
            where T : unmanaged =>
            CopyFromCPU(view, view.GetDefaultStream(), data);

        /// <summary>
        /// Copies the contents of the 1D array into the given
        /// 1D view using the given stream.
        /// </summary>
        /// <param name="view">The source view.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        public static unsafe void CopyFromCPU<T>(
            this ArrayView1D<T, Stride1D.Dense> view,
            AcceleratorStream stream,
            T[] data)
            where T : unmanaged
        {
            if (data is null)
                throw new ArgumentNullException(nameof(data));
            if (view.HasNoData())
                return;
            if (data.GetLength(0) <
                view.Extent.X)
            {
                throw new ArgumentOutOfRangeException(nameof(data));
            }

            var tempBuffer = data;
            fixed (T* ptr = tempBuffer)
            {
                view.BaseView.CopyFromCPU(
                    stream,
                    new ReadOnlySpan<T>(ptr, tempBuffer.Length));
            }
        }



        /// <summary>
        /// Copies the contents of the 2D view into the given
        /// 2D array using the default accelerator stream.
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyToCPU<T>(
            this MemoryBuffer<
                ArrayView2D<T, Stride2D.DenseX>> buffer,
            T[,] data)
            where T : unmanaged =>
            buffer.View.CopyToCPU(data);

        /// <summary>
        /// Copies the contents of the 2D view into the given
        /// 2D array using the given accelerator stream.
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyToCPU<T>(
            this MemoryBuffer<
                ArrayView2D<T, Stride2D.DenseX>> buffer,
            AcceleratorStream stream,
            T[,] data)
            where T : unmanaged =>
            buffer.View.CopyToCPU(stream, data);

        /// <summary>
        /// Copies the contents of the 2D array into the given
        /// 2D buffer using the default accelerator stream.
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyFromCPU<T>(
            this MemoryBuffer<
                ArrayView2D<T, Stride2D.DenseX>> buffer,
            T[,] data)
            where T : unmanaged =>
            buffer.View.CopyFromCPU(data);

        /// <summary>
        /// Copies the contents of the 2D array into the given
        /// 2D buffer using the given accelerator stream.
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyFromCPU<T>(
            this MemoryBuffer<
                ArrayView2D<T, Stride2D.DenseX>> buffer,
            AcceleratorStream stream,
            T[,] data)
            where T : unmanaged =>
            buffer.View.CopyFromCPU(data);


        /// <summary>
        /// Copies the contents of the 2D view into the given
        /// 2D array using the default accelerator stream.
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyToCPU<T>(
            this MemoryBuffer<
                ArrayView2D<T, Stride2D.DenseY>> buffer,
            T[,] data)
            where T : unmanaged =>
            buffer.View.CopyToCPU(data);

        /// <summary>
        /// Copies the contents of the 2D view into the given
        /// 2D array using the given accelerator stream.
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyToCPU<T>(
            this MemoryBuffer<
                ArrayView2D<T, Stride2D.DenseY>> buffer,
            AcceleratorStream stream,
            T[,] data)
            where T : unmanaged =>
            buffer.View.CopyToCPU(stream, data);

        /// <summary>
        /// Copies the contents of the 2D array into the given
        /// 2D buffer using the default accelerator stream.
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyFromCPU<T>(
            this MemoryBuffer<
                ArrayView2D<T, Stride2D.DenseY>> buffer,
            T[,] data)
            where T : unmanaged =>
            buffer.View.CopyFromCPU(data);

        /// <summary>
        /// Copies the contents of the 2D array into the given
        /// 2D buffer using the given accelerator stream.
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyFromCPU<T>(
            this MemoryBuffer<
                ArrayView2D<T, Stride2D.DenseY>> buffer,
            AcceleratorStream stream,
            T[,] data)
            where T : unmanaged =>
            buffer.View.CopyFromCPU(data);


        /// <summary>
        /// Copies the contents of the 3D view into the given
        /// 3D array using the default accelerator stream.
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyToCPU<T>(
            this MemoryBuffer<
                ArrayView3D<T, Stride3D.DenseXY>> buffer,
            T[,,] data)
            where T : unmanaged =>
            buffer.View.CopyToCPU(data);

        /// <summary>
        /// Copies the contents of the 3D view into the given
        /// 3D array using the given accelerator stream.
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyToCPU<T>(
            this MemoryBuffer<
                ArrayView3D<T, Stride3D.DenseXY>> buffer,
            AcceleratorStream stream,
            T[,,] data)
            where T : unmanaged =>
            buffer.View.CopyToCPU(stream, data);

        /// <summary>
        /// Copies the contents of the 3D array into the given
        /// 3D buffer using the default accelerator stream.
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyFromCPU<T>(
            this MemoryBuffer<
                ArrayView3D<T, Stride3D.DenseXY>> buffer,
            T[,,] data)
            where T : unmanaged =>
            buffer.View.CopyFromCPU(data);

        /// <summary>
        /// Copies the contents of the 3D array into the given
        /// 3D buffer using the given accelerator stream.
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyFromCPU<T>(
            this MemoryBuffer<
                ArrayView3D<T, Stride3D.DenseXY>> buffer,
            AcceleratorStream stream,
            T[,,] data)
            where T : unmanaged =>
            buffer.View.CopyFromCPU(data);


        /// <summary>
        /// Copies the contents of the 3D view into the given
        /// 3D array using the default accelerator stream.
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyToCPU<T>(
            this MemoryBuffer<
                ArrayView3D<T, Stride3D.DenseZY>> buffer,
            T[,,] data)
            where T : unmanaged =>
            buffer.View.CopyToCPU(data);

        /// <summary>
        /// Copies the contents of the 3D view into the given
        /// 3D array using the given accelerator stream.
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyToCPU<T>(
            this MemoryBuffer<
                ArrayView3D<T, Stride3D.DenseZY>> buffer,
            AcceleratorStream stream,
            T[,,] data)
            where T : unmanaged =>
            buffer.View.CopyToCPU(stream, data);

        /// <summary>
        /// Copies the contents of the 3D array into the given
        /// 3D buffer using the default accelerator stream.
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyFromCPU<T>(
            this MemoryBuffer<
                ArrayView3D<T, Stride3D.DenseZY>> buffer,
            T[,,] data)
            where T : unmanaged =>
            buffer.View.CopyFromCPU(data);

        /// <summary>
        /// Copies the contents of the 3D array into the given
        /// 3D buffer using the given accelerator stream.
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyFromCPU<T>(
            this MemoryBuffer<
                ArrayView3D<T, Stride3D.DenseZY>> buffer,
            AcceleratorStream stream,
            T[,,] data)
            where T : unmanaged =>
            buffer.View.CopyFromCPU(data);


        /// <summary>
        /// Copies the contents of the 1D view into the given
        /// 1D array using the default accelerator stream.
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyToCPU<T>(
            this MemoryBuffer<
                ArrayView1D<T, Stride1D.Dense>> buffer,
            T[] data)
            where T : unmanaged =>
            buffer.View.CopyToCPU(data);

        /// <summary>
        /// Copies the contents of the 1D view into the given
        /// 1D array using the given accelerator stream.
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyToCPU<T>(
            this MemoryBuffer<
                ArrayView1D<T, Stride1D.Dense>> buffer,
            AcceleratorStream stream,
            T[] data)
            where T : unmanaged =>
            buffer.View.CopyToCPU(stream, data);

        /// <summary>
        /// Copies the contents of the 1D array into the given
        /// 1D buffer using the default accelerator stream.
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyFromCPU<T>(
            this MemoryBuffer<
                ArrayView1D<T, Stride1D.Dense>> buffer,
            T[] data)
            where T : unmanaged =>
            buffer.View.CopyFromCPU(data);

        /// <summary>
        /// Copies the contents of the 1D array into the given
        /// 1D buffer using the given accelerator stream.
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyFromCPU<T>(
            this MemoryBuffer<
                ArrayView1D<T, Stride1D.Dense>> buffer,
            AcceleratorStream stream,
            T[] data)
            where T : unmanaged =>
            buffer.View.CopyFromCPU(data);


        /// <summary>
        /// Copies the contents of the 1D view into the given
        /// 1D array using the default accelerator stream.
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyToCPU<T>(
            this MemoryBuffer<
                ArrayView1D<T, Stride1D.General>> buffer,
            T[] data)
            where T : unmanaged =>
            buffer.View.CopyToCPU(data);

        /// <summary>
        /// Copies the contents of the 1D view into the given
        /// 1D array using the given accelerator stream.
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyToCPU<T>(
            this MemoryBuffer<
                ArrayView1D<T, Stride1D.General>> buffer,
            AcceleratorStream stream,
            T[] data)
            where T : unmanaged =>
            buffer.View.CopyToCPU(stream, data);

        /// <summary>
        /// Copies the contents of the 1D array into the given
        /// 1D buffer using the default accelerator stream.
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyFromCPU<T>(
            this MemoryBuffer<
                ArrayView1D<T, Stride1D.General>> buffer,
            T[] data)
            where T : unmanaged =>
            buffer.View.CopyFromCPU(data);

        /// <summary>
        /// Copies the contents of the 1D array into the given
        /// 1D buffer using the given accelerator stream.
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyFromCPU<T>(
            this MemoryBuffer<
                ArrayView1D<T, Stride1D.General>> buffer,
            AcceleratorStream stream,
            T[] data)
            where T : unmanaged =>
            buffer.View.CopyFromCPU(data);


        /// <summary>
        /// Copies the contents of the 2D view into the given
        /// 2D array using the default accelerator stream.
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyToCPU<T>(
            this MemoryBuffer<
                ArrayView2D<T, Stride2D.General>> buffer,
            T[,] data)
            where T : unmanaged =>
            buffer.View.CopyToCPU(data);

        /// <summary>
        /// Copies the contents of the 2D view into the given
        /// 2D array using the given accelerator stream.
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyToCPU<T>(
            this MemoryBuffer<
                ArrayView2D<T, Stride2D.General>> buffer,
            AcceleratorStream stream,
            T[,] data)
            where T : unmanaged =>
            buffer.View.CopyToCPU(stream, data);

        /// <summary>
        /// Copies the contents of the 2D array into the given
        /// 2D buffer using the default accelerator stream.
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyFromCPU<T>(
            this MemoryBuffer<
                ArrayView2D<T, Stride2D.General>> buffer,
            T[,] data)
            where T : unmanaged =>
            buffer.View.CopyFromCPU(data);

        /// <summary>
        /// Copies the contents of the 2D array into the given
        /// 2D buffer using the given accelerator stream.
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyFromCPU<T>(
            this MemoryBuffer<
                ArrayView2D<T, Stride2D.General>> buffer,
            AcceleratorStream stream,
            T[,] data)
            where T : unmanaged =>
            buffer.View.CopyFromCPU(data);


        /// <summary>
        /// Copies the contents of the 3D view into the given
        /// 3D array using the default accelerator stream.
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyToCPU<T>(
            this MemoryBuffer<
                ArrayView3D<T, Stride3D.General>> buffer,
            T[,,] data)
            where T : unmanaged =>
            buffer.View.CopyToCPU(data);

        /// <summary>
        /// Copies the contents of the 3D view into the given
        /// 3D array using the given accelerator stream.
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyToCPU<T>(
            this MemoryBuffer<
                ArrayView3D<T, Stride3D.General>> buffer,
            AcceleratorStream stream,
            T[,,] data)
            where T : unmanaged =>
            buffer.View.CopyToCPU(stream, data);

        /// <summary>
        /// Copies the contents of the 3D array into the given
        /// 3D buffer using the default accelerator stream.
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyFromCPU<T>(
            this MemoryBuffer<
                ArrayView3D<T, Stride3D.General>> buffer,
            T[,,] data)
            where T : unmanaged =>
            buffer.View.CopyFromCPU(data);

        /// <summary>
        /// Copies the contents of the 3D array into the given
        /// 3D buffer using the given accelerator stream.
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="data">The target data array.</param>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyFromCPU<T>(
            this MemoryBuffer<
                ArrayView3D<T, Stride3D.General>> buffer,
            AcceleratorStream stream,
            T[,,] data)
            where T : unmanaged =>
            buffer.View.CopyFromCPU(data);


        #endregion

        #region Copy to/from Page Locked

        /// <summary>
        /// Copies from the source view into the given page locked memory without
        /// synchronizing the current accelerator stream.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="source">The source view instance.</param>
        /// <param name="pageLockScope">The page locked memory.</param>
        /// <remarks>This method is not supported on accelerators.</remarks>
        [NotInsideKernel]
        [Obsolete("Use PageLockScope.ArrayView instead")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyToPageLockedAsync<T>(
            this ArrayView1D<T, Stride1D.Infinite> source,
            PageLockScope<T> pageLockScope)
            where T : unmanaged =>
            source.BaseView.CopyToPageLockedAsync(pageLockScope);

        /// <summary>
        /// Copies from the source view into the given page locked memory without
        /// synchronizing the current accelerator stream.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="source">The source view instance.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="pageLockScope">The page locked memory.</param>
        /// <remarks>This method is not supported on accelerators.</remarks>
        [NotInsideKernel]
        [Obsolete("Use PageLockScope.ArrayView instead")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyToPageLockedAsync<T>(
            this ArrayView1D<T, Stride1D.Infinite> source,
            AcceleratorStream stream,
            PageLockScope<T> pageLockScope)
            where T : unmanaged =>
            source.BaseView.CopyToPageLockedAsync(stream, pageLockScope);

        /// <summary>
        /// Copies from the page locked memory into the given target view without
        /// synchronizing the current accelerator stream.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="target">The target view instance.</param>
        /// <param name="pageLockScope">The page locked memory.</param>
        /// <remarks>This method is not supported on accelerators.</remarks>
        [NotInsideKernel]
        [Obsolete("Use PageLockScope.ArrayView instead")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyFromPageLockedAsync<T>(
            this ArrayView1D<T, Stride1D.Infinite> target,
            PageLockScope<T> pageLockScope)
            where T : unmanaged =>
            target.BaseView.CopyFromPageLockedAsync(pageLockScope);

        /// <summary>
        /// Copies from the page locked memory into the given target view without
        /// synchronizing the current accelerator stream.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="target">The target view instance.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="pageLockScope">The page locked memory.</param>
        /// <remarks>This method is not supported on accelerators.</remarks>
        [NotInsideKernel]
        [Obsolete("Use PageLockScope.ArrayView instead")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyFromPageLockedAsync<T>(
            this ArrayView1D<T, Stride1D.Infinite> target,
            AcceleratorStream stream,
            PageLockScope<T> pageLockScope)
            where T : unmanaged =>
            target.BaseView.CopyFromPageLockedAsync(stream, pageLockScope);

        /// <summary>
        /// Copies from the source view into the given page locked memory without
        /// synchronizing the current accelerator stream.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="source">The source view instance.</param>
        /// <param name="pageLockScope">The page locked memory.</param>
        /// <remarks>This method is not supported on accelerators.</remarks>
        [NotInsideKernel]
        [Obsolete("Use PageLockScope.ArrayView instead")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyToPageLockedAsync<T>(
            this ArrayView1D<T, Stride1D.Dense> source,
            PageLockScope<T> pageLockScope)
            where T : unmanaged =>
            source.BaseView.CopyToPageLockedAsync(pageLockScope);

        /// <summary>
        /// Copies from the source view into the given page locked memory without
        /// synchronizing the current accelerator stream.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="source">The source view instance.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="pageLockScope">The page locked memory.</param>
        /// <remarks>This method is not supported on accelerators.</remarks>
        [NotInsideKernel]
        [Obsolete("Use PageLockScope.ArrayView instead")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyToPageLockedAsync<T>(
            this ArrayView1D<T, Stride1D.Dense> source,
            AcceleratorStream stream,
            PageLockScope<T> pageLockScope)
            where T : unmanaged =>
            source.BaseView.CopyToPageLockedAsync(stream, pageLockScope);

        /// <summary>
        /// Copies from the page locked memory into the given target view without
        /// synchronizing the current accelerator stream.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="target">The target view instance.</param>
        /// <param name="pageLockScope">The page locked memory.</param>
        /// <remarks>This method is not supported on accelerators.</remarks>
        [NotInsideKernel]
        [Obsolete("Use PageLockScope.ArrayView instead")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyFromPageLockedAsync<T>(
            this ArrayView1D<T, Stride1D.Dense> target,
            PageLockScope<T> pageLockScope)
            where T : unmanaged =>
            target.BaseView.CopyFromPageLockedAsync(pageLockScope);

        /// <summary>
        /// Copies from the page locked memory into the given target view without
        /// synchronizing the current accelerator stream.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="target">The target view instance.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="pageLockScope">The page locked memory.</param>
        /// <remarks>This method is not supported on accelerators.</remarks>
        [NotInsideKernel]
        [Obsolete("Use PageLockScope.ArrayView instead")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyFromPageLockedAsync<T>(
            this ArrayView1D<T, Stride1D.Dense> target,
            AcceleratorStream stream,
            PageLockScope<T> pageLockScope)
            where T : unmanaged =>
            target.BaseView.CopyFromPageLockedAsync(stream, pageLockScope);

        #endregion

        #region Copy to/from Page Locked Array

        /// <summary>
        /// Copies from the source view into the given page locked memory without
        /// synchronizing the current accelerator stream.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="source">The source view instance.</param>
        /// <param name="pageLockedArray">The page locked memory.</param>
        /// <remarks>This method is not supported on accelerators.</remarks>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [Obsolete("Use PageLockScope.ArrayView instead")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyToPageLockedAsync<T>(
            this ArrayView2D<T, Stride2D.DenseY> source,
            PageLockedArray2D<T> pageLockedArray)
            where T : unmanaged =>
            source.CopyToPageLockedAsync(source.GetDefaultStream(), pageLockedArray);

        /// <summary>
        /// Copies from the source view into the given page locked memory without
        /// synchronizing the current accelerator stream.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="source">The source view instance.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="pageLockedArray">The page locked memory.</param>
        /// <remarks>This method is not supported on accelerators.</remarks>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [Obsolete("Use PageLockScope.ArrayView instead")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyToPageLockedAsync<T>(
            this ArrayView2D<T, Stride2D.DenseY> source,
            AcceleratorStream stream,
            PageLockedArray2D<T> pageLockedArray)
            where T : unmanaged =>
            source.BaseView.CopyToPageLockedAsync(stream, pageLockedArray);

        /// <summary>
        /// Copies from the page locked memory into the given target view without
        /// synchronizing the current accelerator stream.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="target">The target view instance.</param>
        /// <param name="pageLockedArray">The page locked memory.</param>
        /// <remarks>This method is not supported on accelerators.</remarks>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [Obsolete("Use PageLockScope.ArrayView instead")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyFromPageLockedAsync<T>(
            this ArrayView2D<T, Stride2D.DenseY> target,
            PageLockedArray2D<T> pageLockedArray)
            where T : unmanaged =>
            target.CopyFromPageLockedAsync(target.GetDefaultStream(), pageLockedArray);

        /// <summary>
        /// Copies from the page locked memory into the given target view without
        /// synchronizing the current accelerator stream.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="target">The target view instance.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="pageLockedArray">The page locked memory.</param>
        /// <remarks>This method is not supported on accelerators.</remarks>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [Obsolete("Use PageLockScope.ArrayView instead")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyFromPageLockedAsync<T>(
            this ArrayView2D<T, Stride2D.DenseY> target,
            AcceleratorStream stream,
            PageLockedArray2D<T> pageLockedArray)
            where T : unmanaged =>
            target.BaseView.CopyFromPageLockedAsync(stream, pageLockedArray);

        /// <summary>
        /// Copies from the source view into the given page locked memory without
        /// synchronizing the current accelerator stream.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="source">The source view instance.</param>
        /// <param name="pageLockedArray">The page locked memory.</param>
        /// <remarks>This method is not supported on accelerators.</remarks>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [Obsolete("Use PageLockScope.ArrayView instead")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyToPageLockedAsync<T>(
            this ArrayView3D<T, Stride3D.DenseZY> source,
            PageLockedArray3D<T> pageLockedArray)
            where T : unmanaged =>
            source.CopyToPageLockedAsync(source.GetDefaultStream(), pageLockedArray);

        /// <summary>
        /// Copies from the source view into the given page locked memory without
        /// synchronizing the current accelerator stream.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="source">The source view instance.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="pageLockedArray">The page locked memory.</param>
        /// <remarks>This method is not supported on accelerators.</remarks>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [Obsolete("Use PageLockScope.ArrayView instead")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyToPageLockedAsync<T>(
            this ArrayView3D<T, Stride3D.DenseZY> source,
            AcceleratorStream stream,
            PageLockedArray3D<T> pageLockedArray)
            where T : unmanaged =>
            source.BaseView.CopyToPageLockedAsync(stream, pageLockedArray);

        /// <summary>
        /// Copies from the page locked memory into the given target view without
        /// synchronizing the current accelerator stream.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="target">The target view instance.</param>
        /// <param name="pageLockedArray">The page locked memory.</param>
        /// <remarks>This method is not supported on accelerators.</remarks>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [Obsolete("Use PageLockScope.ArrayView instead")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyFromPageLockedAsync<T>(
            this ArrayView3D<T, Stride3D.DenseZY> target,
            PageLockedArray3D<T> pageLockedArray)
            where T : unmanaged =>
            target.CopyFromPageLockedAsync(target.GetDefaultStream(), pageLockedArray);

        /// <summary>
        /// Copies from the page locked memory into the given target view without
        /// synchronizing the current accelerator stream.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="target">The target view instance.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="pageLockedArray">The page locked memory.</param>
        /// <remarks>This method is not supported on accelerators.</remarks>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [Obsolete("Use PageLockScope.ArrayView instead")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyFromPageLockedAsync<T>(
            this ArrayView3D<T, Stride3D.DenseZY> target,
            AcceleratorStream stream,
            PageLockedArray3D<T> pageLockedArray)
            where T : unmanaged =>
            target.BaseView.CopyFromPageLockedAsync(stream, pageLockedArray);

        /// <summary>
        /// Copies from the source view into the given page locked memory without
        /// synchronizing the current accelerator stream.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="source">The source view instance.</param>
        /// <param name="pageLockedArray">The page locked memory.</param>
        /// <remarks>This method is not supported on accelerators.</remarks>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [Obsolete("Use PageLockScope.ArrayView instead")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyToPageLockedAsync<T>(
            this ArrayView1D<T, Stride1D.Dense> source,
            PageLockedArray1D<T> pageLockedArray)
            where T : unmanaged =>
            source.CopyToPageLockedAsync(source.GetDefaultStream(), pageLockedArray);

        /// <summary>
        /// Copies from the source view into the given page locked memory without
        /// synchronizing the current accelerator stream.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="source">The source view instance.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="pageLockedArray">The page locked memory.</param>
        /// <remarks>This method is not supported on accelerators.</remarks>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [Obsolete("Use PageLockScope.ArrayView instead")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyToPageLockedAsync<T>(
            this ArrayView1D<T, Stride1D.Dense> source,
            AcceleratorStream stream,
            PageLockedArray1D<T> pageLockedArray)
            where T : unmanaged =>
            source.BaseView.CopyToPageLockedAsync(stream, pageLockedArray);

        /// <summary>
        /// Copies from the page locked memory into the given target view without
        /// synchronizing the current accelerator stream.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="target">The target view instance.</param>
        /// <param name="pageLockedArray">The page locked memory.</param>
        /// <remarks>This method is not supported on accelerators.</remarks>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [Obsolete("Use PageLockScope.ArrayView instead")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyFromPageLockedAsync<T>(
            this ArrayView1D<T, Stride1D.Dense> target,
            PageLockedArray1D<T> pageLockedArray)
            where T : unmanaged =>
            target.CopyFromPageLockedAsync(target.GetDefaultStream(), pageLockedArray);

        /// <summary>
        /// Copies from the page locked memory into the given target view without
        /// synchronizing the current accelerator stream.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="target">The target view instance.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <param name="pageLockedArray">The page locked memory.</param>
        /// <remarks>This method is not supported on accelerators.</remarks>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [Obsolete("Use PageLockScope.ArrayView instead")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyFromPageLockedAsync<T>(
            this ArrayView1D<T, Stride1D.Dense> target,
            AcceleratorStream stream,
            PageLockedArray1D<T> pageLockedArray)
            where T : unmanaged =>
            target.BaseView.CopyFromPageLockedAsync(stream, pageLockedArray);

        #endregion

        #region GetAsPageLocked

        /// <summary>
        /// Copies the contents of the 2D view into a new
        /// page locked 2D array.
        /// </summary>
        /// <param name="view">The source view.</param>
        /// <returns>A new array holding the requested contents.</returns>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PageLockedArray2D<T>
            GetAsPageLocked2D<T>(
            this ArrayView2D<T, Stride2D.DenseY> view)
            where T : unmanaged =>
            view.GetAsPageLocked2D(view.GetDefaultStream());

        /// <summary>
        /// Copies the contents of the 2D view into a new
        /// page locked 2D array.
        /// </summary>
        /// <param name="view">The source view.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <returns>A new array holding the requested contents.</returns>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        public static PageLockedArray2D<T>
            GetAsPageLocked2D<T>(
            this ArrayView2D<T, Stride2D.DenseY> view,
            AcceleratorStream stream)
            where T : unmanaged
        {
            if (view.HasNoData())
                return PageLockedArray2D<T>.Empty;

            // Allocate the return array
            var result = view
                .GetAccelerator()
                .AllocatePageLocked2D<T>(view.Extent);

            // Copy the data
            view.BaseView.CopyTo(stream, result.ArrayView);
            stream.Synchronize();

            return result;
        }

        /// <summary>
        /// Copies the contents of the 3D view into a new
        /// page locked 3D array.
        /// </summary>
        /// <param name="view">The source view.</param>
        /// <returns>A new array holding the requested contents.</returns>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PageLockedArray3D<T>
            GetAsPageLocked3D<T>(
            this ArrayView3D<T, Stride3D.DenseZY> view)
            where T : unmanaged =>
            view.GetAsPageLocked3D(view.GetDefaultStream());

        /// <summary>
        /// Copies the contents of the 3D view into a new
        /// page locked 3D array.
        /// </summary>
        /// <param name="view">The source view.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <returns>A new array holding the requested contents.</returns>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        public static PageLockedArray3D<T>
            GetAsPageLocked3D<T>(
            this ArrayView3D<T, Stride3D.DenseZY> view,
            AcceleratorStream stream)
            where T : unmanaged
        {
            if (view.HasNoData())
                return PageLockedArray3D<T>.Empty;

            // Allocate the return array
            var result = view
                .GetAccelerator()
                .AllocatePageLocked3D<T>(view.Extent);

            // Copy the data
            view.BaseView.CopyTo(stream, result.ArrayView);
            stream.Synchronize();

            return result;
        }

        /// <summary>
        /// Copies the contents of the 1D view into a new
        /// page locked 1D array.
        /// </summary>
        /// <param name="view">The source view.</param>
        /// <returns>A new array holding the requested contents.</returns>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PageLockedArray1D<T>
            GetAsPageLocked1D<T>(
            this ArrayView1D<T, Stride1D.Dense> view)
            where T : unmanaged =>
            view.GetAsPageLocked1D(view.GetDefaultStream());

        /// <summary>
        /// Copies the contents of the 1D view into a new
        /// page locked 1D array.
        /// </summary>
        /// <param name="view">The source view.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <returns>A new array holding the requested contents.</returns>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        public static PageLockedArray1D<T>
            GetAsPageLocked1D<T>(
            this ArrayView1D<T, Stride1D.Dense> view,
            AcceleratorStream stream)
            where T : unmanaged
        {
            if (view.HasNoData())
                return PageLockedArray1D<T>.Empty;

            // Allocate the return array
            var result = view
                .GetAccelerator()
                .AllocatePageLocked1D<T>(view.Extent);

            // Copy the data
            view.BaseView.CopyTo(stream, result.ArrayView);
            stream.Synchronize();

            return result;
        }


        #endregion

        #region GetAsArray

        /// <summary>
        /// Copies the contents of the 2D view into a new
        /// 2D array
        /// while transposing the input buffer on the CPU.
        /// </summary>
        /// <param name="view">The source view.</param>
        /// <returns>A new array holding the requested contents.</returns>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[,] GetAsArray2D<T>(
            this ArrayView2D<T, Stride2D.DenseX> view)
            where T : unmanaged =>
            view.GetAsArray2D(view.GetDefaultStream());

        /// <summary>
        /// Copies the contents of the 2D view into a new
        /// 2D array
        /// while transposing the input buffer on the CPU.
        /// </summary>
        /// <param name="view">The source view.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <returns>A new array holding the requested contents.</returns>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        public static T[,] GetAsArray2D<T>(
            this ArrayView2D<T, Stride2D.DenseX> view,
            AcceleratorStream stream)
            where T : unmanaged
        {
            if (view.HasNoData())
            {
                return new T[0, 0];
            }

            // Allocate the return array
            var result = new T[
                view.Extent.X, view.Extent.Y];

            // Copy the data
            view.CopyToCPU(stream, result);

            return result;
        }

        /// <summary>
        /// Copies the contents of the 2D view into a new
        /// 2D array
        /// while transposing the input buffer on the CPU.
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <returns>A new array holding the requested contents.</returns>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        public static T[,] GetAsArray2D<T>(
            this MemoryBuffer<
                ArrayView2D<T, Stride2D.DenseX>> buffer)
            where T : unmanaged =>
            buffer.View.GetAsArray2D();

        /// <summary>
        /// Copies the contents of the 2D view into a new
        /// 2D array
        /// while transposing the input buffer on the CPU.
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <returns>A new array holding the requested contents.</returns>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        public static T[,] GetAsArray2D<T>(
            this MemoryBuffer<
                ArrayView2D<T, Stride2D.DenseX>> buffer,
            AcceleratorStream stream)
            where T : unmanaged =>
            buffer.View.GetAsArray2D(stream);

        /// <summary>
        /// Copies the contents of the 2D view into a new
        /// 2D array
        /// .
        /// </summary>
        /// <param name="view">The source view.</param>
        /// <returns>A new array holding the requested contents.</returns>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[,] GetAsArray2D<T>(
            this ArrayView2D<T, Stride2D.DenseY> view)
            where T : unmanaged =>
            view.GetAsArray2D(view.GetDefaultStream());

        /// <summary>
        /// Copies the contents of the 2D view into a new
        /// 2D array
        /// .
        /// </summary>
        /// <param name="view">The source view.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <returns>A new array holding the requested contents.</returns>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        public static T[,] GetAsArray2D<T>(
            this ArrayView2D<T, Stride2D.DenseY> view,
            AcceleratorStream stream)
            where T : unmanaged
        {
            if (view.HasNoData())
            {
                return new T[0, 0];
            }

            // Allocate the return array
            var result = new T[
                view.Extent.X, view.Extent.Y];

            // Copy the data
            view.CopyToCPU(stream, result);

            return result;
        }

        /// <summary>
        /// Copies the contents of the 2D view into a new
        /// 2D array
        /// .
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <returns>A new array holding the requested contents.</returns>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        public static T[,] GetAsArray2D<T>(
            this MemoryBuffer<
                ArrayView2D<T, Stride2D.DenseY>> buffer)
            where T : unmanaged =>
            buffer.View.GetAsArray2D();

        /// <summary>
        /// Copies the contents of the 2D view into a new
        /// 2D array
        /// .
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <returns>A new array holding the requested contents.</returns>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        public static T[,] GetAsArray2D<T>(
            this MemoryBuffer<
                ArrayView2D<T, Stride2D.DenseY>> buffer,
            AcceleratorStream stream)
            where T : unmanaged =>
            buffer.View.GetAsArray2D(stream);

        /// <summary>
        /// Copies the contents of the 3D view into a new
        /// 3D array
        /// while transposing the input buffer on the CPU.
        /// </summary>
        /// <param name="view">The source view.</param>
        /// <returns>A new array holding the requested contents.</returns>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[,,] GetAsArray3D<T>(
            this ArrayView3D<T, Stride3D.DenseXY> view)
            where T : unmanaged =>
            view.GetAsArray3D(view.GetDefaultStream());

        /// <summary>
        /// Copies the contents of the 3D view into a new
        /// 3D array
        /// while transposing the input buffer on the CPU.
        /// </summary>
        /// <param name="view">The source view.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <returns>A new array holding the requested contents.</returns>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        public static T[,,] GetAsArray3D<T>(
            this ArrayView3D<T, Stride3D.DenseXY> view,
            AcceleratorStream stream)
            where T : unmanaged
        {
            if (view.HasNoData())
            {
                return new T[0, 0, 0];
            }

            // Allocate the return array
            var result = new T[
                view.Extent.X, view.Extent.Y, view.Extent.Z];

            // Copy the data
            view.CopyToCPU(stream, result);

            return result;
        }

        /// <summary>
        /// Copies the contents of the 3D view into a new
        /// 3D array
        /// while transposing the input buffer on the CPU.
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <returns>A new array holding the requested contents.</returns>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        public static T[,,] GetAsArray3D<T>(
            this MemoryBuffer<
                ArrayView3D<T, Stride3D.DenseXY>> buffer)
            where T : unmanaged =>
            buffer.View.GetAsArray3D();

        /// <summary>
        /// Copies the contents of the 3D view into a new
        /// 3D array
        /// while transposing the input buffer on the CPU.
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <returns>A new array holding the requested contents.</returns>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        public static T[,,] GetAsArray3D<T>(
            this MemoryBuffer<
                ArrayView3D<T, Stride3D.DenseXY>> buffer,
            AcceleratorStream stream)
            where T : unmanaged =>
            buffer.View.GetAsArray3D(stream);

        /// <summary>
        /// Copies the contents of the 3D view into a new
        /// 3D array
        /// .
        /// </summary>
        /// <param name="view">The source view.</param>
        /// <returns>A new array holding the requested contents.</returns>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[,,] GetAsArray3D<T>(
            this ArrayView3D<T, Stride3D.DenseZY> view)
            where T : unmanaged =>
            view.GetAsArray3D(view.GetDefaultStream());

        /// <summary>
        /// Copies the contents of the 3D view into a new
        /// 3D array
        /// .
        /// </summary>
        /// <param name="view">The source view.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <returns>A new array holding the requested contents.</returns>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        public static T[,,] GetAsArray3D<T>(
            this ArrayView3D<T, Stride3D.DenseZY> view,
            AcceleratorStream stream)
            where T : unmanaged
        {
            if (view.HasNoData())
            {
                return new T[0, 0, 0];
            }

            // Allocate the return array
            var result = new T[
                view.Extent.X, view.Extent.Y, view.Extent.Z];

            // Copy the data
            view.CopyToCPU(stream, result);

            return result;
        }

        /// <summary>
        /// Copies the contents of the 3D view into a new
        /// 3D array
        /// .
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <returns>A new array holding the requested contents.</returns>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        public static T[,,] GetAsArray3D<T>(
            this MemoryBuffer<
                ArrayView3D<T, Stride3D.DenseZY>> buffer)
            where T : unmanaged =>
            buffer.View.GetAsArray3D();

        /// <summary>
        /// Copies the contents of the 3D view into a new
        /// 3D array
        /// .
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <returns>A new array holding the requested contents.</returns>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        public static T[,,] GetAsArray3D<T>(
            this MemoryBuffer<
                ArrayView3D<T, Stride3D.DenseZY>> buffer,
            AcceleratorStream stream)
            where T : unmanaged =>
            buffer.View.GetAsArray3D(stream);

        /// <summary>
        /// Copies the contents of the 1D view into a new
        /// 1D array
        /// .
        /// </summary>
        /// <param name="view">The source view.</param>
        /// <returns>A new array holding the requested contents.</returns>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[] GetAsArray1D<T>(
            this ArrayView1D<T, Stride1D.Dense> view)
            where T : unmanaged =>
            view.GetAsArray1D(view.GetDefaultStream());

        /// <summary>
        /// Copies the contents of the 1D view into a new
        /// 1D array
        /// .
        /// </summary>
        /// <param name="view">The source view.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <returns>A new array holding the requested contents.</returns>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        public static T[] GetAsArray1D<T>(
            this ArrayView1D<T, Stride1D.Dense> view,
            AcceleratorStream stream)
            where T : unmanaged
        {
            if (view.HasNoData())
            {
                return new T[0];
            }

            // Allocate the return array
            var result = new T[
                view.Extent.X];

            // Copy the data
            view.CopyToCPU(stream, result);

            return result;
        }

        /// <summary>
        /// Copies the contents of the 1D view into a new
        /// 1D array
        /// .
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <returns>A new array holding the requested contents.</returns>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        public static T[] GetAsArray1D<T>(
            this MemoryBuffer<
                ArrayView1D<T, Stride1D.Dense>> buffer)
            where T : unmanaged =>
            buffer.View.GetAsArray1D();

        /// <summary>
        /// Copies the contents of the 1D view into a new
        /// 1D array
        /// .
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <returns>A new array holding the requested contents.</returns>
        /// <remarks>
        /// This method is not supported on accelerators.
        /// </remarks>
        public static T[] GetAsArray1D<T>(
            this MemoryBuffer<
                ArrayView1D<T, Stride1D.Dense>> buffer,
            AcceleratorStream stream)
            where T : unmanaged =>
            buffer.View.GetAsArray1D(stream);

        /// <summary>
        /// Copies the contents of the 1D view into a new
        /// 1D array
        /// while transposing the input buffer on the CPU.
        /// </summary>
        /// <param name="view">The source view.</param>
        /// <returns>A new array holding the requested contents.</returns>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[] GetAsArray1D<T>(
            this ArrayView1D<T, Stride1D.General> view)
            where T : unmanaged =>
            view.GetAsArray1D(view.GetDefaultStream());

        /// <summary>
        /// Copies the contents of the 1D view into a new
        /// 1D array
        /// while transposing the input buffer on the CPU.
        /// </summary>
        /// <param name="view">The source view.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <returns>A new array holding the requested contents.</returns>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        public static T[] GetAsArray1D<T>(
            this ArrayView1D<T, Stride1D.General> view,
            AcceleratorStream stream)
            where T : unmanaged
        {
            if (view.HasNoData())
            {
                return new T[0];
            }

            // Allocate the return array
            var result = new T[
                view.Extent.X];

            // Copy the data
            view.CopyToCPU(stream, result);

            return result;
        }

        /// <summary>
        /// Copies the contents of the 1D view into a new
        /// 1D array
        /// while transposing the input buffer on the CPU.
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <returns>A new array holding the requested contents.</returns>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        public static T[] GetAsArray1D<T>(
            this MemoryBuffer<
                ArrayView1D<T, Stride1D.General>> buffer)
            where T : unmanaged =>
            buffer.View.GetAsArray1D();

        /// <summary>
        /// Copies the contents of the 1D view into a new
        /// 1D array
        /// while transposing the input buffer on the CPU.
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <returns>A new array holding the requested contents.</returns>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        public static T[] GetAsArray1D<T>(
            this MemoryBuffer<
                ArrayView1D<T, Stride1D.General>> buffer,
            AcceleratorStream stream)
            where T : unmanaged =>
            buffer.View.GetAsArray1D(stream);

        /// <summary>
        /// Copies the contents of the 2D view into a new
        /// 2D array
        /// while transposing the input buffer on the CPU.
        /// </summary>
        /// <param name="view">The source view.</param>
        /// <returns>A new array holding the requested contents.</returns>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[,] GetAsArray2D<T>(
            this ArrayView2D<T, Stride2D.General> view)
            where T : unmanaged =>
            view.GetAsArray2D(view.GetDefaultStream());

        /// <summary>
        /// Copies the contents of the 2D view into a new
        /// 2D array
        /// while transposing the input buffer on the CPU.
        /// </summary>
        /// <param name="view">The source view.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <returns>A new array holding the requested contents.</returns>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        public static T[,] GetAsArray2D<T>(
            this ArrayView2D<T, Stride2D.General> view,
            AcceleratorStream stream)
            where T : unmanaged
        {
            if (view.HasNoData())
            {
                return new T[0, 0];
            }

            // Allocate the return array
            var result = new T[
                view.Extent.X, view.Extent.Y];

            // Copy the data
            view.CopyToCPU(stream, result);

            return result;
        }

        /// <summary>
        /// Copies the contents of the 2D view into a new
        /// 2D array
        /// while transposing the input buffer on the CPU.
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <returns>A new array holding the requested contents.</returns>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        public static T[,] GetAsArray2D<T>(
            this MemoryBuffer<
                ArrayView2D<T, Stride2D.General>> buffer)
            where T : unmanaged =>
            buffer.View.GetAsArray2D();

        /// <summary>
        /// Copies the contents of the 2D view into a new
        /// 2D array
        /// while transposing the input buffer on the CPU.
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <returns>A new array holding the requested contents.</returns>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        public static T[,] GetAsArray2D<T>(
            this MemoryBuffer<
                ArrayView2D<T, Stride2D.General>> buffer,
            AcceleratorStream stream)
            where T : unmanaged =>
            buffer.View.GetAsArray2D(stream);

        /// <summary>
        /// Copies the contents of the 3D view into a new
        /// 3D array
        /// while transposing the input buffer on the CPU.
        /// </summary>
        /// <param name="view">The source view.</param>
        /// <returns>A new array holding the requested contents.</returns>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[,,] GetAsArray3D<T>(
            this ArrayView3D<T, Stride3D.General> view)
            where T : unmanaged =>
            view.GetAsArray3D(view.GetDefaultStream());

        /// <summary>
        /// Copies the contents of the 3D view into a new
        /// 3D array
        /// while transposing the input buffer on the CPU.
        /// </summary>
        /// <param name="view">The source view.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <returns>A new array holding the requested contents.</returns>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        [NotInsideKernel]
        public static T[,,] GetAsArray3D<T>(
            this ArrayView3D<T, Stride3D.General> view,
            AcceleratorStream stream)
            where T : unmanaged
        {
            if (view.HasNoData())
            {
                return new T[0, 0, 0];
            }

            // Allocate the return array
            var result = new T[
                view.Extent.X, view.Extent.Y, view.Extent.Z];

            // Copy the data
            view.CopyToCPU(stream, result);

            return result;
        }

        /// <summary>
        /// Copies the contents of the 3D view into a new
        /// 3D array
        /// while transposing the input buffer on the CPU.
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <returns>A new array holding the requested contents.</returns>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        public static T[,,] GetAsArray3D<T>(
            this MemoryBuffer<
                ArrayView3D<T, Stride3D.General>> buffer)
            where T : unmanaged =>
            buffer.View.GetAsArray3D();

        /// <summary>
        /// Copies the contents of the 3D view into a new
        /// 3D array
        /// while transposing the input buffer on the CPU.
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <param name="stream">The used accelerator stream.</param>
        /// <returns>A new array holding the requested contents.</returns>
        /// <remarks>
        /// CAUTION: this method transposes the data on the CPU.
        /// This method is not supported on accelerators.
        /// </remarks>
        public static T[,,] GetAsArray3D<T>(
            this MemoryBuffer<
                ArrayView3D<T, Stride3D.General>> buffer,
            AcceleratorStream stream)
            where T : unmanaged =>
            buffer.View.GetAsArray3D(stream);


        #endregion
    }
}