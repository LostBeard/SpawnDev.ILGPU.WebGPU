// ---------------------------------------------------------------------------------------
//                                   ILGPU Algorithms
//                        Copyright (c) 2019-2023 ILGPU Project
//                                    www.ilgpu.net
//
// File: Sequencers.tt/Sequencers.cs
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

#pragma warning disable IDE0004 // Cast is redundant

using System;

namespace ILGPU.Algorithms.Sequencers
{
    // Helpers for Int8

    /// <summary>
    /// Represents an identity implementation of a sequencer.
    /// </summary>
    public readonly struct Int8Sequencer : ISequencer<sbyte>
    {
        /// <summary cref="ISequencer{T}.ComputeSequenceElement(LongIndex1D)" />
        public sbyte ComputeSequenceElement(LongIndex1D sequenceIndex) =>
            (sbyte)sequenceIndex.X;
    }

    // Helpers for Int16

    /// <summary>
    /// Represents an identity implementation of a sequencer.
    /// </summary>
    public readonly struct Int16Sequencer : ISequencer<short>
    {
        /// <summary cref="ISequencer{T}.ComputeSequenceElement(LongIndex1D)" />
        public short ComputeSequenceElement(LongIndex1D sequenceIndex) =>
            (short)sequenceIndex.X;
    }

    // Helpers for Int32

    /// <summary>
    /// Represents an identity implementation of a sequencer.
    /// </summary>
    public readonly struct Int32Sequencer : ISequencer<int>
    {
        /// <summary cref="ISequencer{T}.ComputeSequenceElement(LongIndex1D)" />
        public int ComputeSequenceElement(LongIndex1D sequenceIndex) =>
            (int)sequenceIndex.X;
    }

    // Helpers for Int64

    /// <summary>
    /// Represents an identity implementation of a sequencer.
    /// </summary>
    public readonly struct Int64Sequencer : ISequencer<long>
    {
        /// <summary cref="ISequencer{T}.ComputeSequenceElement(LongIndex1D)" />
        public long ComputeSequenceElement(LongIndex1D sequenceIndex) =>
            (long)sequenceIndex.X;
    }

    // Helpers for UInt8

    /// <summary>
    /// Represents an identity implementation of a sequencer.
    /// </summary>
    public readonly struct UInt8Sequencer : ISequencer<byte>
    {
        /// <summary cref="ISequencer{T}.ComputeSequenceElement(LongIndex1D)" />
        public byte ComputeSequenceElement(LongIndex1D sequenceIndex) =>
            (byte)sequenceIndex.X;
    }

    // Helpers for UInt16

    /// <summary>
    /// Represents an identity implementation of a sequencer.
    /// </summary>
    public readonly struct UInt16Sequencer : ISequencer<ushort>
    {
        /// <summary cref="ISequencer{T}.ComputeSequenceElement(LongIndex1D)" />
        public ushort ComputeSequenceElement(LongIndex1D sequenceIndex) =>
            (ushort)sequenceIndex.X;
    }

    // Helpers for UInt32

    /// <summary>
    /// Represents an identity implementation of a sequencer.
    /// </summary>
    public readonly struct UInt32Sequencer : ISequencer<uint>
    {
        /// <summary cref="ISequencer{T}.ComputeSequenceElement(LongIndex1D)" />
        public uint ComputeSequenceElement(LongIndex1D sequenceIndex) =>
            (uint)sequenceIndex.X;
    }

    // Helpers for UInt64

    /// <summary>
    /// Represents an identity implementation of a sequencer.
    /// </summary>
    public readonly struct UInt64Sequencer : ISequencer<ulong>
    {
        /// <summary cref="ISequencer{T}.ComputeSequenceElement(LongIndex1D)" />
        public ulong ComputeSequenceElement(LongIndex1D sequenceIndex) =>
            (ulong)sequenceIndex.X;
    }

}

#pragma warning restore IDE0004