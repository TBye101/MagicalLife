using ProtoBuf;
using System;
using System.Collections.Generic;

namespace MagicalLifeAPI.Components
{
    /// <summary>
    /// The base class for all components.
    /// </summary>
    [ProtoContract]
    public class Component : IEquatable<Component>
    {
        public Guid ID { get; set; }

        public Component()
        {
            this.ID = Guid.NewGuid();
        }

        public override bool Equals(object obj)
        {
            Component comp = obj as Component;

            if (comp == null)
            {
                return false;
            }
            else
            {
                return this.Equals(comp);
            }
        }

        public bool Equals(Component other)
        {
            return this.ID.Equals(other.ID);
        }

        public override int GetHashCode()
        {
            return 1213502048 + EqualityComparer<Guid>.Default.GetHashCode(this.ID);
        }
    }
}