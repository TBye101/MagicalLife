using MLAPI.Networking;
using MLAPI.Networking.Messages;
using MLAPI.Networking.Serialization;

namespace MLClient.Message_Handlers
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