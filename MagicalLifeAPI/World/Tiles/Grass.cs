using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.World.Base;
using ProtoBuf;

namespace MagicalLifeAPI.World.Tiles
{
    [ProtoContract]
    public class Grass : Tile
    {
        public override ComponentRenderer CompositeRenderer { get; set; }

        public Grass(Point2D location) : base(location, 11, 1)
        {
            this.CompositeRenderer = new ComponentRenderer();
            this.CompositeRenderer.RenderQueue.Visuals.Add(new StaticTexture(AssetManager.GetTextureIndex("Dirt"), RenderLayer.DirtBase));
            this.CompositeRenderer.RenderQueue.Visuals.Add(new StaticTexture(AssetManager.GetTextureIndex("Grass"), RenderLayer.GrassBase));
        }

        public Grass(int x, int y) : this(new Point2D(x, y))
        {
        }

        public Grass() : base()
        {
        }

        public override string GetName()
        {
            return "Grass";
        }
    }
}