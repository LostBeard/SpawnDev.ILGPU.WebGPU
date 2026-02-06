// ---------------------------------------------------------------------------------------
//                                   ILGPU Algorithms
//                        Copyright (c) 2020-2021 ILGPU Project
//                                    www.ilgpu.net
//
// File: Cordic.tt/Cordic.cs
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

using ILGPU.Util;
using System.Runtime.CompilerServices;

namespace ILGPU.Algorithms
{
    partial class XMath
    {
        /// <summary>
        /// Implementation of trigonometric/hyperbolic rotation and vector mode functions using CORDIC approximation.
        /// https://en.wikipedia.org/wiki/CORDIC
        ///
        /// NB: CORDIC is typically implemented using a lookup table with angles. However, since
        /// these are not currently available, we unroll the loop.
        /// </summary>
        internal static partial class Cordic
        {
            /// <summary>
            /// Corrects the inaccuracies gained by rotating through the 24 iterations.
            /// NB: We are using a pre-defined number of iterations, so the scaling can be a constant value.
            /// </summary>
            private const float Gain = 6.072529350E-001f;

            /// <summary>
            /// Corrects the inaccuracies gained by rotating through the 53 iterations.
            /// NB: We are using a pre-defined number of iterations, so the scaling can be a constant value.
            /// </summary>
            private const double GainD = 6.07252935008881445E-001;

            /// <summary>
            /// Corrects the inaccuracies gained by rotating through the 24 iterations.
            /// NB: We are using a pre-defined number of iterations, so the scaling can be a constant value.
            /// </summary>
            private static readonly float HyperbolicGain = HyperbolicGainFromCoshZero();

            /// <summary>
            /// Corrects the inaccuracies gained by rotating through the 53 iterations.
            /// NB: We are using a pre-defined number of iterations, so the scaling can be a constant value.
            /// </summary>
            private static readonly double HyperbolicGainD = HyperbolicGainFromCoshZeroD();

            #region Utilities

            /// <summary>
            /// Calculates the inaccuracy gained by calculating the baseline of Cosh(0).
            /// </summary>
            [MethodImpl(MethodImplOptions.NoInlining)]
            private static float HyperbolicGainFromCoshZero()
            {
                // Cosh(0) should return 1. Any differences reflects inaccuracies in the CORDIC algorithm.
                //
                // Ideally, we should be able to calculate cumprod(Cosh(Atanh(2.^(-i)))), similar to the
                // standard/circular CORDIC algorithm. However, the idealized constant converges at 1.2051,
                // where-as our hyperbolic CORDIC algorithm produces a gain of 1.2075. As a workaround,
                // calculate the gain at runtime using the real CORDIC algorithm.

                // Apply 24 iterations.
                RotateHyperbolicIterations(0.0f, out var cosh, out _);
                return 1.0f / cosh;
            }

            /// <summary>
            /// Calculates the inaccuracy gained by calculating the baseline of Cosh(0).
            /// </summary>
            [MethodImpl(MethodImplOptions.NoInlining)]
            private static double HyperbolicGainFromCoshZeroD()
            {
                // Cosh(0) should return 1. Any differences reflects inaccuracies in the CORDIC algorithm.
                //
                // Ideally, we should be able to calculate cumprod(Cosh(Atanh(2.^(-i)))), similar to the
                // standard/circular CORDIC algorithm. However, the idealized constant converges at 1.2051,
                // where-as our hyperbolic CORDIC algorithm produces a gain of 1.2075. As a workaround,
                // calculate the gain at runtime using the real CORDIC algorithm.

                // Apply 53 iterations.
                RotateHyperbolicIterations(0.0, out var cosh, out _);
                return 1.0 / cosh;
            }

