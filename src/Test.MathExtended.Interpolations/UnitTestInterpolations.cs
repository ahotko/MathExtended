using System;
using MathExtended.Interpolations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.MathExtended.Interpolations
{
    [TestClass]
    public class UnitTestInterpolations
    {
        [TestMethod]
        public void InterpolationLinear()
        {
            var _interpolation = new Interpolation();
            _interpolation.Linear();

            _interpolation.Add(0, 0);
            _interpolation.Add(10, 10);

            Assert.AreEqual(0.5, _interpolation.Interpolate(0.5), 0.01, "Linear interpolation at x=0.5 failed!");
            Assert.AreEqual(1.5, _interpolation.Interpolate(1.5), 0.01, "Linear interpolation at x=1.5 failed!");
            Assert.AreEqual(2.5, _interpolation.Interpolate(2.5), 0.01, "Linear interpolation at x=2.5 failed!");
            Assert.AreEqual(3.5, _interpolation.Interpolate(3.5), 0.01, "Linear interpolation at x=3.5 failed!");
            Assert.AreEqual(4.5, _interpolation.Interpolate(4.5), 0.01, "Linear interpolation at x=4.5 failed!");
        }

        [TestMethod]
        public void InterpolationLinearMultiPoints()
        {
            var _interpolation = new Interpolation();
            _interpolation.Linear();

            _interpolation.Add(0, 0);
            _interpolation.Add(2.5, 2.5);
            _interpolation.Add(5, 10);

            Assert.AreEqual(0.5, _interpolation.Interpolate(0.5), 0.01, "Linear interpolation at x=0.5 failed!");
            Assert.AreEqual(1.5, _interpolation.Interpolate(1.5), 0.01, "Linear interpolation at x=1.5 failed!");
            Assert.AreEqual(2.5, _interpolation.Interpolate(2.5), 0.01, "Linear interpolation at x=2.5 failed!");
            Assert.AreEqual(5.5, _interpolation.Interpolate(3.5), 0.01, "Linear interpolation at x=3.5 failed!");
            Assert.AreEqual(8.5, _interpolation.Interpolate(4.5), 0.01, "Linear interpolation at x=4.5 failed!");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InterpolationLinearArgumentOutOfRangeException()
        {
            var _interpolation = new Interpolation();
            _interpolation.Linear();

            _interpolation.Add(0, 0);
            _interpolation.Add(2.5, 2.5);
            _interpolation.Add(5, 10);

            double _result = _interpolation.Interpolate(10.0);
        }

        [TestMethod]
        public void InterpolationParabolic()
        {
            var _interpolation = new Interpolation();
            _interpolation.Parabolic();

            _interpolation.Add(-2, 4);
            _interpolation.Add(0, 0);
            _interpolation.Add(2, 4);

            Assert.AreEqual(1, _interpolation.Interpolate(-1), 0.01, "Parabolic interpolation at x=-1 failed!");
            Assert.AreEqual(0, _interpolation.Interpolate(0), 0.01, "Parabolic interpolation at x=0 failed!");
            Assert.AreEqual(1, _interpolation.Interpolate(1), 0.01, "Parabolic interpolation at x=1 failed!");
            Assert.AreEqual(2.25, _interpolation.Interpolate(1.5), 0.01, "Parabolic interpolation at x=1.5 failed!");
            Assert.AreEqual(2.25, _interpolation.Interpolate(-1.5), 0.01, "Parabolic interpolation at x=-1.5 failed!");
        }

        [TestMethod]
        public void InterpolationSpline()
        {
            var _interpolation = new Interpolation();
            _interpolation.Spline();

            _interpolation.Add(-6, 2);
            _interpolation.Add(2, -4);
            _interpolation.Add(6, 6);

            Assert.AreEqual(-5.344, _interpolation.Interpolate(0), 0.01, "Spline interpolation at x=0 failed!");
            Assert.AreEqual(0, _interpolation.Interpolate(-4.897), 0.01, "Spline interpolation at x=-4.897 failed!");
            Assert.AreEqual(0, _interpolation.Interpolate(3.928), 0.01, "Spline interpolation at x=3.928 failed!");
            Assert.AreEqual(-5.027, _interpolation.Interpolate(1), 0.01, "Spline interpolation at x=1 failed!");
        }

        [TestMethod]
        public void InterpolationCosine()
        {
            var _interpolation = new Interpolation();
            _interpolation.Cosine();

            _interpolation.Add(0, 5);
            _interpolation.Add(2, -5);
            _interpolation.Add(4, 6);

            Assert.AreEqual(0, _interpolation.Interpolate(1), 0.01, "Cosine interpolation at x=0 failed!");
            Assert.AreEqual(0.5, _interpolation.Interpolate(3), 0.01, "Cosine interpolation at x=3 failed!");
            Assert.AreEqual(4.3891, _interpolation.Interpolate(3.5), 0.01, "Cosine interpolation at x=3.5 failed!");
        }
    }
}
