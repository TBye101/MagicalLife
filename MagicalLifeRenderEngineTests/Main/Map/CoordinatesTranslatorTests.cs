using MagicalLifeAPI.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace MagicalLifeRenderEngine.Main.Map.Tests
{
    [TestClass()]
    public class CoordinatesTranslatorTests
    {
        [TestMethod()]
        public void GetTileLocationTest()
        {
            Point3D output = CoordinatesTranslator.GetTileLocation(new Point(0, 0));
            Assert.AreEqual(0, output.X);
            Assert.AreEqual(0, output.Y);
            Assert.AreEqual(0, output.Z);

            output = CoordinatesTranslator.GetTileLocation(new Point(64, 64));

            Assert.AreEqual(1, output.X);
            Assert.AreEqual(1, output.Y);
            Assert.AreEqual(0, output.Z);
        }
    }
}