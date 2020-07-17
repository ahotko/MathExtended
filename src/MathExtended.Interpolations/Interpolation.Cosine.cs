using MathExtended.Common;
using System;
using System.Collections.Generic;

namespace MathExtended.Interpolations
{
    public class Cosine : IInterpolation
    {
        private List<Cartesian2D> _points;

        public void Calculate(List<Cartesian2D> points)
        {
            _points = points;
            Check();
        }

        public bool Check()
        {
            if (_points.Count < 2)
                throw new ArgumentException("Linear interpolation requires at least 2 points.");
            return true;
        }

        public double Interpolate(double x)
        {
            var interval = PointFunctions.FindInterval(x, _points);
            if (interval.Item1 is null || interval.Item2 is null || interval.Item1.Equals(interval.Item2))
                throw new ArgumentOutOfRangeException($"Wrong interpolation point (x = {x}).");

            double deltaX = interval.Item2.X - interval.Item1.X;

            double _xt = (1.0 - Math.Cos((x - interval.Item1.X) / deltaX * Math.PI)) / 2.0;
            return (interval.Item1.Y * (1.0 - _xt) + interval.Item2.Y * _xt);
        }
    }
}
