using System.Security.Cryptography;
using DijkstraAlgorithm.Pathing;
using MagicalLifeAPI.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicalLifeAPI.Entities.Util.Modifier_Remove_Conditions;

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
        public static void MoveEntity(ref Living entity, ref World.World world)
        {
            while (entity.MovementSpeed.GetValue() > 0)
            {
                PathSegment destination = entity.QueuedMovement.Dequeue();
                Tile sourceTile = WorldUtil.GetTileByID(world.Tiles, destination.Origin.Id);
                Tile destinationTile = WorldUtil.GetTileByID(world.Tiles, destination.Destination.Id);
                string modifierReason = "Moved onto a " + destinationTile.GetName() + " tile";
                entity.MovementSpeed.AddModifier(new Tuple<long, IModifierRemoveCondition, string>(-1 * destinationTile.MovementCost, new TimeRemoveCondition(1), modifierReason));
                world.Tiles[sourceTile.Location.X, sourceTile.Location.Y, sourceTile.Location.Z].Living.RemoveAt(EntityWorldMovement.GetIndexOfEntity(sourceTile.Living, entity));
                world.Tiles[destinationTile.Location.X, destinationTile.Location.Y, destinationTile.Location.Z].Living.Add(entity);
            }
        }

        /// <summary>
        /// Finds the index of the living creature in the list. Returns -1 if it doesn't exist anymore.
        /// </summary>
        /// <param name="living"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private static int GetIndexOfEntity(List<Living> living, Living target)
        {
            int length = living.Count;
            for (int i = 0; i < length; i++)
            {
                if (living[i].ID == target.ID)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
