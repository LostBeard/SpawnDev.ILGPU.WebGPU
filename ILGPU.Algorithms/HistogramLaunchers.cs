// ---------------------------------------------------------------------------------------
//                                   ILGPU Algorithms
//                        Copyright (c) 2020-2023 ILGPU Project
//                                    www.ilgpu.net
//
// File: HistogramLaunchers.tt/HistogramLaunchers.cs
//
// This file is part of ILGPU and is distributed under the University of Illinois Open
// Source License. See LICENSE.txt for details.
// ---------------------------------------------------------------------------------------

// ---------------------------------------------------------------------------------------
//                                   ILGPU Algorithms
//                        Copyright (c) 2020-2021 ILGPU Project
//                                    www.ilgpu.net
//
// File: TypeInformation.ttinclude
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

using ILGPU.Algorithms.HistogramOperations;
using ILGPU.Runtime;

namespace ILGPU.Algorithms
{
    /// <summary>
    /// Contains extension methods for histogram operations.
    /// </summary>
    partial class HistogramExtensions
    {
        #region Histogram Int32 Launchers

        /// <summary>
        /// Calculates the histogram (int) on the given 1D view.
        /// </summary>
        /// <typeparam name="T">The input view element type.</typeparam>
        /// <typeparam name="TStride">The input view element type.</typeparam>
        /// <typeparam name="TLocator">
        /// The operation to compute the bin location.
        /// </typeparam>
        /// <param name="accelerator">The accelerator.</param>
        /// <param name="stream">The accelerator stream.</param>
        /// <param name="view">The input view.</param>
        /// <param name="histogram">The histogram view to update.</param>
        /// <param name="histogramOverflow">
        /// Single-element view that indicates whether the histogram has overflowed.
        /// </param>
        public static void Histogram<T, TStride, TLocator>(
            this Accelerator accelerator,
            AcceleratorStream stream,
            ArrayView1D<T, TStride> view,
            ArrayView<int> histogram,
            ArrayView<int> histogramOverflow)
            where T : unmanaged
            where TStride : struct, IStride1D
            where TLocator : struct, IComputeSingleBinOperation<T, Index1D>
        {
            var kernel = accelerator.CreateHistogram<
                T,
                TStride,
                int,
                HistogramIncrementInt32,
                ComputeSingleBinAdapterInt32<T, TLocator>>();
            kernel(stream, view, histogram, histogramOverflow);
        }

        /// <summary>
        /// Adapter to convert single-bin operation into a multi-bin operation for
        /// histograms of type int.
        /// </summary>
        /// <typeparam name="T">
        /// The underlying type of the histogram operation.
        /// </typeparam>
        /// <typeparam name="TLocator">
        /// The operation to compute the bin location.
        /// </typeparam>
        internal readonly struct ComputeSingleBinAdapterInt32<T, TLocator>
            : IComputeMultiBinOperation<
                T,
                int,
                HistogramIncrementInt32>
            where T : unmanaged
            where TLocator : struct, IComputeSingleBinOperation<T, Index1D>
        {
            public void ComputeHistogramBins(
                T value,
                ArrayView<int> histogram,
                in HistogramIncrementInt32 incrementOperation,
                out bool incrementOverflow)
            {
                TLocator locator = default;
                var binIdx = locator.ComputeHistogramBin(value, histogram.IntLength);
                incrementOperation.Increment(
                    ref histogram[binIdx],
                    out incrementOverflow);
            }
        }

        #endregion

        #region Histogram Int64 Launchers

