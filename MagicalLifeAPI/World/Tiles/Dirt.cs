using MagicalLifeAPI.Components.Generic;
using MagicalLifeAPI.Components.Tile.Renderable;
using MagicalLifeAPI.DataTypes;

namespace MagicalLifeAPI.World.Tiles
{
    /// <summary>
    /// A dirt tile.
    /// </summary>
    [ProtoBuf.ProtoContract]
    public class Dirt : Tile
    {
        public Dirt(Point2D location) : base(location, 10, new TransitionTextures(typeof(Grass), typeof(Dirt), new ConnectedDirt()))
        {
        }

        public Dirt(int x, int y) : this(new Point2D(x, y))
        {
        }

        public Dirt() : base()
        {
        }

        public override string GetName()
        {
            return "Dirt";
        }
    }
}