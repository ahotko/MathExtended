﻿using MathExtended.Common;
using MathExtended.Easings;
using System;
using System.Text;
using System.Threading;

namespace Driver.MathExtended.Easings
{
    class Program
    {
        private static string StarPosition(double x, double maxValue)
        {
            int bufferWidth = 15;
            int maxWidth = Console.BufferWidth - 15;
            int spanWidth = maxWidth - 2 * bufferWidth;

            int starPos = (int)Math.Round(spanWidth * x / maxValue) + bufferWidth;
            if (starPos < 0) starPos = 0;
            if (starPos > maxWidth) starPos = maxWidth;

            string line = new string(' ', maxWidth);
            return line.Substring(0, starPos) + "*" + line.Substring(starPos, line.Length - starPos);
        }

        static void Main(string[] args)
        {
            const int maxValue = 1000;

            var easings = new EasingFunctions();

            Console.OutputEncoding = Encoding.UTF8;

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

                int easedInOutElasticMapped = (int)Mapping.Map(easings.EaseInOutElastic(x), 0.0, 1.0, 0.0, maxValue);

                Console.CursorTop = 2;

                Console.Write($"\r");
                Console.Write($"{i,6} ");
                Console.Write($"{easedInOutQuad,6} ");
                Console.Write($"{easedInOutCubic,6} ");
                Console.Write($"{easedInOutQuart,6} ");
                Console.Write($"{easedInOutQuint,6} ");

                Console.Write($"{easedInOutBounce,6} ");
                Console.Write($"{easedInOutElastic,6} ");
                Console.Write($"{easedInOutExpo,6} ");
                Console.Write($"{easedInOutCirc,6} ");
                Console.Write($"{easedInOutBack,6} ");
                Console.Write($"{easedInOutSine,6} ");

                Console.Write($"{easedInOutElasticMapped,6} ");

                Console.WriteLine();
                Console.WriteLine($"===================================================================================");

                Console.WriteLine();

                Console.WriteLine($"\rLinear    : {StarPosition(x, 1)}");
                Console.WriteLine($"\rInOutQuad : {StarPosition(easedInOutQuad, maxValue)}");
                Console.WriteLine($"\rInOutCubic: {StarPosition(easedInOutCubic, maxValue)}");
                Console.WriteLine($"\rInOutQuart: {StarPosition(easedInOutQuart, maxValue)}");
                Console.WriteLine($"\rInOutQuint: {StarPosition(easedInOutQuint, maxValue)}");

                Console.WriteLine($"\rInOutBounc: {StarPosition(easedInOutBounce, maxValue)}");
                Console.WriteLine($"\rInOutElast: {StarPosition(easedInOutElastic, maxValue)}");
                Console.WriteLine($"\rInOutExpo : {StarPosition(easedInOutExpo, maxValue)}");
                Console.WriteLine($"\rInOutCirc : {StarPosition(easedInOutCirc, maxValue)}");
                Console.WriteLine($"\rInOutBack : {StarPosition(easedInOutBack, maxValue)}");
                Console.WriteLine($"\rInOutSine : {StarPosition(easedInOutSine, maxValue)}");

                Thread.Sleep(5);
            }

            Console.CursorVisible = true;

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