            /// <summary>
            /// Performs the common matrix multiplication used by CORDIC (a 2x2 matrix with a 2x1 matrix).
            /// </summary>
            /// <param name="cos">The current cosine value. Filled in with the result cosine value</param>
            /// <param name="sin">The current sine value. Filled in with the result sine value</param>
            /// <param name="factor">The multiplication factor</param>
            [MethodImpl(MethodImplOptions.NoInlining)]
            private static void MatrixMultiply(ref float cos, ref float sin, float factor)
            {
                // Matrix multiplication
                // [ 1     , -factor ] [ currCos ]
                // [ factor, 1       ] [ currSin ]
                var currCos = cos;
                var currSin = sin;
                var nextCos = currCos - (currSin * factor);
                var nextSin = (currCos * factor) + currSin;

                cos = nextCos;
                sin = nextSin;
            }

            /// <summary>
            /// Performs the common matrix multiplication used by CORDIC (a 2x2 matrix with a 2x1 matrix).
            /// </summary>
            /// <param name="cos">The current cosine value. Filled in with the result cosine value</param>
            /// <param name="sin">The current sine value. Filled in with the result sine value</param>
            /// <param name="factor">The multiplication factor</param>
            [MethodImpl(MethodImplOptions.NoInlining)]
            private static void MatrixMultiply(ref double cos, ref double sin, double factor)
            {
                // Matrix multiplication
                // [ 1     , -factor ] [ currCos ]
                // [ factor, 1       ] [ currSin ]
                var currCos = cos;
                var currSin = sin;
                var nextCos = currCos - (currSin * factor);
                var nextSin = (currCos * factor) + currSin;

                cos = nextCos;
                sin = nextSin;
            }

            /// <summary>
            /// Multiplies a 2x2 matrix with a 2x1 matrix for hyperbolic iterations.
            /// </summary>
            /// <param name="cosh">The current hyperbolic cosine value. Filled in with the result hyperbolic cosine value</param>
            /// <param name="sinh">The current hyperbolic sine value. Filled in with the result hyperbolic sine value</param>
            /// <param name="factor">The multiplication factor</param>
            [MethodImpl(MethodImplOptions.NoInlining)]
            private static void MatrixMultiplyHyperbolic(ref float cosh, ref float sinh, float factor)
            {
                // Matrix multiplication
                // [ 1     , factor ] [ currCos ]
                // [ factor, 1      ] [ currSin ]
                var currCosh = cosh;
                var currSinh = sinh;
                var nextCosh = currCosh + (currSinh * factor);
                var nextSinh = (currCosh * factor) + currSinh;

                cosh = nextCosh;
                sinh = nextSinh;
            }

            /// <summary>
            /// Multiplies a 2x2 matrix with a 2x1 matrix for hyperbolic iterations.
            /// </summary>
            /// <param name="cosh">The current hyperbolic cosine value. Filled in with the result hyperbolic cosine value</param>
            /// <param name="sinh">The current hyperbolic sine value. Filled in with the result hyperbolic sine value</param>
            /// <param name="factor">The multiplication factor</param>
            [MethodImpl(MethodImplOptions.NoInlining)]
            private static void MatrixMultiplyHyperbolic(ref double cosh, ref double sinh, double factor)
            {
                // Matrix multiplication
                // [ 1     , factor ] [ currCos ]
                // [ factor, 1      ] [ currSin ]
                var currCosh = cosh;
                var currSinh = sinh;
                var nextCosh = currCosh + (currSinh * factor);
                var nextSinh = (currCosh * factor) + currSinh;

                cosh = nextCosh;
                sinh = nextSinh;
            }

            #endregion

            #region Trigonometric

            /// <summary>
            /// Ensures that the radians are within the range [-PI, PI]
            /// </summary>
            /// <param name="radians">The angle in radians</param>
            /// <returns>The angle, in radians</returns>
            [MethodImpl(MethodImplOptions.NoInlining)]
            private static float RangeLimit(float radians)
            {
                while (radians < -PI)
                    radians += 2 * PI;
                while (radians > PI)
                    radians -= 2 * PI;
                return radians;
            }

            /// <summary>
            /// Ensures that the radians are within the range [-PI, PI]
            /// </summary>
            /// <param name="radians">The angle in radians</param>
            /// <returns>The angle, in radians</returns>
            [MethodImpl(MethodImplOptions.NoInlining)]
            private static double RangeLimit(double radians)
            {
                while (radians < -PID)
                    radians += 2 * PID;
                while (radians > PID)
                    radians -= 2 * PID;
                return radians;
            }

