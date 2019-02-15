using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.World.Base;

namespace MagicalLifeAPI.World.Tiles
{
    [ProtoBuf.ProtoContract]
    internal class TilledDirt : Tile
    {
        public override ComponentRenderer CompositeRenderer { get; set; }

        public TilledDirt(Point2D location) : base(location, 10, 0)
        {
            this.CompositeRenderer = new ComponentRenderer();
            this.CompositeRenderer.RenderQueue.Add(new StaticTexture(TilledDirt.GetTextureID(), RenderLayer.DirtBase));
        }

        public static int GetTextureID()
        {
            return AssetManager.GetTextureIndex(TextureLoader.TextureTilledDirt);
        }

        public override string GetName()
        {
            return "TilledDirt";
        }
    }
}