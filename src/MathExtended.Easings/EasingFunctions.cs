using System;

namespace MathExtended.Easings
{
    /// <summary>
    /// C# port of Easing functions from https://github.com/ai/easings.net
    /// </summary>
    public class EasingFunctions
    {
        private const double c1 = 1.70158;
        private const double c2 = c1 * 1.525;
        private const double c3 = c1 + 1.0;
        private const double c4 = (2 * Math.PI) / 3;
        private const double c5 = (2 * Math.PI) / 4.5;

        private double BounceOut(double x)
        {
            const double n1 = 7.5625;
            const double d1 = 2.75;

            if (x < 1.0 / d1) return n1 * x * x;
            if (x < 2.0 / d1) return n1 * (x -= 1.5 / d1) * x + 0.75;
            if (x < 2.5 / d1) return n1 * (x -= 2.25 / d1) * x + 0.9375;
            return n1 * (x -= 2.625 / d1) * x + 0.984375;
        }

        public double EaseInQuad(double x)
        {
            return x * x;
        }

        public double EaseOutQuad(double x)
        {
            return 1.0 - (1.0 - x) * (1.0 - x); ;
        }

        public double EaseInOutQuad(double x)
        {
            return (x < 0.5) ? 2 * x * x : 1 - Math.Pow(-2 * x + 2, 2) / 2;
        }

        public double EaseInCubic(double x)
        {
            return x * x * x;
        }

        public double EaseOutCubic(double x)
        {
            return 1.0 - Math.Pow(x, 3);
        }

        public double EaseInOutCubic(double x)
        {
            return x < 0.5 ? 4 * x * x * x : 1 - Math.Pow(-2 * x + 2, 3) / 2;
        }

        public double EaseInQuart(double x)
        {
            return x * x * x * x;
        }

        public double EaseOutQuart(double x)
        {
            return 1.0 - Math.Pow(x, 4);
        }

        public double EaseInOutQuart(double x)
        {
            return x < 0.5 ? 8 * x * x * x * x : 1 - Math.Pow(-2 * x + 2, 4) / 2;
        }

        public double EaseInQuint(double x)
        {
            return Math.Pow(x, 5);
        }

        public double EaseOutQuint(double x)
        {
            return 1.0 - Math.Pow(x, 5);
        }

        public double EaseInOutQuint(double x)
        {
            return (x < 0.5) ? 16 * Math.Pow(x, 5) : 1 - Math.Pow(-2 * x + 2, 5) / 2;
        }

        public double EaseInSine(double x)
        {
            return 1 - Math.Cos(x * Math.PI / 2.0);
        }

        public double EaseOutSine(double x)
        {
            return Math.Sin(x * Math.PI / 2.0);
        }

        public double EaseInOutSine(double x)
        {
            return -(Math.Cos(Math.PI * x) - 1.0) / 2.0;
        }

        public double EaseInExpo(double x)
        {
            return (x == 0) ? 0.0 : Math.Pow(2, 10 * x - 10);
        }

        public double EaseOutExpo(double x)
        {
            return (x == 1) ? 1.0 : 1.0 - Math.Pow(2, -10 * x);
        }

        public double EaseInOutExpo(double x)
        {
            if (x == 0.0) return 0.0;
            if (x == 1.0) return 1.0;
            if (x < 0.5) return Math.Pow(2, 20.0 * x - 10.0) / 2.0;
            return (2.0 - Math.Pow(2, -20.0 * x + 10.0)) / 2.0;
        }

        public double EaseInCirc(double x)
        {
            return 1.0 - Math.Sqrt(1.0 - Math.Pow(x, 2.0));
        }

        public double EaseOutCirc(double x)
        {
            return Math.Sqrt(1.0 - Math.Pow(x - 1.0, 2.0));
        }

        public double EaseInOutCirc(double x)
        {
            return (x < 0.5) ? (1 - Math.Sqrt(1 - Math.Pow(2 * x, 2))) / 2 : (Math.Sqrt(1 - Math.Pow(-2 * x + 2, 2)) + 1) / 2;
        }

        public double EaseInBack(double x)
        {
            return c3 * Math.Pow(x, 3) - c1 * Math.Pow(x, 2);
        }

        public double EaseOutBack(double x)
        {
            return 1 + c3 * Math.Pow(x - 1, 3) + c1 * Math.Pow(x - 1, 2);
        }

        public double EaseInOutBack(double x)
        {
            return (x < 0.5)
                ? (Math.Pow(2 * x, 2) * ((c2 + 1) * 2 * x - c2)) / 2
                : (Math.Pow(2 * x - 2, 2) * ((c2 + 1) * (x * 2 - 2) + c2) + 2) / 2;
        }

        public double EaseInElastic(double x)
        {
            if (x == 0.0) return 0.0;
            if (x == 1.0) return 1.0;
            return -Math.Pow(2, 10 * x - 10) * Math.Sin((x * 10 - 10.75) * c4);
        }

        public double EaseOutElastic(double x)
        {
            if (x == 0.0) return 0.0;
            if (x == 1.0) return 1.0;
            return Math.Pow(2, -10 * x) * Math.Sin((x * 10 - 0.75) * c4) + 1;
        }

        public double EaseInOutElastic(double x)
        {
            if (x == 0.0) return 0.0;
            if (x == 1.0) return 1.0;
            if (x < 0.5) return -(Math.Pow(2, 20 * x - 10) * Math.Sin((20 * x - 11.125) * c5)) / 2.0;
            return (Math.Pow(2, -20 * x + 10) * Math.Sin((20 * x - 11.125) * c5)) / 2 + 1;
        }

        public double EaseInBounce(double x)
        {
            return 1 - BounceOut(1 - x);
        }

        public double EaseOutBounce(double x)
        {
            return BounceOut(x);
        }

        public double EaseInOutBounce(double x)
        {
            return (x < 0.5)
                ? (1 - BounceOut(1 - 2 * x)) / 2
                : (1 + BounceOut(2 * x - 1)) / 2;
        }
    }
}
