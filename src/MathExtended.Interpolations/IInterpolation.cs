using MathExtended.Common;
using System.Collections.Generic;

namespace MathExtended.Interpolations
{
    public interface IInterpolation
    {
        bool Check();

        void Calculate(List<Cartesian2D> points);
        double Interpolate(double x);
    }
}
