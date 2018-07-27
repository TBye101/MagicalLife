using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Networking.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeServer.Processing.Message_Handlers
{
    public class LoginMessageHandler : MessageHandler
    {
        public LoginMessageHandler() : base(6)
        {
        }

        public override void HandleMessage(BaseMessage message)
        {
            LoginMessage msg = (LoginMessage)message;
            JobSystem.JobSystemManager.Manager.PlayerToJobSystem.Add(msg.PlayerID, new JobSystem.JobSystem(new Dictionary<Guid, MagicalLifeAPI.Entities.Living>(), msg.PlayerID));//Need to handle game loads, saves, player connect, and player disconnect
            JobSystem.JobSystemManager.Manager.EvaluateUnassigned();
        }
    }
}
