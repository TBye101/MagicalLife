using MagicalLifeAPI.Components.Resource;
using MagicalLifeAPI.DataTypes.Attribute;
using MagicalLifeAPI.GUI;
using MagicalLifeAPI.Networking;
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
    [ProtoInclude(1, typeof(StoneBase))]
    public abstract class Resource : HasTexture, IHasSubclasses, IMinable
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
        [ProtoMember(2)]
        public string DisplayName { get; }

        /// <summary>
        /// How much of the resources is left.
        /// </summary>
        [ProtoMember(3)]
        public int Durability { get; set; }

        [ProtoMember(4)]
        public Attribute32 MaxDurability { get; }

        [ProtoMember(5)]
        public abstract AbstractMinable MiningBehavior { get; set; }

        public Type GetBaseType()
        {
            return typeof(Resource);
        }

        public Dictionary<Type, int> GetSubclassInformation()
        {
            Dictionary<Type, int> ret = new Dictionary<Type, int>
            {
                { typeof(Stone), 1 }
            };
            return ret;
        }
    }
}