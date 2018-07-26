using MagicalLifeAPI.GUI;
using MagicalLifeAPI.Networking;
using MagicalLifeAPI.World.Resources;
using ProtoBuf;
using System;
using System.Collections.Generic;

namespace MagicalLifeAPI.World
{
    /// <summary>
    /// A base class for all resources.
    /// Resources in tiles are things such as stone and minerals.
    /// </summary>
    [ProtoContract]
    [ProtoInclude(1, typeof(StoneBase))]
    public abstract class Resource : HasTexture, IHasSubclasses
    {
        public Resource(string name, int durability)
        {
            this.DisplayName = name;
            this.Durability = durability;
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
        public int Durability { get; }

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