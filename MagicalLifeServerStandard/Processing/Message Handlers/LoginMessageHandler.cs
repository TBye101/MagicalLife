using MagicalLifeAPI.Networking;
using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Networking.Serialization;

namespace MagicalLifeServer.Processing.Message
{
    public class LoginMessageHandler : MessageHandler
    {
        public LoginMessageHandler() : base(NetMessageID.LoginMessage)
        {
        }

        public override void HandleMessage(BaseMessage message)
        {
            LoginMessage msg = (LoginMessage)message;
        }
    }
}