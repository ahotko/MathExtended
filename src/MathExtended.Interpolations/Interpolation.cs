using MathExtended.Common;
using System;
using System.Collections.Generic;

namespace MathExtended.Interpolations
{
    public class Interpolation
    {
        protected bool Changed { get; set; }

        protected int PointsCount => Points.Count;

        protected List<Cartesian2D> Points { get; set; } = new List<Cartesian2D>();

        private IInterpolation _interpolationStrategy;

        private IInterpolation _linearInterpolation = null;
        private IInterpolation _splineInterpolation = null;
        private IInterpolation _cosineInterpolation = null;
        private IInterpolation _parabolicInterpolation = null;

        public Interpolation()
        {
            Clear();
        }

        public Interpolation(Dictionary<double, double> values)
        {
            Clear();
            Add(values);
        }

        public Interpolation(double[] x, double[] y)
        {
            Clear();
            Add(x, y);
        }

        public Interpolation(double x1, double y1, double x2, double y2)
        {
            Clear();
            Add(x1, y1);
            Add(x2, y2);
        }

        private void Sort()
        {
            Points.Sort((a, b) => a.X.CompareTo(b.X));
        }

        public void Add(double x, double y)
        {
            Points.Add(new Cartesian2D(x, y));
            Changed = true;
        }

        public void Add(double[] x, double[] y)
        {
            if ((x.Length != y.Length) || (x.Length == 0) || (y.Length == 0))
                throw new ArgumentException("Lengths of X and Y coordinate values must be the same");
            for (int n = 0; n < x.Length; n++)
            {
                Points.Add(new Cartesian2D() { X = x[n], Y = y[n] });
            }
            Changed = true;
        }

        public void Add(Dictionary<double, double> values)
        {
            foreach (KeyValuePair<double, double> _pair in values)
            {
                Points.Add(new Cartesian2D(_pair.Key, _pair.Value));
            }
            Changed = true;
        }

        public void Clear()
        {
            Points.Clear();
            Changed = true;
        }

        public void SetInterpolation(IInterpolation interpolation)
        {
            _interpolationStrategy = interpolation;
            Changed = true;
        }

        public double Interpolate(double x)
        {
            if (x > Points[Points.Count - 1].X || x < Points[0].X)
                throw new ArgumentOutOfRangeException(nameof(x));
            return Interpolate(_interpolationStrategy, x);
        }

        private double Interpolate(IInterpolation interpolation, double x)
        {
            if (interpolation is null) throw new InvalidOperationException("Missing Interpolation type.");

            if (Changed)
            {
                Sort();
                interpolation.Calculate(Points);
            }

            return interpolation.Interpolate(x);
        }

        /// <summary>
        /// Linear Interpolation; if x is NaN, default interpolation strategy is created, otherwise linear is created and used
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public double Linear(double x = double.NaN)
        {
            if (double.IsNaN(x))
            {
                SetInterpolation(new Linear());
                return double.NaN;
            }
            if (_linearInterpolation is null)
            {
                _linearInterpolation = new Linear();
            }
            return Interpolate(_linearInterpolation, x);
        }

        public double Spline(double x = double.NaN)
        {
            if (double.IsNaN(x))
            {
                SetInterpolation(new Spline());
                return double.NaN;
            }
            if (_splineInterpolation is null)
            {
                _splineInterpolation = new Spline();
            }
            return Interpolate(_splineInterpolation, x);
        }

        public double Cosine(double x = double.NaN)
        {
            if (double.IsNaN(x))
            {
                SetInterpolation(new Cosine());
                return double.NaN;
            }
            if (_cosineInterpolation is null)
            {
                _cosineInterpolation = new Cosine();
            }
            return Interpolate(_cosineInterpolation, x);
        }

        public double Parabolic(double x = double.NaN)
        {
            if (double.IsNaN(x))
            {
                SetInterpolation(new Parabolic());
                return double.NaN;
            }
            if (_parabolicInterpolation is null)
            {
                _parabolicInterpolation = new Parabolic();
            }
            return Interpolate(_parabolicInterpolation, x);
        }
    }
}
