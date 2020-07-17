using System;

namespace MathExtended.ComplexNumbers
{
    public partial class Complex
    {
        #region Overloaded operators
        /// <summary>
        /// Complex Conjugation
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Complex operator ~(Complex value) => new Complex(value.Real, -value.Imaginary);

        public static Complex operator +(Complex number) => number;
        public static Complex operator -(Complex number) => new Complex(-number.Real, number.Imaginary);

        /// <summary>
        /// Addition of two complex numbers
        /// </summary>
        /// <param name="first">First parameter - Complex number</param>
        /// <param name="second">Second parameter - Complex number</param>
        /// <returns>Complex number</returns>
        public static Complex operator +(Complex first, Complex second)
        {
            return new Complex(first.Real + second.Real, first.Imaginary + second.Imaginary);
        }

        public static Complex operator +(Complex first, double second)
        {
            return new Complex(first.Real + second, first.Imaginary);
        }

        public static Complex operator +(double first, Complex second)
        {
            return new Complex(first + second.Real, second.Imaginary);
        }

        public static Complex operator -(Complex first, Complex second)
        {
            return new Complex(first.Real - second.Real, first.Imaginary - second.Imaginary);
        }

        public static Complex operator -(Complex first, double second)
        {
            return new Complex(first.Real - second, first.Imaginary);
        }

        public static Complex operator -(double first, Complex second)
        {
            return new Complex(first - second.Real, -second.Imaginary);
        }

        public static Complex operator *(Complex first, Complex second)
        {
            return new Complex(first.Real * second.Real - first.Imaginary * second.Imaginary, first.Real * second.Imaginary + first.Imaginary * second.Real);
        }

        public static Complex operator *(Complex first, double second)
        {
            return first * new Complex(second);
        }

        public static Complex operator *(double first, Complex second)
        {
            return new Complex(first) * second;
        }

        public static Complex operator /(Complex dividend, Complex divisor)
        {
            var _dividend = dividend.Duplicate();
            _dividend.Divide(divisor);
            return _dividend;
        }

        public static Complex operator /(Complex dividend, double divisor)
        {
            var _dividend = dividend.Duplicate();
            _dividend.Real /= divisor;
            _dividend.Imaginary /= divisor;
            return _dividend;
        }

        public static bool operator ==(Complex first, Complex second)
        {
            return (Math.Abs(first.Real - second.Real) <= first.Epsilon)
                && (Math.Abs(first.Imaginary - second.Imaginary) <= first.Epsilon);
        }

        public static bool operator !=(Complex first, Complex second)
        {
            return !(first == second);
        }

        public static bool operator >(Complex first, Complex second)
        {
            return (first.Size > second.Size);
        }

        public static bool operator <(Complex first, Complex second)
        {
            return (first.Size < second.Size);
        }

        public static bool operator >=(Complex first, Complex second)
        {
            return (first.Size >= second.Size);
        }

        public static bool operator <=(Complex first, Complex second)
        {
            return (first.Size <= second.Size);
        }

        public override bool Equals(object obj)
        {
            var value = obj as Complex;
            if (obj == null)
            {
                return false;
            }
            bool result = false;
            result = (Math.Abs(this.Real - value.Real) <= this.Epsilon)
                && (Math.Abs(this.Imaginary - value.Imaginary) <= this.Epsilon);
            return result;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0:N3}{1}{2:N3}i", this.Real, (this.Imaginary >= 0) ? "+" : "", this.Imaginary);
        }

        #endregion
    }
}