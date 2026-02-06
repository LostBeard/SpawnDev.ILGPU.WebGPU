// ---------------------------------------------------------------------------------------
//                                   ILGPU Algorithms
//                        Copyright (c) 2023-2024 ILGPU Project
//                                    www.ilgpu.net
//
// File: RandomRanges.tt/RandomRanges.cs
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

// ---------------------------------------------------------------------------------------
//                                   ILGPU Algorithms
//                        Copyright (c) 2023-2024 ILGPU Project
//                                    www.ilgpu.net
//
// File: FixedIntConfig.ttinclude
//
// This file is part of ILGPU and is distributed under the University of Illinois Open
// Source License. See LICENSE.txt for details.
// ---------------------------------------------------------------------------------------

#if NET7_0_OR_GREATER
using ILGPU.Algorithms.FixedPrecision;
#endif
using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;

#pragma warning disable CA1000 // No static members on generic types
#pragma warning disable IDE0004 // Cast is redundant

#if NET7_0_OR_GREATER

namespace ILGPU.Algorithms.Random
{
    /// <summary>
    /// A generic random number range operating on a generic type
    /// <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The element type to operate on.</typeparam>
    public interface IBasicRandomRange<out T>
        where T : struct
    {
        /// <summary>
        /// Returns the min value of this range (inclusive).
        /// </summary>
        T MinValue { get; }

        /// <summary>
        /// Returns the max value of this range (exclusive).
        /// </summary>
        T MaxValue { get; }
    }

    /// <summary>
    /// A generic random number range operating on a generic type
    /// <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The element type to operate on.</typeparam>
    public interface IRandomRange<out T> : IBasicRandomRange<T>
        where T : struct
    {
        /// <summary>
        /// Generates a new random value by taking min and max value ranges into account.
        /// </summary>
        /// <typeparam name="TRandomProvider">The random provider type.</typeparam>
        /// <param name="randomProvider">The random provider instance.</param>
        /// <returns>The retrieved random value.</returns>
        /// <remarks>
        /// CAUTION: This function implementation is meant to be thread safe in general to
        /// support massively parallel evaluations on CPU and GPU.
        /// </remarks>
        [SuppressMessage(
            "Naming",
            "CA1716:Identifiers should not match keywords",
            Justification = "Like the method System.Random.Next()")]
        T Next<TRandomProvider>(ref TRandomProvider randomProvider)
            where TRandomProvider : struct, IRandomProvider;
    }

    /// <summary>
    /// A generic random number range provider operating on a generic type
    /// <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The element type to operate on.</typeparam>
    /// <remarks>
    /// CAUTION: A type implementing this interface is meant to be thread safe in general
    /// to support massively parallel evaluations on CPU and GPU.
    /// </remarks>
    public interface IRandomRangeProvider<T>
        where T : struct
    {
        /// <summary>
        /// Generates a new random value by taking min and max value ranges into account.
        /// </summary>
        /// <returns>The retrieved random value.</returns>
        [SuppressMessage(
            "Naming",
            "CA1716:Identifiers should not match keywords",
            Justification = "Like the method System.Random.Next()")]
        T Next();
    }

    /// <summary>
    /// A generic random number range provider operating on a generic type
    /// <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="TSelf">The type implementing this interface.</typeparam>
    /// <typeparam name="T">The element type to operate on.</typeparam>
    /// <remarks>
    /// CAUTION: A type implementing this interface is meant to be thread safe in general
    /// to support massively parallel evaluations on CPU and GPU.
    /// </remarks>
    public interface IRandomRangeProvider<TSelf, T> :
        IRandomRangeProvider<T>, IBasicRandomRange<T>
        where TSelf : struct, IRandomRangeProvider<TSelf, T>
        where T : unmanaged
    {
        /// <summary>
        /// Instantiates a new random range using the given random provider.
        /// </summary>
        /// <param name="random">The parent RNG instance.</param>
        /// <param name="minValue">The minimum value (inclusive).</param>
        /// <param name="maxValue">The maximum value (exclusive).</param>
        static abstract TSelf Create(System.Random random, T minValue, T maxValue);

        /// <summary>
        /// Instantiates a new random range using the given random provider.
        /// </summary>
        /// <param name="random">The parent RNG instance.</param>
        /// <param name="minValue">The minimum value (inclusive).</param>
        /// <param name="maxValue">The maximum value (exclusive).</param>
        static abstract TSelf Create<TOtherProvider>(
            ref TOtherProvider random,
            T minValue,
            T maxValue)
            where TOtherProvider : struct, IRandomProvider<TOtherProvider>;

        /// <summary>
        /// Creates a new random range vector provider compatible with this provider.
        /// </summary>
        RandomRangeVectorProvider<T, TSelf> CreateVectorProvider();
    }

