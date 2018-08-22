using MagicalLifeAPI.Networking;
using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.Networking.World;

namespace MagicalLifeClient.Message
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