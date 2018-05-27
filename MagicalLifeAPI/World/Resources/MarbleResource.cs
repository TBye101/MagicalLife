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

        public override string GetConnectedFourTexture()
        {
            return "MarbleResourceConnected4";
        }

        public override string GetConnectedOneTexture()
        {
            return "MarbleResourceConnected1";
        }

        public override string GetConnectedThreeTexture()
        {
            return "MarbleResourceConnected3";
        }

        public override string GetConnectedTwoTexture()
        {
            return "MarbleResourceConnected2";
        }

        public override string GetUnconnectedTexture()
        {
            return "MarbleResourceUnconnected";
        }
    }
}