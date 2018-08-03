using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.World.Data;
using MagicalLifeServer;
using MagicalLifeServer.ServerWorld.World;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MagicalLifeAPITests1.Networking.Serialization
{
    [TestClass()]
    public class ProtoUtilTests
    {
        [TestMethod()]
        public void SerAndDeSerTest()
        {
            this.Setup();
            this.WorldTest();
        }

        private void WorldTest()
        {
            World.Initialize(1, 1, new GrassAndDirt(0));
            WorldTransferMessage input = new WorldTransferMessage(World.Dimensions);
            byte[] data = ProtoUtil.Serialize(input);
            Assert.IsNotNull(data, "Failed to serialize");

            WorldTransferMessage result = (WorldTransferMessage)ProtoUtil.Deserialize(data);
        }

        private void Setup()
        {
            Server.Load();
        }
    }
}