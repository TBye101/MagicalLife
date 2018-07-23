using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeServer.JobSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeServer.Processing.Message_Handlers
{
    public class JobCompletedMessageHandler : MessageHandler
    {
        public JobCompletedMessageHandler() : base(7)
        {
        }

        public override void HandleMessage(BaseMessage message)
        {
            JobCompletedMessage msg = (JobCompletedMessage)message;
            JobSystemManager.Manager.PlayerToJobSystem[msg.PlayerID].MarkJobAsComplete(msg.CompletedID);
        }
    }
}
