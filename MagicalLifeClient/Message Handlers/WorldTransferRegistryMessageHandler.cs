using MagicalLifeAPI.Networking;
using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.Networking.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeClient.Message_Handlers
{
    public class WorldTransferRegistryMessageHandler : MessageHandler
    {
        public WorldTransferRegistryMessageHandler() : base(NetMessageID.WorldTransferRegistryMessage)
        {

        }

        public override void HandleMessage(BaseMessage message)
        {
            WorldTransferRegistryMessage msg = (WorldTransferRegistryMessage)message;
            NetWorldReceiver.Receive(msg);
        }
    }
}
