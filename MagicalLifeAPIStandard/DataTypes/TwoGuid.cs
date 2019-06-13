using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeAPI.Pathfinding.TeleportationSearch
{
    /// <summary>
    /// Used to hold two guids.
    /// </summary>
    [ProtoContract]
    public struct TwoGuid : IComparer<TwoGuid>, IEquatable<TwoGuid>
    {
        [ProtoMember(1)]
        public Guid One { get; set; }

        [ProtoMember(2)]
        public Guid Two { get; set; }

        public TwoGuid(Guid one, Guid two)
        {
            this.One = one;
            this.Two = two;
        }

        public int Compare(TwoGuid x, TwoGuid y)
        {
            int result = x.One.CompareTo(y.One);

            if (result == 0)
            {
                return x.Two.CompareTo(y.Two);
            }
            else
            {
                return result;
            }
        }

        public bool Equals(TwoGuid other)
        {
            return other.One.Equals(this.One) && other.Two.Equals(this.Two);
        }
    }
}
