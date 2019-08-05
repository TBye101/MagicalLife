using MLAPI.Networking;
using MLAPI.Networking.Messages;
using MLAPI.Networking.Serialization;

namespace MLServer.Processing.Message_Handlers
{
    public class DisconnectMessageHandler : MessageHandler
    {
        public DisconnectMessageHandler() : base(NetMessageId.DisconnectMessage)
        {
        }

        public override void HandleMessage(BaseMessage message)
        {
            DisconnectMessage msg = (DisconnectMessage)message;
        }
    }
}