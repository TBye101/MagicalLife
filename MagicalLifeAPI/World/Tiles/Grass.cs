using MagicalLifeAPI.Components.Tile.Renderable;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.World.Base;
using ProtoBuf;

namespace MagicalLifeAPI.World.Tiles
{
    [ProtoContract]
    public class Grass : Tile
    {
        public Grass(Point2D location) : base(location, 11, null, 1)
        {
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