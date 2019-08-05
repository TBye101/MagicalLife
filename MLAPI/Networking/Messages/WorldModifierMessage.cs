using MLAPI.Networking.Serialization;
using MLAPI.Networking.World.Modifiers;
using ProtoBuf;

namespace MLAPI.Networking.Messages
{
    /// <summary>
    /// Used to transfer <see cref="AbstractWorldModifier"/>s.
    /// </summary>
    [ProtoContract]
    public class WorldModifierMessage : BaseMessage
    {
        [ProtoMember(1)]
        public AbstractWorldModifier WorldModifier { get; private set; }

        public WorldModifierMessage(AbstractWorldModifier worldModifier) : base(NetMessageId.WorldModifierMessage)
        {
            this.WorldModifier = worldModifier;
        }

        public WorldModifierMessage()
        {
            //Protobuf-net constructor.
        }
    }
}