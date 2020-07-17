using System;

namespace MathExtended.ComplexNumbers
{
    public partial class Complex
    {
        public Complex Log()
        {
            return new Complex(Math.Log(this.Size), Math.Atan2(Imaginary, Real));
        }

        public Complex Log(Complex logBase)
        {
            var _a = Log();
            var _b = logBase.Log();
            return _a / _b;
        }

        public Complex Log(double logBase)
        {
            var _a = Log();
            var _b = new Complex(logBase);
            return _a / _b.Log();
        }

        public double Abs()
        {
            return Size;
        }
    }
}
