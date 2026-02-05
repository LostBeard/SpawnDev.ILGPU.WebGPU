// ---------------------------------------------------------------------------------------
//                                        ILGPU
//                        Copyright (c) 2016-2023 ILGPU Project
//                                    www.ilgpu.net
//
// File: StrideTypes.tt/StrideTypes.cs
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


using ILGPU.Util;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ILGPU
{
    /// <summary>
    /// An abstract 1D stride.
    /// </summary>
    public interface IStride1D : IStride<Index1D, LongIndex1D>
    {
        /// <summary>
        /// Returns the X dimension of the stride extent.
        /// </summary>
        int XStride { get; }

        /// <summary>
        /// Returns this stride as general 1D stride.
        /// </summary>
        Stride1D.General AsGeneral();
    }

    /// <summary>
    /// Container class for all 1D strides.
    /// </summary>
    public static partial class Stride1D
    {
        /// <summary>
        /// An infinite stride.
        /// </summary>
        public readonly struct Infinite : IStride1D
        {
            #region Properties

            /// <summary>
            /// Returns a constant stride of Index1D.Zero;
            /// </summary>
            public readonly Index1D StrideExtent => Index1D.Zero;

            /// <summary>
            /// Returns the constant 0.
            /// </summary>
            public readonly int XStride => 0;

            #endregion

            #region Methods

            /// <summary>
            /// Computes the linear 32-bit element address using the given index.
            /// </summary>
            /// <param name="index">The dimension for index computation.</param>
            /// <returns>The computed linear element address.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int ComputeElementIndex(Index1D index) => 0;

            /// <summary>
            /// Computes the linear 64-bit element address using the given index.
            /// </summary>
            /// <param name="index">The dimension for index computation.</param>
            /// <returns>The computed linear element address.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public long ComputeElementIndex(LongIndex1D index) => 0L;

            /// <summary>
            /// Computes the linear 32-bit element address using the given index while
            /// verifying that the given index is within the bounds of the specified
            /// extent.
            /// </summary>
            /// <param name="index">The dimension for the index computation.</param>
            /// <param name="extent">The extent dimension to check.</param>
            /// <returns>The computed linear element address.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int ComputeElementIndexChecked(
                Index1D index,
                Index1D extent) =>
                // Note that all element indices are in bounds
                ComputeElementIndex(index);

            /// <summary>
            /// Computes the linear 64-bit element address using the given index while
            /// verifying that the given index is within the bounds of the specified
            /// extent.
            /// </summary>
            /// <param name="index">The dimension for index computation.</param>
            /// <param name="extent">The extent dimension to check.</param>
            /// <returns>The computed linear element address.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public long ComputeElementIndexChecked(
                LongIndex1D index,
                LongIndex1D extent) =>
                // Note that all element indices are in bounds
                ComputeElementIndex(index);

            /// <summary>
            /// Reconstructs a 32-bit index from a linear element index.
            /// </summary>
            /// <param name="elementIndex">The linear element index.</param>
            /// <returns>The reconstructed index.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Index1D ReconstructFromElementIndex(int elementIndex)
            {
                Trace.Assert(
                    false,
                    "Reconstruction of general strides is not supported");
                return Index1D.Invalid;
            }

            /// <summary>
            /// Reconstructs a 64-bit index from a linear element index.
            /// </summary>
            /// <param name="elementIndex">The linear element index.</param>
            /// <returns>The reconstructed index.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public LongIndex1D ReconstructFromElementIndex(long elementIndex)
            {
                Trace.Assert(
                    false,
                    "Reconstruction of general strides is not supported");
                return LongIndex1D.Invalid;
            }

            /// <summary>
            /// Computes the 32-bit length of a required allocation.
            /// </summary>
            /// <param name="extent">The extent to allocate.</param>
            /// <returns>The 32-bit length of a required allocation.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int ComputeBufferLength(Index1D extent) => 1;

            /// <summary>
            /// Computes the 64-bit length of a required allocation.
            /// </summary>
            /// <param name="extent">The extent to allocate.</param>
            /// <returns>The 64-bit length of a required allocation.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public long ComputeBufferLength(LongIndex1D extent) => 1L;

            /// <summary>
            /// Returns this stride as general 1D stride.
            /// </summary>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public General AsGeneral() => new General(default);

            /// <summary>
            /// Converts this stride instance into a general 1D stride.
            /// </summary>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Stride1D.General To1DStride() => default;

            #endregion

            #region Object

            /// <summary>
            /// Returns the string representation of this stride.
            /// </summary>
            /// <returns>The string representation of this stride.</returns>
            [NotInsideKernel]
            public override string ToString() => "<inf>";

            #endregion
        }

        /// <summary>
        /// A dense stride without padding.
        /// </summary>
        public readonly partial struct Dense : IStride1D
        {
            #region Properties

            /// <summary>
            /// Returns a constant stride of Index1D.One;
            /// </summary>
            public readonly Index1D StrideExtent => Index1D.One;

            /// <summary>
            /// Returns the constant 1.
            /// </summary>
            public readonly int XStride => 1;

            #endregion

            #region Methods

            /// <summary>
            /// Computes the linear 32-bit element address using the given index.
            /// </summary>
            /// <param name="index">The dimension for index computation.</param>
            /// <returns>The computed linear element address.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int ComputeElementIndex(Index1D index) => index;

            /// <summary>
            /// Computes the linear 64-bit element address using the given index.
            /// </summary>
            /// <param name="index">The dimension for index computation.</param>
            /// <returns>The computed linear element address.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public long ComputeElementIndex(LongIndex1D index) => index;

            /// <summary>
            /// Computes the linear 32-bit element address using the given index while
            /// verifying that the given index is within the bounds of the specified
            /// extent.
            /// </summary>
            /// <param name="index">The dimension for the index computation.</param>
            /// <param name="extent">The extent dimension to check.</param>
            /// <returns>The computed linear element address.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int ComputeElementIndexChecked(
                Index1D index,
                Index1D extent) =>
                Stride1D.ComputeElementIndexChecked(this, index, extent);

            /// <summary>
            /// Computes the linear 64-bit element address using the given index while
            /// verifying that the given index is within the bounds of the specified
            /// extent.
            /// </summary>
            /// <param name="index">The dimension for index computation.</param>
            /// <param name="extent">The extent dimension to check.</param>
            /// <returns>The computed linear element address.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public long ComputeElementIndexChecked(
                LongIndex1D index,
                LongIndex1D extent) =>
                Stride1D.ComputeElementIndexChecked(this, index, extent);

            /// <summary>
            /// Reconstructs a 32-bit index from a linear element index.
            /// </summary>
            /// <param name="elementIndex">The linear element index.</param>
            /// <returns>The reconstructed index.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Index1D ReconstructFromElementIndex(int elementIndex) =>
                elementIndex;

            /// <summary>
            /// Reconstructs a 64-bit index from a linear element index.
            /// </summary>
            /// <param name="elementIndex">The linear element index.</param>
            /// <returns>The reconstructed index.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public LongIndex1D ReconstructFromElementIndex(long elementIndex) =>
                elementIndex;

            /// <summary>
            /// Computes the 32-bit length of a required allocation.
            /// </summary>
            /// <param name="extent">The extent to allocate.</param>
            /// <returns>The 32-bit length of a required allocation.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int ComputeBufferLength(Index1D extent) => extent;

            /// <summary>
            /// Computes the 64-bit length of a required allocation.
            /// </summary>
            /// <param name="extent">The extent to allocate.</param>
            /// <returns>The 64-bit length of a required allocation.</returns>
            public long ComputeBufferLength(LongIndex1D extent) => extent;

            /// <summary>
            /// Returns this stride as general 1D stride.
            /// </summary>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public General AsGeneral() =>
                new General(
                    XStride
                );

            /// <summary>
            /// Converts this stride instance into a general 1D stride.
            /// </summary>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public General To1DStride() => AsGeneral();

            #endregion

            #region Object

            /// <summary>
            /// Returns the string representation of this stride.
            /// </summary>
            /// <returns>The string representation of this stride.</returns>
            [NotInsideKernel]
            public override string ToString() => "<dense>";

            #endregion
        }

        /// <summary>
        /// A general 1D stride.
        /// </summary>
        public struct General : IStride1D
        {
            #region Instance

            /// <summary>
            /// Creates a new general 1D stride.
            /// </summary>
            /// <param name="stride">The underlying stride information.</param>
            public General(Index1D stride)
            {
                Trace.Assert(
                    stride.X >= 0,
                    "stride out of range");
                StrideExtent = stride;
            }

            #endregion

            #region Properties

            /// <summary>
            /// Returns the associated stride extent.
            /// </summary>
            public Index1D StrideExtent { get; }

            /// <summary>
            /// Returns the X-dimension stride.
            /// </summary>
            public int XStride =>
                StrideExtent.X;

            #endregion

            #region Methods

            /// <summary>
            /// Computes the linear 32-bit element address using the given index.
            /// </summary>
            /// <param name="index">The dimension for index computation.</param>
            /// <returns>The computed linear element address.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int ComputeElementIndex(Index1D index) =>
                Stride1D.ComputeElementIndex(this, index);

            /// <summary>
            /// Computes the linear 64-bit element address using the given index.
            /// </summary>
            /// <param name="index">The dimension for index computation.</param>
            /// <returns>The computed linear element address.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public long ComputeElementIndex(LongIndex1D index) =>
                Stride1D.ComputeElementIndex(this, index);

            /// <summary>
            /// Computes the linear 32-bit element address using the given index while
            /// verifying that the given index is within the bounds of the specified
            /// extent.
            /// </summary>
            /// <param name="index">The dimension for the index computation.</param>
            /// <param name="extent">The extent dimension to check.</param>
            /// <returns>The computed linear element address.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int ComputeElementIndexChecked(
                Index1D index,
                Index1D extent) =>
                Stride1D.ComputeElementIndexChecked(this, index, extent);

            /// <summary>
            /// Computes the linear 64-bit element address using the given index while
            /// verifying that the given index is within the bounds of the specified
            /// extent.
            /// </summary>
            /// <param name="index">The dimension for index computation.</param>
            /// <param name="extent">The extent dimension to check.</param>
            /// <returns>The computed linear element address.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public long ComputeElementIndexChecked(
                LongIndex1D index,
                LongIndex1D extent) =>
                Stride1D.ComputeElementIndexChecked(this, index, extent);

            /// <summary>
            /// Reconstructs a 32-bit index from a linear element index.
            /// </summary>
            /// <param name="elementIndex">The linear element index.</param>
            /// <returns>The reconstructed index.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Index1D ReconstructFromElementIndex(int elementIndex)
            {
                return new Index1D(elementIndex);
            }

            /// <summary>
            /// Reconstructs a 64-bit index from a linear element index.
            /// </summary>
            /// <param name="elementIndex">The linear element index.</param>
            /// <returns>The reconstructed index.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public LongIndex1D ReconstructFromElementIndex(long elementIndex)
            {
                return new LongIndex1D(elementIndex);
            }

            /// <summary>
            /// Computes the 32-bit length of a required allocation.
            /// </summary>
            /// <param name="extent">The extent to allocate.</param>
            /// <returns>The 32-bit length of a required allocation.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int ComputeBufferLength(Index1D extent) =>
                Stride1D.ComputeBufferLength(this, extent);

            /// <summary>
            /// Computes the 64-bit length of a required allocation.
            /// </summary>
            /// <param name="extent">The extent to allocate.</param>
            /// <returns>The 64-bit length of a required allocation.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public long ComputeBufferLength(LongIndex1D extent) =>
                Stride1D.ComputeBufferLength(this, extent);

            /// <summary>
            /// Returns this stride as general 1D stride.
            /// </summary>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public General AsGeneral() => this;

            /// <summary>
            /// Converts this stride instance into a general 1D stride.
            /// </summary>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Stride1D.General To1DStride() =>
                new Stride1D.General(XStride);

            #endregion

            #region Object

            /// <summary>
            /// Returns the string representation of this stride.
            /// </summary>
            /// <returns>The string representation of this stride.</returns>
            [NotInsideKernel]
            public override string ToString() => StrideExtent.ToString();

            #endregion
        }

        /// <summary>
        /// Computes the linear 32-bit element address using the given index.
        /// </summary>
        /// <param name="stride">The stride to use.</param>
        /// <param name="index">The dimension for index computation.</param>
        /// <returns>The computed linear element address.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ComputeElementIndex<TStride>(
            this TStride stride,
            Index1D index)
            where TStride : struct, IStride1D =>
            index.X * stride.XStride;

        /// <summary>
        /// Computes the linear 64-bit element address using the given index.
        /// </summary>
        /// <param name="stride">The stride to use.</param>
        /// <param name="index">The dimension for index computation.</param>
        /// <returns>The computed linear element address.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ComputeElementIndex<TStride>(
            this TStride stride,
            LongIndex1D index)
            where TStride : struct, IStride1D =>
            index.X * stride.XStride;

        /// <summary>
        /// Computes the linear 32-bit element address using the given index while
        /// verifying that the given index is within the bounds of the specified extent.
        /// </summary>
        /// <param name="stride">The stride to use.</param>
        /// <param name="index">The dimension for the index computation.</param>
        /// <param name="extent">The extent dimension to check.</param>
        /// <returns>The computed linear element address.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ComputeElementIndexChecked<TStride>(
            this TStride stride,
            Index1D index,
            Index1D extent)
            where TStride : struct, IStride1D
        {
            Trace.Assert(
                Bitwise.Or(
                    // Default bound checks
                    Bitwise.And(
                        index.X >= 0,
                        index.X < extent.X),
                    // Zero length views
                    Bitwise.And(index.X == 0, extent.X == 0)),
                "X index out of bounds");
            return ComputeElementIndex(stride, index);
        }

        /// <summary>
        /// Computes the linear 64-bit element address using the given index while
        /// verifying that the given index is within the bounds of the specified extent.
        /// </summary>
        /// <param name="stride">The stride to use.</param>
        /// <param name="index">The dimension for index computation.</param>
        /// <param name="extent">The extent dimension to check.</param>
        /// <returns>The computed linear element address.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ComputeElementIndexChecked<TStride>(
            this TStride stride,
            LongIndex1D index,
            LongIndex1D extent)
            where TStride : struct, IStride1D
        {
            Trace.Assert(
                Bitwise.And(
                    index.X >= 0,
                    index.X < extent.X),
                "X index out of bounds");
            return ComputeElementIndex(stride, index);
        }

        /// <summary>
        /// Computes the 32-bit length of a required allocation.
        /// </summary>
        /// <param name="stride">The stride to use.</param>
        /// <param name="extent">The extent to allocate.</param>
        /// <returns>The 32-bit length of a required allocation.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ComputeBufferLength<TStride>(
            this TStride stride,
            Index1D extent)
            where TStride : struct, IStride1D
        {
            if (extent.X == 0)
                return 0;
            return ComputeElementIndex(stride, extent - Index1D.One) + 1;
        }

        /// <summary>
        /// Computes the 64-bit length of a required allocation.
        /// </summary>
        /// <param name="stride">The stride to use.</param>
        /// <param name="extent">The extent to allocate.</param>
        /// <returns>The 64-bit length of a required allocation.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ComputeBufferLength<TStride>(
            this TStride stride,
            LongIndex1D extent)
            where TStride : struct, IStride1D
        {
            if (extent.X == 0L)
                return 0L;
            return ComputeElementIndex(stride, extent - LongIndex1D.One) + 1L;
        }

    }

    /// <summary>
    /// An abstract 2D stride.
    /// </summary>
    public interface IStride2D : IStride<Index2D, LongIndex2D>
    {
        /// <summary>
        /// Returns the X dimension of the stride extent.
        /// </summary>
        int XStride { get; }

        /// <summary>
        /// Returns the Y dimension of the stride extent.
        /// </summary>
        int YStride { get; }

        /// <summary>
        /// Returns this stride as general 2D stride.
        /// </summary>
        Stride2D.General AsGeneral();
    }

    /// <summary>
    /// Container class for all 2D strides.
    /// </summary>
    public static partial class Stride2D
    {
        /// <summary>
        /// An infinite stride.
        /// </summary>
        public readonly struct Infinite : IStride2D
        {
            #region Properties

            /// <summary>
            /// Returns a constant stride of Index2D.Zero;
            /// </summary>
            public readonly Index2D StrideExtent => Index2D.Zero;

            /// <summary>
            /// Returns the constant 0.
            /// </summary>
            public readonly int XStride => 0;

            /// <summary>
            /// Returns the constant 0.
            /// </summary>
            public readonly int YStride => 0;

            #endregion

            #region Methods

            /// <summary>
            /// Computes the linear 32-bit element address using the given index.
            /// </summary>
            /// <param name="index">The dimension for index computation.</param>
            /// <returns>The computed linear element address.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int ComputeElementIndex(Index2D index) => 0;

            /// <summary>
            /// Computes the linear 64-bit element address using the given index.
            /// </summary>
            /// <param name="index">The dimension for index computation.</param>
            /// <returns>The computed linear element address.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public long ComputeElementIndex(LongIndex2D index) => 0L;

            /// <summary>
            /// Computes the linear 32-bit element address using the given index while
            /// verifying that the given index is within the bounds of the specified
            /// extent.
            /// </summary>
            /// <param name="index">The dimension for the index computation.</param>
            /// <param name="extent">The extent dimension to check.</param>
            /// <returns>The computed linear element address.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int ComputeElementIndexChecked(
                Index2D index,
                Index2D extent) =>
                // Note that all element indices are in bounds
                ComputeElementIndex(index);

            /// <summary>
            /// Computes the linear 64-bit element address using the given index while
            /// verifying that the given index is within the bounds of the specified
            /// extent.
            /// </summary>
            /// <param name="index">The dimension for index computation.</param>
            /// <param name="extent">The extent dimension to check.</param>
            /// <returns>The computed linear element address.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public long ComputeElementIndexChecked(
                LongIndex2D index,
                LongIndex2D extent) =>
                // Note that all element indices are in bounds
                ComputeElementIndex(index);

            /// <summary>
            /// Reconstructs a 32-bit index from a linear element index.
            /// </summary>
            /// <param name="elementIndex">The linear element index.</param>
            /// <returns>The reconstructed index.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Index2D ReconstructFromElementIndex(int elementIndex)
            {
                Trace.Assert(
                    false,
                    "Reconstruction of general strides is not supported");
                return Index2D.Invalid;
            }

            /// <summary>
            /// Reconstructs a 64-bit index from a linear element index.
            /// </summary>
            /// <param name="elementIndex">The linear element index.</param>
            /// <returns>The reconstructed index.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public LongIndex2D ReconstructFromElementIndex(long elementIndex)
            {
                Trace.Assert(
                    false,
                    "Reconstruction of general strides is not supported");
                return LongIndex2D.Invalid;
            }

            /// <summary>
            /// Computes the 32-bit length of a required allocation.
            /// </summary>
            /// <param name="extent">The extent to allocate.</param>
            /// <returns>The 32-bit length of a required allocation.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int ComputeBufferLength(Index2D extent) => 1;

            /// <summary>
            /// Computes the 64-bit length of a required allocation.
            /// </summary>
            /// <param name="extent">The extent to allocate.</param>
            /// <returns>The 64-bit length of a required allocation.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public long ComputeBufferLength(LongIndex2D extent) => 1L;

            /// <summary>
            /// Returns this stride as general 2D stride.
            /// </summary>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public General AsGeneral() => new General(default);

            /// <summary>
            /// Converts this stride instance into a general 1D stride.
            /// </summary>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Stride1D.General To1DStride() => default;

            #endregion

            #region Object

            /// <summary>
            /// Returns the string representation of this stride.
            /// </summary>
            /// <returns>The string representation of this stride.</returns>
            [NotInsideKernel]
            public override string ToString() => "<inf>";

            #endregion
        }

        /// <summary>
        /// Returns the size of the leading dimension based on the given extent.
        /// </summary>
        public delegate long GetLeadingDimensionSize(LongIndex2D extent);

        /// <summary>
        /// Builds a stride based on the given extent and the size of the leading
        /// dimension.
        /// </summary>
        public delegate TStride BuildStride<TStride>(
            LongIndex2D extent,
            int leadingDimension)
            where TStride : struct, IStride2D;

        /// <summary>
        /// A general 2D stride.
        /// </summary>
        public struct General : IStride2D
        {
            #region Instance

            /// <summary>
            /// Creates a new general 2D stride.
            /// </summary>
            /// <param name="stride">The underlying stride information.</param>
            public General(Index2D stride)
            {
                Trace.Assert(
                    stride.X >= 0,
                    "stride out of range");
                Trace.Assert(
                    stride.Y >= 0,
                    "stride out of range");
                StrideExtent = stride;
            }

            #endregion

            #region Properties

            /// <summary>
            /// Returns the associated stride extent.
            /// </summary>
            public Index2D StrideExtent { get; }

            /// <summary>
            /// Returns the X-dimension stride.
            /// </summary>
            public int XStride =>
                StrideExtent.X;

            /// <summary>
            /// Returns the Y-dimension stride.
            /// </summary>
            public int YStride =>
                StrideExtent.Y;

            #endregion

            #region Methods

            /// <summary>
            /// Computes the linear 32-bit element address using the given index.
            /// </summary>
            /// <param name="index">The dimension for index computation.</param>
            /// <returns>The computed linear element address.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int ComputeElementIndex(Index2D index) =>
                Stride2D.ComputeElementIndex(this, index);

            /// <summary>
            /// Computes the linear 64-bit element address using the given index.
            /// </summary>
            /// <param name="index">The dimension for index computation.</param>
            /// <returns>The computed linear element address.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public long ComputeElementIndex(LongIndex2D index) =>
                Stride2D.ComputeElementIndex(this, index);

            /// <summary>
            /// Computes the linear 32-bit element address using the given index while
            /// verifying that the given index is within the bounds of the specified
            /// extent.
            /// </summary>
            /// <param name="index">The dimension for the index computation.</param>
            /// <param name="extent">The extent dimension to check.</param>
            /// <returns>The computed linear element address.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int ComputeElementIndexChecked(
                Index2D index,
                Index2D extent) =>
                Stride2D.ComputeElementIndexChecked(this, index, extent);

            /// <summary>
            /// Computes the linear 64-bit element address using the given index while
            /// verifying that the given index is within the bounds of the specified
            /// extent.
            /// </summary>
            /// <param name="index">The dimension for index computation.</param>
            /// <param name="extent">The extent dimension to check.</param>
            /// <returns>The computed linear element address.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public long ComputeElementIndexChecked(
                LongIndex2D index,
                LongIndex2D extent) =>
                Stride2D.ComputeElementIndexChecked(this, index, extent);

            /// <summary>
            /// Reconstructs a 32-bit index from a linear element index.
            /// </summary>
            /// <param name="elementIndex">The linear element index.</param>
            /// <returns>The reconstructed index.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Index2D ReconstructFromElementIndex(int elementIndex)
            {
                bool prefer1st =
                    XStride >
                    YStride;
                var index = prefer1st
                    ? new DenseY(XStride)
                        .ReconstructFromElementIndex(elementIndex)
                    : new DenseX(YStride)
                        .ReconstructFromElementIndex(elementIndex);
                int minDimension = Utilities.Select(
                    prefer1st,
                    YStride,
                    XStride);
                return new Index2D(index.X, index.Y / minDimension);
            }

            /// <summary>
            /// Reconstructs a 64-bit index from a linear element index.
            /// </summary>
            /// <param name="elementIndex">The linear element index.</param>
            /// <returns>The reconstructed index.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public LongIndex2D ReconstructFromElementIndex(long elementIndex)
            {
                bool prefer1st =
                    XStride >
                    YStride;
                var index = prefer1st
                    ? new DenseY(XStride)
                        .ReconstructFromElementIndex(elementIndex)
                    : new DenseX(YStride)
                        .ReconstructFromElementIndex(elementIndex);
                int minDimension = Utilities.Select(
                    prefer1st,
                    YStride,
                    XStride);
                return new LongIndex2D(index.X, index.Y / minDimension);
            }

            /// <summary>
            /// Computes the 32-bit length of a required allocation.
            /// </summary>
            /// <param name="extent">The extent to allocate.</param>
            /// <returns>The 32-bit length of a required allocation.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int ComputeBufferLength(Index2D extent) =>
                Stride2D.ComputeBufferLength(this, extent);

            /// <summary>
            /// Computes the 64-bit length of a required allocation.
            /// </summary>
            /// <param name="extent">The extent to allocate.</param>
            /// <returns>The 64-bit length of a required allocation.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public long ComputeBufferLength(LongIndex2D extent) =>
                Stride2D.ComputeBufferLength(this, extent);

            /// <summary>
            /// Returns this stride as general 2D stride.
            /// </summary>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public General AsGeneral() => this;

            /// <summary>
            /// Converts this stride instance into a general 1D stride.
            /// </summary>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Stride1D.General To1DStride() =>
                new Stride1D.General(XStride);

            #endregion

            #region Object

            /// <summary>
            /// Returns the string representation of this stride.
            /// </summary>
            /// <returns>The string representation of this stride.</returns>
            [NotInsideKernel]
            public override string ToString() => StrideExtent.ToString();

            #endregion
        }

        /// <summary>
        /// Computes the linear 32-bit element address using the given index.
        /// </summary>
        /// <param name="stride">The stride to use.</param>
        /// <param name="index">The dimension for index computation.</param>
        /// <returns>The computed linear element address.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ComputeElementIndex<TStride>(
            this TStride stride,
            Index2D index)
            where TStride : struct, IStride2D =>
            index.X * stride.XStride +
            index.Y * stride.YStride;

        /// <summary>
        /// Computes the linear 64-bit element address using the given index.
        /// </summary>
        /// <param name="stride">The stride to use.</param>
        /// <param name="index">The dimension for index computation.</param>
        /// <returns>The computed linear element address.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ComputeElementIndex<TStride>(
            this TStride stride,
            LongIndex2D index)
            where TStride : struct, IStride2D =>
            index.X * stride.XStride +
            index.Y * stride.YStride;

        /// <summary>
        /// Computes the linear 32-bit element address using the given index while
        /// verifying that the given index is within the bounds of the specified extent.
        /// </summary>
        /// <param name="stride">The stride to use.</param>
        /// <param name="index">The dimension for the index computation.</param>
        /// <param name="extent">The extent dimension to check.</param>
        /// <returns>The computed linear element address.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ComputeElementIndexChecked<TStride>(
            this TStride stride,
            Index2D index,
            Index2D extent)
            where TStride : struct, IStride2D
        {
            Trace.Assert(
                Bitwise.Or(
                    // Default bound checks
                    Bitwise.And(
                        index.X >= 0,
                        index.X < extent.X),
                    // Zero length views
                    Bitwise.And(index.X == 0, extent.X == 0)),
                "X index out of bounds");
            Trace.Assert(
                Bitwise.Or(
                    // Default bound checks
                    Bitwise.And(
                        index.Y >= 0,
                        index.Y < extent.Y),
                    // Zero length views
                    Bitwise.And(index.Y == 0, extent.Y == 0)),
                "Y index out of bounds");
            return ComputeElementIndex(stride, index);
        }

        /// <summary>
        /// Computes the linear 64-bit element address using the given index while
        /// verifying that the given index is within the bounds of the specified extent.
        /// </summary>
        /// <param name="stride">The stride to use.</param>
        /// <param name="index">The dimension for index computation.</param>
        /// <param name="extent">The extent dimension to check.</param>
        /// <returns>The computed linear element address.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ComputeElementIndexChecked<TStride>(
            this TStride stride,
            LongIndex2D index,
            LongIndex2D extent)
            where TStride : struct, IStride2D
        {
            Trace.Assert(
                Bitwise.And(
                    index.X >= 0,
                    index.X < extent.X),
                "X index out of bounds");
            Trace.Assert(
                Bitwise.And(
                    index.Y >= 0,
                    index.Y < extent.Y),
                "Y index out of bounds");
            return ComputeElementIndex(stride, index);
        }

        /// <summary>
        /// Computes the 32-bit length of a required allocation.
        /// </summary>
        /// <param name="stride">The stride to use.</param>
        /// <param name="extent">The extent to allocate.</param>
        /// <returns>The 32-bit length of a required allocation.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ComputeBufferLength<TStride>(
            this TStride stride,
            Index2D extent)
            where TStride : struct, IStride2D
        {
            if (extent.X == 0)
                return 0;
            if (extent.Y == 0)
                return 0;
            return ComputeElementIndex(stride, extent - Index2D.One) + 1;
        }

        /// <summary>
        /// Computes the 64-bit length of a required allocation.
        /// </summary>
        /// <param name="stride">The stride to use.</param>
        /// <param name="extent">The extent to allocate.</param>
        /// <returns>The 64-bit length of a required allocation.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ComputeBufferLength<TStride>(
            this TStride stride,
            LongIndex2D extent)
            where TStride : struct, IStride2D
        {
            if (extent.X == 0L)
                return 0L;
            if (extent.Y == 0L)
                return 0L;
            return ComputeElementIndex(stride, extent - LongIndex2D.One) + 1L;
        }

    }

    /// <summary>
    /// An abstract 3D stride.
    /// </summary>
    public interface IStride3D : IStride<Index3D, LongIndex3D>
    {
        /// <summary>
        /// Returns the X dimension of the stride extent.
        /// </summary>
        int XStride { get; }

        /// <summary>
        /// Returns the Y dimension of the stride extent.
        /// </summary>
        int YStride { get; }

        /// <summary>
        /// Returns the Z dimension of the stride extent.
        /// </summary>
        int ZStride { get; }

        /// <summary>
        /// Returns this stride as general 3D stride.
        /// </summary>
        Stride3D.General AsGeneral();
    }

    /// <summary>
    /// Container class for all 3D strides.
    /// </summary>
    public static partial class Stride3D
    {
        /// <summary>
        /// An infinite stride.
        /// </summary>
        public readonly struct Infinite : IStride3D
        {
            #region Properties

            /// <summary>
            /// Returns a constant stride of Index3D.Zero;
            /// </summary>
            public readonly Index3D StrideExtent => Index3D.Zero;

            /// <summary>
            /// Returns the constant 0.
            /// </summary>
            public readonly int XStride => 0;

            /// <summary>
            /// Returns the constant 0.
            /// </summary>
            public readonly int YStride => 0;

            /// <summary>
            /// Returns the constant 0.
            /// </summary>
            public readonly int ZStride => 0;

            #endregion

            #region Methods

            /// <summary>
            /// Computes the linear 32-bit element address using the given index.
            /// </summary>
            /// <param name="index">The dimension for index computation.</param>
            /// <returns>The computed linear element address.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int ComputeElementIndex(Index3D index) => 0;

            /// <summary>
            /// Computes the linear 64-bit element address using the given index.
            /// </summary>
            /// <param name="index">The dimension for index computation.</param>
            /// <returns>The computed linear element address.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public long ComputeElementIndex(LongIndex3D index) => 0L;

            /// <summary>
            /// Computes the linear 32-bit element address using the given index while
            /// verifying that the given index is within the bounds of the specified
            /// extent.
            /// </summary>
            /// <param name="index">The dimension for the index computation.</param>
            /// <param name="extent">The extent dimension to check.</param>
            /// <returns>The computed linear element address.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int ComputeElementIndexChecked(
                Index3D index,
                Index3D extent) =>
                // Note that all element indices are in bounds
                ComputeElementIndex(index);

            /// <summary>
            /// Computes the linear 64-bit element address using the given index while
            /// verifying that the given index is within the bounds of the specified
            /// extent.
            /// </summary>
            /// <param name="index">The dimension for index computation.</param>
            /// <param name="extent">The extent dimension to check.</param>
            /// <returns>The computed linear element address.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public long ComputeElementIndexChecked(
                LongIndex3D index,
                LongIndex3D extent) =>
                // Note that all element indices are in bounds
                ComputeElementIndex(index);

            /// <summary>
            /// Reconstructs a 32-bit index from a linear element index.
            /// </summary>
            /// <param name="elementIndex">The linear element index.</param>
            /// <returns>The reconstructed index.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Index3D ReconstructFromElementIndex(int elementIndex)
            {
                Trace.Assert(
                    false,
                    "Reconstruction of general strides is not supported");
                return Index3D.Invalid;
            }

            /// <summary>
            /// Reconstructs a 64-bit index from a linear element index.
            /// </summary>
            /// <param name="elementIndex">The linear element index.</param>
            /// <returns>The reconstructed index.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public LongIndex3D ReconstructFromElementIndex(long elementIndex)
            {
                Trace.Assert(
                    false,
                    "Reconstruction of general strides is not supported");
                return LongIndex3D.Invalid;
            }

            /// <summary>
            /// Computes the 32-bit length of a required allocation.
            /// </summary>
            /// <param name="extent">The extent to allocate.</param>
            /// <returns>The 32-bit length of a required allocation.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int ComputeBufferLength(Index3D extent) => 1;

            /// <summary>
            /// Computes the 64-bit length of a required allocation.
            /// </summary>
            /// <param name="extent">The extent to allocate.</param>
            /// <returns>The 64-bit length of a required allocation.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public long ComputeBufferLength(LongIndex3D extent) => 1L;

            /// <summary>
            /// Returns this stride as general 3D stride.
            /// </summary>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public General AsGeneral() => new General(default);

            /// <summary>
            /// Converts this stride instance into a general 1D stride.
            /// </summary>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Stride1D.General To1DStride() => default;

            #endregion

            #region Object

            /// <summary>
            /// Returns the string representation of this stride.
            /// </summary>
            /// <returns>The string representation of this stride.</returns>
            [NotInsideKernel]
            public override string ToString() => "<inf>";

            #endregion
        }

        /// <summary>
        /// Returns the size of the leading dimension based on the given extent.
        /// </summary>
        public delegate long GetLeadingDimensionSize(LongIndex3D extent);

        /// <summary>
        /// Builds a stride based on the given extent and the size of the leading
        /// dimension.
        /// </summary>
        public delegate TStride BuildStride<TStride>(
            LongIndex3D extent,
            int leadingDimension)
            where TStride : struct, IStride3D;

        /// <summary>
        /// A general 3D stride.
        /// </summary>
        public struct General : IStride3D
        {
            #region Instance

            /// <summary>
            /// Creates a new general 3D stride.
            /// </summary>
            /// <param name="stride">The underlying stride information.</param>
            public General(Index3D stride)
            {
                Trace.Assert(
                    stride.X >= 0,
                    "stride out of range");
                Trace.Assert(
                    stride.Y >= 0,
                    "stride out of range");
                Trace.Assert(
                    stride.Z >= 0,
                    "stride out of range");
                StrideExtent = stride;
            }

            #endregion

            #region Properties

            /// <summary>
            /// Returns the associated stride extent.
            /// </summary>
            public Index3D StrideExtent { get; }

            /// <summary>
            /// Returns the X-dimension stride.
            /// </summary>
            public int XStride =>
                StrideExtent.X;

            /// <summary>
            /// Returns the Y-dimension stride.
            /// </summary>
            public int YStride =>
                StrideExtent.Y;

            /// <summary>
            /// Returns the Z-dimension stride.
            /// </summary>
            public int ZStride =>
                StrideExtent.Z;

            #endregion

            #region Methods

            /// <summary>
            /// Computes the linear 32-bit element address using the given index.
            /// </summary>
            /// <param name="index">The dimension for index computation.</param>
            /// <returns>The computed linear element address.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int ComputeElementIndex(Index3D index) =>
                Stride3D.ComputeElementIndex(this, index);

            /// <summary>
            /// Computes the linear 64-bit element address using the given index.
            /// </summary>
            /// <param name="index">The dimension for index computation.</param>
            /// <returns>The computed linear element address.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public long ComputeElementIndex(LongIndex3D index) =>
                Stride3D.ComputeElementIndex(this, index);

            /// <summary>
            /// Computes the linear 32-bit element address using the given index while
            /// verifying that the given index is within the bounds of the specified
            /// extent.
            /// </summary>
            /// <param name="index">The dimension for the index computation.</param>
            /// <param name="extent">The extent dimension to check.</param>
            /// <returns>The computed linear element address.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int ComputeElementIndexChecked(
                Index3D index,
                Index3D extent) =>
                Stride3D.ComputeElementIndexChecked(this, index, extent);

            /// <summary>
            /// Computes the linear 64-bit element address using the given index while
            /// verifying that the given index is within the bounds of the specified
            /// extent.
            /// </summary>
            /// <param name="index">The dimension for index computation.</param>
            /// <param name="extent">The extent dimension to check.</param>
            /// <returns>The computed linear element address.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public long ComputeElementIndexChecked(
                LongIndex3D index,
                LongIndex3D extent) =>
                Stride3D.ComputeElementIndexChecked(this, index, extent);

            /// <summary>
            /// Reconstructs a 32-bit index from a linear element index.
            /// </summary>
            /// <param name="elementIndex">The linear element index.</param>
            /// <returns>The reconstructed index.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Index3D ReconstructFromElementIndex(int elementIndex)
            {
                bool prefer1st =
                    XStride >
                    ZStride;
                Trace.Assert(
                    !prefer1st &
                    ZStride >
                    YStride |
                    prefer1st &
                    YStride >
                    ZStride,
                    "Reconstruction of general 3D strides is not supported");
                int mainDim = Utilities.Select(
                    prefer1st,
                    ZStride,
                    XStride);
                var index = prefer1st
                    ? new DenseZY(
                        XStride * mainDim,
                        YStride * mainDim)
                        .ReconstructFromElementIndex(elementIndex)
                    : new DenseXY(
                        YStride * mainDim,
                        ZStride * mainDim)
                        .ReconstructFromElementIndex(elementIndex);
                return index;
            }

            /// <summary>
            /// Reconstructs a 64-bit index from a linear element index.
            /// </summary>
            /// <param name="elementIndex">The linear element index.</param>
            /// <returns>The reconstructed index.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public LongIndex3D ReconstructFromElementIndex(long elementIndex)
            {
                bool prefer1st =
                    XStride >
                    ZStride;
                Trace.Assert(
                    !prefer1st &
                    ZStride >
                    YStride |
                    prefer1st &
                    YStride >
                    ZStride,
                    "Reconstruction of general 3D strides is not supported");
                int mainDim = Utilities.Select(
                    prefer1st,
                    ZStride,
                    XStride);
                var index = prefer1st
                    ? new DenseZY(
                        XStride * mainDim,
                        YStride * mainDim)
                        .ReconstructFromElementIndex(elementIndex)
                    : new DenseXY(
                        YStride * mainDim,
                        ZStride * mainDim)
                        .ReconstructFromElementIndex(elementIndex);
                return index;
            }

            /// <summary>
            /// Computes the 32-bit length of a required allocation.
            /// </summary>
            /// <param name="extent">The extent to allocate.</param>
            /// <returns>The 32-bit length of a required allocation.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int ComputeBufferLength(Index3D extent) =>
                Stride3D.ComputeBufferLength(this, extent);

            /// <summary>
            /// Computes the 64-bit length of a required allocation.
            /// </summary>
            /// <param name="extent">The extent to allocate.</param>
            /// <returns>The 64-bit length of a required allocation.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public long ComputeBufferLength(LongIndex3D extent) =>
                Stride3D.ComputeBufferLength(this, extent);

            /// <summary>
            /// Returns this stride as general 3D stride.
            /// </summary>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public General AsGeneral() => this;

            /// <summary>
            /// Converts this stride instance into a general 1D stride.
            /// </summary>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Stride1D.General To1DStride() =>
                new Stride1D.General(XStride);

            #endregion

            #region Object

            /// <summary>
            /// Returns the string representation of this stride.
            /// </summary>
            /// <returns>The string representation of this stride.</returns>
            [NotInsideKernel]
            public override string ToString() => StrideExtent.ToString();

            #endregion
        }

        /// <summary>
        /// Computes the linear 32-bit element address using the given index.
        /// </summary>
        /// <param name="stride">The stride to use.</param>
        /// <param name="index">The dimension for index computation.</param>
        /// <returns>The computed linear element address.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ComputeElementIndex<TStride>(
            this TStride stride,
            Index3D index)
            where TStride : struct, IStride3D =>
            index.X * stride.XStride +
            index.Y * stride.YStride +
            index.Z * stride.ZStride;

        /// <summary>
        /// Computes the linear 64-bit element address using the given index.
        /// </summary>
        /// <param name="stride">The stride to use.</param>
        /// <param name="index">The dimension for index computation.</param>
        /// <returns>The computed linear element address.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ComputeElementIndex<TStride>(
            this TStride stride,
            LongIndex3D index)
            where TStride : struct, IStride3D =>
            index.X * stride.XStride +
            index.Y * stride.YStride +
            index.Z * stride.ZStride;

        /// <summary>
        /// Computes the linear 32-bit element address using the given index while
        /// verifying that the given index is within the bounds of the specified extent.
        /// </summary>
        /// <param name="stride">The stride to use.</param>
        /// <param name="index">The dimension for the index computation.</param>
        /// <param name="extent">The extent dimension to check.</param>
        /// <returns>The computed linear element address.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ComputeElementIndexChecked<TStride>(
            this TStride stride,
            Index3D index,
            Index3D extent)
            where TStride : struct, IStride3D
        {
            Trace.Assert(
                Bitwise.Or(
                    // Default bound checks
                    Bitwise.And(
                        index.X >= 0,
                        index.X < extent.X),
                    // Zero length views
                    Bitwise.And(index.X == 0, extent.X == 0)),
                "X index out of bounds");
            Trace.Assert(
                Bitwise.Or(
                    // Default bound checks
                    Bitwise.And(
                        index.Y >= 0,
                        index.Y < extent.Y),
                    // Zero length views
                    Bitwise.And(index.Y == 0, extent.Y == 0)),
                "Y index out of bounds");
            Trace.Assert(
                Bitwise.Or(
                    // Default bound checks
                    Bitwise.And(
                        index.Z >= 0,
                        index.Z < extent.Z),
                    // Zero length views
                    Bitwise.And(index.Z == 0, extent.Z == 0)),
                "Z index out of bounds");
            return ComputeElementIndex(stride, index);
        }

        /// <summary>
        /// Computes the linear 64-bit element address using the given index while
        /// verifying that the given index is within the bounds of the specified extent.
        /// </summary>
        /// <param name="stride">The stride to use.</param>
        /// <param name="index">The dimension for index computation.</param>
        /// <param name="extent">The extent dimension to check.</param>
        /// <returns>The computed linear element address.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ComputeElementIndexChecked<TStride>(
            this TStride stride,
            LongIndex3D index,
            LongIndex3D extent)
            where TStride : struct, IStride3D
        {
            Trace.Assert(
                Bitwise.And(
                    index.X >= 0,
                    index.X < extent.X),
                "X index out of bounds");
            Trace.Assert(
                Bitwise.And(
                    index.Y >= 0,
                    index.Y < extent.Y),
                "Y index out of bounds");
            Trace.Assert(
                Bitwise.And(
                    index.Z >= 0,
                    index.Z < extent.Z),
                "Z index out of bounds");
            return ComputeElementIndex(stride, index);
        }

        /// <summary>
        /// Computes the 32-bit length of a required allocation.
        /// </summary>
        /// <param name="stride">The stride to use.</param>
        /// <param name="extent">The extent to allocate.</param>
        /// <returns>The 32-bit length of a required allocation.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ComputeBufferLength<TStride>(
            this TStride stride,
            Index3D extent)
            where TStride : struct, IStride3D
        {
            if (extent.X == 0)
                return 0;
            if (extent.Y == 0)
                return 0;
            if (extent.Z == 0)
                return 0;
            return ComputeElementIndex(stride, extent - Index3D.One) + 1;
        }

        /// <summary>
        /// Computes the 64-bit length of a required allocation.
        /// </summary>
        /// <param name="stride">The stride to use.</param>
        /// <param name="extent">The extent to allocate.</param>
        /// <returns>The 64-bit length of a required allocation.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ComputeBufferLength<TStride>(
            this TStride stride,
            LongIndex3D extent)
            where TStride : struct, IStride3D
        {
            if (extent.X == 0L)
                return 0L;
            if (extent.Y == 0L)
                return 0L;
            if (extent.Z == 0L)
                return 0L;
            return ComputeElementIndex(stride, extent - LongIndex3D.One) + 1L;
        }

    }

}