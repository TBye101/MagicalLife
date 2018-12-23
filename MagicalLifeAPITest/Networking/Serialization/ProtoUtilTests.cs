using MagicalLifeServer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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