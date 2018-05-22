using MagicalLifeAPI.Entities.Util.Modifier_Remove_Conditions;
using ProtoBuf;
using System;
using System.Collections.Generic;

namespace MagicalLifeAPI.Entities.Util
{
    [ProtoContract]
    public class Attribute
    {
        public Attribute()
        {
        }

        private void World_TurnEnd(object sender, World.WorldEventArgs e)
        {
            List<Tuple<Int32, IModifierRemoveCondition, string>> remove = new List<Tuple<Int32, IModifierRemoveCondition, string>>();
            foreach (Tuple<Int32, IModifierRemoveCondition, string> item in this.Modifiers)
            {
                if (item.Item2.WearOff())
                {
                    remove.Add(item);
                }
            }

            foreach (Tuple<Int32, IModifierRemoveCondition, string> item in remove)
            {
                this.Modifiers.Remove(item);
            }
        }

        public Attribute(int value) : this()
        {
            this.AddModifier(new Tuple<Int32, IModifierRemoveCondition, string>(value, new NeverRemoveCondition(), "Base value"));
        }

        public Int32 GetValue()
        {
            Int32 ret = 0;
            foreach (Tuple<Int32, IModifierRemoveCondition, string> item in this.Modifiers)
            {
                ret += item.Item1;
            }
            return ret;
        }

        /// <summary>
        /// The int value is applied to the value of this attribute, while the <see cref="IModifierRemoveCondition"/> is used to determine if the modifier will wear off.
        /// The string value is a display message/reason as to why the modifier was applied.
        /// </summary>
        [ProtoMember(1)]
        public List<Tuple<Int32, IModifierRemoveCondition, string>> Modifiers { get; private set; } = new List<Tuple<Int32, IModifierRemoveCondition, string>>();

        /// <summary>
        /// Adds a modifier to the modifiers list.
        /// </summary>
        /// <param name="modifier"></param>
        public void AddModifier(Tuple<Int32, IModifierRemoveCondition, string> modifier)
        {
            this.Modifiers.Add(modifier);
        }
    }
}