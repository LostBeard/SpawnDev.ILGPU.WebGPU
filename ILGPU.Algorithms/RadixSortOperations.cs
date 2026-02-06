// ---------------------------------------------------------------------------------------
//                                   ILGPU Algorithms
//                        Copyright (c) 2019-2023 ILGPU Project
//                                    www.ilgpu.net
//
// File: RadixSortOperations.tt/RadixSortOperations.cs
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
using System.Runtime.CompilerServices;

#pragma warning disable IDE0004 // Cast is redundant

namespace ILGPU.Algorithms.RadixSortOperations
{
    /// <summary>
    /// Represents an ascending radix sort operation of type sbyte.
    /// </summary>
    public readonly struct AscendingInt8 :
        IRadixSortOperation<sbyte>
    {
        /// <summary>
        /// Returns the number of bits to sort.
        /// </summary>
        public int NumBits => sizeof(sbyte) * 8;

        /// <summary>
        /// The default element value.
        /// </summary>
        public sbyte DefaultValue => 0;

        /// <summary>
        /// Converts the given value to a radix-sort compatible value.
        /// </summary>
        /// <param name="value">The value to map.</param>
        /// <param name="shift">The shift amount in bits.</param>
        /// <param name="bitMask">The lower bit mask bit use.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int ExtractRadixBits(sbyte value, int shift, int bitMask)
        {
            // Negative integers are stored using two's complement, so they are already in
            // the correct order (within negative numbers). However, the sign-bit causes
            // negative integers to be incorrected sorted after positive numbers. So, we
            // flip the sign-bit, causing negative numbers to be ordered before positive
            // numbers.

            var bits = value ^ (1 << (NumBits - 1));
            return (int)(bits >> shift) & bitMask;
        }
    }

    /// <summary>
    /// Represents a descending radix sort operation of type sbyte.
    /// </summary>
    public readonly struct DescendingInt8 :
        IRadixSortOperation<sbyte>
    {
        /// <summary>
        /// Returns the number of bits to sort.
        /// </summary>
        public int NumBits => sizeof(sbyte) * 8;

        /// <summary>
        /// The default element value.
        /// </summary>
        public sbyte DefaultValue => 0;

        /// <summary>
        /// Converts the given value to a radix-sort compatible value.
        /// </summary>
        /// <param name="value">The value to map.</param>
        /// <param name="shift">The shift amount in bits.</param>
        /// <param name="bitMask">The lower bit mask bit use.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int ExtractRadixBits(sbyte value, int shift, int bitMask)
        {
            AscendingInt8 operation = default;
            return (~operation.ExtractRadixBits(value, shift, bitMask)) & bitMask;
        }
    }

    /// <summary>
    /// Represents an ascending radix sort operation of type short.
    /// </summary>
    public readonly struct AscendingInt16 :
        IRadixSortOperation<short>
    {
        /// <summary>
        /// Returns the number of bits to sort.
        /// </summary>
        public int NumBits => sizeof(short) * 8;

        /// <summary>
        /// The default element value.
        /// </summary>
        public short DefaultValue => 0;

        /// <summary>
        /// Converts the given value to a radix-sort compatible value.
        /// </summary>
        /// <param name="value">The value to map.</param>
        /// <param name="shift">The shift amount in bits.</param>
        /// <param name="bitMask">The lower bit mask bit use.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int ExtractRadixBits(short value, int shift, int bitMask)
        {
            // Negative integers are stored using two's complement, so they are already in
            // the correct order (within negative numbers). However, the sign-bit causes
            // negative integers to be incorrected sorted after positive numbers. So, we
            // flip the sign-bit, causing negative numbers to be ordered before positive
            // numbers.

            var bits = value ^ (1 << (NumBits - 1));
            return (int)(bits >> shift) & bitMask;
        }
    }

