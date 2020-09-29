using MathExtended.Statistics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.MathExtended.Statistics
{
    [TestClass]
    public class UnitTestHistogram
    {
        private double[] _testArray = { 2.55, 3.05, 7.89, 1.84, 9.38, 7.94, 9.26, 6.48, 4.96, 1.76, 6.35, 4.22, 2.29, 9.68, 7.69, 5.56, 3.54, 8.08, 9.35, 3.87, 6, 5.22, 1.87, 3.6, 9.47, 5.79, 7.91, 8.41, 2.34, 1.54, 3.94, 8.87, 7.83, 7.41, 7.1, 3.46, 3.73, 3.48, 3.38, 4.22, 6.91, 1.1, 2.42, 4.81, 8.14, 6.39, 4.97, 3.02, 5.69, 2.26 };
        private Histogram _histogram;

        private int[] histogramSquareRoot;
        private int[] histogramRice;
        private int[] histogramScott;
        private int[] histogramSturges;

        public UnitTestHistogram()
        {
            _histogram = new Histogram();
            _histogram.AddRange(_testArray);
            //
            histogramSquareRoot = _histogram.Generate(NumberOfBins.SquareRoot);
            histogramRice = _histogram.Generate(NumberOfBins.RiceRule);
            histogramScott = _histogram.Generate(NumberOfBins.ScottsNormalReferenceRule);
            histogramSturges = _histogram.Generate(NumberOfBins.Sturges);

        }

        [TestMethod]
        public void TestBinCountSquareRoot()
        {
            Assert.AreEqual(8, histogramSquareRoot.Length);
        }

        [TestMethod]
        public void TestBinCountRice()
        {
            Assert.AreEqual(8, histogramRice.Length);
        }

        [TestMethod]
        public void TestBinCountScott()
        {
            Assert.AreEqual(5, histogramScott.Length);
        }

        [TestMethod]
        public void TestBinCountSturges()
        {
            Assert.AreEqual(7, histogramSturges.Length);
        }

    }
}
