using MagicalLifeAPI.DataTypes.Attribute;
using MagicalLifeAPI.GUI;
using Microsoft.Xna.Framework;
using ProtoBuf;
using System;
using System.Collections.Generic;

namespace MagicalLifeAPI.World.Base
{
    /// <summary>
    /// Represents almost everything in a movable/harvested form.
    /// </summary>
    [ProtoContract]
    public abstract class Item : HasTexture
    {
        /// <summary>
        /// The name of this <see cref="Item"/>.
        /// </summary>
        [ProtoMember(1)]
        public string Name { get; }

        [ProtoMember(2)]
        public int Durability { get; set; }

        /// <summary>
        /// The item's resistance to fire. 0 is no resistance, 1 is completely immune to fire damage.
        /// </summary>
        [ProtoMember(3)]
        public AttributeFloat FireResistance { get; set; }

        /// <summary>
        /// The description and lore of this item. Is not revealed until the item has been identified, unless it never needed identification.
        /// </summary>
        [ProtoMember(4)]
        public List<string> Lore { get; set; }

        /// <summary>
        /// The location of this item within the world.
        /// </summary>
        [ProtoMember(5)]
        public Point Location { get; set; }

        /// <summary>
        /// The maximum number of this item that may be contained in the same stack.
        /// Must be greater than or equal to one.
        /// </summary>
        [ProtoMember(6)]
        public int StackableLimit { get; set; }

        /// <summary>
        /// How many identical items are currently being clumped and held be this class.
        /// </summary>
        [ProtoMember(7)]
        public int CurrentlyStacked { get; set; }

        /// <summary>
        /// The ID that describes this item to the <see cref="ItemRegistry"/>.
        /// </summary>
        public int ItemID { get; private set; }

        /// <summary>
        /// Combines two items and returns the result.
        /// Do not continue to use "one" or "two" afterwards, as this function reuses them for performance reasons.
        /// Doing so would cause unknown behavior.
        /// </summary>
        /// <param name="one"></param>
        /// <param name="two"></param>
        /// <param name="overflow">If the amount of the two items is too much, then this parameter is used to store the overflow. Otherwise, it is null.</param>
        /// <returns></returns>
        public static Item Combine(Item one, Item two, out Item overflow)
        {
            //Check to make sure the items are compatible, otherwise modders/hackers/bugs could be exploited to transmute cheap items into rarer things.
            if (one.GetType() == two.GetType())
            {
                one.CurrentlyStacked += two.CurrentlyStacked;

                int extra = one.CurrentlyStacked - one.StackableLimit;
                if (extra > 0)
                {
                    two.CurrentlyStacked = extra;
                    overflow = two;
                }
                else
                {
                    overflow = null;
                }

                return one;
            }
            else
            {
                throw new Exception("Error: Combining two items of different types is impossible to store.");
            }
        }
    }
}