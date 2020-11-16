using MathExtended.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driver.MathExtended.Common
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.OutputEncoding = Encoding.UTF8;

            Console.CursorVisible = false;

            Console.WriteLine($"    x   default    limits    SmoothStep3    SmoothStep5    SmoothStep7    SmterStep");
            Console.WriteLine($"===================================================================================");

            //clamping
            for (double x = -5.0; x<5.0; x += 0.1)
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

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
