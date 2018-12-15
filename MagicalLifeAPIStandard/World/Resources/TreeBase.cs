using MagicalLifeAPI.World.Base;
using MagicalLifeAPI.World.Resources.Tree;
using ProtoBuf;

namespace MagicalLifeAPI.World.Resources
{
    /// <summary>
    /// A base class for all trees.
    /// </summary>
    [ProtoContract]
    [ProtoInclude(1, typeof(OakTree))]
    [ProtoInclude(2, typeof(MapleTree))]
    [ProtoInclude(3, typeof(PineTree))]
    public abstract class TreeBase : Resource
    {
        protected TreeBase(string name, int durability) : base(name, durability)
        {
        }

        protected TreeBase()
        {
        }
    }
}