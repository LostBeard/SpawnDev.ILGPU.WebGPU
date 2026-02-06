// ---------------------------------------------------------------------------------------
//                                   ILGPU Algorithms
//                        Copyright (c) 2020-2021 ILGPU Project
//                                    www.ilgpu.net
//
// File: Cordic.Log.tt/Cordic.Log.cs
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
namespace ILGPU.Algorithms
{
    partial class XMath
    {
        /// <summary>
        /// Implementation of logarithmic functions using CORDIC approximation.
        /// </summary>
        partial class Cordic
        {
            #region Logarithm

            /// <summary>
            /// Implementation of natural logarithm using CORDIC approximation.
            /// </summary>
            /// <param name="value">The input value</param>
            /// <returns>The exponent of a input value raised to base e</returns>
            public static float Log(float value)
            {
                // Deal with edge cases
                if (IsNaN(value) || value == float.PositiveInfinity)
                    return value;
                if (value == 0.0f)
                    return float.NegativeInfinity;
                if (value < 0.0f)
                    return float.NaN;

                // The exponential function is related to hyperbolic functions with the
                // identity:
                //  exp(x) = cosh(x) + sinh(x)
                //
                // Furthermore, the hyperbolic CORDIC algorithm cannot handle the full
                // range of input values, so we simplify the calculations using the
                // formula:
                //
                //  ln(x) = ln(base^power * multiplier)
                //        = ln(base^power) + ln(multiplier)
                //        = power * ln(base) + ln(multiplier)
                //
                // We can calculate base/power easily using repeated divisions, and using
                // a suitable base, the multiplier fits within the CORDIC input range.
                //
                // NB: We picked base e, as it cancels out the ln(base).
                //
                // Reference:
                //  https://en.wikipedia.org/wiki/Logarithm#Exponentiation
                //
                var power = 0;
                var currValue = value;

                while (currValue > E)
                {
                    power += 1;
                    currValue /= E;
                }

                while (currValue < 1.0f)
                {
                    power -= 1;
                    currValue *= E;
                }

                // Apply 24 iterations.
                var cosh = currValue + 1.0f;
                var sinh = currValue - 1.0f;
                var radians = VectorHyperbolicIterations(cosh, sinh);

                return power + (2.0f * radians);
            }

            /// <summary>
            /// Implementation of natural logarithm using CORDIC approximation.
            /// </summary>
            /// <param name="value">The input value</param>
            /// <returns>The exponent of a input value raised to base e</returns>
            public static double Log(double value)
            {
                // Deal with edge cases
                if (IsNaN(value) || value == double.PositiveInfinity)
                    return value;
                if (value == 0.0)
                    return double.NegativeInfinity;
                if (value < 0.0)
                    return double.NaN;

                // The exponential function is related to hyperbolic functions with the
                // identity:
                //  exp(x) = cosh(x) + sinh(x)
                //
                // Furthermore, the hyperbolic CORDIC algorithm cannot handle the full
                // range of input values, so we simplify the calculations using the
                // formula:
                //
                //  ln(x) = ln(base^power * multiplier)
                //        = ln(base^power) + ln(multiplier)
                //        = power * ln(base) + ln(multiplier)
                //
                // We can calculate base/power easily using repeated divisions, and using
                // a suitable base, the multiplier fits within the CORDIC input range.
                //
                // NB: We picked base e, as it cancels out the ln(base).
                //
                // Reference:
                //  https://en.wikipedia.org/wiki/Logarithm#Exponentiation
                //
                var power = 0;
                var currValue = value;

                while (currValue > ED)
                {
                    power += 1;
                    currValue /= ED;
                }

                while (currValue < 1.0)
                {
                    power -= 1;
                    currValue *= ED;
                }

                // Apply 53 iterations.
                var cosh = currValue + 1.0;
                var sinh = currValue - 1.0;
                var radians = VectorHyperbolicIterations(cosh, sinh);

                return power + (2.0 * radians);
            }

            #endregion
        }
    }
}