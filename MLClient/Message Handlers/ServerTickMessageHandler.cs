using MagicalLifeAPI.Networking;
using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.Universal;

namespace MagicalLifeClient.Message
{
    public class ServerTickMessageHandler : MessageHandler
    {
        public ServerTickMessageHandler() : base(NetMessageID.ServerTickMessage)
        {
        }

        public override void HandleMessage(BaseMessage message)
        {
            ServerTickMessage serverTickMessage = (ServerTickMessage)message;
            Uni.Tick(serverTickMessage);
        }
    }
}