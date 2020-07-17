using MathExtended.Interpolations;
using System;

namespace Driver.MathExtended.Interpolations
{
    class Program
    {
        private static void InterpolationSnippets()
        {
            var interpolation = new Interpolation();
            interpolation.Add(1, 2);
            interpolation.Add(5, 8);
            interpolation.Add(7.7, 5);
            interpolation.Add(10, 15);
            interpolation.Add(11, 11.3);

            Console.WriteLine($"Value;Linear;Spline;Cosine");

            for (int n = 10; n < 111; n++)
            {
                double interpolatedValueLinear = interpolation.Linear(n / 10.0);
                double interpolatedValueSpline = interpolation.Spline(n / 10.0);
                double interpolatedValueCosine = interpolation.Cosine(n / 10.0);


                if (n == 10 || n == 50 || n == 77 || n == 100 || n == 110)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                Console.WriteLine($"{n / 10.0:N1};{interpolatedValueLinear:N3};{interpolatedValueSpline:N3};{interpolatedValueCosine:N3}");

                Console.ResetColor();
            }
        }

        private static void InterpolationSnippetsRandomPoints()
        {
            var interpolation = new Interpolation();

            var random = new Random();

            double startingX = random.NextDouble() * 10.0;
            double x = startingX;

            int xStartInterval = (int)Math.Ceiling(startingX * 10.0);
            int xEndInterval = (int)Math.Floor(x * 10.0) - 1;

            //add 10 random points
            for (int n = 0; n < 30; n++)
            {
                double y = random.NextDouble() * 50.0;
                interpolation.Add(x, y);

                xEndInterval = (int)Math.Floor(x * 10.0) - 1;
                x += random.NextDouble() * 10.0;
                x += 1.0; //ensure the horizontal distance, not needed, but because it's random values
            }

            Console.WriteLine($"Value;Linear;Spline;Cosine");

            for (int n = xStartInterval; n < xEndInterval; n++)
            {
                double interpolatedValueLinear = interpolation.Linear(n / 10.0);
                double interpolatedValueSpline = interpolation.Spline(n / 10.0);
                double interpolatedValueCosine = interpolation.Cosine(n / 10.0);

                Console.WriteLine($"{n / 10.0:N1};{interpolatedValueLinear:N3};{interpolatedValueSpline:N3};{interpolatedValueCosine:N3}");
            }
        }

