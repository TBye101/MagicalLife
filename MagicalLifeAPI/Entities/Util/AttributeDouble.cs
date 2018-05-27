using MagicalLifeAPI.Entities.Util.Modifier_Remove_Conditions;
using ProtoBuf;
using System;
using System.Collections.Generic;

namespace MagicalLifeAPI.Entities.Util
{
    [ProtoContract]
    public class AttributeDouble
    {
        /// <summary>
        /// The int value is applied to the value of this attribute, while the <see cref="IModifierRemoveCondition"/> is used to determine if the modifier will wear off.
        /// The string value is a display message/reason as to why the modifier was applied.
        /// </summary>
        [ProtoMember(1)]
        public List<Tuple<Double, IModifierRemoveCondition, string>> Modifiers { get; private set; } = new List<Tuple<Double, IModifierRemoveCondition, string>>();

        public AttributeDouble(Double value) : this()
        {
            this.AddModifier(new Tuple<Double, IModifierRemoveCondition, string>(value, new NeverRemoveCondition(), "Base value"));
        }

        public AttributeDouble()
        {
        }

        public Double GetValue()
        {
            Double ret = 0;
            foreach (Tuple<Double, IModifierRemoveCondition, string> item in this.Modifiers)
            {
                ret += item.Item1;
            }
            return ret;
        }

        /// <summary>
        /// Adds a modifier to the modifiers list.
        /// </summary>
        /// <param name="modifier"></param>
        public void AddModifier(Tuple<Double, IModifierRemoveCondition, string> modifier)
        {
            this.Modifiers.Add(modifier);
        }

        private void World_TurnEnd(object sender, World.WorldEventArgs e)
        {
            List<Tuple<Double, IModifierRemoveCondition, string>> remove = new List<Tuple<Double, IModifierRemoveCondition, string>>();
            foreach (Tuple<Double, IModifierRemoveCondition, string> item in this.Modifiers)
            {
                if (item.Item2.WearOff())
                {
                    remove.Add(item);
                }
            }

            foreach (Tuple<Double, IModifierRemoveCondition, string> item in remove)
            {
                this.Modifiers.Remove(item);
            }
        }
    }
}