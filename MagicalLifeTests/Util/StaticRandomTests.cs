using Microsoft.VisualStudio.TestTools.UnitTesting;
using MagicalLifeAPI.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MagicalLifeAPI.Util.Tests
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