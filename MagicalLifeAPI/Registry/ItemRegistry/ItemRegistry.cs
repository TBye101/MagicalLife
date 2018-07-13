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
    /// The data structure that holds all of the items in a single dimension, as well as item IDs for every item in the game.
    /// </summary>
    [ProtoContract]
    public class ItemRegistry
    {
        /// <summary>
        /// Holds which item id is associated with which item type.
        /// </summary>
        [ProtoMember(1)]
        public static Dictionary<int, Type> ItemTypeID { get; set; }

        /// <summary>
        /// For each item in the game, this dictionary holds a R-Tree that contains chunk coordinates for every chunk that has at least one of that item.
        /// </summary>
        [ProtoMember(2)]
        public Dictionary<int, RTree.RTree<Point2D>> ItemIDToChunk { get; set; }

        /// <summary>
        /// An item registry for each dimension.
        /// </summary>
        public static List<ItemRegistry> Registries = new List<ItemRegistry>();

        /// <summary>
        /// Registers the items.
        /// </summary>
        /// <param name="toRegister"></param>
        public static void Initialize(List<Type> toRegister)
        {
            ItemTypeID = new Dictionary<int, Type>();

            foreach (Type item in toRegister)
            {
                RegisterItemType(item);
            }
        }

        public ItemRegistry()
        {
            this.Bake();
        }

        /// <summary>
        /// Registers an item type with this item registry.
        /// All items that will be supported by this class must be added through here before Bake() is called.
        /// </summary>
        /// <param name="item"></param>
        internal static void RegisterItemType(Type item)
        {
            ItemTypeID.Add(ItemTypeID.Count, item);
        }

        /// <summary>
        /// Initializes <see cref="ItemIDToChunk"/> for the first time.
        /// </summary>
        internal void Bake()
        {
            this.ItemIDToChunk = new Dictionary<int, RTree<Point2D>>(ItemTypeID.Count);

            foreach (KeyValuePair<int, Type> item in ItemTypeID)
            {
                this.ItemIDToChunk.Add(item.Key, new RTree<Point2D>());
            }
        }
    }
}