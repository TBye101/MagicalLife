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
        /// Pathfinders for all dimensions.
        /// </summary>
        private static List<IPathFinder> PathFinders = new List<IPathFinder>();

        public static void Initialize()
        {
        }

        /// <summary>
        /// Creates a pathfinder for a dimension.
        /// </summary>
        /// <param name="dimension"></param>
        public static void PrepForDimension(int dimension)
        {
            AStar.AStar star = new AStar.AStar();
            star.Initialize(dimension);
            PathFinders.Add(star);
        }

        public static List<PathLink> GetRoute(int dimension, Point start, Point end)
        {
            return PathFinders[dimension].GetRoute(dimension, start, end);
        }
    }
}