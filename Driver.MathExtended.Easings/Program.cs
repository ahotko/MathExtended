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

            Console.CursorVisible = false;

            Console.WriteLine($"Linear Quadra  Cubic  Quart  Quint Bounce Elasti   Expo   Circ   Back   Sine Mapped");
            Console.WriteLine($"===================================================================================");

            for (int i = 0; i <= maxValue; i++)
            {
                double x = 1.0 * i / maxValue;

                int easedInOutQuad = (int)(easings.EaseInOutQuad(x) * maxValue);
                int easedInOutCubic = (int)(easings.EaseInOutCubic(x) * maxValue);
                int easedInOutQuart = (int)(easings.EaseInOutQuart(x) * maxValue);
                int easedInOutQuint = (int)(easings.EaseInOutQuint(x) * maxValue);

                int easedInOutBounce = (int)(easings.EaseInOutBounce(x) * maxValue);
                int easedInOutElastic = (int)(easings.EaseInOutElastic(x) * maxValue);
                int easedInOutExpo = (int)(easings.EaseInOutExpo(x) * maxValue);
                int easedInOutCirc = (int)(easings.EaseInOutCirc(x) * maxValue);
                int easedInOutBack = (int)(easings.EaseInOutBack(x) * maxValue);
                int easedInOutSine = (int)(easings.EaseInOutSine(x) * maxValue);
                
                int easedInOutElasticMapped = (int)(easings.Mapping(i, easings.EaseInOutElastic, 0, maxValue, 0, maxValue));

                Console.Write($"\r");
                Console.Write($"{i,6} ");
                Console.Write($"{easedInOutQuad,6} ");
                Console.Write($"{ easedInOutCubic,6} ");
                Console.Write($"{easedInOutQuart,6} ");
                Console.Write($"{easedInOutQuint,6} ");

                Console.Write($"{easedInOutBounce,6} ");
                Console.Write($"{easedInOutElastic,6} ");
                Console.Write($"{easedInOutExpo,6} ");
                Console.Write($"{easedInOutCirc,6} ");
                Console.Write($"{easedInOutBack,6} ");
                Console.Write($"{easedInOutSine,6} ");

                Console.Write($"{easedInOutElasticMapped,6} ");
                Console.Write($"      ");
                Thread.Sleep(10);
            }

            Console.CursorVisible = true;

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
