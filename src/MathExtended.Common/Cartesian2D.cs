using System;

namespace MathExtended.Common
{
    public class Cartesian2D
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Cartesian2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Cartesian2D() : this(0, 0) { }

        private bool NearlyEqual(double v1, double v2, double epsilon = 1E-5)
        {
            return Math.Abs(v1 - v2) < epsilon;
        }

        public override bool Equals(Object obj)
        {
            // Check for null values and compare run-time types.
            if (obj == null || GetType() != obj.GetType())
                return false;

            Cartesian2D p = (Cartesian2D)obj;
            return (NearlyEqual(X, p.X) && NearlyEqual(Y, p.Y));
        }

        public override int GetHashCode()
        {
            return (X.GetHashCode() * 31) ^ (Y.GetHashCode() * 17);
        }

        public override string ToString()
        {
            return $"x = {X:N4}, y = {Y:N4}";
        }

        public static Cartesian2D operator +(Cartesian2D coordinates) => coordinates;

        public static Cartesian2D operator +(Cartesian2D coordinates, double length)
        {
            double r = Math.Sqrt(Math.Pow(coordinates.X, 2) + Math.Pow(coordinates.Y, 2)) + length;
            double theta = Math.Atan2(coordinates.Y, coordinates.X);

            return new Cartesian2D(r * Math.Cos(theta), r * Math.Sin(theta));
        }

        public static Cartesian2D operator +(double length, Cartesian2D coordinates)
        {
            return coordinates + length;
        }
    }
}
