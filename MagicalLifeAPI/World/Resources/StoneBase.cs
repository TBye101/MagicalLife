using ProtoBuf;

namespace MagicalLifeAPI.World.Resources
{
    /// <summary>
    /// The base class for all stone-like resources.
    /// </summary>
    [ProtoContract]
    [ProtoInclude(1, typeof(MarbleResource))]
    public abstract class StoneBase : Resource
    {
        public StoneBase(string name, int count) : base(name, count)
        {
        }

        public StoneBase() : base()
        {
        }
    }
}