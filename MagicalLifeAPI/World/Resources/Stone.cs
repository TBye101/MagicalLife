using ProtoBuf;

namespace MagicalLifeAPI.World.Resources
{
    /// <summary>
    /// Stone as a resource.
    /// </summary>
    [ProtoContract]
    public class Stone : StoneBase
    {
        public Stone(int durability) : base("Stone", durability)
        {
        }

        public Stone() : base()
        {
        }

        public override string GetUnconnectedTexture()
        {
            return "Stone";
        }
    }
}