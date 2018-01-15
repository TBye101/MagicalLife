using MagicalLifeAPI.Entities.Util.IModifierRemoveConditions;
using MagicalLifeAPI.Universal;
using System;
using System.Collections.Generic;

namespace MagicalLifeAPI.Entities.Util
{
    public class Attribute
    {
        public Attribute()
        {
            MajorEvents.TurnEnd += this.MajorEvents_TurnEnd;
        }

        public Attribute(int value) : this()
        {
            this.AddModifier(new Tuple<long, IModifierRemoveCondition, string>(value, new NeverRemoveCondition(), "Base value"));
        }

        private void MajorEvents_TurnEnd(object sender, EventArgs e)
        {
            List<Tuple<Int64, IModifierRemoveCondition, string>> remove = new List<Tuple<Int64, IModifierRemoveCondition, string>>();
            foreach (Tuple<Int64, IModifierRemoveCondition, string> item in this.Modifiers)
            {
                if (item.Item2.WearOff())
                {
                    remove.Add(item);
                }
            }

            foreach (Tuple<Int64, IModifierRemoveCondition, string> item in remove)
            {
                this.Modifiers.Remove(item);
            }
        }

        public Int64 GetValue()
        {
            Int64 ret = 0;
            foreach (Tuple<Int64, IModifierRemoveCondition, string> item in this.Modifiers)
            {
                ret += item.Item1;
            }
            return ret;
        }

        /// <summary>
        /// The int value is applied to the value of this attribute, while the <see cref="IModifierRemoveCondition"/> is used to determine if the modifier will wear off.
        /// The string value is a display message/reason as to why the modifier was applied.
        /// </summary>
        public List<Tuple<Int64, IModifierRemoveCondition, string>> Modifiers { get; private set; } = new List<Tuple<Int64, IModifierRemoveCondition, string>>();

        /// <summary>
        /// Adds a modifier to the modifiers list.
        /// </summary>
        /// <param name="modifier"></param>
        public void AddModifier(Tuple<Int64, IModifierRemoveCondition, string> modifier)
        {
            this.Modifiers.Add(modifier);
        }
    }
}