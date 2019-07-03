using ProtoBuf;

namespace MagicalLifeAPI.DataTypes.Attribute
{
    /// <summary>
    /// Supports a double value that has a double multiplying it.
    /// </summary>
    [ProtoContract]
    public class ComboDoubleAttribute
    {
        [ProtoMember(1)]
        public AttributeDouble BaseValue { get; set; }

        [ProtoMember(2)]
        public AttributeDouble Multiplier { get; set; }

        public ComboDoubleAttribute(int baseValue, double baseMultiplier)
        {
            this.BaseValue = new AttributeDouble(baseValue);
            this.Multiplier = new AttributeDouble(baseMultiplier);
        }

        protected ComboDoubleAttribute()
        {
            //Protobuf-net constructor.
        }

        /// <summary>
        /// Adds the specified modifier to the base value of this <see cref="ComboAttribute"/>.
        /// </summary>
        /// <param name="baseValue"></param>
        public void AddToBaseValue(ModifierDouble baseValue)
        {
            this.BaseValue.AddModifier(baseValue);
        }

        /// <summary>
        /// Adds the specified modifier to the multiplier value of this <see cref="ComboAttribute"/>.
        /// </summary>
        /// <param name="multiplierValue"></param>
        public void AddToModifier(ModifierDouble multiplierValue)
        {
            this.Multiplier.AddModifier(multiplierValue);
        }

        /// <summary>
        /// Returns the calculated value of this <see cref="ComboAttribute"/>.
        /// </summary>
        /// <returns></returns>
        public double GetValue()
        {
            return this.BaseValue.GetValue() * this.Multiplier.GetValue();
        }

        public void SetBaseValue(int value)
        {
            this.BaseValue.SetBaseValue(value);
        }
    }
}