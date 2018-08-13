using MagicalLifeAPI.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MagicalLifeTests.Util
{
    [TestClass()]
    public class StaticRandomTests
    {
        [TestMethod()]
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
                    Console.WriteLine("Min: " + min.ToString());
                    Console.WriteLine("Max: " + max.ToString());
                    Console.WriteLine("Result: " + result.ToString());

                    Assert.Fail("Invalid result: ");
                }

                min -= .05;
                max -= .05;
            }
        }
    }
}