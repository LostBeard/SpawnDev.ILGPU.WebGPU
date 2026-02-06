// ---------------------------------------------------------------------------------------
//                                   ILGPU Algorithms
//                        Copyright (c) 2019-2023 ILGPU Project
//                                    www.ilgpu.net
//
// File: ScanReduceOperations.tt/ScanReduceOperations.cs
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

// disable: max_line_length
#pragma warning disable IDE0004 // Cast is redundant

namespace ILGPU.Algorithms.ScanReduceOperations
{
    /// <summary>
    /// Represents an Add reduction of type int.
    /// </summary>
    public readonly struct AddInt32 : IScanReduceOperation<int>
    {
        /// <summary>
        /// Returns the associated OpenCL command suffix for the internal code generator
        /// to build the final OpenCL command to use.
        /// </summary>
        public string CLCommand => "add";

        /// <summary>
        /// Returns the identity value (the neutral element of the operation), such that
        /// Apply(Apply(Identity, left), right) == Apply(left, right).
        /// </summary>
        public int Identity => 0;

        /// <summary>
        /// Applies the current operation.
        /// </summary>
        /// <param name="first">The first operand.</param>
        /// <param name="second">The second operand.</param>
        /// <returns>The result of the operation.</returns>
        public int Apply(int first, int second) =>
            (int)(first + second);

        /// <summary>
        /// Performs an atomic operation of the form target = AtomicUpdate(target.Value, value).
        /// </summary>
        /// <param name="target">The target address to update.</param>
        /// <param name="value">The value.</param>
        public void AtomicApply(ref int target, int value) =>
            Atomic.Add(ref target, value);
    }

    /// <summary>
    /// Represents an Max reduction of type int.
    /// </summary>
    public readonly struct MaxInt32 : IScanReduceOperation<int>
    {
        /// <summary>
        /// Returns the associated OpenCL command suffix for the internal code generator
        /// to build the final OpenCL command to use.
        /// </summary>
        public string CLCommand => "max";

        /// <summary>
        /// Returns the identity value (the neutral element of the operation), such that
        /// Apply(Apply(Identity, left), right) == Apply(left, right).
        /// </summary>
        public int Identity => int.MinValue;

        /// <summary>
        /// Applies the current operation.
        /// </summary>
        /// <param name="first">The first operand.</param>
        /// <param name="second">The second operand.</param>
        /// <returns>The result of the operation.</returns>
        public int Apply(int first, int second) =>
            (int)(XMath.Max(first, second));

        /// <summary>
        /// Performs an atomic operation of the form target = AtomicUpdate(target.Value, value).
        /// </summary>
        /// <param name="target">The target address to update.</param>
        /// <param name="value">The value.</param>
        public void AtomicApply(ref int target, int value) =>
            Atomic.Max(ref target, value);
    }

    /// <summary>
    /// Represents an Min reduction of type int.
    /// </summary>
    public readonly struct MinInt32 : IScanReduceOperation<int>
    {
        /// <summary>
        /// Returns the associated OpenCL command suffix for the internal code generator
        /// to build the final OpenCL command to use.
        /// </summary>
        public string CLCommand => "min";

        /// <summary>
        /// Returns the identity value (the neutral element of the operation), such that
        /// Apply(Apply(Identity, left), right) == Apply(left, right).
        /// </summary>
        public int Identity => int.MaxValue;

        /// <summary>
        /// Applies the current operation.
        /// </summary>
        /// <param name="first">The first operand.</param>
        /// <param name="second">The second operand.</param>
        /// <returns>The result of the operation.</returns>
        public int Apply(int first, int second) =>
            (int)(XMath.Min(first, second));

        /// <summary>
        /// Performs an atomic operation of the form target = AtomicUpdate(target.Value, value).
        /// </summary>
        /// <param name="target">The target address to update.</param>
        /// <param name="value">The value.</param>
        public void AtomicApply(ref int target, int value) =>
            Atomic.Min(ref target, value);
    }

