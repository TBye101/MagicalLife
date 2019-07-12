using MagicalLifeAPI.DataTypes.Attribute;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MagicalLifeAPITest.DataType
{
    public class AttributeTest
    {
        [Fact]
        public void TestAttributeAddition()
        {
            Attribute32 testAttribute1 = new Attribute32(10);
            Attribute32 testAttribute2 = new Attribute32(15);

            testAttribute1 += testAttribute2;

            Assert.True(testAttribute1.GetValue() == 25);
            Assert.True(testAttribute2.GetValue() == 15);
        }

        [Fact]
        public void TestAttributeSubtractionBiggerMinusSmaller()
        {
            Attribute32 testAttribute1 = new Attribute32(10);
            Attribute32 testAttribute2 = new Attribute32(15);

            testAttribute2 -= testAttribute1;

            Assert.True(testAttribute2.GetValue() == 5);
            Assert.True(testAttribute1.GetValue() == 10);
        }

        [Fact]
        public void TestAttributeSubtractionSmallerMinusBigger()
        {
            Attribute32 testAttribute1 = new Attribute32(10);
            Attribute32 testAttribute2 = new Attribute32(15);

            testAttribute1 -= testAttribute2;

            Assert.True(testAttribute2.GetValue() == 15);
            Assert.True(testAttribute1.GetValue() == -5);
        }
    }
}
