using Microsoft.VisualStudio.TestTools.UnitTesting;
using MagicalLifeAPI.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.World.Tests
{
    [TestClass()]
    public class WorldTests
    {
        [TestMethod()]
        public void InitializeTest()
        {
            World world = new World();
            Assert.IsNotNull(world);
            Assert.IsNotNull(World.mainWorld);
        }
    }
}