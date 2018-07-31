using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.World.Tiles;
using MagicalLifeServer;
using MagicalLifeServer.ServerWorld.World_Generation.Generators;
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
            this.WorldTest();
        }

        private void WorldTest()
        {
            World.Data.World.Initialize(1, 1, new GrassAndDirt(0));
            WorldTransferMessage input = new WorldTransferMessage(World.Data.World.Dimensions);
            byte[] data = ProtoUtil.Serialize(input);
            Assert.IsNotNull(data, "Failed to serialize");

            WorldTransferMessage result = (WorldTransferMessage)ProtoUtil.Deserialize(data);
        }

        private void Setup()
        {
            Server.Load(Networking.EngineMode.ServerOnly);
        }
    }
}