using MagicalLifeAPI.Entities.Util.Modifier_Remove_Conditions;
using MagicalLifeAPI.Filing.Logging;
using ProtoBuf;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public ConcurrentStack<Tuple<float, IModifierRemoveCondition, string>> Modifiers { get; private set; } = new ConcurrentStack<Tuple<float, IModifierRemoveCondition, string>>();

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
            this.Modifiers.Push(modifier);
        }

        public void WearOff()
        {
            foreach (Tuple<float, IModifierRemoveCondition, string> item in this.Modifiers)
            {
                Tuple<float, IModifierRemoveCondition, string> o;
                if (this.Modifiers.TryPop(out o))
                {
                    if (!o.Item2.WearOff())
                    {
                        this.Modifiers.Push(o);
                    }
                }
            }
        }
    }
}