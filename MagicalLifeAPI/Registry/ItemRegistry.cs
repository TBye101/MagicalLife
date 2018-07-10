using MagicalLifeAPI.World;
using MagicalLifeAPI.World.Base;
using MagicalLifeAPI.World.Data;
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

    /* Design
     * 
     * Dictionary stores access to a R-tree that stores the location of the chunk that stores at least one of the specified item
     * 
     * Has one entry for every item
     * Dictionary<ItemID, R-tree<ChunkLocation>>
     * 
     * Chunk:
     * Dictionary<ItemID, R-tree<ItemLocation>>
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

        /// <summary>
        /// For each item in the game, this dictionary holds a R-Tree that contains chunk coordinates for every chunk that has at least one of that item.
        /// </summary>
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
        /// Adds an item to the specified map location.
        /// </summary>
        public void AddItem(Item item, Point2D mapLocation, int dimension)
        {
            Point2D chunkLocation = WorldUtil.CalculateChunkLocation(mapLocation);
            Chunk chunk = World.Data.World.Dimensions[dimension].GetChunk(chunkLocation.X, chunkLocation.Y);

            this.RememberWhichChunk(chunkLocation, item.ItemID);
            this.RememberWhichTile(item, mapLocation, chunk, dimension);
            this.StoreItem(chunk, mapLocation, item);
        }

        /// <summary>
        /// Stores an item in the specified tile.
        /// If the tile is already full or cannot accept all of the item(s) being added,
        /// then this method returns any excess.
        /// Otherwise, this method returns null.
        /// </summary>
        internal Item StoreItem(Chunk chunk, Point2D mapLocation, Item item)
        {
            Tile tile = WorldUtil.GetTile(mapLocation, chunk);
            Item overflow = null;
            
            if (tile.Item == null)
            {
                tile.Item = item;
            }
            else
            {
                Item final = this.Combine(tile.Item, item, out overflow);
            }

            return overflow;
        }

        /// <summary>
        /// Combines two items and returns the result.
        /// Do not continue to use "one" or "two" afterwards, as this function reuses them for performance reasons.
        /// Doing so would cause unknown behavior.
        /// </summary>
        /// <param name="one"></param>
        /// <param name="two"></param>
        /// <param name="overflow">If the amount of the two items is too much, then this parameter is used to store the overflow. Otherwise, it is null.</param>
        /// <returns></returns>
        public Item Combine(Item one, Item two, out Item overflow)
        {
            if (one.GetType() == two.GetType())
            {
                one.CurrentlyStacked += two.CurrentlyStacked;

                int extra = one.CurrentlyStacked - one.StackableLimit;
                if (extra > 0)
                {
                    two.CurrentlyStacked = extra;
                    overflow = two;
                }
                else
                {
                    overflow = null;
                }

                return one;
            }
            else
            {
                throw new Exception("Error: Combining two items of different types is impossible to store.");
            }
        }

        /// <summary>
        /// Lets a chunk know that there is an item of the specified type in the specified tile position.
        /// </summary>
        internal void RememberWhichTile(Item item, Point2D mapLocation, Chunk chunk, int dimension)
        {            
            if (!chunk.Items.ContainsKey(item.ItemID))
            {
                //chunk.Items doesn't store one key and value for every item in the game upfront.
                chunk.Items.Add(item.ItemID, new RBush<Point2D>());
            }

            RBush<Point2D> itemLocations = chunk.Items[item.ItemID];
            IReadOnlyList<Point2D> result = itemLocations.Search(mapLocation.Envelope);

            if (result.Count > 0)
            {
                //The chunk already knows that there is an item of the specified type in the specified position.
                return;
            }
            else
            {
                itemLocations.Insert(mapLocation);
            }
        }

        /// <summary>
        /// Internally stores that a certain chunk has at least one item of the specified item ID.
        /// </summary>
        /// <param name="chunkLocation"></param>
        /// <param name="itemID"></param>
        internal void RememberWhichChunk(Point2D chunkLocation, int itemID)
        {
            RBush<Point2D> chunkLocations = this.ItemIDToChunk[itemID];
            IReadOnlyList<Point2D> result = chunkLocations.Search(chunkLocation.Envelope);

            if (result.Count > 0)
            {
                //We already know that the specified chunk contains at least one of the item type.
                return;
            }
            else
            {
                chunkLocations.Insert(chunkLocation);
            }
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
            this.ItemIDToChunk = new Dictionary<int, RBush<Point2D>>(this.ItemTypeID.Count);

            foreach (KeyValuePair<int, Type> item in this.ItemTypeID)
            {
                this.ItemIDToChunk.Add(item.Key, new RBush<Point2D>());
            }
        }
    }
}