    /// <summary>
    /// Represents a descending radix sort operation of type short.
    /// </summary>
    public readonly struct DescendingInt16 :
        IRadixSortOperation<short>
    {
        /// <summary>
        /// Returns the number of bits to sort.
        /// </summary>
        public int NumBits => sizeof(short) * 8;

        /// <summary>
        /// The default element value.
        /// </summary>
        public short DefaultValue => 0;

        /// <summary>
        /// Converts the given value to a radix-sort compatible value.
        /// </summary>
        /// <param name="value">The value to map.</param>
        /// <param name="shift">The shift amount in bits.</param>
        /// <param name="bitMask">The lower bit mask bit use.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int ExtractRadixBits(short value, int shift, int bitMask)
        {
            AscendingInt16 operation = default;
            return (~operation.ExtractRadixBits(value, shift, bitMask)) & bitMask;
        }
    }

    /// <summary>
    /// Represents an ascending radix sort operation of type int.
    /// </summary>
    public readonly struct AscendingInt32 :
        IRadixSortOperation<int>
    {
        /// <summary>
        /// Returns the number of bits to sort.
        /// </summary>
        public int NumBits => sizeof(int) * 8;

        /// <summary>
        /// The default element value.
        /// </summary>
        public int DefaultValue => 0;

        /// <summary>
        /// Converts the given value to a radix-sort compatible value.
        /// </summary>
        /// <param name="value">The value to map.</param>
        /// <param name="shift">The shift amount in bits.</param>
        /// <param name="bitMask">The lower bit mask bit use.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int ExtractRadixBits(int value, int shift, int bitMask)
        {
            // Negative integers are stored using two's complement, so they are already in
            // the correct order (within negative numbers). However, the sign-bit causes
            // negative integers to be incorrected sorted after positive numbers. So, we
            // flip the sign-bit, causing negative numbers to be ordered before positive
            // numbers.

            var bits = value ^ (1 << (NumBits - 1));
            return (int)(bits >> shift) & bitMask;
        }
    }

    /// <summary>
    /// Represents a descending radix sort operation of type int.
    /// </summary>
    public readonly struct DescendingInt32 :
        IRadixSortOperation<int>
    {
        /// <summary>
        /// Returns the number of bits to sort.
        /// </summary>
        public int NumBits => sizeof(int) * 8;

        /// <summary>
        /// The default element value.
        /// </summary>
        public int DefaultValue => 0;

        /// <summary>
        /// Converts the given value to a radix-sort compatible value.
        /// </summary>
        /// <param name="value">The value to map.</param>
        /// <param name="shift">The shift amount in bits.</param>
        /// <param name="bitMask">The lower bit mask bit use.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int ExtractRadixBits(int value, int shift, int bitMask)
        {
            AscendingInt32 operation = default;
            return (~operation.ExtractRadixBits(value, shift, bitMask)) & bitMask;
        }
    }

    /// <summary>
    /// Represents an ascending radix sort operation of type long.
    /// </summary>
    public readonly struct AscendingInt64 :
        IRadixSortOperation<long>
    {
        /// <summary>
        /// Returns the number of bits to sort.
        /// </summary>
        public int NumBits => sizeof(long) * 8;

        /// <summary>
        /// The default element value.
        /// </summary>
        public long DefaultValue => 0;

        /// <summary>
        /// Converts the given value to a radix-sort compatible value.
        /// </summary>
        /// <param name="value">The value to map.</param>
        /// <param name="shift">The shift amount in bits.</param>
        /// <param name="bitMask">The lower bit mask bit use.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int ExtractRadixBits(long value, int shift, int bitMask)
        {
            // Negative integers are stored using two's complement, so they are already in
            // the correct order (within negative numbers). However, the sign-bit causes
            // negative integers to be incorrected sorted after positive numbers. So, we
            // flip the sign-bit, causing negative numbers to be ordered before positive
            // numbers.

            var bits = value ^ (1L << (NumBits - 1));
            return (int)(bits >> shift) & bitMask;
        }
    }

