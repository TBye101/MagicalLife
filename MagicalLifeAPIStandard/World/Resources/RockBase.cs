using MagicalLifeAPI.World.Base;
using ProtoBuf;

namespace MagicalLifeAPI.World.Resources
{
    /// <summary>
    /// The base class for all stone-like resources.
    /// </summary>
    [ProtoContract]
    [ProtoInclude(1, typeof(Rock))]
    public abstract class RockBase : Resource
    {
        protected RockBase(string name, int durability) : base(name, durability)
        {
        }

        protected RockBase()
        {
        }

        public abstract string GetUnconnectedTexture();
    }
}