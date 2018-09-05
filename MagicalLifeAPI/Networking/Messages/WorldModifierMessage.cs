using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.Networking.World.Modifiers;
using ProtoBuf;

namespace MagicalLifeAPI.Networking.Messages
{
    /// <summary>
    /// Used to transfer <see cref="AbstractWorldModifier"/>s.
    /// </summary>
    [ProtoContract]
    public class WorldModifierMessage : BaseMessage
    {
        [ProtoMember(1)]
        public AbstractWorldModifier WorldModifier { get; private set; }

        public WorldModifierMessage(AbstractWorldModifier worldModifier) : base(NetMessageID.WorldModifierMessage)
        {
            this.WorldModifier = worldModifier;
        }

        public WorldModifierMessage() : base(NetMessageID.WorldModifierMessage)
        {
        }
    }
}