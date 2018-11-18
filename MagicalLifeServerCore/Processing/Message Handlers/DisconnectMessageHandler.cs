using MagicalLifeAPI.Networking;
using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Networking.Serialization;

namespace MagicalLifeServer.Processing.Message
{
    public class DisconnectMessageHandler : MessageHandler
    {
        public DisconnectMessageHandler() : base(NetMessageID.DisconnectMessage)
        {
        }

        public override void HandleMessage(BaseMessage message)
        {
            DisconnectMessage msg = (DisconnectMessage)message;
        }
    }
}