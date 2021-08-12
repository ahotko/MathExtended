using System;

namespace MathExtended.Geodesy
{
    public static class GeodeticDistance
    {
        public static (double Distance, double Height) Haversine(GeographicCoordinates origin, GeographicCoordinates destination)
        {
            double R = 6371000.0;

            var dLat = Angle.DegToRad((destination.Latitude - origin.Latitude).DecimalDegrees);
            var dLon = Angle.DegToRad((destination.Longitude - origin.Longitude).DecimalDegrees);

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(Angle.DegToRad(origin.Latitude.DecimalDegrees)) * Math.Cos(Angle.DegToRad(destination.Latitude.DecimalDegrees)) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            var c = 2 * Math.Asin(Math.Min(1, Math.Sqrt(a)));
            var d = R * c;

            return (d, destination.Altitude - origin.Altitude);
        }

        public static (double Distance, double Height) Haversine(double originLat, double originLon, double originAlt, double destLat, double destLon, double destAlt)
        {
            return Haversine(new GeographicCoordinates(originLat, originLon, originAlt), new GeographicCoordinates(destLat, destLon, destAlt));
        }

        public static (double Distance, double Height) Haversine(double originLat, double originLon, double destLat, double destLon)
        {
            return Haversine(new GeographicCoordinates(originLat, originLon, 0.0), new GeographicCoordinates(destLat, destLon, 0.0));
        }
    }
}
