// ---------------------------------------------------------------------------------------
//                                   ILGPU Algorithms
//                        Copyright (c) 2020-2021 ILGPU Project
//                                    www.ilgpu.net
//
// File: Cordic.Trig.tt/Cordic.Trig.cs
//
// This file is part of ILGPU and is distributed under the University of Illinois Open
// Source License. See LICENSE.txt for details.
// ---------------------------------------------------------------------------------------

// ---------------------------------------------------------------------------------------
//                                   ILGPU Algorithms
//                        Copyright (c) 2020-2021 ILGPU Project
//                                    www.ilgpu.net
//
// File: Cordic.ttinclude
//
// This file is part of ILGPU and is distributed under the University of Illinois Open
// Source License. See LICENSE.txt for details.
// ---------------------------------------------------------------------------------------

// disable: max_line_length

namespace ILGPU.Algorithms
{
    partial class XMath
    {
        /// <summary>
        /// Implementation of trigonometric transcendental functions using CORDIC approximation.
        /// </summary>
        partial class Cordic
        {
            #region Trigonometric

            /// <summary>
            /// Implementation of sine approximation using CORDIC.
            /// </summary>
            /// <param name="radians">The angle in radians</param>
            /// <returns>The sine value</returns>
            public static float Sin(float radians)
            {
                SinCos(radians, out var sin, out _);
                return sin;
            }

            /// <summary>
            /// Implementation of sine approximation using CORDIC.
            /// </summary>
            /// <param name="radians">The angle in radians</param>
            /// <returns>The sine value</returns>
            public static double Sin(double radians)
            {
                SinCos(radians, out var sin, out _);
                return sin;
            }

            /// <summary>
            /// Implementation of cosine approximation using CORDIC.
            /// </summary>
            /// <param name="radians">The angle in radians</param>
            /// <returns>The cosine value</returns>
            public static float Cos(float radians)
            {
                SinCos(radians, out _, out var cos);
                return cos;
            }

            /// <summary>
            /// Implementation of cosine approximation using CORDIC.
            /// </summary>
            /// <param name="radians">The angle in radians</param>
            /// <returns>The cosine value</returns>
            public static double Cos(double radians)
            {
                SinCos(radians, out _, out var cos);
                return cos;
            }

            /// <summary>
            /// Implementation of sine/cosine approximation using CORDIC.
            /// </summary>
            /// <param name="radians">The angle in radians</param>
            /// <param name="sin">The sine result</param>
            /// <param name="cos">The cosine result</param>
            public static void SinCos(float radians, out float sin, out float cos)
            {
                // Deal with edge cases
                if (IsNaN(radians) || IsInfinity(radians))
                {
                    sin = float.NaN;
                    cos = float.NaN;
                    return;
                }

                // Ensure that the radians are between [-PI, PI]
                radians = RangeLimit(radians);

                // Limit radians within the range [-PI/2, PI/2].
                // Adjust the sign for second or third quadrant.
                float sign;

                if (radians < -PIHalf)
                {
                    radians += PI;
                    sign = -1.0f;
                }
                else if (radians > PIHalf)
                {
                    radians -= PI;
                    sign = -1.0f;
                }
                else
                    sign = 1.0f;

                // Apply 24 iterations.
                RotateIterations(radians, out var currCos, out var currSin);

                // Adjust length of output vector
                sin = currSin * Gain * sign;
                cos = currCos * Gain * sign;
            }

            /// <summary>
            /// Implementation of sine/cosine approximation using CORDIC.
            /// </summary>
            /// <param name="radians">The angle in radians</param>
            /// <param name="sin">The sine result</param>
            /// <param name="cos">The cosine result</param>
            public static void SinCos(double radians, out double sin, out double cos)
            {
                // Deal with edge cases
                if (IsNaN(radians) || IsInfinity(radians))
                {
                    sin = double.NaN;
                    cos = double.NaN;
                    return;
                }

                // Ensure that the radians are between [-PI, PI]
                radians = RangeLimit(radians);

                // Limit radians within the range [-PI/2, PI/2].
                // Adjust the sign for second or third quadrant.
                double sign;

                if (radians < -PIHalfD)
                {
                    radians += PID;
                    sign = -1.0;
                }
                else if (radians > PIHalfD)
                {
                    radians -= PID;
                    sign = -1.0;
                }
                else
                    sign = 1.0;

                // Apply 53 iterations.
                RotateIterations(radians, out var currCos, out var currSin);

                // Adjust length of output vector
                sin = currSin * GainD * sign;
                cos = currCos * GainD * sign;
            }

            /// <summary>
            /// Implementation of tangent approximation using CORDIC.
            /// </summary>
            /// <param name="radians">The angle in radians</param>
            /// <returns>The tangent value</returns>
            public static float Tan(float radians)
            {
                // NB: This is the same algorithms as SinCos, but without adjustment for
                // second or third quadrant, and without correcting for the "gain" from
                // rotations - both are redudant multiplications for our calculation.

                // Deal with edge cases
                if (IsNaN(radians) || IsInfinity(radians))
                    return float.NaN;

                // Ensure that the radians are between [-PI, PI]
                radians = RangeLimit(radians);

                // Limit radians within the range [-PI/2, PI/2].
                if (radians < -PIHalf)
                    radians += PI;
                else if (radians > PIHalf)
                    radians -= PI;

                // Apply 24 iterations.
                RotateIterations(radians, out var currCos, out var currSin);

                return currSin / currCos;
            }

