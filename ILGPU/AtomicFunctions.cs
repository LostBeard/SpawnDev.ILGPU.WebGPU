// ---------------------------------------------------------------------------------------
//                                        ILGPU
//                        Copyright (c) 2016-2023 ILGPU Project
//                                    www.ilgpu.net
//
// File: AtomicFunctions.tt/AtomicFunctions.cs
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

using ILGPU.Frontend.Intrinsic;
using ILGPU.IR.Values;
using System.Runtime.CompilerServices;
using System.Threading;

namespace ILGPU
{
    namespace AtomicOperations
    {
        /// <summary>
        /// Represents an atomic compare-exchange operation of type int.
        /// </summary>
        public readonly struct CompareExchangeInt32 :
            ICompareExchangeOperation<int>
        {
            /// <summary>
            /// Realizes an atomic compare-exchange operation.
            /// </summary>
            /// <param name="target">The target location.</param>
            /// <param name="compare">The expected comparison value.</param>
            /// <param name="value">The target value.</param>
            /// <returns>The old value.</returns>
            public int CompareExchange(
                ref int target,
                int compare,
                int value) =>
                Atomic.CompareExchange(ref target, compare, value);

            /// <summary>
            /// Returns true if both operands represent the same value.
            /// </summary>
            /// <param name="left">The left operand.</param>
            /// <param name="right">The right operand.</param>
            /// <returns>True, if both operands represent the same value.</returns>
            public bool IsSame(
                int left,
                int right) => left == right;
        }

        /// <summary>
        /// Represents an atomic compare-exchange operation of type long.
        /// </summary>
        public readonly struct CompareExchangeInt64 :
            ICompareExchangeOperation<long>
        {
            /// <summary>
            /// Realizes an atomic compare-exchange operation.
            /// </summary>
            /// <param name="target">The target location.</param>
            /// <param name="compare">The expected comparison value.</param>
            /// <param name="value">The target value.</param>
            /// <returns>The old value.</returns>
            public long CompareExchange(
                ref long target,
                long compare,
                long value) =>
                Atomic.CompareExchange(ref target, compare, value);

            /// <summary>
            /// Returns true if both operands represent the same value.
            /// </summary>
            /// <param name="left">The left operand.</param>
            /// <param name="right">The right operand.</param>
            /// <returns>True, if both operands represent the same value.</returns>
            public bool IsSame(
                long left,
                long right) => left == right;
        }

        /// <summary>
        /// Represents an atomic compare-exchange operation of type uint.
        /// </summary>
        public readonly struct CompareExchangeUInt32 :
            ICompareExchangeOperation<uint>
        {
            /// <summary>
            /// Realizes an atomic compare-exchange operation.
            /// </summary>
            /// <param name="target">The target location.</param>
            /// <param name="compare">The expected comparison value.</param>
            /// <param name="value">The target value.</param>
            /// <returns>The old value.</returns>
            public uint CompareExchange(
                ref uint target,
                uint compare,
                uint value) =>
                Atomic.CompareExchange(ref target, compare, value);

            /// <summary>
            /// Returns true if both operands represent the same value.
            /// </summary>
            /// <param name="left">The left operand.</param>
            /// <param name="right">The right operand.</param>
            /// <returns>True, if both operands represent the same value.</returns>
            public bool IsSame(
                uint left,
                uint right) => left == right;
        }

        /// <summary>
        /// Represents an atomic compare-exchange operation of type ulong.
        /// </summary>
        public readonly struct CompareExchangeUInt64 :
            ICompareExchangeOperation<ulong>
        {
            /// <summary>
            /// Realizes an atomic compare-exchange operation.
            /// </summary>
            /// <param name="target">The target location.</param>
            /// <param name="compare">The expected comparison value.</param>
            /// <param name="value">The target value.</param>
            /// <returns>The old value.</returns>
            public ulong CompareExchange(
                ref ulong target,
                ulong compare,
                ulong value) =>
                Atomic.CompareExchange(ref target, compare, value);

            /// <summary>
            /// Returns true if both operands represent the same value.
            /// </summary>
            /// <param name="left">The left operand.</param>
            /// <param name="right">The right operand.</param>
            /// <returns>True, if both operands represent the same value.</returns>
            public bool IsSame(
                ulong left,
                ulong right) => left == right;
        }

