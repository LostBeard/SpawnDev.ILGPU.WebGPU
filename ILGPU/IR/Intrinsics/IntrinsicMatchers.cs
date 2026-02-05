// ---------------------------------------------------------------------------------------
//                                        ILGPU
//                        Copyright (c) 2016-2023 ILGPU Project
//                                    www.ilgpu.net
//
// File: IntrinsicMatchers.tt/IntrinsicMatchers.cs
//
// This file is part of ILGPU and is distributed under the University of Illinois Open
// Source License. See LICENSE.txt for details.
// ---------------------------------------------------------------------------------------


using ILGPU.IR.Values;
using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace ILGPU.IR.Intrinsics
{
    partial class IntrinsicMatcher
    {
        /// <summary>
        /// Represents a matcher kind.
        /// </summary>
        internal enum MatcherKind
        {
            Method,
            Broadcast,
            PredicateBarrier,
            WarpShuffle,
            SubWarpShuffle,
            UnaryArithmetic,
            BinaryArithmetic,
            TernaryArithmetic,
            GenericAtomic,
        }

        /// <summary>
        /// Creates a new set of intrinsic matchers.
        /// </summary>
        /// <typeparam name="T">The matcher value type.</typeparam>
        internal static IntrinsicMatcher<T>[] CreateMatchers<T>()
            where T : class, IIntrinsicImplementation =>
            new IntrinsicMatcher<T>[]
            {
                new IntrinsicMethodMatcher<T>(),
                new BroadcastMatcher<T>(),
                new PredicateBarrierMatcher<T>(),
                new WarpShuffleMatcher<T>(),
                new SubWarpShuffleMatcher<T>(),
                new UnaryArithmeticMatcher<T>(),
                new BinaryArithmeticMatcher<T>(),
                new TernaryArithmeticMatcher<T>(),
                new GenericAtomicMatcher<T>(),
            };
    }

    partial class IntrinsicImplementationManager
    {

        /// <summary>
        /// Registers the given intrinsic implementation.
        /// </summary>
        /// <param name="kind">The kind.</param>
        /// <param name="implementation">The intrinsic implementation.</param>
        public void RegisterBroadcast(
            BroadcastKind kind,
            IntrinsicImplementation implementation)
        {
            for (int i = 0, e = (int)BasicValueType.Float64; i <= e; ++i)
                RegisterBroadcast(kind, (BasicValueType)i, implementation);
        }

        /// <summary>
        /// Registers the given intrinsic implementation.
        /// </summary>
        /// <param name="kind">The kind.</param>
        /// <param name="basicValueType">The basic value type.</param>
        /// <param name="implementation">The intrinsic implementation.</param>
        public void RegisterBroadcast(
            BroadcastKind kind,
            BasicValueType basicValueType,
            IntrinsicImplementation implementation)
        {
            var matcher = ResolveMatcher<BroadcastMatcher<ImplementationEntry>>(
                IntrinsicMatcher.MatcherKind.Broadcast,
                implementation);
            if (!matcher.TryGetImplementation(kind, basicValueType, out var entry))
            {
                entry = new ImplementationEntry();
                matcher.Register(kind, basicValueType, entry);
            }
            entry.Register(implementation);
        }

        /// <summary>
        /// Registers the given intrinsic implementation.
        /// </summary>
        /// <param name="kind">The kind.</param>
        /// <param name="implementation">The intrinsic implementation.</param>
        public void RegisterPredicateBarrier(
            PredicateBarrierKind kind,
            IntrinsicImplementation implementation)
        {
            for (int i = 0, e = (int)BasicValueType.Float64; i <= e; ++i)
                RegisterPredicateBarrier(kind, (BasicValueType)i, implementation);
        }

        /// <summary>
        /// Registers the given intrinsic implementation.
        /// </summary>
        /// <param name="kind">The kind.</param>
        /// <param name="basicValueType">The basic value type.</param>
        /// <param name="implementation">The intrinsic implementation.</param>
        public void RegisterPredicateBarrier(
            PredicateBarrierKind kind,
            BasicValueType basicValueType,
            IntrinsicImplementation implementation)
        {
            var matcher = ResolveMatcher<PredicateBarrierMatcher<ImplementationEntry>>(
                IntrinsicMatcher.MatcherKind.PredicateBarrier,
                implementation);
            if (!matcher.TryGetImplementation(kind, basicValueType, out var entry))
            {
                entry = new ImplementationEntry();
                matcher.Register(kind, basicValueType, entry);
            }
            entry.Register(implementation);
        }

        /// <summary>
        /// Registers the given intrinsic implementation.
        /// </summary>
        /// <param name="kind">The kind.</param>
        /// <param name="implementation">The intrinsic implementation.</param>
        public void RegisterWarpShuffle(
            ShuffleKind kind,
            IntrinsicImplementation implementation)
        {
            for (int i = 0, e = (int)BasicValueType.Float64; i <= e; ++i)
                RegisterWarpShuffle(kind, (BasicValueType)i, implementation);
        }

        /// <summary>
        /// Registers the given intrinsic implementation.
        /// </summary>
        /// <param name="kind">The kind.</param>
        /// <param name="basicValueType">The basic value type.</param>
        /// <param name="implementation">The intrinsic implementation.</param>
        public void RegisterWarpShuffle(
            ShuffleKind kind,
            BasicValueType basicValueType,
            IntrinsicImplementation implementation)
        {
            var matcher = ResolveMatcher<WarpShuffleMatcher<ImplementationEntry>>(
                IntrinsicMatcher.MatcherKind.WarpShuffle,
                implementation);
            if (!matcher.TryGetImplementation(kind, basicValueType, out var entry))
            {
                entry = new ImplementationEntry();
                matcher.Register(kind, basicValueType, entry);
            }
            entry.Register(implementation);
        }

        /// <summary>
        /// Registers the given intrinsic implementation.
        /// </summary>
        /// <param name="kind">The kind.</param>
        /// <param name="implementation">The intrinsic implementation.</param>
        public void RegisterSubWarpShuffle(
            ShuffleKind kind,
            IntrinsicImplementation implementation)
        {
            for (int i = 0, e = (int)BasicValueType.Float64; i <= e; ++i)
                RegisterSubWarpShuffle(kind, (BasicValueType)i, implementation);
        }

        /// <summary>
        /// Registers the given intrinsic implementation.
        /// </summary>
        /// <param name="kind">The kind.</param>
        /// <param name="basicValueType">The basic value type.</param>
        /// <param name="implementation">The intrinsic implementation.</param>
        public void RegisterSubWarpShuffle(
            ShuffleKind kind,
            BasicValueType basicValueType,
            IntrinsicImplementation implementation)
        {
            var matcher = ResolveMatcher<SubWarpShuffleMatcher<ImplementationEntry>>(
                IntrinsicMatcher.MatcherKind.SubWarpShuffle,
                implementation);
            if (!matcher.TryGetImplementation(kind, basicValueType, out var entry))
            {
                entry = new ImplementationEntry();
                matcher.Register(kind, basicValueType, entry);
            }
            entry.Register(implementation);
        }

        /// <summary>
        /// Registers the given intrinsic implementation.
        /// </summary>
        /// <param name="kind">The kind.</param>
        /// <param name="implementation">The intrinsic implementation.</param>
        public void RegisterUnaryArithmetic(
            UnaryArithmeticKind kind,
            IntrinsicImplementation implementation)
        {
            for (int i = 0, e = (int)BasicValueType.Float64; i <= e; ++i)
                RegisterUnaryArithmetic(kind, (BasicValueType)i, implementation);
        }

        /// <summary>
        /// Registers the given intrinsic implementation.
        /// </summary>
        /// <param name="kind">The kind.</param>
        /// <param name="basicValueType">The basic value type.</param>
        /// <param name="implementation">The intrinsic implementation.</param>
        public void RegisterUnaryArithmetic(
            UnaryArithmeticKind kind,
            BasicValueType basicValueType,
            IntrinsicImplementation implementation)
        {
            var matcher = ResolveMatcher<UnaryArithmeticMatcher<ImplementationEntry>>(
                IntrinsicMatcher.MatcherKind.UnaryArithmetic,
                implementation);
            if (!matcher.TryGetImplementation(kind, basicValueType, out var entry))
            {
                entry = new ImplementationEntry();
                matcher.Register(kind, basicValueType, entry);
            }
            entry.Register(implementation);
        }

        /// <summary>
        /// Registers the given intrinsic implementation.
        /// </summary>
        /// <param name="kind">The kind.</param>
        /// <param name="implementation">The intrinsic implementation.</param>
        public void RegisterBinaryArithmetic(
            BinaryArithmeticKind kind,
            IntrinsicImplementation implementation)
        {
            for (int i = 0, e = (int)BasicValueType.Float64; i <= e; ++i)
                RegisterBinaryArithmetic(kind, (BasicValueType)i, implementation);
        }

        /// <summary>
        /// Registers the given intrinsic implementation.
        /// </summary>
        /// <param name="kind">The kind.</param>
        /// <param name="basicValueType">The basic value type.</param>
        /// <param name="implementation">The intrinsic implementation.</param>
        public void RegisterBinaryArithmetic(
            BinaryArithmeticKind kind,
            BasicValueType basicValueType,
            IntrinsicImplementation implementation)
        {
            var matcher = ResolveMatcher<BinaryArithmeticMatcher<ImplementationEntry>>(
                IntrinsicMatcher.MatcherKind.BinaryArithmetic,
                implementation);
            if (!matcher.TryGetImplementation(kind, basicValueType, out var entry))
            {
                entry = new ImplementationEntry();
                matcher.Register(kind, basicValueType, entry);
            }
            entry.Register(implementation);
        }

        /// <summary>
        /// Registers the given intrinsic implementation.
        /// </summary>
        /// <param name="kind">The kind.</param>
        /// <param name="implementation">The intrinsic implementation.</param>
        public void RegisterTernaryArithmetic(
            TernaryArithmeticKind kind,
            IntrinsicImplementation implementation)
        {
            for (int i = 0, e = (int)BasicValueType.Float64; i <= e; ++i)
                RegisterTernaryArithmetic(kind, (BasicValueType)i, implementation);
        }

        /// <summary>
        /// Registers the given intrinsic implementation.
        /// </summary>
        /// <param name="kind">The kind.</param>
        /// <param name="basicValueType">The basic value type.</param>
        /// <param name="implementation">The intrinsic implementation.</param>
        public void RegisterTernaryArithmetic(
            TernaryArithmeticKind kind,
            BasicValueType basicValueType,
            IntrinsicImplementation implementation)
        {
            var matcher = ResolveMatcher<TernaryArithmeticMatcher<ImplementationEntry>>(
                IntrinsicMatcher.MatcherKind.TernaryArithmetic,
                implementation);
            if (!matcher.TryGetImplementation(kind, basicValueType, out var entry))
            {
                entry = new ImplementationEntry();
                matcher.Register(kind, basicValueType, entry);
            }
            entry.Register(implementation);
        }

        /// <summary>
        /// Registers the given intrinsic implementation.
        /// </summary>
        /// <param name="kind">The kind.</param>
        /// <param name="implementation">The intrinsic implementation.</param>
        public void RegisterGenericAtomic(
            AtomicKind kind,
            IntrinsicImplementation implementation)
        {
            for (int i = 0, e = (int)BasicValueType.Float64; i <= e; ++i)
                RegisterGenericAtomic(kind, (BasicValueType)i, implementation);
        }

        /// <summary>
        /// Registers the given intrinsic implementation.
        /// </summary>
        /// <param name="kind">The kind.</param>
        /// <param name="basicValueType">The basic value type.</param>
        /// <param name="implementation">The intrinsic implementation.</param>
        public void RegisterGenericAtomic(
            AtomicKind kind,
            BasicValueType basicValueType,
            IntrinsicImplementation implementation)
        {
            var matcher = ResolveMatcher<GenericAtomicMatcher<ImplementationEntry>>(
                IntrinsicMatcher.MatcherKind.GenericAtomic,
                implementation);
            if (!matcher.TryGetImplementation(kind, basicValueType, out var entry))
            {
                entry = new ImplementationEntry();
                matcher.Register(kind, basicValueType, entry);
            }
            entry.Register(implementation);
        }

    }


    /// <summary>
    /// Matches typed Broadcast values.
    /// </summary>
    sealed class BroadcastMatcher<T> :
        TypedIntrinsicValueMatcher<T, BroadcastKind>
        where T : class, IIntrinsicImplementation
    {
        public BroadcastMatcher()
            : base(ValueKind.Broadcast)
        { }

        /// <summary>
        /// Registers the given implementation with the current matcher.
        /// </summary>
        /// <param name="kind">The value kind.</param>
        /// <param name="basicValueType">The basic value type.</param>
        /// <param name="implementation">
        /// The intrinsic implementation to register.
        /// </param>
        public void Register(
            BroadcastKind kind,
            BasicValueType basicValueType,
            T implementation) =>
            this[(int)kind, basicValueType] = implementation
                ?? throw new ArgumentNullException(nameof(implementation));

        /// <summary>
        /// Tries to resolve an intrinsic implementation.
        /// </summary>
        /// <param name="kind">The value kind.</param>
        /// <param name="basicValueType">The basic value type.</param>
        /// <param name="implementation">The resolved implementation (if any).</param>
        /// <returns>True, if an implementation could be resolved.</returns>
        public bool TryGetImplementation(
            BroadcastKind kind,
            BasicValueType basicValueType,
            [NotNullWhen(true)] out T? implementation)
        {
            implementation = this[(int)kind, basicValueType];
            return implementation != null;
        }

        /// <summary cref="IntrinsicMatcher{T, TMatchedValue}.TryGetImplementation(
        /// TMatchedValue, out T)"/>
        public override bool TryGetImplementation(
            Value value,
            [NotNullWhen(true)] out T? implementation)
        {
            var targetValue = value as Broadcast;
            Debug.Assert(targetValue != null, "Invalid target value");
            return TryGetImplementation(
                targetValue.Kind,
                targetValue.BasicValueType,
                out implementation);
        }
    }

    /// <summary>
    /// Matches typed PredicateBarrier values.
    /// </summary>
    sealed class PredicateBarrierMatcher<T> :
        TypedIntrinsicValueMatcher<T, PredicateBarrierKind>
        where T : class, IIntrinsicImplementation
    {
        public PredicateBarrierMatcher()
            : base(ValueKind.PredicateBarrier)
        { }

        /// <summary>
        /// Registers the given implementation with the current matcher.
        /// </summary>
        /// <param name="kind">The value kind.</param>
        /// <param name="basicValueType">The basic value type.</param>
        /// <param name="implementation">
        /// The intrinsic implementation to register.
        /// </param>
        public void Register(
            PredicateBarrierKind kind,
            BasicValueType basicValueType,
            T implementation) =>
            this[(int)kind, basicValueType] = implementation
                ?? throw new ArgumentNullException(nameof(implementation));

        /// <summary>
        /// Tries to resolve an intrinsic implementation.
        /// </summary>
        /// <param name="kind">The value kind.</param>
        /// <param name="basicValueType">The basic value type.</param>
        /// <param name="implementation">The resolved implementation (if any).</param>
        /// <returns>True, if an implementation could be resolved.</returns>
        public bool TryGetImplementation(
            PredicateBarrierKind kind,
            BasicValueType basicValueType,
            [NotNullWhen(true)] out T? implementation)
        {
            implementation = this[(int)kind, basicValueType];
            return implementation != null;
        }

        /// <summary cref="IntrinsicMatcher{T, TMatchedValue}.TryGetImplementation(
        /// TMatchedValue, out T)"/>
        public override bool TryGetImplementation(
            Value value,
            [NotNullWhen(true)] out T? implementation)
        {
            var targetValue = value as PredicateBarrier;
            Debug.Assert(targetValue != null, "Invalid target value");
            return TryGetImplementation(
                targetValue.Kind,
                targetValue.BasicValueType,
                out implementation);
        }
    }

    /// <summary>
    /// Matches typed WarpShuffle values.
    /// </summary>
    sealed class WarpShuffleMatcher<T> :
        TypedIntrinsicValueMatcher<T, ShuffleKind>
        where T : class, IIntrinsicImplementation
    {
        public WarpShuffleMatcher()
            : base(ValueKind.WarpShuffle)
        { }

        /// <summary>
        /// Registers the given implementation with the current matcher.
        /// </summary>
        /// <param name="kind">The value kind.</param>
        /// <param name="basicValueType">The basic value type.</param>
        /// <param name="implementation">
        /// The intrinsic implementation to register.
        /// </param>
        public void Register(
            ShuffleKind kind,
            BasicValueType basicValueType,
            T implementation) =>
            this[(int)kind, basicValueType] = implementation
                ?? throw new ArgumentNullException(nameof(implementation));

        /// <summary>
        /// Tries to resolve an intrinsic implementation.
        /// </summary>
        /// <param name="kind">The value kind.</param>
        /// <param name="basicValueType">The basic value type.</param>
        /// <param name="implementation">The resolved implementation (if any).</param>
        /// <returns>True, if an implementation could be resolved.</returns>
        public bool TryGetImplementation(
            ShuffleKind kind,
            BasicValueType basicValueType,
            [NotNullWhen(true)] out T? implementation)
        {
            implementation = this[(int)kind, basicValueType];
            return implementation != null;
        }

        /// <summary cref="IntrinsicMatcher{T, TMatchedValue}.TryGetImplementation(
        /// TMatchedValue, out T)"/>
        public override bool TryGetImplementation(
            Value value,
            [NotNullWhen(true)] out T? implementation)
        {
            var targetValue = value as WarpShuffle;
            Debug.Assert(targetValue != null, "Invalid target value");
            return TryGetImplementation(
                targetValue.Kind,
                targetValue.BasicValueType,
                out implementation);
        }
    }

    /// <summary>
    /// Matches typed SubWarpShuffle values.
    /// </summary>
    sealed class SubWarpShuffleMatcher<T> :
        TypedIntrinsicValueMatcher<T, ShuffleKind>
        where T : class, IIntrinsicImplementation
    {
        public SubWarpShuffleMatcher()
            : base(ValueKind.SubWarpShuffle)
        { }

        /// <summary>
        /// Registers the given implementation with the current matcher.
        /// </summary>
        /// <param name="kind">The value kind.</param>
        /// <param name="basicValueType">The basic value type.</param>
        /// <param name="implementation">
        /// The intrinsic implementation to register.
        /// </param>
        public void Register(
            ShuffleKind kind,
            BasicValueType basicValueType,
            T implementation) =>
            this[(int)kind, basicValueType] = implementation
                ?? throw new ArgumentNullException(nameof(implementation));

        /// <summary>
        /// Tries to resolve an intrinsic implementation.
        /// </summary>
        /// <param name="kind">The value kind.</param>
        /// <param name="basicValueType">The basic value type.</param>
        /// <param name="implementation">The resolved implementation (if any).</param>
        /// <returns>True, if an implementation could be resolved.</returns>
        public bool TryGetImplementation(
            ShuffleKind kind,
            BasicValueType basicValueType,
            [NotNullWhen(true)] out T? implementation)
        {
            implementation = this[(int)kind, basicValueType];
            return implementation != null;
        }

        /// <summary cref="IntrinsicMatcher{T, TMatchedValue}.TryGetImplementation(
        /// TMatchedValue, out T)"/>
        public override bool TryGetImplementation(
            Value value,
            [NotNullWhen(true)] out T? implementation)
        {
            var targetValue = value as SubWarpShuffle;
            Debug.Assert(targetValue != null, "Invalid target value");
            return TryGetImplementation(
                targetValue.Kind,
                targetValue.BasicValueType,
                out implementation);
        }
    }

    /// <summary>
    /// Matches typed UnaryArithmetic values.
    /// </summary>
    sealed class UnaryArithmeticMatcher<T> :
        TypedIntrinsicValueMatcher<T, UnaryArithmeticKind>
        where T : class, IIntrinsicImplementation
    {
        public UnaryArithmeticMatcher()
            : base(ValueKind.UnaryArithmetic)
        { }

        /// <summary>
        /// Registers the given implementation with the current matcher.
        /// </summary>
        /// <param name="kind">The value kind.</param>
        /// <param name="basicValueType">The basic value type.</param>
        /// <param name="implementation">
        /// The intrinsic implementation to register.
        /// </param>
        public void Register(
            UnaryArithmeticKind kind,
            BasicValueType basicValueType,
            T implementation) =>
            this[(int)kind, basicValueType] = implementation
                ?? throw new ArgumentNullException(nameof(implementation));

        /// <summary>
        /// Tries to resolve an intrinsic implementation.
        /// </summary>
        /// <param name="kind">The value kind.</param>
        /// <param name="basicValueType">The basic value type.</param>
        /// <param name="implementation">The resolved implementation (if any).</param>
        /// <returns>True, if an implementation could be resolved.</returns>
        public bool TryGetImplementation(
            UnaryArithmeticKind kind,
            BasicValueType basicValueType,
            [NotNullWhen(true)] out T? implementation)
        {
            implementation = this[(int)kind, basicValueType];
            return implementation != null;
        }

        /// <summary cref="IntrinsicMatcher{T, TMatchedValue}.TryGetImplementation(
        /// TMatchedValue, out T)"/>
        public override bool TryGetImplementation(
            Value value,
            [NotNullWhen(true)] out T? implementation)
        {
            var targetValue = value as UnaryArithmeticValue;
            Debug.Assert(targetValue != null, "Invalid target value");
            return TryGetImplementation(
                targetValue.Kind,
                targetValue.Value.BasicValueType,
                out implementation);
        }
    }

    /// <summary>
    /// Matches typed BinaryArithmetic values.
    /// </summary>
    sealed class BinaryArithmeticMatcher<T> :
        TypedIntrinsicValueMatcher<T, BinaryArithmeticKind>
        where T : class, IIntrinsicImplementation
    {
        public BinaryArithmeticMatcher()
            : base(ValueKind.BinaryArithmetic)
        { }

        /// <summary>
        /// Registers the given implementation with the current matcher.
        /// </summary>
        /// <param name="kind">The value kind.</param>
        /// <param name="basicValueType">The basic value type.</param>
        /// <param name="implementation">
        /// The intrinsic implementation to register.
        /// </param>
        public void Register(
            BinaryArithmeticKind kind,
            BasicValueType basicValueType,
            T implementation) =>
            this[(int)kind, basicValueType] = implementation
                ?? throw new ArgumentNullException(nameof(implementation));

        /// <summary>
        /// Tries to resolve an intrinsic implementation.
        /// </summary>
        /// <param name="kind">The value kind.</param>
        /// <param name="basicValueType">The basic value type.</param>
        /// <param name="implementation">The resolved implementation (if any).</param>
        /// <returns>True, if an implementation could be resolved.</returns>
        public bool TryGetImplementation(
            BinaryArithmeticKind kind,
            BasicValueType basicValueType,
            [NotNullWhen(true)] out T? implementation)
        {
            implementation = this[(int)kind, basicValueType];
            return implementation != null;
        }

        /// <summary cref="IntrinsicMatcher{T, TMatchedValue}.TryGetImplementation(
        /// TMatchedValue, out T)"/>
        public override bool TryGetImplementation(
            Value value,
            [NotNullWhen(true)] out T? implementation)
        {
            var targetValue = value as BinaryArithmeticValue;
            Debug.Assert(targetValue != null, "Invalid target value");
            return TryGetImplementation(
                targetValue.Kind,
                targetValue.BasicValueType,
                out implementation);
        }
    }

    /// <summary>
    /// Matches typed TernaryArithmetic values.
    /// </summary>
    sealed class TernaryArithmeticMatcher<T> :
        TypedIntrinsicValueMatcher<T, TernaryArithmeticKind>
        where T : class, IIntrinsicImplementation
    {
        public TernaryArithmeticMatcher()
            : base(ValueKind.TernaryArithmetic)
        { }

        /// <summary>
        /// Registers the given implementation with the current matcher.
        /// </summary>
        /// <param name="kind">The value kind.</param>
        /// <param name="basicValueType">The basic value type.</param>
        /// <param name="implementation">
        /// The intrinsic implementation to register.
        /// </param>
        public void Register(
            TernaryArithmeticKind kind,
            BasicValueType basicValueType,
            T implementation) =>
            this[(int)kind, basicValueType] = implementation
                ?? throw new ArgumentNullException(nameof(implementation));

        /// <summary>
        /// Tries to resolve an intrinsic implementation.
        /// </summary>
        /// <param name="kind">The value kind.</param>
        /// <param name="basicValueType">The basic value type.</param>
        /// <param name="implementation">The resolved implementation (if any).</param>
        /// <returns>True, if an implementation could be resolved.</returns>
        public bool TryGetImplementation(
            TernaryArithmeticKind kind,
            BasicValueType basicValueType,
            [NotNullWhen(true)] out T? implementation)
        {
            implementation = this[(int)kind, basicValueType];
            return implementation != null;
        }

        /// <summary cref="IntrinsicMatcher{T, TMatchedValue}.TryGetImplementation(
        /// TMatchedValue, out T)"/>
        public override bool TryGetImplementation(
            Value value,
            [NotNullWhen(true)] out T? implementation)
        {
            var targetValue = value as TernaryArithmeticValue;
            Debug.Assert(targetValue != null, "Invalid target value");
            return TryGetImplementation(
                targetValue.Kind,
                targetValue.BasicValueType,
                out implementation);
        }
    }

    /// <summary>
    /// Matches typed GenericAtomic values.
    /// </summary>
    sealed class GenericAtomicMatcher<T> :
        TypedIntrinsicValueMatcher<T, AtomicKind>
        where T : class, IIntrinsicImplementation
    {
        public GenericAtomicMatcher()
            : base(ValueKind.GenericAtomic)
        { }

        /// <summary>
        /// Registers the given implementation with the current matcher.
        /// </summary>
        /// <param name="kind">The value kind.</param>
        /// <param name="basicValueType">The basic value type.</param>
        /// <param name="implementation">
        /// The intrinsic implementation to register.
        /// </param>
        public void Register(
            AtomicKind kind,
            BasicValueType basicValueType,
            T implementation) =>
            this[(int)kind, basicValueType] = implementation
                ?? throw new ArgumentNullException(nameof(implementation));

        /// <summary>
        /// Tries to resolve an intrinsic implementation.
        /// </summary>
        /// <param name="kind">The value kind.</param>
        /// <param name="basicValueType">The basic value type.</param>
        /// <param name="implementation">The resolved implementation (if any).</param>
        /// <returns>True, if an implementation could be resolved.</returns>
        public bool TryGetImplementation(
            AtomicKind kind,
            BasicValueType basicValueType,
            [NotNullWhen(true)] out T? implementation)
        {
            implementation = this[(int)kind, basicValueType];
            return implementation != null;
        }

        /// <summary cref="IntrinsicMatcher{T, TMatchedValue}.TryGetImplementation(
        /// TMatchedValue, out T)"/>
        public override bool TryGetImplementation(
            Value value,
            [NotNullWhen(true)] out T? implementation)
        {
            var targetValue = value as GenericAtomic;
            Debug.Assert(targetValue != null, "Invalid target value");
            return TryGetImplementation(
                targetValue.Kind,
                targetValue.BasicValueType,
                out implementation);
        }
    }

}