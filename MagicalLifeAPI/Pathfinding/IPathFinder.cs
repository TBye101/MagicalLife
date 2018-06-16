using MagicalLifeAPI.Entities;
using Microsoft.Xna.Framework;
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
        /// <param name="living">The creature which will move between the two points.</param>
        /// <param name="destination">The target location for the living to reach.</param>
        /// <param name="origin">The starting point of the living.</param>
        /// <returns></returns>
        List<PathLink> GetRoute(World.Data.World world, Living living, Point origin, Point destination);

        /// <summary>
        /// Run whatever startup code you need to before being capable of world generating here.
        /// </summary>
        void Initialize();

        /// <summary>
        /// Removes all links to the specified location.
        /// </summary>
        /// <param name="location"></param>
        void RemoveConnections(Point location);

        /// <summary>
        /// Adds links to the specified location.
        /// </summary>
        /// <param name="location"></param>

        void AddConnections(Point location);
    }
}