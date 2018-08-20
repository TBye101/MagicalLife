using MagicalLifeAPI.Networking;
using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.World.Data;
using MagicalLifeAPI.World.Data.Disk.DataStorage;

namespace MagicalLifeClient.Message
{
    public class WorldTransferHeaderMessageHandler : MessageHandler
    {
        public WorldTransferHeaderMessageHandler() : base(NetMessageID.WorldTransferHeaderMessage)
        {
        }

        public override void HandleMessage(BaseMessage message)
        {
            WorldTransferHeaderMessage msg = (WorldTransferHeaderMessage)message;

            foreach (DimensionHeader item in msg.DimensionHeaders)
            {
                //Prepare receiver
            }
        }
    }
}