using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.World.Data;
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

        public static void Block(Point2D tile, int dimension)
        {
            if (PathFinders.Count > 0)
            {
                PathFinders[dimension].RemoveConnections(tile);
            }
        }

        public static void UnBlock(Point2D tile, int dimension)
        {
            if (PathFinders.Count > 0)
            {
                PathFinders[dimension].AddConnections(tile);
            }
        }

        public static List<PathLink> GetRoute(int dimension, Point2D start, Point2D end)
        {
            return PathFinders[dimension].GetRoute(dimension, start, end);
        }

        public static bool IsRoutePossible(int dimension, Point2D origin, Point2D destination)
        {
            return PathFinders[dimension].IsRoutePossible(dimension, origin, destination);
        }
    }
}