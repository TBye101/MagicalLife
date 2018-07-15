using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.World.Tiles;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MagicalLifeAPI.Protobuf.Serialization.Tests
{
    [TestClass()]
    public class ProtoUtilTests
    {
        [TestMethod()]
        public void SerAndDeSerTest()
        {
            this.Setup();
            this.TileTest();
        }

        private void TileTest()
        {
            string data = Convert.ToBase64String(ProtoUtil.Serialize<Dirt>(new Dirt(3, 2)));
            Dirt dirt = ProtoUtil.Deserialize<Dirt>(data);

            Assert.AreEqual(dirt.Location, new Point2D(3, 2));
            Assert.IsNotNull(dirt.ID);
        }

        private void Setup()
        {
            ProtoTypeLoader prep = new ProtoTypeLoader();
            int prog = 0;
            prep.InitialStartup();
        }
    }
}