    /// <summary>
    /// Represents a descending radix sort operation of type long.
    /// </summary>
    public readonly struct DescendingInt64 :
        IRadixSortOperation<long>
    {
        /// <summary>
        /// Returns the number of bits to sort.
        /// </summary>
        public int NumBits => sizeof(long) * 8;

        /// <summary>
        /// The default element value.
        /// </summary>
        public long DefaultValue => 0;

        /// <summary>
        /// Converts the given value to a radix-sort compatible value.
        /// </summary>
        /// <param name="value">The value to map.</param>
        /// <param name="shift">The shift amount in bits.</param>
        /// <param name="bitMask">The lower bit mask bit use.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int ExtractRadixBits(long value, int shift, int bitMask)
        {
            AscendingInt64 operation = default;
            return (~operation.ExtractRadixBits(value, shift, bitMask)) & bitMask;
        }
    }

    /// <summary>
    /// Represents an ascending radix sort operation of type byte.
    /// </summary>
    public readonly struct AscendingUInt8 :
        IRadixSortOperation<byte>
    {
        /// <summary>
        /// Returns the number of bits to sort.
        /// </summary>
        public int NumBits => sizeof(byte) * 8;

        /// <summary>
        /// The default element value.
        /// </summary>
        public byte DefaultValue => 0;

        /// <summary>
        /// Converts the given value to a radix-sort compatible value.
        /// </summary>
        /// <param name="value">The value to map.</param>
        /// <param name="shift">The shift amount in bits.</param>
        /// <param name="bitMask">The lower bit mask bit use.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int ExtractRadixBits(byte value, int shift, int bitMask)
        {

            var bits = value;
            return (int)(bits >> shift) & bitMask;
        }
    }

    /// <summary>
    /// Represents a descending radix sort operation of type byte.
    /// </summary>
    public readonly struct DescendingUInt8 :
        IRadixSortOperation<byte>
    {
        /// <summary>
        /// Returns the number of bits to sort.
        /// </summary>
        public int NumBits => sizeof(byte) * 8;

        /// <summary>
        /// The default element value.
        /// </summary>
        public byte DefaultValue => 0;

        /// <summary>
        /// Converts the given value to a radix-sort compatible value.
        /// </summary>
        /// <param name="value">The value to map.</param>
        /// <param name="shift">The shift amount in bits.</param>
        /// <param name="bitMask">The lower bit mask bit use.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int ExtractRadixBits(byte value, int shift, int bitMask)
        {
            AscendingUInt8 operation = default;
            return (~operation.ExtractRadixBits(value, shift, bitMask)) & bitMask;
        }
    }

    /// <summary>
    /// Represents an ascending radix sort operation of type ushort.
    /// </summary>
    public readonly struct AscendingUInt16 :
        IRadixSortOperation<ushort>
    {
        /// <summary>
        /// Returns the number of bits to sort.
        /// </summary>
        public int NumBits => sizeof(ushort) * 8;

        /// <summary>
        /// The default element value.
        /// </summary>
        public ushort DefaultValue => 0;

        /// <summary>
        /// Converts the given value to a radix-sort compatible value.
        /// </summary>
        /// <param name="value">The value to map.</param>
        /// <param name="shift">The shift amount in bits.</param>
        /// <param name="bitMask">The lower bit mask bit use.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int ExtractRadixBits(ushort value, int shift, int bitMask)
        {

            var bits = value;
            return (int)(bits >> shift) & bitMask;
        }
    }

    /// <summary>
    /// Represents a descending radix sort operation of type ushort.
    /// </summary>
    public readonly struct DescendingUInt16 :
        IRadixSortOperation<ushort>
    {
        /// <summary>
        /// Returns the number of bits to sort.
        /// </summary>
        public int NumBits => sizeof(ushort) * 8;

        /// <summary>
        /// The default element value.
        /// </summary>
        public ushort DefaultValue => 0;

        /// <summary>
        /// Converts the given value to a radix-sort compatible value.
        /// </summary>
        /// <param name="value">The value to map.</param>
        /// <param name="shift">The shift amount in bits.</param>
        /// <param name="bitMask">The lower bit mask bit use.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int ExtractRadixBits(ushort value, int shift, int bitMask)
        {
            AscendingUInt16 operation = default;
            return (~operation.ExtractRadixBits(value, shift, bitMask)) & bitMask;
        }
    }

