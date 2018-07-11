using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.World;
using MagicalLifeAPI.World.Base;
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
        public static Item RemoveAllItems(Point2D mapLocation, int dimension)
        {
            Tile tile = World.Data.World.GetTile(dimension, mapLocation.X, mapLocation.Y);
            Item item = tile.Item;

            tile.Item = null;
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

            Item removed = (Item)Activator.CreateInstance(ItemRegistry.Registry.ItemTypeID[tile.Item.ItemID]);

            if (tile.Item.CurrentlyStacked > count)
            {
                removed.CurrentlyStacked = count;
            }
            if (tile.Item.CurrentlyStacked < count || tile.Item.CurrentlyStacked == count)
            {
                removed.CurrentlyStacked = tile.Item.CurrentlyStacked;
                tile.Item = null;
            }

            return removed;
        }
    }
}