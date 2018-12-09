using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.Components.Resource;
using MagicalLifeAPI.DataTypes.Attribute;
using MagicalLifeAPI.GUI;
using MagicalLifeAPI.Networking;
using MagicalLifeAPI.Visual.Rendering;
using MagicalLifeAPI.World.Resources;
using ProtoBuf;
using System;
using System.Collections.Generic;

namespace MagicalLifeAPI.World.Base
{
    /// <summary>
    /// A base class for all resources.
    /// Resources in tiles are things such as stone and minerals.
    /// </summary>
    [ProtoContract]
    [ProtoInclude(7, typeof(RockBase))]
    [ProtoInclude(8, typeof(TreeBase))]
    public abstract class Resource : HasTexture, IHasSubclasses, IHarvestable, IRenderable
    {
        public Resource(string name, int durability)
        {
            this.DisplayName = name;
            this.Durability = durability;
            this.MaxDurability = new Attribute32(this.Durability);
        }

        public Resource()
        {
        }

        /// <summary>
        /// The display name of the resource.
        /// </summary>
        [ProtoMember(3)]
        public string DisplayName { get; }

        /// <summary>
        /// How much of the resources is left.
        /// </summary>
        [ProtoMember(4)]
        public int Durability { get; set; }

        [ProtoMember(5)]
        public Attribute32 MaxDurability { get; }

        [ProtoMember(6)]
        public abstract AbstractHarvestable HarvestingBehavior { get; set; }

        public Type GetBaseType()
        {
            return typeof(Resource);
        }

        public Dictionary<Type, int> GetSubclassInformation()
        {
            Dictionary<Type, int> ret = new Dictionary<Type, int>
            {
                { typeof(RockBase), 7 },
                { typeof(TreeBase), 8 }
            };
            return ret;
        }

        public abstract List<AbstractVisual> GetVisuals();
    }
}