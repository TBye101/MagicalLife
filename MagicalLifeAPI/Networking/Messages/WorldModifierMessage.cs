using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.Networking.World.Modifiers;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public WorldModifierMessage(AbstractWorldModifier worldModifier) : base(10)
        {
            this.WorldModifier = worldModifier;
        }

        public WorldModifierMessage() : base(10)
        {
        }
    }
}
