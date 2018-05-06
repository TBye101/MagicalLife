using MagicalLifeAPI.Networking.Messages;

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
            World.World.mainWorld = msg.World;
        }
    }
}