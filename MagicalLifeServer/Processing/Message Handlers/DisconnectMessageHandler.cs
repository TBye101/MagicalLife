using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Networking.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeServer.Processing.Message_Handlers
{
    public class DisconnectMessageHandler : MessageHandler
    {
        public DisconnectMessageHandler() : base(9)
        {
        }

        public override void HandleMessage(BaseMessage message)
        {
            DisconnectMessage msg = (DisconnectMessage)message;
            JobSystem.JobSystemManager.Manager.PlayerToJobSystem.Remove(msg.ClientPlayerID);
        }
    }
}
