using ProtoBuf;
using System;
using System.ComponentModel;

namespace MagicalLifeAPI.Universal
{
    /// <summary>
    /// Gives whatever inherits from this a unique ID.
    /// </summary>
    [ProtoContract(SkipConstructor = true)]
    public class Unique
    {
        [ProtoMember(1)]
        public Guid ID { get; }

        public Unique(bool doesntMatter)
        {
            this.ID = Guid.NewGuid();
        }

        private Unique()
        {
            //Protobuf-net constructor
        }
    }
}