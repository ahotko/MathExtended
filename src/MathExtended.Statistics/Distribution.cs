using System;
using System.Collections.Generic;

namespace MathExtended.Statistics
{
    public class Distribution
    {
        private double _sumOfSquares;
        private double _sum;

        public void Clear()
        {
            _sumOfSquares = 0.0;
            _sum = 0.0;
            Count = 0;
            MaxValue = double.MinValue;
            MinValue = double.MaxValue;
        }

        public void AddRange(IEnumerable<double> values)
        {
            foreach (double value in values) Add(value);
        }

        public void AddRange(IEnumerable<float> values)
        {
            foreach (float value in values) Add(value);
        }

        public void Add(double value)
        {
            _sum += value;
            _sumOfSquares += Math.Pow(value, 2);
            Count++;
            //
            if (value < MinValue) MinValue = value;
            if (value > MaxValue) MaxValue = value;
        }

        public int Count { get; private set; }
        public double Average => (_sum / Count);
        public double StandardDeviation
        {
            get
            {
                if (Count < 2) return double.NaN;

                double average = Average; //so it's calculated only once

                return Math.Sqrt((Count * Math.Pow(average, 2) - 2 * average * _sum + _sumOfSquares) / (Count - 1));
            }
        }

        public double MaxValue { get; private set; }
        public double MinValue { get; private set; }
        public double Width => MaxValue - MinValue;

        /// <summary>
        /// Calculates value for Gauss (Normal) distribution for given x value
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public double Gauss(double x)
        {
            //Source: https://en.wikipedia.org/wiki/Normal_distribution

            double stdDev = StandardDeviation;
            double avg = Average;

            return (1.0 / (stdDev * Math.Sqrt(2.0 * Math.PI))) * Math.Exp(-0.5 * Math.Pow((x - avg) / stdDev, 2));
        }
    }
}
