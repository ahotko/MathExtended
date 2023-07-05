using MathExtended.Common;
using System;
using System.Text;

namespace Driver.MathExtended.Common
{
    class Program
    {
        private static void ClampingTest()
        {
            Console.WriteLine($"Clamping Functions");
            Console.WriteLine();
            Console.WriteLine($"    x   default    limits    SmoothStep3    SmoothStep5    SmoothStep7    SmterStep");
            Console.WriteLine($"===================================================================================");

            //clamping
            for (double x = -5.0; x < 5.0; x += 0.1)
            {
                double clampDefault = Clamping.Clamp(x);
                double clampLimited = Clamping.Clamp(x, -2.0, 1.5);
                double smoothStep = Clamping.SmoothStep(x); //same as SmoothStep3
                double smoothStep3 = Clamping.SmoothStep3(x, -2.0, 2.0);
                double smoothStep5 = Clamping.SmoothStep5(x, -2.0, 2.0);
                double smoothStep7 = Clamping.SmoothStep7(x, -2.0, 2.0);
                double smootherStep = Clamping.SmootherStep(x, -2.0, 2.0);

                Console.WriteLine($"{x,5:N1} {clampDefault,9:N1} {clampLimited,9:N1} {smoothStep3,14:N3} {smoothStep5,14:N3} {smoothStep7,14:N3} {smootherStep,12:N3}");
            }

            Console.WriteLine($"===================================================================================");

            Console.CursorVisible = true;

            for (double x = -0.5; x <= 1.5; x += 0.1)
            {
                double clampDefault = Clamping.Clamp(x);
                double clampLimited = Clamping.Clamp(x, -2.0, 1.5);
                double smoothStep = Clamping.SmoothStep(x); //same as SmoothStep3
                double smoothStep3 = Clamping.SmoothStep3(x);
                double smoothStep5 = Clamping.SmoothStep5(x);
                double smoothStep7 = Clamping.SmoothStep7(x);
                double smootherStep = Clamping.SmootherStep(x);

                Console.WriteLine();
                Console.WriteLine($"Clamping.Clamp({x:N1}) = {clampDefault:N3}");
                Console.WriteLine($"Clamping.Clamp({x:N1}, -2.0, 1.5) = {clampLimited:N3}");
                Console.WriteLine($"Clamping.SmoothStep({x:N1}) = {smoothStep:N3}");
                Console.WriteLine($"Clamping.SmoothStep3({x:N1}) = {smoothStep3:N3}");
                Console.WriteLine($"Clamping.SmoothStep5({x:N1}) = {smoothStep5:N3}");
                Console.WriteLine($"Clamping.SmoothStep7({x:N1}) = {smoothStep7:N3}");
                Console.WriteLine($"Clamping.SmootherStep({x:N1}) = {smootherStep:N3}");
            }
        }

        private static void MappingTest()
        {
            Console.WriteLine($"Mapping Functions");
            Console.WriteLine();
            Console.WriteLine($"    x    mapped");
            Console.WriteLine($"===================================================================================");

            for (double x = -5.0; x <= 5.0; x += 0.5)
            {
                double mapping1 = Mapping.Map(x, -5.0, 5.0, 3.0, 8.0);

                Console.WriteLine($"{x,5:N1} {mapping1,9:N1}");
            }

            Console.WriteLine($"===================================================================================");
        }

        private static void WrappingTest()
        {
            Console.WriteLine($"Wrapping Functions");
            Console.WriteLine();
            Console.WriteLine($"    x    wrapped");
            Console.WriteLine($"===================================================================================");

            for (double x = -5.0; x <= 5.0; x += 0.5)
            {
                double wrapping = Wrapping.Wrap(x, -1, 1);

                Console.WriteLine($"{x,5:N1} {wrapping,9:N1}");
            }

            Console.WriteLine($"===================================================================================");
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;

            ClampingTest();
            Console.WriteLine();

            MappingTest();
            Console.WriteLine();

            WrappingTest();
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
