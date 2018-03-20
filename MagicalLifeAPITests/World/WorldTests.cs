using MagicalLifeAPI.World.World_Generation.Generators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            World.Initialize(10, 10, 10, new Dirtland());
            Assert.IsNotNull(World.mainWorld);
        }
    }
}