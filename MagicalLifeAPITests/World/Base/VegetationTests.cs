using MagicalLifeAPI.World.Veggies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MagicalLifeAPI.World.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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