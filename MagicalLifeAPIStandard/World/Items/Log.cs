using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.World.Base;
using ProtoBuf;
using System.Collections.Generic;

namespace MagicalLifeAPI.World.Items
{
    /// <summary>
    /// Represents a log in the world.
    /// </summary>
    [ProtoContract]
    public class Log : Item
    {
        private static readonly string ItemName = "Log";

        public Log(int count, int durability)
            : base(ItemName, durability, new List<string>(), 50, count, typeof(Log), TextureLoader.LogTexture1, 5)
        {
        }

        protected Log()
        {
            //Protobuf-net constructor.
        }

        public override List<AbstractVisual> GetVisuals()
        {
            return new List<AbstractVisual>
            {
                new StaticTexture(AssetManager.NameToIndex[TextureLoader.LogTexture1], RenderLayer.Items)
            };
        }
    }
}