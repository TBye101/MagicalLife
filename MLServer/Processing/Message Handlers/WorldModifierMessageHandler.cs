using MagicalLifeAPI.Networking;
using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.Networking.Server;

namespace MagicalLifeServer.Processing.Message
{
    public class WorldModifierMessageHandler : MessageHandler
    {
        public WorldModifierMessageHandler() : base(NetMessageID.WorldModifierMessage)
        {
        }

        public override void HandleMessage(BaseMessage message)
        {
            WorldModifierMessage msg = (WorldModifierMessage)message;

            ServerSendRecieve.SendAllExcept(msg, msg.PlayerID);
            msg.WorldModifier.ModifyWorld();
        }
    }
}