        /// <summary>
        /// Calculates the histogram (long) on the given 1D view.
        /// </summary>
        /// <typeparam name="T">The input view element type.</typeparam>
        /// <typeparam name="TStride">The input view element type.</typeparam>
        /// <typeparam name="TLocator">
        /// The operation to compute the bin location.
        /// </typeparam>
        /// <param name="accelerator">The accelerator.</param>
        /// <param name="stream">The accelerator stream.</param>
        /// <param name="view">The input view.</param>
        /// <param name="histogram">The histogram view to update.</param>
        /// <param name="histogramOverflow">
        /// Single-element view that indicates whether the histogram has overflowed.
        /// </param>
        public static void Histogram<T, TStride, TLocator>(
            this Accelerator accelerator,
            AcceleratorStream stream,
            ArrayView1D<T, TStride> view,
            ArrayView<long> histogram,
            ArrayView<int> histogramOverflow)
            where T : unmanaged
            where TStride : struct, IStride1D
            where TLocator : struct, IComputeSingleBinOperation<T, Index1D>
        {
            var kernel = accelerator.CreateHistogram<
                T,
                TStride,
                long,
                HistogramIncrementInt64,
                ComputeSingleBinAdapterInt64<T, TLocator>>();
            kernel(stream, view, histogram, histogramOverflow);
        }

        /// <summary>
        /// Adapter to convert single-bin operation into a multi-bin operation for
        /// histograms of type long.
        /// </summary>
        /// <typeparam name="T">
        /// The underlying type of the histogram operation.
        /// </typeparam>
        /// <typeparam name="TLocator">
        /// The operation to compute the bin location.
        /// </typeparam>
        internal readonly struct ComputeSingleBinAdapterInt64<T, TLocator>
            : IComputeMultiBinOperation<
                T,
                long,
                HistogramIncrementInt64>
            where T : unmanaged
            where TLocator : struct, IComputeSingleBinOperation<T, Index1D>
        {
            public void ComputeHistogramBins(
                T value,
                ArrayView<long> histogram,
                in HistogramIncrementInt64 incrementOperation,
                out bool incrementOverflow)
            {
                TLocator locator = default;
                var binIdx = locator.ComputeHistogramBin(value, histogram.IntLength);
                incrementOperation.Increment(
                    ref histogram[binIdx],
                    out incrementOverflow);
            }
        }

        #endregion

        #region Histogram UInt32 Launchers

        /// <summary>
        /// Calculates the histogram (uint) on the given 1D view.
        /// </summary>
        /// <typeparam name="T">The input view element type.</typeparam>
        /// <typeparam name="TStride">The input view element type.</typeparam>
        /// <typeparam name="TLocator">
        /// The operation to compute the bin location.
        /// </typeparam>
        /// <param name="accelerator">The accelerator.</param>
        /// <param name="stream">The accelerator stream.</param>
        /// <param name="view">The input view.</param>
        /// <param name="histogram">The histogram view to update.</param>
        /// <param name="histogramOverflow">
        /// Single-element view that indicates whether the histogram has overflowed.
        /// </param>
        public static void Histogram<T, TStride, TLocator>(
            this Accelerator accelerator,
            AcceleratorStream stream,
            ArrayView1D<T, TStride> view,
            ArrayView<uint> histogram,
            ArrayView<int> histogramOverflow)
            where T : unmanaged
            where TStride : struct, IStride1D
            where TLocator : struct, IComputeSingleBinOperation<T, Index1D>
        {
            var kernel = accelerator.CreateHistogram<
                T,
                TStride,
                uint,
                HistogramIncrementUInt32,
                ComputeSingleBinAdapterUInt32<T, TLocator>>();
            kernel(stream, view, histogram, histogramOverflow);
        }

        /// <summary>
        /// Adapter to convert single-bin operation into a multi-bin operation for
        /// histograms of type uint.
        /// </summary>
        /// <typeparam name="T">
        /// The underlying type of the histogram operation.
        /// </typeparam>
        /// <typeparam name="TLocator">
        /// The operation to compute the bin location.
        /// </typeparam>
        internal readonly struct ComputeSingleBinAdapterUInt32<T, TLocator>
            : IComputeMultiBinOperation<
                T,
                uint,
                HistogramIncrementUInt32>
            where T : unmanaged
            where TLocator : struct, IComputeSingleBinOperation<T, Index1D>
        {
            public void ComputeHistogramBins(
                T value,
                ArrayView<uint> histogram,
                in HistogramIncrementUInt32 incrementOperation,
                out bool incrementOverflow)
            {
                TLocator locator = default;
                var binIdx = locator.ComputeHistogramBin(value, histogram.IntLength);
                incrementOperation.Increment(
                    ref histogram[binIdx],
                    out incrementOverflow);
            }
        }

