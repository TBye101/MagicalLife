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
    public class Grass : Tile
    {
        public static readonly string GrassTileName = "Grass";

        public Grass(Point2D location, int dimension) : base(location, dimension, 11, 1)
        {
            this.InitializeComponents();
        }

        private void InitializeComponents()
        {
            ComponentTillable tillingBehavior = new TillablePercentDone();
            ComponentRenderer renderer = this.GetExactComponent<ComponentRenderer>();
            this.AddComponent(tillingBehavior);

            renderer.AddVisual(new StaticTexture(AssetManager.GetTextureIndex(this.GetRandomDirtTexture()), RenderLayer.DirtBase));
            renderer.AddVisual(new StaticTexture(AssetManager.GetTextureIndex(this.GetRandomGrassTexture()), RenderLayer.GrassBase));
        }

        public Grass(int x, int y, int dimension) : this(new Point2D(x, y), dimension)
        {
        }

        public Grass() : base()
        {
            //Protobuf-net constructor
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

        public override string GetName()
        {
            return GrassTileName;
        }
    }
}