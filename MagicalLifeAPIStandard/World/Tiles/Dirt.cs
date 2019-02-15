using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.Components.Resource;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Util;
using MagicalLifeAPI.World.Base;

namespace MagicalLifeAPI.World.Tiles
{
    /// <summary>
    /// A dirt tile.
    /// </summary>
    [ProtoBuf.ProtoContract]
    public class Dirt : Tile, ITillable
    {
        public override ComponentRenderer CompositeRenderer { get; set; }

        public AbstractTillable TillableBehavior { get; set; }

        public Dirt(Point2D location) : base(location, 10, 0)
        {
            this.TillableBehavior = new TillablePercentDone();
            this.CompositeRenderer = new ComponentRenderer();
            this.CompositeRenderer.RenderQueue.Add(new StaticTexture(Dirt.GetTextureID(), RenderLayer.DirtBase));
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
            return "Dirt";
        }

        public static int GetTextureID()
        {
            return AssetManager.GetTextureIndex(GetRandomDirtTexture());
        }

        private static string GetRandomDirtTexture()
        {
            int r = StaticRandom.Rand(0, 2);
            string ret;

            if (r == 0)
            {
                ret = TextureLoader.TextureDirt1;
            }
            else
            {
                ret = TextureLoader.TextureDirt2;
            }

            return ret;
        }
    }
}