    /// <summary>
    /// Represents an ascending radix sort operation of type uint.
    /// </summary>
    public readonly struct AscendingUInt32 :
        IRadixSortOperation<uint>
    {
        /// <summary>
        /// Returns the number of bits to sort.
        /// </summary>
        public int NumBits => sizeof(uint) * 8;

        /// <summary>
        /// The default element value.
        /// </summary>
        public uint DefaultValue => 0;

        /// <summary>
        /// Converts the given value to a radix-sort compatible value.
        /// </summary>
        /// <param name="value">The value to map.</param>
        /// <param name="shift">The shift amount in bits.</param>
        /// <param name="bitMask">The lower bit mask bit use.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int ExtractRadixBits(uint value, int shift, int bitMask)
        {

            var bits = value;
            return (int)(bits >> shift) & bitMask;
        }
    }

    /// <summary>
    /// Represents a descending radix sort operation of type uint.
    /// </summary>
    public readonly struct DescendingUInt32 :
        IRadixSortOperation<uint>
    {
        /// <summary>
        /// Returns the number of bits to sort.
        /// </summary>
        public int NumBits => sizeof(uint) * 8;

        /// <summary>
        /// The default element value.
        /// </summary>
        public uint DefaultValue => 0;

        /// <summary>
        /// Converts the given value to a radix-sort compatible value.
        /// </summary>
        /// <param name="value">The value to map.</param>
        /// <param name="shift">The shift amount in bits.</param>
        /// <param name="bitMask">The lower bit mask bit use.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int ExtractRadixBits(uint value, int shift, int bitMask)
        {
            AscendingUInt32 operation = default;
            return (~operation.ExtractRadixBits(value, shift, bitMask)) & bitMask;
        }
    }

    /// <summary>
    /// Represents an ascending radix sort operation of type ulong.
    /// </summary>
    public readonly struct AscendingUInt64 :
        IRadixSortOperation<ulong>
    {
        /// <summary>
        /// Returns the number of bits to sort.
        /// </summary>
        public int NumBits => sizeof(ulong) * 8;

        /// <summary>
        /// The default element value.
        /// </summary>
        public ulong DefaultValue => 0;

        /// <summary>
        /// Converts the given value to a radix-sort compatible value.
        /// </summary>
        /// <param name="value">The value to map.</param>
        /// <param name="shift">The shift amount in bits.</param>
        /// <param name="bitMask">The lower bit mask bit use.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int ExtractRadixBits(ulong value, int shift, int bitMask)
        {

            var bits = value;
            return (int)(bits >> shift) & bitMask;
        }
    }

    /// <summary>
    /// Represents a descending radix sort operation of type ulong.
    /// </summary>
    public readonly struct DescendingUInt64 :
        IRadixSortOperation<ulong>
    {
        /// <summary>
        /// Returns the number of bits to sort.
        /// </summary>
        public int NumBits => sizeof(ulong) * 8;

        /// <summary>
        /// The default element value.
        /// </summary>
        public ulong DefaultValue => 0;

        /// <summary>
        /// Converts the given value to a radix-sort compatible value.
        /// </summary>
        /// <param name="value">The value to map.</param>
        /// <param name="shift">The shift amount in bits.</param>
        /// <param name="bitMask">The lower bit mask bit use.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int ExtractRadixBits(ulong value, int shift, int bitMask)
        {
            AscendingUInt64 operation = default;
            return (~operation.ExtractRadixBits(value, shift, bitMask)) & bitMask;
        }
    }

