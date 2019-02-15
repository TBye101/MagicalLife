using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.Components.Resource;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Util;
using MagicalLifeAPI.World.Base;
using ProtoBuf;

namespace MagicalLifeAPI.World.Tiles
{
    [ProtoContract]
    public class Grass : Tile, ITillable
    {
        public override ComponentRenderer CompositeRenderer { get; set; }

        public static readonly string GrassTileName = "Grass";

        public AbstractTillable TillableBehavior { get; set; }

        public Grass(Point2D location) : base(location, 11, 1)
        {
            this.TillableBehavior = new TillablePercentDone();
            this.CompositeRenderer = new ComponentRenderer();
            this.CompositeRenderer.RenderQueue.Add(new StaticTexture(AssetManager.GetTextureIndex(this.GetRandomDirtTexture()), RenderLayer.DirtBase));
            this.CompositeRenderer.RenderQueue.Add(new StaticTexture(AssetManager.GetTextureIndex(this.GetRandomGrassTexture()), RenderLayer.GrassBase));
        }

        private string GetRandomGrassTexture()
        {
            int r = StaticRandom.Rand(0, 4);
            string ret;

            switch (r)
            {
                case 1:
                    ret = TextureLoader.TextureGrass2;
                    break;

                case 2:
                    ret = TextureLoader.TextureGrass3;
                    break;

                case 3:
                    ret = TextureLoader.TextureGrass4;
                    break;

                default:
                    ret = TextureLoader.TextureGrass1;
                    break;
            }

            return ret;
        }

        private string GetRandomDirtTexture()
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

        public Grass(int x, int y) : this(new Point2D(x, y))
        {
        }

        public Grass() : base()
        {
        }

        public override string GetName()
        {
            return GrassTileName;
        }
    }
}