            /// <summary>
            /// Implementation of tangent approximation using CORDIC.
            /// </summary>
            /// <param name="radians">The angle in radians</param>
            /// <returns>The tangent value</returns>
            public static double Tan(double radians)
            {
                // NB: This is the same algorithms as SinCos, but without adjustment for
                // second or third quadrant, and without correcting for the "gain" from
                // rotations - both are redudant multiplications for our calculation.

                // Deal with edge cases
                if (IsNaN(radians) || IsInfinity(radians))
                    return double.NaN;

                // Ensure that the radians are between [-PI, PI]
                radians = RangeLimit(radians);

                // Limit radians within the range [-PI/2, PI/2].
                if (radians < -PIHalfD)
                    radians += PID;
                else if (radians > PIHalfD)
                    radians -= PID;

                // Apply 53 iterations.
                RotateIterations(radians, out var currCos, out var currSin);

                return currSin / currCos;
            }

            #endregion

            #region Inverse Trigonometric

            /// <summary>
            /// Implementation of inverse tangent approximation using CORDIC.
            /// </summary>
            /// <param name="value">The tangent of an angle</param>
            /// <returns>The angle in radians</returns>
            public static float Atan(float value)
            {
                // Deal with edge cases
                if (IsNaN(value))
                    return float.NaN;
                else if (value == float.PositiveInfinity)
                    return PIHalf;
                else if (value == float.NegativeInfinity)
                    return -PIHalf;

                // Apply 24 iterations.
                return VectorIterations(value);
            }

            /// <summary>
            /// Implementation of inverse tangent approximation using CORDIC.
            /// </summary>
            /// <param name="value">The tangent of an angle</param>
            /// <returns>The angle in radians</returns>
            public static double Atan(double value)
            {
                // Deal with edge cases
                if (IsNaN(value))
                    return double.NaN;
                else if (value == double.PositiveInfinity)
                    return PIHalfD;
                else if (value == double.NegativeInfinity)
                    return -PIHalfD;

                // Apply 53 iterations.
                return VectorIterations(value);
            }

            /// <summary>
            /// Implementation of inverse tangent approximation using CORDIC.
            /// </summary>
            /// <param name="y">The y value in radians</param>
            /// <param name="x">The x value in radians</param>
            /// <returns>The angle in radians</returns>
            public static float Atan2(float y, float x)
            {
                // Deal with edge cases
                if (IsNaN(x) || IsNaN(y))
                    return float.NaN;
                else if ((x == float.NegativeInfinity && y == float.PositiveInfinity))
                    return 3.0f * PIFourth;
                else if ((x == float.NegativeInfinity && y == float.NegativeInfinity))
                    return -3.0f * PIFourth;
                else if ((x == float.PositiveInfinity && y == float.PositiveInfinity))
                    return PIFourth;
                else if ((x == float.PositiveInfinity && y == float.NegativeInfinity))
                    return -PIFourth;

                // Tranform to equivalent Atan calculation, as defined in:
                // https://en.wikipedia.org/wiki/Atan2
                if (x > 0)
                    return Atan(y / x);
                else if (x < 0 && y >= 0)
                    return Atan(y / x) + PI;
                else if (x < 0 && y < 0)
                    return Atan(y / x) - PI;
                else if (x == 0 && y > 0)
                    return PIHalf;
                else if (x == 0 && y < 0)
                    return -PIHalf;
                else
                    return 0;
            }

            /// <summary>
            /// Implementation of inverse tangent approximation using CORDIC.
            /// </summary>
            /// <param name="y">The y value in radians</param>
            /// <param name="x">The x value in radians</param>
            /// <returns>The angle in radians</returns>
            public static double Atan2(double y, double x)
            {
                // Deal with edge cases
                if (IsNaN(x) || IsNaN(y))
                    return double.NaN;
                else if ((x == double.NegativeInfinity && y == double.PositiveInfinity))
                    return 3.0 * PIFourthD;
                else if ((x == double.NegativeInfinity && y == double.NegativeInfinity))
                    return -3.0 * PIFourthD;
                else if ((x == double.PositiveInfinity && y == double.PositiveInfinity))
                    return PIFourthD;
                else if ((x == double.PositiveInfinity && y == double.NegativeInfinity))
                    return -PIFourthD;

                // Tranform to equivalent Atan calculation, as defined in:
                // https://en.wikipedia.org/wiki/Atan2
                if (x > 0)
                    return Atan(y / x);
                else if (x < 0 && y >= 0)
                    return Atan(y / x) + PID;
                else if (x < 0 && y < 0)
                    return Atan(y / x) - PID;
                else if (x == 0 && y > 0)
                    return PIHalfD;
                else if (x == 0 && y < 0)
                    return -PIHalfD;
                else
                    return 0;
            }

            #endregion
        }
    }
}