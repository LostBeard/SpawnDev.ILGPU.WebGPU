// ---------------------------------------------------------------------------------------
//                                   ILGPU Algorithms
//                        Copyright (c) 2019-2023 ILGPU Project
//                                    www.ilgpu.net
//
// File: AlgorithmContextMappings.tt/AlgorithmContextMappings.cs
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


using ILGPU.Frontend.Intrinsic;

namespace ILGPU
{
    partial class AlgorithmContext
    {
        /// <summary>
        /// Registers all math remappings for faster code generation.
        /// </summary>
        private static void RegisterMathRemappings()
        {
            var systemMathType = typeof(System.Math);
            var systemMathFType = typeof(System.MathF);

            // Register math remappings
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.MathType,
                "Abs",
                typeof(System.SByte));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.MathType,
                "Abs",
                typeof(System.Byte));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.MathType,
                "Abs",
                typeof(System.Int16));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.MathType,
                "Abs",
                typeof(System.UInt16));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.MathType,
                "Abs",
                typeof(System.Int32));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.MathType,
                "Abs",
                typeof(System.UInt32));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.MathType,
                "Abs",
                typeof(System.Int64));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.MathType,
                "Abs",
                typeof(System.UInt64));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.MathType,
                "Abs",
                typeof(System.Single));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.MathType,
                "Abs",
                typeof(System.Double));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.MathType,
                "Decompose",
                typeof(System.Int64));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.MathType,
                "Decompose",
                typeof(System.UInt64));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.MathType,
                "Min",
                typeof(System.SByte), typeof(System.SByte));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.MathType,
                "Min",
                typeof(System.Byte), typeof(System.Byte));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.MathType,
                "Min",
                typeof(System.Int16), typeof(System.Int16));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.MathType,
                "Min",
                typeof(System.UInt16), typeof(System.UInt16));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.MathType,
                "Min",
                typeof(System.Int32), typeof(System.Int32));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.MathType,
                "Min",
                typeof(System.UInt32), typeof(System.UInt32));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.MathType,
                "Min",
                typeof(System.Int64), typeof(System.Int64));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.MathType,
                "Min",
                typeof(System.UInt64), typeof(System.UInt64));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.MathType,
                "Min",
                typeof(System.Single), typeof(System.Single));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.MathType,
                "Min",
                typeof(System.Double), typeof(System.Double));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.MathType,
                "Max",
                typeof(System.SByte), typeof(System.SByte));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.MathType,
                "Max",
                typeof(System.Byte), typeof(System.Byte));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.MathType,
                "Max",
                typeof(System.Int16), typeof(System.Int16));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.MathType,
                "Max",
                typeof(System.UInt16), typeof(System.UInt16));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.MathType,
                "Max",
                typeof(System.Int32), typeof(System.Int32));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.MathType,
                "Max",
                typeof(System.UInt32), typeof(System.UInt32));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.MathType,
                "Max",
                typeof(System.Int64), typeof(System.Int64));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.MathType,
                "Max",
                typeof(System.UInt64), typeof(System.UInt64));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.MathType,
                "Max",
                typeof(System.Single), typeof(System.Single));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.MathType,
                "Max",
                typeof(System.Double), typeof(System.Double));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.MathType,
                "Clamp",
                typeof(System.SByte), typeof(System.SByte), typeof(System.SByte));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.MathType,
                "Clamp",
                typeof(System.Byte), typeof(System.Byte), typeof(System.Byte));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.MathType,
                "Clamp",
                typeof(System.Int16), typeof(System.Int16), typeof(System.Int16));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.MathType,
                "Clamp",
                typeof(System.UInt16), typeof(System.UInt16), typeof(System.UInt16));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.MathType,
                "Clamp",
                typeof(System.Int32), typeof(System.Int32), typeof(System.Int32));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.MathType,
                "Clamp",
                typeof(System.UInt32), typeof(System.UInt32), typeof(System.UInt32));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.MathType,
                "Clamp",
                typeof(System.Int64), typeof(System.Int64), typeof(System.Int64));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.MathType,
                "Clamp",
                typeof(System.UInt64), typeof(System.UInt64), typeof(System.UInt64));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.MathType,
                "Clamp",
                typeof(System.Single), typeof(System.Single), typeof(System.Single));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.MathType,
                "Clamp",
                typeof(System.Double), typeof(System.Double), typeof(System.Double));

            // Register CPU-math remappings
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.CPUMathType,
                "Floor",
                typeof(System.Single));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.CPUMathType,
                "Floor",
                typeof(System.Double));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.CPUMathType,
                "Ceiling",
                typeof(System.Single));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.CPUMathType,
                "Ceiling",
                typeof(System.Double));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.CPUMathType,
                "Log",
                typeof(System.Single));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.CPUMathType,
                "Log",
                typeof(System.Double));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.CPUMathType,
                "Log10",
                typeof(System.Single));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.CPUMathType,
                "Log10",
                typeof(System.Double));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.CPUMathType,
                "Log2",
                typeof(System.Single));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.CPUMathType,
                "Log2",
                typeof(System.Double));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.CPUMathType,
                "IsInfinity",
                typeof(System.Single));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.CPUMathType,
                "IsInfinity",
                typeof(System.Double));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.CPUMathType,
                "IsNaN",
                typeof(System.Single));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.CPUMathType,
                "IsNaN",
                typeof(System.Double));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.CPUMathType,
                "Exp",
                typeof(System.Single));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.CPUMathType,
                "Exp",
                typeof(System.Double));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.CPUMathType,
                "Exp2",
                typeof(System.Single));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.CPUMathType,
                "Exp2",
                typeof(System.Double));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.CPUMathType,
                "Rcp",
                typeof(System.Single));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.CPUMathType,
                "Rcp",
                typeof(System.Double));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.CPUMathType,
                "Sqrt",
                typeof(System.Single));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.CPUMathType,
                "Sqrt",
                typeof(System.Double));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.CPUMathType,
                "Rsqrt",
                typeof(System.Single));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.CPUMathType,
                "Rsqrt",
                typeof(System.Double));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.CPUMathType,
                "Sin",
                typeof(System.Single));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.CPUMathType,
                "Sin",
                typeof(System.Double));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.CPUMathType,
                "Asin",
                typeof(System.Single));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.CPUMathType,
                "Asin",
                typeof(System.Double));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.CPUMathType,
                "Sinh",
                typeof(System.Single));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.CPUMathType,
                "Sinh",
                typeof(System.Double));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.CPUMathType,
                "Cos",
                typeof(System.Single));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.CPUMathType,
                "Cos",
                typeof(System.Double));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.CPUMathType,
                "Acos",
                typeof(System.Single));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.CPUMathType,
                "Acos",
                typeof(System.Double));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.CPUMathType,
                "Cosh",
                typeof(System.Single));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.CPUMathType,
                "Cosh",
                typeof(System.Double));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.CPUMathType,
                "Tan",
                typeof(System.Single));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.CPUMathType,
                "Tan",
                typeof(System.Double));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.CPUMathType,
                "Atan",
                typeof(System.Single));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.CPUMathType,
                "Atan",
                typeof(System.Double));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.CPUMathType,
                "Tanh",
                typeof(System.Single));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.CPUMathType,
                "Tanh",
                typeof(System.Double));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.CPUMathType,
                "Rem",
                typeof(System.Single), typeof(System.Single));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.CPUMathType,
                "Rem",
                typeof(System.Double), typeof(System.Double));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.CPUMathType,
                "Pow",
                typeof(System.Single), typeof(System.Single));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.CPUMathType,
                "Pow",
                typeof(System.Double), typeof(System.Double));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.CPUMathType,
                "Atan2",
                typeof(System.Single), typeof(System.Single));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.CPUMathType,
                "Atan2",
                typeof(System.Double), typeof(System.Double));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.CPUMathType,
                "Log",
                typeof(System.Single), typeof(System.Single));
            RemappedIntrinsics.AddRemapping(
                XMathType,
                RemappedIntrinsics.CPUMathType,
                "Log",
                typeof(System.Double), typeof(System.Double));

            // Register System.Math Round/Truncate remappings
            RemappedIntrinsics.AddRemapping(
                systemMathFType,
                XMathType,
                "Round",
                typeof(float));
            RemappedIntrinsics.AddRemapping(
                systemMathFType,
                XMathType,
                "Round",
                typeof(float), typeof(int));
            RemappedIntrinsics.AddRemapping(
                systemMathFType,
                XMathType,
                "Round",
                typeof(float), typeof(System.MidpointRounding));
            RemappedIntrinsics.AddRemapping(
                systemMathFType,
                XMathType,
                "Round",
                typeof(float),
                typeof(int),
                typeof(System.MidpointRounding));
            RemappedIntrinsics.AddRemapping(
                systemMathFType,
                XMathType,
                "Truncate",
                typeof(float));
            RemappedIntrinsics.AddRemapping(
                systemMathType,
                XMathType,
                "Round",
                typeof(double));
            RemappedIntrinsics.AddRemapping(
                systemMathType,
                XMathType,
                "Round",
                typeof(double), typeof(int));
            RemappedIntrinsics.AddRemapping(
                systemMathType,
                XMathType,
                "Round",
                typeof(double), typeof(System.MidpointRounding));
            RemappedIntrinsics.AddRemapping(
                systemMathType,
                XMathType,
                "Round",
                typeof(double),
                typeof(int),
                typeof(System.MidpointRounding));
            RemappedIntrinsics.AddRemapping(
                systemMathType,
                XMathType,
                "Truncate",
                typeof(double));

        }
    }
}