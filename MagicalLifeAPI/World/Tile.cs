using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.World
{
    public abstract class Tile
    {
        /// <summary>
        /// The loss of movement by stepping on this tile.
        /// </summary>
        public int MovementCost { get; set; } = 1;
    }
}
