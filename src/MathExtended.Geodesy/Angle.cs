using System;

namespace MathExtended.Geodesy
{
    public struct Angle
    {
        public double Value { get; set; }

        public (double Degrees, double Minutes, double Seconds) DegreesMinutesSeconds
        {
            get
            {
                var tmp = Value;

                var deg = Math.Truncate(tmp);

                tmp -= deg;
                tmp *= 60.0;

                var min = Math.Truncate(tmp);

                tmp -= min;
                var sec = tmp * 60.0;

                return (deg, min, sec);
            }
        }

        public (double Degrees, double Minutes) DegreesDecimalMinutes
        {
            get
            {
                var tmp = Value;

                var deg = Math.Truncate(tmp);

                tmp -= deg;
                tmp *= 60.0;

                var min = tmp * 60.0;

                return (deg, min);
            }
        }

        public double DecimalDegrees => Value;

        /// <summary>
        /// Constructor for Angle in format 44°12'13"
        /// </summary>
        /// <param name="degrees"></param>
        /// <param name="minutes"></param>
        /// <param name="seconds"></param>
        public Angle(double degrees, double minutes, double seconds)
        {
            Value = degrees + (minutes / 60.0) + (seconds / 3600.0);
        }

        /// <summary>
        /// Constructor for Angle in format 44°12.135'
        /// </summary>
        /// <param name="degrees"></param>
        /// <param name="decimalMinutes"></param>
        public Angle(double degrees, double decimalMinutes)
        {
            Value = degrees + (decimalMinutes / 60.0);
        }

        /// <summary>
        /// Constructor for Angle in format 44.12344°
        /// </summary>
        /// <param name="decimalDegrees"></param>
        public Angle(double decimalDegrees)
        {
            Value = decimalDegrees;
        }

        public static double DegToRad(double degrees)
        {
            return degrees * (Math.PI / 180.0);
        }

        public static Angle operator +(Angle angle) => angle;
        public static Angle operator -(Angle angle) => new Angle(-angle.DecimalDegrees);
        public static Angle operator +(Angle angle1, Angle angle2) => new Angle(angle1.DecimalDegrees + angle2.DecimalDegrees);
        public static Angle operator -(Angle angle1, Angle angle2) => angle1 + (-angle2);
    }
}
