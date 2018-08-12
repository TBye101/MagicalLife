using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.Networking;

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
            JobSystem.JobSystemManager.Manager.PlayerToJobSystem.Remove(msg.ClientPlayerID);
        }
    }
}
