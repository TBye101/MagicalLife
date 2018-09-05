using MagicalLifeAPI.Networking;
using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Networking.Serialization;

namespace MagicalLifeClient.Message
{
    /// <summary>
    /// Handles the <see cref="WorldModifierMessage"/> for the client.
    /// </summary>
    public class WorldModifierMessageHandler : MessageHandler
    {
        public WorldModifierMessageHandler() : base(NetMessageID.WorldModifierMessage)
        {
        }

        public override void HandleMessage(BaseMessage message)
        {
            WorldModifierMessage msg = (WorldModifierMessage)message;
            msg.WorldModifier.ModifyWorld();
        }
    }
}