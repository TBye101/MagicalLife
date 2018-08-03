using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Networking.Serialization;

namespace MagicalLifeServer.Processing.Message
{
    public class DisconnectMessageHandler : MessageHandler
    {
        public DisconnectMessageHandler() : base(9)
        {
        }

        public override void HandleMessage(BaseMessage message)
        {
            DisconnectMessage msg = (DisconnectMessage)message;
            JobSystem.JobSystemManager.Manager.PlayerToJobSystem.Remove(msg.ClientPlayerID);
        }
    }
}
