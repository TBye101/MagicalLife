using System;
using System.Collections.Generic;
using MLAPI.DataTypes;
using MLAPI.World.Base;
using ProtoBuf;

namespace MLAPI.GameRegistry.Items
{
    /* Item Registry Design
     *
     * Dictionary stores access to a R-tree that stores the location of the chunk that stores at least one of the specified item
     *
     * In this file:
     * Dictionary<ItemID, R-tree<ChunkLocation>>
     * -Has information on which chunks have at least one tile with an item of a certain id.
     * -Has one entry for every item
     *
     * in Chunk.cs:
     * Dictionary<ItemID, R-tree<ItemLocation>>
     * -Has information on which tiles have what items.
     */

    /// <summary>
    /// The data structure that holds all of the items in a single dimension, as well as item IDs for every item in the game.
    /// </summary>
    [ProtoContract]
    public class ItemRegistry
    {
        /// <summary>
        /// Holds which item id is associated with item.
        /// </summary>
        [ProtoMember(1)]
        internal static Dictionary<int, Item> IDToItem { get; set; } = new Dictionary<int, Item>();

        /// <summary>
        /// Holds which item is associated with which item id.
        /// </summary>
        [ProtoMember(2)]
        internal static Dictionary<Item, int> ItemToID { get; set; } = new Dictionary<Item, int>();

        /// <summary>
        /// For each item in the dimension, this dictionary holds a R-Tree that contains chunk coordinates for every chunk that has at least one of that item.
        /// </summary>
        [ProtoMember(3)]
        internal Dictionary<int, RTree<Point2D>> ItemIDToChunk { get; set; }

        [ProtoMember(4)]
        public Guid ID { get; }

        [ProtoMember(5)]
        public int Dimension { get; }

        public ItemRegistry(int dimension)
        {
            this.ID = Guid.NewGuid();
            this.Dimension = dimension;
            this.BakeItemChunks();
        }

        public ItemRegistry()
        {
            //Protobuf-net Constructor
        }

        /// <summary>
        /// Registers an item type with this item registry.
        /// All items that will be supported by this class must be added through here before Bake() is called.
        /// </summary>
        /// <param name="item"></param>
        public static void RegisterItemType(Item item)
        {
            IDToItem.Add(IDToItem.Count, item);
            ItemToID.Add(item, ItemToID.Count);
        }

        /// <summary>
        /// Initializes <see cref="ItemIDToChunk"/> for the first time.
        /// </summary>
        internal void BakeItemChunks()
        {
            this.ItemIDToChunk = new Dictionary<int, RTree<Point2D>>(IDToItem.Count);

            foreach (KeyValuePair<int, Item> item in IDToItem)
            {
                this.ItemIDToChunk.Add(item.Key, new RTree<Point2D>());
            }
        }
    }
}