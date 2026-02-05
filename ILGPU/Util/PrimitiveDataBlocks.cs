// ---------------------------------------------------------------------------------------
//                                        ILGPU
//                        Copyright (c) 2016-2023 ILGPU Project
//                                    www.ilgpu.net
//
// File: PrimitiveDataBlocks.tt/PrimitiveDataBlocks.cs
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
using System.Runtime.InteropServices;

// disable: max_line_length
#pragma warning disable IDE0047 // Remove unnecessary parentheses

namespace ILGPU.Util
{
    /// <summary>
    /// Represents a combined structure type to hold multiple primitive values of the
    /// same type.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Short2 : IEquatable<Short2>
    {
        #region Constants

        /// <summary>
        /// Represents the native size of a single element.
        /// </summary>
        public static readonly int ElementSize = Interop.SizeOf<Short2>();

        #endregion

        #region Instance

        /// <summary>
        /// The internal data block.
        /// </summary>
        private DataBlock<short, short> dataBlock;

        /// <summary>
        /// Constructs a new data container.
        /// </summary>
        public Short2(short value)
            : this(value, value)
        { }

        /// <summary>
        /// Constructs a new data container.
        /// </summary>
        public Short2(short x, short y)
            : this(new DataBlock<short, short>(
                x, y))
        { }

        /// <summary>
        /// Constructs a new data block.
        /// </summary>
        public Short2(DataBlock<short, short> block)
        {
            dataBlock = block;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The underlying raw data block.
        /// </summary>
        public DataBlock<short, short> DataBlock => dataBlock;

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public short X
        {
            get => dataBlock.Item1;
            set => dataBlock.Item1 = value;
        }

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public short Y
        {
            get => dataBlock.Item2;
            set => dataBlock.Item2 = value;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a value tuple that stores all items.
        /// </summary>
        /// <returns>The constructed value tuple.</returns>
        public (short, short) ToValueTuple() => dataBlock.ToValueTuple();

        /// <summary cref="IEquatable{T}.Equals(T)"/>
        public bool Equals(Short2 other) => dataBlock.Equals(other.dataBlock);

        #endregion

        #region Object

        /// <summary>
        /// Returns true if the given object is equal to the current one.
        /// </summary>
        /// <param name="obj">The other object.</param>
        /// <returns>True, if the given object is equal to the current one.</returns>
        public override bool Equals(object? obj) =>
            obj is Short2 other && Equals(other);

        /// <summary>
        /// Returns the combined hash code of all items.
        /// </summary>
        /// <returns>The hash code of all items.</returns>
        public override int GetHashCode() => dataBlock.GetHashCode();

        /// <summary>
        /// Returns the string representation of this view.
        /// </summary>
        /// <returns>The string representation of this view.</returns>
        public override string ToString() => dataBlock.ToString();

        #endregion

        #region Operators

        /// <summary>
        /// Executes an arithmetic * operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Short2 operator *(Short2 left, Short2 right) =>
            new Short2(
                (short)(left.X * right.X), (short)(left.Y * right.Y));

        /// <summary>
        /// Executes an arithmetic / operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Short2 operator /(Short2 left, Short2 right) =>
            new Short2(
                (short)(left.X / right.X), (short)(left.Y / right.Y));

        /// <summary>
        /// Executes an arithmetic - operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Short2 operator -(Short2 left, Short2 right) =>
            new Short2(
                (short)(left.X - right.X), (short)(left.Y - right.Y));

        /// <summary>
        /// Executes an arithmetic + operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Short2 operator +(Short2 left, Short2 right) =>
            new Short2(
                (short)(left.X + right.X), (short)(left.Y + right.Y));

        /// <summary>
        /// Converts the given single value into its container representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator Short2(short value) =>
            new Short2(value);

        /// <summary>
        /// Converts the given value into its tuple representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator (short, short)(Short2 value) =>
            value.ToValueTuple();

        /// <summary>
        /// Converts the given value into its data block representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator DataBlock<short, short>(Short2 value) =>
            value.DataBlock;

        /// <summary>
        /// Returns true if both data blocks represent the same elements.
        /// </summary>
        /// <param name="left">The left block.</param>
        /// <param name="right">The right block.</param>
        /// <returns>True, if both data block represent the same elements.</returns>
        public static bool operator ==(Short2 left, Short2 right) =>
            left.Equals(right);

        /// <summary>
        /// Returns true if both data blocks do not represent the same elements.
        /// </summary>
        /// <param name="left">The left block.</param>
        /// <param name="right">The right block.</param>
        /// <returns>
        /// True, if both data block do not represent the same elements.
        /// </returns>
        public static bool operator !=(Short2 left, Short2 right) =>
            !(left == right);

        #endregion
    }

    /// <summary>
    /// Represents a combined structure type to hold multiple primitive values of the
    /// same type.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Short3 : IEquatable<Short3>
    {
        #region Constants

        /// <summary>
        /// Represents the native size of a single element.
        /// </summary>
        public static readonly int ElementSize = Interop.SizeOf<Short3>();

        #endregion

        #region Instance

        /// <summary>
        /// The internal data block.
        /// </summary>
        private DataBlock<short, short, short> dataBlock;

        /// <summary>
        /// Constructs a new data container.
        /// </summary>
        public Short3(short value)
            : this(value, value, value)
        { }

        /// <summary>
        /// Constructs a new data container.
        /// </summary>
        public Short3(short x, short y, short z)
            : this(new DataBlock<short, short, short>(
                x, y, z))
        { }

        /// <summary>
        /// Constructs a new data block.
        /// </summary>
        public Short3(DataBlock<short, short, short> block)
        {
            dataBlock = block;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The underlying raw data block.
        /// </summary>
        public DataBlock<short, short, short> DataBlock => dataBlock;

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public short X
        {
            get => dataBlock.Item1;
            set => dataBlock.Item1 = value;
        }

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public short Y
        {
            get => dataBlock.Item2;
            set => dataBlock.Item2 = value;
        }

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public short Z
        {
            get => dataBlock.Item3;
            set => dataBlock.Item3 = value;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a value tuple that stores all items.
        /// </summary>
        /// <returns>The constructed value tuple.</returns>
        public (short, short, short) ToValueTuple() => dataBlock.ToValueTuple();

        /// <summary cref="IEquatable{T}.Equals(T)"/>
        public bool Equals(Short3 other) => dataBlock.Equals(other.dataBlock);

        #endregion

        #region Object

        /// <summary>
        /// Returns true if the given object is equal to the current one.
        /// </summary>
        /// <param name="obj">The other object.</param>
        /// <returns>True, if the given object is equal to the current one.</returns>
        public override bool Equals(object? obj) =>
            obj is Short3 other && Equals(other);

        /// <summary>
        /// Returns the combined hash code of all items.
        /// </summary>
        /// <returns>The hash code of all items.</returns>
        public override int GetHashCode() => dataBlock.GetHashCode();

        /// <summary>
        /// Returns the string representation of this view.
        /// </summary>
        /// <returns>The string representation of this view.</returns>
        public override string ToString() => dataBlock.ToString();

        #endregion

        #region Operators

        /// <summary>
        /// Executes an arithmetic * operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Short3 operator *(Short3 left, Short3 right) =>
            new Short3(
                (short)(left.X * right.X), (short)(left.Y * right.Y), (short)(left.Z * right.Z));

        /// <summary>
        /// Executes an arithmetic / operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Short3 operator /(Short3 left, Short3 right) =>
            new Short3(
                (short)(left.X / right.X), (short)(left.Y / right.Y), (short)(left.Z / right.Z));

        /// <summary>
        /// Executes an arithmetic - operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Short3 operator -(Short3 left, Short3 right) =>
            new Short3(
                (short)(left.X - right.X), (short)(left.Y - right.Y), (short)(left.Z - right.Z));

        /// <summary>
        /// Executes an arithmetic + operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Short3 operator +(Short3 left, Short3 right) =>
            new Short3(
                (short)(left.X + right.X), (short)(left.Y + right.Y), (short)(left.Z + right.Z));

        /// <summary>
        /// Converts the given single value into its container representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator Short3(short value) =>
            new Short3(value);

        /// <summary>
        /// Converts the given value into its tuple representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator (short, short, short)(Short3 value) =>
            value.ToValueTuple();

        /// <summary>
        /// Converts the given value into its data block representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator DataBlock<short, short, short>(Short3 value) =>
            value.DataBlock;

        /// <summary>
        /// Returns true if both data blocks represent the same elements.
        /// </summary>
        /// <param name="left">The left block.</param>
        /// <param name="right">The right block.</param>
        /// <returns>True, if both data block represent the same elements.</returns>
        public static bool operator ==(Short3 left, Short3 right) =>
            left.Equals(right);

        /// <summary>
        /// Returns true if both data blocks do not represent the same elements.
        /// </summary>
        /// <param name="left">The left block.</param>
        /// <param name="right">The right block.</param>
        /// <returns>
        /// True, if both data block do not represent the same elements.
        /// </returns>
        public static bool operator !=(Short3 left, Short3 right) =>
            !(left == right);

        #endregion
    }

    /// <summary>
    /// Represents a combined structure type to hold multiple primitive values of the
    /// same type.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Short4 : IEquatable<Short4>
    {
        #region Constants

        /// <summary>
        /// Represents the native size of a single element.
        /// </summary>
        public static readonly int ElementSize = Interop.SizeOf<Short4>();

        #endregion

        #region Instance

        /// <summary>
        /// The internal data block.
        /// </summary>
        private DataBlock<short, short, short, short> dataBlock;

        /// <summary>
        /// Constructs a new data container.
        /// </summary>
        public Short4(short value)
            : this(value, value, value, value)
        { }

        /// <summary>
        /// Constructs a new data container.
        /// </summary>
        public Short4(short x, short y, short z, short w)
            : this(new DataBlock<short, short, short, short>(
                x, y, z, w))
        { }

        /// <summary>
        /// Constructs a new data block.
        /// </summary>
        public Short4(DataBlock<short, short, short, short> block)
        {
            dataBlock = block;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The underlying raw data block.
        /// </summary>
        public DataBlock<short, short, short, short> DataBlock => dataBlock;

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public short X
        {
            get => dataBlock.Item1;
            set => dataBlock.Item1 = value;
        }

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public short Y
        {
            get => dataBlock.Item2;
            set => dataBlock.Item2 = value;
        }

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public short Z
        {
            get => dataBlock.Item3;
            set => dataBlock.Item3 = value;
        }

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public short W
        {
            get => dataBlock.Item4;
            set => dataBlock.Item4 = value;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a value tuple that stores all items.
        /// </summary>
        /// <returns>The constructed value tuple.</returns>
        public (short, short, short, short) ToValueTuple() => dataBlock.ToValueTuple();

        /// <summary cref="IEquatable{T}.Equals(T)"/>
        public bool Equals(Short4 other) => dataBlock.Equals(other.dataBlock);

        #endregion

        #region Object

        /// <summary>
        /// Returns true if the given object is equal to the current one.
        /// </summary>
        /// <param name="obj">The other object.</param>
        /// <returns>True, if the given object is equal to the current one.</returns>
        public override bool Equals(object? obj) =>
            obj is Short4 other && Equals(other);

        /// <summary>
        /// Returns the combined hash code of all items.
        /// </summary>
        /// <returns>The hash code of all items.</returns>
        public override int GetHashCode() => dataBlock.GetHashCode();

        /// <summary>
        /// Returns the string representation of this view.
        /// </summary>
        /// <returns>The string representation of this view.</returns>
        public override string ToString() => dataBlock.ToString();

        #endregion

        #region Operators

        /// <summary>
        /// Executes an arithmetic * operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Short4 operator *(Short4 left, Short4 right) =>
            new Short4(
                (short)(left.X * right.X), (short)(left.Y * right.Y), (short)(left.Z * right.Z), (short)(left.W * right.W));

        /// <summary>
        /// Executes an arithmetic / operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Short4 operator /(Short4 left, Short4 right) =>
            new Short4(
                (short)(left.X / right.X), (short)(left.Y / right.Y), (short)(left.Z / right.Z), (short)(left.W / right.W));

        /// <summary>
        /// Executes an arithmetic - operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Short4 operator -(Short4 left, Short4 right) =>
            new Short4(
                (short)(left.X - right.X), (short)(left.Y - right.Y), (short)(left.Z - right.Z), (short)(left.W - right.W));

        /// <summary>
        /// Executes an arithmetic + operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Short4 operator +(Short4 left, Short4 right) =>
            new Short4(
                (short)(left.X + right.X), (short)(left.Y + right.Y), (short)(left.Z + right.Z), (short)(left.W + right.W));

        /// <summary>
        /// Converts the given single value into its container representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator Short4(short value) =>
            new Short4(value);

        /// <summary>
        /// Converts the given value into its tuple representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator (short, short, short, short)(Short4 value) =>
            value.ToValueTuple();

        /// <summary>
        /// Converts the given value into its data block representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator DataBlock<short, short, short, short>(Short4 value) =>
            value.DataBlock;

        /// <summary>
        /// Returns true if both data blocks represent the same elements.
        /// </summary>
        /// <param name="left">The left block.</param>
        /// <param name="right">The right block.</param>
        /// <returns>True, if both data block represent the same elements.</returns>
        public static bool operator ==(Short4 left, Short4 right) =>
            left.Equals(right);

        /// <summary>
        /// Returns true if both data blocks do not represent the same elements.
        /// </summary>
        /// <param name="left">The left block.</param>
        /// <param name="right">The right block.</param>
        /// <returns>
        /// True, if both data block do not represent the same elements.
        /// </returns>
        public static bool operator !=(Short4 left, Short4 right) =>
            !(left == right);

        #endregion
    }

    /// <summary>
    /// Represents a combined structure type to hold multiple primitive values of the
    /// same type.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Int2 : IEquatable<Int2>
    {
        #region Constants

        /// <summary>
        /// Represents the native size of a single element.
        /// </summary>
        public static readonly int ElementSize = Interop.SizeOf<Int2>();

        #endregion

        #region Instance

        /// <summary>
        /// The internal data block.
        /// </summary>
        private DataBlock<int, int> dataBlock;

        /// <summary>
        /// Constructs a new data container.
        /// </summary>
        public Int2(int value)
            : this(value, value)
        { }

        /// <summary>
        /// Constructs a new data container.
        /// </summary>
        public Int2(int x, int y)
            : this(new DataBlock<int, int>(
                x, y))
        { }

        /// <summary>
        /// Constructs a new data block.
        /// </summary>
        public Int2(DataBlock<int, int> block)
        {
            dataBlock = block;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The underlying raw data block.
        /// </summary>
        public DataBlock<int, int> DataBlock => dataBlock;

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public int X
        {
            get => dataBlock.Item1;
            set => dataBlock.Item1 = value;
        }

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public int Y
        {
            get => dataBlock.Item2;
            set => dataBlock.Item2 = value;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a value tuple that stores all items.
        /// </summary>
        /// <returns>The constructed value tuple.</returns>
        public (int, int) ToValueTuple() => dataBlock.ToValueTuple();

        /// <summary cref="IEquatable{T}.Equals(T)"/>
        public bool Equals(Int2 other) => dataBlock.Equals(other.dataBlock);

        #endregion

        #region Object

        /// <summary>
        /// Returns true if the given object is equal to the current one.
        /// </summary>
        /// <param name="obj">The other object.</param>
        /// <returns>True, if the given object is equal to the current one.</returns>
        public override bool Equals(object? obj) =>
            obj is Int2 other && Equals(other);

        /// <summary>
        /// Returns the combined hash code of all items.
        /// </summary>
        /// <returns>The hash code of all items.</returns>
        public override int GetHashCode() => dataBlock.GetHashCode();

        /// <summary>
        /// Returns the string representation of this view.
        /// </summary>
        /// <returns>The string representation of this view.</returns>
        public override string ToString() => dataBlock.ToString();

        #endregion

        #region Operators

        /// <summary>
        /// Executes an arithmetic * operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Int2 operator *(Int2 left, Int2 right) =>
            new Int2(
                (int)(left.X * right.X), (int)(left.Y * right.Y));

        /// <summary>
        /// Executes an arithmetic / operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Int2 operator /(Int2 left, Int2 right) =>
            new Int2(
                (int)(left.X / right.X), (int)(left.Y / right.Y));

        /// <summary>
        /// Executes an arithmetic - operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Int2 operator -(Int2 left, Int2 right) =>
            new Int2(
                (int)(left.X - right.X), (int)(left.Y - right.Y));

        /// <summary>
        /// Executes an arithmetic + operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Int2 operator +(Int2 left, Int2 right) =>
            new Int2(
                (int)(left.X + right.X), (int)(left.Y + right.Y));

        /// <summary>
        /// Converts the given single value into its container representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator Int2(int value) =>
            new Int2(value);

        /// <summary>
        /// Converts the given value into its tuple representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator (int, int)(Int2 value) =>
            value.ToValueTuple();

        /// <summary>
        /// Converts the given value into its data block representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator DataBlock<int, int>(Int2 value) =>
            value.DataBlock;

        /// <summary>
        /// Returns true if both data blocks represent the same elements.
        /// </summary>
        /// <param name="left">The left block.</param>
        /// <param name="right">The right block.</param>
        /// <returns>True, if both data block represent the same elements.</returns>
        public static bool operator ==(Int2 left, Int2 right) =>
            left.Equals(right);

        /// <summary>
        /// Returns true if both data blocks do not represent the same elements.
        /// </summary>
        /// <param name="left">The left block.</param>
        /// <param name="right">The right block.</param>
        /// <returns>
        /// True, if both data block do not represent the same elements.
        /// </returns>
        public static bool operator !=(Int2 left, Int2 right) =>
            !(left == right);

        #endregion
    }

    /// <summary>
    /// Represents a combined structure type to hold multiple primitive values of the
    /// same type.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Int3 : IEquatable<Int3>
    {
        #region Constants

        /// <summary>
        /// Represents the native size of a single element.
        /// </summary>
        public static readonly int ElementSize = Interop.SizeOf<Int3>();

        #endregion

        #region Instance

        /// <summary>
        /// The internal data block.
        /// </summary>
        private DataBlock<int, int, int> dataBlock;

        /// <summary>
        /// Constructs a new data container.
        /// </summary>
        public Int3(int value)
            : this(value, value, value)
        { }

        /// <summary>
        /// Constructs a new data container.
        /// </summary>
        public Int3(int x, int y, int z)
            : this(new DataBlock<int, int, int>(
                x, y, z))
        { }

        /// <summary>
        /// Constructs a new data block.
        /// </summary>
        public Int3(DataBlock<int, int, int> block)
        {
            dataBlock = block;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The underlying raw data block.
        /// </summary>
        public DataBlock<int, int, int> DataBlock => dataBlock;

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public int X
        {
            get => dataBlock.Item1;
            set => dataBlock.Item1 = value;
        }

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public int Y
        {
            get => dataBlock.Item2;
            set => dataBlock.Item2 = value;
        }

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public int Z
        {
            get => dataBlock.Item3;
            set => dataBlock.Item3 = value;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a value tuple that stores all items.
        /// </summary>
        /// <returns>The constructed value tuple.</returns>
        public (int, int, int) ToValueTuple() => dataBlock.ToValueTuple();

        /// <summary cref="IEquatable{T}.Equals(T)"/>
        public bool Equals(Int3 other) => dataBlock.Equals(other.dataBlock);

        #endregion

        #region Object

        /// <summary>
        /// Returns true if the given object is equal to the current one.
        /// </summary>
        /// <param name="obj">The other object.</param>
        /// <returns>True, if the given object is equal to the current one.</returns>
        public override bool Equals(object? obj) =>
            obj is Int3 other && Equals(other);

        /// <summary>
        /// Returns the combined hash code of all items.
        /// </summary>
        /// <returns>The hash code of all items.</returns>
        public override int GetHashCode() => dataBlock.GetHashCode();

        /// <summary>
        /// Returns the string representation of this view.
        /// </summary>
        /// <returns>The string representation of this view.</returns>
        public override string ToString() => dataBlock.ToString();

        #endregion

        #region Operators

        /// <summary>
        /// Executes an arithmetic * operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Int3 operator *(Int3 left, Int3 right) =>
            new Int3(
                (int)(left.X * right.X), (int)(left.Y * right.Y), (int)(left.Z * right.Z));

        /// <summary>
        /// Executes an arithmetic / operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Int3 operator /(Int3 left, Int3 right) =>
            new Int3(
                (int)(left.X / right.X), (int)(left.Y / right.Y), (int)(left.Z / right.Z));

        /// <summary>
        /// Executes an arithmetic - operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Int3 operator -(Int3 left, Int3 right) =>
            new Int3(
                (int)(left.X - right.X), (int)(left.Y - right.Y), (int)(left.Z - right.Z));

        /// <summary>
        /// Executes an arithmetic + operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Int3 operator +(Int3 left, Int3 right) =>
            new Int3(
                (int)(left.X + right.X), (int)(left.Y + right.Y), (int)(left.Z + right.Z));

        /// <summary>
        /// Converts the given single value into its container representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator Int3(int value) =>
            new Int3(value);

        /// <summary>
        /// Converts the given value into its tuple representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator (int, int, int)(Int3 value) =>
            value.ToValueTuple();

        /// <summary>
        /// Converts the given value into its data block representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator DataBlock<int, int, int>(Int3 value) =>
            value.DataBlock;

        /// <summary>
        /// Returns true if both data blocks represent the same elements.
        /// </summary>
        /// <param name="left">The left block.</param>
        /// <param name="right">The right block.</param>
        /// <returns>True, if both data block represent the same elements.</returns>
        public static bool operator ==(Int3 left, Int3 right) =>
            left.Equals(right);

        /// <summary>
        /// Returns true if both data blocks do not represent the same elements.
        /// </summary>
        /// <param name="left">The left block.</param>
        /// <param name="right">The right block.</param>
        /// <returns>
        /// True, if both data block do not represent the same elements.
        /// </returns>
        public static bool operator !=(Int3 left, Int3 right) =>
            !(left == right);

        #endregion
    }

    /// <summary>
    /// Represents a combined structure type to hold multiple primitive values of the
    /// same type.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Int4 : IEquatable<Int4>
    {
        #region Constants

        /// <summary>
        /// Represents the native size of a single element.
        /// </summary>
        public static readonly int ElementSize = Interop.SizeOf<Int4>();

        #endregion

        #region Instance

        /// <summary>
        /// The internal data block.
        /// </summary>
        private DataBlock<int, int, int, int> dataBlock;

        /// <summary>
        /// Constructs a new data container.
        /// </summary>
        public Int4(int value)
            : this(value, value, value, value)
        { }

        /// <summary>
        /// Constructs a new data container.
        /// </summary>
        public Int4(int x, int y, int z, int w)
            : this(new DataBlock<int, int, int, int>(
                x, y, z, w))
        { }

        /// <summary>
        /// Constructs a new data block.
        /// </summary>
        public Int4(DataBlock<int, int, int, int> block)
        {
            dataBlock = block;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The underlying raw data block.
        /// </summary>
        public DataBlock<int, int, int, int> DataBlock => dataBlock;

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public int X
        {
            get => dataBlock.Item1;
            set => dataBlock.Item1 = value;
        }

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public int Y
        {
            get => dataBlock.Item2;
            set => dataBlock.Item2 = value;
        }

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public int Z
        {
            get => dataBlock.Item3;
            set => dataBlock.Item3 = value;
        }

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public int W
        {
            get => dataBlock.Item4;
            set => dataBlock.Item4 = value;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a value tuple that stores all items.
        /// </summary>
        /// <returns>The constructed value tuple.</returns>
        public (int, int, int, int) ToValueTuple() => dataBlock.ToValueTuple();

        /// <summary cref="IEquatable{T}.Equals(T)"/>
        public bool Equals(Int4 other) => dataBlock.Equals(other.dataBlock);

        #endregion

        #region Object

        /// <summary>
        /// Returns true if the given object is equal to the current one.
        /// </summary>
        /// <param name="obj">The other object.</param>
        /// <returns>True, if the given object is equal to the current one.</returns>
        public override bool Equals(object? obj) =>
            obj is Int4 other && Equals(other);

        /// <summary>
        /// Returns the combined hash code of all items.
        /// </summary>
        /// <returns>The hash code of all items.</returns>
        public override int GetHashCode() => dataBlock.GetHashCode();

        /// <summary>
        /// Returns the string representation of this view.
        /// </summary>
        /// <returns>The string representation of this view.</returns>
        public override string ToString() => dataBlock.ToString();

        #endregion

        #region Operators

        /// <summary>
        /// Executes an arithmetic * operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Int4 operator *(Int4 left, Int4 right) =>
            new Int4(
                (int)(left.X * right.X), (int)(left.Y * right.Y), (int)(left.Z * right.Z), (int)(left.W * right.W));

        /// <summary>
        /// Executes an arithmetic / operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Int4 operator /(Int4 left, Int4 right) =>
            new Int4(
                (int)(left.X / right.X), (int)(left.Y / right.Y), (int)(left.Z / right.Z), (int)(left.W / right.W));

        /// <summary>
        /// Executes an arithmetic - operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Int4 operator -(Int4 left, Int4 right) =>
            new Int4(
                (int)(left.X - right.X), (int)(left.Y - right.Y), (int)(left.Z - right.Z), (int)(left.W - right.W));

        /// <summary>
        /// Executes an arithmetic + operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Int4 operator +(Int4 left, Int4 right) =>
            new Int4(
                (int)(left.X + right.X), (int)(left.Y + right.Y), (int)(left.Z + right.Z), (int)(left.W + right.W));

        /// <summary>
        /// Converts the given single value into its container representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator Int4(int value) =>
            new Int4(value);

        /// <summary>
        /// Converts the given value into its tuple representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator (int, int, int, int)(Int4 value) =>
            value.ToValueTuple();

        /// <summary>
        /// Converts the given value into its data block representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator DataBlock<int, int, int, int>(Int4 value) =>
            value.DataBlock;

        /// <summary>
        /// Returns true if both data blocks represent the same elements.
        /// </summary>
        /// <param name="left">The left block.</param>
        /// <param name="right">The right block.</param>
        /// <returns>True, if both data block represent the same elements.</returns>
        public static bool operator ==(Int4 left, Int4 right) =>
            left.Equals(right);

        /// <summary>
        /// Returns true if both data blocks do not represent the same elements.
        /// </summary>
        /// <param name="left">The left block.</param>
        /// <param name="right">The right block.</param>
        /// <returns>
        /// True, if both data block do not represent the same elements.
        /// </returns>
        public static bool operator !=(Int4 left, Int4 right) =>
            !(left == right);

        #endregion
    }

    /// <summary>
    /// Represents a combined structure type to hold multiple primitive values of the
    /// same type.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Long2 : IEquatable<Long2>
    {
        #region Constants

        /// <summary>
        /// Represents the native size of a single element.
        /// </summary>
        public static readonly int ElementSize = Interop.SizeOf<Long2>();

        #endregion

        #region Instance

        /// <summary>
        /// The internal data block.
        /// </summary>
        private DataBlock<long, long> dataBlock;

        /// <summary>
        /// Constructs a new data container.
        /// </summary>
        public Long2(long value)
            : this(value, value)
        { }

        /// <summary>
        /// Constructs a new data container.
        /// </summary>
        public Long2(long x, long y)
            : this(new DataBlock<long, long>(
                x, y))
        { }

        /// <summary>
        /// Constructs a new data block.
        /// </summary>
        public Long2(DataBlock<long, long> block)
        {
            dataBlock = block;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The underlying raw data block.
        /// </summary>
        public DataBlock<long, long> DataBlock => dataBlock;

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public long X
        {
            get => dataBlock.Item1;
            set => dataBlock.Item1 = value;
        }

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public long Y
        {
            get => dataBlock.Item2;
            set => dataBlock.Item2 = value;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a value tuple that stores all items.
        /// </summary>
        /// <returns>The constructed value tuple.</returns>
        public (long, long) ToValueTuple() => dataBlock.ToValueTuple();

        /// <summary cref="IEquatable{T}.Equals(T)"/>
        public bool Equals(Long2 other) => dataBlock.Equals(other.dataBlock);

        #endregion

        #region Object

        /// <summary>
        /// Returns true if the given object is equal to the current one.
        /// </summary>
        /// <param name="obj">The other object.</param>
        /// <returns>True, if the given object is equal to the current one.</returns>
        public override bool Equals(object? obj) =>
            obj is Long2 other && Equals(other);

        /// <summary>
        /// Returns the combined hash code of all items.
        /// </summary>
        /// <returns>The hash code of all items.</returns>
        public override int GetHashCode() => dataBlock.GetHashCode();

        /// <summary>
        /// Returns the string representation of this view.
        /// </summary>
        /// <returns>The string representation of this view.</returns>
        public override string ToString() => dataBlock.ToString();

        #endregion

        #region Operators

        /// <summary>
        /// Executes an arithmetic * operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Long2 operator *(Long2 left, Long2 right) =>
            new Long2(
                (long)(left.X * right.X), (long)(left.Y * right.Y));

        /// <summary>
        /// Executes an arithmetic / operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Long2 operator /(Long2 left, Long2 right) =>
            new Long2(
                (long)(left.X / right.X), (long)(left.Y / right.Y));

        /// <summary>
        /// Executes an arithmetic - operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Long2 operator -(Long2 left, Long2 right) =>
            new Long2(
                (long)(left.X - right.X), (long)(left.Y - right.Y));

        /// <summary>
        /// Executes an arithmetic + operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Long2 operator +(Long2 left, Long2 right) =>
            new Long2(
                (long)(left.X + right.X), (long)(left.Y + right.Y));

        /// <summary>
        /// Converts the given single value into its container representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator Long2(long value) =>
            new Long2(value);

        /// <summary>
        /// Converts the given value into its tuple representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator (long, long)(Long2 value) =>
            value.ToValueTuple();

        /// <summary>
        /// Converts the given value into its data block representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator DataBlock<long, long>(Long2 value) =>
            value.DataBlock;

        /// <summary>
        /// Returns true if both data blocks represent the same elements.
        /// </summary>
        /// <param name="left">The left block.</param>
        /// <param name="right">The right block.</param>
        /// <returns>True, if both data block represent the same elements.</returns>
        public static bool operator ==(Long2 left, Long2 right) =>
            left.Equals(right);

        /// <summary>
        /// Returns true if both data blocks do not represent the same elements.
        /// </summary>
        /// <param name="left">The left block.</param>
        /// <param name="right">The right block.</param>
        /// <returns>
        /// True, if both data block do not represent the same elements.
        /// </returns>
        public static bool operator !=(Long2 left, Long2 right) =>
            !(left == right);

        #endregion
    }

    /// <summary>
    /// Represents a combined structure type to hold multiple primitive values of the
    /// same type.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Long3 : IEquatable<Long3>
    {
        #region Constants

        /// <summary>
        /// Represents the native size of a single element.
        /// </summary>
        public static readonly int ElementSize = Interop.SizeOf<Long3>();

        #endregion

        #region Instance

        /// <summary>
        /// The internal data block.
        /// </summary>
        private DataBlock<long, long, long> dataBlock;

        /// <summary>
        /// Constructs a new data container.
        /// </summary>
        public Long3(long value)
            : this(value, value, value)
        { }

        /// <summary>
        /// Constructs a new data container.
        /// </summary>
        public Long3(long x, long y, long z)
            : this(new DataBlock<long, long, long>(
                x, y, z))
        { }

        /// <summary>
        /// Constructs a new data block.
        /// </summary>
        public Long3(DataBlock<long, long, long> block)
        {
            dataBlock = block;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The underlying raw data block.
        /// </summary>
        public DataBlock<long, long, long> DataBlock => dataBlock;

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public long X
        {
            get => dataBlock.Item1;
            set => dataBlock.Item1 = value;
        }

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public long Y
        {
            get => dataBlock.Item2;
            set => dataBlock.Item2 = value;
        }

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public long Z
        {
            get => dataBlock.Item3;
            set => dataBlock.Item3 = value;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a value tuple that stores all items.
        /// </summary>
        /// <returns>The constructed value tuple.</returns>
        public (long, long, long) ToValueTuple() => dataBlock.ToValueTuple();

        /// <summary cref="IEquatable{T}.Equals(T)"/>
        public bool Equals(Long3 other) => dataBlock.Equals(other.dataBlock);

        #endregion

        #region Object

        /// <summary>
        /// Returns true if the given object is equal to the current one.
        /// </summary>
        /// <param name="obj">The other object.</param>
        /// <returns>True, if the given object is equal to the current one.</returns>
        public override bool Equals(object? obj) =>
            obj is Long3 other && Equals(other);

        /// <summary>
        /// Returns the combined hash code of all items.
        /// </summary>
        /// <returns>The hash code of all items.</returns>
        public override int GetHashCode() => dataBlock.GetHashCode();

        /// <summary>
        /// Returns the string representation of this view.
        /// </summary>
        /// <returns>The string representation of this view.</returns>
        public override string ToString() => dataBlock.ToString();

        #endregion

        #region Operators

        /// <summary>
        /// Executes an arithmetic * operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Long3 operator *(Long3 left, Long3 right) =>
            new Long3(
                (long)(left.X * right.X), (long)(left.Y * right.Y), (long)(left.Z * right.Z));

        /// <summary>
        /// Executes an arithmetic / operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Long3 operator /(Long3 left, Long3 right) =>
            new Long3(
                (long)(left.X / right.X), (long)(left.Y / right.Y), (long)(left.Z / right.Z));

        /// <summary>
        /// Executes an arithmetic - operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Long3 operator -(Long3 left, Long3 right) =>
            new Long3(
                (long)(left.X - right.X), (long)(left.Y - right.Y), (long)(left.Z - right.Z));

        /// <summary>
        /// Executes an arithmetic + operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Long3 operator +(Long3 left, Long3 right) =>
            new Long3(
                (long)(left.X + right.X), (long)(left.Y + right.Y), (long)(left.Z + right.Z));

        /// <summary>
        /// Converts the given single value into its container representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator Long3(long value) =>
            new Long3(value);

        /// <summary>
        /// Converts the given value into its tuple representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator (long, long, long)(Long3 value) =>
            value.ToValueTuple();

        /// <summary>
        /// Converts the given value into its data block representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator DataBlock<long, long, long>(Long3 value) =>
            value.DataBlock;

        /// <summary>
        /// Returns true if both data blocks represent the same elements.
        /// </summary>
        /// <param name="left">The left block.</param>
        /// <param name="right">The right block.</param>
        /// <returns>True, if both data block represent the same elements.</returns>
        public static bool operator ==(Long3 left, Long3 right) =>
            left.Equals(right);

        /// <summary>
        /// Returns true if both data blocks do not represent the same elements.
        /// </summary>
        /// <param name="left">The left block.</param>
        /// <param name="right">The right block.</param>
        /// <returns>
        /// True, if both data block do not represent the same elements.
        /// </returns>
        public static bool operator !=(Long3 left, Long3 right) =>
            !(left == right);

        #endregion
    }

    /// <summary>
    /// Represents a combined structure type to hold multiple primitive values of the
    /// same type.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Long4 : IEquatable<Long4>
    {
        #region Constants

        /// <summary>
        /// Represents the native size of a single element.
        /// </summary>
        public static readonly int ElementSize = Interop.SizeOf<Long4>();

        #endregion

        #region Instance

        /// <summary>
        /// The internal data block.
        /// </summary>
        private DataBlock<long, long, long, long> dataBlock;

        /// <summary>
        /// Constructs a new data container.
        /// </summary>
        public Long4(long value)
            : this(value, value, value, value)
        { }

        /// <summary>
        /// Constructs a new data container.
        /// </summary>
        public Long4(long x, long y, long z, long w)
            : this(new DataBlock<long, long, long, long>(
                x, y, z, w))
        { }

        /// <summary>
        /// Constructs a new data block.
        /// </summary>
        public Long4(DataBlock<long, long, long, long> block)
        {
            dataBlock = block;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The underlying raw data block.
        /// </summary>
        public DataBlock<long, long, long, long> DataBlock => dataBlock;

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public long X
        {
            get => dataBlock.Item1;
            set => dataBlock.Item1 = value;
        }

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public long Y
        {
            get => dataBlock.Item2;
            set => dataBlock.Item2 = value;
        }

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public long Z
        {
            get => dataBlock.Item3;
            set => dataBlock.Item3 = value;
        }

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public long W
        {
            get => dataBlock.Item4;
            set => dataBlock.Item4 = value;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a value tuple that stores all items.
        /// </summary>
        /// <returns>The constructed value tuple.</returns>
        public (long, long, long, long) ToValueTuple() => dataBlock.ToValueTuple();

        /// <summary cref="IEquatable{T}.Equals(T)"/>
        public bool Equals(Long4 other) => dataBlock.Equals(other.dataBlock);

        #endregion

        #region Object

        /// <summary>
        /// Returns true if the given object is equal to the current one.
        /// </summary>
        /// <param name="obj">The other object.</param>
        /// <returns>True, if the given object is equal to the current one.</returns>
        public override bool Equals(object? obj) =>
            obj is Long4 other && Equals(other);

        /// <summary>
        /// Returns the combined hash code of all items.
        /// </summary>
        /// <returns>The hash code of all items.</returns>
        public override int GetHashCode() => dataBlock.GetHashCode();

        /// <summary>
        /// Returns the string representation of this view.
        /// </summary>
        /// <returns>The string representation of this view.</returns>
        public override string ToString() => dataBlock.ToString();

        #endregion

        #region Operators

        /// <summary>
        /// Executes an arithmetic * operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Long4 operator *(Long4 left, Long4 right) =>
            new Long4(
                (long)(left.X * right.X), (long)(left.Y * right.Y), (long)(left.Z * right.Z), (long)(left.W * right.W));

        /// <summary>
        /// Executes an arithmetic / operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Long4 operator /(Long4 left, Long4 right) =>
            new Long4(
                (long)(left.X / right.X), (long)(left.Y / right.Y), (long)(left.Z / right.Z), (long)(left.W / right.W));

        /// <summary>
        /// Executes an arithmetic - operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Long4 operator -(Long4 left, Long4 right) =>
            new Long4(
                (long)(left.X - right.X), (long)(left.Y - right.Y), (long)(left.Z - right.Z), (long)(left.W - right.W));

        /// <summary>
        /// Executes an arithmetic + operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Long4 operator +(Long4 left, Long4 right) =>
            new Long4(
                (long)(left.X + right.X), (long)(left.Y + right.Y), (long)(left.Z + right.Z), (long)(left.W + right.W));

        /// <summary>
        /// Converts the given single value into its container representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator Long4(long value) =>
            new Long4(value);

        /// <summary>
        /// Converts the given value into its tuple representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator (long, long, long, long)(Long4 value) =>
            value.ToValueTuple();

        /// <summary>
        /// Converts the given value into its data block representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator DataBlock<long, long, long, long>(Long4 value) =>
            value.DataBlock;

        /// <summary>
        /// Returns true if both data blocks represent the same elements.
        /// </summary>
        /// <param name="left">The left block.</param>
        /// <param name="right">The right block.</param>
        /// <returns>True, if both data block represent the same elements.</returns>
        public static bool operator ==(Long4 left, Long4 right) =>
            left.Equals(right);

        /// <summary>
        /// Returns true if both data blocks do not represent the same elements.
        /// </summary>
        /// <param name="left">The left block.</param>
        /// <param name="right">The right block.</param>
        /// <returns>
        /// True, if both data block do not represent the same elements.
        /// </returns>
        public static bool operator !=(Long4 left, Long4 right) =>
            !(left == right);

        #endregion
    }

    /// <summary>
    /// Represents a combined structure type to hold multiple primitive values of the
    /// same type.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Half2 : IEquatable<Half2>
    {
        #region Constants

        /// <summary>
        /// Represents the native size of a single element.
        /// </summary>
        public static readonly int ElementSize = Interop.SizeOf<Half2>();

        #endregion

        #region Instance

        /// <summary>
        /// The internal data block.
        /// </summary>
        private DataBlock<Half, Half> dataBlock;

        /// <summary>
        /// Constructs a new data container.
        /// </summary>
        public Half2(Half value)
            : this(value, value)
        { }

        /// <summary>
        /// Constructs a new data container.
        /// </summary>
        public Half2(Half x, Half y)
            : this(new DataBlock<Half, Half>(
                x, y))
        { }

        /// <summary>
        /// Constructs a new data block.
        /// </summary>
        public Half2(DataBlock<Half, Half> block)
        {
            dataBlock = block;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The underlying raw data block.
        /// </summary>
        public DataBlock<Half, Half> DataBlock => dataBlock;

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public Half X
        {
            get => dataBlock.Item1;
            set => dataBlock.Item1 = value;
        }

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public Half Y
        {
            get => dataBlock.Item2;
            set => dataBlock.Item2 = value;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a value tuple that stores all items.
        /// </summary>
        /// <returns>The constructed value tuple.</returns>
        public (Half, Half) ToValueTuple() => dataBlock.ToValueTuple();

        /// <summary cref="IEquatable{T}.Equals(T)"/>
        public bool Equals(Half2 other) => dataBlock.Equals(other.dataBlock);

        #endregion

        #region Object

        /// <summary>
        /// Returns true if the given object is equal to the current one.
        /// </summary>
        /// <param name="obj">The other object.</param>
        /// <returns>True, if the given object is equal to the current one.</returns>
        public override bool Equals(object? obj) =>
            obj is Half2 other && Equals(other);

        /// <summary>
        /// Returns the combined hash code of all items.
        /// </summary>
        /// <returns>The hash code of all items.</returns>
        public override int GetHashCode() => dataBlock.GetHashCode();

        /// <summary>
        /// Returns the string representation of this view.
        /// </summary>
        /// <returns>The string representation of this view.</returns>
        public override string ToString() => dataBlock.ToString();

        #endregion

        #region Operators

        /// <summary>
        /// Executes an arithmetic * operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Half2 operator *(Half2 left, Half2 right) =>
            new Half2(
                (Half)(left.X * right.X), (Half)(left.Y * right.Y));

        /// <summary>
        /// Executes an arithmetic / operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Half2 operator /(Half2 left, Half2 right) =>
            new Half2(
                (Half)(left.X / right.X), (Half)(left.Y / right.Y));

        /// <summary>
        /// Executes an arithmetic - operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Half2 operator -(Half2 left, Half2 right) =>
            new Half2(
                (Half)(left.X - right.X), (Half)(left.Y - right.Y));

        /// <summary>
        /// Executes an arithmetic + operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Half2 operator +(Half2 left, Half2 right) =>
            new Half2(
                (Half)(left.X + right.X), (Half)(left.Y + right.Y));

        /// <summary>
        /// Converts the given single value into its container representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator Half2(Half value) =>
            new Half2(value);

        /// <summary>
        /// Converts the given value into its tuple representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator (Half, Half)(Half2 value) =>
            value.ToValueTuple();

        /// <summary>
        /// Converts the given value into its data block representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator DataBlock<Half, Half>(Half2 value) =>
            value.DataBlock;

        /// <summary>
        /// Returns true if both data blocks represent the same elements.
        /// </summary>
        /// <param name="left">The left block.</param>
        /// <param name="right">The right block.</param>
        /// <returns>True, if both data block represent the same elements.</returns>
        public static bool operator ==(Half2 left, Half2 right) =>
            left.Equals(right);

        /// <summary>
        /// Returns true if both data blocks do not represent the same elements.
        /// </summary>
        /// <param name="left">The left block.</param>
        /// <param name="right">The right block.</param>
        /// <returns>
        /// True, if both data block do not represent the same elements.
        /// </returns>
        public static bool operator !=(Half2 left, Half2 right) =>
            !(left == right);

        #endregion
    }

    /// <summary>
    /// Represents a combined structure type to hold multiple primitive values of the
    /// same type.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Half3 : IEquatable<Half3>
    {
        #region Constants

        /// <summary>
        /// Represents the native size of a single element.
        /// </summary>
        public static readonly int ElementSize = Interop.SizeOf<Half3>();

        #endregion

        #region Instance

        /// <summary>
        /// The internal data block.
        /// </summary>
        private DataBlock<Half, Half, Half> dataBlock;

        /// <summary>
        /// Constructs a new data container.
        /// </summary>
        public Half3(Half value)
            : this(value, value, value)
        { }

        /// <summary>
        /// Constructs a new data container.
        /// </summary>
        public Half3(Half x, Half y, Half z)
            : this(new DataBlock<Half, Half, Half>(
                x, y, z))
        { }

        /// <summary>
        /// Constructs a new data block.
        /// </summary>
        public Half3(DataBlock<Half, Half, Half> block)
        {
            dataBlock = block;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The underlying raw data block.
        /// </summary>
        public DataBlock<Half, Half, Half> DataBlock => dataBlock;

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public Half X
        {
            get => dataBlock.Item1;
            set => dataBlock.Item1 = value;
        }

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public Half Y
        {
            get => dataBlock.Item2;
            set => dataBlock.Item2 = value;
        }

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public Half Z
        {
            get => dataBlock.Item3;
            set => dataBlock.Item3 = value;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a value tuple that stores all items.
        /// </summary>
        /// <returns>The constructed value tuple.</returns>
        public (Half, Half, Half) ToValueTuple() => dataBlock.ToValueTuple();

        /// <summary cref="IEquatable{T}.Equals(T)"/>
        public bool Equals(Half3 other) => dataBlock.Equals(other.dataBlock);

        #endregion

        #region Object

        /// <summary>
        /// Returns true if the given object is equal to the current one.
        /// </summary>
        /// <param name="obj">The other object.</param>
        /// <returns>True, if the given object is equal to the current one.</returns>
        public override bool Equals(object? obj) =>
            obj is Half3 other && Equals(other);

        /// <summary>
        /// Returns the combined hash code of all items.
        /// </summary>
        /// <returns>The hash code of all items.</returns>
        public override int GetHashCode() => dataBlock.GetHashCode();

        /// <summary>
        /// Returns the string representation of this view.
        /// </summary>
        /// <returns>The string representation of this view.</returns>
        public override string ToString() => dataBlock.ToString();

        #endregion

        #region Operators

        /// <summary>
        /// Executes an arithmetic * operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Half3 operator *(Half3 left, Half3 right) =>
            new Half3(
                (Half)(left.X * right.X), (Half)(left.Y * right.Y), (Half)(left.Z * right.Z));

        /// <summary>
        /// Executes an arithmetic / operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Half3 operator /(Half3 left, Half3 right) =>
            new Half3(
                (Half)(left.X / right.X), (Half)(left.Y / right.Y), (Half)(left.Z / right.Z));

        /// <summary>
        /// Executes an arithmetic - operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Half3 operator -(Half3 left, Half3 right) =>
            new Half3(
                (Half)(left.X - right.X), (Half)(left.Y - right.Y), (Half)(left.Z - right.Z));

        /// <summary>
        /// Executes an arithmetic + operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Half3 operator +(Half3 left, Half3 right) =>
            new Half3(
                (Half)(left.X + right.X), (Half)(left.Y + right.Y), (Half)(left.Z + right.Z));

        /// <summary>
        /// Converts the given single value into its container representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator Half3(Half value) =>
            new Half3(value);

        /// <summary>
        /// Converts the given value into its tuple representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator (Half, Half, Half)(Half3 value) =>
            value.ToValueTuple();

        /// <summary>
        /// Converts the given value into its data block representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator DataBlock<Half, Half, Half>(Half3 value) =>
            value.DataBlock;

        /// <summary>
        /// Returns true if both data blocks represent the same elements.
        /// </summary>
        /// <param name="left">The left block.</param>
        /// <param name="right">The right block.</param>
        /// <returns>True, if both data block represent the same elements.</returns>
        public static bool operator ==(Half3 left, Half3 right) =>
            left.Equals(right);

        /// <summary>
        /// Returns true if both data blocks do not represent the same elements.
        /// </summary>
        /// <param name="left">The left block.</param>
        /// <param name="right">The right block.</param>
        /// <returns>
        /// True, if both data block do not represent the same elements.
        /// </returns>
        public static bool operator !=(Half3 left, Half3 right) =>
            !(left == right);

        #endregion
    }

    /// <summary>
    /// Represents a combined structure type to hold multiple primitive values of the
    /// same type.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Half4 : IEquatable<Half4>
    {
        #region Constants

        /// <summary>
        /// Represents the native size of a single element.
        /// </summary>
        public static readonly int ElementSize = Interop.SizeOf<Half4>();

        #endregion

        #region Instance

        /// <summary>
        /// The internal data block.
        /// </summary>
        private DataBlock<Half, Half, Half, Half> dataBlock;

        /// <summary>
        /// Constructs a new data container.
        /// </summary>
        public Half4(Half value)
            : this(value, value, value, value)
        { }

        /// <summary>
        /// Constructs a new data container.
        /// </summary>
        public Half4(Half x, Half y, Half z, Half w)
            : this(new DataBlock<Half, Half, Half, Half>(
                x, y, z, w))
        { }

        /// <summary>
        /// Constructs a new data block.
        /// </summary>
        public Half4(DataBlock<Half, Half, Half, Half> block)
        {
            dataBlock = block;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The underlying raw data block.
        /// </summary>
        public DataBlock<Half, Half, Half, Half> DataBlock => dataBlock;

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public Half X
        {
            get => dataBlock.Item1;
            set => dataBlock.Item1 = value;
        }

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public Half Y
        {
            get => dataBlock.Item2;
            set => dataBlock.Item2 = value;
        }

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public Half Z
        {
            get => dataBlock.Item3;
            set => dataBlock.Item3 = value;
        }

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public Half W
        {
            get => dataBlock.Item4;
            set => dataBlock.Item4 = value;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a value tuple that stores all items.
        /// </summary>
        /// <returns>The constructed value tuple.</returns>
        public (Half, Half, Half, Half) ToValueTuple() => dataBlock.ToValueTuple();

        /// <summary cref="IEquatable{T}.Equals(T)"/>
        public bool Equals(Half4 other) => dataBlock.Equals(other.dataBlock);

        #endregion

        #region Object

        /// <summary>
        /// Returns true if the given object is equal to the current one.
        /// </summary>
        /// <param name="obj">The other object.</param>
        /// <returns>True, if the given object is equal to the current one.</returns>
        public override bool Equals(object? obj) =>
            obj is Half4 other && Equals(other);

        /// <summary>
        /// Returns the combined hash code of all items.
        /// </summary>
        /// <returns>The hash code of all items.</returns>
        public override int GetHashCode() => dataBlock.GetHashCode();

        /// <summary>
        /// Returns the string representation of this view.
        /// </summary>
        /// <returns>The string representation of this view.</returns>
        public override string ToString() => dataBlock.ToString();

        #endregion

        #region Operators

        /// <summary>
        /// Executes an arithmetic * operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Half4 operator *(Half4 left, Half4 right) =>
            new Half4(
                (Half)(left.X * right.X), (Half)(left.Y * right.Y), (Half)(left.Z * right.Z), (Half)(left.W * right.W));

        /// <summary>
        /// Executes an arithmetic / operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Half4 operator /(Half4 left, Half4 right) =>
            new Half4(
                (Half)(left.X / right.X), (Half)(left.Y / right.Y), (Half)(left.Z / right.Z), (Half)(left.W / right.W));

        /// <summary>
        /// Executes an arithmetic - operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Half4 operator -(Half4 left, Half4 right) =>
            new Half4(
                (Half)(left.X - right.X), (Half)(left.Y - right.Y), (Half)(left.Z - right.Z), (Half)(left.W - right.W));

        /// <summary>
        /// Executes an arithmetic + operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Half4 operator +(Half4 left, Half4 right) =>
            new Half4(
                (Half)(left.X + right.X), (Half)(left.Y + right.Y), (Half)(left.Z + right.Z), (Half)(left.W + right.W));

        /// <summary>
        /// Converts the given single value into its container representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator Half4(Half value) =>
            new Half4(value);

        /// <summary>
        /// Converts the given value into its tuple representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator (Half, Half, Half, Half)(Half4 value) =>
            value.ToValueTuple();

        /// <summary>
        /// Converts the given value into its data block representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator DataBlock<Half, Half, Half, Half>(Half4 value) =>
            value.DataBlock;

        /// <summary>
        /// Returns true if both data blocks represent the same elements.
        /// </summary>
        /// <param name="left">The left block.</param>
        /// <param name="right">The right block.</param>
        /// <returns>True, if both data block represent the same elements.</returns>
        public static bool operator ==(Half4 left, Half4 right) =>
            left.Equals(right);

        /// <summary>
        /// Returns true if both data blocks do not represent the same elements.
        /// </summary>
        /// <param name="left">The left block.</param>
        /// <param name="right">The right block.</param>
        /// <returns>
        /// True, if both data block do not represent the same elements.
        /// </returns>
        public static bool operator !=(Half4 left, Half4 right) =>
            !(left == right);

        #endregion
    }

    /// <summary>
    /// Represents a combined structure type to hold multiple primitive values of the
    /// same type.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Float2 : IEquatable<Float2>
    {
        #region Constants

        /// <summary>
        /// Represents the native size of a single element.
        /// </summary>
        public static readonly int ElementSize = Interop.SizeOf<Float2>();

        #endregion

        #region Instance

        /// <summary>
        /// The internal data block.
        /// </summary>
        private DataBlock<float, float> dataBlock;

        /// <summary>
        /// Constructs a new data container.
        /// </summary>
        public Float2(float value)
            : this(value, value)
        { }

        /// <summary>
        /// Constructs a new data container.
        /// </summary>
        public Float2(float x, float y)
            : this(new DataBlock<float, float>(
                x, y))
        { }

        /// <summary>
        /// Constructs a new data block.
        /// </summary>
        public Float2(DataBlock<float, float> block)
        {
            dataBlock = block;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The underlying raw data block.
        /// </summary>
        public DataBlock<float, float> DataBlock => dataBlock;

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public float X
        {
            get => dataBlock.Item1;
            set => dataBlock.Item1 = value;
        }

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public float Y
        {
            get => dataBlock.Item2;
            set => dataBlock.Item2 = value;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a value tuple that stores all items.
        /// </summary>
        /// <returns>The constructed value tuple.</returns>
        public (float, float) ToValueTuple() => dataBlock.ToValueTuple();

        /// <summary cref="IEquatable{T}.Equals(T)"/>
        public bool Equals(Float2 other) => dataBlock.Equals(other.dataBlock);

        #endregion

        #region Object

        /// <summary>
        /// Returns true if the given object is equal to the current one.
        /// </summary>
        /// <param name="obj">The other object.</param>
        /// <returns>True, if the given object is equal to the current one.</returns>
        public override bool Equals(object? obj) =>
            obj is Float2 other && Equals(other);

        /// <summary>
        /// Returns the combined hash code of all items.
        /// </summary>
        /// <returns>The hash code of all items.</returns>
        public override int GetHashCode() => dataBlock.GetHashCode();

        /// <summary>
        /// Returns the string representation of this view.
        /// </summary>
        /// <returns>The string representation of this view.</returns>
        public override string ToString() => dataBlock.ToString();

        #endregion

        #region Operators

        /// <summary>
        /// Executes an arithmetic * operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Float2 operator *(Float2 left, Float2 right) =>
            new Float2(
                (float)(left.X * right.X), (float)(left.Y * right.Y));

        /// <summary>
        /// Executes an arithmetic / operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Float2 operator /(Float2 left, Float2 right) =>
            new Float2(
                (float)(left.X / right.X), (float)(left.Y / right.Y));

        /// <summary>
        /// Executes an arithmetic - operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Float2 operator -(Float2 left, Float2 right) =>
            new Float2(
                (float)(left.X - right.X), (float)(left.Y - right.Y));

        /// <summary>
        /// Executes an arithmetic + operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Float2 operator +(Float2 left, Float2 right) =>
            new Float2(
                (float)(left.X + right.X), (float)(left.Y + right.Y));

        /// <summary>
        /// Converts the given single value into its container representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator Float2(float value) =>
            new Float2(value);

        /// <summary>
        /// Converts the given value into its tuple representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator (float, float)(Float2 value) =>
            value.ToValueTuple();

        /// <summary>
        /// Converts the given value into its data block representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator DataBlock<float, float>(Float2 value) =>
            value.DataBlock;

        /// <summary>
        /// Returns true if both data blocks represent the same elements.
        /// </summary>
        /// <param name="left">The left block.</param>
        /// <param name="right">The right block.</param>
        /// <returns>True, if both data block represent the same elements.</returns>
        public static bool operator ==(Float2 left, Float2 right) =>
            left.Equals(right);

        /// <summary>
        /// Returns true if both data blocks do not represent the same elements.
        /// </summary>
        /// <param name="left">The left block.</param>
        /// <param name="right">The right block.</param>
        /// <returns>
        /// True, if both data block do not represent the same elements.
        /// </returns>
        public static bool operator !=(Float2 left, Float2 right) =>
            !(left == right);

        #endregion
    }

    /// <summary>
    /// Represents a combined structure type to hold multiple primitive values of the
    /// same type.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Float3 : IEquatable<Float3>
    {
        #region Constants

        /// <summary>
        /// Represents the native size of a single element.
        /// </summary>
        public static readonly int ElementSize = Interop.SizeOf<Float3>();

        #endregion

        #region Instance

        /// <summary>
        /// The internal data block.
        /// </summary>
        private DataBlock<float, float, float> dataBlock;

        /// <summary>
        /// Constructs a new data container.
        /// </summary>
        public Float3(float value)
            : this(value, value, value)
        { }

        /// <summary>
        /// Constructs a new data container.
        /// </summary>
        public Float3(float x, float y, float z)
            : this(new DataBlock<float, float, float>(
                x, y, z))
        { }

        /// <summary>
        /// Constructs a new data block.
        /// </summary>
        public Float3(DataBlock<float, float, float> block)
        {
            dataBlock = block;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The underlying raw data block.
        /// </summary>
        public DataBlock<float, float, float> DataBlock => dataBlock;

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public float X
        {
            get => dataBlock.Item1;
            set => dataBlock.Item1 = value;
        }

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public float Y
        {
            get => dataBlock.Item2;
            set => dataBlock.Item2 = value;
        }

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public float Z
        {
            get => dataBlock.Item3;
            set => dataBlock.Item3 = value;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a value tuple that stores all items.
        /// </summary>
        /// <returns>The constructed value tuple.</returns>
        public (float, float, float) ToValueTuple() => dataBlock.ToValueTuple();

        /// <summary cref="IEquatable{T}.Equals(T)"/>
        public bool Equals(Float3 other) => dataBlock.Equals(other.dataBlock);

        #endregion

        #region Object

        /// <summary>
        /// Returns true if the given object is equal to the current one.
        /// </summary>
        /// <param name="obj">The other object.</param>
        /// <returns>True, if the given object is equal to the current one.</returns>
        public override bool Equals(object? obj) =>
            obj is Float3 other && Equals(other);

        /// <summary>
        /// Returns the combined hash code of all items.
        /// </summary>
        /// <returns>The hash code of all items.</returns>
        public override int GetHashCode() => dataBlock.GetHashCode();

        /// <summary>
        /// Returns the string representation of this view.
        /// </summary>
        /// <returns>The string representation of this view.</returns>
        public override string ToString() => dataBlock.ToString();

        #endregion

        #region Operators

        /// <summary>
        /// Executes an arithmetic * operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Float3 operator *(Float3 left, Float3 right) =>
            new Float3(
                (float)(left.X * right.X), (float)(left.Y * right.Y), (float)(left.Z * right.Z));

        /// <summary>
        /// Executes an arithmetic / operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Float3 operator /(Float3 left, Float3 right) =>
            new Float3(
                (float)(left.X / right.X), (float)(left.Y / right.Y), (float)(left.Z / right.Z));

        /// <summary>
        /// Executes an arithmetic - operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Float3 operator -(Float3 left, Float3 right) =>
            new Float3(
                (float)(left.X - right.X), (float)(left.Y - right.Y), (float)(left.Z - right.Z));

        /// <summary>
        /// Executes an arithmetic + operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Float3 operator +(Float3 left, Float3 right) =>
            new Float3(
                (float)(left.X + right.X), (float)(left.Y + right.Y), (float)(left.Z + right.Z));

        /// <summary>
        /// Converts the given single value into its container representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator Float3(float value) =>
            new Float3(value);

        /// <summary>
        /// Converts the given value into its tuple representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator (float, float, float)(Float3 value) =>
            value.ToValueTuple();

        /// <summary>
        /// Converts the given value into its data block representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator DataBlock<float, float, float>(Float3 value) =>
            value.DataBlock;

        /// <summary>
        /// Returns true if both data blocks represent the same elements.
        /// </summary>
        /// <param name="left">The left block.</param>
        /// <param name="right">The right block.</param>
        /// <returns>True, if both data block represent the same elements.</returns>
        public static bool operator ==(Float3 left, Float3 right) =>
            left.Equals(right);

        /// <summary>
        /// Returns true if both data blocks do not represent the same elements.
        /// </summary>
        /// <param name="left">The left block.</param>
        /// <param name="right">The right block.</param>
        /// <returns>
        /// True, if both data block do not represent the same elements.
        /// </returns>
        public static bool operator !=(Float3 left, Float3 right) =>
            !(left == right);

        #endregion
    }

    /// <summary>
    /// Represents a combined structure type to hold multiple primitive values of the
    /// same type.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Float4 : IEquatable<Float4>
    {
        #region Constants

        /// <summary>
        /// Represents the native size of a single element.
        /// </summary>
        public static readonly int ElementSize = Interop.SizeOf<Float4>();

        #endregion

        #region Instance

        /// <summary>
        /// The internal data block.
        /// </summary>
        private DataBlock<float, float, float, float> dataBlock;

        /// <summary>
        /// Constructs a new data container.
        /// </summary>
        public Float4(float value)
            : this(value, value, value, value)
        { }

        /// <summary>
        /// Constructs a new data container.
        /// </summary>
        public Float4(float x, float y, float z, float w)
            : this(new DataBlock<float, float, float, float>(
                x, y, z, w))
        { }

        /// <summary>
        /// Constructs a new data block.
        /// </summary>
        public Float4(DataBlock<float, float, float, float> block)
        {
            dataBlock = block;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The underlying raw data block.
        /// </summary>
        public DataBlock<float, float, float, float> DataBlock => dataBlock;

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public float X
        {
            get => dataBlock.Item1;
            set => dataBlock.Item1 = value;
        }

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public float Y
        {
            get => dataBlock.Item2;
            set => dataBlock.Item2 = value;
        }

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public float Z
        {
            get => dataBlock.Item3;
            set => dataBlock.Item3 = value;
        }

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public float W
        {
            get => dataBlock.Item4;
            set => dataBlock.Item4 = value;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a value tuple that stores all items.
        /// </summary>
        /// <returns>The constructed value tuple.</returns>
        public (float, float, float, float) ToValueTuple() => dataBlock.ToValueTuple();

        /// <summary cref="IEquatable{T}.Equals(T)"/>
        public bool Equals(Float4 other) => dataBlock.Equals(other.dataBlock);

        #endregion

        #region Object

        /// <summary>
        /// Returns true if the given object is equal to the current one.
        /// </summary>
        /// <param name="obj">The other object.</param>
        /// <returns>True, if the given object is equal to the current one.</returns>
        public override bool Equals(object? obj) =>
            obj is Float4 other && Equals(other);

        /// <summary>
        /// Returns the combined hash code of all items.
        /// </summary>
        /// <returns>The hash code of all items.</returns>
        public override int GetHashCode() => dataBlock.GetHashCode();

        /// <summary>
        /// Returns the string representation of this view.
        /// </summary>
        /// <returns>The string representation of this view.</returns>
        public override string ToString() => dataBlock.ToString();

        #endregion

        #region Operators

        /// <summary>
        /// Executes an arithmetic * operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Float4 operator *(Float4 left, Float4 right) =>
            new Float4(
                (float)(left.X * right.X), (float)(left.Y * right.Y), (float)(left.Z * right.Z), (float)(left.W * right.W));

        /// <summary>
        /// Executes an arithmetic / operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Float4 operator /(Float4 left, Float4 right) =>
            new Float4(
                (float)(left.X / right.X), (float)(left.Y / right.Y), (float)(left.Z / right.Z), (float)(left.W / right.W));

        /// <summary>
        /// Executes an arithmetic - operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Float4 operator -(Float4 left, Float4 right) =>
            new Float4(
                (float)(left.X - right.X), (float)(left.Y - right.Y), (float)(left.Z - right.Z), (float)(left.W - right.W));

        /// <summary>
        /// Executes an arithmetic + operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Float4 operator +(Float4 left, Float4 right) =>
            new Float4(
                (float)(left.X + right.X), (float)(left.Y + right.Y), (float)(left.Z + right.Z), (float)(left.W + right.W));

        /// <summary>
        /// Converts the given single value into its container representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator Float4(float value) =>
            new Float4(value);

        /// <summary>
        /// Converts the given value into its tuple representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator (float, float, float, float)(Float4 value) =>
            value.ToValueTuple();

        /// <summary>
        /// Converts the given value into its data block representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator DataBlock<float, float, float, float>(Float4 value) =>
            value.DataBlock;

        /// <summary>
        /// Returns true if both data blocks represent the same elements.
        /// </summary>
        /// <param name="left">The left block.</param>
        /// <param name="right">The right block.</param>
        /// <returns>True, if both data block represent the same elements.</returns>
        public static bool operator ==(Float4 left, Float4 right) =>
            left.Equals(right);

        /// <summary>
        /// Returns true if both data blocks do not represent the same elements.
        /// </summary>
        /// <param name="left">The left block.</param>
        /// <param name="right">The right block.</param>
        /// <returns>
        /// True, if both data block do not represent the same elements.
        /// </returns>
        public static bool operator !=(Float4 left, Float4 right) =>
            !(left == right);

        #endregion
    }

    /// <summary>
    /// Represents a combined structure type to hold multiple primitive values of the
    /// same type.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Double2 : IEquatable<Double2>
    {
        #region Constants

        /// <summary>
        /// Represents the native size of a single element.
        /// </summary>
        public static readonly int ElementSize = Interop.SizeOf<Double2>();

        #endregion

        #region Instance

        /// <summary>
        /// The internal data block.
        /// </summary>
        private DataBlock<double, double> dataBlock;

        /// <summary>
        /// Constructs a new data container.
        /// </summary>
        public Double2(double value)
            : this(value, value)
        { }

        /// <summary>
        /// Constructs a new data container.
        /// </summary>
        public Double2(double x, double y)
            : this(new DataBlock<double, double>(
                x, y))
        { }

        /// <summary>
        /// Constructs a new data block.
        /// </summary>
        public Double2(DataBlock<double, double> block)
        {
            dataBlock = block;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The underlying raw data block.
        /// </summary>
        public DataBlock<double, double> DataBlock => dataBlock;

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public double X
        {
            get => dataBlock.Item1;
            set => dataBlock.Item1 = value;
        }

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public double Y
        {
            get => dataBlock.Item2;
            set => dataBlock.Item2 = value;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a value tuple that stores all items.
        /// </summary>
        /// <returns>The constructed value tuple.</returns>
        public (double, double) ToValueTuple() => dataBlock.ToValueTuple();

        /// <summary cref="IEquatable{T}.Equals(T)"/>
        public bool Equals(Double2 other) => dataBlock.Equals(other.dataBlock);

        #endregion

        #region Object

        /// <summary>
        /// Returns true if the given object is equal to the current one.
        /// </summary>
        /// <param name="obj">The other object.</param>
        /// <returns>True, if the given object is equal to the current one.</returns>
        public override bool Equals(object? obj) =>
            obj is Double2 other && Equals(other);

        /// <summary>
        /// Returns the combined hash code of all items.
        /// </summary>
        /// <returns>The hash code of all items.</returns>
        public override int GetHashCode() => dataBlock.GetHashCode();

        /// <summary>
        /// Returns the string representation of this view.
        /// </summary>
        /// <returns>The string representation of this view.</returns>
        public override string ToString() => dataBlock.ToString();

        #endregion

        #region Operators

        /// <summary>
        /// Executes an arithmetic * operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Double2 operator *(Double2 left, Double2 right) =>
            new Double2(
                (double)(left.X * right.X), (double)(left.Y * right.Y));

        /// <summary>
        /// Executes an arithmetic / operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Double2 operator /(Double2 left, Double2 right) =>
            new Double2(
                (double)(left.X / right.X), (double)(left.Y / right.Y));

        /// <summary>
        /// Executes an arithmetic - operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Double2 operator -(Double2 left, Double2 right) =>
            new Double2(
                (double)(left.X - right.X), (double)(left.Y - right.Y));

        /// <summary>
        /// Executes an arithmetic + operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Double2 operator +(Double2 left, Double2 right) =>
            new Double2(
                (double)(left.X + right.X), (double)(left.Y + right.Y));

        /// <summary>
        /// Converts the given single value into its container representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator Double2(double value) =>
            new Double2(value);

        /// <summary>
        /// Converts the given value into its tuple representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator (double, double)(Double2 value) =>
            value.ToValueTuple();

        /// <summary>
        /// Converts the given value into its data block representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator DataBlock<double, double>(Double2 value) =>
            value.DataBlock;

        /// <summary>
        /// Returns true if both data blocks represent the same elements.
        /// </summary>
        /// <param name="left">The left block.</param>
        /// <param name="right">The right block.</param>
        /// <returns>True, if both data block represent the same elements.</returns>
        public static bool operator ==(Double2 left, Double2 right) =>
            left.Equals(right);

        /// <summary>
        /// Returns true if both data blocks do not represent the same elements.
        /// </summary>
        /// <param name="left">The left block.</param>
        /// <param name="right">The right block.</param>
        /// <returns>
        /// True, if both data block do not represent the same elements.
        /// </returns>
        public static bool operator !=(Double2 left, Double2 right) =>
            !(left == right);

        #endregion
    }

    /// <summary>
    /// Represents a combined structure type to hold multiple primitive values of the
    /// same type.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Double3 : IEquatable<Double3>
    {
        #region Constants

        /// <summary>
        /// Represents the native size of a single element.
        /// </summary>
        public static readonly int ElementSize = Interop.SizeOf<Double3>();

        #endregion

        #region Instance

        /// <summary>
        /// The internal data block.
        /// </summary>
        private DataBlock<double, double, double> dataBlock;

        /// <summary>
        /// Constructs a new data container.
        /// </summary>
        public Double3(double value)
            : this(value, value, value)
        { }

        /// <summary>
        /// Constructs a new data container.
        /// </summary>
        public Double3(double x, double y, double z)
            : this(new DataBlock<double, double, double>(
                x, y, z))
        { }

        /// <summary>
        /// Constructs a new data block.
        /// </summary>
        public Double3(DataBlock<double, double, double> block)
        {
            dataBlock = block;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The underlying raw data block.
        /// </summary>
        public DataBlock<double, double, double> DataBlock => dataBlock;

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public double X
        {
            get => dataBlock.Item1;
            set => dataBlock.Item1 = value;
        }

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public double Y
        {
            get => dataBlock.Item2;
            set => dataBlock.Item2 = value;
        }

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public double Z
        {
            get => dataBlock.Item3;
            set => dataBlock.Item3 = value;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a value tuple that stores all items.
        /// </summary>
        /// <returns>The constructed value tuple.</returns>
        public (double, double, double) ToValueTuple() => dataBlock.ToValueTuple();

        /// <summary cref="IEquatable{T}.Equals(T)"/>
        public bool Equals(Double3 other) => dataBlock.Equals(other.dataBlock);

        #endregion

        #region Object

        /// <summary>
        /// Returns true if the given object is equal to the current one.
        /// </summary>
        /// <param name="obj">The other object.</param>
        /// <returns>True, if the given object is equal to the current one.</returns>
        public override bool Equals(object? obj) =>
            obj is Double3 other && Equals(other);

        /// <summary>
        /// Returns the combined hash code of all items.
        /// </summary>
        /// <returns>The hash code of all items.</returns>
        public override int GetHashCode() => dataBlock.GetHashCode();

        /// <summary>
        /// Returns the string representation of this view.
        /// </summary>
        /// <returns>The string representation of this view.</returns>
        public override string ToString() => dataBlock.ToString();

        #endregion

        #region Operators

        /// <summary>
        /// Executes an arithmetic * operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Double3 operator *(Double3 left, Double3 right) =>
            new Double3(
                (double)(left.X * right.X), (double)(left.Y * right.Y), (double)(left.Z * right.Z));

        /// <summary>
        /// Executes an arithmetic / operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Double3 operator /(Double3 left, Double3 right) =>
            new Double3(
                (double)(left.X / right.X), (double)(left.Y / right.Y), (double)(left.Z / right.Z));

        /// <summary>
        /// Executes an arithmetic - operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Double3 operator -(Double3 left, Double3 right) =>
            new Double3(
                (double)(left.X - right.X), (double)(left.Y - right.Y), (double)(left.Z - right.Z));

        /// <summary>
        /// Executes an arithmetic + operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Double3 operator +(Double3 left, Double3 right) =>
            new Double3(
                (double)(left.X + right.X), (double)(left.Y + right.Y), (double)(left.Z + right.Z));

        /// <summary>
        /// Converts the given single value into its container representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator Double3(double value) =>
            new Double3(value);

        /// <summary>
        /// Converts the given value into its tuple representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator (double, double, double)(Double3 value) =>
            value.ToValueTuple();

        /// <summary>
        /// Converts the given value into its data block representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator DataBlock<double, double, double>(Double3 value) =>
            value.DataBlock;

        /// <summary>
        /// Returns true if both data blocks represent the same elements.
        /// </summary>
        /// <param name="left">The left block.</param>
        /// <param name="right">The right block.</param>
        /// <returns>True, if both data block represent the same elements.</returns>
        public static bool operator ==(Double3 left, Double3 right) =>
            left.Equals(right);

        /// <summary>
        /// Returns true if both data blocks do not represent the same elements.
        /// </summary>
        /// <param name="left">The left block.</param>
        /// <param name="right">The right block.</param>
        /// <returns>
        /// True, if both data block do not represent the same elements.
        /// </returns>
        public static bool operator !=(Double3 left, Double3 right) =>
            !(left == right);

        #endregion
    }

    /// <summary>
    /// Represents a combined structure type to hold multiple primitive values of the
    /// same type.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Double4 : IEquatable<Double4>
    {
        #region Constants

        /// <summary>
        /// Represents the native size of a single element.
        /// </summary>
        public static readonly int ElementSize = Interop.SizeOf<Double4>();

        #endregion

        #region Instance

        /// <summary>
        /// The internal data block.
        /// </summary>
        private DataBlock<double, double, double, double> dataBlock;

        /// <summary>
        /// Constructs a new data container.
        /// </summary>
        public Double4(double value)
            : this(value, value, value, value)
        { }

        /// <summary>
        /// Constructs a new data container.
        /// </summary>
        public Double4(double x, double y, double z, double w)
            : this(new DataBlock<double, double, double, double>(
                x, y, z, w))
        { }

        /// <summary>
        /// Constructs a new data block.
        /// </summary>
        public Double4(DataBlock<double, double, double, double> block)
        {
            dataBlock = block;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The underlying raw data block.
        /// </summary>
        public DataBlock<double, double, double, double> DataBlock => dataBlock;

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public double X
        {
            get => dataBlock.Item1;
            set => dataBlock.Item1 = value;
        }

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public double Y
        {
            get => dataBlock.Item2;
            set => dataBlock.Item2 = value;
        }

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public double Z
        {
            get => dataBlock.Item3;
            set => dataBlock.Item3 = value;
        }

        /// <summary>
        /// Returns the i-th element.
        /// </summary>
        public double W
        {
            get => dataBlock.Item4;
            set => dataBlock.Item4 = value;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a value tuple that stores all items.
        /// </summary>
        /// <returns>The constructed value tuple.</returns>
        public (double, double, double, double) ToValueTuple() => dataBlock.ToValueTuple();

        /// <summary cref="IEquatable{T}.Equals(T)"/>
        public bool Equals(Double4 other) => dataBlock.Equals(other.dataBlock);

        #endregion

        #region Object

        /// <summary>
        /// Returns true if the given object is equal to the current one.
        /// </summary>
        /// <param name="obj">The other object.</param>
        /// <returns>True, if the given object is equal to the current one.</returns>
        public override bool Equals(object? obj) =>
            obj is Double4 other && Equals(other);

        /// <summary>
        /// Returns the combined hash code of all items.
        /// </summary>
        /// <returns>The hash code of all items.</returns>
        public override int GetHashCode() => dataBlock.GetHashCode();

        /// <summary>
        /// Returns the string representation of this view.
        /// </summary>
        /// <returns>The string representation of this view.</returns>
        public override string ToString() => dataBlock.ToString();

        #endregion

        #region Operators

        /// <summary>
        /// Executes an arithmetic * operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Double4 operator *(Double4 left, Double4 right) =>
            new Double4(
                (double)(left.X * right.X), (double)(left.Y * right.Y), (double)(left.Z * right.Z), (double)(left.W * right.W));

        /// <summary>
        /// Executes an arithmetic / operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Double4 operator /(Double4 left, Double4 right) =>
            new Double4(
                (double)(left.X / right.X), (double)(left.Y / right.Y), (double)(left.Z / right.Z), (double)(left.W / right.W));

        /// <summary>
        /// Executes an arithmetic - operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Double4 operator -(Double4 left, Double4 right) =>
            new Double4(
                (double)(left.X - right.X), (double)(left.Y - right.Y), (double)(left.Z - right.Z), (double)(left.W - right.W));

        /// <summary>
        /// Executes an arithmetic + operation on all elements.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting value.</returns>
        public static Double4 operator +(Double4 left, Double4 right) =>
            new Double4(
                (double)(left.X + right.X), (double)(left.Y + right.Y), (double)(left.Z + right.Z), (double)(left.W + right.W));

        /// <summary>
        /// Converts the given single value into its container representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator Double4(double value) =>
            new Double4(value);

        /// <summary>
        /// Converts the given value into its tuple representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator (double, double, double, double)(Double4 value) =>
            value.ToValueTuple();

        /// <summary>
        /// Converts the given value into its data block representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator DataBlock<double, double, double, double>(Double4 value) =>
            value.DataBlock;

        /// <summary>
        /// Returns true if both data blocks represent the same elements.
        /// </summary>
        /// <param name="left">The left block.</param>
        /// <param name="right">The right block.</param>
        /// <returns>True, if both data block represent the same elements.</returns>
        public static bool operator ==(Double4 left, Double4 right) =>
            left.Equals(right);

        /// <summary>
        /// Returns true if both data blocks do not represent the same elements.
        /// </summary>
        /// <param name="left">The left block.</param>
        /// <param name="right">The right block.</param>
        /// <returns>
        /// True, if both data block do not represent the same elements.
        /// </returns>
        public static bool operator !=(Double4 left, Double4 right) =>
            !(left == right);

        #endregion
    }

}

#pragma warning restore IDE0047 // Remove unnecessary parentheses