    /// <summary>
    /// Represents an Add reduction of type long.
    /// </summary>
    public readonly struct AddInt64 : IScanReduceOperation<long>
    {
        /// <summary>
        /// Returns the associated OpenCL command suffix for the internal code generator
        /// to build the final OpenCL command to use.
        /// </summary>
        public string CLCommand => "add";

        /// <summary>
        /// Returns the identity value (the neutral element of the operation), such that
        /// Apply(Apply(Identity, left), right) == Apply(left, right).
        /// </summary>
        public long Identity => 0;

        /// <summary>
        /// Applies the current operation.
        /// </summary>
        /// <param name="first">The first operand.</param>
        /// <param name="second">The second operand.</param>
        /// <returns>The result of the operation.</returns>
        public long Apply(long first, long second) =>
            (long)(first + second);

        /// <summary>
        /// Performs an atomic operation of the form target = AtomicUpdate(target.Value, value).
        /// </summary>
        /// <param name="target">The target address to update.</param>
        /// <param name="value">The value.</param>
        public void AtomicApply(ref long target, long value) =>
            Atomic.Add(ref target, value);
    }

    /// <summary>
    /// Represents an Max reduction of type long.
    /// </summary>
    public readonly struct MaxInt64 : IScanReduceOperation<long>
    {
        /// <summary>
        /// Returns the associated OpenCL command suffix for the internal code generator
        /// to build the final OpenCL command to use.
        /// </summary>
        public string CLCommand => "max";

        /// <summary>
        /// Returns the identity value (the neutral element of the operation), such that
        /// Apply(Apply(Identity, left), right) == Apply(left, right).
        /// </summary>
        public long Identity => long.MinValue;

        /// <summary>
        /// Applies the current operation.
        /// </summary>
        /// <param name="first">The first operand.</param>
        /// <param name="second">The second operand.</param>
        /// <returns>The result of the operation.</returns>
        public long Apply(long first, long second) =>
            (long)(XMath.Max(first, second));

        /// <summary>
        /// Performs an atomic operation of the form target = AtomicUpdate(target.Value, value).
        /// </summary>
        /// <param name="target">The target address to update.</param>
        /// <param name="value">The value.</param>
        public void AtomicApply(ref long target, long value) =>
            Atomic.Max(ref target, value);
    }

    /// <summary>
    /// Represents an Min reduction of type long.
    /// </summary>
    public readonly struct MinInt64 : IScanReduceOperation<long>
    {
        /// <summary>
        /// Returns the associated OpenCL command suffix for the internal code generator
        /// to build the final OpenCL command to use.
        /// </summary>
        public string CLCommand => "min";

        /// <summary>
        /// Returns the identity value (the neutral element of the operation), such that
        /// Apply(Apply(Identity, left), right) == Apply(left, right).
        /// </summary>
        public long Identity => long.MaxValue;

        /// <summary>
        /// Applies the current operation.
        /// </summary>
        /// <param name="first">The first operand.</param>
        /// <param name="second">The second operand.</param>
        /// <returns>The result of the operation.</returns>
        public long Apply(long first, long second) =>
            (long)(XMath.Min(first, second));

        /// <summary>
        /// Performs an atomic operation of the form target = AtomicUpdate(target.Value, value).
        /// </summary>
        /// <param name="target">The target address to update.</param>
        /// <param name="value">The value.</param>
        public void AtomicApply(ref long target, long value) =>
            Atomic.Min(ref target, value);
    }

    /// <summary>
    /// Represents an Add reduction of type uint.
    /// </summary>
    public readonly struct AddUInt32 : IScanReduceOperation<uint>
    {
        /// <summary>
        /// Returns the associated OpenCL command suffix for the internal code generator
        /// to build the final OpenCL command to use.
        /// </summary>
        public string CLCommand => "add";

        /// <summary>
        /// Returns the identity value (the neutral element of the operation), such that
        /// Apply(Apply(Identity, left), right) == Apply(left, right).
        /// </summary>
        public uint Identity => 0;

        /// <summary>
        /// Applies the current operation.
        /// </summary>
        /// <param name="first">The first operand.</param>
        /// <param name="second">The second operand.</param>
        /// <returns>The result of the operation.</returns>
        public uint Apply(uint first, uint second) =>
            (uint)(first + second);

        /// <summary>
        /// Performs an atomic operation of the form target = AtomicUpdate(target.Value, value).
        /// </summary>
        /// <param name="target">The target address to update.</param>
        /// <param name="value">The value.</param>
        public void AtomicApply(ref uint target, uint value) =>
            Atomic.Add(ref target, value);
    }

