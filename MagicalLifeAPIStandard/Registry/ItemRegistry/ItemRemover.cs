using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.DataTypes.R;
using MagicalLifeAPI.Error.InternalExceptions;
using MagicalLifeAPI.World.Base;
using MagicalLifeAPI.World.Data;
using System;

namespace MagicalLifeAPI.Registry.ItemRegistry
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
        public static Item RemoveAllItems(Point2D mapLocation, int dimension)//Gotta update the indexes
        {
            Tile tile = World.Data.World.GetTile(dimension, mapLocation.X, mapLocation.Y);
            Item item = tile.Item;

            RemoveItem(tile, dimension);
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
        public static Item RemoveSome(Point2D mapLocation, int dimension, int count)
        {
            Tile tile = World.Data.World.GetTile(dimension, mapLocation.X, mapLocation.Y);

            if (tile.Item == null)
            {
                return null;
            }

            Item removed = (Item)Activator.CreateInstance(ItemRegistry.ItemTypeID[tile.Item.ItemID]);

            if (tile.Item.CurrentlyStacked > count)
            {
                removed.CurrentlyStacked = count;
            }
            if (tile.Item.CurrentlyStacked < count || tile.Item.CurrentlyStacked == count)
            {
                removed.CurrentlyStacked = tile.Item.CurrentlyStacked;
                RemoveItem(tile, dimension);
            }

            return removed;
        }

        /// <summary>
        /// Removes the item in the specified tile from the game, and updates the indexes.
        /// </summary>
        private static void RemoveItem(Tile tile, int dimension)
        {
            int itemID = tile.Item.ItemID;
            Point2D l = tile.MapLocation;
            Chunk chunk = World.Data.World.GetChunkByTile(dimension, l.X, l.Y);

            if (chunk.Items.ContainsKey(itemID))
            {
                RTree<Point2D> result = chunk.Items[itemID];
                bool success = result.Delete(new Rectangle(l.X, l.Y, l.X, l.Y), new Point2D(l.X, l.Y));

                if (!success)
                {
                    throw new RegistryDeletionException("Failed to delete an item!");
                }

                if (result.Count == 0)
                {
                    RTree<Point2D> chunksContaining = World.Data.World.Dimensions[dimension].Items.ItemIDToChunk[itemID];
                    bool succeed = chunksContaining.Delete(new Rectangle(chunk.ChunkLocation.X, chunk.ChunkLocation.Y, chunk.ChunkLocation.X, chunk.ChunkLocation.Y), new Point2D(chunk.ChunkLocation.X, chunk.ChunkLocation.Y));

                    if (!succeed)
                    {
                        throw new RegistryDeletionException("Failed to delete a chunk containing an item!");
                    }
                }
                tile.Item = null;
            }
        }
    }
}