using MathExtended.Statistics;
using System;

namespace Driver.MathExtended.Statistics
{
    class Program
    {
        private static void GenerateHistogram(Histogram histogram, NumberOfBins bins, bool cumulative = false)
        {
            Console.WriteLine($"===============================================================");
            Console.WriteLine($"{(cumulative ? "Cumulative " : "")}{bins}, {histogram.Distribution.Count} elements");
            Console.WriteLine($"===============================================================");

            var histo = histogram.Generate(bins, cumulative);

            int bin = 0;

            foreach (var value in histo)
            {
                double binFrom = bin * histogram.BinWidth;
                double binTo = (bin + 1) * histogram.BinWidth;

                Console.WriteLine($"{bin}   {binFrom:N3}   {binTo:N3}     {histo[bin]}");
                bin++;
            }
        }

        static void Main(string[] args)
        {
            var random = new Random();

            int count = random.Next(500, 1500);

            double[] _testArray = new double[count];

            for (int n = 0; n < count; n++)
            {
                _testArray[n] = random.NextGaussian() * 15;
            }

            var histogram = new Histogram();
            histogram.AddRange(_testArray);

            GenerateHistogram(histogram, NumberOfBins.SquareRoot);
            GenerateHistogram(histogram, NumberOfBins.SquareRoot, true);

            GenerateHistogram(histogram, NumberOfBins.Sturges);
            GenerateHistogram(histogram, NumberOfBins.RiceRule);
            GenerateHistogram(histogram, NumberOfBins.ScottsNormalReferenceRule);

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
