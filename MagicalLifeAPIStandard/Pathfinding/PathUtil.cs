using MagicalLifeAPI.DataTypes;
using System.Collections.Generic;

namespace MagicalLifeAPI.Pathfinding
{
    /// <summary>
    /// Holds some pathfinding utilities.
    /// </summary>
    public static class PathUtil
    {
        /// <summary>
        /// Returns the first location found the specified locations that is reachable from the specified position.
        /// Returns null if all the locations were unreachable.
        /// </summary>
        /// <param name="destinations"></param>
        /// <param name="origin">The starting location to attempt to reach the destinations from.</param>
        /// <param name="dimension"></param>
        /// <returns></returns>
        public static Point2D GetFirstReachable(List<Point2D> destinations, Point2D origin, int dimension)
        {
            foreach (Point2D item in destinations)
            {
                if (MainPathFinder.IsRoutePossible(dimension, origin, item))
                {
                    return item;
                }
            }

            return null;
        }
    }
}