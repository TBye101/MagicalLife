using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MagicalLifeAPI.Pathfinding
{
    /// <summary>
    /// Handles who finds the path to destinations.
    /// </summary>
    public static class MainPathFinder
    {
        /// <summary>
        /// The pathfinder.
        /// </summary>
        private static IPathFinder PFinder = new AStar.AStar();

        /// <summary>
        /// Pathfinders for all dimensions.
        /// </summary>
        private static List<IPathFinder> PathFinders = new List<IPathFinder>();

        public static void Initialize()
        {

        }

        public static List<PathLink> GetRoute(int dimension, Point start, Point end)
        {
            return PathFinders[dimension].GetRoute(dimension, start, end);
        }
    }
}