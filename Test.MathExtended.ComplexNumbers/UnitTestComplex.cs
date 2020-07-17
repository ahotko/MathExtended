using System;
using MathExtended.ComplexNumbers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.MathExtended.ComplexNumbers
{
    [TestClass]
    public class UnitTestComplex
    {
        [TestMethod]
        public void ComplexEquals()
        {
            var a = new Complex(3, 3);
            var b = new Complex(3, 3);

            Assert.IsTrue(a == b, "Complex A and B are equal!");
        }

        [TestMethod]
        public void ComplexNotEquals()
        {
            var a = new Complex(3, 3);
            var b = new Complex(4, 3);

            Assert.IsTrue(a != b, "Complex A and B are not equal!");
        }

        [TestMethod]
        public void ComplexAdd()
        {
            var a = new Complex(1, 3);
            var b = new Complex(4, 5);

            var _calculatedResult = a + b;
            var _trueResult = new Complex(a.Real + b.Real, a.Imaginary + b.Imaginary);

            Assert.AreEqual(_trueResult, _calculatedResult, "Complex sum of A and B failed!");
        }

        [TestMethod]
        public void ComplexAddReal()
        {
            var a = new Complex(1, 3);
            double b = 5;

            var _calculatedResult = a + b;
            var _trueResult = new Complex(a.Real + b, a.Imaginary);

            Assert.AreEqual(_trueResult, _calculatedResult, "Complex sum of A and B failed!");
        }

        [TestMethod]
        public void ComplexSubstract()
        {
            var a = new Complex(1, 3);
            var b = new Complex(4, 5);

            var _calculatedResult = a - b;
            var _trueResult = new Complex(a.Real - b.Real, a.Imaginary - b.Imaginary);

            Assert.AreEqual(_trueResult, _calculatedResult, "Complex sum of A and B failed!");
        }

        [TestMethod]
        public void ComplexMultiply()
        {
            var a = new Complex(3, 13);
            var b = new Complex(7, 17);

            var _calculatedResult = a * b;
            var _trueResult = new Complex(a.Real * b.Real - a.Imaginary * b.Imaginary,
                a.Real * b.Imaginary + a.Imaginary * b.Real);

            Assert.AreEqual(_trueResult, _calculatedResult, "Complex product of A and B failed!");
        }

        [TestMethod]
        public void ComplexDivide()
        {
            var a = new Complex(1, 2);
            var b = new Complex(2, 3);

            double _divisor = b.Real * b.Real + b.Imaginary * b.Imaginary;
            double _newReal = a.Real * b.Real + a.Imaginary * b.Imaginary;
            double _newImaginary = a.Real * b.Imaginary - a.Imaginary * b.Real;

            var _calculatedResult = a / b;
            var _trueResult = new Complex(_newReal / _divisor,
                _newImaginary / _divisor);

            Assert.AreEqual(_trueResult, _calculatedResult, "Complex product of A and B failed!");
        }

        [TestMethod]
        public void ComplexConjugateMethod()
        {
            var a = new Complex(1, 3);

            var _calculatedResult = a.Conjugate();
            var _trueResult = new Complex(a.Real, -a.Imaginary);

            Assert.AreEqual(_trueResult, _calculatedResult, "Conjugate of A failed!");
        }

        [TestMethod]
        public void ComplexConjugateOperator()
        {
            var a = new Complex(1, 3);

            var _calculatedResult = ~a;
            var _trueResult = new Complex(a.Real, -a.Imaginary);

            Assert.AreEqual(_trueResult, _calculatedResult, "Conjugate of A failed!");
        }

        [TestMethod]
        public void ComplexSize()
        {
            var a = new Complex(1, 1);
            var b = new Complex(2, 2);

            Assert.IsTrue(b > a, "Complex B is bigger than A!");
            Assert.IsTrue(a < b, "Complex B is bigger than A!");
        }
    }
}