    /// <summary>
    /// Represents an Max reduction of type uint.
    /// </summary>
    public readonly struct MaxUInt32 : IScanReduceOperation<uint>
    {
        /// <summary>
        /// Returns the associated OpenCL command suffix for the internal code generator
        /// to build the final OpenCL command to use.
        /// </summary>
        public string CLCommand => "max";

        /// <summary>
        /// Returns the identity value (the neutral element of the operation), such that
        /// Apply(Apply(Identity, left), right) == Apply(left, right).
        /// </summary>
        public uint Identity => uint.MinValue;

        /// <summary>
        /// Applies the current operation.
        /// </summary>
        /// <param name="first">The first operand.</param>
        /// <param name="second">The second operand.</param>
        /// <returns>The result of the operation.</returns>
        public uint Apply(uint first, uint second) =>
            (uint)(XMath.Max(first, second));

        /// <summary>
        /// Performs an atomic operation of the form target = AtomicUpdate(target.Value, value).
        /// </summary>
        /// <param name="target">The target address to update.</param>
        /// <param name="value">The value.</param>
        public void AtomicApply(ref uint target, uint value) =>
            Atomic.Max(ref target, value);
    }

    /// <summary>
    /// Represents an Min reduction of type uint.
    /// </summary>
    public readonly struct MinUInt32 : IScanReduceOperation<uint>
    {
        /// <summary>
        /// Returns the associated OpenCL command suffix for the internal code generator
        /// to build the final OpenCL command to use.
        /// </summary>
        public string CLCommand => "min";

        /// <summary>
        /// Returns the identity value (the neutral element of the operation), such that
        /// Apply(Apply(Identity, left), right) == Apply(left, right).
        /// </summary>
        public uint Identity => uint.MaxValue;

        /// <summary>
        /// Applies the current operation.
        /// </summary>
        /// <param name="first">The first operand.</param>
        /// <param name="second">The second operand.</param>
        /// <returns>The result of the operation.</returns>
        public uint Apply(uint first, uint second) =>
            (uint)(XMath.Min(first, second));

        /// <summary>
        /// Performs an atomic operation of the form target = AtomicUpdate(target.Value, value).
        /// </summary>
        /// <param name="target">The target address to update.</param>
        /// <param name="value">The value.</param>
        public void AtomicApply(ref uint target, uint value) =>
            Atomic.Min(ref target, value);
    }

    /// <summary>
    /// Represents an Add reduction of type ulong.
    /// </summary>
    public readonly struct AddUInt64 : IScanReduceOperation<ulong>
    {
        /// <summary>
        /// Returns the associated OpenCL command suffix for the internal code generator
        /// to build the final OpenCL command to use.
        /// </summary>
        public string CLCommand => "add";

        /// <summary>
        /// Returns the identity value (the neutral element of the operation), such that
        /// Apply(Apply(Identity, left), right) == Apply(left, right).
        /// </summary>
        public ulong Identity => 0;

        /// <summary>
        /// Applies the current operation.
        /// </summary>
        /// <param name="first">The first operand.</param>
        /// <param name="second">The second operand.</param>
        /// <returns>The result of the operation.</returns>
        public ulong Apply(ulong first, ulong second) =>
            (ulong)(first + second);

        /// <summary>
        /// Performs an atomic operation of the form target = AtomicUpdate(target.Value, value).
        /// </summary>
        /// <param name="target">The target address to update.</param>
        /// <param name="value">The value.</param>
        public void AtomicApply(ref ulong target, ulong value) =>
            Atomic.Add(ref target, value);
    }

    /// <summary>
    /// Represents an Max reduction of type ulong.
    /// </summary>
    public readonly struct MaxUInt64 : IScanReduceOperation<ulong>
    {
        /// <summary>
        /// Returns the associated OpenCL command suffix for the internal code generator
        /// to build the final OpenCL command to use.
        /// </summary>
        public string CLCommand => "max";

        /// <summary>
        /// Returns the identity value (the neutral element of the operation), such that
        /// Apply(Apply(Identity, left), right) == Apply(left, right).
        /// </summary>
        public ulong Identity => ulong.MinValue;

        /// <summary>
        /// Applies the current operation.
        /// </summary>
        /// <param name="first">The first operand.</param>
        /// <param name="second">The second operand.</param>
        /// <returns>The result of the operation.</returns>
        public ulong Apply(ulong first, ulong second) =>
            (ulong)(XMath.Max(first, second));

        /// <summary>
        /// Performs an atomic operation of the form target = AtomicUpdate(target.Value, value).
        /// </summary>
        /// <param name="target">The target address to update.</param>
        /// <param name="value">The value.</param>
        public void AtomicApply(ref ulong target, ulong value) =>
            Atomic.Max(ref target, value);
    }

