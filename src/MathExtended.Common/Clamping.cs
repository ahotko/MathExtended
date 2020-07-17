using System.Runtime.CompilerServices;

namespace MathExtended.Common
{
    public static class Clamping
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Clamp(double x, double lowerLimit = 0.0, double upperLimit = 1.0)
        {
            if (x < lowerLimit) return lowerLimit;
            if (x > upperLimit) return upperLimit;
            return x;
        }

        public static double SmoothStep(double x, double lowerLimit, double upperLimit)
        {
            return SmoothStep3(x, lowerLimit, upperLimit);
        }

        public static double SmoothStep3(double x, double lowerLimit, double upperLimit)
        {
            x = Clamp((x - lowerLimit) / (upperLimit - lowerLimit));
            return x * x * (3.0 - 2.0 * x);
        }

        public static double SmoothStep5(double x, double lowerLimit, double upperLimit)
        {
            x = Clamp((x - lowerLimit) / (upperLimit - lowerLimit));
            return x * x * x * (10 + x * (-15.0 + 6.0 * x));
        }

        public static double SmoothStep7(double x, double lowerLimit, double upperLimit)
        {
            x = Clamp((x - lowerLimit) / (upperLimit - lowerLimit));
            return x * x * x * x * (35.0 + x * (-84.0 + x * (70.0 - 20.0 * x)));
        }

        public static double SmootherStep(double x, double lowerLimit, double upperLimit)
        {
            x = Clamp((x - lowerLimit) / (upperLimit - lowerLimit));
            return x * x * x * (x * (x * 6.0 - 15.0) + 10.0);
        }
    }
}
