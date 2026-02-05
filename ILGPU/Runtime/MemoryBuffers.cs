// ---------------------------------------------------------------------------------------
//                                        ILGPU
//                        Copyright (c) 2016-2021 ILGPU Project
//                                    www.ilgpu.net
//
// File: MemoryBuffers.tt/MemoryBuffers.cs
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


using System.Diagnostics;

namespace ILGPU.Runtime
{
    /// <summary>
    /// Represents an opaque 1D memory buffer that can be used in the
    /// scope of ILGPU runtime kernels.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <typeparam name="TStride">The 1D stride type.</typeparam>
    /// <remarks>Members of this class are not thread safe.</remarks>
    [DebuggerDisplay("{View}")]
    public class MemoryBuffer1D<T, TStride> : MemoryBuffer<ArrayView1D<T, TStride>>
        where T : unmanaged
        where TStride : struct, IStride1D
    {
        #region Instance

        /// <summary>
        /// Initializes this memory buffer.
        /// </summary>
        /// <param name="accelerator">The associated accelerator.</param>
        /// <param name="view">The extent (number of elements).</param>
        protected internal MemoryBuffer1D(
            Accelerator accelerator,
            in ArrayView1D<T, TStride> view)
            : base(accelerator, view)
        { }

        #endregion

        #region Properties

        /// <summary>
        /// Returns the extent of this view.
        /// </summary>
        public LongIndex1D Extent => View.Extent;

        /// <summary>
        /// Returns the 32-bit extent of this view.
        /// </summary>
        public Index1D IntExtent => View.IntExtent;

        #endregion

        #region Methods

        /// <summary>
        /// Returns a contiguous view to this buffer.
        /// </summary>
        public ArrayView<T> AsContiguous() => View.AsContiguous();

        #endregion

        #region Operators

        /// <summary>
        /// Explicitly converts this buffer into a contiguous array view.
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        public static explicit operator ArrayView<T>(
            MemoryBuffer1D<T, TStride> buffer) =>
            buffer.AsContiguous();

        #endregion
    }

    /// <summary>
    /// Represents an opaque 2D memory buffer that can be used in the
    /// scope of ILGPU runtime kernels.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <typeparam name="TStride">The 2D stride type.</typeparam>
    /// <remarks>Members of this class are not thread safe.</remarks>
    [DebuggerDisplay("{View}")]
    public class MemoryBuffer2D<T, TStride> : MemoryBuffer<ArrayView2D<T, TStride>>
        where T : unmanaged
        where TStride : struct, IStride2D
    {
        #region Instance

        /// <summary>
        /// Initializes this memory buffer.
        /// </summary>
        /// <param name="accelerator">The associated accelerator.</param>
        /// <param name="view">The extent (number of elements).</param>
        protected internal MemoryBuffer2D(
            Accelerator accelerator,
            in ArrayView2D<T, TStride> view)
            : base(accelerator, view)
        { }

        #endregion

        #region Properties

        /// <summary>
        /// Returns the extent of this view.
        /// </summary>
        public LongIndex2D Extent => View.Extent;

        /// <summary>
        /// Returns the 32-bit extent of this view.
        /// </summary>
        public Index2D IntExtent => View.IntExtent;

        #endregion

        #region Methods

        /// <summary>
        /// Returns a contiguous view to this buffer.
        /// </summary>
        public ArrayView<T> AsContiguous() => View.AsContiguous();

        #endregion

        #region Operators

        /// <summary>
        /// Explicitly converts this buffer into a contiguous array view.
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        public static explicit operator ArrayView<T>(
            MemoryBuffer2D<T, TStride> buffer) =>
            buffer.AsContiguous();

        #endregion
    }

    /// <summary>
    /// Represents an opaque 3D memory buffer that can be used in the
    /// scope of ILGPU runtime kernels.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <typeparam name="TStride">The 3D stride type.</typeparam>
    /// <remarks>Members of this class are not thread safe.</remarks>
    [DebuggerDisplay("{View}")]
    public class MemoryBuffer3D<T, TStride> : MemoryBuffer<ArrayView3D<T, TStride>>
        where T : unmanaged
        where TStride : struct, IStride3D
    {
        #region Instance

        /// <summary>
        /// Initializes this memory buffer.
        /// </summary>
        /// <param name="accelerator">The associated accelerator.</param>
        /// <param name="view">The extent (number of elements).</param>
        protected internal MemoryBuffer3D(
            Accelerator accelerator,
            in ArrayView3D<T, TStride> view)
            : base(accelerator, view)
        { }

        #endregion

        #region Properties

        /// <summary>
        /// Returns the extent of this view.
        /// </summary>
        public LongIndex3D Extent => View.Extent;

        /// <summary>
        /// Returns the 32-bit extent of this view.
        /// </summary>
        public Index3D IntExtent => View.IntExtent;

        #endregion

        #region Methods

        /// <summary>
        /// Returns a contiguous view to this buffer.
        /// </summary>
        public ArrayView<T> AsContiguous() => View.AsContiguous();

        #endregion

        #region Operators

        /// <summary>
        /// Explicitly converts this buffer into a contiguous array view.
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        public static explicit operator ArrayView<T>(
            MemoryBuffer3D<T, TStride> buffer) =>
            buffer.AsContiguous();

        #endregion
    }

}