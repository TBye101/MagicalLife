using MLAPI.Networking;
using MLAPI.Networking.Messages;
using MLAPI.Networking.Serialization;
using MLAPI.Networking.World;

namespace MLClient.Message_Handlers
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