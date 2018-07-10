using MagicalLifeAPI.World.Base;
using Microsoft.Xna.Framework;
using ProtoBuf;
using RBush;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.DataTypes
{

    /* Requirements
     * O(1) or O(log(N)) performance for insert, search, and delete
     * 
     * Dictionary stores access to a red black tree that stores the location of the chunk that stores at least one of the specified item
     * 
     * Has one entry for every item
     * Dictionary<ItemID, r-tree<ChunkLocation>>
     * 
     * Chunk:
     * Dictionary<ItemID, r-tree<ItemLocation>>
     * 
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
        internal Dictionary<int, Type> ItemTypeID { get; set; }

        [ProtoMember(2)]
        internal Dictionary<int, RBush<Point2D>> ItemIDToChunk { get; set; }

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
        /// </summary>
        /// <param name="item"></param>
        public void RegisterItemType(Item item)
        {
            this.ItemTypeID.Add(this.ItemTypeID.Count, item.GetType());
        }

        /// <summary>
        /// Initializes <see cref="ItemIDToChunk"/> for the first time.
        /// </summary>
        internal void Bake()
        {
            this.ItemIDToChunk = new Dictionary<int, RBush<Point2D>>(this.ItemTypeID.Count);

            foreach (KeyValuePair<int, Type> item in this.ItemTypeID)
            {
                this.ItemIDToChunk.Add(item.Key, new RBush<Point2D>());
            }
        }
    }
}