            /// <summary>
            /// Applies the next iteration of CORDIC rotation
            /// </summary>
            /// <param name="angle">The angle for this iteration</param>
            /// <param name="cos">The current cosine value</param>
            /// <param name="sin">The current sine value</param>
            /// <param name="radians">The current radians value</param>
            /// <param name="powerOfTwo">The current multiplier</param>
            [MethodImpl(MethodImplOptions.NoInlining)]
            private static void NextRotateIteration(float angle, ref float cos, ref float sin, ref float radians, ref float powerOfTwo)
            {
                var sigma = Utilities.Select(radians < 0, -1, 1);
                var factor = sigma * powerOfTwo;

                MatrixMultiply(ref cos, ref sin, factor);

                // Update the remaining angle
                radians -= sigma * angle;
                powerOfTwo /= 2.0f;
            }

            /// <summary>
            /// Applies the next iteration of CORDIC rotation
            /// </summary>
            /// <param name="angle">The angle for this iteration</param>
            /// <param name="cos">The current cosine value</param>
            /// <param name="sin">The current sine value</param>
            /// <param name="radians">The current radians value</param>
            /// <param name="powerOfTwo">The current multiplier</param>
            [MethodImpl(MethodImplOptions.NoInlining)]
            private static void NextRotateIteration(double angle, ref double cos, ref double sin, ref double radians, ref double powerOfTwo)
            {
                var sigma = Utilities.Select(radians < 0, -1, 1);
                var factor = sigma * powerOfTwo;

                MatrixMultiply(ref cos, ref sin, factor);

                // Update the remaining angle
                radians -= sigma * angle;
                powerOfTwo /= 2.0;
            }

