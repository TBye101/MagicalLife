using MLAPI.Networking;
using MLAPI.Networking.Messages;
using MLAPI.Networking.Serialization;

namespace MLServer.Processing.Message_Handlers
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