        /// <summary>
        /// Represents an atomic compare-exchange operation of type float.
        /// </summary>
        public readonly struct CompareExchangeFloat :
            ICompareExchangeOperation<float>
        {
            /// <summary>
            /// Realizes an atomic compare-exchange operation.
            /// </summary>
            /// <param name="target">The target location.</param>
            /// <param name="compare">The expected comparison value.</param>
            /// <param name="value">The target value.</param>
            /// <returns>The old value.</returns>
            public float CompareExchange(
                ref float target,
                float compare,
                float value) =>
                Atomic.CompareExchange(ref target, compare, value);

            /// <summary>
            /// Returns true if both operands represent the same value.
            /// </summary>
            /// <param name="left">The left operand.</param>
            /// <param name="right">The right operand.</param>
            /// <returns>True, if both operands represent the same value.</returns>
            public bool IsSame(
                float left,
                float right) => left == right;
        }

        /// <summary>
        /// Represents an atomic compare-exchange operation of type double.
        /// </summary>
        public readonly struct CompareExchangeDouble :
            ICompareExchangeOperation<double>
        {
            /// <summary>
            /// Realizes an atomic compare-exchange operation.
            /// </summary>
            /// <param name="target">The target location.</param>
            /// <param name="compare">The expected comparison value.</param>
            /// <param name="value">The target value.</param>
            /// <returns>The old value.</returns>
            public double CompareExchange(
                ref double target,
                double compare,
                double value) =>
                Atomic.CompareExchange(ref target, compare, value);

            /// <summary>
            /// Returns true if both operands represent the same value.
            /// </summary>
            /// <param name="left">The left operand.</param>
            /// <param name="right">The right operand.</param>
            /// <returns>True, if both operands represent the same value.</returns>
            public bool IsSame(
                double left,
                double right) => left == right;
        }

    }

    public static partial class Atomic
    {
        #region Add

