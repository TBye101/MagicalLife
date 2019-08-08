using System.Collections.Generic;
using MLAPI.DataTypes;
using MLAPI.Entity;
using MLAPI.Pathfinding.TeleportationSearch;
using Dimension = MLAPI.World.Data.Dimension;

namespace MLAPI.Pathfinding
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
        List<PathLink> GetRoute(Point3D origin, Point3D destination, IConnectionProvider connectionProvider, IWorldProvider worldProvider);

        /// <summary>
        /// Determines whether or not there is a valid path from the origin to the destination.
        /// </summary>
        /// <param name="dimension"></param>
        /// <param name="origin"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        bool IsRoutePossible(Point3D origin, Point3D destination, IConnectionProvider connectionProvider, IWorldProvider worldProvider);

        /// <summary>
        /// Run whatever startup code you need to before being capable of graph building  for the dimension.
        /// <paramref name="dimension"/>The dimension this pathfinder must handle.</param>
        /// </summary>
        void Initialize(Dimension dimension);

        /// <summary>
        /// Removes all links to the specified location.
        /// </summary>
        /// <param name="location"></param>
        void RemoveConnections(Point3D location, IConnectionProvider connectionProvider, IWorldProvider worldProvider);

        /// <summary>
        /// Adds links to the specified location.
        /// </summary>
        /// <param name="location"></param>

        void AddConnections(Point3D location, IConnectionProvider connectionProvider, IWorldProvider worldProvider);
    }
}