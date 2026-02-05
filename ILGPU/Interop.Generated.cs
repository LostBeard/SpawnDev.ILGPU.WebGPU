// ---------------------------------------------------------------------------------------
//                                        ILGPU
//                        Copyright (c) 2016-2021 ILGPU Project
//                                    www.ilgpu.net
//
// File: Interop.Generated.tt/Interop.Generated.cs
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

// disable: max_line_length

namespace ILGPU
{
    partial class Interop
    {
        /// <summary>
        /// Writes the given arguments using the format provided.
        /// </summary>
        /// <typeparam name="T1">Parameter type of parameter 1.</typeparam>

        /// <param name="format">The format expression.</param>
        /// <param name="arg1">Argument 1 to format.</param>

        [InteropIntrinsic(InteropIntrinsicKind.Write)]
        public static void Write<T1>(
            string format,
            T1 arg1)
            where T1 : unmanaged =>
            WriteImplementation(format, arg1.ToString());

        /// <summary>
        /// Writes the given arguments using the format provided.
        /// </summary>
        /// <typeparam name="T1">Parameter type of parameter 1.</typeparam>

        /// <param name="format">The format expression.</param>
        /// <param name="arg1">Argument 1 to format.</param>

        [InteropIntrinsic(InteropIntrinsicKind.WriteLine)]
        public static void WriteLine<T1>(
            string format,
            T1 arg1)
            where T1 : unmanaged =>
            WriteImplementation(
                GetWriteLineFormat(format),
                arg1.ToString());

        /// <summary>
        /// Writes the given arguments using the format provided.
        /// </summary>
        /// <typeparam name="T1">Parameter type of parameter 1.</typeparam>
        /// <typeparam name="T2">Parameter type of parameter 2.</typeparam>

        /// <param name="format">The format expression.</param>
        /// <param name="arg1">Argument 1 to format.</param>
        /// <param name="arg2">Argument 2 to format.</param>

        [InteropIntrinsic(InteropIntrinsicKind.Write)]
        public static void Write<T1, T2>(
            string format,
            T1 arg1, T2 arg2)
            where T1 : unmanaged where T2 : unmanaged =>
            WriteImplementation(format, arg1.ToString(), arg2.ToString());

        /// <summary>
        /// Writes the given arguments using the format provided.
        /// </summary>
        /// <typeparam name="T1">Parameter type of parameter 1.</typeparam>
        /// <typeparam name="T2">Parameter type of parameter 2.</typeparam>

        /// <param name="format">The format expression.</param>
        /// <param name="arg1">Argument 1 to format.</param>
        /// <param name="arg2">Argument 2 to format.</param>

        [InteropIntrinsic(InteropIntrinsicKind.WriteLine)]
        public static void WriteLine<T1, T2>(
            string format,
            T1 arg1, T2 arg2)
            where T1 : unmanaged where T2 : unmanaged =>
            WriteImplementation(
                GetWriteLineFormat(format),
                arg1.ToString(), arg2.ToString());

        /// <summary>
        /// Writes the given arguments using the format provided.
        /// </summary>
        /// <typeparam name="T1">Parameter type of parameter 1.</typeparam>
        /// <typeparam name="T2">Parameter type of parameter 2.</typeparam>
        /// <typeparam name="T3">Parameter type of parameter 3.</typeparam>

        /// <param name="format">The format expression.</param>
        /// <param name="arg1">Argument 1 to format.</param>
        /// <param name="arg2">Argument 2 to format.</param>
        /// <param name="arg3">Argument 3 to format.</param>

        [InteropIntrinsic(InteropIntrinsicKind.Write)]
        public static void Write<T1, T2, T3>(
            string format,
            T1 arg1, T2 arg2, T3 arg3)
            where T1 : unmanaged where T2 : unmanaged where T3 : unmanaged =>
            WriteImplementation(format, arg1.ToString(), arg2.ToString(), arg3.ToString());

        /// <summary>
        /// Writes the given arguments using the format provided.
        /// </summary>
        /// <typeparam name="T1">Parameter type of parameter 1.</typeparam>
        /// <typeparam name="T2">Parameter type of parameter 2.</typeparam>
        /// <typeparam name="T3">Parameter type of parameter 3.</typeparam>

        /// <param name="format">The format expression.</param>
        /// <param name="arg1">Argument 1 to format.</param>
        /// <param name="arg2">Argument 2 to format.</param>
        /// <param name="arg3">Argument 3 to format.</param>

        [InteropIntrinsic(InteropIntrinsicKind.WriteLine)]
        public static void WriteLine<T1, T2, T3>(
            string format,
            T1 arg1, T2 arg2, T3 arg3)
            where T1 : unmanaged where T2 : unmanaged where T3 : unmanaged =>
            WriteImplementation(
                GetWriteLineFormat(format),
                arg1.ToString(), arg2.ToString(), arg3.ToString());

        /// <summary>
        /// Writes the given arguments using the format provided.
        /// </summary>
        /// <typeparam name="T1">Parameter type of parameter 1.</typeparam>
        /// <typeparam name="T2">Parameter type of parameter 2.</typeparam>
        /// <typeparam name="T3">Parameter type of parameter 3.</typeparam>
        /// <typeparam name="T4">Parameter type of parameter 4.</typeparam>

        /// <param name="format">The format expression.</param>
        /// <param name="arg1">Argument 1 to format.</param>
        /// <param name="arg2">Argument 2 to format.</param>
        /// <param name="arg3">Argument 3 to format.</param>
        /// <param name="arg4">Argument 4 to format.</param>

        [InteropIntrinsic(InteropIntrinsicKind.Write)]
        public static void Write<T1, T2, T3, T4>(
            string format,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4)
            where T1 : unmanaged where T2 : unmanaged where T3 : unmanaged where T4 : unmanaged =>
            WriteImplementation(format, arg1.ToString(), arg2.ToString(), arg3.ToString(), arg4.ToString());

        /// <summary>
        /// Writes the given arguments using the format provided.
        /// </summary>
        /// <typeparam name="T1">Parameter type of parameter 1.</typeparam>
        /// <typeparam name="T2">Parameter type of parameter 2.</typeparam>
        /// <typeparam name="T3">Parameter type of parameter 3.</typeparam>
        /// <typeparam name="T4">Parameter type of parameter 4.</typeparam>

