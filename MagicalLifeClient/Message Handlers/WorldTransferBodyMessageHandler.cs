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
    public class WorldTransferBodyMessageHandler : MessageHandler
    {
        public WorldTransferBodyMessageHandler() : base(NetMessageID.WorldTransferBodyMessage)
        {
        }

        public override void HandleMessage(BaseMessage message)
        {
            WorldTransferBodyMessage msg = (WorldTransferBodyMessage)message;
            NetWorldReceiver.Receive(msg);
        }
    }
}
