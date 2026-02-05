// ---------------------------------------------------------------------------------------
//                                        ILGPU
//                        Copyright (c) 2016-2021 ILGPU Project
//                                    www.ilgpu.net
//
// File: PageLockedArrays.Generated.tt/PageLockedArrays.Generated.cs
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

using System;
using System.Runtime.InteropServices;

namespace ILGPU.Runtime
{
    /// <summary>
    /// Represents a page locked 2D array in memory.
    /// </summary>
    /// <typeparam name="T">The array element type.</typeparam>
    public sealed class PageLockedArray2D<T> : PageLockedArray<T>
        where T : unmanaged
    {
        #region Static

        /// <summary>
        /// Represents an empty 2D array.
        /// </summary>
        public static readonly PageLockedArray2D<T> Empty =
            new PageLockedArray2D<T>(
                null,
                LongIndex2D.Zero);

        #endregion

        #region Instance

        private readonly T[,] array;
        private readonly GCHandle handle;

        /// <summary>
        /// Creates a new page-locked 2D array.
        /// </summary>
        /// <param name="accelerator">The parent accelerator.</param>
        /// <param name="extent">The number of elements to allocate.</param>
        internal unsafe PageLockedArray2D(
            Accelerator accelerator,
            in LongIndex2D extent)
        {
            Extent = extent;
            array = new T[extent.X, extent.Y];
            handle = GCHandle.Alloc(array, GCHandleType.Pinned);
            Initialize(accelerator, handle.AddrOfPinnedObject(), extent.Size);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Returns the extent of this array.
        /// </summary>
        public LongIndex2D Extent { get; }

        /// <inheritdoc/>
        public override unsafe Span<T> Span =>
            new Span<T>(
                handle.AddrOfPinnedObject().ToPointer(),
                array.Length);

        /// <summary>
        /// Returns a reference to the i-th array element.
        /// </summary>
        /// <param name="x">
        /// The X index.
        /// </param>
        /// <param name="y">
        /// The Y index.
        /// </param>
        /// <returns>The determined value reference.</returns>
        public ref T this[int x, int y] =>
            ref array[x, y];

        /// <summary>
        /// Returns a reference to the i-th array element.
        /// </summary>
        /// <param name="x">
        /// The X index.
        /// </param>
        /// <param name="y">
        /// The Y index.
        /// </param>
        /// <returns>The determined value reference.</returns>
        public ref T this[long x, long y] =>
            ref array[x, y];

        #endregion

        #region Methods

        /// <summary>
        /// Returns the underlying array.
        /// </summary>
        public T[,] GetArray() => array;

        #endregion

        #region IDisposable

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            handle.Free();
            base.Dispose(disposing);
        }

        #endregion
    }

    /// <summary>
    /// Represents a page locked 3D array in memory.
    /// </summary>
    /// <typeparam name="T">The array element type.</typeparam>
    public sealed class PageLockedArray3D<T> : PageLockedArray<T>
        where T : unmanaged
    {
        #region Static

        /// <summary>
        /// Represents an empty 3D array.
        /// </summary>
        public static readonly PageLockedArray3D<T> Empty =
            new PageLockedArray3D<T>(
                null,
                LongIndex3D.Zero);

        #endregion

        #region Instance

        private readonly T[,,] array;
        private readonly GCHandle handle;

        /// <summary>
        /// Creates a new page-locked 2D array.
        /// </summary>
        /// <param name="accelerator">The parent accelerator.</param>
        /// <param name="extent">The number of elements to allocate.</param>
        internal unsafe PageLockedArray3D(
            Accelerator accelerator,
            in LongIndex3D extent)
        {
            Extent = extent;
            array = new T[extent.X, extent.Y, extent.Z];
            handle = GCHandle.Alloc(array, GCHandleType.Pinned);
            Initialize(accelerator, handle.AddrOfPinnedObject(), extent.Size);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Returns the extent of this array.
        /// </summary>
        public LongIndex3D Extent { get; }

        /// <inheritdoc/>
        public override unsafe Span<T> Span =>
            new Span<T>(
                handle.AddrOfPinnedObject().ToPointer(),
                array.Length);

        /// <summary>
        /// Returns a reference to the i-th array element.
        /// </summary>
        /// <param name="x">
        /// The X index.
        /// </param>
        /// <param name="y">
        /// The Y index.
        /// </param>
        /// <param name="z">
        /// The Z index.
        /// </param>
        /// <returns>The determined value reference.</returns>
        public ref T this[int x, int y, int z] =>
            ref array[x, y, z];

        /// <summary>
        /// Returns a reference to the i-th array element.
        /// </summary>
        /// <param name="x">
        /// The X index.
        /// </param>
        /// <param name="y">
        /// The Y index.
        /// </param>
        /// <param name="z">
        /// The Z index.
        /// </param>
        /// <returns>The determined value reference.</returns>
        public ref T this[long x, long y, long z] =>
            ref array[x, y, z];

        #endregion

        #region Methods

        /// <summary>
        /// Returns the underlying array.
        /// </summary>
        public T[,,] GetArray() => array;

        #endregion

        #region IDisposable

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            handle.Free();
            base.Dispose(disposing);
        }

        #endregion
    }


    partial class PageLockedArrayExtensions
    {
        /// <summary>
        /// Creates a page locked array in CPU memory optimized for GPU data exchange.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="accelerator">The associated accelerator.</param>
        /// <param name="extent">The number of elements.</param>
        /// <returns>The allocated array.</returns>
        public static PageLockedArray1D<T>
            AllocatePageLocked1D<T>(
            this Accelerator accelerator,
            LongIndex1D extent)
            where T : unmanaged =>
            new PageLockedArray1D<T>(accelerator, extent);

        /// <summary>
        /// Creates a page locked array in CPU memory optimized for GPU data exchange.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="accelerator">The associated accelerator.</param>
        /// <param name="extent">The number of elements.</param>
        /// <returns>The allocated array.</returns>
        public static PageLockedArray2D<T>
            AllocatePageLocked2D<T>(
            this Accelerator accelerator,
            in LongIndex2D extent)
            where T : unmanaged =>
            new PageLockedArray2D<T>(accelerator, extent);

        /// <summary>
        /// Creates a page locked array in CPU memory optimized for GPU data exchange.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="accelerator">The associated accelerator.</param>
        /// <param name="extent">The number of elements.</param>
        /// <returns>The allocated array.</returns>
        public static PageLockedArray3D<T>
            AllocatePageLocked3D<T>(
            this Accelerator accelerator,
            in LongIndex3D extent)
            where T : unmanaged =>
            new PageLockedArray3D<T>(accelerator, extent);

    }
}