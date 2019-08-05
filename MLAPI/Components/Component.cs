using System;
using System.Collections.Generic;
using ProtoBuf;

namespace MLAPI.Components
{
    /// <summary>
    /// The base class for all components.
    /// </summary>
    [ProtoContract]
    public class Component : IEquatable<Component>
    {
        public Guid Id { get; set; }

        public Component()
        {
            this.Id = Guid.NewGuid();
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
            return this.Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return 1213502048 + EqualityComparer<Guid>.Default.GetHashCode(this.Id);
        }
    }
}