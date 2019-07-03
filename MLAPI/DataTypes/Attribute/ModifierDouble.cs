using MagicalLifeAPI.Entity.Util.Modifier;
using ProtoBuf;
using System;

namespace MagicalLifeAPI.DataTypes.Attribute
{
    /// <summary>
    /// Used to store a modifier, and some other information for internal use.
    /// </summary>
    [ProtoContract]
    public struct ModifierDouble : IEquatable<ModifierDouble>
    {
        [ProtoMember(1)]
        public double Value { get; set; }

        [ProtoMember(2)]
        public IModifierRemoveCondition RemoveCondition { get; set; }

        [ProtoMember(3)]
        public string Explanation { get; set; }

        public ModifierDouble(double value, IModifierRemoveCondition removeCondition, string explanation)
        {
            this.Value = value;
            this.RemoveCondition = removeCondition;
            this.Explanation = explanation;
        }

        public override bool Equals(object obj)
        {
            if (obj is ModifierDouble modifier32)
            {
                return this.Equals(modifier32);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Explanation.GetHashCode() ^ (int)Value;
        }

        public bool Equals(ModifierDouble other)
        {
            return other.Explanation == Explanation && other.Value == Value;
        }

        public static bool operator ==(ModifierDouble left, ModifierDouble right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ModifierDouble left, ModifierDouble right)
        {
            return !left.Equals(right);
        }
    }
}