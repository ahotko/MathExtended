using System;
using System.Collections.Generic;

namespace MathExtended.Common
{
    public static class PointFunctions
    {
        public static Tuple<int, int> FindIntervalIndex(double x, List<Cartesian2D> points)
        {
            if (x > points[points.Count - 1].X || x < points[0].X)
                return new Tuple<int, int>(-1, -1);

            int idxLeft = 0;
            int idxRight = points.Count - 1;

            //bracket the X value using binary search
            while (idxRight - idxLeft > 1)
            {
                int i = (idxLeft + idxRight) / 2;
                if (points[i].X > x)
                    idxRight = i;
                else
                    idxLeft = i;
            }
            return new Tuple<int,int>(idxLeft, idxRight);
        }

        public static Tuple<Cartesian2D, Cartesian2D> FindInterval(double x, List<Cartesian2D> points)
        {
            var intervalIdx = FindIntervalIndex(x, points);
            if (intervalIdx.Item1 == intervalIdx.Item2)
                return null;
            return new Tuple<Cartesian2D, Cartesian2D>(points[intervalIdx.Item1], points[intervalIdx.Item2]);
        }
    }
}
