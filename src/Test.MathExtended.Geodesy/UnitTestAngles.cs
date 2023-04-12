using MathExtended.Geodesy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Test.MathExtended.Geodesy
{
    [TestClass]
    public class UnitTestAngles
    {
        [TestMethod]
        public void AngleConversionDms()
        {
            var dms = new Angle(45, 30, 10);

            Assert.AreEqual(45.5, dms.DecimalDegrees, 0.01, "DMS Conversion Failed!");
        }
    }
}
