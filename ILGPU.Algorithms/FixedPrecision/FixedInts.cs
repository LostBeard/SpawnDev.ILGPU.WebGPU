// ---------------------------------------------------------------------------------------
//                                   ILGPU Algorithms
//                        Copyright (c) 2023-2024 ILGPU Project
//                                    www.ilgpu.net
//
// File: FixedInts.tt/FixedInts.cs
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

using ILGPU.Algorithms.Random;
using ILGPU.Runtime;
using System;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;

#if NET7_0_OR_GREATER

// disable: max_line_length

#pragma warning disable IDE0004 // Cast is redundant
#pragma warning disable CA2225 // Friendly operator names

namespace ILGPU.Algorithms.FixedPrecision
{
    /// <summary>
    /// A fixed precision integer with 32bits using 7 bits
    /// to represent a number with 2 decimal places.
    /// </summary>
    /// <param name="RawValue">The nested raw integer value.</param>
    public readonly record struct FixedInt2DP(int RawValue) :
        INumber<FixedInt2DP>,
        ISignedNumber<FixedInt2DP>,
        IMinMaxValue<FixedInt2DP>
    {
        #region Static

        /// <summary>
        /// Returns the number of decimal places used.
        /// </summary>
        public const int DecimalPlaces = 2;

        /// <summary>
        /// Returns the number of decimal places used to perform rounding.
        /// </summary>
        private const int RoundingDecimalPlaces = 2;

        /// <summary>
        /// Returns the integer-based resolution radix.
        /// </summary>
        public const int Resolution = 100;

        /// <summary>
        /// Returns a float denominator used to convert fixed point values into floats.
        /// </summary>
        public const float FloatDenominator = 1.0f / Resolution;

        /// <summary>
        /// Returns a double denominator used to convert fixed point values into doubles.
        /// </summary>
        public const double DoubleDenominator = 1.0 / Resolution;

        /// <summary>
        /// Returns a decimal denominator used to convert fixed point values into decimals.
        /// </summary>
        public const decimal DecimalDenominator = 1m / Resolution;

        /// <inheritdoc cref="IMinMaxValue{TSelf}.MinValue" />
        public static FixedInt2DP MinValue => new(int.MinValue);

        /// <inheritdoc cref="IMinMaxValue{TSelf}.MaxValue" />
        public static FixedInt2DP MaxValue => new(int.MaxValue);

        /// <summary>
        /// Returns the value 1.
        /// </summary>
        public static FixedInt2DP One => new(Resolution);

        /// <summary>
        /// Returns the radix 2.
        /// </summary>
        public static int Radix => 2;

        /// <summary>
        /// Returns the value 0.
        /// </summary>
        public static FixedInt2DP Zero => new(0);

        /// <summary>
        /// Returns the value 0.
        /// </summary>
        public static FixedInt2DP AdditiveIdentity => Zero;

        /// <summary>
        /// Returns the value -1.
        /// </summary>
        public static FixedInt2DP NegativeOne => new(-Resolution);

        /// <inheritdoc cref="IMultiplicativeIdentity{TSelf, TResult}.MultiplicativeIdentity" />
        public static FixedInt2DP MultiplicativeIdentity => One;

        #endregion

        #region Properties

        /// <summary>
        /// Returns the main mantissa.
        /// </summary>
        public int Mantissa => RawValue / Resolution;

        /// <summary>
        /// Returns all decimal places of this number.
        /// </summary>
        public int Remainder => RawValue % Resolution;

        #endregion

        #region Operators

        /// <inheritdoc cref="IAdditionOperators{TSelf, TOther, TResult}.op_Addition(TSelf, TOther)" />
        public static FixedInt2DP operator +(FixedInt2DP left, FixedInt2DP right) =>
            new(left.RawValue + right.RawValue);

        /// <inheritdoc cref="ISubtractionOperators{TSelf, TOther, TResult}.op_Subtraction(TSelf, TOther)" />
        public static FixedInt2DP operator -(FixedInt2DP left, FixedInt2DP right) =>
            new(left.RawValue - right.RawValue);

        /// <inheritdoc cref="IComparisonOperators{TSelf, TOther, TResult}.op_GreaterThan(TSelf, TOther)" />
        public static bool operator >(FixedInt2DP left, FixedInt2DP right) =>
            left.RawValue > right.RawValue;
        /// <inheritdoc cref="IComparisonOperators{TSelf, TOther, TResult}.op_GreaterThanOrEqual(TSelf, TOther)" />
        public static bool operator >=(FixedInt2DP left, FixedInt2DP right) =>
            left.RawValue >= right.RawValue;

        /// <inheritdoc cref="IComparisonOperators{TSelf, TOther, TResult}.op_LessThan(TSelf, TOther)" />
        public static bool operator <(FixedInt2DP left, FixedInt2DP right) =>
            left.RawValue < right.RawValue;

        /// <inheritdoc cref="IComparisonOperators{TSelf, TOther, TResult}.op_LessThanOrEqual(TSelf, TOther)" />
        public static bool operator <=(FixedInt2DP left, FixedInt2DP right) =>
            left.RawValue <= right.RawValue;

        /// <inheritdoc cref="IDecrementOperators{TSelf}.op_Decrement(TSelf)" />
        public static FixedInt2DP operator --(FixedInt2DP value) => value - One;
        /// <inheritdoc cref="IIncrementOperators{TSelf}.op_Increment(TSelf)" />
        public static FixedInt2DP operator ++(FixedInt2DP value) => value + One;

        /// <inheritdoc cref="IDivisionOperators{TSelf, TOther, TResult}.op_Division(TSelf, TOther)" />
        public static FixedInt2DP operator /(FixedInt2DP left, FixedInt2DP right) =>
            new((int)(left.RawValue * (long)Resolution / right.RawValue));

        /// <inheritdoc cref="IMultiplyOperators{TSelf, TOther, TResult}.op_Multiply(TSelf, TOther)" />
        public static FixedInt2DP operator *(FixedInt2DP left, FixedInt2DP right) =>
            new((int)((long)left.RawValue * right.RawValue / Resolution));

        /// <inheritdoc cref="IModulusOperators{TSelf, TOther, TResult}.op_Modulus(TSelf, TOther)" />
        public static FixedInt2DP operator %(FixedInt2DP left, FixedInt2DP right) =>
            new(left.RawValue % right.RawValue);

        /// <inheritdoc cref="IUnaryNegationOperators{TSelf, TResult}.op_UnaryNegation(TSelf)" />
        public static FixedInt2DP operator -(FixedInt2DP value) => new(-value.RawValue);

        /// <inheritdoc cref="IUnaryPlusOperators{TSelf, TResult}.op_UnaryPlus(TSelf)" />
        public static FixedInt2DP operator +(FixedInt2DP value) => value;

        #endregion

        #region Generic INumberBase Methods

        /// <inheritdoc cref="INumberBase{TSelf}.Abs(TSelf)" />
        public static FixedInt2DP Abs(FixedInt2DP value) => new(Math.Abs(value.RawValue));

        /// <inheritdoc cref="INumberBase{TSelf}.IsCanonical(TSelf)" />
        public static bool IsCanonical(FixedInt2DP value) => true;

        /// <inheritdoc cref="INumberBase{TSelf}.IsComplexNumber(TSelf)" />
        public static bool IsComplexNumber(FixedInt2DP value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsFinite(TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEvenInteger(FixedInt2DP value) =>
            IsInteger(value) & (value.Mantissa & 1) == 0;

        /// <inheritdoc cref="INumberBase{TSelf}.IsFinite(TSelf)" />
        public static bool IsFinite(FixedInt2DP value) => true;

        /// <inheritdoc cref="INumberBase{TSelf}.IsImaginaryNumber(TSelf)" />
        public static bool IsImaginaryNumber(FixedInt2DP value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsInfinity(TSelf)" />
        public static bool IsInfinity(FixedInt2DP value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsInteger(TSelf)" />
        public static bool IsInteger(FixedInt2DP value) => value.Remainder == 0;

        /// <inheritdoc cref="INumberBase{TSelf}.IsNaN(TSelf)" />
        public static bool IsNaN(FixedInt2DP value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsNegative(TSelf)" />
        public static bool IsNegative(FixedInt2DP value) => value.RawValue < 0;

        /// <inheritdoc cref="INumberBase{TSelf}.IsNegativeInfinity(TSelf)" />
        public static bool IsNegativeInfinity(FixedInt2DP value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsNormal(TSelf)" />
        public static bool IsNormal(FixedInt2DP value) => value.RawValue != 0;

        /// <inheritdoc cref="INumberBase{TSelf}.IsOddInteger(TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsOddInteger(FixedInt2DP value) =>
            IsInteger(value) & (value.Mantissa & 1) != 0;

        /// <inheritdoc cref="INumberBase{TSelf}.IsPositive(TSelf)" />
        public static bool IsPositive(FixedInt2DP value) => value.RawValue >= 0;

        /// <inheritdoc cref="INumberBase{TSelf}.IsPositiveInfinity(TSelf)" />
        public static bool IsPositiveInfinity(FixedInt2DP value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsRealNumber(TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsRealNumber(FixedInt2DP value) => true;

        /// <inheritdoc cref="INumberBase{TSelf}.IsSubnormal(TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsSubnormal(FixedInt2DP value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsZero(TSelf)" />
        public static bool IsZero(FixedInt2DP value) => value.RawValue == 0;

        /// <inheritdoc cref="INumberBase{TSelf}.MaxMagnitude(TSelf, TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FixedInt2DP MaxMagnitude(FixedInt2DP x, FixedInt2DP y) =>
            new(int.MaxMagnitude(x.RawValue, y.RawValue));

        /// <inheritdoc cref="INumberBase{TSelf}.MaxMagnitudeNumber(TSelf, TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FixedInt2DP MaxMagnitudeNumber(FixedInt2DP x, FixedInt2DP y) =>
            MaxMagnitude(x, y);

        /// <inheritdoc cref="INumberBase{TSelf}.MinMagnitude(TSelf, TSelf)" />
        public static FixedInt2DP MinMagnitude(FixedInt2DP x, FixedInt2DP y) =>
            new(int.MinMagnitude(x.RawValue, y.RawValue));

        /// <inheritdoc cref="INumberBase{TSelf}.MinMagnitudeNumber(TSelf, TSelf)" />
        public static FixedInt2DP MinMagnitudeNumber(FixedInt2DP x, FixedInt2DP y) =>
            MinMagnitude(x, y);

        /// <summary>
        /// Computes the min value of both.
        /// </summary>
        /// <param name="x">The first value.</param>
        /// <param name="y">The second value.</param>
        /// <returns>The min value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FixedInt2DP Min(FixedInt2DP x, FixedInt2DP y) =>
            new(Math.Min(x.RawValue, y.RawValue));

        /// <summary>
        /// Computes the max value of both.
        /// </summary>
        /// <param name="x">The first value.</param>
        /// <param name="y">The second value.</param>
        /// <returns>The max value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FixedInt2DP Max(FixedInt2DP x, FixedInt2DP y) =>
            new(Math.Max(x.RawValue, y.RawValue));

        #endregion

        #region TryConvert

        /// <inheritdoc cref="INumberBase{TSelf}.TryConvertFromChecked{TOther}(TOther, out TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryConvertFromChecked<TOther>(TOther value, out FixedInt2DP result)
            where TOther : INumberBase<TOther> =>
            TryConvertFrom(value, out result);

        /// <inheritdoc cref="INumberBase{TSelf}.TryConvertFromSaturating{TOther}(TOther, out TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryConvertFromSaturating<TOther>(TOther value, out FixedInt2DP result)
            where TOther : INumberBase<TOther> =>
            TryConvertFrom(value, out result);

        /// <inheritdoc cref="INumberBase{TSelf}.TryConvertFromTruncating{TOther}(TOther, out TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryConvertFromTruncating<TOther>(TOther value, out FixedInt2DP result)
            where TOther : INumberBase<TOther> =>
            TryConvertFrom(value, out result);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool TryConvertFrom<TOther>(TOther value, out FixedInt2DP result)
            where TOther : INumberBase<TOther>
        {
            if (typeof(TOther) == typeof(bool))
            {
                result = Unsafe.As<TOther, bool>(ref value) ? One : Zero;
                return true;
            }
            if (typeof(TOther) == typeof(sbyte))
            {
                result = (FixedInt2DP)Unsafe.As<TOther, sbyte>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(byte))
            {
                result = (FixedInt2DP)Unsafe.As<TOther, byte>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(short))
            {
                result = (FixedInt2DP)Unsafe.As<TOther, short>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(ushort))
            {
                result = (FixedInt2DP)Unsafe.As<TOther, ushort>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(int))
            {
                result = (FixedInt2DP)Unsafe.As<TOther, int>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(uint))
            {
                result = (FixedInt2DP)Unsafe.As<TOther, uint>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(long))
            {
                result = (FixedInt2DP)Unsafe.As<TOther, long>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(ulong))
            {
                result = (FixedInt2DP)Unsafe.As<TOther, ulong>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(System.Int128))
            {
                result = (FixedInt2DP)Unsafe.As<TOther, System.Int128>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(System.UInt128))
            {
                result = (FixedInt2DP)Unsafe.As<TOther, System.UInt128>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(nint))
            {
                result = (FixedInt2DP)Unsafe.As<TOther, nint>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(nuint))
            {
                result = (FixedInt2DP)Unsafe.As<TOther, nuint>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(System.Half))
            {
                result = (FixedInt2DP)Unsafe.As<TOther, System.Half>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(float))
            {
                result = (FixedInt2DP)Unsafe.As<TOther, float>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(double))
            {
                result = (FixedInt2DP)Unsafe.As<TOther, double>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(int))
            {
                result = (FixedInt2DP)Unsafe.As<TOther, int>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(int))
            {
                result = (FixedInt2DP)Unsafe.As<TOther, int>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(int))
            {
                result = (FixedInt2DP)Unsafe.As<TOther, int>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(long))
            {
                result = (FixedInt2DP)Unsafe.As<TOther, long>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(long))
            {
                result = (FixedInt2DP)Unsafe.As<TOther, long>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(long))
            {
                result = (FixedInt2DP)Unsafe.As<TOther, long>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(long))
            {
                result = (FixedInt2DP)Unsafe.As<TOther, long>(ref value);
                return true;
            }

            result = default;
            return false;
        }

        /// <inheritdoc cref="INumberBase{TSelf}.TryConvertToChecked{TOther}(TSelf, out TOther)" />
        public static bool TryConvertToChecked<TOther>(FixedInt2DP value, out TOther result)
            where TOther : INumberBase<TOther> =>
            TryConvertTo(value, out result);

        /// <inheritdoc cref="INumberBase{TSelf}.TryConvertToSaturating{TOther}(TSelf, out TOther)" />
        public static bool TryConvertToSaturating<TOther>(FixedInt2DP value, out TOther result)
            where TOther : INumberBase<TOther> =>
            TryConvertTo(value, out result);

        /// <inheritdoc cref="INumberBase{TSelf}.TryConvertToTruncating{TOther}(TSelf, out TOther)" />
        public static bool TryConvertToTruncating<TOther>(FixedInt2DP value, out TOther result)
            where TOther : INumberBase<TOther> =>
            TryConvertTo(value, out result);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool TryConvertTo<TOther>(FixedInt2DP value, out TOther result)
            where TOther : INumberBase<TOther>
        {
            result = default!;
            if (typeof(TOther) == typeof(bool))
            {
                Unsafe.As<TOther, bool>(ref result) = (bool)value;
                return true;
            }
            if (typeof(TOther) == typeof(sbyte))
            {
                Unsafe.As<TOther, sbyte>(ref result) = (sbyte)value;
                return true;
            }
            if (typeof(TOther) == typeof(byte))
            {
                Unsafe.As<TOther, byte>(ref result) = (byte)value;
                return true;
            }
            if (typeof(TOther) == typeof(short))
            {
                Unsafe.As<TOther, short>(ref result) = (short)value;
                return true;
            }
            if (typeof(TOther) == typeof(ushort))
            {
                Unsafe.As<TOther, ushort>(ref result) = (ushort)value;
                return true;
            }
            if (typeof(TOther) == typeof(int))
            {
                Unsafe.As<TOther, int>(ref result) = (int)value;
                return true;
            }
            if (typeof(TOther) == typeof(uint))
            {
                Unsafe.As<TOther, uint>(ref result) = (uint)value;
                return true;
            }
            if (typeof(TOther) == typeof(long))
            {
                Unsafe.As<TOther, long>(ref result) = (long)value;
                return true;
            }
            if (typeof(TOther) == typeof(ulong))
            {
                Unsafe.As<TOther, ulong>(ref result) = (ulong)value;
                return true;
            }
            if (typeof(TOther) == typeof(System.Int128))
            {
                Unsafe.As<TOther, System.Int128>(ref result) = (System.Int128)value;
                return true;
            }
            if (typeof(TOther) == typeof(System.UInt128))
            {
                Unsafe.As<TOther, System.UInt128>(ref result) = (System.UInt128)value;
                return true;
            }
            if (typeof(TOther) == typeof(nint))
            {
                Unsafe.As<TOther, nint>(ref result) = (nint)value;
                return true;
            }
            if (typeof(TOther) == typeof(nuint))
            {
                Unsafe.As<TOther, nuint>(ref result) = (nuint)value;
                return true;
            }
            if (typeof(TOther) == typeof(System.Half))
            {
                Unsafe.As<TOther, System.Half>(ref result) = (System.Half)value;
                return true;
            }
            if (typeof(TOther) == typeof(float))
            {
                Unsafe.As<TOther, float>(ref result) = (float)value;
                return true;
            }
            if (typeof(TOther) == typeof(double))
            {
                Unsafe.As<TOther, double>(ref result) = (double)value;
                return true;
            }
            if (typeof(TOther) == typeof(FixedInt2DP))
            {
                Unsafe.As<TOther, FixedInt2DP>(ref result) = (FixedInt2DP)value;
                return true;
            }
            if (typeof(TOther) == typeof(FixedInt4DP))
            {
                Unsafe.As<TOther, FixedInt4DP>(ref result) = (FixedInt4DP)value;
                return true;
            }
            if (typeof(TOther) == typeof(FixedInt6DP))
            {
                Unsafe.As<TOther, FixedInt6DP>(ref result) = (FixedInt6DP)value;
                return true;
            }
            if (typeof(TOther) == typeof(FixedLong2DP))
            {
                Unsafe.As<TOther, FixedLong2DP>(ref result) = (FixedLong2DP)value;
                return true;
            }
            if (typeof(TOther) == typeof(FixedLong4DP))
            {
                Unsafe.As<TOther, FixedLong4DP>(ref result) = (FixedLong4DP)value;
                return true;
            }
            if (typeof(TOther) == typeof(FixedLong6DP))
            {
                Unsafe.As<TOther, FixedLong6DP>(ref result) = (FixedLong6DP)value;
                return true;
            }
            if (typeof(TOther) == typeof(FixedLong8DP))
            {
                Unsafe.As<TOther, FixedLong8DP>(ref result) = (FixedLong8DP)value;
                return true;
            }

            result = default!;
            return false;
        }

        #endregion

        #region Parse

        /// <inheritdoc cref="IParsable{TSelf}.TryParse(string?, IFormatProvider?, out TSelf)"/>
        public static bool TryParse(string? s, IFormatProvider? provider, out FixedInt2DP result)
        {
            result = default;
            if (string.IsNullOrWhiteSpace(s))
                return false;
            return TryParse(s.AsSpan(), provider, out result);
        }

        /// <inheritdoc cref="INumberBase{TSelf}.TryParse(ReadOnlySpan{char}, NumberStyles, IFormatProvider?, out TSelf)"/>
        public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out FixedInt2DP result) =>
            TryParse(s, NumberStyles.Integer, provider, out result);

        /// <inheritdoc cref="INumberBase{TSelf}.TryParse(string?, NumberStyles, IFormatProvider? ,out TSelf)"/>
        public static bool TryParse(string? s, NumberStyles style, IFormatProvider? provider, out FixedInt2DP result)
        {
            result = default;
            if (string.IsNullOrWhiteSpace(s))
                return false;
            return TryParse(s.AsSpan(), style, provider, out result);
        }

        /// <inheritdoc cref="ISpanParsable{TSelf}.TryParse(ReadOnlySpan{char}, IFormatProvider?, out TSelf)" />
        public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out FixedInt2DP result)
        {
            result = default;

            var separator = GetDecimalSeparator(provider);
            int decimalSeparator = s.IndexOf(separator.AsSpan());
            if (decimalSeparator < 0)
            {
                // Try parse mantissa part only
                if (!int.TryParse(s, style, provider, out int mantissaOnly))
                    return false;
                result = new(mantissaOnly);
                return true;
            }

            var mantissaPart = s[..decimalSeparator];
            var remainderPart = s[decimalSeparator..];

            if (!int.TryParse(mantissaPart, style, provider, out int mantissa) ||
                !int.TryParse(remainderPart, style, provider, out int remainder))
            {
                return false;
            }

            result = new(mantissa * Resolution + remainder);
            return true;
        }

        /// <inheritdoc cref="IParsable{TSelf}.Parse(string, IFormatProvider?)"/>
        public static FixedInt2DP Parse(string s, IFormatProvider? provider) =>
            Parse(s.AsSpan(), provider);

        /// <inheritdoc cref="INumberBase{TSelf}.Parse(string, NumberStyles, System.IFormatProvider?)"/>
        public static FixedInt2DP Parse(string s, NumberStyles style, IFormatProvider? provider) =>
            Parse(s.AsSpan(), style, provider);

        /// <inheritdoc cref="ISpanParsable{TSelf}.Parse(ReadOnlySpan{char}, IFormatProvider?)" />
        public static FixedInt2DP Parse(ReadOnlySpan<char> s, IFormatProvider? provider) =>
            Parse(s, NumberStyles.Integer, provider);

        /// <inheritdoc cref="INumberBase{TSelf}.Parse(ReadOnlySpan{char}, NumberStyles, System.IFormatProvider?)"/>
        public static FixedInt2DP Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
        {
            if (!TryParse(s, style, provider, out var result))
                throw new FormatException();
            return result;
        }

        #endregion

        #region IComparable

        /// <summary>
        /// Compares the given object to the current instance.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int CompareTo(object? obj) => obj is FixedInt2DP fixedInt ? CompareTo(fixedInt) : 1;

        /// <summary>
        /// Compares the given fixed integer to the current instance.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int CompareTo(FixedInt2DP other) => RawValue.CompareTo(other.RawValue);

        #endregion

        #region ToString and Formats

        /// <summary>
        /// Returns the default string representation of this fixed point value.
        /// </summary>
        public override string ToString() => ToString(null, null);

        /// <summary>
        /// Returns the string representation of this value while taking the given separator into account.
        /// </summary>
        /// <param name="decimalSeparator">The decimal separator to use.</param>
        private string ToString(string decimalSeparator) =>
            $"{Mantissa}{decimalSeparator}{Remainder:00}";

        /// <summary>
        /// Helper function to get a number format provider instance.
        /// </summary>
        private static string GetDecimalSeparator(IFormatProvider? formatProvider) =>
            NumberFormatInfo.GetInstance(formatProvider).NumberDecimalSeparator;

        /// <inheritdoc cref="IFormattable.ToString(string?,System.IFormatProvider?)"/>
        public string ToString(string? format, IFormatProvider? formatProvider) =>
            ToString(GetDecimalSeparator(formatProvider));

        /// <inheritdoc cref="ISpanFormattable.TryFormat(Span{char}, out int, ReadOnlySpan{char}, IFormatProvider?)"/>
        public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
        {
            if (!Mantissa.TryFormat(destination, out charsWritten, format, provider))
                return false;

            var remainingTarget = destination[charsWritten..];
            var separator = GetDecimalSeparator(provider);
            if (separator.Length > remainingTarget.Length)
                return false;

            separator.CopyTo(remainingTarget);
            charsWritten += separator.Length;

            var decimalPlacesTarget = remainingTarget[separator.Length..];
            bool result = Remainder.TryFormat(
                decimalPlacesTarget,
                out int remainderCharsWritten,
                format,
                provider);
            charsWritten += remainderCharsWritten;
            return result;
        }

        #endregion

        #region Conversion Operators

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator bool(FixedInt2DP fixedInt) => fixedInt.RawValue != 0;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator char(FixedInt2DP fixedInt) => (char)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator sbyte(FixedInt2DP fixedInt) => (sbyte)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator byte(FixedInt2DP fixedInt) => (byte)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator short(FixedInt2DP fixedInt) => (short)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator ushort(FixedInt2DP fixedInt) => (ushort)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator int(FixedInt2DP fixedInt) => (int)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator uint(FixedInt2DP fixedInt) => (uint)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator long(FixedInt2DP fixedInt) => (long)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator Int128(FixedInt2DP fixedInt) => (Int128)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator ulong(FixedInt2DP fixedInt) => (ulong)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator UInt128(FixedInt2DP fixedInt) => (UInt128)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator System.Half(FixedInt2DP fixedInt) =>
            (System.Half)(float)fixedInt;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator float(FixedInt2DP fixedInt) => fixedInt.RawValue * FloatDenominator;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator double(FixedInt2DP fixedInt) =>
            fixedInt.RawValue * DoubleDenominator;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator decimal(FixedInt2DP fixedInt) =>
            fixedInt.RawValue * DecimalDenominator;

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedInt2DP(bool value) => value ? One : Zero;

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedInt2DP(char value) => new((int)value);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedInt2DP(sbyte value) => new(value * Resolution);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedInt2DP(byte value) => new(value * Resolution);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedInt2DP(short value) => new(value * Resolution);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedInt2DP(ushort value) => new(value * Resolution);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedInt2DP(int value) => new(value);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedInt2DP(uint value) => new((int)value);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedInt2DP(long value) => new((int)value);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedInt2DP(Int128 value) => new((int)value);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedInt2DP(ulong value) => new((int)value);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedInt2DP(UInt128 value) => new((int)value);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedInt2DP(System.Half value) =>
            (FixedInt2DP)(float)value;

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedInt2DP(float value)
        {
            int mantissa = (int)value;
            int remainder = (int)(
                MathF.Round(value - MathF.Truncate(value), RoundingDecimalPlaces) * Resolution);
            return new(mantissa * Resolution + remainder);
        }

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedInt2DP(double value)
        {
            int mantissa = (int)value;
            int remainder = (int)(
                Math.Round(value - Math.Truncate(value), RoundingDecimalPlaces) * Resolution);
            return new(mantissa * Resolution + remainder);
        }

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedInt2DP(decimal value)
        {
            int mantissa = (int)value;
            int remainder = (int)(
                Math.Round(value - Math.Truncate(value), RoundingDecimalPlaces) * Resolution);
            return new(mantissa * Resolution + remainder);
        }

        /// <summary>
        /// Converts the given value into its specified fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedInt4DP(FixedInt2DP value)
        {
            var computeVal = (long)value.RawValue;
            var newValue = computeVal * FixedInt4DP.Resolution / Resolution;
            return new((int)newValue);
        }

        /// <summary>
        /// Converts the given value into its specified fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedInt6DP(FixedInt2DP value)
        {
            var computeVal = (long)value.RawValue;
            var newValue = computeVal * FixedInt6DP.Resolution / Resolution;
            return new((int)newValue);
        }

        /// <summary>
        /// Converts the given value into its specified fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedLong2DP(FixedInt2DP value)
        {
            var computeVal = (long)value.RawValue;
            var newValue = computeVal * FixedLong2DP.Resolution / Resolution;
            return new((long)newValue);
        }

        /// <summary>
        /// Converts the given value into its specified fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedLong4DP(FixedInt2DP value)
        {
            var computeVal = (long)value.RawValue;
            var newValue = computeVal * FixedLong4DP.Resolution / Resolution;
            return new((long)newValue);
        }

        /// <summary>
        /// Converts the given value into its specified fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedLong6DP(FixedInt2DP value)
        {
            var computeVal = (long)value.RawValue;
            var newValue = computeVal * FixedLong6DP.Resolution / Resolution;
            return new((long)newValue);
        }

        /// <summary>
        /// Converts the given value into its specified fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedLong8DP(FixedInt2DP value)
        {
            var computeVal = (long)value.RawValue;
            var newValue = computeVal * FixedLong8DP.Resolution / Resolution;
            return new((long)newValue);
        }

        #endregion
    }

    /// <summary>
    /// A fixed precision integer with 32bits using 14 bits
    /// to represent a number with 4 decimal places.
    /// </summary>
    /// <param name="RawValue">The nested raw integer value.</param>
    public readonly record struct FixedInt4DP(int RawValue) :
        INumber<FixedInt4DP>,
        ISignedNumber<FixedInt4DP>,
        IMinMaxValue<FixedInt4DP>
    {
        #region Static

        /// <summary>
        /// Returns the number of decimal places used.
        /// </summary>
        public const int DecimalPlaces = 4;

        /// <summary>
        /// Returns the number of decimal places used to perform rounding.
        /// </summary>
        private const int RoundingDecimalPlaces = 4;

        /// <summary>
        /// Returns the integer-based resolution radix.
        /// </summary>
        public const int Resolution = 10000;

        /// <summary>
        /// Returns a float denominator used to convert fixed point values into floats.
        /// </summary>
        public const float FloatDenominator = 1.0f / Resolution;

        /// <summary>
        /// Returns a double denominator used to convert fixed point values into doubles.
        /// </summary>
        public const double DoubleDenominator = 1.0 / Resolution;

        /// <summary>
        /// Returns a decimal denominator used to convert fixed point values into decimals.
        /// </summary>
        public const decimal DecimalDenominator = 1m / Resolution;

        /// <inheritdoc cref="IMinMaxValue{TSelf}.MinValue" />
        public static FixedInt4DP MinValue => new(int.MinValue);

        /// <inheritdoc cref="IMinMaxValue{TSelf}.MaxValue" />
        public static FixedInt4DP MaxValue => new(int.MaxValue);

        /// <summary>
        /// Returns the value 1.
        /// </summary>
        public static FixedInt4DP One => new(Resolution);

        /// <summary>
        /// Returns the radix 2.
        /// </summary>
        public static int Radix => 2;

        /// <summary>
        /// Returns the value 0.
        /// </summary>
        public static FixedInt4DP Zero => new(0);

        /// <summary>
        /// Returns the value 0.
        /// </summary>
        public static FixedInt4DP AdditiveIdentity => Zero;

        /// <summary>
        /// Returns the value -1.
        /// </summary>
        public static FixedInt4DP NegativeOne => new(-Resolution);

        /// <inheritdoc cref="IMultiplicativeIdentity{TSelf, TResult}.MultiplicativeIdentity" />
        public static FixedInt4DP MultiplicativeIdentity => One;

        #endregion

        #region Properties

        /// <summary>
        /// Returns the main mantissa.
        /// </summary>
        public int Mantissa => RawValue / Resolution;

        /// <summary>
        /// Returns all decimal places of this number.
        /// </summary>
        public int Remainder => RawValue % Resolution;

        #endregion

        #region Operators

        /// <inheritdoc cref="IAdditionOperators{TSelf, TOther, TResult}.op_Addition(TSelf, TOther)" />
        public static FixedInt4DP operator +(FixedInt4DP left, FixedInt4DP right) =>
            new(left.RawValue + right.RawValue);

        /// <inheritdoc cref="ISubtractionOperators{TSelf, TOther, TResult}.op_Subtraction(TSelf, TOther)" />
        public static FixedInt4DP operator -(FixedInt4DP left, FixedInt4DP right) =>
            new(left.RawValue - right.RawValue);

        /// <inheritdoc cref="IComparisonOperators{TSelf, TOther, TResult}.op_GreaterThan(TSelf, TOther)" />
        public static bool operator >(FixedInt4DP left, FixedInt4DP right) =>
            left.RawValue > right.RawValue;
        /// <inheritdoc cref="IComparisonOperators{TSelf, TOther, TResult}.op_GreaterThanOrEqual(TSelf, TOther)" />
        public static bool operator >=(FixedInt4DP left, FixedInt4DP right) =>
            left.RawValue >= right.RawValue;

        /// <inheritdoc cref="IComparisonOperators{TSelf, TOther, TResult}.op_LessThan(TSelf, TOther)" />
        public static bool operator <(FixedInt4DP left, FixedInt4DP right) =>
            left.RawValue < right.RawValue;

        /// <inheritdoc cref="IComparisonOperators{TSelf, TOther, TResult}.op_LessThanOrEqual(TSelf, TOther)" />
        public static bool operator <=(FixedInt4DP left, FixedInt4DP right) =>
            left.RawValue <= right.RawValue;

        /// <inheritdoc cref="IDecrementOperators{TSelf}.op_Decrement(TSelf)" />
        public static FixedInt4DP operator --(FixedInt4DP value) => value - One;
        /// <inheritdoc cref="IIncrementOperators{TSelf}.op_Increment(TSelf)" />
        public static FixedInt4DP operator ++(FixedInt4DP value) => value + One;

        /// <inheritdoc cref="IDivisionOperators{TSelf, TOther, TResult}.op_Division(TSelf, TOther)" />
        public static FixedInt4DP operator /(FixedInt4DP left, FixedInt4DP right) =>
            new((int)(left.RawValue * (long)Resolution / right.RawValue));

        /// <inheritdoc cref="IMultiplyOperators{TSelf, TOther, TResult}.op_Multiply(TSelf, TOther)" />
        public static FixedInt4DP operator *(FixedInt4DP left, FixedInt4DP right) =>
            new((int)((long)left.RawValue * right.RawValue / Resolution));

        /// <inheritdoc cref="IModulusOperators{TSelf, TOther, TResult}.op_Modulus(TSelf, TOther)" />
        public static FixedInt4DP operator %(FixedInt4DP left, FixedInt4DP right) =>
            new(left.RawValue % right.RawValue);

        /// <inheritdoc cref="IUnaryNegationOperators{TSelf, TResult}.op_UnaryNegation(TSelf)" />
        public static FixedInt4DP operator -(FixedInt4DP value) => new(-value.RawValue);

        /// <inheritdoc cref="IUnaryPlusOperators{TSelf, TResult}.op_UnaryPlus(TSelf)" />
        public static FixedInt4DP operator +(FixedInt4DP value) => value;

        #endregion

        #region Generic INumberBase Methods

        /// <inheritdoc cref="INumberBase{TSelf}.Abs(TSelf)" />
        public static FixedInt4DP Abs(FixedInt4DP value) => new(Math.Abs(value.RawValue));

        /// <inheritdoc cref="INumberBase{TSelf}.IsCanonical(TSelf)" />
        public static bool IsCanonical(FixedInt4DP value) => true;

        /// <inheritdoc cref="INumberBase{TSelf}.IsComplexNumber(TSelf)" />
        public static bool IsComplexNumber(FixedInt4DP value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsFinite(TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEvenInteger(FixedInt4DP value) =>
            IsInteger(value) & (value.Mantissa & 1) == 0;

        /// <inheritdoc cref="INumberBase{TSelf}.IsFinite(TSelf)" />
        public static bool IsFinite(FixedInt4DP value) => true;

        /// <inheritdoc cref="INumberBase{TSelf}.IsImaginaryNumber(TSelf)" />
        public static bool IsImaginaryNumber(FixedInt4DP value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsInfinity(TSelf)" />
        public static bool IsInfinity(FixedInt4DP value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsInteger(TSelf)" />
        public static bool IsInteger(FixedInt4DP value) => value.Remainder == 0;

        /// <inheritdoc cref="INumberBase{TSelf}.IsNaN(TSelf)" />
        public static bool IsNaN(FixedInt4DP value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsNegative(TSelf)" />
        public static bool IsNegative(FixedInt4DP value) => value.RawValue < 0;

        /// <inheritdoc cref="INumberBase{TSelf}.IsNegativeInfinity(TSelf)" />
        public static bool IsNegativeInfinity(FixedInt4DP value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsNormal(TSelf)" />
        public static bool IsNormal(FixedInt4DP value) => value.RawValue != 0;

        /// <inheritdoc cref="INumberBase{TSelf}.IsOddInteger(TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsOddInteger(FixedInt4DP value) =>
            IsInteger(value) & (value.Mantissa & 1) != 0;

        /// <inheritdoc cref="INumberBase{TSelf}.IsPositive(TSelf)" />
        public static bool IsPositive(FixedInt4DP value) => value.RawValue >= 0;

        /// <inheritdoc cref="INumberBase{TSelf}.IsPositiveInfinity(TSelf)" />
        public static bool IsPositiveInfinity(FixedInt4DP value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsRealNumber(TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsRealNumber(FixedInt4DP value) => true;

        /// <inheritdoc cref="INumberBase{TSelf}.IsSubnormal(TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsSubnormal(FixedInt4DP value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsZero(TSelf)" />
        public static bool IsZero(FixedInt4DP value) => value.RawValue == 0;

        /// <inheritdoc cref="INumberBase{TSelf}.MaxMagnitude(TSelf, TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FixedInt4DP MaxMagnitude(FixedInt4DP x, FixedInt4DP y) =>
            new(int.MaxMagnitude(x.RawValue, y.RawValue));

        /// <inheritdoc cref="INumberBase{TSelf}.MaxMagnitudeNumber(TSelf, TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FixedInt4DP MaxMagnitudeNumber(FixedInt4DP x, FixedInt4DP y) =>
            MaxMagnitude(x, y);

        /// <inheritdoc cref="INumberBase{TSelf}.MinMagnitude(TSelf, TSelf)" />
        public static FixedInt4DP MinMagnitude(FixedInt4DP x, FixedInt4DP y) =>
            new(int.MinMagnitude(x.RawValue, y.RawValue));

        /// <inheritdoc cref="INumberBase{TSelf}.MinMagnitudeNumber(TSelf, TSelf)" />
        public static FixedInt4DP MinMagnitudeNumber(FixedInt4DP x, FixedInt4DP y) =>
            MinMagnitude(x, y);

        /// <summary>
        /// Computes the min value of both.
        /// </summary>
        /// <param name="x">The first value.</param>
        /// <param name="y">The second value.</param>
        /// <returns>The min value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FixedInt4DP Min(FixedInt4DP x, FixedInt4DP y) =>
            new(Math.Min(x.RawValue, y.RawValue));

        /// <summary>
        /// Computes the max value of both.
        /// </summary>
        /// <param name="x">The first value.</param>
        /// <param name="y">The second value.</param>
        /// <returns>The max value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FixedInt4DP Max(FixedInt4DP x, FixedInt4DP y) =>
            new(Math.Max(x.RawValue, y.RawValue));

        #endregion

        #region TryConvert

        /// <inheritdoc cref="INumberBase{TSelf}.TryConvertFromChecked{TOther}(TOther, out TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryConvertFromChecked<TOther>(TOther value, out FixedInt4DP result)
            where TOther : INumberBase<TOther> =>
            TryConvertFrom(value, out result);

        /// <inheritdoc cref="INumberBase{TSelf}.TryConvertFromSaturating{TOther}(TOther, out TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryConvertFromSaturating<TOther>(TOther value, out FixedInt4DP result)
            where TOther : INumberBase<TOther> =>
            TryConvertFrom(value, out result);

        /// <inheritdoc cref="INumberBase{TSelf}.TryConvertFromTruncating{TOther}(TOther, out TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryConvertFromTruncating<TOther>(TOther value, out FixedInt4DP result)
            where TOther : INumberBase<TOther> =>
            TryConvertFrom(value, out result);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool TryConvertFrom<TOther>(TOther value, out FixedInt4DP result)
            where TOther : INumberBase<TOther>
        {
            if (typeof(TOther) == typeof(bool))
            {
                result = Unsafe.As<TOther, bool>(ref value) ? One : Zero;
                return true;
            }
            if (typeof(TOther) == typeof(sbyte))
            {
                result = (FixedInt4DP)Unsafe.As<TOther, sbyte>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(byte))
            {
                result = (FixedInt4DP)Unsafe.As<TOther, byte>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(short))
            {
                result = (FixedInt4DP)Unsafe.As<TOther, short>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(ushort))
            {
                result = (FixedInt4DP)Unsafe.As<TOther, ushort>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(int))
            {
                result = (FixedInt4DP)Unsafe.As<TOther, int>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(uint))
            {
                result = (FixedInt4DP)Unsafe.As<TOther, uint>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(long))
            {
                result = (FixedInt4DP)Unsafe.As<TOther, long>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(ulong))
            {
                result = (FixedInt4DP)Unsafe.As<TOther, ulong>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(System.Int128))
            {
                result = (FixedInt4DP)Unsafe.As<TOther, System.Int128>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(System.UInt128))
            {
                result = (FixedInt4DP)Unsafe.As<TOther, System.UInt128>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(nint))
            {
                result = (FixedInt4DP)Unsafe.As<TOther, nint>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(nuint))
            {
                result = (FixedInt4DP)Unsafe.As<TOther, nuint>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(System.Half))
            {
                result = (FixedInt4DP)Unsafe.As<TOther, System.Half>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(float))
            {
                result = (FixedInt4DP)Unsafe.As<TOther, float>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(double))
            {
                result = (FixedInt4DP)Unsafe.As<TOther, double>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(int))
            {
                result = (FixedInt4DP)Unsafe.As<TOther, int>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(int))
            {
                result = (FixedInt4DP)Unsafe.As<TOther, int>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(int))
            {
                result = (FixedInt4DP)Unsafe.As<TOther, int>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(long))
            {
                result = (FixedInt4DP)Unsafe.As<TOther, long>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(long))
            {
                result = (FixedInt4DP)Unsafe.As<TOther, long>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(long))
            {
                result = (FixedInt4DP)Unsafe.As<TOther, long>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(long))
            {
                result = (FixedInt4DP)Unsafe.As<TOther, long>(ref value);
                return true;
            }

            result = default;
            return false;
        }

        /// <inheritdoc cref="INumberBase{TSelf}.TryConvertToChecked{TOther}(TSelf, out TOther)" />
        public static bool TryConvertToChecked<TOther>(FixedInt4DP value, out TOther result)
            where TOther : INumberBase<TOther> =>
            TryConvertTo(value, out result);

        /// <inheritdoc cref="INumberBase{TSelf}.TryConvertToSaturating{TOther}(TSelf, out TOther)" />
        public static bool TryConvertToSaturating<TOther>(FixedInt4DP value, out TOther result)
            where TOther : INumberBase<TOther> =>
            TryConvertTo(value, out result);

        /// <inheritdoc cref="INumberBase{TSelf}.TryConvertToTruncating{TOther}(TSelf, out TOther)" />
        public static bool TryConvertToTruncating<TOther>(FixedInt4DP value, out TOther result)
            where TOther : INumberBase<TOther> =>
            TryConvertTo(value, out result);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool TryConvertTo<TOther>(FixedInt4DP value, out TOther result)
            where TOther : INumberBase<TOther>
        {
            result = default!;
            if (typeof(TOther) == typeof(bool))
            {
                Unsafe.As<TOther, bool>(ref result) = (bool)value;
                return true;
            }
            if (typeof(TOther) == typeof(sbyte))
            {
                Unsafe.As<TOther, sbyte>(ref result) = (sbyte)value;
                return true;
            }
            if (typeof(TOther) == typeof(byte))
            {
                Unsafe.As<TOther, byte>(ref result) = (byte)value;
                return true;
            }
            if (typeof(TOther) == typeof(short))
            {
                Unsafe.As<TOther, short>(ref result) = (short)value;
                return true;
            }
            if (typeof(TOther) == typeof(ushort))
            {
                Unsafe.As<TOther, ushort>(ref result) = (ushort)value;
                return true;
            }
            if (typeof(TOther) == typeof(int))
            {
                Unsafe.As<TOther, int>(ref result) = (int)value;
                return true;
            }
            if (typeof(TOther) == typeof(uint))
            {
                Unsafe.As<TOther, uint>(ref result) = (uint)value;
                return true;
            }
            if (typeof(TOther) == typeof(long))
            {
                Unsafe.As<TOther, long>(ref result) = (long)value;
                return true;
            }
            if (typeof(TOther) == typeof(ulong))
            {
                Unsafe.As<TOther, ulong>(ref result) = (ulong)value;
                return true;
            }
            if (typeof(TOther) == typeof(System.Int128))
            {
                Unsafe.As<TOther, System.Int128>(ref result) = (System.Int128)value;
                return true;
            }
            if (typeof(TOther) == typeof(System.UInt128))
            {
                Unsafe.As<TOther, System.UInt128>(ref result) = (System.UInt128)value;
                return true;
            }
            if (typeof(TOther) == typeof(nint))
            {
                Unsafe.As<TOther, nint>(ref result) = (nint)value;
                return true;
            }
            if (typeof(TOther) == typeof(nuint))
            {
                Unsafe.As<TOther, nuint>(ref result) = (nuint)value;
                return true;
            }
            if (typeof(TOther) == typeof(System.Half))
            {
                Unsafe.As<TOther, System.Half>(ref result) = (System.Half)value;
                return true;
            }
            if (typeof(TOther) == typeof(float))
            {
                Unsafe.As<TOther, float>(ref result) = (float)value;
                return true;
            }
            if (typeof(TOther) == typeof(double))
            {
                Unsafe.As<TOther, double>(ref result) = (double)value;
                return true;
            }
            if (typeof(TOther) == typeof(FixedInt2DP))
            {
                Unsafe.As<TOther, FixedInt2DP>(ref result) = (FixedInt2DP)value;
                return true;
            }
            if (typeof(TOther) == typeof(FixedInt4DP))
            {
                Unsafe.As<TOther, FixedInt4DP>(ref result) = (FixedInt4DP)value;
                return true;
            }
            if (typeof(TOther) == typeof(FixedInt6DP))
            {
                Unsafe.As<TOther, FixedInt6DP>(ref result) = (FixedInt6DP)value;
                return true;
            }
            if (typeof(TOther) == typeof(FixedLong2DP))
            {
                Unsafe.As<TOther, FixedLong2DP>(ref result) = (FixedLong2DP)value;
                return true;
            }
            if (typeof(TOther) == typeof(FixedLong4DP))
            {
                Unsafe.As<TOther, FixedLong4DP>(ref result) = (FixedLong4DP)value;
                return true;
            }
            if (typeof(TOther) == typeof(FixedLong6DP))
            {
                Unsafe.As<TOther, FixedLong6DP>(ref result) = (FixedLong6DP)value;
                return true;
            }
            if (typeof(TOther) == typeof(FixedLong8DP))
            {
                Unsafe.As<TOther, FixedLong8DP>(ref result) = (FixedLong8DP)value;
                return true;
            }

            result = default!;
            return false;
        }

        #endregion

        #region Parse

        /// <inheritdoc cref="IParsable{TSelf}.TryParse(string?, IFormatProvider?, out TSelf)"/>
        public static bool TryParse(string? s, IFormatProvider? provider, out FixedInt4DP result)
        {
            result = default;
            if (string.IsNullOrWhiteSpace(s))
                return false;
            return TryParse(s.AsSpan(), provider, out result);
        }

        /// <inheritdoc cref="INumberBase{TSelf}.TryParse(ReadOnlySpan{char}, NumberStyles, IFormatProvider?, out TSelf)"/>
        public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out FixedInt4DP result) =>
            TryParse(s, NumberStyles.Integer, provider, out result);

        /// <inheritdoc cref="INumberBase{TSelf}.TryParse(string?, NumberStyles, IFormatProvider? ,out TSelf)"/>
        public static bool TryParse(string? s, NumberStyles style, IFormatProvider? provider, out FixedInt4DP result)
        {
            result = default;
            if (string.IsNullOrWhiteSpace(s))
                return false;
            return TryParse(s.AsSpan(), style, provider, out result);
        }

        /// <inheritdoc cref="ISpanParsable{TSelf}.TryParse(ReadOnlySpan{char}, IFormatProvider?, out TSelf)" />
        public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out FixedInt4DP result)
        {
            result = default;

            var separator = GetDecimalSeparator(provider);
            int decimalSeparator = s.IndexOf(separator.AsSpan());
            if (decimalSeparator < 0)
            {
                // Try parse mantissa part only
                if (!int.TryParse(s, style, provider, out int mantissaOnly))
                    return false;
                result = new(mantissaOnly);
                return true;
            }

            var mantissaPart = s[..decimalSeparator];
            var remainderPart = s[decimalSeparator..];

            if (!int.TryParse(mantissaPart, style, provider, out int mantissa) ||
                !int.TryParse(remainderPart, style, provider, out int remainder))
            {
                return false;
            }

            result = new(mantissa * Resolution + remainder);
            return true;
        }

        /// <inheritdoc cref="IParsable{TSelf}.Parse(string, IFormatProvider?)"/>
        public static FixedInt4DP Parse(string s, IFormatProvider? provider) =>
            Parse(s.AsSpan(), provider);

        /// <inheritdoc cref="INumberBase{TSelf}.Parse(string, NumberStyles, System.IFormatProvider?)"/>
        public static FixedInt4DP Parse(string s, NumberStyles style, IFormatProvider? provider) =>
            Parse(s.AsSpan(), style, provider);

        /// <inheritdoc cref="ISpanParsable{TSelf}.Parse(ReadOnlySpan{char}, IFormatProvider?)" />
        public static FixedInt4DP Parse(ReadOnlySpan<char> s, IFormatProvider? provider) =>
            Parse(s, NumberStyles.Integer, provider);

        /// <inheritdoc cref="INumberBase{TSelf}.Parse(ReadOnlySpan{char}, NumberStyles, System.IFormatProvider?)"/>
        public static FixedInt4DP Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
        {
            if (!TryParse(s, style, provider, out var result))
                throw new FormatException();
            return result;
        }

        #endregion

        #region IComparable

        /// <summary>
        /// Compares the given object to the current instance.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int CompareTo(object? obj) => obj is FixedInt4DP fixedInt ? CompareTo(fixedInt) : 1;

        /// <summary>
        /// Compares the given fixed integer to the current instance.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int CompareTo(FixedInt4DP other) => RawValue.CompareTo(other.RawValue);

        #endregion

        #region ToString and Formats

        /// <summary>
        /// Returns the default string representation of this fixed point value.
        /// </summary>
        public override string ToString() => ToString(null, null);

        /// <summary>
        /// Returns the string representation of this value while taking the given separator into account.
        /// </summary>
        /// <param name="decimalSeparator">The decimal separator to use.</param>
        private string ToString(string decimalSeparator) =>
            $"{Mantissa}{decimalSeparator}{Remainder:0000}";

        /// <summary>
        /// Helper function to get a number format provider instance.
        /// </summary>
        private static string GetDecimalSeparator(IFormatProvider? formatProvider) =>
            NumberFormatInfo.GetInstance(formatProvider).NumberDecimalSeparator;

        /// <inheritdoc cref="IFormattable.ToString(string?,System.IFormatProvider?)"/>
        public string ToString(string? format, IFormatProvider? formatProvider) =>
            ToString(GetDecimalSeparator(formatProvider));

        /// <inheritdoc cref="ISpanFormattable.TryFormat(Span{char}, out int, ReadOnlySpan{char}, IFormatProvider?)"/>
        public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
        {
            if (!Mantissa.TryFormat(destination, out charsWritten, format, provider))
                return false;

            var remainingTarget = destination[charsWritten..];
            var separator = GetDecimalSeparator(provider);
            if (separator.Length > remainingTarget.Length)
                return false;

            separator.CopyTo(remainingTarget);
            charsWritten += separator.Length;

            var decimalPlacesTarget = remainingTarget[separator.Length..];
            bool result = Remainder.TryFormat(
                decimalPlacesTarget,
                out int remainderCharsWritten,
                format,
                provider);
            charsWritten += remainderCharsWritten;
            return result;
        }

        #endregion

        #region Conversion Operators

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator bool(FixedInt4DP fixedInt) => fixedInt.RawValue != 0;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator char(FixedInt4DP fixedInt) => (char)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator sbyte(FixedInt4DP fixedInt) => (sbyte)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator byte(FixedInt4DP fixedInt) => (byte)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator short(FixedInt4DP fixedInt) => (short)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator ushort(FixedInt4DP fixedInt) => (ushort)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator int(FixedInt4DP fixedInt) => (int)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator uint(FixedInt4DP fixedInt) => (uint)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator long(FixedInt4DP fixedInt) => (long)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator Int128(FixedInt4DP fixedInt) => (Int128)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator ulong(FixedInt4DP fixedInt) => (ulong)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator UInt128(FixedInt4DP fixedInt) => (UInt128)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator System.Half(FixedInt4DP fixedInt) =>
            (System.Half)(float)fixedInt;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator float(FixedInt4DP fixedInt) => fixedInt.RawValue * FloatDenominator;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator double(FixedInt4DP fixedInt) =>
            fixedInt.RawValue * DoubleDenominator;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator decimal(FixedInt4DP fixedInt) =>
            fixedInt.RawValue * DecimalDenominator;

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedInt4DP(bool value) => value ? One : Zero;

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedInt4DP(char value) => new((int)value);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedInt4DP(sbyte value) => new(value * Resolution);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedInt4DP(byte value) => new(value * Resolution);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedInt4DP(short value) => new(value * Resolution);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedInt4DP(ushort value) => new(value * Resolution);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedInt4DP(int value) => new(value);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedInt4DP(uint value) => new((int)value);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedInt4DP(long value) => new((int)value);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedInt4DP(Int128 value) => new((int)value);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedInt4DP(ulong value) => new((int)value);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedInt4DP(UInt128 value) => new((int)value);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedInt4DP(System.Half value) =>
            (FixedInt4DP)(float)value;

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedInt4DP(float value)
        {
            int mantissa = (int)value;
            int remainder = (int)(
                MathF.Round(value - MathF.Truncate(value), RoundingDecimalPlaces) * Resolution);
            return new(mantissa * Resolution + remainder);
        }

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedInt4DP(double value)
        {
            int mantissa = (int)value;
            int remainder = (int)(
                Math.Round(value - Math.Truncate(value), RoundingDecimalPlaces) * Resolution);
            return new(mantissa * Resolution + remainder);
        }

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedInt4DP(decimal value)
        {
            int mantissa = (int)value;
            int remainder = (int)(
                Math.Round(value - Math.Truncate(value), RoundingDecimalPlaces) * Resolution);
            return new(mantissa * Resolution + remainder);
        }

        /// <summary>
        /// Converts the given value into its specified fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedInt2DP(FixedInt4DP value)
        {
            var computeVal = (long)value.RawValue;
            var newValue = computeVal * FixedInt2DP.Resolution / Resolution;
            return new((int)newValue);
        }

        /// <summary>
        /// Converts the given value into its specified fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedInt6DP(FixedInt4DP value)
        {
            var computeVal = (long)value.RawValue;
            var newValue = computeVal * FixedInt6DP.Resolution / Resolution;
            return new((int)newValue);
        }

        /// <summary>
        /// Converts the given value into its specified fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedLong2DP(FixedInt4DP value)
        {
            var computeVal = (long)value.RawValue;
            var newValue = computeVal * FixedLong2DP.Resolution / Resolution;
            return new((long)newValue);
        }

        /// <summary>
        /// Converts the given value into its specified fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedLong4DP(FixedInt4DP value)
        {
            var computeVal = (long)value.RawValue;
            var newValue = computeVal * FixedLong4DP.Resolution / Resolution;
            return new((long)newValue);
        }

        /// <summary>
        /// Converts the given value into its specified fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedLong6DP(FixedInt4DP value)
        {
            var computeVal = (long)value.RawValue;
            var newValue = computeVal * FixedLong6DP.Resolution / Resolution;
            return new((long)newValue);
        }

        /// <summary>
        /// Converts the given value into its specified fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedLong8DP(FixedInt4DP value)
        {
            var computeVal = (long)value.RawValue;
            var newValue = computeVal * FixedLong8DP.Resolution / Resolution;
            return new((long)newValue);
        }

        #endregion
    }

    /// <summary>
    /// A fixed precision integer with 32bits using 20 bits
    /// to represent a number with 6 decimal places.
    /// </summary>
    /// <param name="RawValue">The nested raw integer value.</param>
    public readonly record struct FixedInt6DP(int RawValue) :
        INumber<FixedInt6DP>,
        ISignedNumber<FixedInt6DP>,
        IMinMaxValue<FixedInt6DP>
    {
        #region Static

        /// <summary>
        /// Returns the number of decimal places used.
        /// </summary>
        public const int DecimalPlaces = 6;

        /// <summary>
        /// Returns the number of decimal places used to perform rounding.
        /// </summary>
        private const int RoundingDecimalPlaces = 6;

        /// <summary>
        /// Returns the integer-based resolution radix.
        /// </summary>
        public const int Resolution = 1000000;

        /// <summary>
        /// Returns a float denominator used to convert fixed point values into floats.
        /// </summary>
        public const float FloatDenominator = 1.0f / Resolution;

        /// <summary>
        /// Returns a double denominator used to convert fixed point values into doubles.
        /// </summary>
        public const double DoubleDenominator = 1.0 / Resolution;

        /// <summary>
        /// Returns a decimal denominator used to convert fixed point values into decimals.
        /// </summary>
        public const decimal DecimalDenominator = 1m / Resolution;

        /// <inheritdoc cref="IMinMaxValue{TSelf}.MinValue" />
        public static FixedInt6DP MinValue => new(int.MinValue);

        /// <inheritdoc cref="IMinMaxValue{TSelf}.MaxValue" />
        public static FixedInt6DP MaxValue => new(int.MaxValue);

        /// <summary>
        /// Returns the value 1.
        /// </summary>
        public static FixedInt6DP One => new(Resolution);

        /// <summary>
        /// Returns the radix 2.
        /// </summary>
        public static int Radix => 2;

        /// <summary>
        /// Returns the value 0.
        /// </summary>
        public static FixedInt6DP Zero => new(0);

        /// <summary>
        /// Returns the value 0.
        /// </summary>
        public static FixedInt6DP AdditiveIdentity => Zero;

        /// <summary>
        /// Returns the value -1.
        /// </summary>
        public static FixedInt6DP NegativeOne => new(-Resolution);

        /// <inheritdoc cref="IMultiplicativeIdentity{TSelf, TResult}.MultiplicativeIdentity" />
        public static FixedInt6DP MultiplicativeIdentity => One;

        #endregion

        #region Properties

        /// <summary>
        /// Returns the main mantissa.
        /// </summary>
        public int Mantissa => RawValue / Resolution;

        /// <summary>
        /// Returns all decimal places of this number.
        /// </summary>
        public int Remainder => RawValue % Resolution;

        #endregion

        #region Operators

        /// <inheritdoc cref="IAdditionOperators{TSelf, TOther, TResult}.op_Addition(TSelf, TOther)" />
        public static FixedInt6DP operator +(FixedInt6DP left, FixedInt6DP right) =>
            new(left.RawValue + right.RawValue);

        /// <inheritdoc cref="ISubtractionOperators{TSelf, TOther, TResult}.op_Subtraction(TSelf, TOther)" />
        public static FixedInt6DP operator -(FixedInt6DP left, FixedInt6DP right) =>
            new(left.RawValue - right.RawValue);

        /// <inheritdoc cref="IComparisonOperators{TSelf, TOther, TResult}.op_GreaterThan(TSelf, TOther)" />
        public static bool operator >(FixedInt6DP left, FixedInt6DP right) =>
            left.RawValue > right.RawValue;
        /// <inheritdoc cref="IComparisonOperators{TSelf, TOther, TResult}.op_GreaterThanOrEqual(TSelf, TOther)" />
        public static bool operator >=(FixedInt6DP left, FixedInt6DP right) =>
            left.RawValue >= right.RawValue;

        /// <inheritdoc cref="IComparisonOperators{TSelf, TOther, TResult}.op_LessThan(TSelf, TOther)" />
        public static bool operator <(FixedInt6DP left, FixedInt6DP right) =>
            left.RawValue < right.RawValue;

        /// <inheritdoc cref="IComparisonOperators{TSelf, TOther, TResult}.op_LessThanOrEqual(TSelf, TOther)" />
        public static bool operator <=(FixedInt6DP left, FixedInt6DP right) =>
            left.RawValue <= right.RawValue;

        /// <inheritdoc cref="IDecrementOperators{TSelf}.op_Decrement(TSelf)" />
        public static FixedInt6DP operator --(FixedInt6DP value) => value - One;
        /// <inheritdoc cref="IIncrementOperators{TSelf}.op_Increment(TSelf)" />
        public static FixedInt6DP operator ++(FixedInt6DP value) => value + One;

        /// <inheritdoc cref="IDivisionOperators{TSelf, TOther, TResult}.op_Division(TSelf, TOther)" />
        public static FixedInt6DP operator /(FixedInt6DP left, FixedInt6DP right) =>
            new((int)(left.RawValue * (long)Resolution / right.RawValue));

        /// <inheritdoc cref="IMultiplyOperators{TSelf, TOther, TResult}.op_Multiply(TSelf, TOther)" />
        public static FixedInt6DP operator *(FixedInt6DP left, FixedInt6DP right) =>
            new((int)((long)left.RawValue * right.RawValue / Resolution));

        /// <inheritdoc cref="IModulusOperators{TSelf, TOther, TResult}.op_Modulus(TSelf, TOther)" />
        public static FixedInt6DP operator %(FixedInt6DP left, FixedInt6DP right) =>
            new(left.RawValue % right.RawValue);

        /// <inheritdoc cref="IUnaryNegationOperators{TSelf, TResult}.op_UnaryNegation(TSelf)" />
        public static FixedInt6DP operator -(FixedInt6DP value) => new(-value.RawValue);

        /// <inheritdoc cref="IUnaryPlusOperators{TSelf, TResult}.op_UnaryPlus(TSelf)" />
        public static FixedInt6DP operator +(FixedInt6DP value) => value;

        #endregion

        #region Generic INumberBase Methods

        /// <inheritdoc cref="INumberBase{TSelf}.Abs(TSelf)" />
        public static FixedInt6DP Abs(FixedInt6DP value) => new(Math.Abs(value.RawValue));

        /// <inheritdoc cref="INumberBase{TSelf}.IsCanonical(TSelf)" />
        public static bool IsCanonical(FixedInt6DP value) => true;

        /// <inheritdoc cref="INumberBase{TSelf}.IsComplexNumber(TSelf)" />
        public static bool IsComplexNumber(FixedInt6DP value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsFinite(TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEvenInteger(FixedInt6DP value) =>
            IsInteger(value) & (value.Mantissa & 1) == 0;

        /// <inheritdoc cref="INumberBase{TSelf}.IsFinite(TSelf)" />
        public static bool IsFinite(FixedInt6DP value) => true;

        /// <inheritdoc cref="INumberBase{TSelf}.IsImaginaryNumber(TSelf)" />
        public static bool IsImaginaryNumber(FixedInt6DP value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsInfinity(TSelf)" />
        public static bool IsInfinity(FixedInt6DP value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsInteger(TSelf)" />
        public static bool IsInteger(FixedInt6DP value) => value.Remainder == 0;

        /// <inheritdoc cref="INumberBase{TSelf}.IsNaN(TSelf)" />
        public static bool IsNaN(FixedInt6DP value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsNegative(TSelf)" />
        public static bool IsNegative(FixedInt6DP value) => value.RawValue < 0;

        /// <inheritdoc cref="INumberBase{TSelf}.IsNegativeInfinity(TSelf)" />
        public static bool IsNegativeInfinity(FixedInt6DP value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsNormal(TSelf)" />
        public static bool IsNormal(FixedInt6DP value) => value.RawValue != 0;

        /// <inheritdoc cref="INumberBase{TSelf}.IsOddInteger(TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsOddInteger(FixedInt6DP value) =>
            IsInteger(value) & (value.Mantissa & 1) != 0;

        /// <inheritdoc cref="INumberBase{TSelf}.IsPositive(TSelf)" />
        public static bool IsPositive(FixedInt6DP value) => value.RawValue >= 0;

        /// <inheritdoc cref="INumberBase{TSelf}.IsPositiveInfinity(TSelf)" />
        public static bool IsPositiveInfinity(FixedInt6DP value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsRealNumber(TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsRealNumber(FixedInt6DP value) => true;

        /// <inheritdoc cref="INumberBase{TSelf}.IsSubnormal(TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsSubnormal(FixedInt6DP value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsZero(TSelf)" />
        public static bool IsZero(FixedInt6DP value) => value.RawValue == 0;

        /// <inheritdoc cref="INumberBase{TSelf}.MaxMagnitude(TSelf, TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FixedInt6DP MaxMagnitude(FixedInt6DP x, FixedInt6DP y) =>
            new(int.MaxMagnitude(x.RawValue, y.RawValue));

        /// <inheritdoc cref="INumberBase{TSelf}.MaxMagnitudeNumber(TSelf, TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FixedInt6DP MaxMagnitudeNumber(FixedInt6DP x, FixedInt6DP y) =>
            MaxMagnitude(x, y);

        /// <inheritdoc cref="INumberBase{TSelf}.MinMagnitude(TSelf, TSelf)" />
        public static FixedInt6DP MinMagnitude(FixedInt6DP x, FixedInt6DP y) =>
            new(int.MinMagnitude(x.RawValue, y.RawValue));

        /// <inheritdoc cref="INumberBase{TSelf}.MinMagnitudeNumber(TSelf, TSelf)" />
        public static FixedInt6DP MinMagnitudeNumber(FixedInt6DP x, FixedInt6DP y) =>
            MinMagnitude(x, y);

        /// <summary>
        /// Computes the min value of both.
        /// </summary>
        /// <param name="x">The first value.</param>
        /// <param name="y">The second value.</param>
        /// <returns>The min value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FixedInt6DP Min(FixedInt6DP x, FixedInt6DP y) =>
            new(Math.Min(x.RawValue, y.RawValue));

        /// <summary>
        /// Computes the max value of both.
        /// </summary>
        /// <param name="x">The first value.</param>
        /// <param name="y">The second value.</param>
        /// <returns>The max value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FixedInt6DP Max(FixedInt6DP x, FixedInt6DP y) =>
            new(Math.Max(x.RawValue, y.RawValue));

        #endregion

        #region TryConvert

        /// <inheritdoc cref="INumberBase{TSelf}.TryConvertFromChecked{TOther}(TOther, out TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryConvertFromChecked<TOther>(TOther value, out FixedInt6DP result)
            where TOther : INumberBase<TOther> =>
            TryConvertFrom(value, out result);

        /// <inheritdoc cref="INumberBase{TSelf}.TryConvertFromSaturating{TOther}(TOther, out TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryConvertFromSaturating<TOther>(TOther value, out FixedInt6DP result)
            where TOther : INumberBase<TOther> =>
            TryConvertFrom(value, out result);

        /// <inheritdoc cref="INumberBase{TSelf}.TryConvertFromTruncating{TOther}(TOther, out TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryConvertFromTruncating<TOther>(TOther value, out FixedInt6DP result)
            where TOther : INumberBase<TOther> =>
            TryConvertFrom(value, out result);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool TryConvertFrom<TOther>(TOther value, out FixedInt6DP result)
            where TOther : INumberBase<TOther>
        {
            if (typeof(TOther) == typeof(bool))
            {
                result = Unsafe.As<TOther, bool>(ref value) ? One : Zero;
                return true;
            }
            if (typeof(TOther) == typeof(sbyte))
            {
                result = (FixedInt6DP)Unsafe.As<TOther, sbyte>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(byte))
            {
                result = (FixedInt6DP)Unsafe.As<TOther, byte>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(short))
            {
                result = (FixedInt6DP)Unsafe.As<TOther, short>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(ushort))
            {
                result = (FixedInt6DP)Unsafe.As<TOther, ushort>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(int))
            {
                result = (FixedInt6DP)Unsafe.As<TOther, int>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(uint))
            {
                result = (FixedInt6DP)Unsafe.As<TOther, uint>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(long))
            {
                result = (FixedInt6DP)Unsafe.As<TOther, long>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(ulong))
            {
                result = (FixedInt6DP)Unsafe.As<TOther, ulong>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(System.Int128))
            {
                result = (FixedInt6DP)Unsafe.As<TOther, System.Int128>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(System.UInt128))
            {
                result = (FixedInt6DP)Unsafe.As<TOther, System.UInt128>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(nint))
            {
                result = (FixedInt6DP)Unsafe.As<TOther, nint>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(nuint))
            {
                result = (FixedInt6DP)Unsafe.As<TOther, nuint>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(System.Half))
            {
                result = (FixedInt6DP)Unsafe.As<TOther, System.Half>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(float))
            {
                result = (FixedInt6DP)Unsafe.As<TOther, float>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(double))
            {
                result = (FixedInt6DP)Unsafe.As<TOther, double>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(int))
            {
                result = (FixedInt6DP)Unsafe.As<TOther, int>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(int))
            {
                result = (FixedInt6DP)Unsafe.As<TOther, int>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(int))
            {
                result = (FixedInt6DP)Unsafe.As<TOther, int>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(long))
            {
                result = (FixedInt6DP)Unsafe.As<TOther, long>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(long))
            {
                result = (FixedInt6DP)Unsafe.As<TOther, long>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(long))
            {
                result = (FixedInt6DP)Unsafe.As<TOther, long>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(long))
            {
                result = (FixedInt6DP)Unsafe.As<TOther, long>(ref value);
                return true;
            }

            result = default;
            return false;
        }

        /// <inheritdoc cref="INumberBase{TSelf}.TryConvertToChecked{TOther}(TSelf, out TOther)" />
        public static bool TryConvertToChecked<TOther>(FixedInt6DP value, out TOther result)
            where TOther : INumberBase<TOther> =>
            TryConvertTo(value, out result);

        /// <inheritdoc cref="INumberBase{TSelf}.TryConvertToSaturating{TOther}(TSelf, out TOther)" />
        public static bool TryConvertToSaturating<TOther>(FixedInt6DP value, out TOther result)
            where TOther : INumberBase<TOther> =>
            TryConvertTo(value, out result);

        /// <inheritdoc cref="INumberBase{TSelf}.TryConvertToTruncating{TOther}(TSelf, out TOther)" />
        public static bool TryConvertToTruncating<TOther>(FixedInt6DP value, out TOther result)
            where TOther : INumberBase<TOther> =>
            TryConvertTo(value, out result);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool TryConvertTo<TOther>(FixedInt6DP value, out TOther result)
            where TOther : INumberBase<TOther>
        {
            result = default!;
            if (typeof(TOther) == typeof(bool))
            {
                Unsafe.As<TOther, bool>(ref result) = (bool)value;
                return true;
            }
            if (typeof(TOther) == typeof(sbyte))
            {
                Unsafe.As<TOther, sbyte>(ref result) = (sbyte)value;
                return true;
            }
            if (typeof(TOther) == typeof(byte))
            {
                Unsafe.As<TOther, byte>(ref result) = (byte)value;
                return true;
            }
            if (typeof(TOther) == typeof(short))
            {
                Unsafe.As<TOther, short>(ref result) = (short)value;
                return true;
            }
            if (typeof(TOther) == typeof(ushort))
            {
                Unsafe.As<TOther, ushort>(ref result) = (ushort)value;
                return true;
            }
            if (typeof(TOther) == typeof(int))
            {
                Unsafe.As<TOther, int>(ref result) = (int)value;
                return true;
            }
            if (typeof(TOther) == typeof(uint))
            {
                Unsafe.As<TOther, uint>(ref result) = (uint)value;
                return true;
            }
            if (typeof(TOther) == typeof(long))
            {
                Unsafe.As<TOther, long>(ref result) = (long)value;
                return true;
            }
            if (typeof(TOther) == typeof(ulong))
            {
                Unsafe.As<TOther, ulong>(ref result) = (ulong)value;
                return true;
            }
            if (typeof(TOther) == typeof(System.Int128))
            {
                Unsafe.As<TOther, System.Int128>(ref result) = (System.Int128)value;
                return true;
            }
            if (typeof(TOther) == typeof(System.UInt128))
            {
                Unsafe.As<TOther, System.UInt128>(ref result) = (System.UInt128)value;
                return true;
            }
            if (typeof(TOther) == typeof(nint))
            {
                Unsafe.As<TOther, nint>(ref result) = (nint)value;
                return true;
            }
            if (typeof(TOther) == typeof(nuint))
            {
                Unsafe.As<TOther, nuint>(ref result) = (nuint)value;
                return true;
            }
            if (typeof(TOther) == typeof(System.Half))
            {
                Unsafe.As<TOther, System.Half>(ref result) = (System.Half)value;
                return true;
            }
            if (typeof(TOther) == typeof(float))
            {
                Unsafe.As<TOther, float>(ref result) = (float)value;
                return true;
            }
            if (typeof(TOther) == typeof(double))
            {
                Unsafe.As<TOther, double>(ref result) = (double)value;
                return true;
            }
            if (typeof(TOther) == typeof(FixedInt2DP))
            {
                Unsafe.As<TOther, FixedInt2DP>(ref result) = (FixedInt2DP)value;
                return true;
            }
            if (typeof(TOther) == typeof(FixedInt4DP))
            {
                Unsafe.As<TOther, FixedInt4DP>(ref result) = (FixedInt4DP)value;
                return true;
            }
            if (typeof(TOther) == typeof(FixedInt6DP))
            {
                Unsafe.As<TOther, FixedInt6DP>(ref result) = (FixedInt6DP)value;
                return true;
            }
            if (typeof(TOther) == typeof(FixedLong2DP))
            {
                Unsafe.As<TOther, FixedLong2DP>(ref result) = (FixedLong2DP)value;
                return true;
            }
            if (typeof(TOther) == typeof(FixedLong4DP))
            {
                Unsafe.As<TOther, FixedLong4DP>(ref result) = (FixedLong4DP)value;
                return true;
            }
            if (typeof(TOther) == typeof(FixedLong6DP))
            {
                Unsafe.As<TOther, FixedLong6DP>(ref result) = (FixedLong6DP)value;
                return true;
            }
            if (typeof(TOther) == typeof(FixedLong8DP))
            {
                Unsafe.As<TOther, FixedLong8DP>(ref result) = (FixedLong8DP)value;
                return true;
            }

            result = default!;
            return false;
        }

        #endregion

        #region Parse

        /// <inheritdoc cref="IParsable{TSelf}.TryParse(string?, IFormatProvider?, out TSelf)"/>
        public static bool TryParse(string? s, IFormatProvider? provider, out FixedInt6DP result)
        {
            result = default;
            if (string.IsNullOrWhiteSpace(s))
                return false;
            return TryParse(s.AsSpan(), provider, out result);
        }

        /// <inheritdoc cref="INumberBase{TSelf}.TryParse(ReadOnlySpan{char}, NumberStyles, IFormatProvider?, out TSelf)"/>
        public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out FixedInt6DP result) =>
            TryParse(s, NumberStyles.Integer, provider, out result);

        /// <inheritdoc cref="INumberBase{TSelf}.TryParse(string?, NumberStyles, IFormatProvider? ,out TSelf)"/>
        public static bool TryParse(string? s, NumberStyles style, IFormatProvider? provider, out FixedInt6DP result)
        {
            result = default;
            if (string.IsNullOrWhiteSpace(s))
                return false;
            return TryParse(s.AsSpan(), style, provider, out result);
        }

        /// <inheritdoc cref="ISpanParsable{TSelf}.TryParse(ReadOnlySpan{char}, IFormatProvider?, out TSelf)" />
        public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out FixedInt6DP result)
        {
            result = default;

            var separator = GetDecimalSeparator(provider);
            int decimalSeparator = s.IndexOf(separator.AsSpan());
            if (decimalSeparator < 0)
            {
                // Try parse mantissa part only
                if (!int.TryParse(s, style, provider, out int mantissaOnly))
                    return false;
                result = new(mantissaOnly);
                return true;
            }

            var mantissaPart = s[..decimalSeparator];
            var remainderPart = s[decimalSeparator..];

            if (!int.TryParse(mantissaPart, style, provider, out int mantissa) ||
                !int.TryParse(remainderPart, style, provider, out int remainder))
            {
                return false;
            }

            result = new(mantissa * Resolution + remainder);
            return true;
        }

        /// <inheritdoc cref="IParsable{TSelf}.Parse(string, IFormatProvider?)"/>
        public static FixedInt6DP Parse(string s, IFormatProvider? provider) =>
            Parse(s.AsSpan(), provider);

        /// <inheritdoc cref="INumberBase{TSelf}.Parse(string, NumberStyles, System.IFormatProvider?)"/>
        public static FixedInt6DP Parse(string s, NumberStyles style, IFormatProvider? provider) =>
            Parse(s.AsSpan(), style, provider);

        /// <inheritdoc cref="ISpanParsable{TSelf}.Parse(ReadOnlySpan{char}, IFormatProvider?)" />
        public static FixedInt6DP Parse(ReadOnlySpan<char> s, IFormatProvider? provider) =>
            Parse(s, NumberStyles.Integer, provider);

        /// <inheritdoc cref="INumberBase{TSelf}.Parse(ReadOnlySpan{char}, NumberStyles, System.IFormatProvider?)"/>
        public static FixedInt6DP Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
        {
            if (!TryParse(s, style, provider, out var result))
                throw new FormatException();
            return result;
        }

        #endregion

        #region IComparable

        /// <summary>
        /// Compares the given object to the current instance.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int CompareTo(object? obj) => obj is FixedInt6DP fixedInt ? CompareTo(fixedInt) : 1;

        /// <summary>
        /// Compares the given fixed integer to the current instance.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int CompareTo(FixedInt6DP other) => RawValue.CompareTo(other.RawValue);

        #endregion

        #region ToString and Formats

        /// <summary>
        /// Returns the default string representation of this fixed point value.
        /// </summary>
        public override string ToString() => ToString(null, null);

        /// <summary>
        /// Returns the string representation of this value while taking the given separator into account.
        /// </summary>
        /// <param name="decimalSeparator">The decimal separator to use.</param>
        private string ToString(string decimalSeparator) =>
            $"{Mantissa}{decimalSeparator}{Remainder:000000}";

        /// <summary>
        /// Helper function to get a number format provider instance.
        /// </summary>
        private static string GetDecimalSeparator(IFormatProvider? formatProvider) =>
            NumberFormatInfo.GetInstance(formatProvider).NumberDecimalSeparator;

        /// <inheritdoc cref="IFormattable.ToString(string?,System.IFormatProvider?)"/>
        public string ToString(string? format, IFormatProvider? formatProvider) =>
            ToString(GetDecimalSeparator(formatProvider));

        /// <inheritdoc cref="ISpanFormattable.TryFormat(Span{char}, out int, ReadOnlySpan{char}, IFormatProvider?)"/>
        public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
        {
            if (!Mantissa.TryFormat(destination, out charsWritten, format, provider))
                return false;

            var remainingTarget = destination[charsWritten..];
            var separator = GetDecimalSeparator(provider);
            if (separator.Length > remainingTarget.Length)
                return false;

            separator.CopyTo(remainingTarget);
            charsWritten += separator.Length;

            var decimalPlacesTarget = remainingTarget[separator.Length..];
            bool result = Remainder.TryFormat(
                decimalPlacesTarget,
                out int remainderCharsWritten,
                format,
                provider);
            charsWritten += remainderCharsWritten;
            return result;
        }

        #endregion

        #region Conversion Operators

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator bool(FixedInt6DP fixedInt) => fixedInt.RawValue != 0;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator char(FixedInt6DP fixedInt) => (char)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator sbyte(FixedInt6DP fixedInt) => (sbyte)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator byte(FixedInt6DP fixedInt) => (byte)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator short(FixedInt6DP fixedInt) => (short)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator ushort(FixedInt6DP fixedInt) => (ushort)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator int(FixedInt6DP fixedInt) => (int)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator uint(FixedInt6DP fixedInt) => (uint)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator long(FixedInt6DP fixedInt) => (long)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator Int128(FixedInt6DP fixedInt) => (Int128)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator ulong(FixedInt6DP fixedInt) => (ulong)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator UInt128(FixedInt6DP fixedInt) => (UInt128)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator System.Half(FixedInt6DP fixedInt) =>
            (System.Half)(float)fixedInt;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator float(FixedInt6DP fixedInt) => fixedInt.RawValue * FloatDenominator;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator double(FixedInt6DP fixedInt) =>
            fixedInt.RawValue * DoubleDenominator;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator decimal(FixedInt6DP fixedInt) =>
            fixedInt.RawValue * DecimalDenominator;

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedInt6DP(bool value) => value ? One : Zero;

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedInt6DP(char value) => new((int)value);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedInt6DP(sbyte value) => new(value * Resolution);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedInt6DP(byte value) => new(value * Resolution);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedInt6DP(short value) => new(value * Resolution);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedInt6DP(ushort value) => new(value * Resolution);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedInt6DP(int value) => new(value);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedInt6DP(uint value) => new((int)value);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedInt6DP(long value) => new((int)value);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedInt6DP(Int128 value) => new((int)value);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedInt6DP(ulong value) => new((int)value);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedInt6DP(UInt128 value) => new((int)value);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedInt6DP(System.Half value) =>
            (FixedInt6DP)(float)value;

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedInt6DP(float value)
        {
            int mantissa = (int)value;
            int remainder = (int)(
                MathF.Round(value - MathF.Truncate(value), RoundingDecimalPlaces) * Resolution);
            return new(mantissa * Resolution + remainder);
        }

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedInt6DP(double value)
        {
            int mantissa = (int)value;
            int remainder = (int)(
                Math.Round(value - Math.Truncate(value), RoundingDecimalPlaces) * Resolution);
            return new(mantissa * Resolution + remainder);
        }

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedInt6DP(decimal value)
        {
            int mantissa = (int)value;
            int remainder = (int)(
                Math.Round(value - Math.Truncate(value), RoundingDecimalPlaces) * Resolution);
            return new(mantissa * Resolution + remainder);
        }

        /// <summary>
        /// Converts the given value into its specified fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedInt2DP(FixedInt6DP value)
        {
            var computeVal = (long)value.RawValue;
            var newValue = computeVal * FixedInt2DP.Resolution / Resolution;
            return new((int)newValue);
        }

        /// <summary>
        /// Converts the given value into its specified fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedInt4DP(FixedInt6DP value)
        {
            var computeVal = (long)value.RawValue;
            var newValue = computeVal * FixedInt4DP.Resolution / Resolution;
            return new((int)newValue);
        }

        /// <summary>
        /// Converts the given value into its specified fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedLong2DP(FixedInt6DP value)
        {
            var computeVal = (long)value.RawValue;
            var newValue = computeVal * FixedLong2DP.Resolution / Resolution;
            return new((long)newValue);
        }

        /// <summary>
        /// Converts the given value into its specified fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedLong4DP(FixedInt6DP value)
        {
            var computeVal = (long)value.RawValue;
            var newValue = computeVal * FixedLong4DP.Resolution / Resolution;
            return new((long)newValue);
        }

        /// <summary>
        /// Converts the given value into its specified fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedLong6DP(FixedInt6DP value)
        {
            var computeVal = (long)value.RawValue;
            var newValue = computeVal * FixedLong6DP.Resolution / Resolution;
            return new((long)newValue);
        }

        /// <summary>
        /// Converts the given value into its specified fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedLong8DP(FixedInt6DP value)
        {
            var computeVal = (long)value.RawValue;
            var newValue = computeVal * FixedLong8DP.Resolution / Resolution;
            return new((long)newValue);
        }

        #endregion
    }

    /// <summary>
    /// A fixed precision integer with 64bits using 7 bits
    /// to represent a number with 2 decimal places.
    /// </summary>
    /// <param name="RawValue">The nested raw integer value.</param>
    public readonly record struct FixedLong2DP(long RawValue) :
        INumber<FixedLong2DP>,
        ISignedNumber<FixedLong2DP>,
        IMinMaxValue<FixedLong2DP>
    {
        #region Static

        /// <summary>
        /// Returns the number of decimal places used.
        /// </summary>
        public const int DecimalPlaces = 2;

        /// <summary>
        /// Returns the number of decimal places used to perform rounding.
        /// </summary>
        private const int RoundingDecimalPlaces = 2;

        /// <summary>
        /// Returns the integer-based resolution radix.
        /// </summary>
        public const int Resolution = 100;

        /// <summary>
        /// Returns a float denominator used to convert fixed point values into floats.
        /// </summary>
        public const float FloatDenominator = 1.0f / Resolution;

        /// <summary>
        /// Returns a double denominator used to convert fixed point values into doubles.
        /// </summary>
        public const double DoubleDenominator = 1.0 / Resolution;

        /// <summary>
        /// Returns a decimal denominator used to convert fixed point values into decimals.
        /// </summary>
        public const decimal DecimalDenominator = 1m / Resolution;

        /// <inheritdoc cref="IMinMaxValue{TSelf}.MinValue" />
        public static FixedLong2DP MinValue => new(long.MinValue);

        /// <inheritdoc cref="IMinMaxValue{TSelf}.MaxValue" />
        public static FixedLong2DP MaxValue => new(long.MaxValue);

        /// <summary>
        /// Returns the value 1.
        /// </summary>
        public static FixedLong2DP One => new(Resolution);

        /// <summary>
        /// Returns the radix 2.
        /// </summary>
        public static int Radix => 2;

        /// <summary>
        /// Returns the value 0.
        /// </summary>
        public static FixedLong2DP Zero => new(0);

        /// <summary>
        /// Returns the value 0.
        /// </summary>
        public static FixedLong2DP AdditiveIdentity => Zero;

        /// <summary>
        /// Returns the value -1.
        /// </summary>
        public static FixedLong2DP NegativeOne => new(-Resolution);

        /// <inheritdoc cref="IMultiplicativeIdentity{TSelf, TResult}.MultiplicativeIdentity" />
        public static FixedLong2DP MultiplicativeIdentity => One;

        #endregion

        #region Properties

        /// <summary>
        /// Returns the main mantissa.
        /// </summary>
        public long Mantissa => RawValue / Resolution;

        /// <summary>
        /// Returns all decimal places of this number.
        /// </summary>
        public long Remainder => RawValue % Resolution;

        #endregion

        #region Operators

        /// <inheritdoc cref="IAdditionOperators{TSelf, TOther, TResult}.op_Addition(TSelf, TOther)" />
        public static FixedLong2DP operator +(FixedLong2DP left, FixedLong2DP right) =>
            new(left.RawValue + right.RawValue);

        /// <inheritdoc cref="ISubtractionOperators{TSelf, TOther, TResult}.op_Subtraction(TSelf, TOther)" />
        public static FixedLong2DP operator -(FixedLong2DP left, FixedLong2DP right) =>
            new(left.RawValue - right.RawValue);

        /// <inheritdoc cref="IComparisonOperators{TSelf, TOther, TResult}.op_GreaterThan(TSelf, TOther)" />
        public static bool operator >(FixedLong2DP left, FixedLong2DP right) =>
            left.RawValue > right.RawValue;
        /// <inheritdoc cref="IComparisonOperators{TSelf, TOther, TResult}.op_GreaterThanOrEqual(TSelf, TOther)" />
        public static bool operator >=(FixedLong2DP left, FixedLong2DP right) =>
            left.RawValue >= right.RawValue;

        /// <inheritdoc cref="IComparisonOperators{TSelf, TOther, TResult}.op_LessThan(TSelf, TOther)" />
        public static bool operator <(FixedLong2DP left, FixedLong2DP right) =>
            left.RawValue < right.RawValue;

        /// <inheritdoc cref="IComparisonOperators{TSelf, TOther, TResult}.op_LessThanOrEqual(TSelf, TOther)" />
        public static bool operator <=(FixedLong2DP left, FixedLong2DP right) =>
            left.RawValue <= right.RawValue;

        /// <inheritdoc cref="IDecrementOperators{TSelf}.op_Decrement(TSelf)" />
        public static FixedLong2DP operator --(FixedLong2DP value) => value - One;
        /// <inheritdoc cref="IIncrementOperators{TSelf}.op_Increment(TSelf)" />
        public static FixedLong2DP operator ++(FixedLong2DP value) => value + One;

        /// <inheritdoc cref="IDivisionOperators{TSelf, TOther, TResult}.op_Division(TSelf, TOther)" />
        public static FixedLong2DP operator /(FixedLong2DP left, FixedLong2DP right) =>
            new((long)(left.RawValue * (long)Resolution / right.RawValue));

        /// <inheritdoc cref="IMultiplyOperators{TSelf, TOther, TResult}.op_Multiply(TSelf, TOther)" />
        public static FixedLong2DP operator *(FixedLong2DP left, FixedLong2DP right) =>
            new((long)((long)left.RawValue * right.RawValue / Resolution));

        /// <inheritdoc cref="IModulusOperators{TSelf, TOther, TResult}.op_Modulus(TSelf, TOther)" />
        public static FixedLong2DP operator %(FixedLong2DP left, FixedLong2DP right) =>
            new(left.RawValue % right.RawValue);

        /// <inheritdoc cref="IUnaryNegationOperators{TSelf, TResult}.op_UnaryNegation(TSelf)" />
        public static FixedLong2DP operator -(FixedLong2DP value) => new(-value.RawValue);

        /// <inheritdoc cref="IUnaryPlusOperators{TSelf, TResult}.op_UnaryPlus(TSelf)" />
        public static FixedLong2DP operator +(FixedLong2DP value) => value;

        #endregion

        #region Generic INumberBase Methods

        /// <inheritdoc cref="INumberBase{TSelf}.Abs(TSelf)" />
        public static FixedLong2DP Abs(FixedLong2DP value) => new(Math.Abs(value.RawValue));

        /// <inheritdoc cref="INumberBase{TSelf}.IsCanonical(TSelf)" />
        public static bool IsCanonical(FixedLong2DP value) => true;

        /// <inheritdoc cref="INumberBase{TSelf}.IsComplexNumber(TSelf)" />
        public static bool IsComplexNumber(FixedLong2DP value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsFinite(TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEvenInteger(FixedLong2DP value) =>
            IsInteger(value) & (value.Mantissa & 1) == 0;

        /// <inheritdoc cref="INumberBase{TSelf}.IsFinite(TSelf)" />
        public static bool IsFinite(FixedLong2DP value) => true;

        /// <inheritdoc cref="INumberBase{TSelf}.IsImaginaryNumber(TSelf)" />
        public static bool IsImaginaryNumber(FixedLong2DP value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsInfinity(TSelf)" />
        public static bool IsInfinity(FixedLong2DP value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsInteger(TSelf)" />
        public static bool IsInteger(FixedLong2DP value) => value.Remainder == 0;

        /// <inheritdoc cref="INumberBase{TSelf}.IsNaN(TSelf)" />
        public static bool IsNaN(FixedLong2DP value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsNegative(TSelf)" />
        public static bool IsNegative(FixedLong2DP value) => value.RawValue < 0;

        /// <inheritdoc cref="INumberBase{TSelf}.IsNegativeInfinity(TSelf)" />
        public static bool IsNegativeInfinity(FixedLong2DP value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsNormal(TSelf)" />
        public static bool IsNormal(FixedLong2DP value) => value.RawValue != 0;

        /// <inheritdoc cref="INumberBase{TSelf}.IsOddInteger(TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsOddInteger(FixedLong2DP value) =>
            IsInteger(value) & (value.Mantissa & 1) != 0;

        /// <inheritdoc cref="INumberBase{TSelf}.IsPositive(TSelf)" />
        public static bool IsPositive(FixedLong2DP value) => value.RawValue >= 0;

        /// <inheritdoc cref="INumberBase{TSelf}.IsPositiveInfinity(TSelf)" />
        public static bool IsPositiveInfinity(FixedLong2DP value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsRealNumber(TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsRealNumber(FixedLong2DP value) => true;

        /// <inheritdoc cref="INumberBase{TSelf}.IsSubnormal(TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsSubnormal(FixedLong2DP value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsZero(TSelf)" />
        public static bool IsZero(FixedLong2DP value) => value.RawValue == 0;

        /// <inheritdoc cref="INumberBase{TSelf}.MaxMagnitude(TSelf, TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FixedLong2DP MaxMagnitude(FixedLong2DP x, FixedLong2DP y) =>
            new(long.MaxMagnitude(x.RawValue, y.RawValue));

        /// <inheritdoc cref="INumberBase{TSelf}.MaxMagnitudeNumber(TSelf, TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FixedLong2DP MaxMagnitudeNumber(FixedLong2DP x, FixedLong2DP y) =>
            MaxMagnitude(x, y);

        /// <inheritdoc cref="INumberBase{TSelf}.MinMagnitude(TSelf, TSelf)" />
        public static FixedLong2DP MinMagnitude(FixedLong2DP x, FixedLong2DP y) =>
            new(long.MinMagnitude(x.RawValue, y.RawValue));

        /// <inheritdoc cref="INumberBase{TSelf}.MinMagnitudeNumber(TSelf, TSelf)" />
        public static FixedLong2DP MinMagnitudeNumber(FixedLong2DP x, FixedLong2DP y) =>
            MinMagnitude(x, y);

        /// <summary>
        /// Computes the min value of both.
        /// </summary>
        /// <param name="x">The first value.</param>
        /// <param name="y">The second value.</param>
        /// <returns>The min value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FixedLong2DP Min(FixedLong2DP x, FixedLong2DP y) =>
            new(Math.Min(x.RawValue, y.RawValue));

        /// <summary>
        /// Computes the max value of both.
        /// </summary>
        /// <param name="x">The first value.</param>
        /// <param name="y">The second value.</param>
        /// <returns>The max value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FixedLong2DP Max(FixedLong2DP x, FixedLong2DP y) =>
            new(Math.Max(x.RawValue, y.RawValue));

        #endregion

        #region TryConvert

        /// <inheritdoc cref="INumberBase{TSelf}.TryConvertFromChecked{TOther}(TOther, out TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryConvertFromChecked<TOther>(TOther value, out FixedLong2DP result)
            where TOther : INumberBase<TOther> =>
            TryConvertFrom(value, out result);

        /// <inheritdoc cref="INumberBase{TSelf}.TryConvertFromSaturating{TOther}(TOther, out TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryConvertFromSaturating<TOther>(TOther value, out FixedLong2DP result)
            where TOther : INumberBase<TOther> =>
            TryConvertFrom(value, out result);

        /// <inheritdoc cref="INumberBase{TSelf}.TryConvertFromTruncating{TOther}(TOther, out TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryConvertFromTruncating<TOther>(TOther value, out FixedLong2DP result)
            where TOther : INumberBase<TOther> =>
            TryConvertFrom(value, out result);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool TryConvertFrom<TOther>(TOther value, out FixedLong2DP result)
            where TOther : INumberBase<TOther>
        {
            if (typeof(TOther) == typeof(bool))
            {
                result = Unsafe.As<TOther, bool>(ref value) ? One : Zero;
                return true;
            }
            if (typeof(TOther) == typeof(sbyte))
            {
                result = (FixedLong2DP)Unsafe.As<TOther, sbyte>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(byte))
            {
                result = (FixedLong2DP)Unsafe.As<TOther, byte>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(short))
            {
                result = (FixedLong2DP)Unsafe.As<TOther, short>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(ushort))
            {
                result = (FixedLong2DP)Unsafe.As<TOther, ushort>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(int))
            {
                result = (FixedLong2DP)Unsafe.As<TOther, int>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(uint))
            {
                result = (FixedLong2DP)Unsafe.As<TOther, uint>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(long))
            {
                result = (FixedLong2DP)Unsafe.As<TOther, long>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(ulong))
            {
                result = (FixedLong2DP)Unsafe.As<TOther, ulong>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(System.Int128))
            {
                result = (FixedLong2DP)Unsafe.As<TOther, System.Int128>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(System.UInt128))
            {
                result = (FixedLong2DP)Unsafe.As<TOther, System.UInt128>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(nint))
            {
                result = (FixedLong2DP)Unsafe.As<TOther, nint>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(nuint))
            {
                result = (FixedLong2DP)Unsafe.As<TOther, nuint>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(System.Half))
            {
                result = (FixedLong2DP)Unsafe.As<TOther, System.Half>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(float))
            {
                result = (FixedLong2DP)Unsafe.As<TOther, float>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(double))
            {
                result = (FixedLong2DP)Unsafe.As<TOther, double>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(int))
            {
                result = (FixedLong2DP)Unsafe.As<TOther, int>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(int))
            {
                result = (FixedLong2DP)Unsafe.As<TOther, int>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(int))
            {
                result = (FixedLong2DP)Unsafe.As<TOther, int>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(long))
            {
                result = (FixedLong2DP)Unsafe.As<TOther, long>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(long))
            {
                result = (FixedLong2DP)Unsafe.As<TOther, long>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(long))
            {
                result = (FixedLong2DP)Unsafe.As<TOther, long>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(long))
            {
                result = (FixedLong2DP)Unsafe.As<TOther, long>(ref value);
                return true;
            }

            result = default;
            return false;
        }

        /// <inheritdoc cref="INumberBase{TSelf}.TryConvertToChecked{TOther}(TSelf, out TOther)" />
        public static bool TryConvertToChecked<TOther>(FixedLong2DP value, out TOther result)
            where TOther : INumberBase<TOther> =>
            TryConvertTo(value, out result);

        /// <inheritdoc cref="INumberBase{TSelf}.TryConvertToSaturating{TOther}(TSelf, out TOther)" />
        public static bool TryConvertToSaturating<TOther>(FixedLong2DP value, out TOther result)
            where TOther : INumberBase<TOther> =>
            TryConvertTo(value, out result);

        /// <inheritdoc cref="INumberBase{TSelf}.TryConvertToTruncating{TOther}(TSelf, out TOther)" />
        public static bool TryConvertToTruncating<TOther>(FixedLong2DP value, out TOther result)
            where TOther : INumberBase<TOther> =>
            TryConvertTo(value, out result);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool TryConvertTo<TOther>(FixedLong2DP value, out TOther result)
            where TOther : INumberBase<TOther>
        {
            result = default!;
            if (typeof(TOther) == typeof(bool))
            {
                Unsafe.As<TOther, bool>(ref result) = (bool)value;
                return true;
            }
            if (typeof(TOther) == typeof(sbyte))
            {
                Unsafe.As<TOther, sbyte>(ref result) = (sbyte)value;
                return true;
            }
            if (typeof(TOther) == typeof(byte))
            {
                Unsafe.As<TOther, byte>(ref result) = (byte)value;
                return true;
            }
            if (typeof(TOther) == typeof(short))
            {
                Unsafe.As<TOther, short>(ref result) = (short)value;
                return true;
            }
            if (typeof(TOther) == typeof(ushort))
            {
                Unsafe.As<TOther, ushort>(ref result) = (ushort)value;
                return true;
            }
            if (typeof(TOther) == typeof(int))
            {
                Unsafe.As<TOther, int>(ref result) = (int)value;
                return true;
            }
            if (typeof(TOther) == typeof(uint))
            {
                Unsafe.As<TOther, uint>(ref result) = (uint)value;
                return true;
            }
            if (typeof(TOther) == typeof(long))
            {
                Unsafe.As<TOther, long>(ref result) = (long)value;
                return true;
            }
            if (typeof(TOther) == typeof(ulong))
            {
                Unsafe.As<TOther, ulong>(ref result) = (ulong)value;
                return true;
            }
            if (typeof(TOther) == typeof(System.Int128))
            {
                Unsafe.As<TOther, System.Int128>(ref result) = (System.Int128)value;
                return true;
            }
            if (typeof(TOther) == typeof(System.UInt128))
            {
                Unsafe.As<TOther, System.UInt128>(ref result) = (System.UInt128)value;
                return true;
            }
            if (typeof(TOther) == typeof(nint))
            {
                Unsafe.As<TOther, nint>(ref result) = (nint)value;
                return true;
            }
            if (typeof(TOther) == typeof(nuint))
            {
                Unsafe.As<TOther, nuint>(ref result) = (nuint)value;
                return true;
            }
            if (typeof(TOther) == typeof(System.Half))
            {
                Unsafe.As<TOther, System.Half>(ref result) = (System.Half)value;
                return true;
            }
            if (typeof(TOther) == typeof(float))
            {
                Unsafe.As<TOther, float>(ref result) = (float)value;
                return true;
            }
            if (typeof(TOther) == typeof(double))
            {
                Unsafe.As<TOther, double>(ref result) = (double)value;
                return true;
            }
            if (typeof(TOther) == typeof(FixedInt2DP))
            {
                Unsafe.As<TOther, FixedInt2DP>(ref result) = (FixedInt2DP)value;
                return true;
            }
            if (typeof(TOther) == typeof(FixedInt4DP))
            {
                Unsafe.As<TOther, FixedInt4DP>(ref result) = (FixedInt4DP)value;
                return true;
            }
            if (typeof(TOther) == typeof(FixedInt6DP))
            {
                Unsafe.As<TOther, FixedInt6DP>(ref result) = (FixedInt6DP)value;
                return true;
            }
            if (typeof(TOther) == typeof(FixedLong2DP))
            {
                Unsafe.As<TOther, FixedLong2DP>(ref result) = (FixedLong2DP)value;
                return true;
            }
            if (typeof(TOther) == typeof(FixedLong4DP))
            {
                Unsafe.As<TOther, FixedLong4DP>(ref result) = (FixedLong4DP)value;
                return true;
            }
            if (typeof(TOther) == typeof(FixedLong6DP))
            {
                Unsafe.As<TOther, FixedLong6DP>(ref result) = (FixedLong6DP)value;
                return true;
            }
            if (typeof(TOther) == typeof(FixedLong8DP))
            {
                Unsafe.As<TOther, FixedLong8DP>(ref result) = (FixedLong8DP)value;
                return true;
            }

            result = default!;
            return false;
        }

        #endregion

        #region Parse

        /// <inheritdoc cref="IParsable{TSelf}.TryParse(string?, IFormatProvider?, out TSelf)"/>
        public static bool TryParse(string? s, IFormatProvider? provider, out FixedLong2DP result)
        {
            result = default;
            if (string.IsNullOrWhiteSpace(s))
                return false;
            return TryParse(s.AsSpan(), provider, out result);
        }

        /// <inheritdoc cref="INumberBase{TSelf}.TryParse(ReadOnlySpan{char}, NumberStyles, IFormatProvider?, out TSelf)"/>
        public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out FixedLong2DP result) =>
            TryParse(s, NumberStyles.Integer, provider, out result);

        /// <inheritdoc cref="INumberBase{TSelf}.TryParse(string?, NumberStyles, IFormatProvider? ,out TSelf)"/>
        public static bool TryParse(string? s, NumberStyles style, IFormatProvider? provider, out FixedLong2DP result)
        {
            result = default;
            if (string.IsNullOrWhiteSpace(s))
                return false;
            return TryParse(s.AsSpan(), style, provider, out result);
        }

        /// <inheritdoc cref="ISpanParsable{TSelf}.TryParse(ReadOnlySpan{char}, IFormatProvider?, out TSelf)" />
        public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out FixedLong2DP result)
        {
            result = default;

            var separator = GetDecimalSeparator(provider);
            int decimalSeparator = s.IndexOf(separator.AsSpan());
            if (decimalSeparator < 0)
            {
                // Try parse mantissa part only
                if (!long.TryParse(s, style, provider, out long mantissaOnly))
                    return false;
                result = new(mantissaOnly);
                return true;
            }

            var mantissaPart = s[..decimalSeparator];
            var remainderPart = s[decimalSeparator..];

            if (!long.TryParse(mantissaPart, style, provider, out long mantissa) ||
                !long.TryParse(remainderPart, style, provider, out long remainder))
            {
                return false;
            }

            result = new(mantissa * Resolution + remainder);
            return true;
        }

        /// <inheritdoc cref="IParsable{TSelf}.Parse(string, IFormatProvider?)"/>
        public static FixedLong2DP Parse(string s, IFormatProvider? provider) =>
            Parse(s.AsSpan(), provider);

        /// <inheritdoc cref="INumberBase{TSelf}.Parse(string, NumberStyles, System.IFormatProvider?)"/>
        public static FixedLong2DP Parse(string s, NumberStyles style, IFormatProvider? provider) =>
            Parse(s.AsSpan(), style, provider);

        /// <inheritdoc cref="ISpanParsable{TSelf}.Parse(ReadOnlySpan{char}, IFormatProvider?)" />
        public static FixedLong2DP Parse(ReadOnlySpan<char> s, IFormatProvider? provider) =>
            Parse(s, NumberStyles.Integer, provider);

        /// <inheritdoc cref="INumberBase{TSelf}.Parse(ReadOnlySpan{char}, NumberStyles, System.IFormatProvider?)"/>
        public static FixedLong2DP Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
        {
            if (!TryParse(s, style, provider, out var result))
                throw new FormatException();
            return result;
        }

        #endregion

        #region IComparable

        /// <summary>
        /// Compares the given object to the current instance.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int CompareTo(object? obj) => obj is FixedLong2DP fixedInt ? CompareTo(fixedInt) : 1;

        /// <summary>
        /// Compares the given fixed integer to the current instance.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int CompareTo(FixedLong2DP other) => RawValue.CompareTo(other.RawValue);

        #endregion

        #region ToString and Formats

        /// <summary>
        /// Returns the default string representation of this fixed point value.
        /// </summary>
        public override string ToString() => ToString(null, null);

        /// <summary>
        /// Returns the string representation of this value while taking the given separator into account.
        /// </summary>
        /// <param name="decimalSeparator">The decimal separator to use.</param>
        private string ToString(string decimalSeparator) =>
            $"{Mantissa}{decimalSeparator}{Remainder:00}";

        /// <summary>
        /// Helper function to get a number format provider instance.
        /// </summary>
        private static string GetDecimalSeparator(IFormatProvider? formatProvider) =>
            NumberFormatInfo.GetInstance(formatProvider).NumberDecimalSeparator;

        /// <inheritdoc cref="IFormattable.ToString(string?,System.IFormatProvider?)"/>
        public string ToString(string? format, IFormatProvider? formatProvider) =>
            ToString(GetDecimalSeparator(formatProvider));

        /// <inheritdoc cref="ISpanFormattable.TryFormat(Span{char}, out int, ReadOnlySpan{char}, IFormatProvider?)"/>
        public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
        {
            if (!Mantissa.TryFormat(destination, out charsWritten, format, provider))
                return false;

            var remainingTarget = destination[charsWritten..];
            var separator = GetDecimalSeparator(provider);
            if (separator.Length > remainingTarget.Length)
                return false;

            separator.CopyTo(remainingTarget);
            charsWritten += separator.Length;

            var decimalPlacesTarget = remainingTarget[separator.Length..];
            bool result = Remainder.TryFormat(
                decimalPlacesTarget,
                out int remainderCharsWritten,
                format,
                provider);
            charsWritten += remainderCharsWritten;
            return result;
        }

        #endregion

        #region Conversion Operators

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator bool(FixedLong2DP fixedInt) => fixedInt.RawValue != 0;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator char(FixedLong2DP fixedInt) => (char)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator sbyte(FixedLong2DP fixedInt) => (sbyte)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator byte(FixedLong2DP fixedInt) => (byte)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator short(FixedLong2DP fixedInt) => (short)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator ushort(FixedLong2DP fixedInt) => (ushort)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator int(FixedLong2DP fixedInt) => (int)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator uint(FixedLong2DP fixedInt) => (uint)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator long(FixedLong2DP fixedInt) => (long)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator Int128(FixedLong2DP fixedInt) => (Int128)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator ulong(FixedLong2DP fixedInt) => (ulong)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator UInt128(FixedLong2DP fixedInt) => (UInt128)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator System.Half(FixedLong2DP fixedInt) =>
            (System.Half)(float)fixedInt;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator float(FixedLong2DP fixedInt) => fixedInt.RawValue * FloatDenominator;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator double(FixedLong2DP fixedInt) =>
            fixedInt.RawValue * DoubleDenominator;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator decimal(FixedLong2DP fixedInt) =>
            fixedInt.RawValue * DecimalDenominator;

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedLong2DP(bool value) => value ? One : Zero;

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedLong2DP(char value) => new((long)value);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedLong2DP(sbyte value) => new(value * Resolution);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedLong2DP(byte value) => new(value * Resolution);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedLong2DP(short value) => new(value * Resolution);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedLong2DP(ushort value) => new(value * Resolution);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedLong2DP(int value) => new(value);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedLong2DP(uint value) => new((long)value);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedLong2DP(long value) => new((long)value);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedLong2DP(Int128 value) => new((long)value);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedLong2DP(ulong value) => new((long)value);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedLong2DP(UInt128 value) => new((long)value);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedLong2DP(System.Half value) =>
            (FixedLong2DP)(float)value;

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedLong2DP(float value)
        {
            long mantissa = (long)value;
            long remainder = (long)(
                MathF.Round(value - MathF.Truncate(value), RoundingDecimalPlaces) * Resolution);
            return new(mantissa * Resolution + remainder);
        }

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedLong2DP(double value)
        {
            long mantissa = (long)value;
            long remainder = (long)(
                Math.Round(value - Math.Truncate(value), RoundingDecimalPlaces) * Resolution);
            return new(mantissa * Resolution + remainder);
        }

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedLong2DP(decimal value)
        {
            long mantissa = (long)value;
            long remainder = (long)(
                Math.Round(value - Math.Truncate(value), RoundingDecimalPlaces) * Resolution);
            return new(mantissa * Resolution + remainder);
        }

        /// <summary>
        /// Converts the given value into its specified fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedInt2DP(FixedLong2DP value)
        {
            var computeVal = (long)value.RawValue;
            var newValue = computeVal * FixedInt2DP.Resolution / Resolution;
            return new((int)newValue);
        }

        /// <summary>
        /// Converts the given value into its specified fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedInt4DP(FixedLong2DP value)
        {
            var computeVal = (long)value.RawValue;
            var newValue = computeVal * FixedInt4DP.Resolution / Resolution;
            return new((int)newValue);
        }

        /// <summary>
        /// Converts the given value into its specified fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedInt6DP(FixedLong2DP value)
        {
            var computeVal = (long)value.RawValue;
            var newValue = computeVal * FixedInt6DP.Resolution / Resolution;
            return new((int)newValue);
        }

        /// <summary>
        /// Converts the given value into its specified fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedLong4DP(FixedLong2DP value)
        {
            var computeVal = (long)value.RawValue;
            var newValue = computeVal * FixedLong4DP.Resolution / Resolution;
            return new((long)newValue);
        }

        /// <summary>
        /// Converts the given value into its specified fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedLong6DP(FixedLong2DP value)
        {
            var computeVal = (long)value.RawValue;
            var newValue = computeVal * FixedLong6DP.Resolution / Resolution;
            return new((long)newValue);
        }

        /// <summary>
        /// Converts the given value into its specified fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedLong8DP(FixedLong2DP value)
        {
            var computeVal = (long)value.RawValue;
            var newValue = computeVal * FixedLong8DP.Resolution / Resolution;
            return new((long)newValue);
        }

        #endregion
    }

    /// <summary>
    /// A fixed precision integer with 64bits using 14 bits
    /// to represent a number with 4 decimal places.
    /// </summary>
    /// <param name="RawValue">The nested raw integer value.</param>
    public readonly record struct FixedLong4DP(long RawValue) :
        INumber<FixedLong4DP>,
        ISignedNumber<FixedLong4DP>,
        IMinMaxValue<FixedLong4DP>
    {
        #region Static

        /// <summary>
        /// Returns the number of decimal places used.
        /// </summary>
        public const int DecimalPlaces = 4;

        /// <summary>
        /// Returns the number of decimal places used to perform rounding.
        /// </summary>
        private const int RoundingDecimalPlaces = 4;

        /// <summary>
        /// Returns the integer-based resolution radix.
        /// </summary>
        public const int Resolution = 10000;

        /// <summary>
        /// Returns a float denominator used to convert fixed point values into floats.
        /// </summary>
        public const float FloatDenominator = 1.0f / Resolution;

        /// <summary>
        /// Returns a double denominator used to convert fixed point values into doubles.
        /// </summary>
        public const double DoubleDenominator = 1.0 / Resolution;

        /// <summary>
        /// Returns a decimal denominator used to convert fixed point values into decimals.
        /// </summary>
        public const decimal DecimalDenominator = 1m / Resolution;

        /// <inheritdoc cref="IMinMaxValue{TSelf}.MinValue" />
        public static FixedLong4DP MinValue => new(long.MinValue);

        /// <inheritdoc cref="IMinMaxValue{TSelf}.MaxValue" />
        public static FixedLong4DP MaxValue => new(long.MaxValue);

        /// <summary>
        /// Returns the value 1.
        /// </summary>
        public static FixedLong4DP One => new(Resolution);

        /// <summary>
        /// Returns the radix 2.
        /// </summary>
        public static int Radix => 2;

        /// <summary>
        /// Returns the value 0.
        /// </summary>
        public static FixedLong4DP Zero => new(0);

        /// <summary>
        /// Returns the value 0.
        /// </summary>
        public static FixedLong4DP AdditiveIdentity => Zero;

        /// <summary>
        /// Returns the value -1.
        /// </summary>
        public static FixedLong4DP NegativeOne => new(-Resolution);

        /// <inheritdoc cref="IMultiplicativeIdentity{TSelf, TResult}.MultiplicativeIdentity" />
        public static FixedLong4DP MultiplicativeIdentity => One;

        #endregion

        #region Properties

        /// <summary>
        /// Returns the main mantissa.
        /// </summary>
        public long Mantissa => RawValue / Resolution;

        /// <summary>
        /// Returns all decimal places of this number.
        /// </summary>
        public long Remainder => RawValue % Resolution;

        #endregion

        #region Operators

        /// <inheritdoc cref="IAdditionOperators{TSelf, TOther, TResult}.op_Addition(TSelf, TOther)" />
        public static FixedLong4DP operator +(FixedLong4DP left, FixedLong4DP right) =>
            new(left.RawValue + right.RawValue);

        /// <inheritdoc cref="ISubtractionOperators{TSelf, TOther, TResult}.op_Subtraction(TSelf, TOther)" />
        public static FixedLong4DP operator -(FixedLong4DP left, FixedLong4DP right) =>
            new(left.RawValue - right.RawValue);

        /// <inheritdoc cref="IComparisonOperators{TSelf, TOther, TResult}.op_GreaterThan(TSelf, TOther)" />
        public static bool operator >(FixedLong4DP left, FixedLong4DP right) =>
            left.RawValue > right.RawValue;
        /// <inheritdoc cref="IComparisonOperators{TSelf, TOther, TResult}.op_GreaterThanOrEqual(TSelf, TOther)" />
        public static bool operator >=(FixedLong4DP left, FixedLong4DP right) =>
            left.RawValue >= right.RawValue;

        /// <inheritdoc cref="IComparisonOperators{TSelf, TOther, TResult}.op_LessThan(TSelf, TOther)" />
        public static bool operator <(FixedLong4DP left, FixedLong4DP right) =>
            left.RawValue < right.RawValue;

        /// <inheritdoc cref="IComparisonOperators{TSelf, TOther, TResult}.op_LessThanOrEqual(TSelf, TOther)" />
        public static bool operator <=(FixedLong4DP left, FixedLong4DP right) =>
            left.RawValue <= right.RawValue;

        /// <inheritdoc cref="IDecrementOperators{TSelf}.op_Decrement(TSelf)" />
        public static FixedLong4DP operator --(FixedLong4DP value) => value - One;
        /// <inheritdoc cref="IIncrementOperators{TSelf}.op_Increment(TSelf)" />
        public static FixedLong4DP operator ++(FixedLong4DP value) => value + One;

        /// <inheritdoc cref="IDivisionOperators{TSelf, TOther, TResult}.op_Division(TSelf, TOther)" />
        public static FixedLong4DP operator /(FixedLong4DP left, FixedLong4DP right) =>
            new((long)(left.RawValue * (long)Resolution / right.RawValue));

        /// <inheritdoc cref="IMultiplyOperators{TSelf, TOther, TResult}.op_Multiply(TSelf, TOther)" />
        public static FixedLong4DP operator *(FixedLong4DP left, FixedLong4DP right) =>
            new((long)((long)left.RawValue * right.RawValue / Resolution));

        /// <inheritdoc cref="IModulusOperators{TSelf, TOther, TResult}.op_Modulus(TSelf, TOther)" />
        public static FixedLong4DP operator %(FixedLong4DP left, FixedLong4DP right) =>
            new(left.RawValue % right.RawValue);

        /// <inheritdoc cref="IUnaryNegationOperators{TSelf, TResult}.op_UnaryNegation(TSelf)" />
        public static FixedLong4DP operator -(FixedLong4DP value) => new(-value.RawValue);

        /// <inheritdoc cref="IUnaryPlusOperators{TSelf, TResult}.op_UnaryPlus(TSelf)" />
        public static FixedLong4DP operator +(FixedLong4DP value) => value;

        #endregion

        #region Generic INumberBase Methods

        /// <inheritdoc cref="INumberBase{TSelf}.Abs(TSelf)" />
        public static FixedLong4DP Abs(FixedLong4DP value) => new(Math.Abs(value.RawValue));

        /// <inheritdoc cref="INumberBase{TSelf}.IsCanonical(TSelf)" />
        public static bool IsCanonical(FixedLong4DP value) => true;

        /// <inheritdoc cref="INumberBase{TSelf}.IsComplexNumber(TSelf)" />
        public static bool IsComplexNumber(FixedLong4DP value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsFinite(TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEvenInteger(FixedLong4DP value) =>
            IsInteger(value) & (value.Mantissa & 1) == 0;

        /// <inheritdoc cref="INumberBase{TSelf}.IsFinite(TSelf)" />
        public static bool IsFinite(FixedLong4DP value) => true;

        /// <inheritdoc cref="INumberBase{TSelf}.IsImaginaryNumber(TSelf)" />
        public static bool IsImaginaryNumber(FixedLong4DP value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsInfinity(TSelf)" />
        public static bool IsInfinity(FixedLong4DP value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsInteger(TSelf)" />
        public static bool IsInteger(FixedLong4DP value) => value.Remainder == 0;

        /// <inheritdoc cref="INumberBase{TSelf}.IsNaN(TSelf)" />
        public static bool IsNaN(FixedLong4DP value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsNegative(TSelf)" />
        public static bool IsNegative(FixedLong4DP value) => value.RawValue < 0;

        /// <inheritdoc cref="INumberBase{TSelf}.IsNegativeInfinity(TSelf)" />
        public static bool IsNegativeInfinity(FixedLong4DP value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsNormal(TSelf)" />
        public static bool IsNormal(FixedLong4DP value) => value.RawValue != 0;

        /// <inheritdoc cref="INumberBase{TSelf}.IsOddInteger(TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsOddInteger(FixedLong4DP value) =>
            IsInteger(value) & (value.Mantissa & 1) != 0;

        /// <inheritdoc cref="INumberBase{TSelf}.IsPositive(TSelf)" />
        public static bool IsPositive(FixedLong4DP value) => value.RawValue >= 0;

        /// <inheritdoc cref="INumberBase{TSelf}.IsPositiveInfinity(TSelf)" />
        public static bool IsPositiveInfinity(FixedLong4DP value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsRealNumber(TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsRealNumber(FixedLong4DP value) => true;

        /// <inheritdoc cref="INumberBase{TSelf}.IsSubnormal(TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsSubnormal(FixedLong4DP value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsZero(TSelf)" />
        public static bool IsZero(FixedLong4DP value) => value.RawValue == 0;

        /// <inheritdoc cref="INumberBase{TSelf}.MaxMagnitude(TSelf, TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FixedLong4DP MaxMagnitude(FixedLong4DP x, FixedLong4DP y) =>
            new(long.MaxMagnitude(x.RawValue, y.RawValue));

        /// <inheritdoc cref="INumberBase{TSelf}.MaxMagnitudeNumber(TSelf, TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FixedLong4DP MaxMagnitudeNumber(FixedLong4DP x, FixedLong4DP y) =>
            MaxMagnitude(x, y);

        /// <inheritdoc cref="INumberBase{TSelf}.MinMagnitude(TSelf, TSelf)" />
        public static FixedLong4DP MinMagnitude(FixedLong4DP x, FixedLong4DP y) =>
            new(long.MinMagnitude(x.RawValue, y.RawValue));

        /// <inheritdoc cref="INumberBase{TSelf}.MinMagnitudeNumber(TSelf, TSelf)" />
        public static FixedLong4DP MinMagnitudeNumber(FixedLong4DP x, FixedLong4DP y) =>
            MinMagnitude(x, y);

        /// <summary>
        /// Computes the min value of both.
        /// </summary>
        /// <param name="x">The first value.</param>
        /// <param name="y">The second value.</param>
        /// <returns>The min value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FixedLong4DP Min(FixedLong4DP x, FixedLong4DP y) =>
            new(Math.Min(x.RawValue, y.RawValue));

        /// <summary>
        /// Computes the max value of both.
        /// </summary>
        /// <param name="x">The first value.</param>
        /// <param name="y">The second value.</param>
        /// <returns>The max value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FixedLong4DP Max(FixedLong4DP x, FixedLong4DP y) =>
            new(Math.Max(x.RawValue, y.RawValue));

        #endregion

        #region TryConvert

        /// <inheritdoc cref="INumberBase{TSelf}.TryConvertFromChecked{TOther}(TOther, out TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryConvertFromChecked<TOther>(TOther value, out FixedLong4DP result)
            where TOther : INumberBase<TOther> =>
            TryConvertFrom(value, out result);

        /// <inheritdoc cref="INumberBase{TSelf}.TryConvertFromSaturating{TOther}(TOther, out TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryConvertFromSaturating<TOther>(TOther value, out FixedLong4DP result)
            where TOther : INumberBase<TOther> =>
            TryConvertFrom(value, out result);

        /// <inheritdoc cref="INumberBase{TSelf}.TryConvertFromTruncating{TOther}(TOther, out TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryConvertFromTruncating<TOther>(TOther value, out FixedLong4DP result)
            where TOther : INumberBase<TOther> =>
            TryConvertFrom(value, out result);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool TryConvertFrom<TOther>(TOther value, out FixedLong4DP result)
            where TOther : INumberBase<TOther>
        {
            if (typeof(TOther) == typeof(bool))
            {
                result = Unsafe.As<TOther, bool>(ref value) ? One : Zero;
                return true;
            }
            if (typeof(TOther) == typeof(sbyte))
            {
                result = (FixedLong4DP)Unsafe.As<TOther, sbyte>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(byte))
            {
                result = (FixedLong4DP)Unsafe.As<TOther, byte>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(short))
            {
                result = (FixedLong4DP)Unsafe.As<TOther, short>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(ushort))
            {
                result = (FixedLong4DP)Unsafe.As<TOther, ushort>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(int))
            {
                result = (FixedLong4DP)Unsafe.As<TOther, int>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(uint))
            {
                result = (FixedLong4DP)Unsafe.As<TOther, uint>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(long))
            {
                result = (FixedLong4DP)Unsafe.As<TOther, long>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(ulong))
            {
                result = (FixedLong4DP)Unsafe.As<TOther, ulong>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(System.Int128))
            {
                result = (FixedLong4DP)Unsafe.As<TOther, System.Int128>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(System.UInt128))
            {
                result = (FixedLong4DP)Unsafe.As<TOther, System.UInt128>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(nint))
            {
                result = (FixedLong4DP)Unsafe.As<TOther, nint>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(nuint))
            {
                result = (FixedLong4DP)Unsafe.As<TOther, nuint>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(System.Half))
            {
                result = (FixedLong4DP)Unsafe.As<TOther, System.Half>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(float))
            {
                result = (FixedLong4DP)Unsafe.As<TOther, float>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(double))
            {
                result = (FixedLong4DP)Unsafe.As<TOther, double>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(int))
            {
                result = (FixedLong4DP)Unsafe.As<TOther, int>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(int))
            {
                result = (FixedLong4DP)Unsafe.As<TOther, int>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(int))
            {
                result = (FixedLong4DP)Unsafe.As<TOther, int>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(long))
            {
                result = (FixedLong4DP)Unsafe.As<TOther, long>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(long))
            {
                result = (FixedLong4DP)Unsafe.As<TOther, long>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(long))
            {
                result = (FixedLong4DP)Unsafe.As<TOther, long>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(long))
            {
                result = (FixedLong4DP)Unsafe.As<TOther, long>(ref value);
                return true;
            }

            result = default;
            return false;
        }

        /// <inheritdoc cref="INumberBase{TSelf}.TryConvertToChecked{TOther}(TSelf, out TOther)" />
        public static bool TryConvertToChecked<TOther>(FixedLong4DP value, out TOther result)
            where TOther : INumberBase<TOther> =>
            TryConvertTo(value, out result);

        /// <inheritdoc cref="INumberBase{TSelf}.TryConvertToSaturating{TOther}(TSelf, out TOther)" />
        public static bool TryConvertToSaturating<TOther>(FixedLong4DP value, out TOther result)
            where TOther : INumberBase<TOther> =>
            TryConvertTo(value, out result);

        /// <inheritdoc cref="INumberBase{TSelf}.TryConvertToTruncating{TOther}(TSelf, out TOther)" />
        public static bool TryConvertToTruncating<TOther>(FixedLong4DP value, out TOther result)
            where TOther : INumberBase<TOther> =>
            TryConvertTo(value, out result);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool TryConvertTo<TOther>(FixedLong4DP value, out TOther result)
            where TOther : INumberBase<TOther>
        {
            result = default!;
            if (typeof(TOther) == typeof(bool))
            {
                Unsafe.As<TOther, bool>(ref result) = (bool)value;
                return true;
            }
            if (typeof(TOther) == typeof(sbyte))
            {
                Unsafe.As<TOther, sbyte>(ref result) = (sbyte)value;
                return true;
            }
            if (typeof(TOther) == typeof(byte))
            {
                Unsafe.As<TOther, byte>(ref result) = (byte)value;
                return true;
            }
            if (typeof(TOther) == typeof(short))
            {
                Unsafe.As<TOther, short>(ref result) = (short)value;
                return true;
            }
            if (typeof(TOther) == typeof(ushort))
            {
                Unsafe.As<TOther, ushort>(ref result) = (ushort)value;
                return true;
            }
            if (typeof(TOther) == typeof(int))
            {
                Unsafe.As<TOther, int>(ref result) = (int)value;
                return true;
            }
            if (typeof(TOther) == typeof(uint))
            {
                Unsafe.As<TOther, uint>(ref result) = (uint)value;
                return true;
            }
            if (typeof(TOther) == typeof(long))
            {
                Unsafe.As<TOther, long>(ref result) = (long)value;
                return true;
            }
            if (typeof(TOther) == typeof(ulong))
            {
                Unsafe.As<TOther, ulong>(ref result) = (ulong)value;
                return true;
            }
            if (typeof(TOther) == typeof(System.Int128))
            {
                Unsafe.As<TOther, System.Int128>(ref result) = (System.Int128)value;
                return true;
            }
            if (typeof(TOther) == typeof(System.UInt128))
            {
                Unsafe.As<TOther, System.UInt128>(ref result) = (System.UInt128)value;
                return true;
            }
            if (typeof(TOther) == typeof(nint))
            {
                Unsafe.As<TOther, nint>(ref result) = (nint)value;
                return true;
            }
            if (typeof(TOther) == typeof(nuint))
            {
                Unsafe.As<TOther, nuint>(ref result) = (nuint)value;
                return true;
            }
            if (typeof(TOther) == typeof(System.Half))
            {
                Unsafe.As<TOther, System.Half>(ref result) = (System.Half)value;
                return true;
            }
            if (typeof(TOther) == typeof(float))
            {
                Unsafe.As<TOther, float>(ref result) = (float)value;
                return true;
            }
            if (typeof(TOther) == typeof(double))
            {
                Unsafe.As<TOther, double>(ref result) = (double)value;
                return true;
            }
            if (typeof(TOther) == typeof(FixedInt2DP))
            {
                Unsafe.As<TOther, FixedInt2DP>(ref result) = (FixedInt2DP)value;
                return true;
            }
            if (typeof(TOther) == typeof(FixedInt4DP))
            {
                Unsafe.As<TOther, FixedInt4DP>(ref result) = (FixedInt4DP)value;
                return true;
            }
            if (typeof(TOther) == typeof(FixedInt6DP))
            {
                Unsafe.As<TOther, FixedInt6DP>(ref result) = (FixedInt6DP)value;
                return true;
            }
            if (typeof(TOther) == typeof(FixedLong2DP))
            {
                Unsafe.As<TOther, FixedLong2DP>(ref result) = (FixedLong2DP)value;
                return true;
            }
            if (typeof(TOther) == typeof(FixedLong4DP))
            {
                Unsafe.As<TOther, FixedLong4DP>(ref result) = (FixedLong4DP)value;
                return true;
            }
            if (typeof(TOther) == typeof(FixedLong6DP))
            {
                Unsafe.As<TOther, FixedLong6DP>(ref result) = (FixedLong6DP)value;
                return true;
            }
            if (typeof(TOther) == typeof(FixedLong8DP))
            {
                Unsafe.As<TOther, FixedLong8DP>(ref result) = (FixedLong8DP)value;
                return true;
            }

            result = default!;
            return false;
        }

        #endregion

        #region Parse

        /// <inheritdoc cref="IParsable{TSelf}.TryParse(string?, IFormatProvider?, out TSelf)"/>
        public static bool TryParse(string? s, IFormatProvider? provider, out FixedLong4DP result)
        {
            result = default;
            if (string.IsNullOrWhiteSpace(s))
                return false;
            return TryParse(s.AsSpan(), provider, out result);
        }

        /// <inheritdoc cref="INumberBase{TSelf}.TryParse(ReadOnlySpan{char}, NumberStyles, IFormatProvider?, out TSelf)"/>
        public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out FixedLong4DP result) =>
            TryParse(s, NumberStyles.Integer, provider, out result);

        /// <inheritdoc cref="INumberBase{TSelf}.TryParse(string?, NumberStyles, IFormatProvider? ,out TSelf)"/>
        public static bool TryParse(string? s, NumberStyles style, IFormatProvider? provider, out FixedLong4DP result)
        {
            result = default;
            if (string.IsNullOrWhiteSpace(s))
                return false;
            return TryParse(s.AsSpan(), style, provider, out result);
        }

        /// <inheritdoc cref="ISpanParsable{TSelf}.TryParse(ReadOnlySpan{char}, IFormatProvider?, out TSelf)" />
        public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out FixedLong4DP result)
        {
            result = default;

            var separator = GetDecimalSeparator(provider);
            int decimalSeparator = s.IndexOf(separator.AsSpan());
            if (decimalSeparator < 0)
            {
                // Try parse mantissa part only
                if (!long.TryParse(s, style, provider, out long mantissaOnly))
                    return false;
                result = new(mantissaOnly);
                return true;
            }

            var mantissaPart = s[..decimalSeparator];
            var remainderPart = s[decimalSeparator..];

            if (!long.TryParse(mantissaPart, style, provider, out long mantissa) ||
                !long.TryParse(remainderPart, style, provider, out long remainder))
            {
                return false;
            }

            result = new(mantissa * Resolution + remainder);
            return true;
        }

        /// <inheritdoc cref="IParsable{TSelf}.Parse(string, IFormatProvider?)"/>
        public static FixedLong4DP Parse(string s, IFormatProvider? provider) =>
            Parse(s.AsSpan(), provider);

        /// <inheritdoc cref="INumberBase{TSelf}.Parse(string, NumberStyles, System.IFormatProvider?)"/>
        public static FixedLong4DP Parse(string s, NumberStyles style, IFormatProvider? provider) =>
            Parse(s.AsSpan(), style, provider);

        /// <inheritdoc cref="ISpanParsable{TSelf}.Parse(ReadOnlySpan{char}, IFormatProvider?)" />
        public static FixedLong4DP Parse(ReadOnlySpan<char> s, IFormatProvider? provider) =>
            Parse(s, NumberStyles.Integer, provider);

        /// <inheritdoc cref="INumberBase{TSelf}.Parse(ReadOnlySpan{char}, NumberStyles, System.IFormatProvider?)"/>
        public static FixedLong4DP Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
        {
            if (!TryParse(s, style, provider, out var result))
                throw new FormatException();
            return result;
        }

        #endregion

        #region IComparable

        /// <summary>
        /// Compares the given object to the current instance.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int CompareTo(object? obj) => obj is FixedLong4DP fixedInt ? CompareTo(fixedInt) : 1;

        /// <summary>
        /// Compares the given fixed integer to the current instance.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int CompareTo(FixedLong4DP other) => RawValue.CompareTo(other.RawValue);

        #endregion

        #region ToString and Formats

        /// <summary>
        /// Returns the default string representation of this fixed point value.
        /// </summary>
        public override string ToString() => ToString(null, null);

        /// <summary>
        /// Returns the string representation of this value while taking the given separator into account.
        /// </summary>
        /// <param name="decimalSeparator">The decimal separator to use.</param>
        private string ToString(string decimalSeparator) =>
            $"{Mantissa}{decimalSeparator}{Remainder:0000}";

        /// <summary>
        /// Helper function to get a number format provider instance.
        /// </summary>
        private static string GetDecimalSeparator(IFormatProvider? formatProvider) =>
            NumberFormatInfo.GetInstance(formatProvider).NumberDecimalSeparator;

        /// <inheritdoc cref="IFormattable.ToString(string?,System.IFormatProvider?)"/>
        public string ToString(string? format, IFormatProvider? formatProvider) =>
            ToString(GetDecimalSeparator(formatProvider));

        /// <inheritdoc cref="ISpanFormattable.TryFormat(Span{char}, out int, ReadOnlySpan{char}, IFormatProvider?)"/>
        public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
        {
            if (!Mantissa.TryFormat(destination, out charsWritten, format, provider))
                return false;

            var remainingTarget = destination[charsWritten..];
            var separator = GetDecimalSeparator(provider);
            if (separator.Length > remainingTarget.Length)
                return false;

            separator.CopyTo(remainingTarget);
            charsWritten += separator.Length;

            var decimalPlacesTarget = remainingTarget[separator.Length..];
            bool result = Remainder.TryFormat(
                decimalPlacesTarget,
                out int remainderCharsWritten,
                format,
                provider);
            charsWritten += remainderCharsWritten;
            return result;
        }

        #endregion

        #region Conversion Operators

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator bool(FixedLong4DP fixedInt) => fixedInt.RawValue != 0;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator char(FixedLong4DP fixedInt) => (char)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator sbyte(FixedLong4DP fixedInt) => (sbyte)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator byte(FixedLong4DP fixedInt) => (byte)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator short(FixedLong4DP fixedInt) => (short)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator ushort(FixedLong4DP fixedInt) => (ushort)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator int(FixedLong4DP fixedInt) => (int)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator uint(FixedLong4DP fixedInt) => (uint)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator long(FixedLong4DP fixedInt) => (long)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator Int128(FixedLong4DP fixedInt) => (Int128)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator ulong(FixedLong4DP fixedInt) => (ulong)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator UInt128(FixedLong4DP fixedInt) => (UInt128)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator System.Half(FixedLong4DP fixedInt) =>
            (System.Half)(float)fixedInt;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator float(FixedLong4DP fixedInt) => fixedInt.RawValue * FloatDenominator;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator double(FixedLong4DP fixedInt) =>
            fixedInt.RawValue * DoubleDenominator;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator decimal(FixedLong4DP fixedInt) =>
            fixedInt.RawValue * DecimalDenominator;

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedLong4DP(bool value) => value ? One : Zero;

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedLong4DP(char value) => new((long)value);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedLong4DP(sbyte value) => new(value * Resolution);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedLong4DP(byte value) => new(value * Resolution);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedLong4DP(short value) => new(value * Resolution);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedLong4DP(ushort value) => new(value * Resolution);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedLong4DP(int value) => new(value);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedLong4DP(uint value) => new((long)value);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedLong4DP(long value) => new((long)value);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedLong4DP(Int128 value) => new((long)value);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedLong4DP(ulong value) => new((long)value);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedLong4DP(UInt128 value) => new((long)value);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedLong4DP(System.Half value) =>
            (FixedLong4DP)(float)value;

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedLong4DP(float value)
        {
            long mantissa = (long)value;
            long remainder = (long)(
                MathF.Round(value - MathF.Truncate(value), RoundingDecimalPlaces) * Resolution);
            return new(mantissa * Resolution + remainder);
        }

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedLong4DP(double value)
        {
            long mantissa = (long)value;
            long remainder = (long)(
                Math.Round(value - Math.Truncate(value), RoundingDecimalPlaces) * Resolution);
            return new(mantissa * Resolution + remainder);
        }

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedLong4DP(decimal value)
        {
            long mantissa = (long)value;
            long remainder = (long)(
                Math.Round(value - Math.Truncate(value), RoundingDecimalPlaces) * Resolution);
            return new(mantissa * Resolution + remainder);
        }

        /// <summary>
        /// Converts the given value into its specified fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedInt2DP(FixedLong4DP value)
        {
            var computeVal = (long)value.RawValue;
            var newValue = computeVal * FixedInt2DP.Resolution / Resolution;
            return new((int)newValue);
        }

        /// <summary>
        /// Converts the given value into its specified fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedInt4DP(FixedLong4DP value)
        {
            var computeVal = (long)value.RawValue;
            var newValue = computeVal * FixedInt4DP.Resolution / Resolution;
            return new((int)newValue);
        }

        /// <summary>
        /// Converts the given value into its specified fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedInt6DP(FixedLong4DP value)
        {
            var computeVal = (long)value.RawValue;
            var newValue = computeVal * FixedInt6DP.Resolution / Resolution;
            return new((int)newValue);
        }

        /// <summary>
        /// Converts the given value into its specified fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedLong2DP(FixedLong4DP value)
        {
            var computeVal = (long)value.RawValue;
            var newValue = computeVal * FixedLong2DP.Resolution / Resolution;
            return new((long)newValue);
        }

        /// <summary>
        /// Converts the given value into its specified fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedLong6DP(FixedLong4DP value)
        {
            var computeVal = (long)value.RawValue;
            var newValue = computeVal * FixedLong6DP.Resolution / Resolution;
            return new((long)newValue);
        }

        /// <summary>
        /// Converts the given value into its specified fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedLong8DP(FixedLong4DP value)
        {
            var computeVal = (long)value.RawValue;
            var newValue = computeVal * FixedLong8DP.Resolution / Resolution;
            return new((long)newValue);
        }

        #endregion
    }

    /// <summary>
    /// A fixed precision integer with 64bits using 20 bits
    /// to represent a number with 6 decimal places.
    /// </summary>
    /// <param name="RawValue">The nested raw integer value.</param>
    public readonly record struct FixedLong6DP(long RawValue) :
        INumber<FixedLong6DP>,
        ISignedNumber<FixedLong6DP>,
        IMinMaxValue<FixedLong6DP>
    {
        #region Static

        /// <summary>
        /// Returns the number of decimal places used.
        /// </summary>
        public const int DecimalPlaces = 6;

        /// <summary>
        /// Returns the number of decimal places used to perform rounding.
        /// </summary>
        private const int RoundingDecimalPlaces = 6;

        /// <summary>
        /// Returns the integer-based resolution radix.
        /// </summary>
        public const int Resolution = 1000000;

        /// <summary>
        /// Returns a float denominator used to convert fixed point values into floats.
        /// </summary>
        public const float FloatDenominator = 1.0f / Resolution;

        /// <summary>
        /// Returns a double denominator used to convert fixed point values into doubles.
        /// </summary>
        public const double DoubleDenominator = 1.0 / Resolution;

        /// <summary>
        /// Returns a decimal denominator used to convert fixed point values into decimals.
        /// </summary>
        public const decimal DecimalDenominator = 1m / Resolution;

        /// <inheritdoc cref="IMinMaxValue{TSelf}.MinValue" />
        public static FixedLong6DP MinValue => new(long.MinValue);

        /// <inheritdoc cref="IMinMaxValue{TSelf}.MaxValue" />
        public static FixedLong6DP MaxValue => new(long.MaxValue);

        /// <summary>
        /// Returns the value 1.
        /// </summary>
        public static FixedLong6DP One => new(Resolution);

        /// <summary>
        /// Returns the radix 2.
        /// </summary>
        public static int Radix => 2;

        /// <summary>
        /// Returns the value 0.
        /// </summary>
        public static FixedLong6DP Zero => new(0);

        /// <summary>
        /// Returns the value 0.
        /// </summary>
        public static FixedLong6DP AdditiveIdentity => Zero;

        /// <summary>
        /// Returns the value -1.
        /// </summary>
        public static FixedLong6DP NegativeOne => new(-Resolution);

        /// <inheritdoc cref="IMultiplicativeIdentity{TSelf, TResult}.MultiplicativeIdentity" />
        public static FixedLong6DP MultiplicativeIdentity => One;

        #endregion

        #region Properties

        /// <summary>
        /// Returns the main mantissa.
        /// </summary>
        public long Mantissa => RawValue / Resolution;

        /// <summary>
        /// Returns all decimal places of this number.
        /// </summary>
        public long Remainder => RawValue % Resolution;

        #endregion

        #region Operators

        /// <inheritdoc cref="IAdditionOperators{TSelf, TOther, TResult}.op_Addition(TSelf, TOther)" />
        public static FixedLong6DP operator +(FixedLong6DP left, FixedLong6DP right) =>
            new(left.RawValue + right.RawValue);

        /// <inheritdoc cref="ISubtractionOperators{TSelf, TOther, TResult}.op_Subtraction(TSelf, TOther)" />
        public static FixedLong6DP operator -(FixedLong6DP left, FixedLong6DP right) =>
            new(left.RawValue - right.RawValue);

        /// <inheritdoc cref="IComparisonOperators{TSelf, TOther, TResult}.op_GreaterThan(TSelf, TOther)" />
        public static bool operator >(FixedLong6DP left, FixedLong6DP right) =>
            left.RawValue > right.RawValue;
        /// <inheritdoc cref="IComparisonOperators{TSelf, TOther, TResult}.op_GreaterThanOrEqual(TSelf, TOther)" />
        public static bool operator >=(FixedLong6DP left, FixedLong6DP right) =>
            left.RawValue >= right.RawValue;

        /// <inheritdoc cref="IComparisonOperators{TSelf, TOther, TResult}.op_LessThan(TSelf, TOther)" />
        public static bool operator <(FixedLong6DP left, FixedLong6DP right) =>
            left.RawValue < right.RawValue;

        /// <inheritdoc cref="IComparisonOperators{TSelf, TOther, TResult}.op_LessThanOrEqual(TSelf, TOther)" />
        public static bool operator <=(FixedLong6DP left, FixedLong6DP right) =>
            left.RawValue <= right.RawValue;

        /// <inheritdoc cref="IDecrementOperators{TSelf}.op_Decrement(TSelf)" />
        public static FixedLong6DP operator --(FixedLong6DP value) => value - One;
        /// <inheritdoc cref="IIncrementOperators{TSelf}.op_Increment(TSelf)" />
        public static FixedLong6DP operator ++(FixedLong6DP value) => value + One;

        /// <inheritdoc cref="IDivisionOperators{TSelf, TOther, TResult}.op_Division(TSelf, TOther)" />
        public static FixedLong6DP operator /(FixedLong6DP left, FixedLong6DP right) =>
            new((long)(left.RawValue * (long)Resolution / right.RawValue));

        /// <inheritdoc cref="IMultiplyOperators{TSelf, TOther, TResult}.op_Multiply(TSelf, TOther)" />
        public static FixedLong6DP operator *(FixedLong6DP left, FixedLong6DP right) =>
            new((long)((long)left.RawValue * right.RawValue / Resolution));

        /// <inheritdoc cref="IModulusOperators{TSelf, TOther, TResult}.op_Modulus(TSelf, TOther)" />
        public static FixedLong6DP operator %(FixedLong6DP left, FixedLong6DP right) =>
            new(left.RawValue % right.RawValue);

        /// <inheritdoc cref="IUnaryNegationOperators{TSelf, TResult}.op_UnaryNegation(TSelf)" />
        public static FixedLong6DP operator -(FixedLong6DP value) => new(-value.RawValue);

        /// <inheritdoc cref="IUnaryPlusOperators{TSelf, TResult}.op_UnaryPlus(TSelf)" />
        public static FixedLong6DP operator +(FixedLong6DP value) => value;

        #endregion

        #region Generic INumberBase Methods

        /// <inheritdoc cref="INumberBase{TSelf}.Abs(TSelf)" />
        public static FixedLong6DP Abs(FixedLong6DP value) => new(Math.Abs(value.RawValue));

        /// <inheritdoc cref="INumberBase{TSelf}.IsCanonical(TSelf)" />
        public static bool IsCanonical(FixedLong6DP value) => true;

        /// <inheritdoc cref="INumberBase{TSelf}.IsComplexNumber(TSelf)" />
        public static bool IsComplexNumber(FixedLong6DP value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsFinite(TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEvenInteger(FixedLong6DP value) =>
            IsInteger(value) & (value.Mantissa & 1) == 0;

        /// <inheritdoc cref="INumberBase{TSelf}.IsFinite(TSelf)" />
        public static bool IsFinite(FixedLong6DP value) => true;

        /// <inheritdoc cref="INumberBase{TSelf}.IsImaginaryNumber(TSelf)" />
        public static bool IsImaginaryNumber(FixedLong6DP value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsInfinity(TSelf)" />
        public static bool IsInfinity(FixedLong6DP value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsInteger(TSelf)" />
        public static bool IsInteger(FixedLong6DP value) => value.Remainder == 0;

        /// <inheritdoc cref="INumberBase{TSelf}.IsNaN(TSelf)" />
        public static bool IsNaN(FixedLong6DP value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsNegative(TSelf)" />
        public static bool IsNegative(FixedLong6DP value) => value.RawValue < 0;

        /// <inheritdoc cref="INumberBase{TSelf}.IsNegativeInfinity(TSelf)" />
        public static bool IsNegativeInfinity(FixedLong6DP value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsNormal(TSelf)" />
        public static bool IsNormal(FixedLong6DP value) => value.RawValue != 0;

        /// <inheritdoc cref="INumberBase{TSelf}.IsOddInteger(TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsOddInteger(FixedLong6DP value) =>
            IsInteger(value) & (value.Mantissa & 1) != 0;

        /// <inheritdoc cref="INumberBase{TSelf}.IsPositive(TSelf)" />
        public static bool IsPositive(FixedLong6DP value) => value.RawValue >= 0;

        /// <inheritdoc cref="INumberBase{TSelf}.IsPositiveInfinity(TSelf)" />
        public static bool IsPositiveInfinity(FixedLong6DP value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsRealNumber(TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsRealNumber(FixedLong6DP value) => true;

        /// <inheritdoc cref="INumberBase{TSelf}.IsSubnormal(TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsSubnormal(FixedLong6DP value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsZero(TSelf)" />
        public static bool IsZero(FixedLong6DP value) => value.RawValue == 0;

        /// <inheritdoc cref="INumberBase{TSelf}.MaxMagnitude(TSelf, TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FixedLong6DP MaxMagnitude(FixedLong6DP x, FixedLong6DP y) =>
            new(long.MaxMagnitude(x.RawValue, y.RawValue));

        /// <inheritdoc cref="INumberBase{TSelf}.MaxMagnitudeNumber(TSelf, TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FixedLong6DP MaxMagnitudeNumber(FixedLong6DP x, FixedLong6DP y) =>
            MaxMagnitude(x, y);

        /// <inheritdoc cref="INumberBase{TSelf}.MinMagnitude(TSelf, TSelf)" />
        public static FixedLong6DP MinMagnitude(FixedLong6DP x, FixedLong6DP y) =>
            new(long.MinMagnitude(x.RawValue, y.RawValue));

        /// <inheritdoc cref="INumberBase{TSelf}.MinMagnitudeNumber(TSelf, TSelf)" />
        public static FixedLong6DP MinMagnitudeNumber(FixedLong6DP x, FixedLong6DP y) =>
            MinMagnitude(x, y);

        /// <summary>
        /// Computes the min value of both.
        /// </summary>
        /// <param name="x">The first value.</param>
        /// <param name="y">The second value.</param>
        /// <returns>The min value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FixedLong6DP Min(FixedLong6DP x, FixedLong6DP y) =>
            new(Math.Min(x.RawValue, y.RawValue));

        /// <summary>
        /// Computes the max value of both.
        /// </summary>
        /// <param name="x">The first value.</param>
        /// <param name="y">The second value.</param>
        /// <returns>The max value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FixedLong6DP Max(FixedLong6DP x, FixedLong6DP y) =>
            new(Math.Max(x.RawValue, y.RawValue));

        #endregion

        #region TryConvert

        /// <inheritdoc cref="INumberBase{TSelf}.TryConvertFromChecked{TOther}(TOther, out TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryConvertFromChecked<TOther>(TOther value, out FixedLong6DP result)
            where TOther : INumberBase<TOther> =>
            TryConvertFrom(value, out result);

        /// <inheritdoc cref="INumberBase{TSelf}.TryConvertFromSaturating{TOther}(TOther, out TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryConvertFromSaturating<TOther>(TOther value, out FixedLong6DP result)
            where TOther : INumberBase<TOther> =>
            TryConvertFrom(value, out result);

        /// <inheritdoc cref="INumberBase{TSelf}.TryConvertFromTruncating{TOther}(TOther, out TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryConvertFromTruncating<TOther>(TOther value, out FixedLong6DP result)
            where TOther : INumberBase<TOther> =>
            TryConvertFrom(value, out result);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool TryConvertFrom<TOther>(TOther value, out FixedLong6DP result)
            where TOther : INumberBase<TOther>
        {
            if (typeof(TOther) == typeof(bool))
            {
                result = Unsafe.As<TOther, bool>(ref value) ? One : Zero;
                return true;
            }
            if (typeof(TOther) == typeof(sbyte))
            {
                result = (FixedLong6DP)Unsafe.As<TOther, sbyte>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(byte))
            {
                result = (FixedLong6DP)Unsafe.As<TOther, byte>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(short))
            {
                result = (FixedLong6DP)Unsafe.As<TOther, short>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(ushort))
            {
                result = (FixedLong6DP)Unsafe.As<TOther, ushort>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(int))
            {
                result = (FixedLong6DP)Unsafe.As<TOther, int>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(uint))
            {
                result = (FixedLong6DP)Unsafe.As<TOther, uint>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(long))
            {
                result = (FixedLong6DP)Unsafe.As<TOther, long>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(ulong))
            {
                result = (FixedLong6DP)Unsafe.As<TOther, ulong>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(System.Int128))
            {
                result = (FixedLong6DP)Unsafe.As<TOther, System.Int128>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(System.UInt128))
            {
                result = (FixedLong6DP)Unsafe.As<TOther, System.UInt128>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(nint))
            {
                result = (FixedLong6DP)Unsafe.As<TOther, nint>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(nuint))
            {
                result = (FixedLong6DP)Unsafe.As<TOther, nuint>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(System.Half))
            {
                result = (FixedLong6DP)Unsafe.As<TOther, System.Half>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(float))
            {
                result = (FixedLong6DP)Unsafe.As<TOther, float>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(double))
            {
                result = (FixedLong6DP)Unsafe.As<TOther, double>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(int))
            {
                result = (FixedLong6DP)Unsafe.As<TOther, int>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(int))
            {
                result = (FixedLong6DP)Unsafe.As<TOther, int>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(int))
            {
                result = (FixedLong6DP)Unsafe.As<TOther, int>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(long))
            {
                result = (FixedLong6DP)Unsafe.As<TOther, long>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(long))
            {
                result = (FixedLong6DP)Unsafe.As<TOther, long>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(long))
            {
                result = (FixedLong6DP)Unsafe.As<TOther, long>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(long))
            {
                result = (FixedLong6DP)Unsafe.As<TOther, long>(ref value);
                return true;
            }

            result = default;
            return false;
        }

        /// <inheritdoc cref="INumberBase{TSelf}.TryConvertToChecked{TOther}(TSelf, out TOther)" />
        public static bool TryConvertToChecked<TOther>(FixedLong6DP value, out TOther result)
            where TOther : INumberBase<TOther> =>
            TryConvertTo(value, out result);

        /// <inheritdoc cref="INumberBase{TSelf}.TryConvertToSaturating{TOther}(TSelf, out TOther)" />
        public static bool TryConvertToSaturating<TOther>(FixedLong6DP value, out TOther result)
            where TOther : INumberBase<TOther> =>
            TryConvertTo(value, out result);

        /// <inheritdoc cref="INumberBase{TSelf}.TryConvertToTruncating{TOther}(TSelf, out TOther)" />
        public static bool TryConvertToTruncating<TOther>(FixedLong6DP value, out TOther result)
            where TOther : INumberBase<TOther> =>
            TryConvertTo(value, out result);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool TryConvertTo<TOther>(FixedLong6DP value, out TOther result)
            where TOther : INumberBase<TOther>
        {
            result = default!;
            if (typeof(TOther) == typeof(bool))
            {
                Unsafe.As<TOther, bool>(ref result) = (bool)value;
                return true;
            }
            if (typeof(TOther) == typeof(sbyte))
            {
                Unsafe.As<TOther, sbyte>(ref result) = (sbyte)value;
                return true;
            }
            if (typeof(TOther) == typeof(byte))
            {
                Unsafe.As<TOther, byte>(ref result) = (byte)value;
                return true;
            }
            if (typeof(TOther) == typeof(short))
            {
                Unsafe.As<TOther, short>(ref result) = (short)value;
                return true;
            }
            if (typeof(TOther) == typeof(ushort))
            {
                Unsafe.As<TOther, ushort>(ref result) = (ushort)value;
                return true;
            }
            if (typeof(TOther) == typeof(int))
            {
                Unsafe.As<TOther, int>(ref result) = (int)value;
                return true;
            }
            if (typeof(TOther) == typeof(uint))
            {
                Unsafe.As<TOther, uint>(ref result) = (uint)value;
                return true;
            }
            if (typeof(TOther) == typeof(long))
            {
                Unsafe.As<TOther, long>(ref result) = (long)value;
                return true;
            }
            if (typeof(TOther) == typeof(ulong))
            {
                Unsafe.As<TOther, ulong>(ref result) = (ulong)value;
                return true;
            }
            if (typeof(TOther) == typeof(System.Int128))
            {
                Unsafe.As<TOther, System.Int128>(ref result) = (System.Int128)value;
                return true;
            }
            if (typeof(TOther) == typeof(System.UInt128))
            {
                Unsafe.As<TOther, System.UInt128>(ref result) = (System.UInt128)value;
                return true;
            }
            if (typeof(TOther) == typeof(nint))
            {
                Unsafe.As<TOther, nint>(ref result) = (nint)value;
                return true;
            }
            if (typeof(TOther) == typeof(nuint))
            {
                Unsafe.As<TOther, nuint>(ref result) = (nuint)value;
                return true;
            }
            if (typeof(TOther) == typeof(System.Half))
            {
                Unsafe.As<TOther, System.Half>(ref result) = (System.Half)value;
                return true;
            }
            if (typeof(TOther) == typeof(float))
            {
                Unsafe.As<TOther, float>(ref result) = (float)value;
                return true;
            }
            if (typeof(TOther) == typeof(double))
            {
                Unsafe.As<TOther, double>(ref result) = (double)value;
                return true;
            }
            if (typeof(TOther) == typeof(FixedInt2DP))
            {
                Unsafe.As<TOther, FixedInt2DP>(ref result) = (FixedInt2DP)value;
                return true;
            }
            if (typeof(TOther) == typeof(FixedInt4DP))
            {
                Unsafe.As<TOther, FixedInt4DP>(ref result) = (FixedInt4DP)value;
                return true;
            }
            if (typeof(TOther) == typeof(FixedInt6DP))
            {
                Unsafe.As<TOther, FixedInt6DP>(ref result) = (FixedInt6DP)value;
                return true;
            }
            if (typeof(TOther) == typeof(FixedLong2DP))
            {
                Unsafe.As<TOther, FixedLong2DP>(ref result) = (FixedLong2DP)value;
                return true;
            }
            if (typeof(TOther) == typeof(FixedLong4DP))
            {
                Unsafe.As<TOther, FixedLong4DP>(ref result) = (FixedLong4DP)value;
                return true;
            }
            if (typeof(TOther) == typeof(FixedLong6DP))
            {
                Unsafe.As<TOther, FixedLong6DP>(ref result) = (FixedLong6DP)value;
                return true;
            }
            if (typeof(TOther) == typeof(FixedLong8DP))
            {
                Unsafe.As<TOther, FixedLong8DP>(ref result) = (FixedLong8DP)value;
                return true;
            }

            result = default!;
            return false;
        }

        #endregion

        #region Parse

        /// <inheritdoc cref="IParsable{TSelf}.TryParse(string?, IFormatProvider?, out TSelf)"/>
        public static bool TryParse(string? s, IFormatProvider? provider, out FixedLong6DP result)
        {
            result = default;
            if (string.IsNullOrWhiteSpace(s))
                return false;
            return TryParse(s.AsSpan(), provider, out result);
        }

        /// <inheritdoc cref="INumberBase{TSelf}.TryParse(ReadOnlySpan{char}, NumberStyles, IFormatProvider?, out TSelf)"/>
        public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out FixedLong6DP result) =>
            TryParse(s, NumberStyles.Integer, provider, out result);

        /// <inheritdoc cref="INumberBase{TSelf}.TryParse(string?, NumberStyles, IFormatProvider? ,out TSelf)"/>
        public static bool TryParse(string? s, NumberStyles style, IFormatProvider? provider, out FixedLong6DP result)
        {
            result = default;
            if (string.IsNullOrWhiteSpace(s))
                return false;
            return TryParse(s.AsSpan(), style, provider, out result);
        }

        /// <inheritdoc cref="ISpanParsable{TSelf}.TryParse(ReadOnlySpan{char}, IFormatProvider?, out TSelf)" />
        public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out FixedLong6DP result)
        {
            result = default;

            var separator = GetDecimalSeparator(provider);
            int decimalSeparator = s.IndexOf(separator.AsSpan());
            if (decimalSeparator < 0)
            {
                // Try parse mantissa part only
                if (!long.TryParse(s, style, provider, out long mantissaOnly))
                    return false;
                result = new(mantissaOnly);
                return true;
            }

            var mantissaPart = s[..decimalSeparator];
            var remainderPart = s[decimalSeparator..];

            if (!long.TryParse(mantissaPart, style, provider, out long mantissa) ||
                !long.TryParse(remainderPart, style, provider, out long remainder))
            {
                return false;
            }

            result = new(mantissa * Resolution + remainder);
            return true;
        }

        /// <inheritdoc cref="IParsable{TSelf}.Parse(string, IFormatProvider?)"/>
        public static FixedLong6DP Parse(string s, IFormatProvider? provider) =>
            Parse(s.AsSpan(), provider);

        /// <inheritdoc cref="INumberBase{TSelf}.Parse(string, NumberStyles, System.IFormatProvider?)"/>
        public static FixedLong6DP Parse(string s, NumberStyles style, IFormatProvider? provider) =>
            Parse(s.AsSpan(), style, provider);

        /// <inheritdoc cref="ISpanParsable{TSelf}.Parse(ReadOnlySpan{char}, IFormatProvider?)" />
        public static FixedLong6DP Parse(ReadOnlySpan<char> s, IFormatProvider? provider) =>
            Parse(s, NumberStyles.Integer, provider);

        /// <inheritdoc cref="INumberBase{TSelf}.Parse(ReadOnlySpan{char}, NumberStyles, System.IFormatProvider?)"/>
        public static FixedLong6DP Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
        {
            if (!TryParse(s, style, provider, out var result))
                throw new FormatException();
            return result;
        }

        #endregion

        #region IComparable

        /// <summary>
        /// Compares the given object to the current instance.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int CompareTo(object? obj) => obj is FixedLong6DP fixedInt ? CompareTo(fixedInt) : 1;

        /// <summary>
        /// Compares the given fixed integer to the current instance.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int CompareTo(FixedLong6DP other) => RawValue.CompareTo(other.RawValue);

        #endregion

        #region ToString and Formats

        /// <summary>
        /// Returns the default string representation of this fixed point value.
        /// </summary>
        public override string ToString() => ToString(null, null);

        /// <summary>
        /// Returns the string representation of this value while taking the given separator into account.
        /// </summary>
        /// <param name="decimalSeparator">The decimal separator to use.</param>
        private string ToString(string decimalSeparator) =>
            $"{Mantissa}{decimalSeparator}{Remainder:000000}";

        /// <summary>
        /// Helper function to get a number format provider instance.
        /// </summary>
        private static string GetDecimalSeparator(IFormatProvider? formatProvider) =>
            NumberFormatInfo.GetInstance(formatProvider).NumberDecimalSeparator;

        /// <inheritdoc cref="IFormattable.ToString(string?,System.IFormatProvider?)"/>
        public string ToString(string? format, IFormatProvider? formatProvider) =>
            ToString(GetDecimalSeparator(formatProvider));

        /// <inheritdoc cref="ISpanFormattable.TryFormat(Span{char}, out int, ReadOnlySpan{char}, IFormatProvider?)"/>
        public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
        {
            if (!Mantissa.TryFormat(destination, out charsWritten, format, provider))
                return false;

            var remainingTarget = destination[charsWritten..];
            var separator = GetDecimalSeparator(provider);
            if (separator.Length > remainingTarget.Length)
                return false;

            separator.CopyTo(remainingTarget);
            charsWritten += separator.Length;

            var decimalPlacesTarget = remainingTarget[separator.Length..];
            bool result = Remainder.TryFormat(
                decimalPlacesTarget,
                out int remainderCharsWritten,
                format,
                provider);
            charsWritten += remainderCharsWritten;
            return result;
        }

        #endregion

        #region Conversion Operators

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator bool(FixedLong6DP fixedInt) => fixedInt.RawValue != 0;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator char(FixedLong6DP fixedInt) => (char)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator sbyte(FixedLong6DP fixedInt) => (sbyte)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator byte(FixedLong6DP fixedInt) => (byte)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator short(FixedLong6DP fixedInt) => (short)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator ushort(FixedLong6DP fixedInt) => (ushort)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator int(FixedLong6DP fixedInt) => (int)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator uint(FixedLong6DP fixedInt) => (uint)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator long(FixedLong6DP fixedInt) => (long)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator Int128(FixedLong6DP fixedInt) => (Int128)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator ulong(FixedLong6DP fixedInt) => (ulong)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator UInt128(FixedLong6DP fixedInt) => (UInt128)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator System.Half(FixedLong6DP fixedInt) =>
            (System.Half)(float)fixedInt;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator float(FixedLong6DP fixedInt) => fixedInt.RawValue * FloatDenominator;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator double(FixedLong6DP fixedInt) =>
            fixedInt.RawValue * DoubleDenominator;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator decimal(FixedLong6DP fixedInt) =>
            fixedInt.RawValue * DecimalDenominator;

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedLong6DP(bool value) => value ? One : Zero;

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedLong6DP(char value) => new((long)value);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedLong6DP(sbyte value) => new(value * Resolution);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedLong6DP(byte value) => new(value * Resolution);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedLong6DP(short value) => new(value * Resolution);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedLong6DP(ushort value) => new(value * Resolution);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedLong6DP(int value) => new(value);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedLong6DP(uint value) => new((long)value);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedLong6DP(long value) => new((long)value);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedLong6DP(Int128 value) => new((long)value);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedLong6DP(ulong value) => new((long)value);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedLong6DP(UInt128 value) => new((long)value);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedLong6DP(System.Half value) =>
            (FixedLong6DP)(float)value;

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedLong6DP(float value)
        {
            long mantissa = (long)value;
            long remainder = (long)(
                MathF.Round(value - MathF.Truncate(value), RoundingDecimalPlaces) * Resolution);
            return new(mantissa * Resolution + remainder);
        }

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedLong6DP(double value)
        {
            long mantissa = (long)value;
            long remainder = (long)(
                Math.Round(value - Math.Truncate(value), RoundingDecimalPlaces) * Resolution);
            return new(mantissa * Resolution + remainder);
        }

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedLong6DP(decimal value)
        {
            long mantissa = (long)value;
            long remainder = (long)(
                Math.Round(value - Math.Truncate(value), RoundingDecimalPlaces) * Resolution);
            return new(mantissa * Resolution + remainder);
        }

        /// <summary>
        /// Converts the given value into its specified fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedInt2DP(FixedLong6DP value)
        {
            var computeVal = (long)value.RawValue;
            var newValue = computeVal * FixedInt2DP.Resolution / Resolution;
            return new((int)newValue);
        }

        /// <summary>
        /// Converts the given value into its specified fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedInt4DP(FixedLong6DP value)
        {
            var computeVal = (long)value.RawValue;
            var newValue = computeVal * FixedInt4DP.Resolution / Resolution;
            return new((int)newValue);
        }

        /// <summary>
        /// Converts the given value into its specified fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedInt6DP(FixedLong6DP value)
        {
            var computeVal = (long)value.RawValue;
            var newValue = computeVal * FixedInt6DP.Resolution / Resolution;
            return new((int)newValue);
        }

        /// <summary>
        /// Converts the given value into its specified fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedLong2DP(FixedLong6DP value)
        {
            var computeVal = (long)value.RawValue;
            var newValue = computeVal * FixedLong2DP.Resolution / Resolution;
            return new((long)newValue);
        }

        /// <summary>
        /// Converts the given value into its specified fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedLong4DP(FixedLong6DP value)
        {
            var computeVal = (long)value.RawValue;
            var newValue = computeVal * FixedLong4DP.Resolution / Resolution;
            return new((long)newValue);
        }

        /// <summary>
        /// Converts the given value into its specified fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedLong8DP(FixedLong6DP value)
        {
            var computeVal = (long)value.RawValue;
            var newValue = computeVal * FixedLong8DP.Resolution / Resolution;
            return new((long)newValue);
        }

        #endregion
    }

    /// <summary>
    /// A fixed precision integer with 64bits using 27 bits
    /// to represent a number with 8 decimal places.
    /// </summary>
    /// <param name="RawValue">The nested raw integer value.</param>
    public readonly record struct FixedLong8DP(long RawValue) :
        INumber<FixedLong8DP>,
        ISignedNumber<FixedLong8DP>,
        IMinMaxValue<FixedLong8DP>
    {
        #region Static

        /// <summary>
        /// Returns the number of decimal places used.
        /// </summary>
        public const int DecimalPlaces = 8;

        /// <summary>
        /// Returns the number of decimal places used to perform rounding.
        /// </summary>
        private const int RoundingDecimalPlaces = 6;

        /// <summary>
        /// Returns the integer-based resolution radix.
        /// </summary>
        public const int Resolution = 100000000;

        /// <summary>
        /// Returns a float denominator used to convert fixed point values into floats.
        /// </summary>
        public const float FloatDenominator = 1.0f / Resolution;

        /// <summary>
        /// Returns a double denominator used to convert fixed point values into doubles.
        /// </summary>
        public const double DoubleDenominator = 1.0 / Resolution;

        /// <summary>
        /// Returns a decimal denominator used to convert fixed point values into decimals.
        /// </summary>
        public const decimal DecimalDenominator = 1m / Resolution;

        /// <inheritdoc cref="IMinMaxValue{TSelf}.MinValue" />
        public static FixedLong8DP MinValue => new(long.MinValue);

        /// <inheritdoc cref="IMinMaxValue{TSelf}.MaxValue" />
        public static FixedLong8DP MaxValue => new(long.MaxValue);

        /// <summary>
        /// Returns the value 1.
        /// </summary>
        public static FixedLong8DP One => new(Resolution);

        /// <summary>
        /// Returns the radix 2.
        /// </summary>
        public static int Radix => 2;

        /// <summary>
        /// Returns the value 0.
        /// </summary>
        public static FixedLong8DP Zero => new(0);

        /// <summary>
        /// Returns the value 0.
        /// </summary>
        public static FixedLong8DP AdditiveIdentity => Zero;

        /// <summary>
        /// Returns the value -1.
        /// </summary>
        public static FixedLong8DP NegativeOne => new(-Resolution);

        /// <inheritdoc cref="IMultiplicativeIdentity{TSelf, TResult}.MultiplicativeIdentity" />
        public static FixedLong8DP MultiplicativeIdentity => One;

        #endregion

        #region Properties

        /// <summary>
        /// Returns the main mantissa.
        /// </summary>
        public long Mantissa => RawValue / Resolution;

        /// <summary>
        /// Returns all decimal places of this number.
        /// </summary>
        public long Remainder => RawValue % Resolution;

        #endregion

        #region Operators

        /// <inheritdoc cref="IAdditionOperators{TSelf, TOther, TResult}.op_Addition(TSelf, TOther)" />
        public static FixedLong8DP operator +(FixedLong8DP left, FixedLong8DP right) =>
            new(left.RawValue + right.RawValue);

        /// <inheritdoc cref="ISubtractionOperators{TSelf, TOther, TResult}.op_Subtraction(TSelf, TOther)" />
        public static FixedLong8DP operator -(FixedLong8DP left, FixedLong8DP right) =>
            new(left.RawValue - right.RawValue);

        /// <inheritdoc cref="IComparisonOperators{TSelf, TOther, TResult}.op_GreaterThan(TSelf, TOther)" />
        public static bool operator >(FixedLong8DP left, FixedLong8DP right) =>
            left.RawValue > right.RawValue;
        /// <inheritdoc cref="IComparisonOperators{TSelf, TOther, TResult}.op_GreaterThanOrEqual(TSelf, TOther)" />
        public static bool operator >=(FixedLong8DP left, FixedLong8DP right) =>
            left.RawValue >= right.RawValue;

        /// <inheritdoc cref="IComparisonOperators{TSelf, TOther, TResult}.op_LessThan(TSelf, TOther)" />
        public static bool operator <(FixedLong8DP left, FixedLong8DP right) =>
            left.RawValue < right.RawValue;

        /// <inheritdoc cref="IComparisonOperators{TSelf, TOther, TResult}.op_LessThanOrEqual(TSelf, TOther)" />
        public static bool operator <=(FixedLong8DP left, FixedLong8DP right) =>
            left.RawValue <= right.RawValue;

        /// <inheritdoc cref="IDecrementOperators{TSelf}.op_Decrement(TSelf)" />
        public static FixedLong8DP operator --(FixedLong8DP value) => value - One;
        /// <inheritdoc cref="IIncrementOperators{TSelf}.op_Increment(TSelf)" />
        public static FixedLong8DP operator ++(FixedLong8DP value) => value + One;

        /// <inheritdoc cref="IDivisionOperators{TSelf, TOther, TResult}.op_Division(TSelf, TOther)" />
        public static FixedLong8DP operator /(FixedLong8DP left, FixedLong8DP right) =>
            new((long)(left.RawValue * (long)Resolution / right.RawValue));

        /// <inheritdoc cref="IMultiplyOperators{TSelf, TOther, TResult}.op_Multiply(TSelf, TOther)" />
        public static FixedLong8DP operator *(FixedLong8DP left, FixedLong8DP right) =>
            new((long)((long)left.RawValue * right.RawValue / Resolution));

        /// <inheritdoc cref="IModulusOperators{TSelf, TOther, TResult}.op_Modulus(TSelf, TOther)" />
        public static FixedLong8DP operator %(FixedLong8DP left, FixedLong8DP right) =>
            new(left.RawValue % right.RawValue);

        /// <inheritdoc cref="IUnaryNegationOperators{TSelf, TResult}.op_UnaryNegation(TSelf)" />
        public static FixedLong8DP operator -(FixedLong8DP value) => new(-value.RawValue);

        /// <inheritdoc cref="IUnaryPlusOperators{TSelf, TResult}.op_UnaryPlus(TSelf)" />
        public static FixedLong8DP operator +(FixedLong8DP value) => value;

        #endregion

        #region Generic INumberBase Methods

        /// <inheritdoc cref="INumberBase{TSelf}.Abs(TSelf)" />
        public static FixedLong8DP Abs(FixedLong8DP value) => new(Math.Abs(value.RawValue));

        /// <inheritdoc cref="INumberBase{TSelf}.IsCanonical(TSelf)" />
        public static bool IsCanonical(FixedLong8DP value) => true;

        /// <inheritdoc cref="INumberBase{TSelf}.IsComplexNumber(TSelf)" />
        public static bool IsComplexNumber(FixedLong8DP value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsFinite(TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEvenInteger(FixedLong8DP value) =>
            IsInteger(value) & (value.Mantissa & 1) == 0;

        /// <inheritdoc cref="INumberBase{TSelf}.IsFinite(TSelf)" />
        public static bool IsFinite(FixedLong8DP value) => true;

        /// <inheritdoc cref="INumberBase{TSelf}.IsImaginaryNumber(TSelf)" />
        public static bool IsImaginaryNumber(FixedLong8DP value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsInfinity(TSelf)" />
        public static bool IsInfinity(FixedLong8DP value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsInteger(TSelf)" />
        public static bool IsInteger(FixedLong8DP value) => value.Remainder == 0;

        /// <inheritdoc cref="INumberBase{TSelf}.IsNaN(TSelf)" />
        public static bool IsNaN(FixedLong8DP value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsNegative(TSelf)" />
        public static bool IsNegative(FixedLong8DP value) => value.RawValue < 0;

        /// <inheritdoc cref="INumberBase{TSelf}.IsNegativeInfinity(TSelf)" />
        public static bool IsNegativeInfinity(FixedLong8DP value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsNormal(TSelf)" />
        public static bool IsNormal(FixedLong8DP value) => value.RawValue != 0;

        /// <inheritdoc cref="INumberBase{TSelf}.IsOddInteger(TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsOddInteger(FixedLong8DP value) =>
            IsInteger(value) & (value.Mantissa & 1) != 0;

        /// <inheritdoc cref="INumberBase{TSelf}.IsPositive(TSelf)" />
        public static bool IsPositive(FixedLong8DP value) => value.RawValue >= 0;

        /// <inheritdoc cref="INumberBase{TSelf}.IsPositiveInfinity(TSelf)" />
        public static bool IsPositiveInfinity(FixedLong8DP value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsRealNumber(TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsRealNumber(FixedLong8DP value) => true;

        /// <inheritdoc cref="INumberBase{TSelf}.IsSubnormal(TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsSubnormal(FixedLong8DP value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsZero(TSelf)" />
        public static bool IsZero(FixedLong8DP value) => value.RawValue == 0;

        /// <inheritdoc cref="INumberBase{TSelf}.MaxMagnitude(TSelf, TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FixedLong8DP MaxMagnitude(FixedLong8DP x, FixedLong8DP y) =>
            new(long.MaxMagnitude(x.RawValue, y.RawValue));

        /// <inheritdoc cref="INumberBase{TSelf}.MaxMagnitudeNumber(TSelf, TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FixedLong8DP MaxMagnitudeNumber(FixedLong8DP x, FixedLong8DP y) =>
            MaxMagnitude(x, y);

        /// <inheritdoc cref="INumberBase{TSelf}.MinMagnitude(TSelf, TSelf)" />
        public static FixedLong8DP MinMagnitude(FixedLong8DP x, FixedLong8DP y) =>
            new(long.MinMagnitude(x.RawValue, y.RawValue));

        /// <inheritdoc cref="INumberBase{TSelf}.MinMagnitudeNumber(TSelf, TSelf)" />
        public static FixedLong8DP MinMagnitudeNumber(FixedLong8DP x, FixedLong8DP y) =>
            MinMagnitude(x, y);

        /// <summary>
        /// Computes the min value of both.
        /// </summary>
        /// <param name="x">The first value.</param>
        /// <param name="y">The second value.</param>
        /// <returns>The min value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FixedLong8DP Min(FixedLong8DP x, FixedLong8DP y) =>
            new(Math.Min(x.RawValue, y.RawValue));

        /// <summary>
        /// Computes the max value of both.
        /// </summary>
        /// <param name="x">The first value.</param>
        /// <param name="y">The second value.</param>
        /// <returns>The max value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FixedLong8DP Max(FixedLong8DP x, FixedLong8DP y) =>
            new(Math.Max(x.RawValue, y.RawValue));

        #endregion

        #region TryConvert

        /// <inheritdoc cref="INumberBase{TSelf}.TryConvertFromChecked{TOther}(TOther, out TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryConvertFromChecked<TOther>(TOther value, out FixedLong8DP result)
            where TOther : INumberBase<TOther> =>
            TryConvertFrom(value, out result);

        /// <inheritdoc cref="INumberBase{TSelf}.TryConvertFromSaturating{TOther}(TOther, out TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryConvertFromSaturating<TOther>(TOther value, out FixedLong8DP result)
            where TOther : INumberBase<TOther> =>
            TryConvertFrom(value, out result);

        /// <inheritdoc cref="INumberBase{TSelf}.TryConvertFromTruncating{TOther}(TOther, out TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryConvertFromTruncating<TOther>(TOther value, out FixedLong8DP result)
            where TOther : INumberBase<TOther> =>
            TryConvertFrom(value, out result);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool TryConvertFrom<TOther>(TOther value, out FixedLong8DP result)
            where TOther : INumberBase<TOther>
        {
            if (typeof(TOther) == typeof(bool))
            {
                result = Unsafe.As<TOther, bool>(ref value) ? One : Zero;
                return true;
            }
            if (typeof(TOther) == typeof(sbyte))
            {
                result = (FixedLong8DP)Unsafe.As<TOther, sbyte>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(byte))
            {
                result = (FixedLong8DP)Unsafe.As<TOther, byte>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(short))
            {
                result = (FixedLong8DP)Unsafe.As<TOther, short>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(ushort))
            {
                result = (FixedLong8DP)Unsafe.As<TOther, ushort>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(int))
            {
                result = (FixedLong8DP)Unsafe.As<TOther, int>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(uint))
            {
                result = (FixedLong8DP)Unsafe.As<TOther, uint>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(long))
            {
                result = (FixedLong8DP)Unsafe.As<TOther, long>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(ulong))
            {
                result = (FixedLong8DP)Unsafe.As<TOther, ulong>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(System.Int128))
            {
                result = (FixedLong8DP)Unsafe.As<TOther, System.Int128>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(System.UInt128))
            {
                result = (FixedLong8DP)Unsafe.As<TOther, System.UInt128>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(nint))
            {
                result = (FixedLong8DP)Unsafe.As<TOther, nint>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(nuint))
            {
                result = (FixedLong8DP)Unsafe.As<TOther, nuint>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(System.Half))
            {
                result = (FixedLong8DP)Unsafe.As<TOther, System.Half>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(float))
            {
                result = (FixedLong8DP)Unsafe.As<TOther, float>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(double))
            {
                result = (FixedLong8DP)Unsafe.As<TOther, double>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(int))
            {
                result = (FixedLong8DP)Unsafe.As<TOther, int>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(int))
            {
                result = (FixedLong8DP)Unsafe.As<TOther, int>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(int))
            {
                result = (FixedLong8DP)Unsafe.As<TOther, int>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(long))
            {
                result = (FixedLong8DP)Unsafe.As<TOther, long>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(long))
            {
                result = (FixedLong8DP)Unsafe.As<TOther, long>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(long))
            {
                result = (FixedLong8DP)Unsafe.As<TOther, long>(ref value);
                return true;
            }
            if (typeof(TOther) == typeof(long))
            {
                result = (FixedLong8DP)Unsafe.As<TOther, long>(ref value);
                return true;
            }

            result = default;
            return false;
        }

        /// <inheritdoc cref="INumberBase{TSelf}.TryConvertToChecked{TOther}(TSelf, out TOther)" />
        public static bool TryConvertToChecked<TOther>(FixedLong8DP value, out TOther result)
            where TOther : INumberBase<TOther> =>
            TryConvertTo(value, out result);

        /// <inheritdoc cref="INumberBase{TSelf}.TryConvertToSaturating{TOther}(TSelf, out TOther)" />
        public static bool TryConvertToSaturating<TOther>(FixedLong8DP value, out TOther result)
            where TOther : INumberBase<TOther> =>
            TryConvertTo(value, out result);

        /// <inheritdoc cref="INumberBase{TSelf}.TryConvertToTruncating{TOther}(TSelf, out TOther)" />
        public static bool TryConvertToTruncating<TOther>(FixedLong8DP value, out TOther result)
            where TOther : INumberBase<TOther> =>
            TryConvertTo(value, out result);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool TryConvertTo<TOther>(FixedLong8DP value, out TOther result)
            where TOther : INumberBase<TOther>
        {
            result = default!;
            if (typeof(TOther) == typeof(bool))
            {
                Unsafe.As<TOther, bool>(ref result) = (bool)value;
                return true;
            }
            if (typeof(TOther) == typeof(sbyte))
            {
                Unsafe.As<TOther, sbyte>(ref result) = (sbyte)value;
                return true;
            }
            if (typeof(TOther) == typeof(byte))
            {
                Unsafe.As<TOther, byte>(ref result) = (byte)value;
                return true;
            }
            if (typeof(TOther) == typeof(short))
            {
                Unsafe.As<TOther, short>(ref result) = (short)value;
                return true;
            }
            if (typeof(TOther) == typeof(ushort))
            {
                Unsafe.As<TOther, ushort>(ref result) = (ushort)value;
                return true;
            }
            if (typeof(TOther) == typeof(int))
            {
                Unsafe.As<TOther, int>(ref result) = (int)value;
                return true;
            }
            if (typeof(TOther) == typeof(uint))
            {
                Unsafe.As<TOther, uint>(ref result) = (uint)value;
                return true;
            }
            if (typeof(TOther) == typeof(long))
            {
                Unsafe.As<TOther, long>(ref result) = (long)value;
                return true;
            }
            if (typeof(TOther) == typeof(ulong))
            {
                Unsafe.As<TOther, ulong>(ref result) = (ulong)value;
                return true;
            }
            if (typeof(TOther) == typeof(System.Int128))
            {
                Unsafe.As<TOther, System.Int128>(ref result) = (System.Int128)value;
                return true;
            }
            if (typeof(TOther) == typeof(System.UInt128))
            {
                Unsafe.As<TOther, System.UInt128>(ref result) = (System.UInt128)value;
                return true;
            }
            if (typeof(TOther) == typeof(nint))
            {
                Unsafe.As<TOther, nint>(ref result) = (nint)value;
                return true;
            }
            if (typeof(TOther) == typeof(nuint))
            {
                Unsafe.As<TOther, nuint>(ref result) = (nuint)value;
                return true;
            }
            if (typeof(TOther) == typeof(System.Half))
            {
                Unsafe.As<TOther, System.Half>(ref result) = (System.Half)value;
                return true;
            }
            if (typeof(TOther) == typeof(float))
            {
                Unsafe.As<TOther, float>(ref result) = (float)value;
                return true;
            }
            if (typeof(TOther) == typeof(double))
            {
                Unsafe.As<TOther, double>(ref result) = (double)value;
                return true;
            }
            if (typeof(TOther) == typeof(FixedInt2DP))
            {
                Unsafe.As<TOther, FixedInt2DP>(ref result) = (FixedInt2DP)value;
                return true;
            }
            if (typeof(TOther) == typeof(FixedInt4DP))
            {
                Unsafe.As<TOther, FixedInt4DP>(ref result) = (FixedInt4DP)value;
                return true;
            }
            if (typeof(TOther) == typeof(FixedInt6DP))
            {
                Unsafe.As<TOther, FixedInt6DP>(ref result) = (FixedInt6DP)value;
                return true;
            }
            if (typeof(TOther) == typeof(FixedLong2DP))
            {
                Unsafe.As<TOther, FixedLong2DP>(ref result) = (FixedLong2DP)value;
                return true;
            }
            if (typeof(TOther) == typeof(FixedLong4DP))
            {
                Unsafe.As<TOther, FixedLong4DP>(ref result) = (FixedLong4DP)value;
                return true;
            }
            if (typeof(TOther) == typeof(FixedLong6DP))
            {
                Unsafe.As<TOther, FixedLong6DP>(ref result) = (FixedLong6DP)value;
                return true;
            }
            if (typeof(TOther) == typeof(FixedLong8DP))
            {
                Unsafe.As<TOther, FixedLong8DP>(ref result) = (FixedLong8DP)value;
                return true;
            }

            result = default!;
            return false;
        }

        #endregion

        #region Parse

        /// <inheritdoc cref="IParsable{TSelf}.TryParse(string?, IFormatProvider?, out TSelf)"/>
        public static bool TryParse(string? s, IFormatProvider? provider, out FixedLong8DP result)
        {
            result = default;
            if (string.IsNullOrWhiteSpace(s))
                return false;
            return TryParse(s.AsSpan(), provider, out result);
        }

        /// <inheritdoc cref="INumberBase{TSelf}.TryParse(ReadOnlySpan{char}, NumberStyles, IFormatProvider?, out TSelf)"/>
        public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out FixedLong8DP result) =>
            TryParse(s, NumberStyles.Integer, provider, out result);

        /// <inheritdoc cref="INumberBase{TSelf}.TryParse(string?, NumberStyles, IFormatProvider? ,out TSelf)"/>
        public static bool TryParse(string? s, NumberStyles style, IFormatProvider? provider, out FixedLong8DP result)
        {
            result = default;
            if (string.IsNullOrWhiteSpace(s))
                return false;
            return TryParse(s.AsSpan(), style, provider, out result);
        }

        /// <inheritdoc cref="ISpanParsable{TSelf}.TryParse(ReadOnlySpan{char}, IFormatProvider?, out TSelf)" />
        public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out FixedLong8DP result)
        {
            result = default;

            var separator = GetDecimalSeparator(provider);
            int decimalSeparator = s.IndexOf(separator.AsSpan());
            if (decimalSeparator < 0)
            {
                // Try parse mantissa part only
                if (!long.TryParse(s, style, provider, out long mantissaOnly))
                    return false;
                result = new(mantissaOnly);
                return true;
            }

            var mantissaPart = s[..decimalSeparator];
            var remainderPart = s[decimalSeparator..];

            if (!long.TryParse(mantissaPart, style, provider, out long mantissa) ||
                !long.TryParse(remainderPart, style, provider, out long remainder))
            {
                return false;
            }

            result = new(mantissa * Resolution + remainder);
            return true;
        }

        /// <inheritdoc cref="IParsable{TSelf}.Parse(string, IFormatProvider?)"/>
        public static FixedLong8DP Parse(string s, IFormatProvider? provider) =>
            Parse(s.AsSpan(), provider);

        /// <inheritdoc cref="INumberBase{TSelf}.Parse(string, NumberStyles, System.IFormatProvider?)"/>
        public static FixedLong8DP Parse(string s, NumberStyles style, IFormatProvider? provider) =>
            Parse(s.AsSpan(), style, provider);

        /// <inheritdoc cref="ISpanParsable{TSelf}.Parse(ReadOnlySpan{char}, IFormatProvider?)" />
        public static FixedLong8DP Parse(ReadOnlySpan<char> s, IFormatProvider? provider) =>
            Parse(s, NumberStyles.Integer, provider);

        /// <inheritdoc cref="INumberBase{TSelf}.Parse(ReadOnlySpan{char}, NumberStyles, System.IFormatProvider?)"/>
        public static FixedLong8DP Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
        {
            if (!TryParse(s, style, provider, out var result))
                throw new FormatException();
            return result;
        }

        #endregion

        #region IComparable

        /// <summary>
        /// Compares the given object to the current instance.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int CompareTo(object? obj) => obj is FixedLong8DP fixedInt ? CompareTo(fixedInt) : 1;

        /// <summary>
        /// Compares the given fixed integer to the current instance.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int CompareTo(FixedLong8DP other) => RawValue.CompareTo(other.RawValue);

        #endregion

        #region ToString and Formats

        /// <summary>
        /// Returns the default string representation of this fixed point value.
        /// </summary>
        public override string ToString() => ToString(null, null);

        /// <summary>
        /// Returns the string representation of this value while taking the given separator into account.
        /// </summary>
        /// <param name="decimalSeparator">The decimal separator to use.</param>
        private string ToString(string decimalSeparator) =>
            $"{Mantissa}{decimalSeparator}{Remainder:00000000}";

        /// <summary>
        /// Helper function to get a number format provider instance.
        /// </summary>
        private static string GetDecimalSeparator(IFormatProvider? formatProvider) =>
            NumberFormatInfo.GetInstance(formatProvider).NumberDecimalSeparator;

        /// <inheritdoc cref="IFormattable.ToString(string?,System.IFormatProvider?)"/>
        public string ToString(string? format, IFormatProvider? formatProvider) =>
            ToString(GetDecimalSeparator(formatProvider));

        /// <inheritdoc cref="ISpanFormattable.TryFormat(Span{char}, out int, ReadOnlySpan{char}, IFormatProvider?)"/>
        public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
        {
            if (!Mantissa.TryFormat(destination, out charsWritten, format, provider))
                return false;

            var remainingTarget = destination[charsWritten..];
            var separator = GetDecimalSeparator(provider);
            if (separator.Length > remainingTarget.Length)
                return false;

            separator.CopyTo(remainingTarget);
            charsWritten += separator.Length;

            var decimalPlacesTarget = remainingTarget[separator.Length..];
            bool result = Remainder.TryFormat(
                decimalPlacesTarget,
                out int remainderCharsWritten,
                format,
                provider);
            charsWritten += remainderCharsWritten;
            return result;
        }

        #endregion

        #region Conversion Operators

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator bool(FixedLong8DP fixedInt) => fixedInt.RawValue != 0;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator char(FixedLong8DP fixedInt) => (char)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator sbyte(FixedLong8DP fixedInt) => (sbyte)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator byte(FixedLong8DP fixedInt) => (byte)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator short(FixedLong8DP fixedInt) => (short)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator ushort(FixedLong8DP fixedInt) => (ushort)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator int(FixedLong8DP fixedInt) => (int)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator uint(FixedLong8DP fixedInt) => (uint)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator long(FixedLong8DP fixedInt) => (long)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator Int128(FixedLong8DP fixedInt) => (Int128)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator ulong(FixedLong8DP fixedInt) => (ulong)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator UInt128(FixedLong8DP fixedInt) => (UInt128)fixedInt.Mantissa;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator System.Half(FixedLong8DP fixedInt) =>
            (System.Half)(float)fixedInt;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator float(FixedLong8DP fixedInt) => fixedInt.RawValue * FloatDenominator;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator double(FixedLong8DP fixedInt) =>
            fixedInt.RawValue * DoubleDenominator;

        /// <summary>
        /// Converts the given fixed-point value into the designated target type.
        /// </summary>
        /// <param name="fixedInt">The fixed value to convert.</param>
        /// <returns>The converted target value.</returns>
        public static explicit operator decimal(FixedLong8DP fixedInt) =>
            fixedInt.RawValue * DecimalDenominator;

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedLong8DP(bool value) => value ? One : Zero;

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedLong8DP(char value) => new((long)value);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedLong8DP(sbyte value) => new(value * Resolution);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedLong8DP(byte value) => new(value * Resolution);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedLong8DP(short value) => new(value * Resolution);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedLong8DP(ushort value) => new(value * Resolution);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedLong8DP(int value) => new(value);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedLong8DP(uint value) => new((long)value);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedLong8DP(long value) => new((long)value);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedLong8DP(Int128 value) => new((long)value);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedLong8DP(ulong value) => new((long)value);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        public static explicit operator FixedLong8DP(UInt128 value) => new((long)value);

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedLong8DP(System.Half value) =>
            (FixedLong8DP)(float)value;

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedLong8DP(float value)
        {
            long mantissa = (long)value;
            long remainder = (long)(
                MathF.Round(value - MathF.Truncate(value), RoundingDecimalPlaces) * Resolution);
            return new(mantissa * Resolution + remainder);
        }

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedLong8DP(double value)
        {
            long mantissa = (long)value;
            long remainder = (long)(
                Math.Round(value - Math.Truncate(value), RoundingDecimalPlaces) * Resolution);
            return new(mantissa * Resolution + remainder);
        }

        /// <summary>
        /// Converts the given value into its fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedLong8DP(decimal value)
        {
            long mantissa = (long)value;
            long remainder = (long)(
                Math.Round(value - Math.Truncate(value), RoundingDecimalPlaces) * Resolution);
            return new(mantissa * Resolution + remainder);
        }

        /// <summary>
        /// Converts the given value into its specified fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedInt2DP(FixedLong8DP value)
        {
            var computeVal = (long)value.RawValue;
            var newValue = computeVal * FixedInt2DP.Resolution / Resolution;
            return new((int)newValue);
        }

        /// <summary>
        /// Converts the given value into its specified fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedInt4DP(FixedLong8DP value)
        {
            var computeVal = (long)value.RawValue;
            var newValue = computeVal * FixedInt4DP.Resolution / Resolution;
            return new((int)newValue);
        }

        /// <summary>
        /// Converts the given value into its specified fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedInt6DP(FixedLong8DP value)
        {
            var computeVal = (long)value.RawValue;
            var newValue = computeVal * FixedInt6DP.Resolution / Resolution;
            return new((int)newValue);
        }

        /// <summary>
        /// Converts the given value into its specified fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedLong2DP(FixedLong8DP value)
        {
            var computeVal = (long)value.RawValue;
            var newValue = computeVal * FixedLong2DP.Resolution / Resolution;
            return new((long)newValue);
        }

        /// <summary>
        /// Converts the given value into its specified fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedLong4DP(FixedLong8DP value)
        {
            var computeVal = (long)value.RawValue;
            var newValue = computeVal * FixedLong4DP.Resolution / Resolution;
            return new((long)newValue);
        }

        /// <summary>
        /// Converts the given value into its specified fixed-point value equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted fixed point value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FixedLong6DP(FixedLong8DP value)
        {
            var computeVal = (long)value.RawValue;
            var newValue = computeVal * FixedLong6DP.Resolution / Resolution;
            return new((long)newValue);
        }

        #endregion
    }

}

namespace ILGPU.Algorithms.Random
{
    using ILGPU.Algorithms.FixedPrecision;

    partial class RandomExtensions
    {
        /// <summary>
        /// Generates a random FixedInt2DP in [minValue..maxValue).
        /// </summary>
        /// <param name="randomProvider">The random provider.</param>
        /// <param name="minValue">The minimum value (inclusive).</param>
        /// <param name="maxValue">The maximum values (exclusive).</param>
        /// <returns>A random FixedInt2DP in [minValue..maxValue).</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FixedInt2DP Next<TRandomProvider>(
            ref TRandomProvider randomProvider,
            FixedInt2DP minValue,
            FixedInt2DP maxValue)
            where TRandomProvider : struct, IRandomProvider
        {
            long next = Next(
                ref randomProvider,
                (long)minValue.RawValue,
                (long)maxValue.RawValue);
            return new((int)next);
        }
        /// <summary>
        /// Generates a random FixedInt4DP in [minValue..maxValue).
        /// </summary>
        /// <param name="randomProvider">The random provider.</param>
        /// <param name="minValue">The minimum value (inclusive).</param>
        /// <param name="maxValue">The maximum values (exclusive).</param>
        /// <returns>A random FixedInt4DP in [minValue..maxValue).</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FixedInt4DP Next<TRandomProvider>(
            ref TRandomProvider randomProvider,
            FixedInt4DP minValue,
            FixedInt4DP maxValue)
            where TRandomProvider : struct, IRandomProvider
        {
            long next = Next(
                ref randomProvider,
                (long)minValue.RawValue,
                (long)maxValue.RawValue);
            return new((int)next);
        }
        /// <summary>
        /// Generates a random FixedInt6DP in [minValue..maxValue).
        /// </summary>
        /// <param name="randomProvider">The random provider.</param>
        /// <param name="minValue">The minimum value (inclusive).</param>
        /// <param name="maxValue">The maximum values (exclusive).</param>
        /// <returns>A random FixedInt6DP in [minValue..maxValue).</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FixedInt6DP Next<TRandomProvider>(
            ref TRandomProvider randomProvider,
            FixedInt6DP minValue,
            FixedInt6DP maxValue)
            where TRandomProvider : struct, IRandomProvider
        {
            long next = Next(
                ref randomProvider,
                (long)minValue.RawValue,
                (long)maxValue.RawValue);
            return new((int)next);
        }
        /// <summary>
        /// Generates a random FixedLong2DP in [minValue..maxValue).
        /// </summary>
        /// <param name="randomProvider">The random provider.</param>
        /// <param name="minValue">The minimum value (inclusive).</param>
        /// <param name="maxValue">The maximum values (exclusive).</param>
        /// <returns>A random FixedLong2DP in [minValue..maxValue).</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FixedLong2DP Next<TRandomProvider>(
            ref TRandomProvider randomProvider,
            FixedLong2DP minValue,
            FixedLong2DP maxValue)
            where TRandomProvider : struct, IRandomProvider
        {
            long next = Next(
                ref randomProvider,
                (long)minValue.RawValue,
                (long)maxValue.RawValue);
            return new((long)next);
        }
        /// <summary>
        /// Generates a random FixedLong4DP in [minValue..maxValue).
        /// </summary>
        /// <param name="randomProvider">The random provider.</param>
        /// <param name="minValue">The minimum value (inclusive).</param>
        /// <param name="maxValue">The maximum values (exclusive).</param>
        /// <returns>A random FixedLong4DP in [minValue..maxValue).</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FixedLong4DP Next<TRandomProvider>(
            ref TRandomProvider randomProvider,
            FixedLong4DP minValue,
            FixedLong4DP maxValue)
            where TRandomProvider : struct, IRandomProvider
        {
            long next = Next(
                ref randomProvider,
                (long)minValue.RawValue,
                (long)maxValue.RawValue);
            return new((long)next);
        }
        /// <summary>
        /// Generates a random FixedLong6DP in [minValue..maxValue).
        /// </summary>
        /// <param name="randomProvider">The random provider.</param>
        /// <param name="minValue">The minimum value (inclusive).</param>
        /// <param name="maxValue">The maximum values (exclusive).</param>
        /// <returns>A random FixedLong6DP in [minValue..maxValue).</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FixedLong6DP Next<TRandomProvider>(
            ref TRandomProvider randomProvider,
            FixedLong6DP minValue,
            FixedLong6DP maxValue)
            where TRandomProvider : struct, IRandomProvider
        {
            long next = Next(
                ref randomProvider,
                (long)minValue.RawValue,
                (long)maxValue.RawValue);
            return new((long)next);
        }
        /// <summary>
        /// Generates a random FixedLong8DP in [minValue..maxValue).
        /// </summary>
        /// <param name="randomProvider">The random provider.</param>
        /// <param name="minValue">The minimum value (inclusive).</param>
        /// <param name="maxValue">The maximum values (exclusive).</param>
        /// <returns>A random FixedLong8DP in [minValue..maxValue).</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FixedLong8DP Next<TRandomProvider>(
            ref TRandomProvider randomProvider,
            FixedLong8DP minValue,
            FixedLong8DP maxValue)
            where TRandomProvider : struct, IRandomProvider
        {
            long next = Next(
                ref randomProvider,
                (long)minValue.RawValue,
                (long)maxValue.RawValue);
            return new((long)next);
        }
    }
}

#pragma warning restore CA2225
#pragma warning restore IDE0004

#endif