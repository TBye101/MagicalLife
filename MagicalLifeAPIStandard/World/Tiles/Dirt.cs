using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.Components.Resource;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Properties;
using MagicalLifeAPI.Util;
using MagicalLifeAPI.World.Base;

namespace MagicalLifeAPI.World.Tiles
{
    /// <summary>
    /// A dirt tile.
    /// </summary>
    [ProtoBuf.ProtoContract]
    public class Dirt : Tile
    {
        public Dirt(Point2D location) : base(location, 10, 0)
        {
            this.AddComponent(new TillablePercentDone());
            this.GetExactComponent<ComponentRenderer>().RenderQueue.Add(
                new StaticTexture(Dirt.GetTextureID(), RenderLayer.DirtBase));
        }

        public Dirt(int x, int y) : this(new Point2D(x, y))
        {
        }

        public Dirt() : base()
        {
        }

        protected static ComponentRenderer GetRenderer()
        {
            ComponentRenderer renderer = new ComponentRenderer();
            StaticTexture texture = new StaticTexture(GetTextureID(), RenderLayer.DirtBase);

            renderer.RenderQueue.Add(texture);
            return renderer;
        }

        public override string GetName()
        {
            return Lang.Dirt;
        }

        public static int GetTextureID()
        {
            return AssetManager.GetTextureIndex(GetRandomDirtTexture());
        }

        private static string GetRandomDirtTexture()
        {
            int r = StaticRandom.Rand(0, 2);

            if (r == 0)
            {
                return TextureLoader.TextureDirt1;
            }
            else
            {
                return TextureLoader.TextureDirt2;
            }
        }
    }
}