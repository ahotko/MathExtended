using MathExtended.Common;
using System;
using System.Collections.Generic;

namespace MathExtended.Interpolations
{
    /// <summary>
    /// Parabolit interpolation, which requires exactly 3 points between which the parabola is fit
    /// </summary>
    public class Parabolic : IInterpolation
    {
        private List<Cartesian2D> _points;

        private double _a;
        private double _b;
        private double _c;

        private void CalculateFactors()
        {
            var A = _points[0];
            var B = _points[1];
            var C = _points[2];

            double D = A.X * A.X * B.X + A.X * C.X * C.X +
                       B.X * B.X * C.X - B.X * C.X * C.X -
                       A.X * A.X * C.X - A.X * B.X * B.X;
            double Da = A.Y * B.X + A.X * C.Y + B.Y * C.X -
                        B.X * C.Y - A.Y * C.X - A.X * B.Y;
            double Db = A.X * A.X * B.Y + A.Y * C.X * C.X +
                        B.X * B.X * C.Y - B.Y * C.X * C.X -
                        A.X * A.X * C.Y - A.Y * B.X * B.X;
            double Dc = A.X * A.X * B.X * C.Y + A.X * B.Y * C.X * C.X +
                        A.Y * B.X * B.X * C.X - A.Y * B.X * C.X * C.X -
                        A.X * A.X * B.Y * C.X - A.X * B.X * B.X * C.Y;
            try
            {
                _a = Da / D;
                _b = Db / D;
                _c = Dc / D;
            }
            catch (Exception)
            {
                throw new ArgumentOutOfRangeException();
            }
        }


        public double Interpolate(double x)
        {
            return _a * Math.Pow(x, 2) + _b * x + _c;
        }

        public bool Check()
        {
            if (_points.Count != 3)
                throw new ArgumentException("Parabolic interpolation requires exactly 3 points.");
            return true;
        }

        public void Calculate(List<Cartesian2D> points)
        {
            _points = points;
            Check();
            CalculateFactors();
        }
    }

}
