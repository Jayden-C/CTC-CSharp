using System;

namespace ACILIBj
{
    static class Utilities
    {

        /// <summary>
        /// Gets the square root of the input and appends its original sign after square rooting
        /// </summary>
        /// <param name="input">Input</param>
        /// <returns></returns>
        public static double SignedRoot(double input)
        {
            return Math.Sqrt(Math.Abs(input)) * Math.Sign(input);
        }

        /// <summary>
        /// Returns the value of the input clamped between +clamp and -clamp
        /// </summary>
        /// <param name="input">To be clamped</param>
        /// <param name="clamp">Min/Max value</param>
        /// <returns></returns>
        public static double Clamp(double input, double clamp)
        {
            return Math.Abs(input) > clamp ? clamp*Math.Sign(input) : input;
        }

        /// <summary>
        /// Returns the mod of the provided value with its sign
        /// </summary>
        /// <param name="a"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static double SignedMod(double a, double n)
        {
            return (a%n + n)%n;
        }
    }
}
