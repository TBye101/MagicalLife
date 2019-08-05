using System;
using MLAPI.Asset;
using MLAPI.DataTypes;
using MLAPI.Properties;
using MLAPI.Util.RandomUtils;
using MLAPI.Visual.Rendering;
using MLAPI.World.Base;
using MLCoreMod.Core.Components;
using ProtoBuf;

namespace MLCoreMod.Core.Tiles
{
    /// <summary>
    /// A dirt tile.
    /// </summary>
    [ProtoContract]
    public class Dirt : Tile
    {
        public Dirt(Point3D location) : base(location, 10, 0)
        {
            this.AddComponent(new TillablePercentDone(.07F));
            this.GetExactComponent<ComponentRenderer>().RenderQueue.Add(
                new StaticTexture(Dirt.GetTextureId(), RenderLayer.DirtBase));
        }

        public Dirt(int x, int y, Guid dimensionId) : this(new Point3D(x, y, dimensionId))
        {
        }

        public Dirt() : base()
        {
        }

        protected static ComponentRenderer GetRenderer()
        {
            ComponentRenderer renderer = new ComponentRenderer();
            StaticTexture texture = new StaticTexture(GetTextureId(), RenderLayer.DirtBase);

            renderer.RenderQueue.Add(texture);
            return renderer;
        }

        public override string GetName()
        {
            return Lang.Dirt;
        }

        public static int GetTextureId()
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