using MagicalLifeAPI.Universal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.World
{
    /// <summary>
    /// A base class used by anything that can grow, and is alive.
    /// </summary>
    public abstract class Vegetation : Unique
    {
        public string Name { get; }

        /// <summary>
        /// The percent that this vegetation has currently grown.
        /// </summary>
        private double PercentGrown { get; set; }

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
