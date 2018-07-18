using ProtoBuf;

namespace MagicalLifeAPI.World.Resources
{
    /// <summary>
    /// Stone as a resource.
    /// </summary>
    [ProtoContract]
    public class MarbleResource : StoneBase
    {
        public MarbleResource(int count) : base("Marble", count)
        {
        }

        public MarbleResource() : base()
        {
        }

        public override string GetUnconnectedTexture()
        {
            return "MarbleResourceUnconnected";
        }
    }
}