using MagicalLifeAPI.Entities;
using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.World.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeClient.Message_Handlers
{
    public class JobAssignedMessageHandler : MessageHandler
    {
        public JobAssignedMessageHandler() : base(5)
        {
        }

        public override void HandleMessage(BaseMessage message)
        {
            JobAssignedMessage msg = (JobAssignedMessage)message;
            Chunk chunk = World.GetChunkByTile(msg.Worker.Dimension, msg.Worker.MapLocation.X, msg.Worker.MapLocation.Y);

            chunk.GetCreature(msg.Worker.MapLocation, out Living worker);
            worker.Task = msg.Task;
            worker.Task.BeginJob(worker);
        }
    }
}
