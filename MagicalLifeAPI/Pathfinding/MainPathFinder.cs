using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Pathfinding
{
    /// <summary>
    /// Handles who pathfinds.
    /// </summary>
    public static class MainPathFinder
    {
        /// <summary>
        /// The pathfinder.
        /// </summary>
        public static IPathFinder PFinder = new AStar.AStar();
    }
}
