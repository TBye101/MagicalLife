using MagicalLifeAPI.Entity;
using MagicalLifeAPI.Networking;
using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.World;
using System;
using System.Collections.Generic;

namespace MagicalLifeServer.Processing.Message
{
    public class LoginMessageHandler : MessageHandler
    {
        public LoginMessageHandler() : base(NetMessageID.LoginMessage)
        {
        }

        public override void HandleMessage(BaseMessage message)
        {
            LoginMessage msg = (LoginMessage)message;
            JobSystem.JobSystemManager.Manager.PlayerToJobSystem.Add(msg.PlayerID, new JobSystem.JobSystem(new Dictionary<Guid, Living>(), msg.PlayerID));//Need to handle game loads, saves, player connect, and player disconnect
            JobSystem.JobSystemManager.Manager.EvaluateUnassigned();
        }
    }
}
