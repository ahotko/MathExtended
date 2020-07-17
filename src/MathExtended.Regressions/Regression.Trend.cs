using MathExtended.Common;
using System;
using System.Collections.Generic;

namespace MathExtended.Regressions
{
    public class LinearTrend
    {
        private bool _changed = true;
        private List<Cartesian2D> _points = new List<Cartesian2D>();
        private double _k = 0.0;
        private double _n = 0.0;

        private void Sort()
        {
            _points.Sort((a, b) => a.X.CompareTo(b.X));
        }

        private void Calculate()
        {
            if (_changed)
            {
                Sort();
                //https://math.stackexchange.com/questions/204020/what-is-the-equation-used-to-calculate-a-linear-trendline
                int _len = _points.Count;
                double _sumX = 0.0;
                double _sumX2 = 0.0;
                double _sumY = 0.0;
                double _sumXY = 0.0;
                for (int n = 0; n < _len; n++)
                {
                    _sumX += _points[n].X;
                    _sumX2 += Math.Pow(_points[n].X, 2);
                    _sumY += _points[n].Y;
                    _sumXY += (_points[n].X * _points[n].Y);
                }
                _k = (_len * _sumXY - _sumX * _sumY) / (_len * _sumX2 - Math.Pow(_sumX, 2));
                _n = (_sumY - _k * _sumX) / _len;
                _changed = false;
            }
        }

        public void Add(double ValueX, double ValueY)
        {
            _points.Add(new Cartesian2D(ValueX, ValueY));
            _changed = true;
        }

        public void Add(double[] ValuesX, double[] ValuesY)
        {
            for (int n = 0; n < ValuesX.Length; n++)
            {
                _points.Add(new Cartesian2D(ValuesX[n], ValuesY[n]));
            }
            _changed = true;
        }

        public void Add(Dictionary<double, double> Values)
        {
            foreach (KeyValuePair<double, double> _pair in Values)
            {
                _points.Add(new Cartesian2D(_pair.Key, _pair.Value));
            }
            _changed = true;
        }

        public void Clear()
        {
            _points.Clear();
        }

        public LinearTrend()
        {
            Clear();
        }

        public LinearTrend(Dictionary<double, double> Values)
        {
            Clear();
            Add(Values);
        }

        public LinearTrend(double[] ValuesX, double[] ValuesY)
        {
            Clear();
            Add(ValuesX, ValuesY);
        }

        public LinearTrend(double X1, double Y1, double X2, double Y2)
        {
            Clear();
            Add(X1, Y1);
            Add(X2, Y2);
        }

        public double Value(double x)
        {
            if (_points.Count < 2)
                throw new ArgumentOutOfRangeException("points", "Not enough data points.");
            Calculate();
            return _k * x + _n;
        }
    }
}
