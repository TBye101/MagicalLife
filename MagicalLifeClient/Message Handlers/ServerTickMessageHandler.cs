using MagicalLifeAPI.Networking;
using MagicalLifeNetworking.Messages;

namespace MagicalLifeClient.Message_Handlers
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