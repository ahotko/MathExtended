using MathExtended.Easings;
using System;
using System.Threading;

namespace Driver.MathExtended.Easings
{
    class Program
    {
        static void Main(string[] args)
        {
            const int maxValue = 1000;

            var easings = new EasingFunctions();

            Console.WriteLine($"Linear Quadra  Cubic  Quart  Quint Bounce Elasti");
            Console.WriteLine($"================================================");

            for (int i = 0; i <= maxValue; i++)
            {
                double x = 1.0 * i / maxValue;

                int easedInOutQuad = (int)(easings.EaseInOutQuad(x) * maxValue);
                int easedInOutCubic = (int)(easings.EaseInOutCubic(x) * maxValue);
                int easedInOutQuart = (int)(easings.EaseInOutQuart(x) * maxValue);
                int easedInOutQuint = (int)(easings.EaseInOutQuint(x) * maxValue);

                int easedInOutBounce = (int)(easings.EaseInOutBounce(x) * maxValue);
                int easedInOutElastic = (int)(easings.EaseInOutElastic(x) * maxValue);

                Console.Write($"\r{i,6} {easedInOutQuad,6} {easedInOutCubic,6} {easedInOutQuart,6} {easedInOutQuint,6} {easedInOutBounce,6} {easedInOutElastic,6}      ");
                Thread.Sleep(10);
            }

            Console.WriteLine();
            Console.WriteLine($"================================================");
            Console.ReadKey();
        }
    }
}
