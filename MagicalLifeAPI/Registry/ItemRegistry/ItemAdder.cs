using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.World;
using MagicalLifeAPI.World.Base;
using MagicalLifeAPI.World.Data;
using RTree;
using System.Collections.Generic;

namespace MagicalLifeAPI.Registry.ItemRegistry
{
    /// <summary>
    /// Used to add items to the world, via the <see cref="ItemRegistry"/>.
    /// </summary>
    public static class ItemAdder
    {
        /// <summary>
        /// Lets a chunk know that there is an item of the specified type in the specified tile position.
        /// </summary>
        internal static void RememberWhichTile(Item item, Point2D mapLocation, Chunk chunk, int dimension)
        {
            if (!chunk.Items.ContainsKey(item.ItemID))
            {
                //chunk.Items doesn't store one key and value for every item in the game upfront.
                chunk.Items.Add(item.ItemID, new RTree<Point2D>());
            }

            RTree<Point2D> itemLocations = chunk.Items[item.ItemID];
            List<Point2D> result = itemLocations.Contains(new Rectangle(mapLocation.X, mapLocation.Y, mapLocation.X, mapLocation.Y));

            if (result.Count > 0)
            {
                //The chunk already knows that there is an item of the specified type in the specified position.
                return;
            }
            else
            {
                itemLocations.Add(new Rectangle(mapLocation.X, mapLocation.Y, mapLocation.X, mapLocation.Y), WorldUtil.GetTile(mapLocation, chunk).Location);
            }
        }

        /// <summary>
        /// Internally stores that a certain chunk has at least one item of the specified item ID.
        /// </summary>
        /// <param name="chunkLocation"></param>
        /// <param name="itemID"></param>
        internal static void RememberWhichChunk(Point2D chunkLocation, int itemID, int dimension)
        {
            RTree<Point2D> chunkLocations = ItemRegistry.Registries[dimension].ItemIDToChunk[itemID];
            List<Point2D> result = chunkLocations.Contains(new RTree.Rectangle(chunkLocation.X, chunkLocation.Y, chunkLocation.X, chunkLocation.Y));

            if (result.Count > 0)
            {
                //We already know that the specified chunk contains at least one of the item type.
                return;
            }
            else
            {
                chunkLocations.Add(new RTree.Rectangle(chunkLocation.X, chunkLocation.Y, chunkLocation.X, chunkLocation.Y), chunkLocation);
            }
        }

        /// <summary>
        /// Adds an item to the specified map location.
        /// </summary>
        public static void AddItem(Item item, Point2D mapLocation, int dimension)
        {
            Point2D chunkLocation = WorldUtil.CalculateChunkLocation(mapLocation);
            Chunk chunk = World.Data.World.Dimensions[dimension].GetChunk(chunkLocation.X, chunkLocation.Y);

            ItemAdder.RememberWhichChunk(chunkLocation, item.ItemID, dimension);
            ItemAdder.RememberWhichTile(item, mapLocation, chunk, dimension);
            ItemAdder.StoreItem(chunk, mapLocation, item);
        }

        public static void AddItemWorldGen(Item item, Point2D mapLocation, ProtoArray<Chunk> map, int dimension)
        {
            Point2D chunkLocation = WorldUtil.CalculateChunkLocation(mapLocation);
            Chunk chunk = map[chunkLocation.X, chunkLocation.Y];

            ItemAdder.RememberWhichChunk(chunkLocation, item.ItemID, dimension);
            ItemAdder.RememberWhichTile(item, mapLocation, chunk, dimension);
            ItemAdder.StoreItem(chunk, mapLocation, item);
        }

        /// <summary>
        /// Stores an item in the specified tile.
        /// If the tile is already full or cannot accept all of the item(s) being added,
        /// then this method returns any excess.
        /// Otherwise, this method returns null.
        /// </summary>
        internal static Item StoreItem(Chunk chunk, Point2D mapLocation, Item item)
        {
            Tile tile = WorldUtil.GetTile(mapLocation, chunk);
            Item overflow = null;

            if (tile.Item == null)
            {
                tile.Item = item;
            }
            else
            {
                Item final = Item.Combine(tile.Item, item, out overflow);
            }

            return overflow;
        }
    }
}