        #endregion

        #region Histogram UInt64 Launchers

        /// <summary>
        /// Calculates the histogram (ulong) on the given 1D view.
        /// </summary>
        /// <typeparam name="T">The input view element type.</typeparam>
        /// <typeparam name="TStride">The input view element type.</typeparam>
        /// <typeparam name="TLocator">
        /// The operation to compute the bin location.
        /// </typeparam>
        /// <param name="accelerator">The accelerator.</param>
        /// <param name="stream">The accelerator stream.</param>
        /// <param name="view">The input view.</param>
        /// <param name="histogram">The histogram view to update.</param>
        /// <param name="histogramOverflow">
        /// Single-element view that indicates whether the histogram has overflowed.
        /// </param>
        public static void Histogram<T, TStride, TLocator>(
            this Accelerator accelerator,
            AcceleratorStream stream,
            ArrayView1D<T, TStride> view,
            ArrayView<ulong> histogram,
            ArrayView<int> histogramOverflow)
            where T : unmanaged
            where TStride : struct, IStride1D
            where TLocator : struct, IComputeSingleBinOperation<T, Index1D>
        {
            var kernel = accelerator.CreateHistogram<
                T,
                TStride,
                ulong,
                HistogramIncrementUInt64,
                ComputeSingleBinAdapterUInt64<T, TLocator>>();
            kernel(stream, view, histogram, histogramOverflow);
        }

        /// <summary>
        /// Adapter to convert single-bin operation into a multi-bin operation for
        /// histograms of type ulong.
        /// </summary>
        /// <typeparam name="T">
        /// The underlying type of the histogram operation.
        /// </typeparam>
        /// <typeparam name="TLocator">
        /// The operation to compute the bin location.
        /// </typeparam>
        internal readonly struct ComputeSingleBinAdapterUInt64<T, TLocator>
            : IComputeMultiBinOperation<
                T,
                ulong,
                HistogramIncrementUInt64>
            where T : unmanaged
            where TLocator : struct, IComputeSingleBinOperation<T, Index1D>
        {
            public void ComputeHistogramBins(
                T value,
                ArrayView<ulong> histogram,
                in HistogramIncrementUInt64 incrementOperation,
                out bool incrementOverflow)
            {
                TLocator locator = default;
                var binIdx = locator.ComputeHistogramBin(value, histogram.IntLength);
                incrementOperation.Increment(
                    ref histogram[binIdx],
                    out incrementOverflow);
            }
        }

        #endregion

        #region Histogram Float Launchers

        /// <summary>
        /// Calculates the histogram (float) on the given 1D view.
        /// </summary>
        /// <typeparam name="T">The input view element type.</typeparam>
        /// <typeparam name="TStride">The input view element type.</typeparam>
        /// <typeparam name="TLocator">
        /// The operation to compute the bin location.
        /// </typeparam>
        /// <param name="accelerator">The accelerator.</param>
        /// <param name="stream">The accelerator stream.</param>
        /// <param name="view">The input view.</param>
        /// <param name="histogram">The histogram view to update.</param>
        /// <param name="histogramOverflow">
        /// Single-element view that indicates whether the histogram has overflowed.
        /// </param>
        public static void Histogram<T, TStride, TLocator>(
            this Accelerator accelerator,
            AcceleratorStream stream,
            ArrayView1D<T, TStride> view,
            ArrayView<float> histogram,
            ArrayView<int> histogramOverflow)
            where T : unmanaged
            where TStride : struct, IStride1D
            where TLocator : struct, IComputeSingleBinOperation<T, Index1D>
        {
            var kernel = accelerator.CreateHistogram<
                T,
                TStride,
                float,
                HistogramIncrementFloat,
                ComputeSingleBinAdapterFloat<T, TLocator>>();
            kernel(stream, view, histogram, histogramOverflow);
        }

