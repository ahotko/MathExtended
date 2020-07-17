using MathExtended.Common;
using System;
using System.Collections.Generic;

namespace MathExtended.Interpolations
{
    public class Spline : IInterpolation
    {
        private double[] _derivatives;
        private List<Cartesian2D> _points;

        private void CalculateSpline()
        {
                _derivatives = new double[_points.Count];
                var _upperTriangle = new double[_points.Count];
                //
                _derivatives[0] = 0.0;
                _upperTriangle[0] = 0.0;
                for (int n = 1; n < (_points.Count - 1); n++)
                {
                    try
                    {
                        double _leftXFraction = (_points[n].X - _points[n - 1].X) / (_points[n + 1].X - _points[n - 1].X);
                        double _tmp = _leftXFraction * _derivatives[n - 1] + 2.0;
                        _derivatives[n] = (_leftXFraction - 1.0) / _tmp;
                        _upperTriangle[n] =
                            (_points[n + 1].Y - _points[n].Y) /
                            (_points[n + 1].X - _points[n].X) -
                            (_points[n].Y - _points[n - 1].Y) /
                            (_points[n].X - _points[n - 1].X);
                        _upperTriangle[n] = (6.0 * _upperTriangle[n] / (_points[n + 1].X - _points[n - 1].X) - _leftXFraction * _upperTriangle[n - 1]) / _tmp;
                    }
                    catch (Exception)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
                _derivatives[_points.Count - 1] = 0.0;
                for (int i = _points.Count - 2; i >= 0; i--)
                {
                    _derivatives[i] = _derivatives[i] * _derivatives[i + 1] + _upperTriangle[i];
                }
        }

        public double Interpolate(double x)
        {

            var _interval = PointFunctions.FindIntervalIndex(x, _points);
            int _idxLeft = _interval.Item1;
            int _idxRight = _interval.Item2;

            //width of bracketing interval
            double _dX = _points[_idxRight].X - _points[_idxLeft].X;
            if (_dX == 0.0)
                throw new ArgumentOutOfRangeException($"Two points have the same X value (x={x}).");

            double _rightX = (_points[_idxRight].X - x) / _dX;
            double _leftX = (x - _points[_idxLeft].X) / _dX;
            double _result = _rightX * _points[_idxLeft].Y +
                             _leftX * _points[_idxRight].Y +
                             ((Math.Pow(_rightX, 3) - _rightX) * _derivatives[_idxLeft] +
                             (Math.Pow(_leftX, 3) - _leftX) * _derivatives[_idxRight]) *
                              Math.Pow(_dX, 2) / 6.0;
            return _result;
        }

        public bool Check()
        {
            if (_points.Count < 3)
                throw new ArgumentOutOfRangeException("points", "Not enough data points.");
            return true;
        }

        public void Calculate(List<Cartesian2D> points)
        {
            _points = points;
            CalculateSpline();
        }
    }
}
