using MagicalLifeAPI.Util;
using System;
using Xunit;

namespace MagicalLifeTests.Util
{
    public class StaticRandomTests
    {
        [Fact]
        public void RandTestPositive()
        {
            double min = 15;
            double max = 18;

            while (min > 0)
            {
                double result = StaticRandom.Rand(min, max);

                Assert.False(result < min);

                Assert.False(result > max);

                Assert.False(result < 0);

                min -= .05;
                max -= .05;
            }
        }
    }
}