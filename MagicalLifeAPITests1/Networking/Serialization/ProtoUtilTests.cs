using MagicalLifeAPI.Entity.AI.Job.Jobs;
using MagicalLifeAPI.Entity.Entity;
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
            Assert.Fail();//Need to rewrite the world serialization/deserialization test.
        }

        private void Setup()
        {
            Server.Load();
        }
    }
}