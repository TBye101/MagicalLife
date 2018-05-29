using MagicalLifeAPI.Entities.Util.Modifier_Remove_Conditions;
using ProtoBuf;
using System;
using System.Collections.Generic;

namespace MagicalLifeAPI.Entities.Util
{
    [ProtoContract]
    public class AttributeFloat
    {
        /// <summary>
        /// The int value is applied to the value of this attribute, while the <see cref="IModifierRemoveCondition"/> is used to determine if the modifier will wear off.
        /// The string value is a display message/reason as to why the modifier was applied.
        /// </summary>
        [ProtoMember(1)]
        public List<Tuple<float, IModifierRemoveCondition, string>> Modifiers { get; private set; } = new List<Tuple<float, IModifierRemoveCondition, string>>();

        public AttributeFloat(float value) : this()
        {
            this.AddModifier(new Tuple<float, IModifierRemoveCondition, string>(value, new NeverRemoveCondition(), "Base value"));
        }

        public AttributeFloat()
        {
        }

        public float GetValue()
        {
            float ret = 0;
            foreach (Tuple<float, IModifierRemoveCondition, string> item in this.Modifiers)
            {
                ret += item.Item1;
            }
            return ret;
        }

        /// <summary>
        /// Adds a modifier to the modifiers list.
        /// </summary>
        /// <param name="modifier"></param>
        public void AddModifier(Tuple<float, IModifierRemoveCondition, string> modifier)
        {
            this.Modifiers.Add(modifier);
        }

        public void WearOff()
        {
            List<Tuple<float, IModifierRemoveCondition, string>> remove = new List<Tuple<float, IModifierRemoveCondition, string>>();
            foreach (Tuple<float, IModifierRemoveCondition, string> item in this.Modifiers)
            {
                if (item.Item2.WearOff())
                {
                    remove.Add(item);
                }
            }

            foreach (Tuple<float, IModifierRemoveCondition, string> item in remove)
            {
                this.Modifiers.Remove(item);
            }
        }
    }
}