using MathExtended.Statistics;
using System;
using System.Text;

namespace Driver.MathExtended.Statistics
{
    class Program
    {
        private static void GenerateHistogram(Histogram histogram, NumberOfBins bins, bool cumulative = false)
        {
            var sb = new StringBuilder((cumulative ? "Cumulative " : ""));
            sb.Append(bins).Append(", ");
            sb.Append($"{histogram.Distribution.Count} elements, ");
            sb.Append($"x\u0305 = {histogram.Distribution.Average:N3}, ");
            sb.Append($"\u03C3 = {histogram.Distribution.StandardDeviation:N3}, ");
            sb.Append($"Variance = {histogram.Distribution.Variance:N3}, ");
            sb.AppendLine($"Skewness = {histogram.Distribution.Skewness:N3}");
            sb.Append($"m\u2081 = {histogram.Distribution.FirstMoment:N3}, ");
            sb.Append($"m\u2082 = {histogram.Distribution.SecondMoment:N3}, ");
            sb.Append($"m\u2083 = {histogram.Distribution.ThirdMoment:N3} ");

            Console.WriteLine($"===============================================================");
            Console.WriteLine(sb.ToString());
            Console.WriteLine($"===============================================================");
            Console.WriteLine($"n             bin\u2265         bin\u2264          Count");
            Console.WriteLine($"===============================================================");

            var histo = histogram.Generate(bins, cumulative);

            int bin = 0;

            foreach (var value in histo)
            {
                double binFrom = histogram.Distribution.MinValue + bin * histogram.BinWidth;
                double binTo = histogram.Distribution.MinValue + (bin + 1) * histogram.BinWidth;

                Console.WriteLine($"{bin,-5}   {binFrom,10:N3}   {binTo,10:N3}     {histo[bin],10}");
                bin++;
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var random = new Random();

            int count = random.Next(500, 1500);

            double[] _testArray = new double[count];

            for (int n = 0; n < count; n++)
            {
                _testArray[n] = random.NextGaussian() * 15;
                //_testArray[n] = random.NextDouble() * 15;
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