        /// <summary>
        /// Atomically adds the given value and the value at the target location
        /// and returns the old value.
        /// </summary>
        /// <param name="target">The target location.</param>
        /// <param name="value">The value to add.</param>
        /// <returns>The old value that was stored at the target location.</returns>
        [AtomicIntrinsic(AtomicIntrinsicKind.Add, AtomicFlags.None)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Add(
            ref int target,
            int value) =>
            Interlocked.Add(ref target, value) - value;

        /// <summary>
        /// Atomically adds the given value and the value at the target location
        /// and returns the old value.
        /// </summary>
        /// <param name="target">The target location.</param>
        /// <param name="value">The value to add.</param>
        /// <returns>The old value that was stored at the target location.</returns>
        [AtomicIntrinsic(AtomicIntrinsicKind.Add, AtomicFlags.None)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Add(
            ref long target,
            long value) =>
            Interlocked.Add(ref target, value) - value;


        readonly struct AddUInt32 :
            AtomicOperations.IAtomicOperation<uint>
        {
            public uint Operation(
                uint current,
                uint value) =>
                current + value;
        }

        readonly struct AddUInt64 :
            AtomicOperations.IAtomicOperation<ulong>
        {
            public ulong Operation(
                ulong current,
                ulong value) =>
                current + value;
        }

        readonly struct AddFloat :
            AtomicOperations.IAtomicOperation<float>
        {
            public float Operation(
                float current,
                float value) =>
                current + value;
        }

        readonly struct AddDouble :
            AtomicOperations.IAtomicOperation<double>
        {
            public double Operation(
                double current,
                double value) =>
                current + value;
        }


        /// <summary>
        /// Atomically adds the given value and the value at the target location
        /// and returns the old value.
        /// </summary>
        /// <param name="target">The target location.</param>
        /// <param name="value">The value to add.</param>
        /// <returns>The old value that was stored at the target location.</returns>
        [AtomicIntrinsic(AtomicIntrinsicKind.Add, AtomicFlags.Unsigned)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Add(
            ref uint target,
            uint value) =>
            MakeAtomic(
                ref target,
                value,
                new AddUInt32(),
                new AtomicOperations.CompareExchangeUInt32());

        /// <summary>
        /// Atomically adds the given value and the value at the target location
        /// and returns the old value.
        /// </summary>
        /// <param name="target">The target location.</param>
        /// <param name="value">The value to add.</param>
        /// <returns>The old value that was stored at the target location.</returns>
        [AtomicIntrinsic(AtomicIntrinsicKind.Add, AtomicFlags.Unsigned)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong Add(
            ref ulong target,
            ulong value) =>
            MakeAtomic(
                ref target,
                value,
                new AddUInt64(),
                new AtomicOperations.CompareExchangeUInt64());


        /// <summary>
        /// Atomically adds the given value and the value at the target location
        /// and returns the old value.
        /// </summary>
        /// <param name="target">The target location.</param>
        /// <param name="value">The value to add.</param>
        /// <returns>The old value that was stored at the target location.</returns>
        [AtomicIntrinsic(AtomicIntrinsicKind.Add, AtomicFlags.None)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Add(
            ref float target,
            float value) =>
            MakeAtomic(
                ref target,
                value,
                new AddFloat(),
                new AtomicOperations.CompareExchangeFloat());

        /// <summary>
        /// Atomically adds the given value and the value at the target location
        /// and returns the old value.
        /// </summary>
        /// <param name="target">The target location.</param>
        /// <param name="value">The value to add.</param>
        /// <returns>The old value that was stored at the target location.</returns>
        [AtomicIntrinsic(AtomicIntrinsicKind.Add, AtomicFlags.None)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Add(
            ref double target,
            double value) =>
            MakeAtomic(
                ref target,
                value,
                new AddDouble(),
                new AtomicOperations.CompareExchangeDouble());


        #endregion

        #region Max

        readonly struct MaxInt32 :
            AtomicOperations.IAtomicOperation<int>
        {
            public int Operation(
                int current,
                int value) =>
                IntrinsicMath.Max(current, value);
        }

        /// <summary>
        /// Atomically computes the maximum at the target location with the given value
        /// and returns the old value that was stored at the target location.
        /// </summary>
        /// <param name="target">The target location.</param>
        /// <param name="value">The comparison value.</param>
        /// <returns>The old value that was stored at the target location.</returns>
        [AtomicIntrinsic(AtomicIntrinsicKind.Max, AtomicFlags.None)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Max(
            ref int target,
            int value) =>
            MakeAtomic(
                ref target,
                value,
                new MaxInt32(),
                new AtomicOperations.CompareExchangeInt32());

        readonly struct MaxInt64 :
            AtomicOperations.IAtomicOperation<long>
        {
            public long Operation(
                long current,
                long value) =>
                IntrinsicMath.Max(current, value);
        }

        /// <summary>
        /// Atomically computes the maximum at the target location with the given value
        /// and returns the old value that was stored at the target location.
        /// </summary>
        /// <param name="target">The target location.</param>
        /// <param name="value">The comparison value.</param>
        /// <returns>The old value that was stored at the target location.</returns>
        [AtomicIntrinsic(AtomicIntrinsicKind.Max, AtomicFlags.None)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Max(
            ref long target,
            long value) =>
            MakeAtomic(
                ref target,
                value,
                new MaxInt64(),
                new AtomicOperations.CompareExchangeInt64());

        readonly struct MaxUInt32 :
            AtomicOperations.IAtomicOperation<uint>
        {
            public uint Operation(
                uint current,
                uint value) =>
                IntrinsicMath.Max(current, value);
        }

        /// <summary>
        /// Atomically computes the maximum at the target location with the given value
        /// and returns the old value that was stored at the target location.
        /// </summary>
        /// <param name="target">The target location.</param>
        /// <param name="value">The comparison value.</param>
        /// <returns>The old value that was stored at the target location.</returns>
        [AtomicIntrinsic(AtomicIntrinsicKind.Max, AtomicFlags.Unsigned)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Max(
            ref uint target,
            uint value) =>
            MakeAtomic(
                ref target,
                value,
                new MaxUInt32(),
                new AtomicOperations.CompareExchangeUInt32());

        readonly struct MaxUInt64 :
            AtomicOperations.IAtomicOperation<ulong>
        {
            public ulong Operation(
                ulong current,
                ulong value) =>
                IntrinsicMath.Max(current, value);
        }

        /// <summary>
        /// Atomically computes the maximum at the target location with the given value
        /// and returns the old value that was stored at the target location.
        /// </summary>
        /// <param name="target">The target location.</param>
        /// <param name="value">The comparison value.</param>
        /// <returns>The old value that was stored at the target location.</returns>
        [AtomicIntrinsic(AtomicIntrinsicKind.Max, AtomicFlags.Unsigned)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong Max(
            ref ulong target,
            ulong value) =>
            MakeAtomic(
                ref target,
                value,
                new MaxUInt64(),
                new AtomicOperations.CompareExchangeUInt64());

        readonly struct MaxFloat :
            AtomicOperations.IAtomicOperation<float>
        {
            public float Operation(
                float current,
                float value) =>
                IntrinsicMath.Max(current, value);
        }

        /// <summary>
        /// Atomically computes the maximum at the target location with the given value
        /// and returns the old value that was stored at the target location.
        /// </summary>
        /// <param name="target">The target location.</param>
        /// <param name="value">The comparison value.</param>
        /// <returns>The old value that was stored at the target location.</returns>
        [AtomicIntrinsic(AtomicIntrinsicKind.Max, AtomicFlags.None)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Max(
            ref float target,
            float value) =>
            MakeAtomic(
                ref target,
                value,
                new MaxFloat(),
                new AtomicOperations.CompareExchangeFloat());

        readonly struct MaxDouble :
            AtomicOperations.IAtomicOperation<double>
        {
            public double Operation(
                double current,
                double value) =>
                IntrinsicMath.Max(current, value);
        }

        /// <summary>
        /// Atomically computes the maximum at the target location with the given value
        /// and returns the old value that was stored at the target location.
        /// </summary>
        /// <param name="target">The target location.</param>
        /// <param name="value">The comparison value.</param>
        /// <returns>The old value that was stored at the target location.</returns>
        [AtomicIntrinsic(AtomicIntrinsicKind.Max, AtomicFlags.None)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Max(
            ref double target,
            double value) =>
            MakeAtomic(
                ref target,
                value,
                new MaxDouble(),
                new AtomicOperations.CompareExchangeDouble());


        #endregion

        #region Min

        readonly struct MinInt32 :
            AtomicOperations.IAtomicOperation<int>
        {
            public int Operation(
                int current,
                int value) =>
                IntrinsicMath.Min(current, value);
        }

        /// <summary>
        /// Atomically computes the minimum at the target location with the given value
        /// and returns the old value that was stored at the target location.
        /// </summary>
        /// <param name="target">The target location.</param>
        /// <param name="value">The comparison value.</param>
        /// <returns>The old value that was stored at the target location.</returns>
        [AtomicIntrinsic(AtomicIntrinsicKind.Min, AtomicFlags.None)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Min(
            ref int target,
            int value) =>
            MakeAtomic(
                ref target,
                value,
                new MinInt32(),
                new AtomicOperations.CompareExchangeInt32());

        readonly struct MinInt64 :
            AtomicOperations.IAtomicOperation<long>
        {
            public long Operation(
                long current,
                long value) =>
                IntrinsicMath.Min(current, value);
        }

        /// <summary>
        /// Atomically computes the minimum at the target location with the given value
        /// and returns the old value that was stored at the target location.
        /// </summary>
        /// <param name="target">The target location.</param>
        /// <param name="value">The comparison value.</param>
        /// <returns>The old value that was stored at the target location.</returns>
        [AtomicIntrinsic(AtomicIntrinsicKind.Min, AtomicFlags.None)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Min(
            ref long target,
            long value) =>
            MakeAtomic(
                ref target,
                value,
                new MinInt64(),
                new AtomicOperations.CompareExchangeInt64());

        readonly struct MinUInt32 :
            AtomicOperations.IAtomicOperation<uint>
        {
            public uint Operation(
                uint current,
                uint value) =>
                IntrinsicMath.Min(current, value);
        }

        /// <summary>
        /// Atomically computes the minimum at the target location with the given value
        /// and returns the old value that was stored at the target location.
        /// </summary>
        /// <param name="target">The target location.</param>
        /// <param name="value">The comparison value.</param>
        /// <returns>The old value that was stored at the target location.</returns>
        [AtomicIntrinsic(AtomicIntrinsicKind.Min, AtomicFlags.Unsigned)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Min(
            ref uint target,
            uint value) =>
            MakeAtomic(
                ref target,
                value,
                new MinUInt32(),
                new AtomicOperations.CompareExchangeUInt32());

        readonly struct MinUInt64 :
            AtomicOperations.IAtomicOperation<ulong>
        {
            public ulong Operation(
                ulong current,
                ulong value) =>
                IntrinsicMath.Min(current, value);
        }

        /// <summary>
        /// Atomically computes the minimum at the target location with the given value
        /// and returns the old value that was stored at the target location.
        /// </summary>
        /// <param name="target">The target location.</param>
        /// <param name="value">The comparison value.</param>
        /// <returns>The old value that was stored at the target location.</returns>
        [AtomicIntrinsic(AtomicIntrinsicKind.Min, AtomicFlags.Unsigned)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong Min(
            ref ulong target,
            ulong value) =>
            MakeAtomic(
                ref target,
                value,
                new MinUInt64(),
                new AtomicOperations.CompareExchangeUInt64());

        readonly struct MinFloat :
            AtomicOperations.IAtomicOperation<float>
        {
            public float Operation(
                float current,
                float value) =>
                IntrinsicMath.Min(current, value);
        }

        /// <summary>
        /// Atomically computes the minimum at the target location with the given value
        /// and returns the old value that was stored at the target location.
        /// </summary>
        /// <param name="target">The target location.</param>
        /// <param name="value">The comparison value.</param>
        /// <returns>The old value that was stored at the target location.</returns>
        [AtomicIntrinsic(AtomicIntrinsicKind.Min, AtomicFlags.None)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Min(
            ref float target,
            float value) =>
            MakeAtomic(
                ref target,
                value,
                new MinFloat(),
                new AtomicOperations.CompareExchangeFloat());

        readonly struct MinDouble :
            AtomicOperations.IAtomicOperation<double>
        {
            public double Operation(
                double current,
                double value) =>
                IntrinsicMath.Min(current, value);
        }

        /// <summary>
        /// Atomically computes the minimum at the target location with the given value
        /// and returns the old value that was stored at the target location.
        /// </summary>
        /// <param name="target">The target location.</param>
        /// <param name="value">The comparison value.</param>
        /// <returns>The old value that was stored at the target location.</returns>
        [AtomicIntrinsic(AtomicIntrinsicKind.Min, AtomicFlags.None)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Min(
            ref double target,
            double value) =>
            MakeAtomic(
                ref target,
                value,
                new MinDouble(),
                new AtomicOperations.CompareExchangeDouble());


        #endregion

        #region And

        readonly struct AndInt32 :
            AtomicOperations.IAtomicOperation<int>
        {
            public int Operation(
                int current,
                int value) =>
                current & value;
        }

        /// <summary>
        /// Atomically computes the logical and of the value at the target location with
        /// the given value and returns the old value that was stored at the target
        /// location.
        /// </summary>
        /// <param name="target">The target location.</param>
        /// <param name="value">The comparison value.</param>
        /// <returns>The old value that was stored at the target location.</returns>
        [AtomicIntrinsic(AtomicIntrinsicKind.And, AtomicFlags.None)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int And(
            ref int target,
            int value) =>
            MakeAtomic(
                ref target,
                value,
                new AndInt32(),
                new AtomicOperations.CompareExchangeInt32());

        readonly struct AndInt64 :
            AtomicOperations.IAtomicOperation<long>
        {
            public long Operation(
                long current,
                long value) =>
                current & value;
        }

        /// <summary>
        /// Atomically computes the logical and of the value at the target location with
        /// the given value and returns the old value that was stored at the target
        /// location.
        /// </summary>
        /// <param name="target">The target location.</param>
        /// <param name="value">The comparison value.</param>
        /// <returns>The old value that was stored at the target location.</returns>
        [AtomicIntrinsic(AtomicIntrinsicKind.And, AtomicFlags.None)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long And(
            ref long target,
            long value) =>
            MakeAtomic(
                ref target,
                value,
                new AndInt64(),
                new AtomicOperations.CompareExchangeInt64());

        readonly struct AndUInt32 :
            AtomicOperations.IAtomicOperation<uint>
        {
            public uint Operation(
                uint current,
                uint value) =>
                current & value;
        }

        /// <summary>
        /// Atomically computes the logical and of the value at the target location with
        /// the given value and returns the old value that was stored at the target
        /// location.
        /// </summary>
        /// <param name="target">The target location.</param>
        /// <param name="value">The comparison value.</param>
        /// <returns>The old value that was stored at the target location.</returns>
        [AtomicIntrinsic(AtomicIntrinsicKind.And, AtomicFlags.Unsigned)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint And(
            ref uint target,
            uint value) =>
            MakeAtomic(
                ref target,
                value,
                new AndUInt32(),
                new AtomicOperations.CompareExchangeUInt32());

        readonly struct AndUInt64 :
            AtomicOperations.IAtomicOperation<ulong>
        {
            public ulong Operation(
                ulong current,
                ulong value) =>
                current & value;
        }

        /// <summary>
        /// Atomically computes the logical and of the value at the target location with
        /// the given value and returns the old value that was stored at the target
        /// location.
        /// </summary>
        /// <param name="target">The target location.</param>
        /// <param name="value">The comparison value.</param>
        /// <returns>The old value that was stored at the target location.</returns>
        [AtomicIntrinsic(AtomicIntrinsicKind.And, AtomicFlags.Unsigned)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong And(
            ref ulong target,
            ulong value) =>
            MakeAtomic(
                ref target,
                value,
                new AndUInt64(),
                new AtomicOperations.CompareExchangeUInt64());


        #endregion

        #region Or

        readonly struct OrInt32 :
            AtomicOperations.IAtomicOperation<int>
        {
            public int Operation(
                int current,
                int value) =>
                current | value;
        }

        /// <summary>
        /// Atomically computes the logical or of the value at the target location with
        /// the given value and returns the old value that was stored at the target
        /// location.
        /// </summary>
        /// <param name="target">The target location.</param>
        /// <param name="value">The comparison value.</param>
        /// <returns>The old value that was stored at the target location.</returns>
        [AtomicIntrinsic(AtomicIntrinsicKind.Or, AtomicFlags.None)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Or(
            ref int target,
            int value) =>
            MakeAtomic(
                ref target,
                value,
                new OrInt32(),
                new AtomicOperations.CompareExchangeInt32());

        readonly struct OrInt64 :
            AtomicOperations.IAtomicOperation<long>
        {
            public long Operation(
                long current,
                long value) =>
                current | value;
        }

        /// <summary>
        /// Atomically computes the logical or of the value at the target location with
        /// the given value and returns the old value that was stored at the target
        /// location.
        /// </summary>
        /// <param name="target">The target location.</param>
        /// <param name="value">The comparison value.</param>
        /// <returns>The old value that was stored at the target location.</returns>
        [AtomicIntrinsic(AtomicIntrinsicKind.Or, AtomicFlags.None)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Or(
            ref long target,
            long value) =>
            MakeAtomic(
                ref target,
                value,
                new OrInt64(),
                new AtomicOperations.CompareExchangeInt64());

        readonly struct OrUInt32 :
            AtomicOperations.IAtomicOperation<uint>
        {
            public uint Operation(
                uint current,
                uint value) =>
                current | value;
        }

        /// <summary>
        /// Atomically computes the logical or of the value at the target location with
        /// the given value and returns the old value that was stored at the target
        /// location.
        /// </summary>
        /// <param name="target">The target location.</param>
        /// <param name="value">The comparison value.</param>
        /// <returns>The old value that was stored at the target location.</returns>
        [AtomicIntrinsic(AtomicIntrinsicKind.Or, AtomicFlags.Unsigned)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Or(
            ref uint target,
            uint value) =>
            MakeAtomic(
                ref target,
                value,
                new OrUInt32(),
                new AtomicOperations.CompareExchangeUInt32());

        readonly struct OrUInt64 :
            AtomicOperations.IAtomicOperation<ulong>
        {
            public ulong Operation(
                ulong current,
                ulong value) =>
                current | value;
        }

        /// <summary>
        /// Atomically computes the logical or of the value at the target location with
        /// the given value and returns the old value that was stored at the target
        /// location.
        /// </summary>
        /// <param name="target">The target location.</param>
        /// <param name="value">The comparison value.</param>
        /// <returns>The old value that was stored at the target location.</returns>
        [AtomicIntrinsic(AtomicIntrinsicKind.Or, AtomicFlags.Unsigned)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong Or(
            ref ulong target,
            ulong value) =>
            MakeAtomic(
                ref target,
                value,
                new OrUInt64(),
                new AtomicOperations.CompareExchangeUInt64());


        #endregion

        #region Xor

        readonly struct XorInt32 :
            AtomicOperations.IAtomicOperation<int>
        {
            public int Operation(
                int current,
                int value) =>
                current ^ value;
        }

        /// <summary>
        /// Atomically computes the logical xor of the value at the target location with
        /// the given value and returns the old value that was stored at the target
        /// location.
        /// </summary>
        /// <param name="target">The target location.</param>
        /// <param name="value">The comparison value.</param>
        /// <returns>The old value that was stored at the target location.</returns>
        [AtomicIntrinsic(AtomicIntrinsicKind.Xor, AtomicFlags.None)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Xor(
            ref int target,
            int value) =>
            MakeAtomic(
                ref target,
                value,
                new XorInt32(),
                new AtomicOperations.CompareExchangeInt32());

        readonly struct XorInt64 :
            AtomicOperations.IAtomicOperation<long>
        {
            public long Operation(
                long current,
                long value) =>
                current ^ value;
        }

        /// <summary>
        /// Atomically computes the logical xor of the value at the target location with
        /// the given value and returns the old value that was stored at the target
        /// location.
        /// </summary>
        /// <param name="target">The target location.</param>
        /// <param name="value">The comparison value.</param>
        /// <returns>The old value that was stored at the target location.</returns>
        [AtomicIntrinsic(AtomicIntrinsicKind.Xor, AtomicFlags.None)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Xor(
            ref long target,
            long value) =>
            MakeAtomic(
                ref target,
                value,
                new XorInt64(),
                new AtomicOperations.CompareExchangeInt64());

        readonly struct XorUInt32 :
            AtomicOperations.IAtomicOperation<uint>
        {
            public uint Operation(
                uint current,
                uint value) =>
                current ^ value;
        }

        /// <summary>
        /// Atomically computes the logical xor of the value at the target location with
        /// the given value and returns the old value that was stored at the target
        /// location.
        /// </summary>
        /// <param name="target">The target location.</param>
        /// <param name="value">The comparison value.</param>
        /// <returns>The old value that was stored at the target location.</returns>
        [AtomicIntrinsic(AtomicIntrinsicKind.Xor, AtomicFlags.Unsigned)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Xor(
            ref uint target,
            uint value) =>
            MakeAtomic(
                ref target,
                value,
                new XorUInt32(),
                new AtomicOperations.CompareExchangeUInt32());

        readonly struct XorUInt64 :
            AtomicOperations.IAtomicOperation<ulong>
        {
            public ulong Operation(
                ulong current,
                ulong value) =>
                current ^ value;
        }

        /// <summary>
        /// Atomically computes the logical xor of the value at the target location with
        /// the given value and returns the old value that was stored at the target
        /// location.
        /// </summary>
        /// <param name="target">The target location.</param>
        /// <param name="value">The comparison value.</param>
        /// <returns>The old value that was stored at the target location.</returns>
        [AtomicIntrinsic(AtomicIntrinsicKind.Xor, AtomicFlags.Unsigned)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong Xor(
            ref ulong target,
            ulong value) =>
            MakeAtomic(
                ref target,
                value,
                new XorUInt64(),
                new AtomicOperations.CompareExchangeUInt64());


        #endregion

        #region Exchange

        /// <summary>
        /// Represents an atomic exchange operation.
        /// </summary>
        /// <param name="target">The target location.</param>
        /// <param name="value">The target value.</param>
        /// <returns>The old value.</returns>
        [AtomicIntrinsic(AtomicIntrinsicKind.Exchange, AtomicFlags.None)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Exchange(
            ref int target,
            int value) =>
            Interlocked.Exchange(ref target, value);

        /// <summary>
        /// Represents an atomic exchange operation.
        /// </summary>
        /// <param name="target">The target location.</param>
        /// <param name="value">The target value.</param>
        /// <returns>The old value.</returns>
        [AtomicIntrinsic(AtomicIntrinsicKind.Exchange, AtomicFlags.None)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Exchange(
            ref long target,
            long value) =>
            Interlocked.Exchange(ref target, value);


        #endregion

        #region Compare & Exchange

        /// <summary>
        /// Represents an atomic compare-exchange operation.
        /// </summary>
        /// <param name="target">The target location.</param>
        /// <param name="compare">The expected comparison value.</param>
        /// <param name="value">The target value.</param>
        /// <returns>The old value.</returns>
        [AtomicIntrinsic(AtomicIntrinsicKind.CompareExchange, AtomicFlags.None)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CompareExchange(
            ref int target,
            int compare,
            int value) =>
            Interlocked.CompareExchange(ref target, value, compare);

        /// <summary>
        /// Represents an atomic compare-exchange operation.
        /// </summary>
        /// <param name="target">The target location.</param>
        /// <param name="compare">The expected comparison value.</param>
        /// <param name="value">The target value.</param>
        /// <returns>The old value.</returns>
        [AtomicIntrinsic(AtomicIntrinsicKind.CompareExchange, AtomicFlags.None)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long CompareExchange(
            ref long target,
            long compare,
            long value) =>
            Interlocked.CompareExchange(ref target, value, compare);


        #endregion
    }
}