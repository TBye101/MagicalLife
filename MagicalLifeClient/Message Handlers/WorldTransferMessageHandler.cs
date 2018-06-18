using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Networking.Serialization;

namespace MagicalLifeAPI.Networking.Message_Handlers
{
    public class WorldTransferMessageHandler : MessageHandler
    {
        public WorldTransferMessageHandler() : base(2)
        {
        }

        public override void HandleMessage(BaseMessage message)
        {
            WorldTransferMessage msg = (WorldTransferMessage)message;
            World.Data.World.Dimensions = msg.World;
        }
    }
}