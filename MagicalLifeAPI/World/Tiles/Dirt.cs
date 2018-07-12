using Microsoft.Xna.Framework;

namespace MagicalLifeAPI.World.Tiles
{
    /// <summary>
    /// A dirt tile.
    /// </summary>
    [ProtoBuf.ProtoContract]
    public class Dirt : Tile
    {
        public Dirt(Point location) : base(location, 10)
        {
            //this.AdditionalMovementCost = 0;
        }

        public Dirt(int x, int y) : this(new Point(x, y))
        {
        }

        public Dirt() : base()
        {
        }

        public override string GetName()
        {
            return "dirt";
        }

        public override string GetTextureName()
        {
            return "DirtFloor";
            //return "TestTile";
        }
    }
}