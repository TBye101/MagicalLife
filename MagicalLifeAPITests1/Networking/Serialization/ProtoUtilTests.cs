using MagicalLifeAPI.Entity.Humanoid;
using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeServer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MagicalLifeAPITests1.Networking.Serialization
{
    [TestClass()]
    public class ProtoUtilTests
    {
        [TestMethod()]
        public void TestJobSerialization()
        {
        }

        [TestMethod()]
        private void WorldTest()
        {
            Assert.Fail();//Need to rewrite the world serialization/deserialization test.
        }

        private void Setup()
        {
            Server.Load();
        }
    }
}