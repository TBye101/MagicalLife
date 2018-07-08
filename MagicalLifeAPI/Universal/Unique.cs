using ProtoBuf;
using System;

namespace MagicalLifeAPI.Universal
{
    /// <summary>
    /// Gives whatever inherits from this a unique ID.
    /// </summary>
    [ProtoContract]
    public class Unique
    {
        [ProtoMember(1)]
        public Guid ID { get; } = Guid.NewGuid();

        public Unique()
        {
        }
    }
}