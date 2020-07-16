using MatxExtended.Random;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.MathExtended.Random
{
    [TestClass]
    public class UnitTestRandom
    {
        [TestMethod]
        public void RanmarValidation()
        {
            #region Description of Test procedure from original Author
            /*
            Use IJ = 1802 & KL = 9373 to test the random number generator. The
            subroutine RANMAR should be used to generate 20000 random numbers.
            Then display the next six random numbers generated multiplied by
            4096 * 4096
            If the random number generator is working properly, the random numbers
            should be:
            6533892.0  14220222.0   7275067.0
            6172232.0   8354498.0  10633180.0
            */
            #endregion
            int[] results = new int[20006];
            int factor = 4096 * 4096;

            var ranmar = new Ranmar(1802, 9373);

            for (int i = 0; i < results.Length; i++)
            {
                results[i] = ranmar.Next(factor);
            }
            Assert.IsTrue(results[20000] == 6533892 &&
                          results[20001] == 14220222 &&
                          results[20002] == 7275067 &&
                          results[20003] == 6172232 &&
                          results[20004] == 8354498 &&
                          results[20005] == 10633180, "Random Generator RANMAR NOT working by specifications.");
        }
    }
}