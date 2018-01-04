using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.World
{
    /// <summary>
    /// A base class for all resources.
    /// Resources in tiles are things such as stone, iron, and gravel.
    /// </summary>
    public abstract class Resource
    {
        /// <summary>
        /// The display name of the resource.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// How much of the resources is left.
        /// </summary>
        public double Count { get; }
    }
}
