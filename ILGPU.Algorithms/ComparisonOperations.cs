// ---------------------------------------------------------------------------------------
//                                   ILGPU Algorithms
//                        Copyright (c) 2020-2023 ILGPU Project
//                                    www.ilgpu.net
//
// File: ComparisonOperations.tt/ComparisonOperations.cs
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

using System;

namespace ILGPU.Algorithms.ComparisonOperations
{
    /// <summary>
    /// Represents an comparison between two elements of type sbyte.
    /// </summary>
    public readonly struct ComparisonInt8
        : IComparisonOperation<sbyte>
    {
        /// <summary>
        /// Compares two elements.
        /// </summary>
        /// <param name="first">The first operand.</param>
        /// <param name="second">The second operand.</param>
        /// <returns>
        /// Less than zero, if first is less than second.
        /// Zero, if first is equal to second.
        /// Greater than zero, if first is greater than second.
        /// </returns>
        public int Compare(sbyte first, sbyte second) =>
            first.CompareTo(second);
    }

    /// <summary>
    /// Represents an comparison between two elements of type short.
    /// </summary>
    public readonly struct ComparisonInt16
        : IComparisonOperation<short>
    {
        /// <summary>
        /// Compares two elements.
        /// </summary>
        /// <param name="first">The first operand.</param>
        /// <param name="second">The second operand.</param>
        /// <returns>
        /// Less than zero, if first is less than second.
        /// Zero, if first is equal to second.
        /// Greater than zero, if first is greater than second.
        /// </returns>
        public int Compare(short first, short second) =>
            first.CompareTo(second);
    }

    /// <summary>
    /// Represents an comparison between two elements of type int.
    /// </summary>
    public readonly struct ComparisonInt32
        : IComparisonOperation<int>
    {
        /// <summary>
        /// Compares two elements.
        /// </summary>
        /// <param name="first">The first operand.</param>
        /// <param name="second">The second operand.</param>
        /// <returns>
        /// Less than zero, if first is less than second.
        /// Zero, if first is equal to second.
        /// Greater than zero, if first is greater than second.
        /// </returns>
        public int Compare(int first, int second) =>
            first.CompareTo(second);
    }

    /// <summary>
    /// Represents an comparison between two elements of type long.
    /// </summary>
    public readonly struct ComparisonInt64
        : IComparisonOperation<long>
    {
        /// <summary>
        /// Compares two elements.
        /// </summary>
        /// <param name="first">The first operand.</param>
        /// <param name="second">The second operand.</param>
        /// <returns>
        /// Less than zero, if first is less than second.
        /// Zero, if first is equal to second.
        /// Greater than zero, if first is greater than second.
        /// </returns>
        public int Compare(long first, long second) =>
            first.CompareTo(second);
    }

    /// <summary>
    /// Represents an comparison between two elements of type byte.
    /// </summary>
    public readonly struct ComparisonUInt8
        : IComparisonOperation<byte>
    {
        /// <summary>
        /// Compares two elements.
        /// </summary>
        /// <param name="first">The first operand.</param>
        /// <param name="second">The second operand.</param>
        /// <returns>
        /// Less than zero, if first is less than second.
        /// Zero, if first is equal to second.
        /// Greater than zero, if first is greater than second.
        /// </returns>
        public int Compare(byte first, byte second) =>
            first.CompareTo(second);
    }

    /// <summary>
    /// Represents an comparison between two elements of type ushort.
    /// </summary>
    public readonly struct ComparisonUInt16
        : IComparisonOperation<ushort>
    {
        /// <summary>
        /// Compares two elements.
        /// </summary>
        /// <param name="first">The first operand.</param>
        /// <param name="second">The second operand.</param>
        /// <returns>
        /// Less than zero, if first is less than second.
        /// Zero, if first is equal to second.
        /// Greater than zero, if first is greater than second.
        /// </returns>
        public int Compare(ushort first, ushort second) =>
            first.CompareTo(second);
    }

    /// <summary>
    /// Represents an comparison between two elements of type uint.
    /// </summary>
    public readonly struct ComparisonUInt32
        : IComparisonOperation<uint>
    {
        /// <summary>
        /// Compares two elements.
        /// </summary>
        /// <param name="first">The first operand.</param>
        /// <param name="second">The second operand.</param>
        /// <returns>
        /// Less than zero, if first is less than second.
        /// Zero, if first is equal to second.
        /// Greater than zero, if first is greater than second.
        /// </returns>
        public int Compare(uint first, uint second) =>
            first.CompareTo(second);
    }

    /// <summary>
    /// Represents an comparison between two elements of type ulong.
    /// </summary>
    public readonly struct ComparisonUInt64
        : IComparisonOperation<ulong>
    {
        /// <summary>
        /// Compares two elements.
        /// </summary>
        /// <param name="first">The first operand.</param>
        /// <param name="second">The second operand.</param>
        /// <returns>
        /// Less than zero, if first is less than second.
        /// Zero, if first is equal to second.
        /// Greater than zero, if first is greater than second.
        /// </returns>
        public int Compare(ulong first, ulong second) =>
            first.CompareTo(second);
    }

    /// <summary>
    /// Represents an comparison between two elements of type Half.
    /// </summary>
    public readonly struct ComparisonHalf
        : IComparisonOperation<Half>
    {
        /// <summary>
        /// Compares two elements.
        /// </summary>
        /// <param name="first">The first operand.</param>
        /// <param name="second">The second operand.</param>
        /// <returns>
        /// Less than zero, if first is less than second.
        /// Zero, if first is equal to second.
        /// Greater than zero, if first is greater than second.
        /// </returns>
        public int Compare(Half first, Half second) =>
            first.CompareTo(second);
    }

    /// <summary>
    /// Represents an comparison between two elements of type float.
    /// </summary>
    public readonly struct ComparisonFloat
        : IComparisonOperation<float>
    {
        /// <summary>
        /// Compares two elements.
        /// </summary>
        /// <param name="first">The first operand.</param>
        /// <param name="second">The second operand.</param>
        /// <returns>
        /// Less than zero, if first is less than second.
        /// Zero, if first is equal to second.
        /// Greater than zero, if first is greater than second.
        /// </returns>
        public int Compare(float first, float second) =>
            first.CompareTo(second);
    }

    /// <summary>
    /// Represents an comparison between two elements of type double.
    /// </summary>
    public readonly struct ComparisonDouble
        : IComparisonOperation<double>
    {
        /// <summary>
        /// Compares two elements.
        /// </summary>
        /// <param name="first">The first operand.</param>
        /// <param name="second">The second operand.</param>
        /// <returns>
        /// Less than zero, if first is less than second.
        /// Zero, if first is equal to second.
        /// Greater than zero, if first is greater than second.
        /// </returns>
        public int Compare(double first, double second) =>
            first.CompareTo(second);
    }

}