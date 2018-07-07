using MagicalLifeAPI.World.Data;
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
            World.Data.World.DimensionAdded += World_DimensionAdded;
        }

        private static void World_DimensionAdded(object sender, int e)
        {
            PrepForDimension(World.Data.World.Dimensions[e]);
        }

        /// <summary>
        /// Creates a pathfinder for a dimension.
        /// </summary>
        /// <param name="dimension"></param>
        public static void PrepForDimension(Dimension dimension)
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