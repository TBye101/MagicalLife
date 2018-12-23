using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.World.Data;
using System.Collections.Generic;

namespace MagicalLifeAPI.Pathfinding
{
    /// <summary>
    /// All pathfinding algorithms must implement this.
    /// </summary>
    public interface IPathFinder
    {
        /// <summary>
        /// Must get a valid path between the origin and the destination.
        /// </summary>
        /// <param name="world">The world with which the <see cref="Living"/> exists within.</param>
        /// <param name="destination">The target location for the living to reach.</param>
        /// <param name="origin">The starting Point2D of the living.</param>
        /// <returns></returns>
        List<PathLink> GetRoute(int dimension, Point2D origin, Point2D destination);

        /// <summary>
        /// Determines whether or not there is a valid path from the origin to the destination.
        /// </summary>
        /// <param name="dimension"></param>
        /// <param name="origin"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        bool IsRoutePossible(int dimension, Point2D origin, Point2D destination);

        /// <summary>
        /// Run whatever startup code you need to before being capable of graph building  for the dimension.
        /// <paramref name="dimension"/>The dimension this pathfinder must handle.</param>
        /// </summary>
        void Initialize(Dimension dimension);

        /// <summary>
        /// Removes all links to the specified location.
        /// </summary>
        /// <param name="location"></param>
        void RemoveConnections(Point2D location);

        /// <summary>
        /// Adds links to the specified location.
        /// </summary>
        /// <param name="location"></param>

        void AddConnections(Point2D location);
    }
}