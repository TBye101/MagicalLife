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
        public int MovementCost { get; } = 1;

        /// <summary>
        /// The resources that can be found in this tile.
        /// </summary>
        public List<Resource> Resources { get; } = new List<Resource>();
    }
}
