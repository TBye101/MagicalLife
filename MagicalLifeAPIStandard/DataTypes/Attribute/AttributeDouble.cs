using MagicalLifeAPI.Entity.Util.Modifier;
using ProtoBuf;
using System.Collections.Generic;

namespace MagicalLifeAPI.DataTypes.Attribute
{
    [ProtoContract]
    public class AttributeDouble
    {
        /// <summary>
        /// The decimal value is applied to the value of this attribute, while the <see cref="IModifierRemoveCondition"/> is used to determine if the modifier will wear off.
        /// The string value is a display message/reason as to why the modifier was applied.
        /// </summary>
        [ProtoMember(1)]
        public List<ModifierDouble> Modifiers { get; private set; } = new List<ModifierDouble>();

        public AttributeDouble(double value) : this()
        {
            this.AddModifier(new ModifierDouble(value, new NeverRemoveCondition(), "Base value"));
        }

        public AttributeDouble()
        {
        }

        public double GetValue()
        {
            double ret = 0;
            foreach (ModifierDouble item in this.Modifiers)
            {
                ret += item.Value;
            }
            return ret;
        }

        /// <summary>
        /// Adds a modifier to the modifiers list.
        /// </summary>
        /// <param name="modifier"></param>
        public void AddModifier(ModifierDouble modifier)
        {
            this.Modifiers.Add(modifier);
        }

        public void WearOff()
        {
            lock (this.Modifiers)
            {
                int length = this.Modifiers.Count;
                for (int i = length - 1; i >= 0; i--)
                {
                    if (this.Modifiers[i].RemoveCondition.WearOff())
                    {
                        this.Modifiers.RemoveAt(i);
                    }
                }
            }
        }

        /// <summary>
        /// Sets the base value of this attribute.
        /// </summary>
        /// <param name="value"></param>
        public void SetBaseValue(double value)
        {
            ModifierDouble baseValue = this.Modifiers[0];
            baseValue.Value = value;

            this.Modifiers.RemoveAt(0);
            this.Modifiers.Insert(0, baseValue);
        }
    }
}