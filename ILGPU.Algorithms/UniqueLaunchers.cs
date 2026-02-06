// ---------------------------------------------------------------------------------------
//                                   ILGPU Algorithms
//                        Copyright (c) 2020-2023 ILGPU Project
//                                    www.ilgpu.net
//
// File: UniqueLaunchers.tt/UniqueLaunchers.cs
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

using ILGPU.Algorithms.ComparisonOperations;
using ILGPU.Runtime;
using System;

namespace ILGPU.Algorithms
{
    /// <summary>
    /// Contains extension methods for unique operations.
    /// </summary>
    partial class UniqueExtensions
    {
        /// <summary>
        /// Removes consecutive duplicate elements in a supplied input view.
        /// </summary>
        /// <param name="accelerator">The accelerator.</param>
        /// <param name="stream">The accelerator stream.</param>
        /// <param name="input">The input view.</param>
        /// <returns>The new/valid length of the input view.</returns>
        public static long Unique(
            this Accelerator accelerator,
            AcceleratorStream stream,
            ArrayView<sbyte> input) =>
            accelerator.Unique<
                sbyte,
                ComparisonInt8>(
                    stream,
                    input);

        /// <summary>
        /// Removes consecutive duplicate elements in a supplied input view.
        /// </summary>
        /// <param name="accelerator">The accelerator.</param>
        /// <param name="stream">The accelerator stream.</param>
        /// <param name="input">The input view.</param>
        /// <returns>The new/valid length of the input view.</returns>
        public static long Unique(
            this Accelerator accelerator,
            AcceleratorStream stream,
            ArrayView<short> input) =>
            accelerator.Unique<
                short,
                ComparisonInt16>(
                    stream,
                    input);

        /// <summary>
        /// Removes consecutive duplicate elements in a supplied input view.
        /// </summary>
        /// <param name="accelerator">The accelerator.</param>
        /// <param name="stream">The accelerator stream.</param>
        /// <param name="input">The input view.</param>
        /// <returns>The new/valid length of the input view.</returns>
        public static long Unique(
            this Accelerator accelerator,
            AcceleratorStream stream,
            ArrayView<int> input) =>
            accelerator.Unique<
                int,
                ComparisonInt32>(
                    stream,
                    input);

        /// <summary>
        /// Removes consecutive duplicate elements in a supplied input view.
        /// </summary>
        /// <param name="accelerator">The accelerator.</param>
        /// <param name="stream">The accelerator stream.</param>
        /// <param name="input">The input view.</param>
        /// <returns>The new/valid length of the input view.</returns>
        public static long Unique(
            this Accelerator accelerator,
            AcceleratorStream stream,
            ArrayView<long> input) =>
            accelerator.Unique<
                long,
                ComparisonInt64>(
                    stream,
                    input);

        /// <summary>
        /// Removes consecutive duplicate elements in a supplied input view.
        /// </summary>
        /// <param name="accelerator">The accelerator.</param>
        /// <param name="stream">The accelerator stream.</param>
        /// <param name="input">The input view.</param>
        /// <returns>The new/valid length of the input view.</returns>
        public static long Unique(
            this Accelerator accelerator,
            AcceleratorStream stream,
            ArrayView<byte> input) =>
            accelerator.Unique<
                byte,
                ComparisonUInt8>(
                    stream,
                    input);

        /// <summary>
        /// Removes consecutive duplicate elements in a supplied input view.
        /// </summary>
        /// <param name="accelerator">The accelerator.</param>
        /// <param name="stream">The accelerator stream.</param>
        /// <param name="input">The input view.</param>
        /// <returns>The new/valid length of the input view.</returns>
        public static long Unique(
            this Accelerator accelerator,
            AcceleratorStream stream,
            ArrayView<ushort> input) =>
            accelerator.Unique<
                ushort,
                ComparisonUInt16>(
                    stream,
                    input);

        /// <summary>
        /// Removes consecutive duplicate elements in a supplied input view.
        /// </summary>
        /// <param name="accelerator">The accelerator.</param>
        /// <param name="stream">The accelerator stream.</param>
        /// <param name="input">The input view.</param>
        /// <returns>The new/valid length of the input view.</returns>
        public static long Unique(
            this Accelerator accelerator,
            AcceleratorStream stream,
            ArrayView<uint> input) =>
            accelerator.Unique<
                uint,
                ComparisonUInt32>(
                    stream,
                    input);

        /// <summary>
        /// Removes consecutive duplicate elements in a supplied input view.
        /// </summary>
        /// <param name="accelerator">The accelerator.</param>
        /// <param name="stream">The accelerator stream.</param>
        /// <param name="input">The input view.</param>
        /// <returns>The new/valid length of the input view.</returns>
        public static long Unique(
            this Accelerator accelerator,
            AcceleratorStream stream,
            ArrayView<ulong> input) =>
            accelerator.Unique<
                ulong,
                ComparisonUInt64>(
                    stream,
                    input);

        /// <summary>
        /// Removes consecutive duplicate elements in a supplied input view.
        /// </summary>
        /// <param name="accelerator">The accelerator.</param>
        /// <param name="stream">The accelerator stream.</param>
        /// <param name="input">The input view.</param>
        /// <returns>The new/valid length of the input view.</returns>
        public static long Unique(
            this Accelerator accelerator,
            AcceleratorStream stream,
            ArrayView<Half> input) =>
            accelerator.Unique<
                Half,
                ComparisonHalf>(
                    stream,
                    input);

        /// <summary>
        /// Removes consecutive duplicate elements in a supplied input view.
        /// </summary>
        /// <param name="accelerator">The accelerator.</param>
        /// <param name="stream">The accelerator stream.</param>
        /// <param name="input">The input view.</param>
        /// <returns>The new/valid length of the input view.</returns>
        public static long Unique(
            this Accelerator accelerator,
            AcceleratorStream stream,
            ArrayView<float> input) =>
            accelerator.Unique<
                float,
                ComparisonFloat>(
                    stream,
                    input);

        /// <summary>
        /// Removes consecutive duplicate elements in a supplied input view.
        /// </summary>
        /// <param name="accelerator">The accelerator.</param>
        /// <param name="stream">The accelerator stream.</param>
        /// <param name="input">The input view.</param>
        /// <returns>The new/valid length of the input view.</returns>
        public static long Unique(
            this Accelerator accelerator,
            AcceleratorStream stream,
            ArrayView<double> input) =>
            accelerator.Unique<
                double,
                ComparisonDouble>(
                    stream,
                    input);

    }
}