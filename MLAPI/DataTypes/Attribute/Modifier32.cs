using System;
using MLAPI.Entity.Util.Modifier_Remove_Conditions;
using ProtoBuf;

namespace MLAPI.DataTypes.Attribute
{
    /// <summary>
    /// Used to store a modifier, and some other information for internal use.
    /// </summary>
    [ProtoContract]
    public struct Modifier32 : IEquatable<Modifier32>
    {
        [ProtoMember(1)]
        public Int32 Value { get; set; }

        [ProtoMember(2)]
        public IModifierRemoveCondition RemoveCondition { get; set; }

        [ProtoMember(3)]
        public string Explanation { get; set; }

        public Modifier32(Int32 value, IModifierRemoveCondition removeCondition, string explanation)
        {
            this.Value = value;
            this.RemoveCondition = removeCondition;
            this.Explanation = explanation;
        }

        public override bool Equals(object obj)
        {
            if (obj is Modifier32 modifier32)
            {
                return this.Equals(modifier32);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return Explanation.GetHashCode() ^ Value;
        }

        public bool Equals(Modifier32 other)
        {
            return other.Explanation == Explanation && other.Value == Value;
        }

        public static bool operator ==(Modifier32 left, Modifier32 right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Modifier32 left, Modifier32 right)
        {
            return !left.Equals(right);
        }
    }
}