    /// <summary>
    /// Represents an ascending radix sort operation of type Half.
    /// </summary>
    public readonly struct AscendingHalf :
        IRadixSortOperation<Half>
    {
        /// <summary>
        /// Returns the number of bits to sort.
        /// </summary>
        public int NumBits => sizeof(ushort) * 8;

        /// <summary>
        /// The default element value.
        /// </summary>
        public Half DefaultValue => Half.Zero;

        /// <summary>
        /// Converts the given value to a radix-sort compatible value.
        /// </summary>
        /// <param name="value">The value to map.</param>
        /// <param name="shift">The shift amount in bits.</param>
        /// <param name="bitMask">The lower bit mask bit use.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int ExtractRadixBits(Half value, int shift, int bitMask)
        {
            // Floating point numbers have a sign-bit, causing negative integers to be
            // incorrected sorted after positive numbers. So, we flip the sign-bit,
            // causing negative numbers to be ordered before positive numbers.
            //
            // In addition, the exponent and mantissa are always stored as positive
            // numbers, incorrectly causing larger negative numbers to be ordered after
            // smaller negative numbers. So, if the number is negative, we apply a one's
            // complement to the exponent and mantissa (flip the bits), causing larger
            // negative numbers to be ordered before smaller negative numbers.
            //
            // In order to flip the exponent and mantissa only for negative numbers, we
            // build as mask by right-shifting the sign-bit all the way to the end. If the
            // sign-bit was set, it will be extended to fill all the bits. If the sign-bit
            // was not set, it will be zero all the way. Finally, we OR this with the
            // sign-bit flipping because we still want negative numbers before positive
            // numbers.

            var signMask = 1U << (NumBits - 1);
            var onesComplementMask =
                ((uint)~(Interop.FloatAsInt(value)) >> (NumBits - 1));
            var bits = Interop.FloatAsInt(value) ^ (signMask | onesComplementMask);
            return (int)(bits >> shift) & bitMask;
        }
    }

    /// <summary>
    /// Represents a descending radix sort operation of type Half.
    /// </summary>
    public readonly struct DescendingHalf :
        IRadixSortOperation<Half>
    {
        /// <summary>
        /// Returns the number of bits to sort.
        /// </summary>
        public int NumBits => sizeof(ushort) * 8;

        /// <summary>
        /// The default element value.
        /// </summary>
        public Half DefaultValue => Half.Zero;

        /// <summary>
        /// Converts the given value to a radix-sort compatible value.
        /// </summary>
        /// <param name="value">The value to map.</param>
        /// <param name="shift">The shift amount in bits.</param>
        /// <param name="bitMask">The lower bit mask bit use.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int ExtractRadixBits(Half value, int shift, int bitMask)
        {
            AscendingHalf operation = default;
            return (~operation.ExtractRadixBits(value, shift, bitMask)) & bitMask;
        }
    }

    /// <summary>
    /// Represents an ascending radix sort operation of type float.
    /// </summary>
    public readonly struct AscendingFloat :
        IRadixSortOperation<float>
    {
        /// <summary>
        /// Returns the number of bits to sort.
        /// </summary>
        public int NumBits => sizeof(float) * 8;

        /// <summary>
        /// The default element value.
        /// </summary>
        public float DefaultValue => 0;

        /// <summary>
        /// Converts the given value to a radix-sort compatible value.
        /// </summary>
        /// <param name="value">The value to map.</param>
        /// <param name="shift">The shift amount in bits.</param>
        /// <param name="bitMask">The lower bit mask bit use.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int ExtractRadixBits(float value, int shift, int bitMask)
        {
            // Floating point numbers have a sign-bit, causing negative integers to be
            // incorrected sorted after positive numbers. So, we flip the sign-bit,
            // causing negative numbers to be ordered before positive numbers.
            //
            // In addition, the exponent and mantissa are always stored as positive
            // numbers, incorrectly causing larger negative numbers to be ordered after
            // smaller negative numbers. So, if the number is negative, we apply a one's
            // complement to the exponent and mantissa (flip the bits), causing larger
            // negative numbers to be ordered before smaller negative numbers.
            //
            // In order to flip the exponent and mantissa only for negative numbers, we
            // build as mask by right-shifting the sign-bit all the way to the end. If the
            // sign-bit was set, it will be extended to fill all the bits. If the sign-bit
            // was not set, it will be zero all the way. Finally, we OR this with the
            // sign-bit flipping because we still want negative numbers before positive
            // numbers.

            var signMask = 1U << (NumBits - 1);
            var onesComplementMask = (~(Interop.FloatAsInt(value)) >> (NumBits - 1));
            var bits = Interop.FloatAsInt(value) ^ (signMask | onesComplementMask);
            return (int)(bits >> shift) & bitMask;
        }
    }

