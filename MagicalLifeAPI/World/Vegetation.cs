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
    public abstract class Vegetation
    {
        /// <summary>
        /// The percent that this vegetation has currently grown.
        /// </summary>
        public double PercentGrown { get; }
    }
}
