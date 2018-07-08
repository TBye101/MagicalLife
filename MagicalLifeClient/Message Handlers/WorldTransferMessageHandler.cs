using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.World.Data;

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

            foreach (Dimension item in msg.World)
            {
                World.Data.World.AddDimension(item);
            }
        }
    }
}