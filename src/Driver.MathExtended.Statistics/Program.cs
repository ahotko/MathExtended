using MathExtended.Statistics;
using System;

namespace Driver.MathExtended.Statistics
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] _testArray = { 2.55, 3.05, 7.89, 1.84, 9.38, 7.94, 9.26, 6.48, 4.96, 1.76, 6.35, 4.22, 2.29, 9.68, 7.69, 5.56, 3.54, 8.08, 9.35, 3.87, 6, 5.22, 1.87, 3.6, 9.47, 5.79, 7.91, 8.41, 2.34, 1.54, 3.94, 8.87, 7.83, 7.41, 7.1, 3.46, 3.73, 3.48, 3.38, 4.22, 6.91, 1.1, 2.42, 4.81, 8.14, 6.39, 4.97, 3.02, 5.69, 2.26 };

            var histogram = new Histogram();
            histogram.AddRange(_testArray);

            var histo = histogram.Generate(NumberOfBins.SquareRoot);

            int bin = 0;

            foreach(var value in histo)
            {
                double binFrom = bin * histogram.BinWidth;
                double binTo = (bin+1) * histogram.BinWidth;

                Console.WriteLine($"{bin}   {binFrom:N3}   {binTo:N3}     {histo[bin]}");
                bin++;
            }

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