            /// <summary>
            /// Applies the iterations of CORDIC rotations
            /// </summary>
            /// <param name="radians">The radians value</param>
            /// <param name="cos">Filled in with result cosine value</param>
            /// <param name="sin">Filled in with result sine value</param>
            [MethodImpl(MethodImplOptions.NoInlining)]
            private static void RotateIterations(float radians, out float cos, out float sin)
            {
                // Apply 24 iterations.
                var currCos = 1.0f;
                var currSin = 0.0f;
                var currRadians = radians;
                var powerOfTwo = 1.0f;

                NextRotateIteration(7.853981634E-001f, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(4.636476090E-001f, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(2.449786631E-001f, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(1.243549945E-001f, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(6.241881000E-002f, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(3.123983343E-002f, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(1.562372862E-002f, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(7.812341060E-003f, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(3.906230132E-003f, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(1.953122516E-003f, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(9.765621896E-004f, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(4.882812112E-004f, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(2.441406201E-004f, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(1.220703119E-004f, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(6.103515617E-005f, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(3.051757812E-005f, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(1.525878906E-005f, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(7.629394531E-006f, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(3.814697266E-006f, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(1.907348633E-006f, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(9.536743164E-007f, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(4.768371582E-007f, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(2.384185791E-007f, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(1.192092896E-007f, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);

                cos = currCos;
                sin = currSin;
            }

            /// <summary>
            /// Applies the iterations of CORDIC rotations
            /// </summary>
            /// <param name="radians">The radians value</param>
            /// <param name="cos">Filled in with result cosine value</param>
            /// <param name="sin">Filled in with result sine value</param>
            [MethodImpl(MethodImplOptions.NoInlining)]
            private static void RotateIterations(double radians, out double cos, out double sin)
            {
                // Apply 53 iterations.
                var currCos = 1.0;
                var currSin = 0.0;
                var currRadians = radians;
                var powerOfTwo = 1.0;

                NextRotateIteration(7.85398163397448279E-001, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(4.63647609000806094E-001, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(2.44978663126864143E-001, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(1.24354994546761438E-001, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(6.24188099959573500E-002, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(3.12398334302682774E-002, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(1.56237286204768313E-002, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(7.81234106010111114E-003, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(3.90623013196697176E-003, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(1.95312251647881876E-003, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(9.76562189559319459E-004, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(4.88281211194898290E-004, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(2.44140620149361771E-004, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(1.22070311893670208E-004, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(6.10351561742087726E-005, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(3.05175781155260957E-005, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(1.52587890613157615E-005, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(7.62939453110196998E-006, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(3.81469726560649614E-006, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(1.90734863281018696E-006, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(9.53674316405960844E-007, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(4.76837158203088842E-007, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(2.38418579101557974E-007, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(1.19209289550780681E-007, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(5.96046447753905522E-008, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(2.98023223876953026E-008, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(1.49011611938476546E-008, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(7.45058059692382812E-009, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(3.72529029846191406E-009, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(1.86264514923095703E-009, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(9.31322574615478516E-010, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(4.65661287307739258E-010, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(2.32830643653869629E-010, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(1.16415321826934814E-010, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(5.82076609134674072E-011, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(2.91038304567337036E-011, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(1.45519152283668518E-011, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(7.27595761418342590E-012, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(3.63797880709171295E-012, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(1.81898940354585648E-012, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(9.09494701772928238E-013, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(4.54747350886464119E-013, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(2.27373675443232059E-013, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(1.13686837721616030E-013, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(5.68434188608080149E-014, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(2.84217094304040074E-014, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(1.42108547152020037E-014, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(7.10542735760100186E-015, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(3.55271367880050093E-015, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(1.77635683940025046E-015, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(8.88178419700125232E-016, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(4.44089209850062616E-016, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextRotateIteration(2.22044604925031308E-016, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);

                cos = currCos;
                sin = currSin;
            }

            #endregion

            #region Inverse Trigonometric

            /// <summary>
            /// Applies the next iteration of CORDIC vectoring
            /// </summary>
            /// <param name="angle">The angle for this iteration</param>
            /// <param name="cos">The current cosine value</param>
            /// <param name="sin">The current sine value</param>
            /// <param name="radians">The current radians value</param>
            /// <param name="powerOfTwo">The current multiplier</param>
            [MethodImpl(MethodImplOptions.NoInlining)]
            private static void NextVectorIteration(float angle, ref float cos, ref float sin, ref float radians, ref float powerOfTwo)
            {
                var sigma = Utilities.Select(sin >= 0, -1, 1);
                var factor = sigma * powerOfTwo;

                MatrixMultiply(ref cos, ref sin, factor);

                radians -= sigma * angle;
                powerOfTwo /= 2.0f;
            }

            /// <summary>
            /// Applies the next iteration of CORDIC vectoring
            /// </summary>
            /// <param name="angle">The angle for this iteration</param>
            /// <param name="cos">The current cosine value</param>
            /// <param name="sin">The current sine value</param>
            /// <param name="radians">The current radians value</param>
            /// <param name="powerOfTwo">The current multiplier</param>
            [MethodImpl(MethodImplOptions.NoInlining)]
            private static void NextVectorIteration(double angle, ref double cos, ref double sin, ref double radians, ref double powerOfTwo)
            {
                var sigma = Utilities.Select(sin >= 0, -1, 1);
                var factor = sigma * powerOfTwo;

                MatrixMultiply(ref cos, ref sin, factor);

                radians -= sigma * angle;
                powerOfTwo /= 2.0;
            }

            /// <summary>
            /// Applies the iterations of CORDIC vectoring
            /// </summary>
            /// <param name="target">The target sine value</param>
            /// <returns>The angle in radians</returns>
            [MethodImpl(MethodImplOptions.NoInlining)]
            private static float VectorIterations(float target)
            {
                // Apply 24 iterations.
                var currCos = 1.0f;
                var currSin = target;
                var currRadians = 0.0f;
                var powerOfTwo = 1.0f;

                NextVectorIteration(7.853981634E-001f, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(4.636476090E-001f, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(2.449786631E-001f, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(1.243549945E-001f, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(6.241881000E-002f, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(3.123983343E-002f, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(1.562372862E-002f, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(7.812341060E-003f, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(3.906230132E-003f, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(1.953122516E-003f, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(9.765621896E-004f, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(4.882812112E-004f, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(2.441406201E-004f, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(1.220703119E-004f, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(6.103515617E-005f, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(3.051757812E-005f, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(1.525878906E-005f, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(7.629394531E-006f, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(3.814697266E-006f, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(1.907348633E-006f, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(9.536743164E-007f, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(4.768371582E-007f, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(2.384185791E-007f, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(1.192092896E-007f, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);

                return currRadians;
            }

            /// <summary>
            /// Applies the iterations of CORDIC vectoring
            /// </summary>
            /// <param name="target">The target sine value</param>
            /// <returns>The angle in radians</returns>
            [MethodImpl(MethodImplOptions.NoInlining)]
            private static double VectorIterations(double target)
            {
                // Apply 53 iterations.
                var currCos = 1.0;
                var currSin = target;
                var currRadians = 0.0;
                var powerOfTwo = 1.0;

                NextVectorIteration(7.85398163397448279E-001, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(4.63647609000806094E-001, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(2.44978663126864143E-001, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(1.24354994546761438E-001, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(6.24188099959573500E-002, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(3.12398334302682774E-002, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(1.56237286204768313E-002, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(7.81234106010111114E-003, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(3.90623013196697176E-003, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(1.95312251647881876E-003, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(9.76562189559319459E-004, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(4.88281211194898290E-004, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(2.44140620149361771E-004, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(1.22070311893670208E-004, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(6.10351561742087726E-005, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(3.05175781155260957E-005, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(1.52587890613157615E-005, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(7.62939453110196998E-006, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(3.81469726560649614E-006, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(1.90734863281018696E-006, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(9.53674316405960844E-007, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(4.76837158203088842E-007, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(2.38418579101557974E-007, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(1.19209289550780681E-007, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(5.96046447753905522E-008, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(2.98023223876953026E-008, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(1.49011611938476546E-008, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(7.45058059692382812E-009, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(3.72529029846191406E-009, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(1.86264514923095703E-009, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(9.31322574615478516E-010, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(4.65661287307739258E-010, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(2.32830643653869629E-010, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(1.16415321826934814E-010, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(5.82076609134674072E-011, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(2.91038304567337036E-011, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(1.45519152283668518E-011, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(7.27595761418342590E-012, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(3.63797880709171295E-012, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(1.81898940354585648E-012, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(9.09494701772928238E-013, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(4.54747350886464119E-013, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(2.27373675443232059E-013, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(1.13686837721616030E-013, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(5.68434188608080149E-014, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(2.84217094304040074E-014, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(1.42108547152020037E-014, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(7.10542735760100186E-015, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(3.55271367880050093E-015, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(1.77635683940025046E-015, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(8.88178419700125232E-016, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(4.44089209850062616E-016, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);
                NextVectorIteration(2.22044604925031308E-016, ref currCos, ref currSin, ref currRadians, ref powerOfTwo);

                return currRadians;
            }

            #endregion

            #region Hyperbolic
            /// <summary>
            /// Applies the next iteration of CORDIC hyperbolic rotation
            /// </summary>
            /// <param name="angle">The angle for this iteration</param>
            /// <param name="cosh">The current cosh value</param>
            /// <param name="sinh">The current sinh value</param>
            /// <param name="radians">The current radians value</param>
            /// <param name="powerOfTwo">The current multiplier</param>
            /// <param name="numMultiplications">The number of multiplications in this loop</param>
            [MethodImpl(MethodImplOptions.NoInlining)]
            private static void NextRotateHyperbolicIteration(float angle, ref float cosh, ref float sinh, ref float radians, ref float powerOfTwo, int numMultiplications)
            {
                // Apply second multiplication every 3k + 1 multiplcations
                for (var i = 0; i < numMultiplications; i++)
                {
                    var sigma = Utilities.Select(radians < 0, -1, 1);
                    var factor = sigma * powerOfTwo;

                    MatrixMultiplyHyperbolic(ref cosh, ref sinh, factor);
                    radians -= sigma * angle;
                }

                powerOfTwo /= 2.0f;
            }

            /// <summary>
            /// Applies the next iteration of CORDIC hyperbolic rotation
            /// </summary>
            /// <param name="angle">The angle for this iteration</param>
            /// <param name="cosh">The current cosh value</param>
            /// <param name="sinh">The current sinh value</param>
            /// <param name="radians">The current radians value</param>
            /// <param name="powerOfTwo">The current multiplier</param>
            /// <param name="numMultiplications">The number of multiplications in this loop</param>
            [MethodImpl(MethodImplOptions.NoInlining)]
            private static void NextRotateHyperbolicIteration(double angle, ref double cosh, ref double sinh, ref double radians, ref double powerOfTwo, int numMultiplications)
            {
                // Apply second multiplication every 3k + 1 multiplcations
                for (var i = 0; i < numMultiplications; i++)
                {
                    var sigma = Utilities.Select(radians < 0, -1, 1);
                    var factor = sigma * powerOfTwo;

                    MatrixMultiplyHyperbolic(ref cosh, ref sinh, factor);
                    radians -= sigma * angle;
                }

                powerOfTwo /= 2.0;
            }

            /// <summary>
            /// Applies the iterations of CORDIC hyperbolic rotations
            /// </summary>
            /// <param name="radians">The current radians value</param>
            /// <param name="cosh">The current cosh value</param>
            /// <param name="sinh">The current sinh value</param>
            [MethodImpl(MethodImplOptions.NoInlining)]
            private static void RotateHyperbolicIterations(float radians, out float cosh, out float sinh)
            {
                // Apply 24 iterations.
                var currCosh = 1.0f;
                var currSinh = 0.0f;
                var currRadians = radians;
                var powerOfTwo = 0.5f;

                NextRotateHyperbolicIteration(5.493061443E-001f, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(2.554128119E-001f, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(1.256572141E-001f, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(6.258157148E-002f, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 2);
                NextRotateHyperbolicIteration(3.126017849E-002f, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(1.562627175E-002f, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(7.812658952E-003f, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(3.906269868E-003f, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(1.953127484E-003f, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(9.765628104E-004f, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(4.882812888E-004f, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(2.441406299E-004f, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(1.220703131E-004f, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 2);
                NextRotateHyperbolicIteration(6.103515633E-005f, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(3.051757813E-005f, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(1.525878906E-005f, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(7.629394531E-006f, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(3.814697266E-006f, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(1.907348633E-006f, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(9.536743164E-007f, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(4.768371582E-007f, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(2.384185791E-007f, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(1.192092896E-007f, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(5.960464478E-008f, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);

                cosh = currCosh;
                sinh = currSinh;
            }

            /// <summary>
            /// Applies the iterations of CORDIC hyperbolic rotations
            /// </summary>
            /// <param name="radians">The current radians value</param>
            /// <param name="cosh">The current cosh value</param>
            /// <param name="sinh">The current sinh value</param>
            [MethodImpl(MethodImplOptions.NoInlining)]
            private static void RotateHyperbolicIterations(double radians, out double cosh, out double sinh)
            {
                // Apply 53 iterations.
                var currCosh = 1.0;
                var currSinh = 0.0;
                var currRadians = radians;
                var powerOfTwo = 0.5;

                NextRotateHyperbolicIteration(5.49306144334054891E-001, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(2.55412811882995361E-001, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(1.25657214140453083E-001, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(6.25815714770029952E-002, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 2);
                NextRotateHyperbolicIteration(3.12601784906669650E-002, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(1.56262717520522648E-002, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(7.81265895154040733E-003, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(3.90626986839681233E-003, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(1.95312748353260526E-003, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(9.76562810441035075E-004, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(4.88281288805085122E-004, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(2.44140629850637741E-004, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(1.22070313106329792E-004, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 2);
                NextRotateHyperbolicIteration(6.10351563257773428E-005, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(3.05175781344730335E-005, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(1.52587890636841826E-005, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(7.62939453139802578E-006, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(3.81469726569901459E-006, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(1.90734863280787414E-006, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(9.53674316405671794E-007, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(4.76837158203052738E-007, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(2.38418579101553474E-007, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(1.19209289550780125E-007, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(5.96046447753904860E-008, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(2.98023223876952960E-008, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(1.49011611938476546E-008, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(7.45058065243497770E-009, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(3.72529028458412625E-009, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(1.86264514576151008E-009, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(9.31322573748116778E-010, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(4.65661287090898823E-010, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(2.32830643599659520E-010, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(1.16415321813382287E-010, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(5.82076609100792754E-011, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(2.91038304558866707E-011, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(1.45519152281550936E-011, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(7.27595761413048634E-012, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(3.63797880707847806E-012, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(1.81898940354254775E-012, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(9.09494701772101057E-013, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 2);
                NextRotateHyperbolicIteration(4.54747350886257324E-013, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(2.27373675443180361E-013, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(1.13686837721603105E-013, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(5.68434188608047837E-014, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(2.84217094304031996E-014, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(1.42108547152018018E-014, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(7.10542735760095137E-015, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(3.55271367880048831E-015, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(1.77635683940024731E-015, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(8.88178419700124443E-016, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(4.44089209850062419E-016, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(2.22044604925031259E-016, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextRotateHyperbolicIteration(1.11022302462515642E-016, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);

                cosh = currCosh;
                sinh = currSinh;
            }

            #endregion

            #region Inverse Hyperbolic

            /// <summary>
            /// Applies the next iteration of CORDIC hyperbolic vectoring
            /// </summary>
            /// <param name="angle">The angle for this iteration</param>
            /// <param name="cosh">The current cosh value</param>
            /// <param name="sinh">The current sinh value</param>
            /// <param name="radians">The current radians value</param>
            /// <param name="powerOfTwo">The current multiplier</param>
            /// <param name="numMultiplications">The number of multiplications in this loop</param>
            [MethodImpl(MethodImplOptions.NoInlining)]
            private static void NextVectorHyperbolicIteration(float angle, ref float cosh, ref float sinh, ref float radians, ref float powerOfTwo, int numMultiplications)
            {
                // Apply second multiplication every 3k + 1 multiplcations
                for (var i = 0; i < numMultiplications; i++)
                {
                    var sigma = Utilities.Select(sinh < 0, 1, -1);
                    var factor = sigma * powerOfTwo;

                    MatrixMultiplyHyperbolic(ref cosh, ref sinh, factor);
                    radians -= sigma * angle;
                }

                powerOfTwo /= 2.0f;
            }

            /// <summary>
            /// Applies the next iteration of CORDIC hyperbolic vectoring
            /// </summary>
            /// <param name="angle">The angle for this iteration</param>
            /// <param name="cosh">The current cosh value</param>
            /// <param name="sinh">The current sinh value</param>
            /// <param name="radians">The current radians value</param>
            /// <param name="powerOfTwo">The current multiplier</param>
            /// <param name="numMultiplications">The number of multiplications in this loop</param>
            [MethodImpl(MethodImplOptions.NoInlining)]
            private static void NextVectorHyperbolicIteration(double angle, ref double cosh, ref double sinh, ref double radians, ref double powerOfTwo, int numMultiplications)
            {
                // Apply second multiplication every 3k + 1 multiplcations
                for (var i = 0; i < numMultiplications; i++)
                {
                    var sigma = Utilities.Select(sinh < 0, 1, -1);
                    var factor = sigma * powerOfTwo;

                    MatrixMultiplyHyperbolic(ref cosh, ref sinh, factor);
                    radians -= sigma * angle;
                }

                powerOfTwo /= 2.0;
            }

            /// <summary>
            /// Applies the iterations of CORDIC hyperbolic vectoring
            /// </summary>
            /// <param name="cosh">The current cosh value</param>
            /// <param name="sinh">The current sinh value</param>
            /// <returns>The angle in radians</returns>
            [MethodImpl(MethodImplOptions.NoInlining)]
            private static float VectorHyperbolicIterations(float cosh, float sinh)
            {
                // Apply 24 iterations.
                var currCosh = cosh;
                var currSinh = sinh;
                var currRadians = 0.0f;
                var powerOfTwo = 0.5f;

                NextVectorHyperbolicIteration(5.493061443E-001f, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(2.554128119E-001f, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(1.256572141E-001f, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(6.258157148E-002f, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 2);
                NextVectorHyperbolicIteration(3.126017849E-002f, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(1.562627175E-002f, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(7.812658952E-003f, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(3.906269868E-003f, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(1.953127484E-003f, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(9.765628104E-004f, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(4.882812888E-004f, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(2.441406299E-004f, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(1.220703131E-004f, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 2);
                NextVectorHyperbolicIteration(6.103515633E-005f, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(3.051757813E-005f, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(1.525878906E-005f, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(7.629394531E-006f, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(3.814697266E-006f, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(1.907348633E-006f, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(9.536743164E-007f, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(4.768371582E-007f, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(2.384185791E-007f, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(1.192092896E-007f, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(5.960464478E-008f, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);

                return currRadians;
            }

            /// <summary>
            /// Applies the iterations of CORDIC hyperbolic vectoring
            /// </summary>
            /// <param name="cosh">The current cosh value</param>
            /// <param name="sinh">The current sinh value</param>
            /// <returns>The angle in radians</returns>
            [MethodImpl(MethodImplOptions.NoInlining)]
            private static double VectorHyperbolicIterations(double cosh, double sinh)
            {
                // Apply 53 iterations.
                var currCosh = cosh;
                var currSinh = sinh;
                var currRadians = 0.0;
                var powerOfTwo = 0.5;

                NextVectorHyperbolicIteration(5.49306144334054891E-001, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(2.55412811882995361E-001, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(1.25657214140453083E-001, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(6.25815714770029952E-002, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 2);
                NextVectorHyperbolicIteration(3.12601784906669650E-002, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(1.56262717520522648E-002, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(7.81265895154040733E-003, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(3.90626986839681233E-003, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(1.95312748353260526E-003, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(9.76562810441035075E-004, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(4.88281288805085122E-004, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(2.44140629850637741E-004, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(1.22070313106329792E-004, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 2);
                NextVectorHyperbolicIteration(6.10351563257773428E-005, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(3.05175781344730335E-005, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(1.52587890636841826E-005, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(7.62939453139802578E-006, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(3.81469726569901459E-006, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(1.90734863280787414E-006, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(9.53674316405671794E-007, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(4.76837158203052738E-007, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(2.38418579101553474E-007, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(1.19209289550780125E-007, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(5.96046447753904860E-008, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(2.98023223876952960E-008, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(1.49011611938476546E-008, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(7.45058065243497770E-009, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(3.72529028458412625E-009, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(1.86264514576151008E-009, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(9.31322573748116778E-010, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(4.65661287090898823E-010, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(2.32830643599659520E-010, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(1.16415321813382287E-010, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(5.82076609100792754E-011, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(2.91038304558866707E-011, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(1.45519152281550936E-011, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(7.27595761413048634E-012, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(3.63797880707847806E-012, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(1.81898940354254775E-012, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(9.09494701772101057E-013, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 2);
                NextVectorHyperbolicIteration(4.54747350886257324E-013, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(2.27373675443180361E-013, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(1.13686837721603105E-013, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(5.68434188608047837E-014, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(2.84217094304031996E-014, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(1.42108547152018018E-014, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(7.10542735760095137E-015, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(3.55271367880048831E-015, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(1.77635683940024731E-015, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(8.88178419700124443E-016, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(4.44089209850062419E-016, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(2.22044604925031259E-016, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);
                NextVectorHyperbolicIteration(1.11022302462515642E-016, ref currCosh, ref currSinh, ref currRadians, ref powerOfTwo, 1);

                return currRadians;
            }

            #endregion
        }
    }
}