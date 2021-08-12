namespace MathExtended.Geodesy
{
    public struct GeographicCoordinates
    {
        public Angle Latitude { get; set; }
        public Angle Longitude { get; set; }
        public double Altitude { get; set; }

        public GeographicCoordinates(Angle latitude, Angle longitude, double altitude)
        {
            Latitude = latitude;
            Longitude = longitude;
            Altitude = altitude;
        }

        public GeographicCoordinates(double latitude, double longitude, double altitude)
        {
            Latitude = new Angle(latitude);
            Longitude = new Angle(longitude);
            Altitude = altitude;
        }
    }
}
