using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.World.Tiles;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MagicalLifeAPI.World.Tests
{
    [TestClass()]
    public class TileTests
    {
        [TestMethod()]
        public void TileTest()
        {
            Tile tile = new Dirt(new Point3D(0, 0, 0));
            Assert.IsNotNull(tile);
        }
    }
}