using MagicalLifeAPI.Universal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.World
{
    public abstract class Tile : Unique
    {
        /// <summary>
        /// The loss of movement by stepping on this tile.
        /// </summary>
        public int MovementCost { get; } = 1;

        /// <summary>
        /// Returns the name of the biome that this tile belongs to.
        /// </summary>
        public string BiomeName { get; }

        /// <summary>
        /// The resources that can be found in this tile.
        /// </summary>
        public List<Resource> Resources { get; set; } = new List<Resource>();

        public List<Vegetation> Plants { get; set; } = new List<Vegetation>();
    }
}
