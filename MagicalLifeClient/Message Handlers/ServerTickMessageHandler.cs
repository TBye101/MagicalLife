using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Networking.Serialization;

namespace MagicalLifeClient.Message
{
    public class ServerTickMessageHandler : MessageHandler
    {
        public ServerTickMessageHandler() : base(4)
        {
        }

        public override void HandleMessage(BaseMessage message)
        {
            ServerTickMessage serverTickMessage = (ServerTickMessage)message;
            Client.Tick(serverTickMessage);
        }
    }
}