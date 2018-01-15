using System.Web.UI.DataVisualization.Charting;

namespace MagicalLifeAPI.World.Tiles
{
    /// <summary>
    /// A dirt tile.
    /// </summary>
    public class Dirt : Tile
    {
        public Dirt(Point3D location) : base(location)
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
        }
    }
}