// ---------------------------------------------------------------------------------------
//                                   ILGPU Algorithms
//                        Copyright (c) 2020-2023 ILGPU Project
//                                    www.ilgpu.net
//
// File: HistogramOperations.tt/HistogramOperations.cs
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

namespace ILGPU.Algorithms.HistogramOperations
{
    /// <summary>
    /// Represents atomically incrementing a histogram bin of type int.
    /// </summary>
    public readonly struct HistogramIncrementInt32 :
        IIncrementOperation<int>
    {
        /// <summary>
        /// Atomically increments a histogram bin of type int.
        /// </summary>
        public void Increment(ref int target, out bool incrementOverflow)
        {
            var oldValue = Atomic.Add(ref target, 1);
            incrementOverflow = oldValue == int.MaxValue;
        }
    }

    /// <summary>
    /// Represents atomically incrementing a histogram bin of type long.
    /// </summary>
    public readonly struct HistogramIncrementInt64 :
        IIncrementOperation<long>
    {
        /// <summary>
        /// Atomically increments a histogram bin of type long.
        /// </summary>
        public void Increment(ref long target, out bool incrementOverflow)
        {
            var oldValue = Atomic.Add(ref target, 1);
            incrementOverflow = oldValue == long.MaxValue;
        }
    }

    /// <summary>
    /// Represents atomically incrementing a histogram bin of type uint.
    /// </summary>
    public readonly struct HistogramIncrementUInt32 :
        IIncrementOperation<uint>
    {
        /// <summary>
        /// Atomically increments a histogram bin of type uint.
        /// </summary>
        public void Increment(ref uint target, out bool incrementOverflow)
        {
            var oldValue = Atomic.Add(ref target, 1);
            incrementOverflow = oldValue == uint.MaxValue;
        }
    }

    /// <summary>
    /// Represents atomically incrementing a histogram bin of type ulong.
    /// </summary>
    public readonly struct HistogramIncrementUInt64 :
        IIncrementOperation<ulong>
    {
        /// <summary>
        /// Atomically increments a histogram bin of type ulong.
        /// </summary>
        public void Increment(ref ulong target, out bool incrementOverflow)
        {
            var oldValue = Atomic.Add(ref target, 1);
            incrementOverflow = oldValue == ulong.MaxValue;
        }
    }

    /// <summary>
    /// Represents atomically incrementing a histogram bin of type float.
    /// </summary>
    public readonly struct HistogramIncrementFloat :
        IIncrementOperation<float>
    {
        /// <summary>
        /// Atomically increments a histogram bin of type float.
        /// </summary>
        public void Increment(ref float target, out bool incrementOverflow)
        {
            var oldValue = Atomic.Add(ref target, 1);
            incrementOverflow = oldValue == float.MaxValue;
        }
    }

    /// <summary>
    /// Represents atomically incrementing a histogram bin of type double.
    /// </summary>
    public readonly struct HistogramIncrementDouble :
        IIncrementOperation<double>
    {
        /// <summary>
        /// Atomically increments a histogram bin of type double.
        /// </summary>
        public void Increment(ref double target, out bool incrementOverflow)
        {
            var oldValue = Atomic.Add(ref target, 1);
            incrementOverflow = oldValue == double.MaxValue;
        }
    }

}