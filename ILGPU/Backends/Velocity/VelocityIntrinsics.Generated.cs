// ---------------------------------------------------------------------------------------
//                                        ILGPU
//                           Copyright (c) 2023 ILGPU Project
//                                    www.ilgpu.net
//
// File: VelocityIntrinsics.Generated.tt/VelocityIntrinsics.Generated.cs
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

using ILGPU.IR.Intrinsics;
using ILGPU.IR.Values;
using ILGPU.Runtime.Cuda;
using System.Runtime.CompilerServices;

namespace ILGPU.Backends.Velocity
{
    partial class VelocityIntrinsics
    {
        #region Warp Shuffles

        /// <summary>
        /// Registers all Velocity warp intrinsics with the given manager.
        /// </summary>
        /// <param name="manager">The target implementation manager.</param>
        private static void RegisterWarpShuffles(IntrinsicImplementationManager manager)
        {
            manager.RegisterWarpShuffle(
                ShuffleKind.Generic,
                BasicValueType.Int64,
                CreateIntrinsic(
                    nameof(WarpShuffleInt64),
                    IntrinsicImplementationMode.Redirect));
            manager.RegisterWarpShuffle(
                ShuffleKind.Generic,
                BasicValueType.Float64,
                CreateIntrinsic(
                    nameof(WarpShuffleFloat64),
                    IntrinsicImplementationMode.Redirect));

            manager.RegisterSubWarpShuffle(
                ShuffleKind.Generic,
                BasicValueType.Int64,
                CreateIntrinsic(
                    nameof(WarpShuffleInt64),
                    IntrinsicImplementationMode.Redirect));
            manager.RegisterSubWarpShuffle(
                ShuffleKind.Generic,
                BasicValueType.Float64,
                CreateIntrinsic(
                    nameof(WarpShuffleFloat64),
                    IntrinsicImplementationMode.Redirect));

            manager.RegisterWarpShuffle(
                ShuffleKind.Down,
                BasicValueType.Int64,
                CreateIntrinsic(
                    nameof(WarpShuffleDownInt64),
                    IntrinsicImplementationMode.Redirect));
            manager.RegisterWarpShuffle(
                ShuffleKind.Down,
                BasicValueType.Float64,
                CreateIntrinsic(
                    nameof(WarpShuffleDownFloat64),
                    IntrinsicImplementationMode.Redirect));

            manager.RegisterSubWarpShuffle(
                ShuffleKind.Down,
                BasicValueType.Int64,
                CreateIntrinsic(
                    nameof(WarpShuffleDownInt64),
                    IntrinsicImplementationMode.Redirect));
            manager.RegisterSubWarpShuffle(
                ShuffleKind.Down,
                BasicValueType.Float64,
                CreateIntrinsic(
                    nameof(WarpShuffleDownFloat64),
                    IntrinsicImplementationMode.Redirect));

            manager.RegisterWarpShuffle(
                ShuffleKind.Up,
                BasicValueType.Int64,
                CreateIntrinsic(
                    nameof(WarpShuffleUpInt64),
                    IntrinsicImplementationMode.Redirect));
            manager.RegisterWarpShuffle(
                ShuffleKind.Up,
                BasicValueType.Float64,
                CreateIntrinsic(
                    nameof(WarpShuffleUpFloat64),
                    IntrinsicImplementationMode.Redirect));

            manager.RegisterSubWarpShuffle(
                ShuffleKind.Up,
                BasicValueType.Int64,
                CreateIntrinsic(
                    nameof(WarpShuffleUpInt64),
                    IntrinsicImplementationMode.Redirect));
            manager.RegisterSubWarpShuffle(
                ShuffleKind.Up,
                BasicValueType.Float64,
                CreateIntrinsic(
                    nameof(WarpShuffleUpFloat64),
                    IntrinsicImplementationMode.Redirect));

            manager.RegisterWarpShuffle(
                ShuffleKind.Xor,
                BasicValueType.Int64,
                CreateIntrinsic(
                    nameof(WarpShuffleXorInt64),
                    IntrinsicImplementationMode.Redirect));
            manager.RegisterWarpShuffle(
                ShuffleKind.Xor,
                BasicValueType.Float64,
                CreateIntrinsic(
                    nameof(WarpShuffleXorFloat64),
                    IntrinsicImplementationMode.Redirect));

            manager.RegisterSubWarpShuffle(
                ShuffleKind.Xor,
                BasicValueType.Int64,
                CreateIntrinsic(
                    nameof(WarpShuffleXorInt64),
                    IntrinsicImplementationMode.Redirect));
            manager.RegisterSubWarpShuffle(
                ShuffleKind.Xor,
                BasicValueType.Float64,
                CreateIntrinsic(
                    nameof(WarpShuffleXorFloat64),
                    IntrinsicImplementationMode.Redirect));

        }

        /// <summary>
        /// Wraps a single warp-shuffle operation.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ulong WarpShuffleInt64(ulong value, int idx)
        {
            var parts = IntrinsicMath.Decompose(value);
            parts.Lower = Warp.Shuffle(parts.Lower, idx);
            parts.Upper = Warp.Shuffle(parts.Upper, idx);
            return parts.ToULong();
        }