    /// <summary>
    /// Represents an Min reduction of type ulong.
    /// </summary>
    public readonly struct MinUInt64 : IScanReduceOperation<ulong>
    {
        /// <summary>
        /// Returns the associated OpenCL command suffix for the internal code generator
        /// to build the final OpenCL command to use.
        /// </summary>
        public string CLCommand => "min";

        /// <summary>
        /// Returns the identity value (the neutral element of the operation), such that
        /// Apply(Apply(Identity, left), right) == Apply(left, right).
        /// </summary>
        public ulong Identity => ulong.MaxValue;

        /// <summary>
        /// Applies the current operation.
        /// </summary>
        /// <param name="first">The first operand.</param>
        /// <param name="second">The second operand.</param>
        /// <returns>The result of the operation.</returns>
        public ulong Apply(ulong first, ulong second) =>
            (ulong)(XMath.Min(first, second));

        /// <summary>
        /// Performs an atomic operation of the form target = AtomicUpdate(target.Value, value).
        /// </summary>
        /// <param name="target">The target address to update.</param>
        /// <param name="value">The value.</param>
        public void AtomicApply(ref ulong target, ulong value) =>
            Atomic.Min(ref target, value);
    }

    /// <summary>
    /// Represents an Add reduction of type float.
    /// </summary>
    public readonly struct AddFloat : IScanReduceOperation<float>
    {
        /// <summary>
        /// Returns the associated OpenCL command suffix for the internal code generator
        /// to build the final OpenCL command to use.
        /// </summary>
        public string CLCommand => "add";

        /// <summary>
        /// Returns the identity value (the neutral element of the operation), such that
        /// Apply(Apply(Identity, left), right) == Apply(left, right).
        /// </summary>
        public float Identity => 0;

        /// <summary>
        /// Applies the current operation.
        /// </summary>
        /// <param name="first">The first operand.</param>
        /// <param name="second">The second operand.</param>
        /// <returns>The result of the operation.</returns>
        public float Apply(float first, float second) =>
            (float)(first + second);

        /// <summary>
        /// Performs an atomic operation of the form target = AtomicUpdate(target.Value, value).
        /// </summary>
        /// <param name="target">The target address to update.</param>
        /// <param name="value">The value.</param>
        public void AtomicApply(ref float target, float value) =>
            Atomic.Add(ref target, value);
    }

    /// <summary>
    /// Represents an Max reduction of type float.
    /// </summary>
    public readonly struct MaxFloat : IScanReduceOperation<float>
    {
        /// <summary>
        /// Returns the associated OpenCL command suffix for the internal code generator
        /// to build the final OpenCL command to use.
        /// </summary>
        public string CLCommand => "max";

        /// <summary>
        /// Returns the identity value (the neutral element of the operation), such that
        /// Apply(Apply(Identity, left), right) == Apply(left, right).
        /// </summary>
        public float Identity => float.MinValue;

        /// <summary>
        /// Applies the current operation.
        /// </summary>
        /// <param name="first">The first operand.</param>
        /// <param name="second">The second operand.</param>
        /// <returns>The result of the operation.</returns>
        public float Apply(float first, float second) =>
            (float)(XMath.Max(first, second));

        /// <summary>
        /// Performs an atomic operation of the form target = AtomicUpdate(target.Value, value).
        /// </summary>
        /// <param name="target">The target address to update.</param>
        /// <param name="value">The value.</param>
        public void AtomicApply(ref float target, float value) =>
            Atomic.Max(ref target, value);
    }

