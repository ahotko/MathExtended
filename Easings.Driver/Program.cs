using MathExtended.Easings;
using System;
using System.Threading;

namespace Easings.Driver
{
    class Program
    {
        static void Main(string[] args)
        {
            const int maxValue = 100;

            var easings = new EasingFunctions();

            for (int i = 0; i <= maxValue; i++)
            {
                double x = 1.0 * i / maxValue;

                int easedInOutCubic = (int)(easings.EaseInOutCubic(x) * maxValue);
                int easedInBounce = (int)(easings.EaseInBounce(x) * maxValue);
                int easedInElastic = (int)(easings.EaseInElastic(x) * maxValue);

                Console.Write($"\r{i,4} {easedInOutCubic,4} {easedInBounce,4} {easedInElastic,4}      ");
                Thread.Sleep(100);
            }

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
