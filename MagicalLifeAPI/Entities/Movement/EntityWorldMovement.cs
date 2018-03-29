using DijkstraAlgorithm.Pathing;
using MagicalLifeAPI.Entities.Util.Modifier_Remove_Conditions;
using MagicalLifeAPI.World;
using System;
using System.Collections.Generic;

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
        public static void MoveEntity(ref Living entity)
        {
            Queue<PathSegment> path = entity.QueuedMovement;
            while (entity.MovementSpeed.GetValue() > 0 && path.Count > 0)
            {
                PathSegment destination = path.Dequeue();
                Tile sourceTile = WorldUtil.GetTileByID(World.World.mainWorld.Tiles, destination.Origin.Id);
                Tile destinationTile = WorldUtil.GetTileByID(World.World.mainWorld.Tiles, destination.Destination.Id);
                string modifierReason = "Moved onto a " + destinationTile.GetName() + " tile";
                entity.MovementSpeed.AddModifier(new Tuple<long, IModifierRemoveCondition, string>(-1 * destinationTile.MovementCost, new TimeRemoveCondition(1), modifierReason));
                World.World.mainWorld.Tiles[sourceTile.Location.X, sourceTile.Location.Y, sourceTile.Location.Z].Living = null;
                entity.MapLocation = destinationTile.Location;
                World.World.mainWorld.Tiles[destinationTile.Location.X, destinationTile.Location.Y, destinationTile.Location.Z].Living = entity;
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