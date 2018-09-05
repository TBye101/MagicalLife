using MagicalLifeAPI.Entity.Util.Modifier;
using ProtoBuf;
using System;

namespace MagicalLifeAPI.DataTypes.Attribute
{
    /// <summary>
    /// Used to store a modifier, and some other information for internal use.
    /// </summary>
    [ProtoContract]
    public struct Modifier32
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
    }
}