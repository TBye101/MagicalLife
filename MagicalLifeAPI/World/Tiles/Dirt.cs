using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.World.Tiles
{
    /// <summary>
    /// A dirt tile.
    /// </summary>
    public class Dirt : Tile
    {
        public Dirt()
        {
            this.AdditionalMovementCost = 0;
        }
    }
}