        /// <param name="format">The format expression.</param>
        /// <param name="arg1">Argument 1 to format.</param>
        /// <param name="arg2">Argument 2 to format.</param>
        /// <param name="arg3">Argument 3 to format.</param>
        /// <param name="arg4">Argument 4 to format.</param>

        [InteropIntrinsic(InteropIntrinsicKind.WriteLine)]
        public static void WriteLine<T1, T2, T3, T4>(
            string format,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4)
            where T1 : unmanaged where T2 : unmanaged where T3 : unmanaged where T4 : unmanaged =>
            WriteImplementation(
                GetWriteLineFormat(format),
                arg1.ToString(), arg2.ToString(), arg3.ToString(), arg4.ToString());

        /// <summary>
        /// Writes the given arguments using the format provided.
        /// </summary>
        /// <typeparam name="T1">Parameter type of parameter 1.</typeparam>
        /// <typeparam name="T2">Parameter type of parameter 2.</typeparam>
        /// <typeparam name="T3">Parameter type of parameter 3.</typeparam>
        /// <typeparam name="T4">Parameter type of parameter 4.</typeparam>
        /// <typeparam name="T5">Parameter type of parameter 5.</typeparam>

        /// <param name="format">The format expression.</param>
        /// <param name="arg1">Argument 1 to format.</param>
        /// <param name="arg2">Argument 2 to format.</param>
        /// <param name="arg3">Argument 3 to format.</param>
        /// <param name="arg4">Argument 4 to format.</param>
        /// <param name="arg5">Argument 5 to format.</param>

