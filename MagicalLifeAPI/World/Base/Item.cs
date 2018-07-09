using MagicalLifeAPI.DataTypes.Attribute;
using MagicalLifeAPI.GUI;
using Microsoft.Xna.Framework;
using ProtoBuf;
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
        /// The ID that describes this item to the <see cref="ItemRegistry"/>.
        /// </summary>
        public int ItemID { get; private set; }
    }
}