using System;
using System.Collections.Generic;
using MagicalLifeAPI.GUI;
using MagicalLifeAPI.Networking;
using MagicalLifeAPI.World.Resources;
using ProtoBuf;

namespace MagicalLifeAPI.World
{
    /// <summary>
    /// A base class for all resources.
    /// Resources in tiles are things such as minerals.
    /// </summary>
    [ProtoContract]
    public abstract class Resource : HasTexture, IHasSubclasses
    {
        public Resource(string name, int count)
        {
            this.Name = name;
            this.Count = count;
        }

        public Resource()
        {

        }

        /// <summary>
        /// The display name of the resource.
        /// </summary>
        [ProtoMember(2)]
        public string Name { get; }

        /// <summary>
        /// How much of the resources is left.
        /// </summary>
        [ProtoMember(3)]
        public int Count { get; }

        public Type GetBaseType()
        {
            return typeof(Resource);
        }

        public Dictionary<Type, int> GetSubclassInformation()
        {
            Dictionary<Type, int> ret = new Dictionary<Type, int>();
            ret.Add(typeof(MarbleResource), 1);
            return ret;
        }
    }
}