    /// <summary>
    /// Represents an Min reduction of type float.
    /// </summary>
    public readonly struct MinFloat : IScanReduceOperation<float>
    {
        /// <summary>
        /// Returns the associated OpenCL command suffix for the internal code generator
        /// to build the final OpenCL command to use.
        /// </summary>
        public string CLCommand => "min";

        /// <summary>
        /// Returns the identity value (the neutral element of the operation), such that
        /// Apply(Apply(Identity, left), right) == Apply(left, right).
        /// </summary>
        public float Identity => float.MaxValue;

        /// <summary>
        /// Applies the current operation.
        /// </summary>
        /// <param name="first">The first operand.</param>
        /// <param name="second">The second operand.</param>
        /// <returns>The result of the operation.</returns>
        public float Apply(float first, float second) =>
            (float)(XMath.Min(first, second));

        /// <summary>
        /// Performs an atomic operation of the form target = AtomicUpdate(target.Value, value).
        /// </summary>
        /// <param name="target">The target address to update.</param>
        /// <param name="value">The value.</param>
        public void AtomicApply(ref float target, float value) =>
            Atomic.Min(ref target, value);
    }

    /// <summary>
    /// Represents an Add reduction of type double.
    /// </summary>
    public readonly struct AddDouble : IScanReduceOperation<double>
    {
        /// <summary>
        /// Returns the associated OpenCL command suffix for the internal code generator
        /// to build the final OpenCL command to use.
        /// </summary>
        public string CLCommand => "add";

        /// <summary>
        /// Returns the identity value (the neutral element of the operation), such that
        /// Apply(Apply(Identity, left), right) == Apply(left, right).
        /// </summary>
        public double Identity => 0;

        /// <summary>
        /// Applies the current operation.
        /// </summary>
        /// <param name="first">The first operand.</param>
        /// <param name="second">The second operand.</param>
        /// <returns>The result of the operation.</returns>
        public double Apply(double first, double second) =>
            (double)(first + second);

        /// <summary>
        /// Performs an atomic operation of the form target = AtomicUpdate(target.Value, value).
        /// </summary>
        /// <param name="target">The target address to update.</param>
        /// <param name="value">The value.</param>
        public void AtomicApply(ref double target, double value) =>
            Atomic.Add(ref target, value);
    }

    /// <summary>
    /// Represents an Max reduction of type double.
    /// </summary>
    public readonly struct MaxDouble : IScanReduceOperation<double>
    {
        /// <summary>
        /// Returns the associated OpenCL command suffix for the internal code generator
        /// to build the final OpenCL command to use.
        /// </summary>
        public string CLCommand => "max";

        /// <summary>
        /// Returns the identity value (the neutral element of the operation), such that
        /// Apply(Apply(Identity, left), right) == Apply(left, right).
        /// </summary>
        public double Identity => double.MinValue;

        /// <summary>
        /// Applies the current operation.
        /// </summary>
        /// <param name="first">The first operand.</param>
        /// <param name="second">The second operand.</param>
        /// <returns>The result of the operation.</returns>
        public double Apply(double first, double second) =>
            (double)(XMath.Max(first, second));

        /// <summary>
        /// Performs an atomic operation of the form target = AtomicUpdate(target.Value, value).
        /// </summary>
        /// <param name="target">The target address to update.</param>
        /// <param name="value">The value.</param>
        public void AtomicApply(ref double target, double value) =>
            Atomic.Max(ref target, value);
    }

    /// <summary>
    /// Represents an Min reduction of type double.
    /// </summary>
    public readonly struct MinDouble : IScanReduceOperation<double>
    {
        /// <summary>
        /// Returns the associated OpenCL command suffix for the internal code generator
        /// to build the final OpenCL command to use.
        /// </summary>
        public string CLCommand => "min";

        /// <summary>
        /// Returns the identity value (the neutral element of the operation), such that
        /// Apply(Apply(Identity, left), right) == Apply(left, right).
        /// </summary>
        public double Identity => double.MaxValue;

        /// <summary>
        /// Applies the current operation.
        /// </summary>
        /// <param name="first">The first operand.</param>
        /// <param name="second">The second operand.</param>
        /// <returns>The result of the operation.</returns>
        public double Apply(double first, double second) =>
            (double)(XMath.Min(first, second));

        /// <summary>
        /// Performs an atomic operation of the form target = AtomicUpdate(target.Value, value).
        /// </summary>
        /// <param name="target">The target address to update.</param>
        /// <param name="value">The value.</param>
        public void AtomicApply(ref double target, double value) =>
            Atomic.Min(ref target, value);
    }

}

#pragma warning restore IDE0004