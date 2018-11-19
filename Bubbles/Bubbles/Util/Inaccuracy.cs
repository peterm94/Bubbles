using System;
using System.Runtime.InteropServices;

namespace Bubbles.Util
{
    public static class Inaccuracy
    {
        private static readonly Random random = new Random();
        
        public static float MakeInaccurate(float currentRotationRadians, float scale = 1)
        {
            // Random double between -0.5 and 0.5, then scaled.
            var amount = (random.NextDouble() - 0.5) * scale;

            return (float) (currentRotationRadians + amount);
        }
    }
}