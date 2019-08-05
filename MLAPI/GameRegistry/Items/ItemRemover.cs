using System;
using MLAPI.Components;
using MLAPI.DataTypes;
using MLAPI.Error.InternalExceptions;
using MLAPI.World.Base;
using MLAPI.World.Data;

namespace MLAPI.GameRegistry.Items
{
    /// <summary>
    /// Used to remove items from the world, via the <see cref="ItemRegistry"/>.
    /// </summary>
    public static class ItemRemover
    {
        /// <summary>
        /// All item(s) at the specified location.
        /// Returns the item(s) removed.
        /// Returns null if there was no item at the specified location.
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="mapLocation"></param>
        /// <param name="dimension"></param>
        public static Item RemoveAllItems(Point3D mapLocation)//Gotta update the indexes
        {
            Tile tile = World.Data.World.GetTile(mapLocation.DimensionId, mapLocation.X, mapLocation.Y);
            Item item = tile.MainObject as Item;

            RemoveItem(tile, mapLocation.DimensionId);
            return item;
        }

        /// <summary>
        /// Removes and returns a specified number of items from a item stored in the location specified.
        /// If there are less items than requested in the location, this will return as many as it can.
        /// </summary>
        /// <param name="mapLocation">The location to remove items from.</param>
        /// <param name="dimension">The dimension to remove items from.</param>
        /// <param name="count">How many items to remove.</param>
        /// <returns>Returns null if there was no item(s) stored in the specified location.</returns>
        public static Item RemoveSome(Point3D mapLocation, int count)
        {
            Tile tile = World.Data.World.GetTile(mapLocation.DimensionId, mapLocation.X, mapLocation.Y);

            Item removed = null;
            if (tile.MainObject is Item tileItem)
            {
                if (tileItem.CurrentlyStacked > count)
                {
                    removed = ItemRegistry.IdToItem[tileItem.ItemId].GetDeepCopy(count);
                }
                else
                {
                    removed = ItemRegistry.IdToItem[tileItem.ItemId].GetDeepCopy(tileItem.CurrentlyStacked);
                    RemoveItem(tile, mapLocation.DimensionId);
                }
            }

            return removed;
        }

        /// <summary>
        /// Removes the item in the specified tile from the game, and updates the indexes.
        /// </summary>
        private static void RemoveItem(Tile tile, Guid dimensionId)
        {
            if (tile.MainObject is Item tileItem)
            {
                int itemId = tileItem.ItemId;
                Point2D l = tile.GetExactComponent<ComponentSelectable>().MapLocation;
                Chunk chunk = World.Data.World.GetChunkByTile(dimensionId, l.X, l.Y);

                if (chunk.Items.ContainsKey(itemId))
                {
                    RTree<Point2D> result = chunk.Items[itemId];
                    bool success = result.Delete(new Rectangle(l.X, l.Y, l.X, l.Y), new Point2D(l.X, l.Y));

                    if (!success)
                    {
                        throw new RegistryDeletionException("Failed to delete an item!");
                    }

                    if (result.Count == 0)
                    {
                        RTree<Point2D> chunksContaining = World.Data.World.Dimensions[dimensionId].Items.ItemIdToChunk[itemId];
                        bool succeed = chunksContaining.Delete(new Rectangle(chunk.ChunkLocation.X, chunk.ChunkLocation.Y, chunk.ChunkLocation.X, chunk.ChunkLocation.Y), new Point2D(chunk.ChunkLocation.X, chunk.ChunkLocation.Y));

                        if (!succeed)
                        {
                            throw new RegistryDeletionException("Failed to delete a chunk containing an item!");
                        }
                    }
                    tileItem = null;
                }
            }
        }
    }
}