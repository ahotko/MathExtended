using System.Runtime.CompilerServices;

namespace MathExtended.Common
{
    public static class Mapping
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Map(double x, double xInMin = 0.0, double xInMax = 1.0, double xOutMin = 0.0, double xOutMax = 1.0)
        {
            double xMapped = (x - xInMin) / (xInMax - xInMin);
            return xOutMin + (xOutMax - xOutMin) * xMapped;
        }
    }
}
