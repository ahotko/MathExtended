﻿using MathExtended.Statistics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.MathExtended.Statistics
{
    [TestClass]
    public class UnitTestDistribution
    {
        [TestMethod]
        public void TestCount()
        {
            var distribution = new Distribution();
            distribution.AddRange(new double[] { 5.0, 10.0, 15.0, 20.0, 25.0 });

            Assert.AreEqual(5, distribution.Count);
        }

        [TestMethod]
        public void TestAverage()
        {
            var distribution = new Distribution();
            distribution.AddRange(new double[] { 5.0, 10.0, 15.0, 20.0});

            Assert.AreEqual(12.5, distribution.Average, 0.01);
        }

        [TestMethod]
        public void TestStandardDeviation()
        {
            var distribution = new Distribution();
            distribution.AddRange(new double[] { 5.0, 10.0, 15.0, 20.0 });

            Assert.AreEqual(6.454972244, distribution.StandardDeviation, 0.0001);
        }

        [TestMethod]
        public void TestNormalDistribution()
        {
            var distribution = new Distribution();
            distribution.AddRange(new double[] { 5.0, 10.0, 15.0, 20.0 });

            Assert.AreEqual(0.009477931, distribution.GetGaussValue(0), 0.0001);
            Assert.AreEqual(0.061803873, distribution.GetGaussValue(12.5), 0.0001);
        }

        [TestMethod]
        public void TestVariance()
        {
            var distribution = new Distribution();
            distribution.AddRange(new double[] { 5.0, 10.0, 15.0, 20.0, 21.0 });

            Assert.AreEqual(36.56, distribution.Variance, 0.1);
        }

        [TestMethod]
        public void TestSkewness()
        {
            var distribution = new Distribution();
            distribution.AddRange(new double[] { 5.0, 10.0, 15.0, 20.0, 21.0 });

            Assert.AreEqual(-0.31, distribution.Skewness, 0.01);
        }

        [TestMethod]
        public void TestSampleSkewness()
        {
            var distribution = new Distribution();
            distribution.AddRange(new double[] { 5.0, 10.0, 15.0, 20.0, 21.0 });

            Assert.AreEqual(-0.46, distribution.SampleSkewness, 0.01);
        }
    }
}
