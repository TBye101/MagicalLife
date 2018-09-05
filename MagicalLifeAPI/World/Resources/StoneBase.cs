using MagicalLifeAPI.World.Base;
using ProtoBuf;

namespace MagicalLifeAPI.World.Resources
{
    /// <summary>
    /// The base class for all stone-like resources.
    /// </summary>
    [ProtoContract]
    [ProtoInclude(1, typeof(Stone))]
    public abstract class StoneBase : Resource
    {
        public StoneBase(string name, int durability) : base(name, durability)
        {
        }

        public StoneBase() : base()
        {
        }

        public abstract string GetUnconnectedTexture();
    }
}