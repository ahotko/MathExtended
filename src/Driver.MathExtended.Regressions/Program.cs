using MathExtended.Regressions;
using System;

namespace Driver.MathExtended.Regressions
{
    class Program
    {
        private static void RegressionPoly()
        {
            var regression = new PolynomialRegression();
            regression.Add(1.1, 1);
            regression.Add(2, 5);
            regression.Add(5, 7);
            regression.Add(5.5, 8);
            regression.Add(7, 4.3);
            regression.Add(9, 5);

            regression.Degree = 4;

            for (int n = 10; n < 91; n++)
            {
                double regressionValue = regression.Value(n / 10.0);

                Console.WriteLine($"{n:N1};{regressionValue:N3}");
            }
        }

        private static void RegressionTrend()
        {

        }

        static void Main(string[] args)
        {
            RegressionPoly();
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
