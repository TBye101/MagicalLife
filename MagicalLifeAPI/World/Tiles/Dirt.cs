using MagicalLifeAPI.DataTypes;

namespace MagicalLifeAPI.World.Tiles
{
    /// <summary>
    /// A dirt tile.
    /// </summary>
    [ProtoBuf.ProtoContract]
    public class Dirt : Tile
    {
        public Dirt(Point2D location) : base(location, 10)
        {
            //this.AdditionalMovementCost = 0;
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

        public override string GetTextureName()
        {
            return "Dirt";
        }
    }
}