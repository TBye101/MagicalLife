using MLAPI.Networking;
using MLAPI.Networking.Messages;
using MLAPI.Networking.Serialization;
using MLAPI.Networking.Server;

namespace MLServer.Processing.Message_Handlers
{
    public class WorldModifierMessageHandler : MessageHandler
    {
        public WorldModifierMessageHandler() : base(NetMessageId.WorldModifierMessage)
        {
        }

        public override void HandleMessage(BaseMessage message)
        {
            WorldModifierMessage msg = (WorldModifierMessage)message;

            ServerSendRecieve.SendAllExcept(msg, msg.PlayerId);
            msg.WorldModifier.ModifyWorld();
        }
    }
}