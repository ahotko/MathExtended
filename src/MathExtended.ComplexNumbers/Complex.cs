using System;

namespace MathExtended.ComplexNumbers
{
    public partial class Complex
    {
        public double Epsilon { get; set; } = 1E-3;

        public static Complex Zero
        {
            get { return new Complex(); }
        }

        public double Real { get; set; } = 0;

        public double Imaginary { get; set; } = 0;

        public double Size
        {
            get
            {
                double _size = Math.Pow(Real, 2) + Math.Pow(Imaginary, 2);
                return Math.Sqrt(_size);
            }
        }

        public double Angle
        {
            get
            {
                return Math.Atan2(Imaginary, Real);
            }
        }

        public Complex() : this(0.0, 0.0) { }

        public Complex(double real) : this(real, 0.0) { }

        public Complex(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public Complex Conjugate()
        {
            return new Complex(this.Real, -this.Imaginary);
        }

        public void Multiply(Complex factor)
        {
            double _newReal = this.Real * factor.Real - this.Imaginary * factor.Imaginary;
            double _newImaginary = this.Real * factor.Imaginary + this.Imaginary * factor.Real;
            Real = _newReal;
            Imaginary = _newImaginary;
        }

        public void Divide(Complex divisor)
        {
            double _divisor = Math.Pow(divisor.Real, 2) + Math.Pow(divisor.Imaginary, 2);
            double _newReal = this.Real * divisor.Real + this.Imaginary * divisor.Imaginary;
            double _newImaginary = this.Real * divisor.Imaginary - this.Imaginary * divisor.Real;
            Real = _newReal / _divisor;
            Imaginary = _newImaginary / _divisor;
        }

        public Complex Duplicate()
        {
            return new Complex(Real, Imaginary);
        }

    }
}