using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeAPI.Components
{
    /// <summary>
    /// The base class for all components.
    /// </summary>
    [ProtoContract]
    public class Component
    {
        [ProtoMember(1)]
        public Guid ID { get; private set; }

        /// <param name="constantID">This value should be constant/hard coded.</param>
        public Component(Guid constantID)
        {
            this.ID = constantID;
        }

        protected Component()
        {
            //Protobuf-net constructor
        }
    }
}
