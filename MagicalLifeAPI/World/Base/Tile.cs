using MagicalLifeAPI.Universal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicalLifeAPI.World.Base;

namespace MagicalLifeAPI.World
{
    public abstract class Tile : Unique
    {
        /// <summary>
        /// The loss of movement by stepping on this tile.
        /// </summary>
        public double MovementCost
        {
            get
            {
                return this.LastMovementCost;
            }
        }

        /// <summary>
        /// The last calculated movement cost of this tile.
        /// </summary>
        private double LastMovementCost { get; set; }

        /// <summary>
        /// Returns the name of the biome that this tile belongs to.
        /// </summary>
        public string BiomeName { get; }

        /// <summary>
        /// Returns the last calculated value of the temperature of this tile.
        /// </summary>
        public double Temperature
        {
            get
            {
                return this.LastTemperature;
            }
        }

        /// <summary>
        /// The last calculated temperature value of this tile.
        /// </summary>
        private double LastTemperature { get; set; }

        /// <summary>
        /// The resources that can be found in this tile.
        /// </summary>
        public List<Resource> Resources { get; set; } = new List<Resource>();

        public List<Vegetation> Plants { get; set; } = new List<Vegetation>();
    }
}
