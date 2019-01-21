using ProtoBuf;

namespace MagicalLifeAPI.DataTypes.Attribute
{
    /// <summary>
    /// This type of attribute combines both whole number attributes
    /// and float based attributes in order to support a whole number attribute that has a multiplier multiplying it.
    /// </summary>
    [ProtoContract]
    public class ComboAttribute
    {
        [ProtoMember(1)]
        public Attribute32 BaseValue { get; set; }

        [ProtoMember(2)]
        public AttributeDouble Multiplier { get; set; }

        public ComboAttribute(int baseValue, double baseMultiplier)
        {
            this.BaseValue = new Attribute32(baseValue);
            this.Multiplier = new AttributeDouble(baseMultiplier);
        }

        protected ComboAttribute()
        {
            //Protobuf-net constructor.
        }

        /// <summary>
        /// Adds the specified modifier to the base value of this <see cref="ComboAttribute"/>.
        /// </summary>
        /// <param name="baseValue"></param>
        public void AddToBaseValue(Modifier32 baseValue)
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