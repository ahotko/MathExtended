using MathExtended.Geodesy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Test.MathExtended.Geodesy
{
    [TestClass]
    public class UnitTestAngles
    {
        [TestMethod]
        public void AngleConversion()
        {
            var dms = new Angle(45, 30, 10);
        }
    }
}
