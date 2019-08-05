using System;
using MLAPI.Util.RandomUtils;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace MLAPITest.Util
{
    public class StaticRandomTests
    {
        [Fact]
        public void RandTest()
        {
            this.TestPositive();
        }

        private void TestPositive()
        {
            double min = 15;
            double max = 18;

            while (min > 0)
            {
                double result = StaticRandom.Rand(min, max);

                if (result < min || result > max || result < 0)
                {
#if DEBUG
                    Console.WriteLine("Min: " + min.ToString());
                    Console.WriteLine("Max: " + max.ToString());
                    Console.WriteLine("Result: " + result.ToString());
#endif
                    Assert.Fail("Invalid result: ");
                }

                min -= .05;
                max -= .05;
            }
        }
    }
}