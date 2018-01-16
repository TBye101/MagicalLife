using DijkstraAlgorithm.Pathing;
using MagicalLifeAPI.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Entities.Entity_Components.Movement_Rules
{
    /// <summary>
    /// Used to determine if a creature is allowed to move on a tile.
    /// </summary>
    public interface IMovementRule
    {
        /// <summary>
        /// Returns the optimal path from start to finish.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="destination"></param>
        /// <param name="world"></param>
        /// <param name="creature"></param>
        /// <param name="isPossible">Is set to false if it is completly impossible for the creature to move to the target location.</param>
        /// <returns></returns>
        Path GetOptimalPath(Tile start, Tile destination, World.World world, Living creature, out bool isPossible);
    }
}
