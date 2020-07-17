using System;
using System.Runtime.CompilerServices;

namespace MathExtended.Common
{
    public static class Wrapping
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Wrap(double x, double lowerLimit, double upperLimit)
        {
            return x - Math.Floor((x - lowerLimit) / (upperLimit - lowerLimit)) * (upperLimit - lowerLimit);
        }
    }
}