        /// <summary>
        /// Adapter to convert single-bin operation into a multi-bin operation for
        /// histograms of type float.
        /// </summary>
        /// <typeparam name="T">
        /// The underlying type of the histogram operation.
        /// </typeparam>
        /// <typeparam name="TLocator">
        /// The operation to compute the bin location.
        /// </typeparam>
        internal readonly struct ComputeSingleBinAdapterFloat<T, TLocator>
            : IComputeMultiBinOperation<
                T,
                float,
                HistogramIncrementFloat>
            where T : unmanaged
            where TLocator : struct, IComputeSingleBinOperation<T, Index1D>
        {
            public void ComputeHistogramBins(
                T value,
                ArrayView<float> histogram,
                in HistogramIncrementFloat incrementOperation,
                out bool incrementOverflow)
            {
                TLocator locator = default;
                var binIdx = locator.ComputeHistogramBin(value, histogram.IntLength);
                incrementOperation.Increment(
                    ref histogram[binIdx],
                    out incrementOverflow);
            }
        }

        #endregion

        #region Histogram Double Launchers

        /// <summary>
        /// Calculates the histogram (double) on the given 1D view.
        /// </summary>
        /// <typeparam name="T">The input view element type.</typeparam>
        /// <typeparam name="TStride">The input view element type.</typeparam>
        /// <typeparam name="TLocator">
        /// The operation to compute the bin location.
        /// </typeparam>
        /// <param name="accelerator">The accelerator.</param>
        /// <param name="stream">The accelerator stream.</param>
        /// <param name="view">The input view.</param>
        /// <param name="histogram">The histogram view to update.</param>
        /// <param name="histogramOverflow">
        /// Single-element view that indicates whether the histogram has overflowed.
        /// </param>
        public static void Histogram<T, TStride, TLocator>(
            this Accelerator accelerator,
            AcceleratorStream stream,
            ArrayView1D<T, TStride> view,
            ArrayView<double> histogram,
            ArrayView<int> histogramOverflow)
            where T : unmanaged
            where TStride : struct, IStride1D
            where TLocator : struct, IComputeSingleBinOperation<T, Index1D>
        {
            var kernel = accelerator.CreateHistogram<
                T,
                TStride,
                double,
                HistogramIncrementDouble,
                ComputeSingleBinAdapterDouble<T, TLocator>>();
            kernel(stream, view, histogram, histogramOverflow);
        }

        /// <summary>
        /// Adapter to convert single-bin operation into a multi-bin operation for
        /// histograms of type double.
        /// </summary>
        /// <typeparam name="T">
        /// The underlying type of the histogram operation.
        /// </typeparam>
        /// <typeparam name="TLocator">
        /// The operation to compute the bin location.
        /// </typeparam>
        internal readonly struct ComputeSingleBinAdapterDouble<T, TLocator>
            : IComputeMultiBinOperation<
                T,
                double,
                HistogramIncrementDouble>
            where T : unmanaged
            where TLocator : struct, IComputeSingleBinOperation<T, Index1D>
        {
            public void ComputeHistogramBins(
                T value,
                ArrayView<double> histogram,
                in HistogramIncrementDouble incrementOperation,
                out bool incrementOverflow)
            {
                TLocator locator = default;
                var binIdx = locator.ComputeHistogramBin(value, histogram.IntLength);
                incrementOperation.Increment(
                    ref histogram[binIdx],
                    out incrementOverflow);
            }
        }

        #endregion

    }
}