        private static void InterpolationSnippetsActualTemperature()
        {
            var interpolation = new Interpolation();

            #region [Temperature Points]
            interpolation.Add(0, 24.9);
            interpolation.Add(10, 24.8);
            interpolation.Add(20, 24.8);
            interpolation.Add(29, 24.8);
            interpolation.Add(40, 24.9);
            interpolation.Add(50, 25.1);
            interpolation.Add(60, 25.3);
            interpolation.Add(69, 25.4);
            interpolation.Add(79, 25.6);
            interpolation.Add(90, 25.7);
            interpolation.Add(100, 25.8);
            interpolation.Add(110, 25.7);
            interpolation.Add(120, 25.8);
            interpolation.Add(129, 25.7);
            interpolation.Add(140, 25.6);
            interpolation.Add(150, 25.4);
            interpolation.Add(160, 25.2);
            interpolation.Add(169, 25);
            interpolation.Add(180, 24.8);
            interpolation.Add(190, 24.6);
            interpolation.Add(200, 24.5);
            interpolation.Add(210, 24.4);
            interpolation.Add(220, 24.2);
            interpolation.Add(229, 24.1);
            interpolation.Add(239, 23.9);
            interpolation.Add(250, 23.8);
            interpolation.Add(260, 23.7);
            interpolation.Add(269, 23.6);
            interpolation.Add(280, 23.4);
            interpolation.Add(290, 23.2);
            interpolation.Add(300, 22.9);
            interpolation.Add(309, 22.6);
            interpolation.Add(320, 22.4);
            interpolation.Add(330, 22.1);
            interpolation.Add(339, 21.9);
            interpolation.Add(350, 21.9);
            interpolation.Add(360, 21.8);
            interpolation.Add(370, 21.7);
            interpolation.Add(380, 21.7);
            interpolation.Add(390, 21.7);
            interpolation.Add(400, 21.6);
            interpolation.Add(409, 21.5);
            interpolation.Add(419, 21.3);
            interpolation.Add(430, 21.2);
            interpolation.Add(440, 21.1);
            interpolation.Add(449, 21);
            interpolation.Add(460, 20.9);
            interpolation.Add(470, 20.8);
            interpolation.Add(479, 20.7);
            interpolation.Add(490, 20.4);
            interpolation.Add(500, 20.3);
            interpolation.Add(509, 20.2);
            interpolation.Add(520, 19.9);
            interpolation.Add(530, 19.7);
            interpolation.Add(539, 19.6);
            interpolation.Add(550, 19.4);
            interpolation.Add(554, 19.4);
            interpolation.Add(570, 19.3);
            interpolation.Add(580, 19.3);
            interpolation.Add(589, 19.3);
            interpolation.Add(600, 19.2);
            interpolation.Add(604, 19.2);
            interpolation.Add(620, 19.2);
            interpolation.Add(629, 19.1);
            interpolation.Add(640, 19.1);
            interpolation.Add(650, 19.1);
            interpolation.Add(659, 19.1);
            interpolation.Add(670, 19.1);
            interpolation.Add(680, 19);
            interpolation.Add(690, 18.9);
            interpolation.Add(700, 18.9);
            interpolation.Add(709, 18.8);
            interpolation.Add(720, 18.8);
            interpolation.Add(730, 18.8);
            interpolation.Add(740, 18.8);
            interpolation.Add(749, 18.8);
            interpolation.Add(760, 18.7);
            interpolation.Add(770, 18.7);
            interpolation.Add(775, 18.7);
            interpolation.Add(789, 18.6);
            interpolation.Add(800, 18.6);
            interpolation.Add(810, 18.6);
            interpolation.Add(819, 18.6);
            interpolation.Add(829, 18.6);
            interpolation.Add(840, 18.6);
            interpolation.Add(850, 18.6);
            interpolation.Add(859, 18.6);
            interpolation.Add(870, 18.6);
            interpolation.Add(880, 18.6);
            interpolation.Add(889, 18.7);
            interpolation.Add(899, 18.7);
            interpolation.Add(910, 18.7);
            interpolation.Add(919, 18.6);
            interpolation.Add(930, 18.5);
            interpolation.Add(940, 18.6);
            interpolation.Add(950, 18.6);
            interpolation.Add(959, 18.6);
            interpolation.Add(970, 18.6);
            interpolation.Add(980, 18.4);
            interpolation.Add(989, 18.4);
            interpolation.Add(1000, 18.2);
            interpolation.Add(1010, 18);
            interpolation.Add(1019, 17.8);
            interpolation.Add(1030, 17.6);
            interpolation.Add(1040, 17.4);
            interpolation.Add(1049, 17.3);
            interpolation.Add(1060, 17.3);
            interpolation.Add(1069, 17.4);
            interpolation.Add(1080, 17.3);
            interpolation.Add(1090, 17.3);
            interpolation.Add(1100, 17.4);
            interpolation.Add(1109, 17.4);
            interpolation.Add(1120, 17.5);
            interpolation.Add(1129, 17.5);
            interpolation.Add(1139, 17.4);
            interpolation.Add(1150, 17.6);
            interpolation.Add(1159, 17.7);
            interpolation.Add(1170, 17.7);
            interpolation.Add(1180, 17.7);
            interpolation.Add(1190, 17.7);
            interpolation.Add(1199, 17.7);
            interpolation.Add(1210, 17.7);
            interpolation.Add(1219, 17.7);
            interpolation.Add(1230, 17.9);
            interpolation.Add(1240, 18);
            interpolation.Add(1249, 18.2);
            interpolation.Add(1260, 18.3);
            interpolation.Add(1270, 18.2);
            interpolation.Add(1279, 18.3);
            interpolation.Add(1289, 18.6);
            interpolation.Add(1300, 18.7);
            interpolation.Add(1310, 18.9);
            interpolation.Add(1319, 19.2);
            interpolation.Add(1329, 19.3);
            interpolation.Add(1340, 19.4);
            interpolation.Add(1350, 19.4);
            interpolation.Add(1359, 19.6);
            interpolation.Add(1370, 19.8);
            interpolation.Add(1380, 19.9);
            interpolation.Add(1390, 20.1);
            interpolation.Add(1400, 20.3);
            interpolation.Add(1409, 20.4);
            interpolation.Add(1419, 20.6);
            interpolation.Add(1429, 20.6);
            #endregion

            Console.WriteLine($"Value;Linear;Spline;Cosine");

            for (int n = 0; n < 1430; n++)
            {
                double interpolatedValueLinear = interpolation.Linear(n);
                double interpolatedValueSpline = interpolation.Spline(n);
                double interpolatedValueCosine = interpolation.Cosine(n);

                Console.WriteLine($"{n:N1};{interpolatedValueLinear:N3};{interpolatedValueSpline:N3};{interpolatedValueCosine:N3}");
            }
        }

        static void Main(string[] args)
        {
            InterpolationSnippets();
            Console.WriteLine();

            InterpolationSnippetsRandomPoints();
            Console.WriteLine();

            InterpolationSnippetsActualTemperature();
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
