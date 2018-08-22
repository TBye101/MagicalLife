using MagicalLifeAPI.Networking;
using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeServer.JobSystem;

namespace MagicalLifeServer.Processing.Message
{
    public class JobCompletedMessageHandler : MessageHandler
    {
        public JobCompletedMessageHandler() : base(NetMessageID.JobCompletedMessage)
        {
        }

        public override void HandleMessage(BaseMessage message)
        {
            JobCompletedMessage msg = (JobCompletedMessage)message;
            JobSystemManager.Manager.PlayerToJobSystem[msg.PlayerID].MarkJobAsComplete(msg.CompletedID);
        }
    }
}