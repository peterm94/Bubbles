using System;

namespace Bubbles.Util
{
    public static class MathUtil
    {
        /// <summary>
        ///     Float equality with a default tolerance.
        /// </summary>
        /// <param name="f1">The first value the compare.</param>
        /// <param name="f2">The second value to compare to.</param>
        /// <param name="tolerance">The equality tolerance.</param>
        /// <returns>True if equal, otherwise false.</returns>
        public static bool FloatEquals(float f1, float f2, float tolerance = 0.001f)
        {
            return Math.Abs(f1 - f2) < tolerance;
        }
    }
}