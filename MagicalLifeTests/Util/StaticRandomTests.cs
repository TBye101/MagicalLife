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
            this.TestNegative();
            this.TestPositive();
        }

        private void TestNegative()
        {
            double min = -.1;
            double max = .2;

            while (min > -15)
            {
                double result = StaticRandom.Rand(min, max);

                if (result < min || result > max)
                {
                    Console.WriteLine("Min: " + min.ToString());
                    Console.WriteLine("Max: " + max.ToString());
                    Console.WriteLine("Result: " + result.ToString());
                    Assert.Fail("Invalid Result");
                }

                min -= .05;
                max -= .05;
            }
        }

        private void TestPositive()
        {
            double min = 15;
            double max = 16;

            while (min > -15)
            {
                double result = StaticRandom.Rand(min, max);

                if (result < min || result > max)
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