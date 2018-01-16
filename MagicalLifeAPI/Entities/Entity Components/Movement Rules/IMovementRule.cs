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
        /// Used to determine if a creature can move from it's start to a destination.
        /// </summary>
        /// <param name="destination">The tile to determine if the creature can get there.</param>
        /// <param name="start">The tile the creature is starting from.</param>
        /// <param name="world">The world.</param>
        /// <returns></returns>
        bool CanMoveHere(Tile destination, Tile start, World.World world, Living creature);
    }
}