    /// <summary>
    /// Represents a descending radix sort operation of type float.
    /// </summary>
    public readonly struct DescendingFloat :
        IRadixSortOperation<float>
    {
        /// <summary>
        /// Returns the number of bits to sort.
        /// </summary>
        public int NumBits => sizeof(float) * 8;

        /// <summary>
        /// The default element value.
        /// </summary>
        public float DefaultValue => 0;

        /// <summary>
        /// Converts the given value to a radix-sort compatible value.
        /// </summary>
        /// <param name="value">The value to map.</param>
        /// <param name="shift">The shift amount in bits.</param>
        /// <param name="bitMask">The lower bit mask bit use.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int ExtractRadixBits(float value, int shift, int bitMask)
        {
            AscendingFloat operation = default;
            return (~operation.ExtractRadixBits(value, shift, bitMask)) & bitMask;
        }
    }

    /// <summary>
    /// Represents an ascending radix sort operation of type double.
    /// </summary>
    public readonly struct AscendingDouble :
        IRadixSortOperation<double>
    {
        /// <summary>
        /// Returns the number of bits to sort.
        /// </summary>
        public int NumBits => sizeof(double) * 8;

        /// <summary>
        /// The default element value.
        /// </summary>
        public double DefaultValue => 0;

        /// <summary>
        /// Converts the given value to a radix-sort compatible value.
        /// </summary>
        /// <param name="value">The value to map.</param>
        /// <param name="shift">The shift amount in bits.</param>
        /// <param name="bitMask">The lower bit mask bit use.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int ExtractRadixBits(double value, int shift, int bitMask)
        {
            // Floating point numbers have a sign-bit, causing negative integers to be
            // incorrected sorted after positive numbers. So, we flip the sign-bit,
            // causing negative numbers to be ordered before positive numbers.
            //
            // In addition, the exponent and mantissa are always stored as positive
            // numbers, incorrectly causing larger negative numbers to be ordered after
            // smaller negative numbers. So, if the number is negative, we apply a one's
            // complement to the exponent and mantissa (flip the bits), causing larger
            // negative numbers to be ordered before smaller negative numbers.
            //
            // In order to flip the exponent and mantissa only for negative numbers, we
            // build as mask by right-shifting the sign-bit all the way to the end. If the
            // sign-bit was set, it will be extended to fill all the bits. If the sign-bit
            // was not set, it will be zero all the way. Finally, we OR this with the
            // sign-bit flipping because we still want negative numbers before positive
            // numbers.

            var signMask = 1UL << (NumBits - 1);
            var onesComplementMask = (~(Interop.FloatAsInt(value)) >> (NumBits - 1));
            var bits = Interop.FloatAsInt(value) ^ (signMask | onesComplementMask);
            return (int)(bits >> shift) & bitMask;
        }
    }

    /// <summary>
    /// Represents a descending radix sort operation of type double.
    /// </summary>
    public readonly struct DescendingDouble :
        IRadixSortOperation<double>
    {
        /// <summary>
        /// Returns the number of bits to sort.
        /// </summary>
        public int NumBits => sizeof(double) * 8;

        /// <summary>
        /// The default element value.
        /// </summary>
        public double DefaultValue => 0;

        /// <summary>
        /// Converts the given value to a radix-sort compatible value.
        /// </summary>
        /// <param name="value">The value to map.</param>
        /// <param name="shift">The shift amount in bits.</param>
        /// <param name="bitMask">The lower bit mask bit use.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int ExtractRadixBits(double value, int shift, int bitMask)
        {
            AscendingDouble operation = default;
            return (~operation.ExtractRadixBits(value, shift, bitMask)) & bitMask;
        }
    }

}

#pragma warning restore IDE0004