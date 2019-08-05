using MLAPI.Networking;
using MLAPI.Networking.Messages;
using MLAPI.Networking.Serialization;
using MLAPI.Universal;

namespace MLClient.Message_Handlers
{
    public class ServerTickMessageHandler : MessageHandler
    {
        public ServerTickMessageHandler() : base(NetMessageId.ServerTickMessage)
        {
        }

        public override void HandleMessage(BaseMessage message)
        {
            ServerTickMessage serverTickMessage = (ServerTickMessage)message;
            Uni.Tick(serverTickMessage);
        }
    }
}