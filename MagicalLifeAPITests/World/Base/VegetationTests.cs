using MagicalLifeAPI.World.Veggies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MagicalLifeAPI.World.Base.Tests
{
    [TestClass()]
    public class VegetationTests
    {
        [TestMethod()]
        public void VegetationTest()
        {
            Vegetation a = new OakTree();
            Assert.IsNotNull(a);
        }
    }
}