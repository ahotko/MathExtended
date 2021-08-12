using System;
using System.Collections.Generic;

namespace MathExtended.Geodesy
{
    public enum GeodeticReference
    {
        WGS84,
        GRS80,
        GRS67,
        ANS,
        Clarke1880
    }

    public struct Ellipsoid
    {
        private Dictionary<GeodeticReference, Tuple<double, double>> _geodeticReferenceValues;

        public double SemiMajorAxis { get; private set; }
        public double SemiMinorAxis { get; private set; }
        public double Flattening { get; private set; }
        public double InverseFlattening { get; private set; }

        public Ellipsoid(GeodeticReference reference = GeodeticReference.WGS84)
        {
            SemiMajorAxis = 0.0;
            InverseFlattening = 0.0;
            Flattening = 0.0;
            SemiMinorAxis = 0.0;

            _geodeticReferenceValues = new()
            {
                [GeodeticReference.WGS84] = new Tuple<double, double>(6378137.0, 298.257223563),
                [GeodeticReference.GRS80] = new Tuple<double, double>(6378137.0, 298.257222101),
                [GeodeticReference.GRS67] = new Tuple<double, double>(6378160.0, 298.25),
                [GeodeticReference.ANS] = new Tuple<double, double>(6378160.0, 298.25),
                [GeodeticReference.Clarke1880] = new Tuple<double, double>(6378249.145, 293.465),
            };

            (double SemiMajorAxis, double InverseFlattening) values = _geodeticReferenceValues[reference].ToValueTuple();

            Calculate(values.SemiMajorAxis, values.InverseFlattening);
        }

        private void Calculate(double semiMajorAxis, double inverseFlattening)
        {
            SemiMajorAxis = semiMajorAxis;
            InverseFlattening = inverseFlattening;

            Flattening = 1.0 / inverseFlattening;
            SemiMinorAxis = (1.0 - Flattening) * semiMajorAxis;
        }
    }
}
