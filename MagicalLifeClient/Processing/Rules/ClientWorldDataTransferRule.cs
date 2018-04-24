using MagicalLifeAPI.World;
using MagicalLifeNetworkMessages;
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
            Type msgType = message.GetType();
            return msgType.IsAssignableFrom(typeof(ServerToClientWorldDataTransfer));
        }

        public void HandleMessage(NetworkMessage message)
        {
            ServerToClientWorldDataTransfer msg = (ServerToClientWorldDataTransfer)message.Payload.GetPayload();
            World.mainWorld.Tiles = DataUtil.ConvertPayloads<Tile>(msg.Tiles);
        }
    }
}
