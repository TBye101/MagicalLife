using MagicalLifeAPI.World.Base;
using ProtoBuf;

namespace MagicalLifeAPI.World.Resources
{
    /// <summary>
    /// A base class for all trees.
    /// </summary>
    [ProtoContract]
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