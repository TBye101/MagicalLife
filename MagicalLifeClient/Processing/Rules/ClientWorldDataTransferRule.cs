using MagicalLifeAPI.World;
using MagicalLifeNetworkMessages.Messages;
using MagicalLifeNetworkMessages.Messages.ServerToClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeClient.Processing.Rules
{
    public class ClientWorldDataTransferRule : IMessageHandler
    {
        public bool CanIHandle(NetworkMessage message)
        {
            if (message.GetType() == typeof(ServerToClientWorldDataTransfer))
            {
                return true;
            }

            return false;
        }

        public void HandleMessage(NetworkMessage message)
        {
            ServerToClientWorldDataTransfer msg = (ServerToClientWorldDataTransfer)message;
            World.mainWorld = msg.World;
        }
    }
}
