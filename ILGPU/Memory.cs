// ---------------------------------------------------------------------------------------
//                                        ILGPU
//                        Copyright (c) 2016-2022 ILGPU Project
//                                    www.ilgpu.net
//
// File: Memory.tt/Memory.cs
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

using ILGPU.Runtime;
using ILGPU.Util;
using System.Diagnostics;

namespace ILGPU
{
    partial class LocalMemory
    {
        /// <summary>
        /// Allocates a 1D chunk of local memory with the specified number
        /// of elements.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="extent">The extent of the buffer.</param>
        /// <returns>An allocated region of local memory.</returns>
        public static ArrayView1D<T, Stride1D.Dense> Allocate1D<T>(
            Index1D extent)
            where T : unmanaged =>
            Allocate1D<T, Stride1D.Dense>(extent, default);
    }

    partial class LocalMemory
    {
        /// <summary>
        /// Allocates a 1D chunk of local memory with the
        /// specified number of elements.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <typeparam name="TStride">The stride type.</typeparam>
        /// <param name="extent">The extent of the buffer.</param>
        /// <param name="stride">The buffer stride.</param>
        /// <returns>An allocated region of local memory.</returns>
        public static ArrayView1D<T, TStride>
            Allocate1D<T, TStride>(
            Index1D extent,
            TStride stride)
            where T : unmanaged
            where TStride : struct, IStride1D
        {
            Trace.Assert(
                extent.X >= 0,
                "Extent out of bounds");

            var baseView = Allocate<T>((int)stride.ComputeBufferLength(extent));
            return new ArrayView1D<T, TStride>(
                baseView,
                extent,
                stride);
        }
    }

    partial class LocalMemory
    {
        /// <summary>
        /// Allocates a 2D chunk of local memory with the
        /// specified number of elements.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <typeparam name="TStride">The stride type.</typeparam>
        /// <param name="extent">The extent of the buffer.</param>
        /// <param name="stride">The buffer stride.</param>
        /// <returns>An allocated region of local memory.</returns>
        public static ArrayView2D<T, TStride>
            Allocate2D<T, TStride>(
            Index2D extent,
            TStride stride)
            where T : unmanaged
            where TStride : struct, IStride2D
        {
            Trace.Assert(
                Bitwise.And(extent.X >= 0, extent.Y >= 0),
                "Extent out of bounds");

            var baseView = Allocate<T>((int)stride.ComputeBufferLength(extent));
            return new ArrayView2D<T, TStride>(
                baseView,
                extent,
                stride);
        }
    }

    partial class LocalMemory
    {
        /// <summary>
        /// Allocates a 3D chunk of local memory with the
        /// specified number of elements.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <typeparam name="TStride">The stride type.</typeparam>
        /// <param name="extent">The extent of the buffer.</param>
        /// <param name="stride">The buffer stride.</param>
        /// <returns>An allocated region of local memory.</returns>
        public static ArrayView3D<T, TStride>
            Allocate3D<T, TStride>(
            Index3D extent,
            TStride stride)
            where T : unmanaged
            where TStride : struct, IStride3D
        {
            Trace.Assert(
                Bitwise.And(extent.X >= 0, extent.Y >= 0, extent.Z >= 0),
                "Extent out of bounds");

            var baseView = Allocate<T>((int)stride.ComputeBufferLength(extent));
            return new ArrayView3D<T, TStride>(
                baseView,
                extent,
                stride);
        }
    }

    partial class SharedMemory
    {
        /// <summary>
        /// Allocates a 1D chunk of shared memory with the specified number
        /// of elements.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="extent">The extent of the buffer.</param>
        /// <returns>An allocated region of shared memory.</returns>
        public static ArrayView1D<T, Stride1D.Dense> Allocate1D<T>(
            Index1D extent)
            where T : unmanaged =>
            Allocate1D<T, Stride1D.Dense>(extent, default);
    }

    partial class SharedMemory
    {
        /// <summary>
        /// Allocates a 1D chunk of shared memory with the
        /// specified number of elements.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <typeparam name="TStride">The stride type.</typeparam>
        /// <param name="extent">The extent of the buffer.</param>
        /// <param name="stride">The buffer stride.</param>
        /// <returns>An allocated region of shared memory.</returns>
        public static ArrayView1D<T, TStride>
            Allocate1D<T, TStride>(
            Index1D extent,
            TStride stride)
            where T : unmanaged
            where TStride : struct, IStride1D
        {
            Trace.Assert(
                extent.X >= 0,
                "Extent out of bounds");

            var baseView = Allocate<T>((int)stride.ComputeBufferLength(extent));
            return new ArrayView1D<T, TStride>(
                baseView,
                extent,
                stride);
        }
    }

