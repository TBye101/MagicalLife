using MLAPI.Asset;
using MLAPI.DataTypes;
using MLAPI.Properties;
using MLAPI.Visual.Rendering;
using MLAPI.World.Base;

namespace MLCoreMod.Core.Tiles
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
            renderer.AddVisual(new StaticTexture(GetTextureId(), RenderLayer.DirtBase));
        }

        private static int GetTextureId()
        {
            return AssetManager.GetTextureIndex(TextureLoader.TextureTilledDirt);
        }

        public override string GetName()
        {
            return Lang.Dirt;
        }
    }
}