using MagicalLifeAPI.World.Base;
using MagicalLifeAPI.World.Resources.Tree;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.World.Resources
{
    /// <summary>
    /// A base class for all trees. 
    /// </summary>
    [ProtoContract]
    [ProtoInclude(1, typeof(OakTree))]
    public abstract class TreeBase : Resource
    {
        public TreeBase(string name, int durability) : base(name, durability)
        {
        }

        protected TreeBase() : base()
        {

        }
    }
}