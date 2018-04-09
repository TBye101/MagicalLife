using MagicalLifeAPI.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        List<PathLink> GetRoute(World.World world, Living living, Point origin, Point destination);

        /// <summary>
        /// Run whatever startup code you need to before being capable of world generating here.
        /// </summary>
        void Initialize();

        /// <summary>
        /// Removes all pathfindable links to the specified location.
        /// </summary>
        /// <param name="location"></param>
        void RemoveConnections(Point location);

        /// <summary>
        /// Adds pathfindable links to the specified location.
        /// </summary>
        /// <param name="location"></param>

        void AddConnections(Point location);
    }
}
