using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.World.Base;
using ProtoBuf;
using RTree;
using System;
using System.Collections.Generic;

namespace MagicalLifeAPI.Registry.ItemRegistry
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
    /// The data structure that holds all of the items laying around in the world.
    /// </summary>
    [ProtoContract]
    public class ItemRegistry
    {
        /// <summary>
        /// Holds which item id is associated with which item type.
        /// </summary>
        [ProtoMember(1)]
        public Dictionary<int, Type> ItemTypeID { get; set; }

        /// <summary>
        /// For each item in the game, this dictionary holds a R-Tree that contains chunk coordinates for every chunk that has at least one of that item.
        /// </summary>
        [ProtoMember(2)]
        public Dictionary<int, RTree.RTree<Point2D>> ItemIDToChunk { get; set; }

        /// <summary>
        /// The singleton access point for the item registry.
        /// </summary>
        public static ItemRegistry Registry;

        public static void Initialize(List<Item> toRegister)
        {
            Registry = new ItemRegistry(toRegister);
        }

        public ItemRegistry(List<Item> toRegister)
        {
            this.ItemTypeID = new Dictionary<int, Type>();

            foreach (Item item in toRegister)
            {
                this.RegisterItemType(item);
            }

            this.Bake();
        }

        public ItemRegistry()
        {
        }

        /// <summary>
        /// Registers an item type with this item registry.
        /// All items that will be supported by this class must be added through here before Bake() is called.
        /// </summary>
        /// <param name="item"></param>
        internal void RegisterItemType(Item item)
        {
            this.ItemTypeID.Add(this.ItemTypeID.Count, item.GetType());
        }

        /// <summary>
        /// Initializes <see cref="ItemIDToChunk"/> for the first time.
        /// </summary>
        internal void Bake()
        {
            this.ItemIDToChunk = new Dictionary<int, RTree<Point2D>>(this.ItemTypeID.Count);

            foreach (KeyValuePair<int, Type> item in this.ItemTypeID)
            {
                this.ItemIDToChunk.Add(item.Key, new RTree<Point2D>());
            }
        }
    }
}