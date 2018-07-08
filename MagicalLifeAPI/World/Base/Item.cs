using MagicalLifeAPI.DataTypes.Attribute;
using MagicalLifeAPI.Entities.Util;
using MagicalLifeAPI.GUI;
using MagicalLifeAPI.Universal;
using ProtoBuf;

namespace MagicalLifeAPI.World.Base
{
    /// <summary>
    /// Represents almost everything in a movable/harvested form.
    /// </summary>
    [ProtoContract]
    public abstract class Item : HasTexture
    {
        /// <summary>
        /// The name of this <see cref="Item"/>;
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
        /// If true, then the item is probably magical and needs to be identified. 
        /// </summary>
        [ProtoMember(4)]
        public bool NeedsIdentifying { get; set; }

        /// <summary>
        /// Determines how hard it is to identify this object. 
        /// </summary>
        [ProtoMember(5)]
        public int IdentificationDifficulty { get; set; }

        /// <summary>
        /// The description and lore of this item. Is not revealed until the item has been identified, unless it never needed identification.
        /// </summary>
        [ProtoMember(6)]
        public string[] Lore { get; set; }
    }
}