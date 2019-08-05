using MLAPI.Networking;
using MLAPI.Networking.Messages;
using MLAPI.Networking.Serialization;
using MLAPI.Networking.World;

namespace MLClient.Message_Handlers
{
    public class WorldTransferRegistryMessageHandler : MessageHandler
    {
        public WorldTransferRegistryMessageHandler() : base(NetMessageId.WorldTransferRegistryMessage)
        {
        }

        public override void HandleMessage(BaseMessage message)
        {
            WorldTransferRegistryMessage msg = (WorldTransferRegistryMessage)message;
            NetWorldReceiver.Receive(msg);
        }
    }
}