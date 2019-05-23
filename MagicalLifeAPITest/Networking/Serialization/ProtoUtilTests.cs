using MagicalLifeServer;
using Xunit;

namespace MagicalLifeAPITests1.Networking.Serialization
{

    public class ProtoUtilTests
    {
        [Fact]
        public void TestJobSerialization()
        {
        }


        private void WorldTest()
        {
            //Assert.Fail();//Need to rewrite the world serialization/deserialization test.
        }


        private void Setup()
        {
            Server.Load();
        }
    }
}