using System;
using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Properties;
using MagicalLifeAPI.World.Base;

namespace MagicalLifeAPI.World.Tiles
{
    [ProtoBuf.ProtoContract]
    internal class TilledDirt : Tile
    {
        public TilledDirt(Point2D location, int dimension) : base(location, dimension, 10, 0)
        {
            this.InitializeComponents();
        }

        private void InitializeComponents()
        {
            ComponentRenderer renderer = GetComponent<ComponentRenderer>();
            renderer.AddVisual(new StaticTexture(GetTextureID(), RenderLayer.DirtBase));
        }

        private static int GetTextureID()
        {
            return AssetManager.GetTextureIndex(TextureLoader.TextureTilledDirt);
        }

        public override string GetName()
        {
            return Lang.Dirt;
        }
    }
}