        [InteropIntrinsic(InteropIntrinsicKind.Write)]
        public static void Write<T1, T2, T3, T4, T5>(
            string format,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
            where T1 : unmanaged where T2 : unmanaged where T3 : unmanaged where T4 : unmanaged where T5 : unmanaged =>
            WriteImplementation(format, arg1.ToString(), arg2.ToString(), arg3.ToString(), arg4.ToString(), arg5.ToString());

        /// <summary>
        /// Writes the given arguments using the format provided.
        /// </summary>
        /// <typeparam name="T1">Parameter type of parameter 1.</typeparam>
        /// <typeparam name="T2">Parameter type of parameter 2.</typeparam>
        /// <typeparam name="T3">Parameter type of parameter 3.</typeparam>
        /// <typeparam name="T4">Parameter type of parameter 4.</typeparam>
        /// <typeparam name="T5">Parameter type of parameter 5.</typeparam>

        /// <param name="format">The format expression.</param>
        /// <param name="arg1">Argument 1 to format.</param>
        /// <param name="arg2">Argument 2 to format.</param>
        /// <param name="arg3">Argument 3 to format.</param>
        /// <param name="arg4">Argument 4 to format.</param>
        /// <param name="arg5">Argument 5 to format.</param>

        [InteropIntrinsic(InteropIntrinsicKind.WriteLine)]
        public static void WriteLine<T1, T2, T3, T4, T5>(
            string format,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
            where T1 : unmanaged where T2 : unmanaged where T3 : unmanaged where T4 : unmanaged where T5 : unmanaged =>
            WriteImplementation(
                GetWriteLineFormat(format),
                arg1.ToString(), arg2.ToString(), arg3.ToString(), arg4.ToString(), arg5.ToString());

        /// <summary>
        /// Writes the given arguments using the format provided.
        /// </summary>
        /// <typeparam name="T1">Parameter type of parameter 1.</typeparam>
        /// <typeparam name="T2">Parameter type of parameter 2.</typeparam>
        /// <typeparam name="T3">Parameter type of parameter 3.</typeparam>
        /// <typeparam name="T4">Parameter type of parameter 4.</typeparam>
        /// <typeparam name="T5">Parameter type of parameter 5.</typeparam>
        /// <typeparam name="T6">Parameter type of parameter 6.</typeparam>

        /// <param name="format">The format expression.</param>
        /// <param name="arg1">Argument 1 to format.</param>
        /// <param name="arg2">Argument 2 to format.</param>
        /// <param name="arg3">Argument 3 to format.</param>
        /// <param name="arg4">Argument 4 to format.</param>
        /// <param name="arg5">Argument 5 to format.</param>
        /// <param name="arg6">Argument 6 to format.</param>

        [InteropIntrinsic(InteropIntrinsicKind.Write)]
        public static void Write<T1, T2, T3, T4, T5, T6>(
            string format,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
            where T1 : unmanaged where T2 : unmanaged where T3 : unmanaged where T4 : unmanaged where T5 : unmanaged where T6 : unmanaged =>
            WriteImplementation(format, arg1.ToString(), arg2.ToString(), arg3.ToString(), arg4.ToString(), arg5.ToString(), arg6.ToString());

        /// <summary>
        /// Writes the given arguments using the format provided.
        /// </summary>
        /// <typeparam name="T1">Parameter type of parameter 1.</typeparam>
        /// <typeparam name="T2">Parameter type of parameter 2.</typeparam>
        /// <typeparam name="T3">Parameter type of parameter 3.</typeparam>
        /// <typeparam name="T4">Parameter type of parameter 4.</typeparam>
        /// <typeparam name="T5">Parameter type of parameter 5.</typeparam>
        /// <typeparam name="T6">Parameter type of parameter 6.</typeparam>

        /// <param name="format">The format expression.</param>
        /// <param name="arg1">Argument 1 to format.</param>
        /// <param name="arg2">Argument 2 to format.</param>
        /// <param name="arg3">Argument 3 to format.</param>
        /// <param name="arg4">Argument 4 to format.</param>
        /// <param name="arg5">Argument 5 to format.</param>
        /// <param name="arg6">Argument 6 to format.</param>

        [InteropIntrinsic(InteropIntrinsicKind.WriteLine)]
        public static void WriteLine<T1, T2, T3, T4, T5, T6>(
            string format,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
            where T1 : unmanaged where T2 : unmanaged where T3 : unmanaged where T4 : unmanaged where T5 : unmanaged where T6 : unmanaged =>
            WriteImplementation(
                GetWriteLineFormat(format),
                arg1.ToString(), arg2.ToString(), arg3.ToString(), arg4.ToString(), arg5.ToString(), arg6.ToString());

        /// <summary>
        /// Writes the given arguments using the format provided.
        /// </summary>
        /// <typeparam name="T1">Parameter type of parameter 1.</typeparam>
        /// <typeparam name="T2">Parameter type of parameter 2.</typeparam>
        /// <typeparam name="T3">Parameter type of parameter 3.</typeparam>
        /// <typeparam name="T4">Parameter type of parameter 4.</typeparam>
        /// <typeparam name="T5">Parameter type of parameter 5.</typeparam>
        /// <typeparam name="T6">Parameter type of parameter 6.</typeparam>
        /// <typeparam name="T7">Parameter type of parameter 7.</typeparam>

        /// <param name="format">The format expression.</param>
        /// <param name="arg1">Argument 1 to format.</param>
        /// <param name="arg2">Argument 2 to format.</param>
        /// <param name="arg3">Argument 3 to format.</param>
        /// <param name="arg4">Argument 4 to format.</param>
        /// <param name="arg5">Argument 5 to format.</param>
        /// <param name="arg6">Argument 6 to format.</param>
        /// <param name="arg7">Argument 7 to format.</param>

        [InteropIntrinsic(InteropIntrinsicKind.Write)]
        public static void Write<T1, T2, T3, T4, T5, T6, T7>(
            string format,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
            where T1 : unmanaged where T2 : unmanaged where T3 : unmanaged where T4 : unmanaged where T5 : unmanaged where T6 : unmanaged where T7 : unmanaged =>
            WriteImplementation(format, arg1.ToString(), arg2.ToString(), arg3.ToString(), arg4.ToString(), arg5.ToString(), arg6.ToString(), arg7.ToString());

        /// <summary>
        /// Writes the given arguments using the format provided.
        /// </summary>
        /// <typeparam name="T1">Parameter type of parameter 1.</typeparam>
        /// <typeparam name="T2">Parameter type of parameter 2.</typeparam>
        /// <typeparam name="T3">Parameter type of parameter 3.</typeparam>
        /// <typeparam name="T4">Parameter type of parameter 4.</typeparam>
        /// <typeparam name="T5">Parameter type of parameter 5.</typeparam>
        /// <typeparam name="T6">Parameter type of parameter 6.</typeparam>
        /// <typeparam name="T7">Parameter type of parameter 7.</typeparam>

        /// <param name="format">The format expression.</param>
        /// <param name="arg1">Argument 1 to format.</param>
        /// <param name="arg2">Argument 2 to format.</param>
        /// <param name="arg3">Argument 3 to format.</param>
        /// <param name="arg4">Argument 4 to format.</param>
        /// <param name="arg5">Argument 5 to format.</param>
        /// <param name="arg6">Argument 6 to format.</param>
        /// <param name="arg7">Argument 7 to format.</param>

        [InteropIntrinsic(InteropIntrinsicKind.WriteLine)]
        public static void WriteLine<T1, T2, T3, T4, T5, T6, T7>(
            string format,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
            where T1 : unmanaged where T2 : unmanaged where T3 : unmanaged where T4 : unmanaged where T5 : unmanaged where T6 : unmanaged where T7 : unmanaged =>
            WriteImplementation(
                GetWriteLineFormat(format),
                arg1.ToString(), arg2.ToString(), arg3.ToString(), arg4.ToString(), arg5.ToString(), arg6.ToString(), arg7.ToString());

        /// <summary>
        /// Writes the given arguments using the format provided.
        /// </summary>
        /// <typeparam name="T1">Parameter type of parameter 1.</typeparam>
        /// <typeparam name="T2">Parameter type of parameter 2.</typeparam>
        /// <typeparam name="T3">Parameter type of parameter 3.</typeparam>
        /// <typeparam name="T4">Parameter type of parameter 4.</typeparam>
        /// <typeparam name="T5">Parameter type of parameter 5.</typeparam>
        /// <typeparam name="T6">Parameter type of parameter 6.</typeparam>
        /// <typeparam name="T7">Parameter type of parameter 7.</typeparam>
        /// <typeparam name="T8">Parameter type of parameter 8.</typeparam>

        /// <param name="format">The format expression.</param>
        /// <param name="arg1">Argument 1 to format.</param>
        /// <param name="arg2">Argument 2 to format.</param>
        /// <param name="arg3">Argument 3 to format.</param>
        /// <param name="arg4">Argument 4 to format.</param>
        /// <param name="arg5">Argument 5 to format.</param>
        /// <param name="arg6">Argument 6 to format.</param>
        /// <param name="arg7">Argument 7 to format.</param>
        /// <param name="arg8">Argument 8 to format.</param>

        [InteropIntrinsic(InteropIntrinsicKind.Write)]
        public static void Write<T1, T2, T3, T4, T5, T6, T7, T8>(
            string format,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
            where T1 : unmanaged where T2 : unmanaged where T3 : unmanaged where T4 : unmanaged where T5 : unmanaged where T6 : unmanaged where T7 : unmanaged where T8 : unmanaged =>
            WriteImplementation(format, arg1.ToString(), arg2.ToString(), arg3.ToString(), arg4.ToString(), arg5.ToString(), arg6.ToString(), arg7.ToString(), arg8.ToString());

        /// <summary>
        /// Writes the given arguments using the format provided.
        /// </summary>
        /// <typeparam name="T1">Parameter type of parameter 1.</typeparam>
        /// <typeparam name="T2">Parameter type of parameter 2.</typeparam>
        /// <typeparam name="T3">Parameter type of parameter 3.</typeparam>
        /// <typeparam name="T4">Parameter type of parameter 4.</typeparam>
        /// <typeparam name="T5">Parameter type of parameter 5.</typeparam>
        /// <typeparam name="T6">Parameter type of parameter 6.</typeparam>
        /// <typeparam name="T7">Parameter type of parameter 7.</typeparam>
        /// <typeparam name="T8">Parameter type of parameter 8.</typeparam>

        /// <param name="format">The format expression.</param>
        /// <param name="arg1">Argument 1 to format.</param>
        /// <param name="arg2">Argument 2 to format.</param>
        /// <param name="arg3">Argument 3 to format.</param>
        /// <param name="arg4">Argument 4 to format.</param>
        /// <param name="arg5">Argument 5 to format.</param>
        /// <param name="arg6">Argument 6 to format.</param>
        /// <param name="arg7">Argument 7 to format.</param>
        /// <param name="arg8">Argument 8 to format.</param>

        [InteropIntrinsic(InteropIntrinsicKind.WriteLine)]
        public static void WriteLine<T1, T2, T3, T4, T5, T6, T7, T8>(
            string format,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
            where T1 : unmanaged where T2 : unmanaged where T3 : unmanaged where T4 : unmanaged where T5 : unmanaged where T6 : unmanaged where T7 : unmanaged where T8 : unmanaged =>
            WriteImplementation(
                GetWriteLineFormat(format),
                arg1.ToString(), arg2.ToString(), arg3.ToString(), arg4.ToString(), arg5.ToString(), arg6.ToString(), arg7.ToString(), arg8.ToString());

        /// <summary>
        /// Writes the given arguments using the format provided.
        /// </summary>
        /// <typeparam name="T1">Parameter type of parameter 1.</typeparam>
        /// <typeparam name="T2">Parameter type of parameter 2.</typeparam>
        /// <typeparam name="T3">Parameter type of parameter 3.</typeparam>
        /// <typeparam name="T4">Parameter type of parameter 4.</typeparam>
        /// <typeparam name="T5">Parameter type of parameter 5.</typeparam>
        /// <typeparam name="T6">Parameter type of parameter 6.</typeparam>
        /// <typeparam name="T7">Parameter type of parameter 7.</typeparam>
        /// <typeparam name="T8">Parameter type of parameter 8.</typeparam>
        /// <typeparam name="T9">Parameter type of parameter 9.</typeparam>

        /// <param name="format">The format expression.</param>
        /// <param name="arg1">Argument 1 to format.</param>
        /// <param name="arg2">Argument 2 to format.</param>
        /// <param name="arg3">Argument 3 to format.</param>
        /// <param name="arg4">Argument 4 to format.</param>
        /// <param name="arg5">Argument 5 to format.</param>
        /// <param name="arg6">Argument 6 to format.</param>
        /// <param name="arg7">Argument 7 to format.</param>
        /// <param name="arg8">Argument 8 to format.</param>
        /// <param name="arg9">Argument 9 to format.</param>

        [InteropIntrinsic(InteropIntrinsicKind.Write)]
        public static void Write<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
            string format,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
            where T1 : unmanaged where T2 : unmanaged where T3 : unmanaged where T4 : unmanaged where T5 : unmanaged where T6 : unmanaged where T7 : unmanaged where T8 : unmanaged where T9 : unmanaged =>
            WriteImplementation(format, arg1.ToString(), arg2.ToString(), arg3.ToString(), arg4.ToString(), arg5.ToString(), arg6.ToString(), arg7.ToString(), arg8.ToString(), arg9.ToString());

        /// <summary>
        /// Writes the given arguments using the format provided.
        /// </summary>
        /// <typeparam name="T1">Parameter type of parameter 1.</typeparam>
        /// <typeparam name="T2">Parameter type of parameter 2.</typeparam>
        /// <typeparam name="T3">Parameter type of parameter 3.</typeparam>
        /// <typeparam name="T4">Parameter type of parameter 4.</typeparam>
        /// <typeparam name="T5">Parameter type of parameter 5.</typeparam>
        /// <typeparam name="T6">Parameter type of parameter 6.</typeparam>
        /// <typeparam name="T7">Parameter type of parameter 7.</typeparam>
        /// <typeparam name="T8">Parameter type of parameter 8.</typeparam>
        /// <typeparam name="T9">Parameter type of parameter 9.</typeparam>

        /// <param name="format">The format expression.</param>
        /// <param name="arg1">Argument 1 to format.</param>
        /// <param name="arg2">Argument 2 to format.</param>
        /// <param name="arg3">Argument 3 to format.</param>
        /// <param name="arg4">Argument 4 to format.</param>
        /// <param name="arg5">Argument 5 to format.</param>
        /// <param name="arg6">Argument 6 to format.</param>
        /// <param name="arg7">Argument 7 to format.</param>
        /// <param name="arg8">Argument 8 to format.</param>
        /// <param name="arg9">Argument 9 to format.</param>

        [InteropIntrinsic(InteropIntrinsicKind.WriteLine)]
        public static void WriteLine<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
            string format,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
            where T1 : unmanaged where T2 : unmanaged where T3 : unmanaged where T4 : unmanaged where T5 : unmanaged where T6 : unmanaged where T7 : unmanaged where T8 : unmanaged where T9 : unmanaged =>
            WriteImplementation(
                GetWriteLineFormat(format),
                arg1.ToString(), arg2.ToString(), arg3.ToString(), arg4.ToString(), arg5.ToString(), arg6.ToString(), arg7.ToString(), arg8.ToString(), arg9.ToString());

        /// <summary>
        /// Writes the given arguments using the format provided.
        /// </summary>
        /// <typeparam name="T1">Parameter type of parameter 1.</typeparam>
        /// <typeparam name="T2">Parameter type of parameter 2.</typeparam>
        /// <typeparam name="T3">Parameter type of parameter 3.</typeparam>
        /// <typeparam name="T4">Parameter type of parameter 4.</typeparam>
        /// <typeparam name="T5">Parameter type of parameter 5.</typeparam>
        /// <typeparam name="T6">Parameter type of parameter 6.</typeparam>
        /// <typeparam name="T7">Parameter type of parameter 7.</typeparam>
        /// <typeparam name="T8">Parameter type of parameter 8.</typeparam>
        /// <typeparam name="T9">Parameter type of parameter 9.</typeparam>
        /// <typeparam name="T10">Parameter type of parameter 10.</typeparam>

        /// <param name="format">The format expression.</param>
        /// <param name="arg1">Argument 1 to format.</param>
        /// <param name="arg2">Argument 2 to format.</param>
        /// <param name="arg3">Argument 3 to format.</param>
        /// <param name="arg4">Argument 4 to format.</param>
        /// <param name="arg5">Argument 5 to format.</param>
        /// <param name="arg6">Argument 6 to format.</param>
        /// <param name="arg7">Argument 7 to format.</param>
        /// <param name="arg8">Argument 8 to format.</param>
        /// <param name="arg9">Argument 9 to format.</param>
        /// <param name="arg10">Argument 10 to format.</param>

        [InteropIntrinsic(InteropIntrinsicKind.Write)]
        public static void Write<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
            string format,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
            where T1 : unmanaged where T2 : unmanaged where T3 : unmanaged where T4 : unmanaged where T5 : unmanaged where T6 : unmanaged where T7 : unmanaged where T8 : unmanaged where T9 : unmanaged where T10 : unmanaged =>
            WriteImplementation(format, arg1.ToString(), arg2.ToString(), arg3.ToString(), arg4.ToString(), arg5.ToString(), arg6.ToString(), arg7.ToString(), arg8.ToString(), arg9.ToString(), arg10.ToString());

        /// <summary>
        /// Writes the given arguments using the format provided.
        /// </summary>
        /// <typeparam name="T1">Parameter type of parameter 1.</typeparam>
        /// <typeparam name="T2">Parameter type of parameter 2.</typeparam>
        /// <typeparam name="T3">Parameter type of parameter 3.</typeparam>
        /// <typeparam name="T4">Parameter type of parameter 4.</typeparam>
        /// <typeparam name="T5">Parameter type of parameter 5.</typeparam>
        /// <typeparam name="T6">Parameter type of parameter 6.</typeparam>
        /// <typeparam name="T7">Parameter type of parameter 7.</typeparam>
        /// <typeparam name="T8">Parameter type of parameter 8.</typeparam>
        /// <typeparam name="T9">Parameter type of parameter 9.</typeparam>
        /// <typeparam name="T10">Parameter type of parameter 10.</typeparam>

        /// <param name="format">The format expression.</param>
        /// <param name="arg1">Argument 1 to format.</param>
        /// <param name="arg2">Argument 2 to format.</param>
        /// <param name="arg3">Argument 3 to format.</param>
        /// <param name="arg4">Argument 4 to format.</param>
        /// <param name="arg5">Argument 5 to format.</param>
        /// <param name="arg6">Argument 6 to format.</param>
        /// <param name="arg7">Argument 7 to format.</param>
        /// <param name="arg8">Argument 8 to format.</param>
        /// <param name="arg9">Argument 9 to format.</param>
        /// <param name="arg10">Argument 10 to format.</param>

        [InteropIntrinsic(InteropIntrinsicKind.WriteLine)]
        public static void WriteLine<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
            string format,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
            where T1 : unmanaged where T2 : unmanaged where T3 : unmanaged where T4 : unmanaged where T5 : unmanaged where T6 : unmanaged where T7 : unmanaged where T8 : unmanaged where T9 : unmanaged where T10 : unmanaged =>
            WriteImplementation(
                GetWriteLineFormat(format),
                arg1.ToString(), arg2.ToString(), arg3.ToString(), arg4.ToString(), arg5.ToString(), arg6.ToString(), arg7.ToString(), arg8.ToString(), arg9.ToString(), arg10.ToString());

        /// <summary>
        /// Writes the given arguments using the format provided.
        /// </summary>
        /// <typeparam name="T1">Parameter type of parameter 1.</typeparam>
        /// <typeparam name="T2">Parameter type of parameter 2.</typeparam>
        /// <typeparam name="T3">Parameter type of parameter 3.</typeparam>
        /// <typeparam name="T4">Parameter type of parameter 4.</typeparam>
        /// <typeparam name="T5">Parameter type of parameter 5.</typeparam>
        /// <typeparam name="T6">Parameter type of parameter 6.</typeparam>
        /// <typeparam name="T7">Parameter type of parameter 7.</typeparam>
        /// <typeparam name="T8">Parameter type of parameter 8.</typeparam>
        /// <typeparam name="T9">Parameter type of parameter 9.</typeparam>
        /// <typeparam name="T10">Parameter type of parameter 10.</typeparam>
        /// <typeparam name="T11">Parameter type of parameter 11.</typeparam>

        /// <param name="format">The format expression.</param>
        /// <param name="arg1">Argument 1 to format.</param>
        /// <param name="arg2">Argument 2 to format.</param>
        /// <param name="arg3">Argument 3 to format.</param>
        /// <param name="arg4">Argument 4 to format.</param>
        /// <param name="arg5">Argument 5 to format.</param>
        /// <param name="arg6">Argument 6 to format.</param>
        /// <param name="arg7">Argument 7 to format.</param>
        /// <param name="arg8">Argument 8 to format.</param>
        /// <param name="arg9">Argument 9 to format.</param>
        /// <param name="arg10">Argument 10 to format.</param>
        /// <param name="arg11">Argument 11 to format.</param>

        [InteropIntrinsic(InteropIntrinsicKind.Write)]
        public static void Write<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
            string format,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
            where T1 : unmanaged where T2 : unmanaged where T3 : unmanaged where T4 : unmanaged where T5 : unmanaged where T6 : unmanaged where T7 : unmanaged where T8 : unmanaged where T9 : unmanaged where T10 : unmanaged where T11 : unmanaged =>
            WriteImplementation(format, arg1.ToString(), arg2.ToString(), arg3.ToString(), arg4.ToString(), arg5.ToString(), arg6.ToString(), arg7.ToString(), arg8.ToString(), arg9.ToString(), arg10.ToString(), arg11.ToString());

        /// <summary>
        /// Writes the given arguments using the format provided.
        /// </summary>
        /// <typeparam name="T1">Parameter type of parameter 1.</typeparam>
        /// <typeparam name="T2">Parameter type of parameter 2.</typeparam>
        /// <typeparam name="T3">Parameter type of parameter 3.</typeparam>
        /// <typeparam name="T4">Parameter type of parameter 4.</typeparam>
        /// <typeparam name="T5">Parameter type of parameter 5.</typeparam>
        /// <typeparam name="T6">Parameter type of parameter 6.</typeparam>
        /// <typeparam name="T7">Parameter type of parameter 7.</typeparam>
        /// <typeparam name="T8">Parameter type of parameter 8.</typeparam>
        /// <typeparam name="T9">Parameter type of parameter 9.</typeparam>
        /// <typeparam name="T10">Parameter type of parameter 10.</typeparam>
        /// <typeparam name="T11">Parameter type of parameter 11.</typeparam>

        /// <param name="format">The format expression.</param>
        /// <param name="arg1">Argument 1 to format.</param>
        /// <param name="arg2">Argument 2 to format.</param>
        /// <param name="arg3">Argument 3 to format.</param>
        /// <param name="arg4">Argument 4 to format.</param>
        /// <param name="arg5">Argument 5 to format.</param>
        /// <param name="arg6">Argument 6 to format.</param>
        /// <param name="arg7">Argument 7 to format.</param>
        /// <param name="arg8">Argument 8 to format.</param>
        /// <param name="arg9">Argument 9 to format.</param>
        /// <param name="arg10">Argument 10 to format.</param>
        /// <param name="arg11">Argument 11 to format.</param>

        [InteropIntrinsic(InteropIntrinsicKind.WriteLine)]
        public static void WriteLine<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
            string format,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
            where T1 : unmanaged where T2 : unmanaged where T3 : unmanaged where T4 : unmanaged where T5 : unmanaged where T6 : unmanaged where T7 : unmanaged where T8 : unmanaged where T9 : unmanaged where T10 : unmanaged where T11 : unmanaged =>
            WriteImplementation(
                GetWriteLineFormat(format),
                arg1.ToString(), arg2.ToString(), arg3.ToString(), arg4.ToString(), arg5.ToString(), arg6.ToString(), arg7.ToString(), arg8.ToString(), arg9.ToString(), arg10.ToString(), arg11.ToString());

        /// <summary>
        /// Writes the given arguments using the format provided.
        /// </summary>
        /// <typeparam name="T1">Parameter type of parameter 1.</typeparam>
        /// <typeparam name="T2">Parameter type of parameter 2.</typeparam>
        /// <typeparam name="T3">Parameter type of parameter 3.</typeparam>
        /// <typeparam name="T4">Parameter type of parameter 4.</typeparam>
        /// <typeparam name="T5">Parameter type of parameter 5.</typeparam>
        /// <typeparam name="T6">Parameter type of parameter 6.</typeparam>
        /// <typeparam name="T7">Parameter type of parameter 7.</typeparam>
        /// <typeparam name="T8">Parameter type of parameter 8.</typeparam>
        /// <typeparam name="T9">Parameter type of parameter 9.</typeparam>
        /// <typeparam name="T10">Parameter type of parameter 10.</typeparam>
        /// <typeparam name="T11">Parameter type of parameter 11.</typeparam>
        /// <typeparam name="T12">Parameter type of parameter 12.</typeparam>

        /// <param name="format">The format expression.</param>
        /// <param name="arg1">Argument 1 to format.</param>
        /// <param name="arg2">Argument 2 to format.</param>
        /// <param name="arg3">Argument 3 to format.</param>
        /// <param name="arg4">Argument 4 to format.</param>
        /// <param name="arg5">Argument 5 to format.</param>
        /// <param name="arg6">Argument 6 to format.</param>
        /// <param name="arg7">Argument 7 to format.</param>
        /// <param name="arg8">Argument 8 to format.</param>
        /// <param name="arg9">Argument 9 to format.</param>
        /// <param name="arg10">Argument 10 to format.</param>
        /// <param name="arg11">Argument 11 to format.</param>
        /// <param name="arg12">Argument 12 to format.</param>

        [InteropIntrinsic(InteropIntrinsicKind.Write)]
        public static void Write<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
            string format,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
            where T1 : unmanaged where T2 : unmanaged where T3 : unmanaged where T4 : unmanaged where T5 : unmanaged where T6 : unmanaged where T7 : unmanaged where T8 : unmanaged where T9 : unmanaged where T10 : unmanaged where T11 : unmanaged where T12 : unmanaged =>
            WriteImplementation(format, arg1.ToString(), arg2.ToString(), arg3.ToString(), arg4.ToString(), arg5.ToString(), arg6.ToString(), arg7.ToString(), arg8.ToString(), arg9.ToString(), arg10.ToString(), arg11.ToString(), arg12.ToString());

        /// <summary>
        /// Writes the given arguments using the format provided.
        /// </summary>
        /// <typeparam name="T1">Parameter type of parameter 1.</typeparam>
        /// <typeparam name="T2">Parameter type of parameter 2.</typeparam>
        /// <typeparam name="T3">Parameter type of parameter 3.</typeparam>
        /// <typeparam name="T4">Parameter type of parameter 4.</typeparam>
        /// <typeparam name="T5">Parameter type of parameter 5.</typeparam>
        /// <typeparam name="T6">Parameter type of parameter 6.</typeparam>
        /// <typeparam name="T7">Parameter type of parameter 7.</typeparam>
        /// <typeparam name="T8">Parameter type of parameter 8.</typeparam>
        /// <typeparam name="T9">Parameter type of parameter 9.</typeparam>
        /// <typeparam name="T10">Parameter type of parameter 10.</typeparam>
        /// <typeparam name="T11">Parameter type of parameter 11.</typeparam>
        /// <typeparam name="T12">Parameter type of parameter 12.</typeparam>

        /// <param name="format">The format expression.</param>
        /// <param name="arg1">Argument 1 to format.</param>
        /// <param name="arg2">Argument 2 to format.</param>
        /// <param name="arg3">Argument 3 to format.</param>
        /// <param name="arg4">Argument 4 to format.</param>
        /// <param name="arg5">Argument 5 to format.</param>
        /// <param name="arg6">Argument 6 to format.</param>
        /// <param name="arg7">Argument 7 to format.</param>
        /// <param name="arg8">Argument 8 to format.</param>
        /// <param name="arg9">Argument 9 to format.</param>
        /// <param name="arg10">Argument 10 to format.</param>
        /// <param name="arg11">Argument 11 to format.</param>
        /// <param name="arg12">Argument 12 to format.</param>

        [InteropIntrinsic(InteropIntrinsicKind.WriteLine)]
        public static void WriteLine<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
            string format,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
            where T1 : unmanaged where T2 : unmanaged where T3 : unmanaged where T4 : unmanaged where T5 : unmanaged where T6 : unmanaged where T7 : unmanaged where T8 : unmanaged where T9 : unmanaged where T10 : unmanaged where T11 : unmanaged where T12 : unmanaged =>
            WriteImplementation(
                GetWriteLineFormat(format),
                arg1.ToString(), arg2.ToString(), arg3.ToString(), arg4.ToString(), arg5.ToString(), arg6.ToString(), arg7.ToString(), arg8.ToString(), arg9.ToString(), arg10.ToString(), arg11.ToString(), arg12.ToString());

        /// <summary>
        /// Writes the given arguments using the format provided.
        /// </summary>
        /// <typeparam name="T1">Parameter type of parameter 1.</typeparam>
        /// <typeparam name="T2">Parameter type of parameter 2.</typeparam>
        /// <typeparam name="T3">Parameter type of parameter 3.</typeparam>
        /// <typeparam name="T4">Parameter type of parameter 4.</typeparam>
        /// <typeparam name="T5">Parameter type of parameter 5.</typeparam>
        /// <typeparam name="T6">Parameter type of parameter 6.</typeparam>
        /// <typeparam name="T7">Parameter type of parameter 7.</typeparam>
        /// <typeparam name="T8">Parameter type of parameter 8.</typeparam>
        /// <typeparam name="T9">Parameter type of parameter 9.</typeparam>
        /// <typeparam name="T10">Parameter type of parameter 10.</typeparam>
        /// <typeparam name="T11">Parameter type of parameter 11.</typeparam>
        /// <typeparam name="T12">Parameter type of parameter 12.</typeparam>
        /// <typeparam name="T13">Parameter type of parameter 13.</typeparam>

        /// <param name="format">The format expression.</param>
        /// <param name="arg1">Argument 1 to format.</param>
        /// <param name="arg2">Argument 2 to format.</param>
        /// <param name="arg3">Argument 3 to format.</param>
        /// <param name="arg4">Argument 4 to format.</param>
        /// <param name="arg5">Argument 5 to format.</param>
        /// <param name="arg6">Argument 6 to format.</param>
        /// <param name="arg7">Argument 7 to format.</param>
        /// <param name="arg8">Argument 8 to format.</param>
        /// <param name="arg9">Argument 9 to format.</param>
        /// <param name="arg10">Argument 10 to format.</param>
        /// <param name="arg11">Argument 11 to format.</param>
        /// <param name="arg12">Argument 12 to format.</param>
        /// <param name="arg13">Argument 13 to format.</param>

        [InteropIntrinsic(InteropIntrinsicKind.Write)]
        public static void Write<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
            string format,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
            where T1 : unmanaged where T2 : unmanaged where T3 : unmanaged where T4 : unmanaged where T5 : unmanaged where T6 : unmanaged where T7 : unmanaged where T8 : unmanaged where T9 : unmanaged where T10 : unmanaged where T11 : unmanaged where T12 : unmanaged where T13 : unmanaged =>
            WriteImplementation(format, arg1.ToString(), arg2.ToString(), arg3.ToString(), arg4.ToString(), arg5.ToString(), arg6.ToString(), arg7.ToString(), arg8.ToString(), arg9.ToString(), arg10.ToString(), arg11.ToString(), arg12.ToString(), arg13.ToString());

        /// <summary>
        /// Writes the given arguments using the format provided.
        /// </summary>
        /// <typeparam name="T1">Parameter type of parameter 1.</typeparam>
        /// <typeparam name="T2">Parameter type of parameter 2.</typeparam>
        /// <typeparam name="T3">Parameter type of parameter 3.</typeparam>
        /// <typeparam name="T4">Parameter type of parameter 4.</typeparam>
        /// <typeparam name="T5">Parameter type of parameter 5.</typeparam>
        /// <typeparam name="T6">Parameter type of parameter 6.</typeparam>
        /// <typeparam name="T7">Parameter type of parameter 7.</typeparam>
        /// <typeparam name="T8">Parameter type of parameter 8.</typeparam>
        /// <typeparam name="T9">Parameter type of parameter 9.</typeparam>
        /// <typeparam name="T10">Parameter type of parameter 10.</typeparam>
        /// <typeparam name="T11">Parameter type of parameter 11.</typeparam>
        /// <typeparam name="T12">Parameter type of parameter 12.</typeparam>
        /// <typeparam name="T13">Parameter type of parameter 13.</typeparam>

        /// <param name="format">The format expression.</param>
        /// <param name="arg1">Argument 1 to format.</param>
        /// <param name="arg2">Argument 2 to format.</param>
        /// <param name="arg3">Argument 3 to format.</param>
        /// <param name="arg4">Argument 4 to format.</param>
        /// <param name="arg5">Argument 5 to format.</param>
        /// <param name="arg6">Argument 6 to format.</param>
        /// <param name="arg7">Argument 7 to format.</param>
        /// <param name="arg8">Argument 8 to format.</param>
        /// <param name="arg9">Argument 9 to format.</param>
        /// <param name="arg10">Argument 10 to format.</param>
        /// <param name="arg11">Argument 11 to format.</param>
        /// <param name="arg12">Argument 12 to format.</param>
        /// <param name="arg13">Argument 13 to format.</param>

        [InteropIntrinsic(InteropIntrinsicKind.WriteLine)]
        public static void WriteLine<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
            string format,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
            where T1 : unmanaged where T2 : unmanaged where T3 : unmanaged where T4 : unmanaged where T5 : unmanaged where T6 : unmanaged where T7 : unmanaged where T8 : unmanaged where T9 : unmanaged where T10 : unmanaged where T11 : unmanaged where T12 : unmanaged where T13 : unmanaged =>
            WriteImplementation(
                GetWriteLineFormat(format),
                arg1.ToString(), arg2.ToString(), arg3.ToString(), arg4.ToString(), arg5.ToString(), arg6.ToString(), arg7.ToString(), arg8.ToString(), arg9.ToString(), arg10.ToString(), arg11.ToString(), arg12.ToString(), arg13.ToString());

        /// <summary>
        /// Writes the given arguments using the format provided.
        /// </summary>
        /// <typeparam name="T1">Parameter type of parameter 1.</typeparam>
        /// <typeparam name="T2">Parameter type of parameter 2.</typeparam>
        /// <typeparam name="T3">Parameter type of parameter 3.</typeparam>
        /// <typeparam name="T4">Parameter type of parameter 4.</typeparam>
        /// <typeparam name="T5">Parameter type of parameter 5.</typeparam>
        /// <typeparam name="T6">Parameter type of parameter 6.</typeparam>
        /// <typeparam name="T7">Parameter type of parameter 7.</typeparam>
        /// <typeparam name="T8">Parameter type of parameter 8.</typeparam>
        /// <typeparam name="T9">Parameter type of parameter 9.</typeparam>
        /// <typeparam name="T10">Parameter type of parameter 10.</typeparam>
        /// <typeparam name="T11">Parameter type of parameter 11.</typeparam>
        /// <typeparam name="T12">Parameter type of parameter 12.</typeparam>
        /// <typeparam name="T13">Parameter type of parameter 13.</typeparam>
        /// <typeparam name="T14">Parameter type of parameter 14.</typeparam>

        /// <param name="format">The format expression.</param>
        /// <param name="arg1">Argument 1 to format.</param>
        /// <param name="arg2">Argument 2 to format.</param>
        /// <param name="arg3">Argument 3 to format.</param>
        /// <param name="arg4">Argument 4 to format.</param>
        /// <param name="arg5">Argument 5 to format.</param>
        /// <param name="arg6">Argument 6 to format.</param>
        /// <param name="arg7">Argument 7 to format.</param>
        /// <param name="arg8">Argument 8 to format.</param>
        /// <param name="arg9">Argument 9 to format.</param>
        /// <param name="arg10">Argument 10 to format.</param>
        /// <param name="arg11">Argument 11 to format.</param>
        /// <param name="arg12">Argument 12 to format.</param>
        /// <param name="arg13">Argument 13 to format.</param>
        /// <param name="arg14">Argument 14 to format.</param>

        [InteropIntrinsic(InteropIntrinsicKind.Write)]
        public static void Write<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
            string format,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
            where T1 : unmanaged where T2 : unmanaged where T3 : unmanaged where T4 : unmanaged where T5 : unmanaged where T6 : unmanaged where T7 : unmanaged where T8 : unmanaged where T9 : unmanaged where T10 : unmanaged where T11 : unmanaged where T12 : unmanaged where T13 : unmanaged where T14 : unmanaged =>
            WriteImplementation(format, arg1.ToString(), arg2.ToString(), arg3.ToString(), arg4.ToString(), arg5.ToString(), arg6.ToString(), arg7.ToString(), arg8.ToString(), arg9.ToString(), arg10.ToString(), arg11.ToString(), arg12.ToString(), arg13.ToString(), arg14.ToString());

        /// <summary>
        /// Writes the given arguments using the format provided.
        /// </summary>
        /// <typeparam name="T1">Parameter type of parameter 1.</typeparam>
        /// <typeparam name="T2">Parameter type of parameter 2.</typeparam>
        /// <typeparam name="T3">Parameter type of parameter 3.</typeparam>
        /// <typeparam name="T4">Parameter type of parameter 4.</typeparam>
        /// <typeparam name="T5">Parameter type of parameter 5.</typeparam>
        /// <typeparam name="T6">Parameter type of parameter 6.</typeparam>
        /// <typeparam name="T7">Parameter type of parameter 7.</typeparam>
        /// <typeparam name="T8">Parameter type of parameter 8.</typeparam>
        /// <typeparam name="T9">Parameter type of parameter 9.</typeparam>
        /// <typeparam name="T10">Parameter type of parameter 10.</typeparam>
        /// <typeparam name="T11">Parameter type of parameter 11.</typeparam>
        /// <typeparam name="T12">Parameter type of parameter 12.</typeparam>
        /// <typeparam name="T13">Parameter type of parameter 13.</typeparam>
        /// <typeparam name="T14">Parameter type of parameter 14.</typeparam>

        /// <param name="format">The format expression.</param>
        /// <param name="arg1">Argument 1 to format.</param>
        /// <param name="arg2">Argument 2 to format.</param>
        /// <param name="arg3">Argument 3 to format.</param>
        /// <param name="arg4">Argument 4 to format.</param>
        /// <param name="arg5">Argument 5 to format.</param>
        /// <param name="arg6">Argument 6 to format.</param>
        /// <param name="arg7">Argument 7 to format.</param>
        /// <param name="arg8">Argument 8 to format.</param>
        /// <param name="arg9">Argument 9 to format.</param>
        /// <param name="arg10">Argument 10 to format.</param>
        /// <param name="arg11">Argument 11 to format.</param>
        /// <param name="arg12">Argument 12 to format.</param>
        /// <param name="arg13">Argument 13 to format.</param>
        /// <param name="arg14">Argument 14 to format.</param>

        [InteropIntrinsic(InteropIntrinsicKind.WriteLine)]
        public static void WriteLine<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
            string format,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
            where T1 : unmanaged where T2 : unmanaged where T3 : unmanaged where T4 : unmanaged where T5 : unmanaged where T6 : unmanaged where T7 : unmanaged where T8 : unmanaged where T9 : unmanaged where T10 : unmanaged where T11 : unmanaged where T12 : unmanaged where T13 : unmanaged where T14 : unmanaged =>
            WriteImplementation(
                GetWriteLineFormat(format),
                arg1.ToString(), arg2.ToString(), arg3.ToString(), arg4.ToString(), arg5.ToString(), arg6.ToString(), arg7.ToString(), arg8.ToString(), arg9.ToString(), arg10.ToString(), arg11.ToString(), arg12.ToString(), arg13.ToString(), arg14.ToString());

    }
}