        /// <summary>
        /// Wraps a single warp-shuffle operation.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static double WarpShuffleFloat64(double value, int idx)
        {
            var shuffled = WarpShuffleInt64(Interop.FloatAsInt(value), idx);
            return Interop.IntAsFloat(shuffled);
        }

        /// <summary>
        /// Wraps a single sub-warp-shuffle operation.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ulong SubWarpShuffleInt64(ulong value, int idx, int width)
        {
            var parts = IntrinsicMath.Decompose(value);
            parts.Lower = Warp.Shuffle(parts.Lower, idx, width);
            parts.Upper = Warp.Shuffle(parts.Upper, idx, width);
            return parts.ToULong();
        }

        /// <summary>
        /// Wraps a single sub-warp-shuffle operation.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static double SubWarpShuffleFloat64(
            double value,
            int idx,
            int width)
        {
            var shuffled = SubWarpShuffleInt64(
                Interop.FloatAsInt(value),
                idx,
                width);
            return Interop.IntAsFloat(shuffled);
        }

        /// <summary>
        /// Wraps a single warp-shuffle operation.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ulong WarpShuffleDownInt64(ulong value, int idx)
        {
            var parts = IntrinsicMath.Decompose(value);
            parts.Lower = Warp.ShuffleDown(parts.Lower, idx);
            parts.Upper = Warp.ShuffleDown(parts.Upper, idx);
            return parts.ToULong();
        }

        /// <summary>
        /// Wraps a single warp-shuffle operation.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static double WarpShuffleDownFloat64(double value, int idx)
        {
            var shuffled = WarpShuffleDownInt64(Interop.FloatAsInt(value), idx);
            return Interop.IntAsFloat(shuffled);
        }

        /// <summary>
        /// Wraps a single sub-warp-shuffle operation.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ulong SubWarpShuffleDownInt64(ulong value, int idx, int width)
        {
            var parts = IntrinsicMath.Decompose(value);
            parts.Lower = Warp.ShuffleDown(parts.Lower, idx, width);
            parts.Upper = Warp.ShuffleDown(parts.Upper, idx, width);
            return parts.ToULong();
        }

        /// <summary>
        /// Wraps a single sub-warp-shuffle operation.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static double SubWarpShuffleDownFloat64(
            double value,
            int idx,
            int width)
        {
            var shuffled = SubWarpShuffleDownInt64(
                Interop.FloatAsInt(value),
                idx,
                width);
            return Interop.IntAsFloat(shuffled);
        }

        /// <summary>
        /// Wraps a single warp-shuffle operation.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ulong WarpShuffleUpInt64(ulong value, int idx)
        {
            var parts = IntrinsicMath.Decompose(value);
            parts.Lower = Warp.ShuffleUp(parts.Lower, idx);
            parts.Upper = Warp.ShuffleUp(parts.Upper, idx);
            return parts.ToULong();
        }

        /// <summary>
        /// Wraps a single warp-shuffle operation.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static double WarpShuffleUpFloat64(double value, int idx)
        {
            var shuffled = WarpShuffleUpInt64(Interop.FloatAsInt(value), idx);
            return Interop.IntAsFloat(shuffled);
        }

        /// <summary>
        /// Wraps a single sub-warp-shuffle operation.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ulong SubWarpShuffleUpInt64(ulong value, int idx, int width)
        {
            var parts = IntrinsicMath.Decompose(value);
            parts.Lower = Warp.ShuffleUp(parts.Lower, idx, width);
            parts.Upper = Warp.ShuffleUp(parts.Upper, idx, width);
            return parts.ToULong();
        }

        /// <summary>
        /// Wraps a single sub-warp-shuffle operation.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static double SubWarpShuffleUpFloat64(
            double value,
            int idx,
            int width)
        {
            var shuffled = SubWarpShuffleUpInt64(
                Interop.FloatAsInt(value),
                idx,
                width);
            return Interop.IntAsFloat(shuffled);
        }

        /// <summary>
        /// Wraps a single warp-shuffle operation.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ulong WarpShuffleXorInt64(ulong value, int idx)
        {
            var parts = IntrinsicMath.Decompose(value);
            parts.Lower = Warp.ShuffleXor(parts.Lower, idx);
            parts.Upper = Warp.ShuffleXor(parts.Upper, idx);
            return parts.ToULong();
        }

        /// <summary>
        /// Wraps a single warp-shuffle operation.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static double WarpShuffleXorFloat64(double value, int idx)
        {
            var shuffled = WarpShuffleXorInt64(Interop.FloatAsInt(value), idx);
            return Interop.IntAsFloat(shuffled);
        }

        /// <summary>
        /// Wraps a single sub-warp-shuffle operation.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ulong SubWarpShuffleXorInt64(ulong value, int idx, int width)
        {
            var parts = IntrinsicMath.Decompose(value);
            parts.Lower = Warp.ShuffleXor(parts.Lower, idx, width);
            parts.Upper = Warp.ShuffleXor(parts.Upper, idx, width);
            return parts.ToULong();
        }

        /// <summary>
        /// Wraps a single sub-warp-shuffle operation.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static double SubWarpShuffleXorFloat64(
            double value,
            int idx,
            int width)
        {
            var shuffled = SubWarpShuffleXorInt64(
                Interop.FloatAsInt(value),
                idx,
                width);
            return Interop.IntAsFloat(shuffled);
        }


        #endregion
    }
}