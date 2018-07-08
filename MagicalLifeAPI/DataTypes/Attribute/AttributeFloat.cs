using MagicalLifeAPI.Entities.Util.Modifier_Remove_Conditions;
using MagicalLifeAPI.Entity.Util;
using ProtoBuf;
using System.Collections.Generic;

namespace MagicalLifeAPI.DataTypes.Attribute
{
    [ProtoContract]
    public class AttributeFloat
    {
        /// <summary>
        /// The int value is applied to the value of this attribute, while the <see cref="IModifierRemoveCondition"/> is used to determine if the modifier will wear off.
        /// The string value is a display message/reason as to why the modifier was applied.
        /// </summary>
        [ProtoMember(1)]
        public List<ModifierFloat> Modifiers { get; private set; } = new List<ModifierFloat>();

        public AttributeFloat(float value) : this()
        {
            this.AddModifier(new ModifierFloat(value, new NeverRemoveCondition(), "Base value"));
        }

        public AttributeFloat()
        {
        }

        public float GetValue()
        {
            float ret = 0;
            foreach (ModifierFloat item in this.Modifiers)
            {
                ret += item.Value;
            }
            return ret;
        }

        /// <summary>
        /// Adds a modifier to the modifiers list.
        /// </summary>
        /// <param name="modifier"></param>
        public void AddModifier(ModifierFloat modifier)
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
    }
}