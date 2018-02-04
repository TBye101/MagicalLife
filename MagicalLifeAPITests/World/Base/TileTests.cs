using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.World.Tiles;
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