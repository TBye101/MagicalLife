using MagicalLifeAPI.DataTypes;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;

namespace MagicalLifeAPI.World.Tiles
{
    /// <summary>
    /// A dirt tile.
    /// </summary>
    public class Dirt : Tile
    {
        public Dirt(Point location) : base(location, 10)
        {
            //this.AdditionalMovementCost = 0;
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
        }
    }
}