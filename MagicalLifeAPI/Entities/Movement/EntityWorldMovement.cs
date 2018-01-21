using DijkstraAlgorithm.Pathing;
using MagicalLifeAPI.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Entities.Movement
{
    /// <summary>
    /// Used to move entities.
    /// </summary>
    public static class EntityWorldMovement
    {
        /// <summary>
        /// Moves an entity from it's current position to as close to it's target destination as it can get. This will appear like teleporting.
        /// </summary>
        /// <param name="entity"></param>
        public static void MoveEntity(Living entity, World.World world)
        {
            while (entity.MovementSpeed.GetValue() > 0)
            {
                PathSegment destination = entity.QueuedMovement.Dequeue();
                //Tile destinationTile = destination.Destination.
                //entity.MovementSpeed.AddModifier(new Tuple<long, IModifierRemoveCondition, string>())
            }
        }
    }
}
