using MagicalLifeAPI.Entity.Util.Modifier;
using ProtoBuf;

namespace MagicalLifeAPI.DataTypes.Attribute
{
    /// <summary>
    /// Used to store a modifier, and some other information for internal use.
    /// </summary>
    [ProtoContract]
    public struct ModifierDouble
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
    }
}