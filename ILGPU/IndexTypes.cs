// ---------------------------------------------------------------------------------------
//                                        ILGPU
//                        Copyright (c) 2016-2023 ILGPU Project
//                                    www.ilgpu.net
//
// File: IndexTypes.tt/IndexTypes.cs
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



using ILGPU.Util;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ILGPU
{
    /// <summary>
    /// Represents a 1D index.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    [IndexType((IndexType)1)]
    public readonly partial struct Index1D :
        IIntIndex<Index1D, LongIndex1D>
    {
        #region Static

        /// <summary>
        /// Represents an invalid index (-1);
        /// </summary>
        public static readonly Index1D Invalid = new Index1D(-1);

        /// <summary>
        /// Represents an index with zero.
        /// </summary>
        public static readonly Index1D Zero = new Index1D(0);

        /// <summary>
        /// Represents an index with 1.
        /// </summary>
        public static readonly Index1D One = new Index1D(1);

        /// <summary>
        /// Returns the main constructor to create a new index instance.
        /// </summary>
        internal static ConstructorInfo MainConstructor =
            typeof(Index1D).GetConstructor(
                new Type[]
                {
                    typeof(int)
                })
            .AsNotNull();

        /// <summary>
        /// Computes min(first, second).
        /// </summary>
        /// <param name="first">The first argument.</param>
        /// <param name="second">The second argument.</param>
        /// <returns>The minimum of first and second value.</returns>
        public static Index1D Min(Index1D first, Index1D second) =>
            new Index1D(
                IntrinsicMath.Min(first.X, second.X));

        /// <summary>
        /// Computes max(first, second).
        /// </summary>
        /// <param name="first">The first argument.</param>
        /// <param name="second">The second argument.</param>
        /// <returns>The maximum of first and second value.</returns>
        public static Index1D Max(Index1D first, Index1D second) =>
            new Index1D(
                IntrinsicMath.Max(first.X, second.X));

        /// <summary>
        /// Clamps the given index value according to Max(Min(clamp, max), min).
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <param name="min">The first argument.</param>
        /// <param name="max">The second argument.</param>
        /// <returns>The clamped value in the interval [min, max].</returns>
        public static Index1D Clamp(
            Index1D value,
            Index1D min,
            Index1D max) =>
            new Index1D(
                IntrinsicMath.Clamp(value.X, min.X, max.X));

        #endregion

        #region Instance

        /// <summary>
        /// Constructs a new index.
        /// </summary>
        /// <param name="x">The x value.</param>
        public Index1D(int x)
        {
            X = x;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Returns the X index.
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Returns true if this is the first index.
        /// </summary>
        public readonly bool IsFirst =>
            X == 0;

        /// <summary>
        /// Returns the size represented by this index.
        /// </summary>
        public readonly int Size
        {
            get
            {
                IndexTypeExtensions.AssertIntIndexRange(LongSize);
                return X;
            }
        }

        /// <summary>
        /// Returns the size represented by this index.
        /// </summary>
        public readonly long LongSize =>
            (long)X;

        /// <summary>
        /// Returns the size represented by this index.
        /// </summary>
        readonly long IIndex.Size => LongSize;

        /// <summary>
        /// Returns the current index type.
        /// </summary>
        public readonly IndexType IndexType => (IndexType)1;

        #endregion

        #region Index

        /// <summary>
        /// Converts this index to a long integer index.
        /// </summary>
        /// <returns>The resulting long integer representation.</returns>
        public readonly LongIndex1D ToLongIndex() =>
            new LongIndex1D(
                X);

        #endregion

        #region IGenericIndex

        /// <summary>
        /// Returns true if the current index is greater than or equal to 0 and
        /// is less than the given dimension.
        /// </summary>
        /// <param name="dimension">The dimension bounds.</param>
        /// <returns>True if the current index is inside the given bounds.</returns>
        public readonly bool InBounds(Index1D dimension) =>
            Bitwise.And(X >= 0, X < dimension.X);

        /// <summary>
        /// Returns true if the current index is greater than or equal to 0 and
        /// is less than or equal to the given dimension.
        /// </summary>
        /// <param name="dimension">The dimension bounds.</param>
        /// <returns>True if the current index is inside the given bounds.</returns>
        public readonly bool InBoundsInclusive(Index1D dimension) =>
            Bitwise.And(X >= 0, X <= dimension.X);

        /// <summary>
        /// Computes this + right-hand side.
        /// </summary>
        /// <param name="rhs">The right-hand side of the addition.</param>
        /// <returns>The added index.</returns>
        public readonly Index1D Add(Index1D rhs) => this + rhs;

        /// <summary>
        /// Computes this - right-hand side.
        /// </summary>
        /// <param name="rhs">The right-hand side of the subtraction.</param>
        /// <returns>The subtracted index.</returns>
        public readonly Index1D Subtract(Index1D rhs) => this - rhs;

        #endregion

        #region IEquatable

        /// <summary>
        /// Returns true if the given index is equal to the current index.
        /// </summary>
        /// <param name="other">The other index.</param>
        /// <returns>True, if the given index is equal to the current index.</returns>
        public readonly bool Equals(Index1D other) => this == other;

        #endregion

        #region Object

        /// <summary>
        /// Returns true if the given object is equal to the current index.
        /// </summary>
        /// <param name="obj">The other object.</param>
        /// <returns>True, if the given object is equal to the current index.</returns>
        public readonly override bool Equals(object? obj) =>
            obj is Index1D other && Equals(other);

        /// <summary>
        /// Returns the hash code of this index.
        /// </summary>
        /// <returns>The hash code of this index.</returns>
        public readonly override int GetHashCode() =>
            HashCode.Combine(X);

        /// <summary>
        /// Returns the string representation of this index.
        /// </summary>
        /// <returns>The string representation of this index.</returns>
        public readonly override string ToString() =>
            $"({X})";

        #endregion

        #region Operators

        /// <summary>
        /// Converts this index to a long integer index.
        /// </summary>
        /// <param name="index">The index to convert.</param>
        /// <returns>The resulting long integer representation.</returns>
        public static implicit operator LongIndex1D(Index1D index) =>
            index.ToLongIndex();

        /// <summary>
        /// Adds two indices.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>The added index.</returns>
        public static Index1D Add(Index1D first, Index1D second) =>
            first + second;

        /// <summary>
        /// Adds two indices.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>The added index.</returns>
        public static Index1D operator +(Index1D first, Index1D second) =>
            new Index1D(
                first.X + second.X);

        /// <summary>
        /// Subtracts two indices.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>The subtracted index.</returns>
        public static Index1D Subtract(Index1D first, Index1D second) =>
            first - second;

        /// <summary>
        /// Subtracts two indices.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>The subtracted index.</returns>
        public static Index1D operator -(Index1D first, Index1D second) =>
            new Index1D(
                first.X - second.X);

        /// <summary>
        /// Multiplies two indices.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>The multiplied index.</returns>
        public static Index1D Multiply(Index1D first, Index1D second) =>
            first * second;

        /// <summary>
        /// Multiplies two indices.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>The multiplied index.</returns>
        public static Index1D operator *(Index1D first, Index1D second) =>
            new Index1D(
                first.X * second.X);

        /// <summary>
        /// Divides two indices.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>The divided index.</returns>
        public static Index1D Divide(Index1D first, Index1D second) =>
            first / second;

        /// <summary>
        /// Divides two indices.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>The divided index.</returns>
        public static Index1D operator /(Index1D first, Index1D second) =>
            new Index1D(
                first.X / second.X);

        /// <summary>
        /// Returns true if the first and second index are the same.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>True, if the first and second index are the same.</returns>
        public static bool operator ==(Index1D first, Index1D second) =>
            first.X == second.X;

        /// <summary>
        /// Returns true if the first and second index are not the same.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>True, if the first and second index are not the same.</returns>
        public static bool operator !=(Index1D first, Index1D second) =>
            first.X != second.X;

        #endregion
    }

    /// <summary>
    /// Represents a 2D index.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    [IndexType((IndexType)2)]
    public readonly partial struct Index2D :
        IIntIndex<Index2D, LongIndex2D>
    {
        #region Static

        /// <summary>
        /// Represents an invalid index (-1);
        /// </summary>
        public static readonly Index2D Invalid = new Index2D(-1);

        /// <summary>
        /// Represents an index with zero.
        /// </summary>
        public static readonly Index2D Zero = new Index2D(0);

        /// <summary>
        /// Represents an index with 1.
        /// </summary>
        public static readonly Index2D One = new Index2D(1);

        /// <summary>
        /// Returns the main constructor to create a new index instance.
        /// </summary>
        internal static ConstructorInfo MainConstructor =
            typeof(Index2D).GetConstructor(
                new Type[]
                {
                    typeof(int), typeof(int)
                })
            .AsNotNull();

        /// <summary>
        /// Computes min(first, second).
        /// </summary>
        /// <param name="first">The first argument.</param>
        /// <param name="second">The second argument.</param>
        /// <returns>The minimum of first and second value.</returns>
        public static Index2D Min(Index2D first, Index2D second) =>
            new Index2D(
                IntrinsicMath.Min(first.X, second.X), 
                IntrinsicMath.Min(first.Y, second.Y));

        /// <summary>
        /// Computes max(first, second).
        /// </summary>
        /// <param name="first">The first argument.</param>
        /// <param name="second">The second argument.</param>
        /// <returns>The maximum of first and second value.</returns>
        public static Index2D Max(Index2D first, Index2D second) =>
            new Index2D(
                IntrinsicMath.Max(first.X, second.X), 
                IntrinsicMath.Max(first.Y, second.Y));

        /// <summary>
        /// Clamps the given index value according to Max(Min(clamp, max), min).
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <param name="min">The first argument.</param>
        /// <param name="max">The second argument.</param>
        /// <returns>The clamped value in the interval [min, max].</returns>
        public static Index2D Clamp(
            Index2D value,
            Index2D min,
            Index2D max) =>
            new Index2D(
                IntrinsicMath.Clamp(value.X, min.X, max.X), 
                IntrinsicMath.Clamp(value.Y, min.Y, max.Y));

        #endregion

        #region Instance

        /// <summary>
        /// Constructs a new index using a single value for each component.
        /// </summary>
        /// <param name="value">The value.</param>
        public Index2D(int value)
        {
            X = value;
            Y = value;
        }

        /// <summary>
        /// Constructs a new index.
        /// </summary>
        /// <param name="x">The x value.</param>
        /// <param name="y">The y value.</param>
        public Index2D(int x, int y)
        {
            X = x;
            Y = y;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Returns the X index.
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Returns the Y index.
        /// </summary>
        public int Y { get; }

        /// <summary>
        /// Returns true if this is the first index.
        /// </summary>
        public readonly bool IsFirst =>
            Bitwise.And(X == 0, Y == 0);

        /// <summary>
        /// Returns the size represented by this index.
        /// </summary>
        public readonly int Size
        {
            get
            {
                IndexTypeExtensions.AssertIntIndexRange(LongSize);
                return X * Y;
            }
        }

        /// <summary>
        /// Returns the size represented by this index.
        /// </summary>
        public readonly long LongSize =>
            (long)X * Y;

        /// <summary>
        /// Returns the size represented by this index.
        /// </summary>
        readonly long IIndex.Size => LongSize;

        /// <summary>
        /// Returns the current index type.
        /// </summary>
        public readonly IndexType IndexType => (IndexType)2;

        #endregion

        #region Index

        /// <summary>
        /// Converts this index to a long integer index.
        /// </summary>
        /// <returns>The resulting long integer representation.</returns>
        public readonly LongIndex2D ToLongIndex() =>
            new LongIndex2D(
                X, Y);

        #endregion

        #region IGenericIndex

        /// <summary>
        /// Returns true if the current index is greater than or equal to 0 and
        /// is less than the given dimension.
        /// </summary>
        /// <param name="dimension">The dimension bounds.</param>
        /// <returns>True if the current index is inside the given bounds.</returns>
        public readonly bool InBounds(Index2D dimension) =>
            Bitwise.And(Bitwise.And(X >= 0, X < dimension.X), Bitwise.And(Y >= 0, Y < dimension.Y));

        /// <summary>
        /// Returns true if the current index is greater than or equal to 0 and
        /// is less than or equal to the given dimension.
        /// </summary>
        /// <param name="dimension">The dimension bounds.</param>
        /// <returns>True if the current index is inside the given bounds.</returns>
        public readonly bool InBoundsInclusive(Index2D dimension) =>
            Bitwise.And(Bitwise.And(X >= 0, X <= dimension.X), Bitwise.And(Y >= 0, Y <= dimension.Y));

        /// <summary>
        /// Computes this + right-hand side.
        /// </summary>
        /// <param name="rhs">The right-hand side of the addition.</param>
        /// <returns>The added index.</returns>
        public readonly Index2D Add(Index2D rhs) => this + rhs;

        /// <summary>
        /// Computes this - right-hand side.
        /// </summary>
        /// <param name="rhs">The right-hand side of the subtraction.</param>
        /// <returns>The subtracted index.</returns>
        public readonly Index2D Subtract(Index2D rhs) => this - rhs;

        #endregion

        #region ValueTuple

        /// <summary>
        /// Returns a value tuple that stores all dimensions.
        /// </summary>
        /// <returns>The constructed value tuple.</returns>
        public (int X, int Y) ToValueTuple() =>
            (X, Y);

        /// <summary>
        /// Deconstructs the current instance into a tuple.
        /// </summary>
        /// <param name="x">The x value.</param>
        /// <param name="y">The y value.</param>
        public void Deconstruct(
            out int x, out int y)
        {
            x = X;
            y = Y;
        }

        #endregion

        #region IEquatable

        /// <summary>
        /// Returns true if the given index is equal to the current index.
        /// </summary>
        /// <param name="other">The other index.</param>
        /// <returns>True, if the given index is equal to the current index.</returns>
        public readonly bool Equals(Index2D other) => this == other;

        #endregion

        #region Object

        /// <summary>
        /// Returns true if the given object is equal to the current index.
        /// </summary>
        /// <param name="obj">The other object.</param>
        /// <returns>True, if the given object is equal to the current index.</returns>
        public readonly override bool Equals(object? obj) =>
            obj is Index2D other && Equals(other);

        /// <summary>
        /// Returns the hash code of this index.
        /// </summary>
        /// <returns>The hash code of this index.</returns>
        public readonly override int GetHashCode() =>
            HashCode.Combine(X, Y);

        /// <summary>
        /// Returns the string representation of this index.
        /// </summary>
        /// <returns>The string representation of this index.</returns>
        public readonly override string ToString() =>
            $"({X}, {Y})";

        #endregion

        #region Operators

        /// <summary>
        /// Converts this index to a long integer index.
        /// </summary>
        /// <param name="index">The index to convert.</param>
        /// <returns>The resulting long integer representation.</returns>
        public static implicit operator LongIndex2D(Index2D index) =>
            index.ToLongIndex();

        /// <summary>
        /// Converts the given value tuple into an equivalent <see cref="Index2D"/>.
        /// </summary>
        /// <param name="values">The values.</param>
        public static implicit operator Index2D(
            (int, int) values) =>
            new Index2D(
                values.Item1
                , values.Item2
                );

        /// <summary>
        /// Adds two indices.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>The added index.</returns>
        public static Index2D Add(Index2D first, Index2D second) =>
            first + second;

        /// <summary>
        /// Adds two indices.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>The added index.</returns>
        public static Index2D operator +(Index2D first, Index2D second) =>
            new Index2D(
                first.X + second.X, first.Y + second.Y);

        /// <summary>
        /// Subtracts two indices.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>The subtracted index.</returns>
        public static Index2D Subtract(Index2D first, Index2D second) =>
            first - second;

        /// <summary>
        /// Subtracts two indices.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>The subtracted index.</returns>
        public static Index2D operator -(Index2D first, Index2D second) =>
            new Index2D(
                first.X - second.X, first.Y - second.Y);

        /// <summary>
        /// Multiplies two indices.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>The multiplied index.</returns>
        public static Index2D Multiply(Index2D first, Index2D second) =>
            first * second;

        /// <summary>
        /// Multiplies two indices.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>The multiplied index.</returns>
        public static Index2D operator *(Index2D first, Index2D second) =>
            new Index2D(
                first.X * second.X, first.Y * second.Y);

        /// <summary>
        /// Divides two indices.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>The divided index.</returns>
        public static Index2D Divide(Index2D first, Index2D second) =>
            first / second;

        /// <summary>
        /// Divides two indices.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>The divided index.</returns>
        public static Index2D operator /(Index2D first, Index2D second) =>
            new Index2D(
                first.X / second.X, first.Y / second.Y);

        /// <summary>
        /// Returns true if the first and second index are the same.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>True, if the first and second index are the same.</returns>
        public static bool operator ==(Index2D first, Index2D second) =>
            Bitwise.And(first.X == second.X, first.Y == second.Y);

        /// <summary>
        /// Returns true if the first and second index are not the same.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>True, if the first and second index are not the same.</returns>
        public static bool operator !=(Index2D first, Index2D second) =>
            Bitwise.Or(first.X != second.X, first.Y != second.Y);

        #endregion
    }

    /// <summary>
    /// Represents a 3D index.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    [IndexType((IndexType)3)]
    public readonly partial struct Index3D :
        IIntIndex<Index3D, LongIndex3D>
    {
        #region Static

        /// <summary>
        /// Represents an invalid index (-1);
        /// </summary>
        public static readonly Index3D Invalid = new Index3D(-1);

        /// <summary>
        /// Represents an index with zero.
        /// </summary>
        public static readonly Index3D Zero = new Index3D(0);

        /// <summary>
        /// Represents an index with 1.
        /// </summary>
        public static readonly Index3D One = new Index3D(1);

        /// <summary>
        /// Returns the main constructor to create a new index instance.
        /// </summary>
        internal static ConstructorInfo MainConstructor =
            typeof(Index3D).GetConstructor(
                new Type[]
                {
                    typeof(int), typeof(int), typeof(int)
                })
            .AsNotNull();

        /// <summary>
        /// Computes min(first, second).
        /// </summary>
        /// <param name="first">The first argument.</param>
        /// <param name="second">The second argument.</param>
        /// <returns>The minimum of first and second value.</returns>
        public static Index3D Min(Index3D first, Index3D second) =>
            new Index3D(
                IntrinsicMath.Min(first.X, second.X), 
                IntrinsicMath.Min(first.Y, second.Y), 
                IntrinsicMath.Min(first.Z, second.Z));

        /// <summary>
        /// Computes max(first, second).
        /// </summary>
        /// <param name="first">The first argument.</param>
        /// <param name="second">The second argument.</param>
        /// <returns>The maximum of first and second value.</returns>
        public static Index3D Max(Index3D first, Index3D second) =>
            new Index3D(
                IntrinsicMath.Max(first.X, second.X), 
                IntrinsicMath.Max(first.Y, second.Y), 
                IntrinsicMath.Max(first.Z, second.Z));

        /// <summary>
        /// Clamps the given index value according to Max(Min(clamp, max), min).
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <param name="min">The first argument.</param>
        /// <param name="max">The second argument.</param>
        /// <returns>The clamped value in the interval [min, max].</returns>
        public static Index3D Clamp(
            Index3D value,
            Index3D min,
            Index3D max) =>
            new Index3D(
                IntrinsicMath.Clamp(value.X, min.X, max.X), 
                IntrinsicMath.Clamp(value.Y, min.Y, max.Y), 
                IntrinsicMath.Clamp(value.Z, min.Z, max.Z));

        #endregion

        #region Instance

        /// <summary>
        /// Constructs a new index using a single value for each component.
        /// </summary>
        /// <param name="value">The value.</param>
        public Index3D(int value)
        {
            X = value;
            Y = value;
            Z = value;
        }

        /// <summary>
        /// Constructs a new index.
        /// </summary>
        /// <param name="x">The x value.</param>
        /// <param name="y">The y value.</param>
        /// <param name="z">The z value.</param>
        public Index3D(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Returns the X index.
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Returns the Y index.
        /// </summary>
        public int Y { get; }

        /// <summary>
        /// Returns the Z index.
        /// </summary>
        public int Z { get; }

        /// <summary>
        /// Returns true if this is the first index.
        /// </summary>
        public readonly bool IsFirst =>
            Bitwise.And(X == 0, Y == 0, Z == 0);

        /// <summary>
        /// Returns the size represented by this index.
        /// </summary>
        public readonly int Size
        {
            get
            {
                IndexTypeExtensions.AssertIntIndexRange(LongSize);
                return X * Y * Z;
            }
        }

        /// <summary>
        /// Returns the size represented by this index.
        /// </summary>
        public readonly long LongSize =>
            (long)X * Y * Z;

        /// <summary>
        /// Returns the size represented by this index.
        /// </summary>
        readonly long IIndex.Size => LongSize;

        /// <summary>
        /// Returns the current index type.
        /// </summary>
        public readonly IndexType IndexType => (IndexType)3;

        #endregion

        #region Index

        /// <summary>
        /// Converts this index to a long integer index.
        /// </summary>
        /// <returns>The resulting long integer representation.</returns>
        public readonly LongIndex3D ToLongIndex() =>
            new LongIndex3D(
                X, Y, Z);

        #endregion

        #region IGenericIndex

        /// <summary>
        /// Returns true if the current index is greater than or equal to 0 and
        /// is less than the given dimension.
        /// </summary>
        /// <param name="dimension">The dimension bounds.</param>
        /// <returns>True if the current index is inside the given bounds.</returns>
        public readonly bool InBounds(Index3D dimension) =>
            Bitwise.And(Bitwise.And(X >= 0, X < dimension.X), Bitwise.And(Y >= 0, Y < dimension.Y), Bitwise.And(Z >= 0, Z < dimension.Z));

        /// <summary>
        /// Returns true if the current index is greater than or equal to 0 and
        /// is less than or equal to the given dimension.
        /// </summary>
        /// <param name="dimension">The dimension bounds.</param>
        /// <returns>True if the current index is inside the given bounds.</returns>
        public readonly bool InBoundsInclusive(Index3D dimension) =>
            Bitwise.And(Bitwise.And(X >= 0, X <= dimension.X), Bitwise.And(Y >= 0, Y <= dimension.Y), Bitwise.And(Z >= 0, Z <= dimension.Z));

        /// <summary>
        /// Computes this + right-hand side.
        /// </summary>
        /// <param name="rhs">The right-hand side of the addition.</param>
        /// <returns>The added index.</returns>
        public readonly Index3D Add(Index3D rhs) => this + rhs;

        /// <summary>
        /// Computes this - right-hand side.
        /// </summary>
        /// <param name="rhs">The right-hand side of the subtraction.</param>
        /// <returns>The subtracted index.</returns>
        public readonly Index3D Subtract(Index3D rhs) => this - rhs;

        #endregion

        #region ValueTuple

        /// <summary>
        /// Returns a value tuple that stores all dimensions.
        /// </summary>
        /// <returns>The constructed value tuple.</returns>
        public (int X, int Y, int Z) ToValueTuple() =>
            (X, Y, Z);

        /// <summary>
        /// Deconstructs the current instance into a tuple.
        /// </summary>
        /// <param name="x">The x value.</param>
        /// <param name="y">The y value.</param>
        /// <param name="z">The z value.</param>
        public void Deconstruct(
            out int x, out int y, out int z)
        {
            x = X;
            y = Y;
            z = Z;
        }

        #endregion

        #region IEquatable

        /// <summary>
        /// Returns true if the given index is equal to the current index.
        /// </summary>
        /// <param name="other">The other index.</param>
        /// <returns>True, if the given index is equal to the current index.</returns>
        public readonly bool Equals(Index3D other) => this == other;

        #endregion

        #region Object

        /// <summary>
        /// Returns true if the given object is equal to the current index.
        /// </summary>
        /// <param name="obj">The other object.</param>
        /// <returns>True, if the given object is equal to the current index.</returns>
        public readonly override bool Equals(object? obj) =>
            obj is Index3D other && Equals(other);

        /// <summary>
        /// Returns the hash code of this index.
        /// </summary>
        /// <returns>The hash code of this index.</returns>
        public readonly override int GetHashCode() =>
            HashCode.Combine(X, Y, Z);

        /// <summary>
        /// Returns the string representation of this index.
        /// </summary>
        /// <returns>The string representation of this index.</returns>
        public readonly override string ToString() =>
            $"({X}, {Y}, {Z})";

        #endregion

        #region Operators

        /// <summary>
        /// Converts this index to a long integer index.
        /// </summary>
        /// <param name="index">The index to convert.</param>
        /// <returns>The resulting long integer representation.</returns>
        public static implicit operator LongIndex3D(Index3D index) =>
            index.ToLongIndex();

        /// <summary>
        /// Converts the given value tuple into an equivalent <see cref="Index3D"/>.
        /// </summary>
        /// <param name="values">The values.</param>
        public static implicit operator Index3D(
            (int, int, int) values) =>
            new Index3D(
                values.Item1
                , values.Item2
                , values.Item3
                );

        /// <summary>
        /// Adds two indices.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>The added index.</returns>
        public static Index3D Add(Index3D first, Index3D second) =>
            first + second;

        /// <summary>
        /// Adds two indices.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>The added index.</returns>
        public static Index3D operator +(Index3D first, Index3D second) =>
            new Index3D(
                first.X + second.X, first.Y + second.Y, first.Z + second.Z);

        /// <summary>
        /// Subtracts two indices.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>The subtracted index.</returns>
        public static Index3D Subtract(Index3D first, Index3D second) =>
            first - second;

        /// <summary>
        /// Subtracts two indices.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>The subtracted index.</returns>
        public static Index3D operator -(Index3D first, Index3D second) =>
            new Index3D(
                first.X - second.X, first.Y - second.Y, first.Z - second.Z);

        /// <summary>
        /// Multiplies two indices.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>The multiplied index.</returns>
        public static Index3D Multiply(Index3D first, Index3D second) =>
            first * second;

        /// <summary>
        /// Multiplies two indices.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>The multiplied index.</returns>
        public static Index3D operator *(Index3D first, Index3D second) =>
            new Index3D(
                first.X * second.X, first.Y * second.Y, first.Z * second.Z);

        /// <summary>
        /// Divides two indices.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>The divided index.</returns>
        public static Index3D Divide(Index3D first, Index3D second) =>
            first / second;

        /// <summary>
        /// Divides two indices.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>The divided index.</returns>
        public static Index3D operator /(Index3D first, Index3D second) =>
            new Index3D(
                first.X / second.X, first.Y / second.Y, first.Z / second.Z);

        /// <summary>
        /// Returns true if the first and second index are the same.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>True, if the first and second index are the same.</returns>
        public static bool operator ==(Index3D first, Index3D second) =>
            Bitwise.And(first.X == second.X, first.Y == second.Y, first.Z == second.Z);

        /// <summary>
        /// Returns true if the first and second index are not the same.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>True, if the first and second index are not the same.</returns>
        public static bool operator !=(Index3D first, Index3D second) =>
            Bitwise.Or(first.X != second.X, first.Y != second.Y, first.Z != second.Z);

        #endregion
    }

    /// <summary>
    /// Represents a 1D index.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    [IndexType((IndexType)4)]
    public readonly partial struct LongIndex1D :
        ILongIndex<LongIndex1D, Index1D>
    {
        #region Static

        /// <summary>
        /// Represents an invalid index (-1);
        /// </summary>
        public static readonly LongIndex1D Invalid = new LongIndex1D(-1);

        /// <summary>
        /// Represents an index with zero.
        /// </summary>
        public static readonly LongIndex1D Zero = new LongIndex1D(0);

        /// <summary>
        /// Represents an index with 1.
        /// </summary>
        public static readonly LongIndex1D One = new LongIndex1D(1);

        /// <summary>
        /// Returns the main constructor to create a new index instance.
        /// </summary>
        internal static ConstructorInfo MainConstructor =
            typeof(LongIndex1D).GetConstructor(
                new Type[]
                {
                    typeof(long)
                })
            .AsNotNull();

        /// <summary>
        /// Computes min(first, second).
        /// </summary>
        /// <param name="first">The first argument.</param>
        /// <param name="second">The second argument.</param>
        /// <returns>The minimum of first and second value.</returns>
        public static LongIndex1D Min(LongIndex1D first, LongIndex1D second) =>
            new LongIndex1D(
                IntrinsicMath.Min(first.X, second.X));

        /// <summary>
        /// Computes max(first, second).
        /// </summary>
        /// <param name="first">The first argument.</param>
        /// <param name="second">The second argument.</param>
        /// <returns>The maximum of first and second value.</returns>
        public static LongIndex1D Max(LongIndex1D first, LongIndex1D second) =>
            new LongIndex1D(
                IntrinsicMath.Max(first.X, second.X));

        /// <summary>
        /// Clamps the given index value according to Max(Min(clamp, max), min).
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <param name="min">The first argument.</param>
        /// <param name="max">The second argument.</param>
        /// <returns>The clamped value in the interval [min, max].</returns>
        public static LongIndex1D Clamp(
            LongIndex1D value,
            LongIndex1D min,
            LongIndex1D max) =>
            new LongIndex1D(
                IntrinsicMath.Clamp(value.X, min.X, max.X));

        #endregion

        #region Instance

        /// <summary>
        /// Constructs a new index.
        /// </summary>
        /// <param name="x">The x value.</param>
        public LongIndex1D(long x)
        {
            X = x;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Returns the X index.
        /// </summary>
        public long X { get; }

        /// <summary>
        /// Returns true if this is the first index.
        /// </summary>
        public readonly bool IsFirst =>
            X == 0;

        /// <summary>
        /// Returns the size represented by this index.
        /// </summary>
        /// <summary>
        /// Returns the size represented by this index.
        /// </summary>
        public readonly long Size =>
            X;

        /// <summary>
        /// Returns the current index type.
        /// </summary>
        public readonly IndexType IndexType => (IndexType)4;

        #endregion

        #region Index

        /// <summary>
        /// Converts this index to an integer index.
        /// </summary>
        /// <returns>The resulting integer representation.</returns>
        public readonly Index1D ToIntIndex()
        {
            IndexTypeExtensions.AssertIntIndexRange(X);
            return new Index1D(
                (int)X);
        }

        #endregion

        #region IGenericIndex

        /// <summary>
        /// Returns true if the current index is greater than or equal to 0 and
        /// is less than the given dimension.
        /// </summary>
        /// <param name="dimension">The dimension bounds.</param>
        /// <returns>True if the current index is inside the given bounds.</returns>
        public readonly bool InBounds(LongIndex1D dimension) =>
            Bitwise.And(X >= 0, X < dimension.X);

        /// <summary>
        /// Returns true if the current index is greater than or equal to 0 and
        /// is less than or equal to the given dimension.
        /// </summary>
        /// <param name="dimension">The dimension bounds.</param>
        /// <returns>True if the current index is inside the given bounds.</returns>
        public readonly bool InBoundsInclusive(LongIndex1D dimension) =>
            Bitwise.And(X >= 0, X <= dimension.X);

        /// <summary>
        /// Computes this + right-hand side.
        /// </summary>
        /// <param name="rhs">The right-hand side of the addition.</param>
        /// <returns>The added index.</returns>
        public readonly LongIndex1D Add(LongIndex1D rhs) => this + rhs;

        /// <summary>
        /// Computes this - right-hand side.
        /// </summary>
        /// <param name="rhs">The right-hand side of the subtraction.</param>
        /// <returns>The subtracted index.</returns>
        public readonly LongIndex1D Subtract(LongIndex1D rhs) => this - rhs;

        #endregion

        #region IEquatable

        /// <summary>
        /// Returns true if the given index is equal to the current index.
        /// </summary>
        /// <param name="other">The other index.</param>
        /// <returns>True, if the given index is equal to the current index.</returns>
        public readonly bool Equals(LongIndex1D other) => this == other;

        #endregion

        #region Object

        /// <summary>
        /// Returns true if the given object is equal to the current index.
        /// </summary>
        /// <param name="obj">The other object.</param>
        /// <returns>True, if the given object is equal to the current index.</returns>
        public readonly override bool Equals(object? obj) =>
            obj is LongIndex1D other && Equals(other);

        /// <summary>
        /// Returns the hash code of this index.
        /// </summary>
        /// <returns>The hash code of this index.</returns>
        public readonly override int GetHashCode() =>
            HashCode.Combine(X);

        /// <summary>
        /// Returns the string representation of this index.
        /// </summary>
        /// <returns>The string representation of this index.</returns>
        public readonly override string ToString() =>
            $"({X})";

        #endregion

        #region Operators

        /// <summary>
        /// Converts this index to an integer index.
        /// </summary>
        /// <param name="index">The index to convert.</param>
        /// <returns>The resulting integer representation.</returns>
        public static explicit operator Index1D(LongIndex1D index) =>
            index.ToIntIndex();

        /// <summary>
        /// Adds two indices.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>The added index.</returns>
        public static LongIndex1D Add(LongIndex1D first, LongIndex1D second) =>
            first + second;

        /// <summary>
        /// Adds two indices.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>The added index.</returns>
        public static LongIndex1D operator +(LongIndex1D first, LongIndex1D second) =>
            new LongIndex1D(
                first.X + second.X);

        /// <summary>
        /// Subtracts two indices.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>The subtracted index.</returns>
        public static LongIndex1D Subtract(LongIndex1D first, LongIndex1D second) =>
            first - second;

        /// <summary>
        /// Subtracts two indices.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>The subtracted index.</returns>
        public static LongIndex1D operator -(LongIndex1D first, LongIndex1D second) =>
            new LongIndex1D(
                first.X - second.X);

        /// <summary>
        /// Multiplies two indices.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>The multiplied index.</returns>
        public static LongIndex1D Multiply(LongIndex1D first, LongIndex1D second) =>
            first * second;

        /// <summary>
        /// Multiplies two indices.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>The multiplied index.</returns>
        public static LongIndex1D operator *(LongIndex1D first, LongIndex1D second) =>
            new LongIndex1D(
                first.X * second.X);

        /// <summary>
        /// Divides two indices.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>The divided index.</returns>
        public static LongIndex1D Divide(LongIndex1D first, LongIndex1D second) =>
            first / second;

        /// <summary>
        /// Divides two indices.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>The divided index.</returns>
        public static LongIndex1D operator /(LongIndex1D first, LongIndex1D second) =>
            new LongIndex1D(
                first.X / second.X);

        /// <summary>
        /// Returns true if the first and second index are the same.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>True, if the first and second index are the same.</returns>
        public static bool operator ==(LongIndex1D first, LongIndex1D second) =>
            first.X == second.X;

        /// <summary>
        /// Returns true if the first and second index are not the same.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>True, if the first and second index are not the same.</returns>
        public static bool operator !=(LongIndex1D first, LongIndex1D second) =>
            first.X != second.X;

        #endregion
    }

    /// <summary>
    /// Represents a 2D index.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    [IndexType((IndexType)5)]
    public readonly partial struct LongIndex2D :
        ILongIndex<LongIndex2D, Index2D>
    {
        #region Static

        /// <summary>
        /// Represents an invalid index (-1);
        /// </summary>
        public static readonly LongIndex2D Invalid = new LongIndex2D(-1);

        /// <summary>
        /// Represents an index with zero.
        /// </summary>
        public static readonly LongIndex2D Zero = new LongIndex2D(0);

        /// <summary>
        /// Represents an index with 1.
        /// </summary>
        public static readonly LongIndex2D One = new LongIndex2D(1);

        /// <summary>
        /// Returns the main constructor to create a new index instance.
        /// </summary>
        internal static ConstructorInfo MainConstructor =
            typeof(LongIndex2D).GetConstructor(
                new Type[]
                {
                    typeof(long), typeof(long)
                })
            .AsNotNull();

        /// <summary>
        /// Computes min(first, second).
        /// </summary>
        /// <param name="first">The first argument.</param>
        /// <param name="second">The second argument.</param>
        /// <returns>The minimum of first and second value.</returns>
        public static LongIndex2D Min(LongIndex2D first, LongIndex2D second) =>
            new LongIndex2D(
                IntrinsicMath.Min(first.X, second.X), 
                IntrinsicMath.Min(first.Y, second.Y));

        /// <summary>
        /// Computes max(first, second).
        /// </summary>
        /// <param name="first">The first argument.</param>
        /// <param name="second">The second argument.</param>
        /// <returns>The maximum of first and second value.</returns>
        public static LongIndex2D Max(LongIndex2D first, LongIndex2D second) =>
            new LongIndex2D(
                IntrinsicMath.Max(first.X, second.X), 
                IntrinsicMath.Max(first.Y, second.Y));

        /// <summary>
        /// Clamps the given index value according to Max(Min(clamp, max), min).
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <param name="min">The first argument.</param>
        /// <param name="max">The second argument.</param>
        /// <returns>The clamped value in the interval [min, max].</returns>
        public static LongIndex2D Clamp(
            LongIndex2D value,
            LongIndex2D min,
            LongIndex2D max) =>
            new LongIndex2D(
                IntrinsicMath.Clamp(value.X, min.X, max.X), 
                IntrinsicMath.Clamp(value.Y, min.Y, max.Y));

        #endregion

        #region Instance

        /// <summary>
        /// Constructs a new index using a single value for each component.
        /// </summary>
        /// <param name="value">The value.</param>
        public LongIndex2D(long value)
        {
            X = value;
            Y = value;
        }

        /// <summary>
        /// Constructs a new index.
        /// </summary>
        /// <param name="x">The x value.</param>
        /// <param name="y">The y value.</param>
        public LongIndex2D(long x, long y)
        {
            X = x;
            Y = y;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Returns the X index.
        /// </summary>
        public long X { get; }

        /// <summary>
        /// Returns the Y index.
        /// </summary>
        public long Y { get; }

        /// <summary>
        /// Returns true if this is the first index.
        /// </summary>
        public readonly bool IsFirst =>
            Bitwise.And(X == 0, Y == 0);

        /// <summary>
        /// Returns the size represented by this index.
        /// </summary>
        /// <summary>
        /// Returns the size represented by this index.
        /// </summary>
        public readonly long Size =>
            X * Y;

        /// <summary>
        /// Returns the current index type.
        /// </summary>
        public readonly IndexType IndexType => (IndexType)5;

        #endregion

        #region Index

        /// <summary>
        /// Converts this index to an integer index.
        /// </summary>
        /// <returns>The resulting integer representation.</returns>
        public readonly Index2D ToIntIndex()
        {
            IndexTypeExtensions.AssertIntIndexRange(X);
            IndexTypeExtensions.AssertIntIndexRange(Y);
            return new Index2D(
                (int)X, (int)Y);
        }

        #endregion

        #region IGenericIndex

        /// <summary>
        /// Returns true if the current index is greater than or equal to 0 and
        /// is less than the given dimension.
        /// </summary>
        /// <param name="dimension">The dimension bounds.</param>
        /// <returns>True if the current index is inside the given bounds.</returns>
        public readonly bool InBounds(LongIndex2D dimension) =>
            Bitwise.And(Bitwise.And(X >= 0, X < dimension.X), Bitwise.And(Y >= 0, Y < dimension.Y));

        /// <summary>
        /// Returns true if the current index is greater than or equal to 0 and
        /// is less than or equal to the given dimension.
        /// </summary>
        /// <param name="dimension">The dimension bounds.</param>
        /// <returns>True if the current index is inside the given bounds.</returns>
        public readonly bool InBoundsInclusive(LongIndex2D dimension) =>
            Bitwise.And(Bitwise.And(X >= 0, X <= dimension.X), Bitwise.And(Y >= 0, Y <= dimension.Y));

        /// <summary>
        /// Computes this + right-hand side.
        /// </summary>
        /// <param name="rhs">The right-hand side of the addition.</param>
        /// <returns>The added index.</returns>
        public readonly LongIndex2D Add(LongIndex2D rhs) => this + rhs;

        /// <summary>
        /// Computes this - right-hand side.
        /// </summary>
        /// <param name="rhs">The right-hand side of the subtraction.</param>
        /// <returns>The subtracted index.</returns>
        public readonly LongIndex2D Subtract(LongIndex2D rhs) => this - rhs;

        #endregion

        #region ValueTuple

        /// <summary>
        /// Returns a value tuple that stores all dimensions.
        /// </summary>
        /// <returns>The constructed value tuple.</returns>
        public (long X, long Y) ToValueTuple() =>
            (X, Y);

        /// <summary>
        /// Deconstructs the current instance into a tuple.
        /// </summary>
        /// <param name="x">The x value.</param>
        /// <param name="y">The y value.</param>
        public void Deconstruct(
            out long x, out long y)
        {
            x = X;
            y = Y;
        }

        #endregion

        #region IEquatable

        /// <summary>
        /// Returns true if the given index is equal to the current index.
        /// </summary>
        /// <param name="other">The other index.</param>
        /// <returns>True, if the given index is equal to the current index.</returns>
        public readonly bool Equals(LongIndex2D other) => this == other;

        #endregion

        #region Object

        /// <summary>
        /// Returns true if the given object is equal to the current index.
        /// </summary>
        /// <param name="obj">The other object.</param>
        /// <returns>True, if the given object is equal to the current index.</returns>
        public readonly override bool Equals(object? obj) =>
            obj is LongIndex2D other && Equals(other);

        /// <summary>
        /// Returns the hash code of this index.
        /// </summary>
        /// <returns>The hash code of this index.</returns>
        public readonly override int GetHashCode() =>
            HashCode.Combine(X, Y);

        /// <summary>
        /// Returns the string representation of this index.
        /// </summary>
        /// <returns>The string representation of this index.</returns>
        public readonly override string ToString() =>
            $"({X}, {Y})";

        #endregion

        #region Operators

        /// <summary>
        /// Converts this index to an integer index.
        /// </summary>
        /// <param name="index">The index to convert.</param>
        /// <returns>The resulting integer representation.</returns>
        public static explicit operator Index2D(LongIndex2D index) =>
            index.ToIntIndex();

        /// <summary>
        /// Converts the given value tuple into an equivalent <see cref="LongIndex2D"/>.
        /// </summary>
        /// <param name="values">The values.</param>
        public static implicit operator LongIndex2D(
            (long, long) values) =>
            new LongIndex2D(
                values.Item1
                , values.Item2
                );

        /// <summary>
        /// Adds two indices.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>The added index.</returns>
        public static LongIndex2D Add(LongIndex2D first, LongIndex2D second) =>
            first + second;

        /// <summary>
        /// Adds two indices.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>The added index.</returns>
        public static LongIndex2D operator +(LongIndex2D first, LongIndex2D second) =>
            new LongIndex2D(
                first.X + second.X, first.Y + second.Y);

        /// <summary>
        /// Subtracts two indices.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>The subtracted index.</returns>
        public static LongIndex2D Subtract(LongIndex2D first, LongIndex2D second) =>
            first - second;

        /// <summary>
        /// Subtracts two indices.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>The subtracted index.</returns>
        public static LongIndex2D operator -(LongIndex2D first, LongIndex2D second) =>
            new LongIndex2D(
                first.X - second.X, first.Y - second.Y);

        /// <summary>
        /// Multiplies two indices.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>The multiplied index.</returns>
        public static LongIndex2D Multiply(LongIndex2D first, LongIndex2D second) =>
            first * second;

        /// <summary>
        /// Multiplies two indices.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>The multiplied index.</returns>
        public static LongIndex2D operator *(LongIndex2D first, LongIndex2D second) =>
            new LongIndex2D(
                first.X * second.X, first.Y * second.Y);

        /// <summary>
        /// Divides two indices.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>The divided index.</returns>
        public static LongIndex2D Divide(LongIndex2D first, LongIndex2D second) =>
            first / second;

        /// <summary>
        /// Divides two indices.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>The divided index.</returns>
        public static LongIndex2D operator /(LongIndex2D first, LongIndex2D second) =>
            new LongIndex2D(
                first.X / second.X, first.Y / second.Y);

        /// <summary>
        /// Returns true if the first and second index are the same.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>True, if the first and second index are the same.</returns>
        public static bool operator ==(LongIndex2D first, LongIndex2D second) =>
            Bitwise.And(first.X == second.X, first.Y == second.Y);

        /// <summary>
        /// Returns true if the first and second index are not the same.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>True, if the first and second index are not the same.</returns>
        public static bool operator !=(LongIndex2D first, LongIndex2D second) =>
            Bitwise.Or(first.X != second.X, first.Y != second.Y);

        #endregion
    }

    /// <summary>
    /// Represents a 3D index.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    [IndexType((IndexType)6)]
    public readonly partial struct LongIndex3D :
        ILongIndex<LongIndex3D, Index3D>
    {
        #region Static

        /// <summary>
        /// Represents an invalid index (-1);
        /// </summary>
        public static readonly LongIndex3D Invalid = new LongIndex3D(-1);

        /// <summary>
        /// Represents an index with zero.
        /// </summary>
        public static readonly LongIndex3D Zero = new LongIndex3D(0);

        /// <summary>
        /// Represents an index with 1.
        /// </summary>
        public static readonly LongIndex3D One = new LongIndex3D(1);

        /// <summary>
        /// Returns the main constructor to create a new index instance.
        /// </summary>
        internal static ConstructorInfo MainConstructor =
            typeof(LongIndex3D).GetConstructor(
                new Type[]
                {
                    typeof(long), typeof(long), typeof(long)
                })
            .AsNotNull();

        /// <summary>
        /// Computes min(first, second).
        /// </summary>
        /// <param name="first">The first argument.</param>
        /// <param name="second">The second argument.</param>
        /// <returns>The minimum of first and second value.</returns>
        public static LongIndex3D Min(LongIndex3D first, LongIndex3D second) =>
            new LongIndex3D(
                IntrinsicMath.Min(first.X, second.X), 
                IntrinsicMath.Min(first.Y, second.Y), 
                IntrinsicMath.Min(first.Z, second.Z));

        /// <summary>
        /// Computes max(first, second).
        /// </summary>
        /// <param name="first">The first argument.</param>
        /// <param name="second">The second argument.</param>
        /// <returns>The maximum of first and second value.</returns>
        public static LongIndex3D Max(LongIndex3D first, LongIndex3D second) =>
            new LongIndex3D(
                IntrinsicMath.Max(first.X, second.X), 
                IntrinsicMath.Max(first.Y, second.Y), 
                IntrinsicMath.Max(first.Z, second.Z));

        /// <summary>
        /// Clamps the given index value according to Max(Min(clamp, max), min).
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <param name="min">The first argument.</param>
        /// <param name="max">The second argument.</param>
        /// <returns>The clamped value in the interval [min, max].</returns>
        public static LongIndex3D Clamp(
            LongIndex3D value,
            LongIndex3D min,
            LongIndex3D max) =>
            new LongIndex3D(
                IntrinsicMath.Clamp(value.X, min.X, max.X), 
                IntrinsicMath.Clamp(value.Y, min.Y, max.Y), 
                IntrinsicMath.Clamp(value.Z, min.Z, max.Z));

        #endregion

        #region Instance

        /// <summary>
        /// Constructs a new index using a single value for each component.
        /// </summary>
        /// <param name="value">The value.</param>
        public LongIndex3D(long value)
        {
            X = value;
            Y = value;
            Z = value;
        }

        /// <summary>
        /// Constructs a new index.
        /// </summary>
        /// <param name="x">The x value.</param>
        /// <param name="y">The y value.</param>
        /// <param name="z">The z value.</param>
        public LongIndex3D(long x, long y, long z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Returns the X index.
        /// </summary>
        public long X { get; }

        /// <summary>
        /// Returns the Y index.
        /// </summary>
        public long Y { get; }

        /// <summary>
        /// Returns the Z index.
        /// </summary>
        public long Z { get; }

        /// <summary>
        /// Returns true if this is the first index.
        /// </summary>
        public readonly bool IsFirst =>
            Bitwise.And(X == 0, Y == 0, Z == 0);

        /// <summary>
        /// Returns the size represented by this index.
        /// </summary>
        /// <summary>
        /// Returns the size represented by this index.
        /// </summary>
        public readonly long Size =>
            X * Y * Z;

        /// <summary>
        /// Returns the current index type.
        /// </summary>
        public readonly IndexType IndexType => (IndexType)6;

        #endregion

        #region Index

        /// <summary>
        /// Converts this index to an integer index.
        /// </summary>
        /// <returns>The resulting integer representation.</returns>
        public readonly Index3D ToIntIndex()
        {
            IndexTypeExtensions.AssertIntIndexRange(X);
            IndexTypeExtensions.AssertIntIndexRange(Y);
            IndexTypeExtensions.AssertIntIndexRange(Z);
            return new Index3D(
                (int)X, (int)Y, (int)Z);
        }

        #endregion

        #region IGenericIndex

        /// <summary>
        /// Returns true if the current index is greater than or equal to 0 and
        /// is less than the given dimension.
        /// </summary>
        /// <param name="dimension">The dimension bounds.</param>
        /// <returns>True if the current index is inside the given bounds.</returns>
        public readonly bool InBounds(LongIndex3D dimension) =>
            Bitwise.And(Bitwise.And(X >= 0, X < dimension.X), Bitwise.And(Y >= 0, Y < dimension.Y), Bitwise.And(Z >= 0, Z < dimension.Z));

        /// <summary>
        /// Returns true if the current index is greater than or equal to 0 and
        /// is less than or equal to the given dimension.
        /// </summary>
        /// <param name="dimension">The dimension bounds.</param>
        /// <returns>True if the current index is inside the given bounds.</returns>
        public readonly bool InBoundsInclusive(LongIndex3D dimension) =>
            Bitwise.And(Bitwise.And(X >= 0, X <= dimension.X), Bitwise.And(Y >= 0, Y <= dimension.Y), Bitwise.And(Z >= 0, Z <= dimension.Z));

        /// <summary>
        /// Computes this + right-hand side.
        /// </summary>
        /// <param name="rhs">The right-hand side of the addition.</param>
        /// <returns>The added index.</returns>
        public readonly LongIndex3D Add(LongIndex3D rhs) => this + rhs;

        /// <summary>
        /// Computes this - right-hand side.
        /// </summary>
        /// <param name="rhs">The right-hand side of the subtraction.</param>
        /// <returns>The subtracted index.</returns>
        public readonly LongIndex3D Subtract(LongIndex3D rhs) => this - rhs;

        #endregion

        #region ValueTuple

        /// <summary>
        /// Returns a value tuple that stores all dimensions.
        /// </summary>
        /// <returns>The constructed value tuple.</returns>
        public (long X, long Y, long Z) ToValueTuple() =>
            (X, Y, Z);

        /// <summary>
        /// Deconstructs the current instance into a tuple.
        /// </summary>
        /// <param name="x">The x value.</param>
        /// <param name="y">The y value.</param>
        /// <param name="z">The z value.</param>
        public void Deconstruct(
            out long x, out long y, out long z)
        {
            x = X;
            y = Y;
            z = Z;
        }

        #endregion

        #region IEquatable

        /// <summary>
        /// Returns true if the given index is equal to the current index.
        /// </summary>
        /// <param name="other">The other index.</param>
        /// <returns>True, if the given index is equal to the current index.</returns>
        public readonly bool Equals(LongIndex3D other) => this == other;

        #endregion

        #region Object

        /// <summary>
        /// Returns true if the given object is equal to the current index.
        /// </summary>
        /// <param name="obj">The other object.</param>
        /// <returns>True, if the given object is equal to the current index.</returns>
        public readonly override bool Equals(object? obj) =>
            obj is LongIndex3D other && Equals(other);

        /// <summary>
        /// Returns the hash code of this index.
        /// </summary>
        /// <returns>The hash code of this index.</returns>
        public readonly override int GetHashCode() =>
            HashCode.Combine(X, Y, Z);

        /// <summary>
        /// Returns the string representation of this index.
        /// </summary>
        /// <returns>The string representation of this index.</returns>
        public readonly override string ToString() =>
            $"({X}, {Y}, {Z})";

        #endregion

        #region Operators

        /// <summary>
        /// Converts this index to an integer index.
        /// </summary>
        /// <param name="index">The index to convert.</param>
        /// <returns>The resulting integer representation.</returns>
        public static explicit operator Index3D(LongIndex3D index) =>
            index.ToIntIndex();

        /// <summary>
        /// Converts the given value tuple into an equivalent <see cref="LongIndex3D"/>.
        /// </summary>
        /// <param name="values">The values.</param>
        public static implicit operator LongIndex3D(
            (long, long, long) values) =>
            new LongIndex3D(
                values.Item1
                , values.Item2
                , values.Item3
                );

        /// <summary>
        /// Adds two indices.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>The added index.</returns>
        public static LongIndex3D Add(LongIndex3D first, LongIndex3D second) =>
            first + second;

        /// <summary>
        /// Adds two indices.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>The added index.</returns>
        public static LongIndex3D operator +(LongIndex3D first, LongIndex3D second) =>
            new LongIndex3D(
                first.X + second.X, first.Y + second.Y, first.Z + second.Z);

        /// <summary>
        /// Subtracts two indices.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>The subtracted index.</returns>
        public static LongIndex3D Subtract(LongIndex3D first, LongIndex3D second) =>
            first - second;

        /// <summary>
        /// Subtracts two indices.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>The subtracted index.</returns>
        public static LongIndex3D operator -(LongIndex3D first, LongIndex3D second) =>
            new LongIndex3D(
                first.X - second.X, first.Y - second.Y, first.Z - second.Z);

        /// <summary>
        /// Multiplies two indices.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>The multiplied index.</returns>
        public static LongIndex3D Multiply(LongIndex3D first, LongIndex3D second) =>
            first * second;

        /// <summary>
        /// Multiplies two indices.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>The multiplied index.</returns>
        public static LongIndex3D operator *(LongIndex3D first, LongIndex3D second) =>
            new LongIndex3D(
                first.X * second.X, first.Y * second.Y, first.Z * second.Z);

        /// <summary>
        /// Divides two indices.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>The divided index.</returns>
        public static LongIndex3D Divide(LongIndex3D first, LongIndex3D second) =>
            first / second;

        /// <summary>
        /// Divides two indices.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>The divided index.</returns>
        public static LongIndex3D operator /(LongIndex3D first, LongIndex3D second) =>
            new LongIndex3D(
                first.X / second.X, first.Y / second.Y, first.Z / second.Z);

        /// <summary>
        /// Returns true if the first and second index are the same.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>True, if the first and second index are the same.</returns>
        public static bool operator ==(LongIndex3D first, LongIndex3D second) =>
            Bitwise.And(first.X == second.X, first.Y == second.Y, first.Z == second.Z);

        /// <summary>
        /// Returns true if the first and second index are not the same.
        /// </summary>
        /// <param name="first">The first index.</param>
        /// <param name="second">The second index.</param>
        /// <returns>True, if the first and second index are not the same.</returns>
        public static bool operator !=(LongIndex3D first, LongIndex3D second) =>
            Bitwise.Or(first.X != second.X, first.Y != second.Y, first.Z != second.Z);

        #endregion
    }


    // Basic index extensions

    partial struct Index1D
    {
        /// <summary>
        /// Implicitly converts an index to an int.
        /// </summary>
        /// <param name="idx">The index to convert.</param>
        public static implicit operator int(Index1D idx) => idx.X;

        /// <summary>
        /// Implicitly converts an int to an index.
        /// </summary>
        /// <param name="idx">The int to convert.</param>
        public static implicit operator Index1D(int idx) =>
            new Index1D(idx);

        /// <summary>
        /// Implicitly converts an index to an unsigned value.
        /// </summary>
        /// <param name="idx">The index to convert.</param>
        public static explicit operator uint(Index1D idx) =>
            (uint)idx.X;
    }

    partial struct LongIndex1D
    {
        /// <summary>
        /// Implicitly converts an index to an int.
        /// </summary>
        /// <param name="idx">The index to convert.</param>
        public static implicit operator long(LongIndex1D idx) => idx.X;

        /// <summary>
        /// Implicitly converts an int to an index.
        /// </summary>
        /// <param name="idx">The int to convert.</param>
        public static implicit operator LongIndex1D(long idx) =>
            new LongIndex1D(idx);

        /// <summary>
        /// Implicitly converts an index to an unsigned value.
        /// </summary>
        /// <param name="idx">The index to convert.</param>
        public static explicit operator ulong(LongIndex1D idx) =>
            (ulong)idx.X;
    }

}