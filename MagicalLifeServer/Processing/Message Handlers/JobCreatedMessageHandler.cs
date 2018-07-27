using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Networking.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeServer.Processing.Message_Handlers
{
    public class JobCreatedMessageHandler : MessageHandler
    {
        public JobCreatedMessageHandler() : base(8)
        {
        }

        public override void HandleMessage(BaseMessage message)
        {
            JobCreatedMessage msg = (JobCreatedMessage)message;
            JobSystem.JobSystemManager.Manager.PlayerToJobSystem[msg.PlayerID].AddJob(new KeyValuePair<Guid, MagicalLifeAPI.Entity.AI.Job.Job>(msg.Job.ID, msg.Job));
        }
    }
}
