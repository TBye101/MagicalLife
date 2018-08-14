using MagicalLifeAPI.Entity.AI.Job.Jobs;
using MagicalLifeAPI.Entity.Entity;
using MagicalLifeAPI.Entity.Humanoid;
using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.World.Data;
using MagicalLifeServer;
using MagicalLifeServer.ServerWorld.World;
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
            this.Setup();
            MineJob job = new MineJob(new MagicalLifeAPI.DataTypes.Point2D(3, 6));

            HumanFactory humanFactory = new HumanFactory();
            Human human = humanFactory.GenerateHuman(new MagicalLifeAPI.DataTypes.Point2D(1, 3), 0, Guid.NewGuid());

            JobAssignedMessage message = new JobAssignedMessage(human, job);

            byte[] data = ProtoUtil.Serialize(message);
            Assert.IsNotNull(data);

            JobAssignedMessage result = (JobAssignedMessage)ProtoUtil.Deserialize(data);
        }

        [TestMethod()]
        private void WorldTest()
        {
            this.Setup();
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