    /// <summary>
    /// Represents a default RNG range for vectors types returning specified value
    /// intervals for type Vector.
    /// </summary>
    /// <typeparam name="T">The vector element type.</typeparam>
    /// <typeparam name="TRangeProvider">The underlying range provider.</typeparam>
    public struct RandomRangeVectorProvider<T, TRangeProvider> :
        IRandomRangeProvider<Vector<T>>,
        IRandomRangeProvider<T>,
        IBasicRandomRange<T>
        where T : unmanaged
        where TRangeProvider : struct, IRandomRangeProvider<TRangeProvider, T>
    {
        private TRangeProvider rangeProvider;

        /// <summary>
        /// Instantiates a new random range provider using the given random provider.
        /// </summary>
        /// <param name="provider">The RNG provider to use.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public RandomRangeVectorProvider(TRangeProvider provider)
        {
            rangeProvider = provider;
        }

        /// <summary>
        /// Returns the min value of this range (inclusive).
        /// </summary>
        public readonly T MinValue => rangeProvider.MinValue;

        /// <summary>
        /// Returns the max value of this range (exclusive).
        /// </summary>
        public readonly T MaxValue => rangeProvider.MaxValue;

        /// <summary>
        /// Generates a new random value using the given min and max values.
        /// </summary>
        [SuppressMessage(
            "Naming",
            "CA1716:Identifiers should not match keywords",
            Justification = "Like the method System.Random.Next()")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector<T> Next() =>
            RandomExtensions.NextVector<T, TRangeProvider>(ref rangeProvider);

        /// <summary>
        /// Generates a new random value using the given min and max values.
        /// </summary>
        [SuppressMessage(
            "Naming",
            "CA1716:Identifiers should not match keywords",
            Justification = "Like the method System.Random.Next()")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        T IRandomRangeProvider<T>.Next() => rangeProvider.Next();
    }

    /// <summary>
    /// A container class holding specialized random range instances while providing
    /// specialized extension methods for different RNG providers.
    /// </summary>
    public static class RandomRanges
    {
        /// <summary>
        /// Represents a default RNG range for type Int8 returning
        /// specified value intervals for type Int8 (in analogy to calling
        /// the appropriate NextXYZ method on the random provider given using min and
        /// max values).
        /// </summary>
        /// <param name="MinValue">The minimum value (inclusive).</param>
        /// <param name="MaxValue">The maximum values (exclusive).</param>
        public readonly record struct RandomRangeInt8(
            sbyte MinValue,
            sbyte MaxValue) :
            IRandomRange<sbyte>
        {
            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RandomRangeInt8Provider<TRandomProvider>
                CreateProvider<TRandomProvider>(System.Random random)
                where TRandomProvider : struct, IRandomProvider<TRandomProvider> =>
                RandomRangeInt8Provider<TRandomProvider>.Create(
                    random,
                    MinValue,
                    MaxValue);

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RandomRangeInt8Provider<TRandomProvider>
                CreateProvider<TRandomProvider>(ref TRandomProvider random)
                where TRandomProvider : struct, IRandomProvider<TRandomProvider> =>
                RandomRangeInt8Provider<TRandomProvider>.Create(
                    ref random,
                    MinValue,
                    MaxValue);

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RandomRangeInt8Provider<TRandomProvider>
                CreateProvider<TRandomProvider, TOtherRandomProvider>(
                ref TOtherRandomProvider random)
                where TRandomProvider : struct, IRandomProvider<TRandomProvider>
                where TOtherRandomProvider :
                    struct, IRandomProvider<TOtherRandomProvider> =>
                RandomRangeInt8Provider<TRandomProvider>.Create(
                    ref random,
                    MinValue,
                    MaxValue);

            /// <summary>
            /// Generates a new random value using the given min and max values.
            /// </summary>
            [SuppressMessage(
                "Naming",
                "CA1716:Identifiers should not match keywords",
                Justification = "Like the method System.Random.Next()")]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public sbyte Next<TRandomProvider>(
                ref TRandomProvider randomProvider)
                where TRandomProvider : struct, IRandomProvider =>
                (sbyte)RandomExtensions.Next(
                    ref randomProvider,
                    MinValue,
                    MaxValue);
        }

        /// <summary>
        /// Represents a default RNG range for type Int8 returning
        /// specified value intervals for type Int8 (in analogy to calling
        /// the appropriate NextXYZ method on the random provider given using min and
        /// max values).
        /// </summary>
        /// <typeparam name="TRandomProvider">The underlying random provider.</typeparam>
        public struct RandomRangeInt8Provider<TRandomProvider> :
            IRandomRangeProvider<
                RandomRangeInt8Provider<TRandomProvider>,
                sbyte>
            where TRandomProvider : struct, IRandomProvider<TRandomProvider>
        {
            private TRandomProvider randomProvider;

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The RNG instance to use.</param>
            /// <param name="minValue">The minimum value (inclusive).</param>
            /// <param name="maxValue">The maximum value (exclusive).</param>
            public RandomRangeInt8Provider(
                TRandomProvider random,
                sbyte minValue,
                sbyte maxValue)
            {
                randomProvider = random;
                MinValue = minValue;
                MaxValue = maxValue;
            }

            /// <summary>
            /// Returns the min value of this range (inclusive).
            /// </summary>
            public sbyte MinValue { get; }

            /// <summary>
            /// Returns the max value of this range (exclusive).
            /// </summary>
            public sbyte MaxValue { get; }

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            /// <param name="minValue">The minimum value (inclusive).</param>
            /// <param name="maxValue">The maximum value (exclusive).</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static RandomRangeInt8Provider<TRandomProvider>
                Create(
                System.Random random,
                sbyte minValue,
                sbyte maxValue) =>
                new(default(TRandomProvider).CreateProvider(random), minValue, maxValue);

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            /// <param name="minValue">The minimum value (inclusive).</param>
            /// <param name="maxValue">The maximum value (exclusive).</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static RandomRangeInt8Provider<TRandomProvider>
                Create<TOtherProvider>(
                ref TOtherProvider random,
                sbyte minValue,
                sbyte maxValue)
                where TOtherProvider : struct, IRandomProvider<TOtherProvider> =>
                new(
                    default(TRandomProvider).CreateProvider(ref random),
                    minValue,
                    maxValue);

            /// <summary>
            /// Creates a new random range vector provider compatible with this provider.
            /// </summary>
            public readonly RandomRangeVectorProvider<
                sbyte,
                RandomRangeInt8Provider<TRandomProvider>> CreateVectorProvider() =>
                new(this);

            /// <summary>
            /// Generates a new random value using the given min and max values.
            /// </summary>
            [SuppressMessage(
                "Naming",
                "CA1716:Identifiers should not match keywords",
                Justification = "Like the method System.Random.Next()")]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public sbyte Next() =>
                (sbyte)RandomExtensions.Next(
                    ref randomProvider,
                    MinValue,
                    MaxValue);
        }

        /// <summary>
        /// Represents a default RNG range for type Int16 returning
        /// specified value intervals for type Int16 (in analogy to calling
        /// the appropriate NextXYZ method on the random provider given using min and
        /// max values).
        /// </summary>
        /// <param name="MinValue">The minimum value (inclusive).</param>
        /// <param name="MaxValue">The maximum values (exclusive).</param>
        public readonly record struct RandomRangeInt16(
            short MinValue,
            short MaxValue) :
            IRandomRange<short>
        {
            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RandomRangeInt16Provider<TRandomProvider>
                CreateProvider<TRandomProvider>(System.Random random)
                where TRandomProvider : struct, IRandomProvider<TRandomProvider> =>
                RandomRangeInt16Provider<TRandomProvider>.Create(
                    random,
                    MinValue,
                    MaxValue);

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RandomRangeInt16Provider<TRandomProvider>
                CreateProvider<TRandomProvider>(ref TRandomProvider random)
                where TRandomProvider : struct, IRandomProvider<TRandomProvider> =>
                RandomRangeInt16Provider<TRandomProvider>.Create(
                    ref random,
                    MinValue,
                    MaxValue);

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RandomRangeInt16Provider<TRandomProvider>
                CreateProvider<TRandomProvider, TOtherRandomProvider>(
                ref TOtherRandomProvider random)
                where TRandomProvider : struct, IRandomProvider<TRandomProvider>
                where TOtherRandomProvider :
                    struct, IRandomProvider<TOtherRandomProvider> =>
                RandomRangeInt16Provider<TRandomProvider>.Create(
                    ref random,
                    MinValue,
                    MaxValue);

            /// <summary>
            /// Generates a new random value using the given min and max values.
            /// </summary>
            [SuppressMessage(
                "Naming",
                "CA1716:Identifiers should not match keywords",
                Justification = "Like the method System.Random.Next()")]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public short Next<TRandomProvider>(
                ref TRandomProvider randomProvider)
                where TRandomProvider : struct, IRandomProvider =>
                (short)RandomExtensions.Next(
                    ref randomProvider,
                    MinValue,
                    MaxValue);
        }

        /// <summary>
        /// Represents a default RNG range for type Int16 returning
        /// specified value intervals for type Int16 (in analogy to calling
        /// the appropriate NextXYZ method on the random provider given using min and
        /// max values).
        /// </summary>
        /// <typeparam name="TRandomProvider">The underlying random provider.</typeparam>
        public struct RandomRangeInt16Provider<TRandomProvider> :
            IRandomRangeProvider<
                RandomRangeInt16Provider<TRandomProvider>,
                short>
            where TRandomProvider : struct, IRandomProvider<TRandomProvider>
        {
            private TRandomProvider randomProvider;

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The RNG instance to use.</param>
            /// <param name="minValue">The minimum value (inclusive).</param>
            /// <param name="maxValue">The maximum value (exclusive).</param>
            public RandomRangeInt16Provider(
                TRandomProvider random,
                short minValue,
                short maxValue)
            {
                randomProvider = random;
                MinValue = minValue;
                MaxValue = maxValue;
            }

            /// <summary>
            /// Returns the min value of this range (inclusive).
            /// </summary>
            public short MinValue { get; }

            /// <summary>
            /// Returns the max value of this range (exclusive).
            /// </summary>
            public short MaxValue { get; }

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            /// <param name="minValue">The minimum value (inclusive).</param>
            /// <param name="maxValue">The maximum value (exclusive).</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static RandomRangeInt16Provider<TRandomProvider>
                Create(
                System.Random random,
                short minValue,
                short maxValue) =>
                new(default(TRandomProvider).CreateProvider(random), minValue, maxValue);

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            /// <param name="minValue">The minimum value (inclusive).</param>
            /// <param name="maxValue">The maximum value (exclusive).</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static RandomRangeInt16Provider<TRandomProvider>
                Create<TOtherProvider>(
                ref TOtherProvider random,
                short minValue,
                short maxValue)
                where TOtherProvider : struct, IRandomProvider<TOtherProvider> =>
                new(
                    default(TRandomProvider).CreateProvider(ref random),
                    minValue,
                    maxValue);

            /// <summary>
            /// Creates a new random range vector provider compatible with this provider.
            /// </summary>
            public readonly RandomRangeVectorProvider<
                short,
                RandomRangeInt16Provider<TRandomProvider>> CreateVectorProvider() =>
                new(this);

            /// <summary>
            /// Generates a new random value using the given min and max values.
            /// </summary>
            [SuppressMessage(
                "Naming",
                "CA1716:Identifiers should not match keywords",
                Justification = "Like the method System.Random.Next()")]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public short Next() =>
                (short)RandomExtensions.Next(
                    ref randomProvider,
                    MinValue,
                    MaxValue);
        }

        /// <summary>
        /// Represents a default RNG range for type Int32 returning
        /// specified value intervals for type Int32 (in analogy to calling
        /// the appropriate NextXYZ method on the random provider given using min and
        /// max values).
        /// </summary>
        /// <param name="MinValue">The minimum value (inclusive).</param>
        /// <param name="MaxValue">The maximum values (exclusive).</param>
        public readonly record struct RandomRangeInt32(
            int MinValue,
            int MaxValue) :
            IRandomRange<int>
        {
            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RandomRangeInt32Provider<TRandomProvider>
                CreateProvider<TRandomProvider>(System.Random random)
                where TRandomProvider : struct, IRandomProvider<TRandomProvider> =>
                RandomRangeInt32Provider<TRandomProvider>.Create(
                    random,
                    MinValue,
                    MaxValue);

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RandomRangeInt32Provider<TRandomProvider>
                CreateProvider<TRandomProvider>(ref TRandomProvider random)
                where TRandomProvider : struct, IRandomProvider<TRandomProvider> =>
                RandomRangeInt32Provider<TRandomProvider>.Create(
                    ref random,
                    MinValue,
                    MaxValue);

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RandomRangeInt32Provider<TRandomProvider>
                CreateProvider<TRandomProvider, TOtherRandomProvider>(
                ref TOtherRandomProvider random)
                where TRandomProvider : struct, IRandomProvider<TRandomProvider>
                where TOtherRandomProvider :
                    struct, IRandomProvider<TOtherRandomProvider> =>
                RandomRangeInt32Provider<TRandomProvider>.Create(
                    ref random,
                    MinValue,
                    MaxValue);

            /// <summary>
            /// Generates a new random value using the given min and max values.
            /// </summary>
            [SuppressMessage(
                "Naming",
                "CA1716:Identifiers should not match keywords",
                Justification = "Like the method System.Random.Next()")]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int Next<TRandomProvider>(
                ref TRandomProvider randomProvider)
                where TRandomProvider : struct, IRandomProvider =>
                (int)RandomExtensions.Next(
                    ref randomProvider,
                    MinValue,
                    MaxValue);
        }

        /// <summary>
        /// Represents a default RNG range for type Int32 returning
        /// specified value intervals for type Int32 (in analogy to calling
        /// the appropriate NextXYZ method on the random provider given using min and
        /// max values).
        /// </summary>
        /// <typeparam name="TRandomProvider">The underlying random provider.</typeparam>
        public struct RandomRangeInt32Provider<TRandomProvider> :
            IRandomRangeProvider<
                RandomRangeInt32Provider<TRandomProvider>,
                int>
            where TRandomProvider : struct, IRandomProvider<TRandomProvider>
        {
            private TRandomProvider randomProvider;

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The RNG instance to use.</param>
            /// <param name="minValue">The minimum value (inclusive).</param>
            /// <param name="maxValue">The maximum value (exclusive).</param>
            public RandomRangeInt32Provider(
                TRandomProvider random,
                int minValue,
                int maxValue)
            {
                randomProvider = random;
                MinValue = minValue;
                MaxValue = maxValue;
            }

            /// <summary>
            /// Returns the min value of this range (inclusive).
            /// </summary>
            public int MinValue { get; }

            /// <summary>
            /// Returns the max value of this range (exclusive).
            /// </summary>
            public int MaxValue { get; }

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            /// <param name="minValue">The minimum value (inclusive).</param>
            /// <param name="maxValue">The maximum value (exclusive).</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static RandomRangeInt32Provider<TRandomProvider>
                Create(
                System.Random random,
                int minValue,
                int maxValue) =>
                new(default(TRandomProvider).CreateProvider(random), minValue, maxValue);

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            /// <param name="minValue">The minimum value (inclusive).</param>
            /// <param name="maxValue">The maximum value (exclusive).</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static RandomRangeInt32Provider<TRandomProvider>
                Create<TOtherProvider>(
                ref TOtherProvider random,
                int minValue,
                int maxValue)
                where TOtherProvider : struct, IRandomProvider<TOtherProvider> =>
                new(
                    default(TRandomProvider).CreateProvider(ref random),
                    minValue,
                    maxValue);

            /// <summary>
            /// Creates a new random range vector provider compatible with this provider.
            /// </summary>
            public readonly RandomRangeVectorProvider<
                int,
                RandomRangeInt32Provider<TRandomProvider>> CreateVectorProvider() =>
                new(this);

            /// <summary>
            /// Generates a new random value using the given min and max values.
            /// </summary>
            [SuppressMessage(
                "Naming",
                "CA1716:Identifiers should not match keywords",
                Justification = "Like the method System.Random.Next()")]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int Next() =>
                (int)RandomExtensions.Next(
                    ref randomProvider,
                    MinValue,
                    MaxValue);
        }

        /// <summary>
        /// Represents a default RNG range for type Int64 returning
        /// specified value intervals for type Int64 (in analogy to calling
        /// the appropriate NextXYZ method on the random provider given using min and
        /// max values).
        /// </summary>
        /// <param name="MinValue">The minimum value (inclusive).</param>
        /// <param name="MaxValue">The maximum values (exclusive).</param>
        public readonly record struct RandomRangeInt64(
            long MinValue,
            long MaxValue) :
            IRandomRange<long>
        {
            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RandomRangeInt64Provider<TRandomProvider>
                CreateProvider<TRandomProvider>(System.Random random)
                where TRandomProvider : struct, IRandomProvider<TRandomProvider> =>
                RandomRangeInt64Provider<TRandomProvider>.Create(
                    random,
                    MinValue,
                    MaxValue);

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RandomRangeInt64Provider<TRandomProvider>
                CreateProvider<TRandomProvider>(ref TRandomProvider random)
                where TRandomProvider : struct, IRandomProvider<TRandomProvider> =>
                RandomRangeInt64Provider<TRandomProvider>.Create(
                    ref random,
                    MinValue,
                    MaxValue);

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RandomRangeInt64Provider<TRandomProvider>
                CreateProvider<TRandomProvider, TOtherRandomProvider>(
                ref TOtherRandomProvider random)
                where TRandomProvider : struct, IRandomProvider<TRandomProvider>
                where TOtherRandomProvider :
                    struct, IRandomProvider<TOtherRandomProvider> =>
                RandomRangeInt64Provider<TRandomProvider>.Create(
                    ref random,
                    MinValue,
                    MaxValue);

            /// <summary>
            /// Generates a new random value using the given min and max values.
            /// </summary>
            [SuppressMessage(
                "Naming",
                "CA1716:Identifiers should not match keywords",
                Justification = "Like the method System.Random.Next()")]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public long Next<TRandomProvider>(
                ref TRandomProvider randomProvider)
                where TRandomProvider : struct, IRandomProvider =>
                (long)RandomExtensions.Next(
                    ref randomProvider,
                    MinValue,
                    MaxValue);
        }

        /// <summary>
        /// Represents a default RNG range for type Int64 returning
        /// specified value intervals for type Int64 (in analogy to calling
        /// the appropriate NextXYZ method on the random provider given using min and
        /// max values).
        /// </summary>
        /// <typeparam name="TRandomProvider">The underlying random provider.</typeparam>
        public struct RandomRangeInt64Provider<TRandomProvider> :
            IRandomRangeProvider<
                RandomRangeInt64Provider<TRandomProvider>,
                long>
            where TRandomProvider : struct, IRandomProvider<TRandomProvider>
        {
            private TRandomProvider randomProvider;

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The RNG instance to use.</param>
            /// <param name="minValue">The minimum value (inclusive).</param>
            /// <param name="maxValue">The maximum value (exclusive).</param>
            public RandomRangeInt64Provider(
                TRandomProvider random,
                long minValue,
                long maxValue)
            {
                randomProvider = random;
                MinValue = minValue;
                MaxValue = maxValue;
            }

            /// <summary>
            /// Returns the min value of this range (inclusive).
            /// </summary>
            public long MinValue { get; }

            /// <summary>
            /// Returns the max value of this range (exclusive).
            /// </summary>
            public long MaxValue { get; }

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            /// <param name="minValue">The minimum value (inclusive).</param>
            /// <param name="maxValue">The maximum value (exclusive).</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static RandomRangeInt64Provider<TRandomProvider>
                Create(
                System.Random random,
                long minValue,
                long maxValue) =>
                new(default(TRandomProvider).CreateProvider(random), minValue, maxValue);

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            /// <param name="minValue">The minimum value (inclusive).</param>
            /// <param name="maxValue">The maximum value (exclusive).</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static RandomRangeInt64Provider<TRandomProvider>
                Create<TOtherProvider>(
                ref TOtherProvider random,
                long minValue,
                long maxValue)
                where TOtherProvider : struct, IRandomProvider<TOtherProvider> =>
                new(
                    default(TRandomProvider).CreateProvider(ref random),
                    minValue,
                    maxValue);

            /// <summary>
            /// Creates a new random range vector provider compatible with this provider.
            /// </summary>
            public readonly RandomRangeVectorProvider<
                long,
                RandomRangeInt64Provider<TRandomProvider>> CreateVectorProvider() =>
                new(this);

            /// <summary>
            /// Generates a new random value using the given min and max values.
            /// </summary>
            [SuppressMessage(
                "Naming",
                "CA1716:Identifiers should not match keywords",
                Justification = "Like the method System.Random.Next()")]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public long Next() =>
                (long)RandomExtensions.Next(
                    ref randomProvider,
                    MinValue,
                    MaxValue);
        }

        /// <summary>
        /// Represents a default RNG range for type Half returning
        /// specified value intervals for type Half (in analogy to calling
        /// the appropriate NextXYZ method on the random provider given using min and
        /// max values).
        /// </summary>
        /// <param name="MinValue">The minimum value (inclusive).</param>
        /// <param name="MaxValue">The maximum values (exclusive).</param>
        public readonly record struct RandomRangeHalf(
            Half MinValue,
            Half MaxValue) :
            IRandomRange<Half>
        {
            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RandomRangeHalfProvider<TRandomProvider>
                CreateProvider<TRandomProvider>(System.Random random)
                where TRandomProvider : struct, IRandomProvider<TRandomProvider> =>
                RandomRangeHalfProvider<TRandomProvider>.Create(
                    random,
                    MinValue,
                    MaxValue);

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RandomRangeHalfProvider<TRandomProvider>
                CreateProvider<TRandomProvider>(ref TRandomProvider random)
                where TRandomProvider : struct, IRandomProvider<TRandomProvider> =>
                RandomRangeHalfProvider<TRandomProvider>.Create(
                    ref random,
                    MinValue,
                    MaxValue);

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RandomRangeHalfProvider<TRandomProvider>
                CreateProvider<TRandomProvider, TOtherRandomProvider>(
                ref TOtherRandomProvider random)
                where TRandomProvider : struct, IRandomProvider<TRandomProvider>
                where TOtherRandomProvider :
                    struct, IRandomProvider<TOtherRandomProvider> =>
                RandomRangeHalfProvider<TRandomProvider>.Create(
                    ref random,
                    MinValue,
                    MaxValue);

            /// <summary>
            /// Generates a new random value using the given min and max values.
            /// </summary>
            [SuppressMessage(
                "Naming",
                "CA1716:Identifiers should not match keywords",
                Justification = "Like the method System.Random.Next()")]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Half Next<TRandomProvider>(
                ref TRandomProvider randomProvider)
                where TRandomProvider : struct, IRandomProvider =>
                (Half)RandomExtensions.Next(
                    ref randomProvider,
                    MinValue,
                    MaxValue);
        }

        /// <summary>
        /// Represents a default RNG range for type Half returning
        /// specified value intervals for type Half (in analogy to calling
        /// the appropriate NextXYZ method on the random provider given using min and
        /// max values).
        /// </summary>
        /// <typeparam name="TRandomProvider">The underlying random provider.</typeparam>
        public struct RandomRangeHalfProvider<TRandomProvider> :
            IRandomRangeProvider<
                RandomRangeHalfProvider<TRandomProvider>,
                Half>
            where TRandomProvider : struct, IRandomProvider<TRandomProvider>
        {
            private TRandomProvider randomProvider;

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The RNG instance to use.</param>
            /// <param name="minValue">The minimum value (inclusive).</param>
            /// <param name="maxValue">The maximum value (exclusive).</param>
            public RandomRangeHalfProvider(
                TRandomProvider random,
                Half minValue,
                Half maxValue)
            {
                randomProvider = random;
                MinValue = minValue;
                MaxValue = maxValue;
            }

            /// <summary>
            /// Returns the min value of this range (inclusive).
            /// </summary>
            public Half MinValue { get; }

            /// <summary>
            /// Returns the max value of this range (exclusive).
            /// </summary>
            public Half MaxValue { get; }

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            /// <param name="minValue">The minimum value (inclusive).</param>
            /// <param name="maxValue">The maximum value (exclusive).</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static RandomRangeHalfProvider<TRandomProvider>
                Create(
                System.Random random,
                Half minValue,
                Half maxValue) =>
                new(default(TRandomProvider).CreateProvider(random), minValue, maxValue);

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            /// <param name="minValue">The minimum value (inclusive).</param>
            /// <param name="maxValue">The maximum value (exclusive).</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static RandomRangeHalfProvider<TRandomProvider>
                Create<TOtherProvider>(
                ref TOtherProvider random,
                Half minValue,
                Half maxValue)
                where TOtherProvider : struct, IRandomProvider<TOtherProvider> =>
                new(
                    default(TRandomProvider).CreateProvider(ref random),
                    minValue,
                    maxValue);

            /// <summary>
            /// Creates a new random range vector provider compatible with this provider.
            /// </summary>
            public readonly RandomRangeVectorProvider<
                Half,
                RandomRangeHalfProvider<TRandomProvider>> CreateVectorProvider() =>
                new(this);

            /// <summary>
            /// Generates a new random value using the given min and max values.
            /// </summary>
            [SuppressMessage(
                "Naming",
                "CA1716:Identifiers should not match keywords",
                Justification = "Like the method System.Random.Next()")]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Half Next() =>
                (Half)RandomExtensions.Next(
                    ref randomProvider,
                    MinValue,
                    MaxValue);
        }

        /// <summary>
        /// Represents a default RNG range for type Float returning
        /// specified value intervals for type Float (in analogy to calling
        /// the appropriate NextXYZ method on the random provider given using min and
        /// max values).
        /// </summary>
        /// <param name="MinValue">The minimum value (inclusive).</param>
        /// <param name="MaxValue">The maximum values (exclusive).</param>
        public readonly record struct RandomRangeFloat(
            float MinValue,
            float MaxValue) :
            IRandomRange<float>
        {
            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RandomRangeFloatProvider<TRandomProvider>
                CreateProvider<TRandomProvider>(System.Random random)
                where TRandomProvider : struct, IRandomProvider<TRandomProvider> =>
                RandomRangeFloatProvider<TRandomProvider>.Create(
                    random,
                    MinValue,
                    MaxValue);

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RandomRangeFloatProvider<TRandomProvider>
                CreateProvider<TRandomProvider>(ref TRandomProvider random)
                where TRandomProvider : struct, IRandomProvider<TRandomProvider> =>
                RandomRangeFloatProvider<TRandomProvider>.Create(
                    ref random,
                    MinValue,
                    MaxValue);

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RandomRangeFloatProvider<TRandomProvider>
                CreateProvider<TRandomProvider, TOtherRandomProvider>(
                ref TOtherRandomProvider random)
                where TRandomProvider : struct, IRandomProvider<TRandomProvider>
                where TOtherRandomProvider :
                    struct, IRandomProvider<TOtherRandomProvider> =>
                RandomRangeFloatProvider<TRandomProvider>.Create(
                    ref random,
                    MinValue,
                    MaxValue);

            /// <summary>
            /// Generates a new random value using the given min and max values.
            /// </summary>
            [SuppressMessage(
                "Naming",
                "CA1716:Identifiers should not match keywords",
                Justification = "Like the method System.Random.Next()")]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public float Next<TRandomProvider>(
                ref TRandomProvider randomProvider)
                where TRandomProvider : struct, IRandomProvider =>
                (float)RandomExtensions.Next(
                    ref randomProvider,
                    MinValue,
                    MaxValue);
        }

        /// <summary>
        /// Represents a default RNG range for type Float returning
        /// specified value intervals for type Float (in analogy to calling
        /// the appropriate NextXYZ method on the random provider given using min and
        /// max values).
        /// </summary>
        /// <typeparam name="TRandomProvider">The underlying random provider.</typeparam>
        public struct RandomRangeFloatProvider<TRandomProvider> :
            IRandomRangeProvider<
                RandomRangeFloatProvider<TRandomProvider>,
                float>
            where TRandomProvider : struct, IRandomProvider<TRandomProvider>
        {
            private TRandomProvider randomProvider;

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The RNG instance to use.</param>
            /// <param name="minValue">The minimum value (inclusive).</param>
            /// <param name="maxValue">The maximum value (exclusive).</param>
            public RandomRangeFloatProvider(
                TRandomProvider random,
                float minValue,
                float maxValue)
            {
                randomProvider = random;
                MinValue = minValue;
                MaxValue = maxValue;
            }

            /// <summary>
            /// Returns the min value of this range (inclusive).
            /// </summary>
            public float MinValue { get; }

            /// <summary>
            /// Returns the max value of this range (exclusive).
            /// </summary>
            public float MaxValue { get; }

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            /// <param name="minValue">The minimum value (inclusive).</param>
            /// <param name="maxValue">The maximum value (exclusive).</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static RandomRangeFloatProvider<TRandomProvider>
                Create(
                System.Random random,
                float minValue,
                float maxValue) =>
                new(default(TRandomProvider).CreateProvider(random), minValue, maxValue);

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            /// <param name="minValue">The minimum value (inclusive).</param>
            /// <param name="maxValue">The maximum value (exclusive).</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static RandomRangeFloatProvider<TRandomProvider>
                Create<TOtherProvider>(
                ref TOtherProvider random,
                float minValue,
                float maxValue)
                where TOtherProvider : struct, IRandomProvider<TOtherProvider> =>
                new(
                    default(TRandomProvider).CreateProvider(ref random),
                    minValue,
                    maxValue);

            /// <summary>
            /// Creates a new random range vector provider compatible with this provider.
            /// </summary>
            public readonly RandomRangeVectorProvider<
                float,
                RandomRangeFloatProvider<TRandomProvider>> CreateVectorProvider() =>
                new(this);

            /// <summary>
            /// Generates a new random value using the given min and max values.
            /// </summary>
            [SuppressMessage(
                "Naming",
                "CA1716:Identifiers should not match keywords",
                Justification = "Like the method System.Random.Next()")]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public float Next() =>
                (float)RandomExtensions.Next(
                    ref randomProvider,
                    MinValue,
                    MaxValue);
        }

        /// <summary>
        /// Represents a default RNG range for type Double returning
        /// specified value intervals for type Double (in analogy to calling
        /// the appropriate NextXYZ method on the random provider given using min and
        /// max values).
        /// </summary>
        /// <param name="MinValue">The minimum value (inclusive).</param>
        /// <param name="MaxValue">The maximum values (exclusive).</param>
        public readonly record struct RandomRangeDouble(
            double MinValue,
            double MaxValue) :
            IRandomRange<double>
        {
            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RandomRangeDoubleProvider<TRandomProvider>
                CreateProvider<TRandomProvider>(System.Random random)
                where TRandomProvider : struct, IRandomProvider<TRandomProvider> =>
                RandomRangeDoubleProvider<TRandomProvider>.Create(
                    random,
                    MinValue,
                    MaxValue);

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RandomRangeDoubleProvider<TRandomProvider>
                CreateProvider<TRandomProvider>(ref TRandomProvider random)
                where TRandomProvider : struct, IRandomProvider<TRandomProvider> =>
                RandomRangeDoubleProvider<TRandomProvider>.Create(
                    ref random,
                    MinValue,
                    MaxValue);

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RandomRangeDoubleProvider<TRandomProvider>
                CreateProvider<TRandomProvider, TOtherRandomProvider>(
                ref TOtherRandomProvider random)
                where TRandomProvider : struct, IRandomProvider<TRandomProvider>
                where TOtherRandomProvider :
                    struct, IRandomProvider<TOtherRandomProvider> =>
                RandomRangeDoubleProvider<TRandomProvider>.Create(
                    ref random,
                    MinValue,
                    MaxValue);

            /// <summary>
            /// Generates a new random value using the given min and max values.
            /// </summary>
            [SuppressMessage(
                "Naming",
                "CA1716:Identifiers should not match keywords",
                Justification = "Like the method System.Random.Next()")]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public double Next<TRandomProvider>(
                ref TRandomProvider randomProvider)
                where TRandomProvider : struct, IRandomProvider =>
                (double)RandomExtensions.Next(
                    ref randomProvider,
                    MinValue,
                    MaxValue);
        }

        /// <summary>
        /// Represents a default RNG range for type Double returning
        /// specified value intervals for type Double (in analogy to calling
        /// the appropriate NextXYZ method on the random provider given using min and
        /// max values).
        /// </summary>
        /// <typeparam name="TRandomProvider">The underlying random provider.</typeparam>
        public struct RandomRangeDoubleProvider<TRandomProvider> :
            IRandomRangeProvider<
                RandomRangeDoubleProvider<TRandomProvider>,
                double>
            where TRandomProvider : struct, IRandomProvider<TRandomProvider>
        {
            private TRandomProvider randomProvider;

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The RNG instance to use.</param>
            /// <param name="minValue">The minimum value (inclusive).</param>
            /// <param name="maxValue">The maximum value (exclusive).</param>
            public RandomRangeDoubleProvider(
                TRandomProvider random,
                double minValue,
                double maxValue)
            {
                randomProvider = random;
                MinValue = minValue;
                MaxValue = maxValue;
            }

            /// <summary>
            /// Returns the min value of this range (inclusive).
            /// </summary>
            public double MinValue { get; }

            /// <summary>
            /// Returns the max value of this range (exclusive).
            /// </summary>
            public double MaxValue { get; }

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            /// <param name="minValue">The minimum value (inclusive).</param>
            /// <param name="maxValue">The maximum value (exclusive).</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static RandomRangeDoubleProvider<TRandomProvider>
                Create(
                System.Random random,
                double minValue,
                double maxValue) =>
                new(default(TRandomProvider).CreateProvider(random), minValue, maxValue);

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            /// <param name="minValue">The minimum value (inclusive).</param>
            /// <param name="maxValue">The maximum value (exclusive).</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static RandomRangeDoubleProvider<TRandomProvider>
                Create<TOtherProvider>(
                ref TOtherProvider random,
                double minValue,
                double maxValue)
                where TOtherProvider : struct, IRandomProvider<TOtherProvider> =>
                new(
                    default(TRandomProvider).CreateProvider(ref random),
                    minValue,
                    maxValue);

            /// <summary>
            /// Creates a new random range vector provider compatible with this provider.
            /// </summary>
            public readonly RandomRangeVectorProvider<
                double,
                RandomRangeDoubleProvider<TRandomProvider>> CreateVectorProvider() =>
                new(this);

            /// <summary>
            /// Generates a new random value using the given min and max values.
            /// </summary>
            [SuppressMessage(
                "Naming",
                "CA1716:Identifiers should not match keywords",
                Justification = "Like the method System.Random.Next()")]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public double Next() =>
                (double)RandomExtensions.Next(
                    ref randomProvider,
                    MinValue,
                    MaxValue);
        }

        /// <summary>
        /// Represents a default RNG range for type FixedInt2DP returning
        /// specified value intervals for type FixedInt2DP (in analogy to calling
        /// the appropriate NextXYZ method on the random provider given using min and
        /// max values).
        /// </summary>
        /// <param name="MinValue">The minimum value (inclusive).</param>
        /// <param name="MaxValue">The maximum values (exclusive).</param>
        public readonly record struct RandomRangeFixedInt2DP(
            FixedInt2DP MinValue,
            FixedInt2DP MaxValue) :
            IRandomRange<FixedInt2DP>
        {
            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RandomRangeFixedInt2DPProvider<TRandomProvider>
                CreateProvider<TRandomProvider>(System.Random random)
                where TRandomProvider : struct, IRandomProvider<TRandomProvider> =>
                RandomRangeFixedInt2DPProvider<TRandomProvider>.Create(
                    random,
                    MinValue,
                    MaxValue);

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RandomRangeFixedInt2DPProvider<TRandomProvider>
                CreateProvider<TRandomProvider>(ref TRandomProvider random)
                where TRandomProvider : struct, IRandomProvider<TRandomProvider> =>
                RandomRangeFixedInt2DPProvider<TRandomProvider>.Create(
                    ref random,
                    MinValue,
                    MaxValue);

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RandomRangeFixedInt2DPProvider<TRandomProvider>
                CreateProvider<TRandomProvider, TOtherRandomProvider>(
                ref TOtherRandomProvider random)
                where TRandomProvider : struct, IRandomProvider<TRandomProvider>
                where TOtherRandomProvider :
                    struct, IRandomProvider<TOtherRandomProvider> =>
                RandomRangeFixedInt2DPProvider<TRandomProvider>.Create(
                    ref random,
                    MinValue,
                    MaxValue);

            /// <summary>
            /// Generates a new random value using the given min and max values.
            /// </summary>
            [SuppressMessage(
                "Naming",
                "CA1716:Identifiers should not match keywords",
                Justification = "Like the method System.Random.Next()")]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public FixedInt2DP Next<TRandomProvider>(
                ref TRandomProvider randomProvider)
                where TRandomProvider : struct, IRandomProvider =>
                (FixedInt2DP)RandomExtensions.Next(
                    ref randomProvider,
                    MinValue,
                    MaxValue);
        }

        /// <summary>
        /// Represents a default RNG range for type FixedInt2DP returning
        /// specified value intervals for type FixedInt2DP (in analogy to calling
        /// the appropriate NextXYZ method on the random provider given using min and
        /// max values).
        /// </summary>
        /// <typeparam name="TRandomProvider">The underlying random provider.</typeparam>
        public struct RandomRangeFixedInt2DPProvider<TRandomProvider> :
            IRandomRangeProvider<
                RandomRangeFixedInt2DPProvider<TRandomProvider>,
                FixedInt2DP>
            where TRandomProvider : struct, IRandomProvider<TRandomProvider>
        {
            private TRandomProvider randomProvider;

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The RNG instance to use.</param>
            /// <param name="minValue">The minimum value (inclusive).</param>
            /// <param name="maxValue">The maximum value (exclusive).</param>
            public RandomRangeFixedInt2DPProvider(
                TRandomProvider random,
                FixedInt2DP minValue,
                FixedInt2DP maxValue)
            {
                randomProvider = random;
                MinValue = minValue;
                MaxValue = maxValue;
            }

            /// <summary>
            /// Returns the min value of this range (inclusive).
            /// </summary>
            public FixedInt2DP MinValue { get; }

            /// <summary>
            /// Returns the max value of this range (exclusive).
            /// </summary>
            public FixedInt2DP MaxValue { get; }

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            /// <param name="minValue">The minimum value (inclusive).</param>
            /// <param name="maxValue">The maximum value (exclusive).</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static RandomRangeFixedInt2DPProvider<TRandomProvider>
                Create(
                System.Random random,
                FixedInt2DP minValue,
                FixedInt2DP maxValue) =>
                new(default(TRandomProvider).CreateProvider(random), minValue, maxValue);

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            /// <param name="minValue">The minimum value (inclusive).</param>
            /// <param name="maxValue">The maximum value (exclusive).</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static RandomRangeFixedInt2DPProvider<TRandomProvider>
                Create<TOtherProvider>(
                ref TOtherProvider random,
                FixedInt2DP minValue,
                FixedInt2DP maxValue)
                where TOtherProvider : struct, IRandomProvider<TOtherProvider> =>
                new(
                    default(TRandomProvider).CreateProvider(ref random),
                    minValue,
                    maxValue);

            /// <summary>
            /// Creates a new random range vector provider compatible with this provider.
            /// </summary>
            public readonly RandomRangeVectorProvider<
                FixedInt2DP,
                RandomRangeFixedInt2DPProvider<TRandomProvider>> CreateVectorProvider() =>
                new(this);

            /// <summary>
            /// Generates a new random value using the given min and max values.
            /// </summary>
            [SuppressMessage(
                "Naming",
                "CA1716:Identifiers should not match keywords",
                Justification = "Like the method System.Random.Next()")]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public FixedInt2DP Next() =>
                (FixedInt2DP)RandomExtensions.Next(
                    ref randomProvider,
                    MinValue,
                    MaxValue);
        }

        /// <summary>
        /// Represents a default RNG range for type FixedInt4DP returning
        /// specified value intervals for type FixedInt4DP (in analogy to calling
        /// the appropriate NextXYZ method on the random provider given using min and
        /// max values).
        /// </summary>
        /// <param name="MinValue">The minimum value (inclusive).</param>
        /// <param name="MaxValue">The maximum values (exclusive).</param>
        public readonly record struct RandomRangeFixedInt4DP(
            FixedInt4DP MinValue,
            FixedInt4DP MaxValue) :
            IRandomRange<FixedInt4DP>
        {
            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RandomRangeFixedInt4DPProvider<TRandomProvider>
                CreateProvider<TRandomProvider>(System.Random random)
                where TRandomProvider : struct, IRandomProvider<TRandomProvider> =>
                RandomRangeFixedInt4DPProvider<TRandomProvider>.Create(
                    random,
                    MinValue,
                    MaxValue);

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RandomRangeFixedInt4DPProvider<TRandomProvider>
                CreateProvider<TRandomProvider>(ref TRandomProvider random)
                where TRandomProvider : struct, IRandomProvider<TRandomProvider> =>
                RandomRangeFixedInt4DPProvider<TRandomProvider>.Create(
                    ref random,
                    MinValue,
                    MaxValue);

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RandomRangeFixedInt4DPProvider<TRandomProvider>
                CreateProvider<TRandomProvider, TOtherRandomProvider>(
                ref TOtherRandomProvider random)
                where TRandomProvider : struct, IRandomProvider<TRandomProvider>
                where TOtherRandomProvider :
                    struct, IRandomProvider<TOtherRandomProvider> =>
                RandomRangeFixedInt4DPProvider<TRandomProvider>.Create(
                    ref random,
                    MinValue,
                    MaxValue);

            /// <summary>
            /// Generates a new random value using the given min and max values.
            /// </summary>
            [SuppressMessage(
                "Naming",
                "CA1716:Identifiers should not match keywords",
                Justification = "Like the method System.Random.Next()")]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public FixedInt4DP Next<TRandomProvider>(
                ref TRandomProvider randomProvider)
                where TRandomProvider : struct, IRandomProvider =>
                (FixedInt4DP)RandomExtensions.Next(
                    ref randomProvider,
                    MinValue,
                    MaxValue);
        }

        /// <summary>
        /// Represents a default RNG range for type FixedInt4DP returning
        /// specified value intervals for type FixedInt4DP (in analogy to calling
        /// the appropriate NextXYZ method on the random provider given using min and
        /// max values).
        /// </summary>
        /// <typeparam name="TRandomProvider">The underlying random provider.</typeparam>
        public struct RandomRangeFixedInt4DPProvider<TRandomProvider> :
            IRandomRangeProvider<
                RandomRangeFixedInt4DPProvider<TRandomProvider>,
                FixedInt4DP>
            where TRandomProvider : struct, IRandomProvider<TRandomProvider>
        {
            private TRandomProvider randomProvider;

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The RNG instance to use.</param>
            /// <param name="minValue">The minimum value (inclusive).</param>
            /// <param name="maxValue">The maximum value (exclusive).</param>
            public RandomRangeFixedInt4DPProvider(
                TRandomProvider random,
                FixedInt4DP minValue,
                FixedInt4DP maxValue)
            {
                randomProvider = random;
                MinValue = minValue;
                MaxValue = maxValue;
            }

            /// <summary>
            /// Returns the min value of this range (inclusive).
            /// </summary>
            public FixedInt4DP MinValue { get; }

            /// <summary>
            /// Returns the max value of this range (exclusive).
            /// </summary>
            public FixedInt4DP MaxValue { get; }

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            /// <param name="minValue">The minimum value (inclusive).</param>
            /// <param name="maxValue">The maximum value (exclusive).</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static RandomRangeFixedInt4DPProvider<TRandomProvider>
                Create(
                System.Random random,
                FixedInt4DP minValue,
                FixedInt4DP maxValue) =>
                new(default(TRandomProvider).CreateProvider(random), minValue, maxValue);

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            /// <param name="minValue">The minimum value (inclusive).</param>
            /// <param name="maxValue">The maximum value (exclusive).</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static RandomRangeFixedInt4DPProvider<TRandomProvider>
                Create<TOtherProvider>(
                ref TOtherProvider random,
                FixedInt4DP minValue,
                FixedInt4DP maxValue)
                where TOtherProvider : struct, IRandomProvider<TOtherProvider> =>
                new(
                    default(TRandomProvider).CreateProvider(ref random),
                    minValue,
                    maxValue);

            /// <summary>
            /// Creates a new random range vector provider compatible with this provider.
            /// </summary>
            public readonly RandomRangeVectorProvider<
                FixedInt4DP,
                RandomRangeFixedInt4DPProvider<TRandomProvider>> CreateVectorProvider() =>
                new(this);

            /// <summary>
            /// Generates a new random value using the given min and max values.
            /// </summary>
            [SuppressMessage(
                "Naming",
                "CA1716:Identifiers should not match keywords",
                Justification = "Like the method System.Random.Next()")]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public FixedInt4DP Next() =>
                (FixedInt4DP)RandomExtensions.Next(
                    ref randomProvider,
                    MinValue,
                    MaxValue);
        }

        /// <summary>
        /// Represents a default RNG range for type FixedInt6DP returning
        /// specified value intervals for type FixedInt6DP (in analogy to calling
        /// the appropriate NextXYZ method on the random provider given using min and
        /// max values).
        /// </summary>
        /// <param name="MinValue">The minimum value (inclusive).</param>
        /// <param name="MaxValue">The maximum values (exclusive).</param>
        public readonly record struct RandomRangeFixedInt6DP(
            FixedInt6DP MinValue,
            FixedInt6DP MaxValue) :
            IRandomRange<FixedInt6DP>
        {
            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RandomRangeFixedInt6DPProvider<TRandomProvider>
                CreateProvider<TRandomProvider>(System.Random random)
                where TRandomProvider : struct, IRandomProvider<TRandomProvider> =>
                RandomRangeFixedInt6DPProvider<TRandomProvider>.Create(
                    random,
                    MinValue,
                    MaxValue);

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RandomRangeFixedInt6DPProvider<TRandomProvider>
                CreateProvider<TRandomProvider>(ref TRandomProvider random)
                where TRandomProvider : struct, IRandomProvider<TRandomProvider> =>
                RandomRangeFixedInt6DPProvider<TRandomProvider>.Create(
                    ref random,
                    MinValue,
                    MaxValue);

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RandomRangeFixedInt6DPProvider<TRandomProvider>
                CreateProvider<TRandomProvider, TOtherRandomProvider>(
                ref TOtherRandomProvider random)
                where TRandomProvider : struct, IRandomProvider<TRandomProvider>
                where TOtherRandomProvider :
                    struct, IRandomProvider<TOtherRandomProvider> =>
                RandomRangeFixedInt6DPProvider<TRandomProvider>.Create(
                    ref random,
                    MinValue,
                    MaxValue);

            /// <summary>
            /// Generates a new random value using the given min and max values.
            /// </summary>
            [SuppressMessage(
                "Naming",
                "CA1716:Identifiers should not match keywords",
                Justification = "Like the method System.Random.Next()")]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public FixedInt6DP Next<TRandomProvider>(
                ref TRandomProvider randomProvider)
                where TRandomProvider : struct, IRandomProvider =>
                (FixedInt6DP)RandomExtensions.Next(
                    ref randomProvider,
                    MinValue,
                    MaxValue);
        }

        /// <summary>
        /// Represents a default RNG range for type FixedInt6DP returning
        /// specified value intervals for type FixedInt6DP (in analogy to calling
        /// the appropriate NextXYZ method on the random provider given using min and
        /// max values).
        /// </summary>
        /// <typeparam name="TRandomProvider">The underlying random provider.</typeparam>
        public struct RandomRangeFixedInt6DPProvider<TRandomProvider> :
            IRandomRangeProvider<
                RandomRangeFixedInt6DPProvider<TRandomProvider>,
                FixedInt6DP>
            where TRandomProvider : struct, IRandomProvider<TRandomProvider>
        {
            private TRandomProvider randomProvider;

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The RNG instance to use.</param>
            /// <param name="minValue">The minimum value (inclusive).</param>
            /// <param name="maxValue">The maximum value (exclusive).</param>
            public RandomRangeFixedInt6DPProvider(
                TRandomProvider random,
                FixedInt6DP minValue,
                FixedInt6DP maxValue)
            {
                randomProvider = random;
                MinValue = minValue;
                MaxValue = maxValue;
            }

            /// <summary>
            /// Returns the min value of this range (inclusive).
            /// </summary>
            public FixedInt6DP MinValue { get; }

            /// <summary>
            /// Returns the max value of this range (exclusive).
            /// </summary>
            public FixedInt6DP MaxValue { get; }

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            /// <param name="minValue">The minimum value (inclusive).</param>
            /// <param name="maxValue">The maximum value (exclusive).</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static RandomRangeFixedInt6DPProvider<TRandomProvider>
                Create(
                System.Random random,
                FixedInt6DP minValue,
                FixedInt6DP maxValue) =>
                new(default(TRandomProvider).CreateProvider(random), minValue, maxValue);

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            /// <param name="minValue">The minimum value (inclusive).</param>
            /// <param name="maxValue">The maximum value (exclusive).</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static RandomRangeFixedInt6DPProvider<TRandomProvider>
                Create<TOtherProvider>(
                ref TOtherProvider random,
                FixedInt6DP minValue,
                FixedInt6DP maxValue)
                where TOtherProvider : struct, IRandomProvider<TOtherProvider> =>
                new(
                    default(TRandomProvider).CreateProvider(ref random),
                    minValue,
                    maxValue);

            /// <summary>
            /// Creates a new random range vector provider compatible with this provider.
            /// </summary>
            public readonly RandomRangeVectorProvider<
                FixedInt6DP,
                RandomRangeFixedInt6DPProvider<TRandomProvider>> CreateVectorProvider() =>
                new(this);

            /// <summary>
            /// Generates a new random value using the given min and max values.
            /// </summary>
            [SuppressMessage(
                "Naming",
                "CA1716:Identifiers should not match keywords",
                Justification = "Like the method System.Random.Next()")]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public FixedInt6DP Next() =>
                (FixedInt6DP)RandomExtensions.Next(
                    ref randomProvider,
                    MinValue,
                    MaxValue);
        }

        /// <summary>
        /// Represents a default RNG range for type FixedLong2DP returning
        /// specified value intervals for type FixedLong2DP (in analogy to calling
        /// the appropriate NextXYZ method on the random provider given using min and
        /// max values).
        /// </summary>
        /// <param name="MinValue">The minimum value (inclusive).</param>
        /// <param name="MaxValue">The maximum values (exclusive).</param>
        public readonly record struct RandomRangeFixedLong2DP(
            FixedLong2DP MinValue,
            FixedLong2DP MaxValue) :
            IRandomRange<FixedLong2DP>
        {
            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RandomRangeFixedLong2DPProvider<TRandomProvider>
                CreateProvider<TRandomProvider>(System.Random random)
                where TRandomProvider : struct, IRandomProvider<TRandomProvider> =>
                RandomRangeFixedLong2DPProvider<TRandomProvider>.Create(
                    random,
                    MinValue,
                    MaxValue);

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RandomRangeFixedLong2DPProvider<TRandomProvider>
                CreateProvider<TRandomProvider>(ref TRandomProvider random)
                where TRandomProvider : struct, IRandomProvider<TRandomProvider> =>
                RandomRangeFixedLong2DPProvider<TRandomProvider>.Create(
                    ref random,
                    MinValue,
                    MaxValue);

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RandomRangeFixedLong2DPProvider<TRandomProvider>
                CreateProvider<TRandomProvider, TOtherRandomProvider>(
                ref TOtherRandomProvider random)
                where TRandomProvider : struct, IRandomProvider<TRandomProvider>
                where TOtherRandomProvider :
                    struct, IRandomProvider<TOtherRandomProvider> =>
                RandomRangeFixedLong2DPProvider<TRandomProvider>.Create(
                    ref random,
                    MinValue,
                    MaxValue);

            /// <summary>
            /// Generates a new random value using the given min and max values.
            /// </summary>
            [SuppressMessage(
                "Naming",
                "CA1716:Identifiers should not match keywords",
                Justification = "Like the method System.Random.Next()")]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public FixedLong2DP Next<TRandomProvider>(
                ref TRandomProvider randomProvider)
                where TRandomProvider : struct, IRandomProvider =>
                (FixedLong2DP)RandomExtensions.Next(
                    ref randomProvider,
                    MinValue,
                    MaxValue);
        }

        /// <summary>
        /// Represents a default RNG range for type FixedLong2DP returning
        /// specified value intervals for type FixedLong2DP (in analogy to calling
        /// the appropriate NextXYZ method on the random provider given using min and
        /// max values).
        /// </summary>
        /// <typeparam name="TRandomProvider">The underlying random provider.</typeparam>
        public struct RandomRangeFixedLong2DPProvider<TRandomProvider> :
            IRandomRangeProvider<
                RandomRangeFixedLong2DPProvider<TRandomProvider>,
                FixedLong2DP>
            where TRandomProvider : struct, IRandomProvider<TRandomProvider>
        {
            private TRandomProvider randomProvider;

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The RNG instance to use.</param>
            /// <param name="minValue">The minimum value (inclusive).</param>
            /// <param name="maxValue">The maximum value (exclusive).</param>
            public RandomRangeFixedLong2DPProvider(
                TRandomProvider random,
                FixedLong2DP minValue,
                FixedLong2DP maxValue)
            {
                randomProvider = random;
                MinValue = minValue;
                MaxValue = maxValue;
            }

            /// <summary>
            /// Returns the min value of this range (inclusive).
            /// </summary>
            public FixedLong2DP MinValue { get; }

            /// <summary>
            /// Returns the max value of this range (exclusive).
            /// </summary>
            public FixedLong2DP MaxValue { get; }

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            /// <param name="minValue">The minimum value (inclusive).</param>
            /// <param name="maxValue">The maximum value (exclusive).</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static RandomRangeFixedLong2DPProvider<TRandomProvider>
                Create(
                System.Random random,
                FixedLong2DP minValue,
                FixedLong2DP maxValue) =>
                new(default(TRandomProvider).CreateProvider(random), minValue, maxValue);

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            /// <param name="minValue">The minimum value (inclusive).</param>
            /// <param name="maxValue">The maximum value (exclusive).</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static RandomRangeFixedLong2DPProvider<TRandomProvider>
                Create<TOtherProvider>(
                ref TOtherProvider random,
                FixedLong2DP minValue,
                FixedLong2DP maxValue)
                where TOtherProvider : struct, IRandomProvider<TOtherProvider> =>
                new(
                    default(TRandomProvider).CreateProvider(ref random),
                    minValue,
                    maxValue);

            /// <summary>
            /// Creates a new random range vector provider compatible with this provider.
            /// </summary>
            public readonly RandomRangeVectorProvider<
                FixedLong2DP,
                RandomRangeFixedLong2DPProvider<TRandomProvider>> CreateVectorProvider() =>
                new(this);

            /// <summary>
            /// Generates a new random value using the given min and max values.
            /// </summary>
            [SuppressMessage(
                "Naming",
                "CA1716:Identifiers should not match keywords",
                Justification = "Like the method System.Random.Next()")]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public FixedLong2DP Next() =>
                (FixedLong2DP)RandomExtensions.Next(
                    ref randomProvider,
                    MinValue,
                    MaxValue);
        }

        /// <summary>
        /// Represents a default RNG range for type FixedLong4DP returning
        /// specified value intervals for type FixedLong4DP (in analogy to calling
        /// the appropriate NextXYZ method on the random provider given using min and
        /// max values).
        /// </summary>
        /// <param name="MinValue">The minimum value (inclusive).</param>
        /// <param name="MaxValue">The maximum values (exclusive).</param>
        public readonly record struct RandomRangeFixedLong4DP(
            FixedLong4DP MinValue,
            FixedLong4DP MaxValue) :
            IRandomRange<FixedLong4DP>
        {
            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RandomRangeFixedLong4DPProvider<TRandomProvider>
                CreateProvider<TRandomProvider>(System.Random random)
                where TRandomProvider : struct, IRandomProvider<TRandomProvider> =>
                RandomRangeFixedLong4DPProvider<TRandomProvider>.Create(
                    random,
                    MinValue,
                    MaxValue);

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RandomRangeFixedLong4DPProvider<TRandomProvider>
                CreateProvider<TRandomProvider>(ref TRandomProvider random)
                where TRandomProvider : struct, IRandomProvider<TRandomProvider> =>
                RandomRangeFixedLong4DPProvider<TRandomProvider>.Create(
                    ref random,
                    MinValue,
                    MaxValue);

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RandomRangeFixedLong4DPProvider<TRandomProvider>
                CreateProvider<TRandomProvider, TOtherRandomProvider>(
                ref TOtherRandomProvider random)
                where TRandomProvider : struct, IRandomProvider<TRandomProvider>
                where TOtherRandomProvider :
                    struct, IRandomProvider<TOtherRandomProvider> =>
                RandomRangeFixedLong4DPProvider<TRandomProvider>.Create(
                    ref random,
                    MinValue,
                    MaxValue);

            /// <summary>
            /// Generates a new random value using the given min and max values.
            /// </summary>
            [SuppressMessage(
                "Naming",
                "CA1716:Identifiers should not match keywords",
                Justification = "Like the method System.Random.Next()")]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public FixedLong4DP Next<TRandomProvider>(
                ref TRandomProvider randomProvider)
                where TRandomProvider : struct, IRandomProvider =>
                (FixedLong4DP)RandomExtensions.Next(
                    ref randomProvider,
                    MinValue,
                    MaxValue);
        }

        /// <summary>
        /// Represents a default RNG range for type FixedLong4DP returning
        /// specified value intervals for type FixedLong4DP (in analogy to calling
        /// the appropriate NextXYZ method on the random provider given using min and
        /// max values).
        /// </summary>
        /// <typeparam name="TRandomProvider">The underlying random provider.</typeparam>
        public struct RandomRangeFixedLong4DPProvider<TRandomProvider> :
            IRandomRangeProvider<
                RandomRangeFixedLong4DPProvider<TRandomProvider>,
                FixedLong4DP>
            where TRandomProvider : struct, IRandomProvider<TRandomProvider>
        {
            private TRandomProvider randomProvider;

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The RNG instance to use.</param>
            /// <param name="minValue">The minimum value (inclusive).</param>
            /// <param name="maxValue">The maximum value (exclusive).</param>
            public RandomRangeFixedLong4DPProvider(
                TRandomProvider random,
                FixedLong4DP minValue,
                FixedLong4DP maxValue)
            {
                randomProvider = random;
                MinValue = minValue;
                MaxValue = maxValue;
            }

            /// <summary>
            /// Returns the min value of this range (inclusive).
            /// </summary>
            public FixedLong4DP MinValue { get; }

            /// <summary>
            /// Returns the max value of this range (exclusive).
            /// </summary>
            public FixedLong4DP MaxValue { get; }

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            /// <param name="minValue">The minimum value (inclusive).</param>
            /// <param name="maxValue">The maximum value (exclusive).</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static RandomRangeFixedLong4DPProvider<TRandomProvider>
                Create(
                System.Random random,
                FixedLong4DP minValue,
                FixedLong4DP maxValue) =>
                new(default(TRandomProvider).CreateProvider(random), minValue, maxValue);

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            /// <param name="minValue">The minimum value (inclusive).</param>
            /// <param name="maxValue">The maximum value (exclusive).</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static RandomRangeFixedLong4DPProvider<TRandomProvider>
                Create<TOtherProvider>(
                ref TOtherProvider random,
                FixedLong4DP minValue,
                FixedLong4DP maxValue)
                where TOtherProvider : struct, IRandomProvider<TOtherProvider> =>
                new(
                    default(TRandomProvider).CreateProvider(ref random),
                    minValue,
                    maxValue);

            /// <summary>
            /// Creates a new random range vector provider compatible with this provider.
            /// </summary>
            public readonly RandomRangeVectorProvider<
                FixedLong4DP,
                RandomRangeFixedLong4DPProvider<TRandomProvider>> CreateVectorProvider() =>
                new(this);

            /// <summary>
            /// Generates a new random value using the given min and max values.
            /// </summary>
            [SuppressMessage(
                "Naming",
                "CA1716:Identifiers should not match keywords",
                Justification = "Like the method System.Random.Next()")]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public FixedLong4DP Next() =>
                (FixedLong4DP)RandomExtensions.Next(
                    ref randomProvider,
                    MinValue,
                    MaxValue);
        }

        /// <summary>
        /// Represents a default RNG range for type FixedLong6DP returning
        /// specified value intervals for type FixedLong6DP (in analogy to calling
        /// the appropriate NextXYZ method on the random provider given using min and
        /// max values).
        /// </summary>
        /// <param name="MinValue">The minimum value (inclusive).</param>
        /// <param name="MaxValue">The maximum values (exclusive).</param>
        public readonly record struct RandomRangeFixedLong6DP(
            FixedLong6DP MinValue,
            FixedLong6DP MaxValue) :
            IRandomRange<FixedLong6DP>
        {
            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RandomRangeFixedLong6DPProvider<TRandomProvider>
                CreateProvider<TRandomProvider>(System.Random random)
                where TRandomProvider : struct, IRandomProvider<TRandomProvider> =>
                RandomRangeFixedLong6DPProvider<TRandomProvider>.Create(
                    random,
                    MinValue,
                    MaxValue);

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RandomRangeFixedLong6DPProvider<TRandomProvider>
                CreateProvider<TRandomProvider>(ref TRandomProvider random)
                where TRandomProvider : struct, IRandomProvider<TRandomProvider> =>
                RandomRangeFixedLong6DPProvider<TRandomProvider>.Create(
                    ref random,
                    MinValue,
                    MaxValue);

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RandomRangeFixedLong6DPProvider<TRandomProvider>
                CreateProvider<TRandomProvider, TOtherRandomProvider>(
                ref TOtherRandomProvider random)
                where TRandomProvider : struct, IRandomProvider<TRandomProvider>
                where TOtherRandomProvider :
                    struct, IRandomProvider<TOtherRandomProvider> =>
                RandomRangeFixedLong6DPProvider<TRandomProvider>.Create(
                    ref random,
                    MinValue,
                    MaxValue);

            /// <summary>
            /// Generates a new random value using the given min and max values.
            /// </summary>
            [SuppressMessage(
                "Naming",
                "CA1716:Identifiers should not match keywords",
                Justification = "Like the method System.Random.Next()")]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public FixedLong6DP Next<TRandomProvider>(
                ref TRandomProvider randomProvider)
                where TRandomProvider : struct, IRandomProvider =>
                (FixedLong6DP)RandomExtensions.Next(
                    ref randomProvider,
                    MinValue,
                    MaxValue);
        }

        /// <summary>
        /// Represents a default RNG range for type FixedLong6DP returning
        /// specified value intervals for type FixedLong6DP (in analogy to calling
        /// the appropriate NextXYZ method on the random provider given using min and
        /// max values).
        /// </summary>
        /// <typeparam name="TRandomProvider">The underlying random provider.</typeparam>
        public struct RandomRangeFixedLong6DPProvider<TRandomProvider> :
            IRandomRangeProvider<
                RandomRangeFixedLong6DPProvider<TRandomProvider>,
                FixedLong6DP>
            where TRandomProvider : struct, IRandomProvider<TRandomProvider>
        {
            private TRandomProvider randomProvider;

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The RNG instance to use.</param>
            /// <param name="minValue">The minimum value (inclusive).</param>
            /// <param name="maxValue">The maximum value (exclusive).</param>
            public RandomRangeFixedLong6DPProvider(
                TRandomProvider random,
                FixedLong6DP minValue,
                FixedLong6DP maxValue)
            {
                randomProvider = random;
                MinValue = minValue;
                MaxValue = maxValue;
            }

            /// <summary>
            /// Returns the min value of this range (inclusive).
            /// </summary>
            public FixedLong6DP MinValue { get; }

            /// <summary>
            /// Returns the max value of this range (exclusive).
            /// </summary>
            public FixedLong6DP MaxValue { get; }

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            /// <param name="minValue">The minimum value (inclusive).</param>
            /// <param name="maxValue">The maximum value (exclusive).</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static RandomRangeFixedLong6DPProvider<TRandomProvider>
                Create(
                System.Random random,
                FixedLong6DP minValue,
                FixedLong6DP maxValue) =>
                new(default(TRandomProvider).CreateProvider(random), minValue, maxValue);

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            /// <param name="minValue">The minimum value (inclusive).</param>
            /// <param name="maxValue">The maximum value (exclusive).</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static RandomRangeFixedLong6DPProvider<TRandomProvider>
                Create<TOtherProvider>(
                ref TOtherProvider random,
                FixedLong6DP minValue,
                FixedLong6DP maxValue)
                where TOtherProvider : struct, IRandomProvider<TOtherProvider> =>
                new(
                    default(TRandomProvider).CreateProvider(ref random),
                    minValue,
                    maxValue);

            /// <summary>
            /// Creates a new random range vector provider compatible with this provider.
            /// </summary>
            public readonly RandomRangeVectorProvider<
                FixedLong6DP,
                RandomRangeFixedLong6DPProvider<TRandomProvider>> CreateVectorProvider() =>
                new(this);

            /// <summary>
            /// Generates a new random value using the given min and max values.
            /// </summary>
            [SuppressMessage(
                "Naming",
                "CA1716:Identifiers should not match keywords",
                Justification = "Like the method System.Random.Next()")]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public FixedLong6DP Next() =>
                (FixedLong6DP)RandomExtensions.Next(
                    ref randomProvider,
                    MinValue,
                    MaxValue);
        }

        /// <summary>
        /// Represents a default RNG range for type FixedLong8DP returning
        /// specified value intervals for type FixedLong8DP (in analogy to calling
        /// the appropriate NextXYZ method on the random provider given using min and
        /// max values).
        /// </summary>
        /// <param name="MinValue">The minimum value (inclusive).</param>
        /// <param name="MaxValue">The maximum values (exclusive).</param>
        public readonly record struct RandomRangeFixedLong8DP(
            FixedLong8DP MinValue,
            FixedLong8DP MaxValue) :
            IRandomRange<FixedLong8DP>
        {
            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RandomRangeFixedLong8DPProvider<TRandomProvider>
                CreateProvider<TRandomProvider>(System.Random random)
                where TRandomProvider : struct, IRandomProvider<TRandomProvider> =>
                RandomRangeFixedLong8DPProvider<TRandomProvider>.Create(
                    random,
                    MinValue,
                    MaxValue);

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RandomRangeFixedLong8DPProvider<TRandomProvider>
                CreateProvider<TRandomProvider>(ref TRandomProvider random)
                where TRandomProvider : struct, IRandomProvider<TRandomProvider> =>
                RandomRangeFixedLong8DPProvider<TRandomProvider>.Create(
                    ref random,
                    MinValue,
                    MaxValue);

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RandomRangeFixedLong8DPProvider<TRandomProvider>
                CreateProvider<TRandomProvider, TOtherRandomProvider>(
                ref TOtherRandomProvider random)
                where TRandomProvider : struct, IRandomProvider<TRandomProvider>
                where TOtherRandomProvider :
                    struct, IRandomProvider<TOtherRandomProvider> =>
                RandomRangeFixedLong8DPProvider<TRandomProvider>.Create(
                    ref random,
                    MinValue,
                    MaxValue);

            /// <summary>
            /// Generates a new random value using the given min and max values.
            /// </summary>
            [SuppressMessage(
                "Naming",
                "CA1716:Identifiers should not match keywords",
                Justification = "Like the method System.Random.Next()")]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public FixedLong8DP Next<TRandomProvider>(
                ref TRandomProvider randomProvider)
                where TRandomProvider : struct, IRandomProvider =>
                (FixedLong8DP)RandomExtensions.Next(
                    ref randomProvider,
                    MinValue,
                    MaxValue);
        }

        /// <summary>
        /// Represents a default RNG range for type FixedLong8DP returning
        /// specified value intervals for type FixedLong8DP (in analogy to calling
        /// the appropriate NextXYZ method on the random provider given using min and
        /// max values).
        /// </summary>
        /// <typeparam name="TRandomProvider">The underlying random provider.</typeparam>
        public struct RandomRangeFixedLong8DPProvider<TRandomProvider> :
            IRandomRangeProvider<
                RandomRangeFixedLong8DPProvider<TRandomProvider>,
                FixedLong8DP>
            where TRandomProvider : struct, IRandomProvider<TRandomProvider>
        {
            private TRandomProvider randomProvider;

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The RNG instance to use.</param>
            /// <param name="minValue">The minimum value (inclusive).</param>
            /// <param name="maxValue">The maximum value (exclusive).</param>
            public RandomRangeFixedLong8DPProvider(
                TRandomProvider random,
                FixedLong8DP minValue,
                FixedLong8DP maxValue)
            {
                randomProvider = random;
                MinValue = minValue;
                MaxValue = maxValue;
            }

            /// <summary>
            /// Returns the min value of this range (inclusive).
            /// </summary>
            public FixedLong8DP MinValue { get; }

            /// <summary>
            /// Returns the max value of this range (exclusive).
            /// </summary>
            public FixedLong8DP MaxValue { get; }

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            /// <param name="minValue">The minimum value (inclusive).</param>
            /// <param name="maxValue">The maximum value (exclusive).</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static RandomRangeFixedLong8DPProvider<TRandomProvider>
                Create(
                System.Random random,
                FixedLong8DP minValue,
                FixedLong8DP maxValue) =>
                new(default(TRandomProvider).CreateProvider(random), minValue, maxValue);

            /// <summary>
            /// Instantiates a new random range provider using the given random provider.
            /// </summary>
            /// <param name="random">The parent RNG instance.</param>
            /// <param name="minValue">The minimum value (inclusive).</param>
            /// <param name="maxValue">The maximum value (exclusive).</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static RandomRangeFixedLong8DPProvider<TRandomProvider>
                Create<TOtherProvider>(
                ref TOtherProvider random,
                FixedLong8DP minValue,
                FixedLong8DP maxValue)
                where TOtherProvider : struct, IRandomProvider<TOtherProvider> =>
                new(
                    default(TRandomProvider).CreateProvider(ref random),
                    minValue,
                    maxValue);

            /// <summary>
            /// Creates a new random range vector provider compatible with this provider.
            /// </summary>
            public readonly RandomRangeVectorProvider<
                FixedLong8DP,
                RandomRangeFixedLong8DPProvider<TRandomProvider>> CreateVectorProvider() =>
                new(this);

            /// <summary>
            /// Generates a new random value using the given min and max values.
            /// </summary>
            [SuppressMessage(
                "Naming",
                "CA1716:Identifiers should not match keywords",
                Justification = "Like the method System.Random.Next()")]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public FixedLong8DP Next() =>
                (FixedLong8DP)RandomExtensions.Next(
                    ref randomProvider,
                    MinValue,
                    MaxValue);
        }

    }
}

#endif

#pragma warning restore IDE0004
#pragma warning restore CA1000