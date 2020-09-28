using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtended.Statistics
{
    public enum NumberOfBins
    {
        Default,
        BinWidth,
        SquareRoot,
        Sturges,
        RiceRule,
        ScottsNormalReferenceRule
    }

    public class Histogram
    {
        private List<double> _values;

        public int BinCount { get; private set; }
        public double BinWidth { get; private set; }
        public Distribution Distribution { get; private set; }

        public Histogram()
        {
            Distribution = new Distribution();
            _values = new List<double>();
        }

        public void Add(double value)
        {
            AddRange(new double[] { value });
        }

        public void AddRange(IEnumerable<double> values)
        {
            _values.AddRange(values);
            Distribution.AddRange(values);
        }

        public void Clear()
        {
            _values.Clear();
            Distribution.Clear();

            BinCount = 0;
            BinWidth = 0.0;
        }

        private int CalculateBinCount()
        {
            if (BinWidth <= 0.0) throw new ArgumentOutOfRangeException(nameof(BinWidth));
            return (int)Math.Ceiling((Distribution.MaxValue - Distribution.MinValue) / BinWidth);
        }

        private int CalculateBinCount(NumberOfBins bins)
        {
            int n = _values.Count();

            switch (bins)
            {
                case NumberOfBins.BinWidth:
                    return CalculateBinCount();
                case NumberOfBins.Sturges:
                    return (int)Math.Ceiling(Math.Log(n) / Math.Log(2)) + 1;
                case NumberOfBins.RiceRule:
                    return (int)Math.Ceiling(2.0 * Math.Pow(n, 1.0 / 3.0));
                case NumberOfBins.ScottsNormalReferenceRule:
                    BinWidth = 3.49 * Distribution.StandardDeviation / Math.Pow(n, 1.0 / 3.0);
                    return CalculateBinCount();
                case NumberOfBins.SquareRoot:
                case NumberOfBins.Default:
                default:
                    return (int)Math.Ceiling(Math.Sqrt(n));
            }
        }

        public int[] Generate(NumberOfBins bins, bool cumulative = false)
        {
            BinCount = CalculateBinCount(bins);
            if (bins != NumberOfBins.BinWidth)
            {
                BinWidth = (Distribution.MaxValue - Distribution.MinValue) / BinCount;
            }

            var result = new int[BinCount];
            Array.Clear(result, 0, BinCount);

            foreach (double x in _values)
            {
                int index = (int)Math.Floor((x - Distribution.MinValue) / BinWidth);
                if (index == BinCount) index--;
                result[index]++;
            }

            if (cumulative)
            {
                int sum = 0;
                for (int n = 0; n < BinCount; n++)
                {
                    sum += result[n];
                    result[n] = sum;
                }
            }

            return result;
        }

        public int[] Generate(double binWidth, bool cumulative = false)
        {
            BinWidth = binWidth;

            return Generate(NumberOfBins.BinWidth, cumulative);
        }
    }
}
