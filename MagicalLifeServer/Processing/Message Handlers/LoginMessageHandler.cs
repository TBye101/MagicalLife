using MagicalLifeAPI.Entity;
using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.World;
using System;
using System.Collections.Generic;

namespace MagicalLifeServer.Processing.Message
{
    public class LoginMessageHandler : MessageHandler
    {
        public LoginMessageHandler() : base(6)
        {
        }

        public override void HandleMessage(BaseMessage message)
        {
            LoginMessage msg = (LoginMessage)message;
            JobSystem.JobSystemManager.Manager.PlayerToJobSystem.Add(msg.PlayerID, new JobSystem.JobSystem(new Dictionary<Guid, Living>(), msg.PlayerID));//Need to handle game loads, saves, player connect, and player disconnect
            JobSystem.JobSystemManager.Manager.EvaluateUnassigned();

            JobSystem.JobSystem playerSystem = JobSystem.JobSystemManager.Manager.PlayerToJobSystem[msg.PlayerID];
            if (playerSystem.Idle.Count == 0 && playerSystem.Busy.Count == 0)
            {
                //Spawns a creature in the default dimension (0).
                WorldUtil.SpawnRandomCharacter(msg.PlayerID, 0);
            }
        }
    }
}
