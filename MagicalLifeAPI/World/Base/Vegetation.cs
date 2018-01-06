using MagicalLifeAPI.Universal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.World.Base
{
    /// <summary>
    /// A base class used by anything that can grow, and is alive.
    /// </summary>
    public abstract class Vegetation : Unique
    {
        public string Name { get; }

        /// <summary>
        /// Returns the movement cost that this vegetation adds to the tile.
        /// </summary>
        public double MovementCost { get; }

        /// <summary>
        /// The percent that this vegetation has currently grown.
        /// </summary>
        private double PercentGrown { get; set; }

        /// <summary>
        /// The minimum amount of precipitation for this plant to survive.
        /// </summary>
        public double PrecipitationMin { get; set; }

        /// <summary>
        /// The maximum amount of precipitation that this plant can survive.
        /// </summary>
        public double Precipitationmax { get; set; }

        /// <summary>
        /// The chance that this vegetation will reproduce and create a immature version of itself nearby.
        /// </summary>
        public double ReproductionChance { get; set; }

        /// <summary>
        /// The minimum amount of offspring this vegetation is allowed to create.
        /// </summary>
        public int OffSpringMin { get; set; }

        /// <summary>
        /// The maximum amount of offspring this vegetation is allowed to create.
        /// </summary>
        public int OffSpringMax { get; set; }

        /// <summary>
        /// The minimum amount of days between reproduction attempts.
        /// </summary>
        private int MinDaysBetweenReproduction { get; }

        /// <summary>
        /// If true, this vegetation is dormant. This is most likely due to winter.
        /// </summary>
        public bool IsDorment { get; set; }

        /// <summary>
        /// The range at which this plant could possibly create a immature version of itself.
        /// </summary>
        public int ReproductionRange { get; set; }

        /// <summary>
        /// The chance that the offspring of this vegetation will be slightly different due to a mutation.
        /// </summary>
        public double MutationChance { get; set; }

        /// <summary>
        /// Returns the percent that this vegetation has currently grown.
        /// </summary>
        /// <returns></returns>
        public double GetPercentGrown()
        {
            return this.PercentGrown;
        }

        /// <summary>
        /// Gets the current yield of this vegatation.
        /// </summary>
        /// <returns></returns>
        public abstract double GetCurrentYield();
    }
}
