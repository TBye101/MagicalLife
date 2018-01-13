using MagicalLifeAPI.Universal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Entities.Util
{
    public class Attribute
    {
        public Attribute()
        {
            MajorEvents.TurnEnd += this.MajorEvents_TurnEnd;
        }

        private void MajorEvents_TurnEnd(object sender, EventArgs e)
        {
            List<Tuple<Int64, IModifierRemoveCondition>> remove = new List<Tuple<Int64, IModifierRemoveCondition>>();
            foreach (Tuple<Int64, IModifierRemoveCondition> item in this.Modifiers)
            {
                if (item.Item2.WearOff())
                {
                    remove.Add(item);
                }
            }

            foreach (Tuple<Int64, IModifierRemoveCondition> item in remove)
            {
                this.Modifiers.Remove(item);
            }
        }

        public Int64 GetValue()
        {
            Int64 ret = 0;
            foreach (Tuple<Int64, IModifierRemoveCondition> item in this.Modifiers)
            {
                ret += item.Item1;
            }
            return ret;
        }

        /// <summary>
        /// The int value is applied to the value of this attribute, while the <see cref="IModifierRemoveCondition"/> is used to determine if the modifier will wear off.
        /// </summary>
        public List<Tuple<Int64, IModifierRemoveCondition>> Modifiers { get; private set; } = new List<Tuple<Int64, IModifierRemoveCondition>>();

        /// <summary>
        /// Adds a modifier to the modifiers list.
        /// </summary>
        /// <param name="modifier"></param>
        public void AddModifier(Tuple<Int64, IModifierRemoveCondition> modifier)
        {
            this.Modifiers.Add(modifier);
        }
    }
}
