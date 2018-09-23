using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.World.Base;

namespace MagicalLifeAPI.World.Tiles
{
    /// <summary>
    /// A dirt tile.
    /// </summary>
    [ProtoBuf.ProtoContract]
    public class Dirt : Tile
    {
        public Dirt(Point2D location) : base(location, 10, , 0)
        {
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
            StaticTexture texture = new StaticTexture(GetTextureID(), RenderLayer.TileBase);

            renderer.RenderQueue.Visuals.Add(texture);
            return renderer;
        }

        public override string GetName()
        {
            return "Dirt";
        }

        private static int GetTextureID()
        {
            return AssetManager.GetTextureIndex("Dirt");
        }
    }
}