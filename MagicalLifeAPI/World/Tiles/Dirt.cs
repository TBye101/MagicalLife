using MagicalLifeAPI.DataTypes;

namespace MagicalLifeAPI.World.Tiles
{
    /// <summary>
    /// A dirt tile.
    /// </summary>
    public class Dirt : Tile
    {
        public Dirt(Point3D location) : base(location, 10)
        {
            //this.AdditionalMovementCost = 0;
        }

        public override string GetName()
        {
            return "dirt";
        }

        public override string GetTextureName()
        {
            return "DirtTile.png";
            //return "TestTile.png";
        }
    }
}