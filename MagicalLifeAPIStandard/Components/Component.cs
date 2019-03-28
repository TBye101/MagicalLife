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
        public Guid ID { get; set; }

        public Component()
        {
            this.ID = Guid.NewGuid();
        }
    }
}
