using MagicalLifeAPI.Entity.Util.Modifier;
using ProtoBuf;
using System;
using System.Collections.Generic;

namespace MagicalLifeAPI.DataTypes.Attribute
{
    [ProtoContract]
    public class Attribute32
    {
        private static readonly string BaseValueText = "Base Value";

        /// <summary>
        /// The int value is applied to the value of this attribute, while the <see cref="IModifierRemoveCondition"/> is used to determine if the modifier will wear off.
        /// The string value is a display message/reason as to why the modifier was applied.
        /// </summary>
        [ProtoMember(1)]//This doesn't serialize.
        public List<Modifier32> Modifiers { get; private set; } = new List<Modifier32>();

        public Attribute32(Int32 value) : this()
        {
            this.Modifiers.Add(new Modifier32(value, new NeverRemoveCondition(), BaseValueText));
        }

        public Attribute32()
        {
        }

        public int GetValue()
        {
            int ret = 0;
            foreach (Modifier32 item in this.Modifiers)
            {
                ret += item.Value;
            }
            return ret;
        }

        /// <summary>
        /// Adds a modifier to the modifiers list.
        /// </summary>
        /// <param name="modifier"></param>
        public void AddModifier(Modifier32 modifier)
        {
            this.Modifiers.Add(modifier);
        }

        public void AddModifiers(IList<Modifier32> modifiers)
        {
            this.Modifiers.AddRange(modifiers);
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
        public void SetBaseValue(int value)
        {
            Modifier32 baseValue = this.Modifiers[0];
            baseValue.Value = value;

            this.Modifiers.RemoveAt(0);
            this.Modifiers.Insert(0, baseValue);
        }

        public static Attribute32 operator+ (Attribute32 a, Attribute32 b)
        {
            Attribute32 ret = new Attribute32();
            ret.AddModifiers(a.Modifiers);
            ret.AddModifiers(b.Modifiers);
            return ret;
        }

        public static Attribute32 operator- (Attribute32 a, Attribute32 b)//Write tests, test, then come up with generic solution to combine with the other types of attributes
        {
            Attribute32 ret = new Attribute32();
            ret.AddModifiers(a.Modifiers);

            foreach (Modifier32 item in b.Modifiers)
            {
                if (ret.Modifiers.Contains(item))
                {
                    ret.Modifiers.Remove(item);
                }
                else
                {
                    ret.Modifiers.Add(new Modifier32(item.Value * -1, item.RemoveCondition, "-" + item.Explanation));
                }
            }

            return ret;
        }
    }
}