using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.World.Base;
using MLAPI.Properties;

namespace MagicalLifeAPI.World.Tiles
{
    [ProtoBuf.ProtoContract]
    internal class TilledDirt : Tile
    {
        public TilledDirt(Point3D location) : base(location, 10, 0)
        {
            this.InitializeComponents();
        }

        private void InitializeComponents()
        {
            ComponentRenderer renderer = this.GetComponent<ComponentRenderer>();
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