    partial class SharedMemory
    {
        /// <summary>
        /// Allocates a 2D chunk of shared memory with the
        /// specified number of elements.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <typeparam name="TStride">The stride type.</typeparam>
        /// <param name="extent">The extent of the buffer.</param>
        /// <param name="stride">The buffer stride.</param>
        /// <returns>An allocated region of shared memory.</returns>
        public static ArrayView2D<T, TStride>
            Allocate2D<T, TStride>(
            Index2D extent,
            TStride stride)
            where T : unmanaged
            where TStride : struct, IStride2D
        {
            Trace.Assert(
                Bitwise.And(extent.X >= 0, extent.Y >= 0),
                "Extent out of bounds");

            var baseView = Allocate<T>((int)stride.ComputeBufferLength(extent));
            return new ArrayView2D<T, TStride>(
                baseView,
                extent,
                stride);
        }
    }

    partial class SharedMemory
    {
        /// <summary>
        /// Allocates a 3D chunk of shared memory with the
        /// specified number of elements.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <typeparam name="TStride">The stride type.</typeparam>
        /// <param name="extent">The extent of the buffer.</param>
        /// <param name="stride">The buffer stride.</param>
        /// <returns>An allocated region of shared memory.</returns>
        public static ArrayView3D<T, TStride>
            Allocate3D<T, TStride>(
            Index3D extent,
            TStride stride)
            where T : unmanaged
            where TStride : struct, IStride3D
        {
            Trace.Assert(
                Bitwise.And(extent.X >= 0, extent.Y >= 0, extent.Z >= 0),
                "Extent out of bounds");

            var baseView = Allocate<T>((int)stride.ComputeBufferLength(extent));
            return new ArrayView3D<T, TStride>(
                baseView,
                extent,
                stride);
        }
    }




    partial class SharedMemory
    {
        /// <summary>
        /// Allocates a 2D chunk of shared memory with X
        /// as the leading dimension.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="extent">The number of elements to allocate.</param>
        /// <returns>An allocated 2D buffer on shared memory.</returns>
        public static ArrayView2D<T, Stride2D.DenseX> 
            Allocate2DDenseX<T>(
            in Index2D extent)
            where T : unmanaged =>
            Allocate2D<T, Stride2D.DenseX> (
                extent,
                new Stride2D.DenseX(extent.X));
    }
    partial class SharedMemory
    {
        /// <summary>
        /// Allocates a 2D chunk of shared memory with Y
        /// as the leading dimension.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="extent">The number of elements to allocate.</param>
        /// <returns>An allocated 2D buffer on shared memory.</returns>
        public static ArrayView2D<T, Stride2D.DenseY> 
            Allocate2DDenseY<T>(
            in Index2D extent)
            where T : unmanaged =>
            Allocate2D<T, Stride2D.DenseY> (
                extent,
                new Stride2D.DenseY(extent.Y));
    }


    partial class SharedMemory
    {
        /// <summary>
        /// Allocates a 3D chunk of shared memory with XY 
        /// as the leading dimensions.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="extent">The number of elements to allocate.</param>
        /// <returns>An allocated 3D buffer on shared memory.</returns>
        /// <remarks>
        /// Since XY are the leading dimension, combined dimension 
        /// (multiplied sizes) must be less or equal to <see cref="int.MaxValue"/>.
        /// </remarks>
        public static ArrayView3D<T, Stride3D.DenseXY> 
            Allocate3DDenseXY<T>(
            in Index3D extent)
            where T : unmanaged =>
            Allocate3D<T, Stride3D.DenseXY> (
                extent,
                new Stride3D.DenseXY(extent.X, extent.X * extent.Y));
    }
    partial class SharedMemory
    {
        /// <summary>
        /// Allocates a 3D chunk of shared memory with ZY 
        /// as the leading dimensions.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="extent">The number of elements to allocate.</param>
        /// <returns>An allocated 3D buffer on shared memory.</returns>
        /// <remarks>
        /// Since ZY are the leading dimension, combined dimension 
        /// (multiplied sizes) must be less or equal to <see cref="int.MaxValue"/>.
        /// </remarks>
        public static ArrayView3D<T, Stride3D.DenseZY> 
            Allocate3DDenseZY<T>(
            in Index3D extent)
            where T : unmanaged =>
            Allocate3D<T, Stride3D.DenseZY> (
                extent,
                new Stride3D.DenseZY(extent.Z * extent.Y, extent.Z));
    }
}