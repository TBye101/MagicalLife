using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.Util;
using MagicalLifeAPI.World.Base;
using MagicalLifeAPI.World.Data;
using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Registry
{
    /* design goals:
     * 
     * What item access should look like to the public:
     * 
     * Each tile should be able to return what items are there
     * Each Chunk should be able to return what items are there
     * Search functions to find the closest item that meets the specified parameters
     * 
     * Internal workings (What we don't show them):
     * 
     * Each tile doesn't actually store the item, but merely stores a pointer to it
     * Each chunk doesn't store items, but stores a pointer to a list that points to positions in a SORTED list of all currently loaded items in the chunk
     * 
     * Finding nearest item of a type should be blazing fast
     */

    /* Actual Structure
     * 
     * Item IDs start from 0, and go to int32.MaxValue
     * 
     * Map<ID, ItemType>
     * Every item has an entry
     * 
     * Dictionary<ItemID, SortedDictionary<ChunkLocation, 1stOccurance>> GlobalItemsIndex
     * -If no index for an item yet, value is -1 (Saves me from resizing later)
     * -To get the index of the first of each item ID in GlobalItems from this, simply do GlobalItemsIndex[ItemID]
     * -Gets chunks that have the item
     * 
     * In each chunk:
     * SortedSet<Item> ChunkItems
     * -Items are sorted by ID, then by location
     */
     
    /* Performance Analysis
     * 
     * Find AN item of a kind via ID: O(1)
     * 
     * To find the CLOSEST: O(log(nm))
     * where n is the number of items in the SortedDictionary<ChunkLocation, 1stOcurance>
     * where m is the number of items in a chunk
     * 
     * To insert a new item/remove an item: O(log(m))
     * where n is the number of items in the SortedDictionary<ChunkLocation, 1stOcurance>
     * where m is the number of items in a chunk
     * 
     * Benefits of design:
     * Ability to load and offload items with chunks, while still keeping the whole system indexed (Saves a lot of memory!!!)
     */

    /// <summary>
    /// Is used to find items in various ways.
    /// </summary>
    public class ItemRegistry
    {
        /// <summary>
        /// Holds the id of every type of item in the game.
        /// Key: Item ID
        /// Value: An item.
        /// </summary>
        internal Dictionary<int, Type> ItemIDs { get; set; }

        /// <summary>
        /// Used to find which chunks have an item.
        /// 
        /// Dictionary:
        /// Key: Item ID.
        /// Value: SortedDictionary
        /// 
        /// SortedDictionary:
        /// Key: Location of a chunk (chunk locations, not tile locations)
        /// that has at least one item with an ID matching the target ID.
        /// Value: The index of the item in the SortedSet within a chunk
        /// that marks the start of all items that match that ID.
        /// </summary>
        internal Dictionary<int, SortedDictionary<Point, int>> GlobalItemsIndex { get; set; }

        /// <summary>
        /// When finding the closest item, this limits how many chunks we can search.
        /// The higher the value, the more thorough the search. The lower the number, the better the performance. 
        /// </summary>
        internal int MaxChunkSearch = 9;

        public ItemRegistry()
        {
            this.ItemIDs = new Dictionary<int, Type>();
            this.GlobalItemsIndex = new Dictionary<int, SortedDictionary<Point, int>>();
        }

        /// <summary>
        /// Registers an item into the item system.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>The ID of the item</returns>
        public int RegisterItem(Item item)
        {
            if (this.ItemIDs.ContainsValue(item.GetType()))
            {
                throw new Exception("Duplicate item already registered!");
            }
            else
            {
                this.ItemIDs.Add(this.ItemIDs.Count, item.GetType());
                return this.ItemIDs.Count;
            }
        }

        /// <summary>
        /// Returns the id that the item is associated with.
        /// WARNING: This is a slow operation.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int GetID(Item item)
        {
            return this.ItemIDs.FirstOrDefault(x => x.Value.GetType() == item.GetType()).Key;
        }

        /// <summary>
        /// Returns the location of the closest item of the specified ID.
        /// Returns null if there is not such an item in the entire game.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public Point GetClosest(int type, Point target, int dimension)
        {
            if (this.GlobalItemsIndex.TryGetValue(type, out SortedDictionary<Point, int> chunksContaining))
            {
                Point closestChunk = this.GetClosestChunk(type, target, chunksContaining, out int index);
                Chunk chunk = World.Data.World.Dimensions[dimension].GetChunk(closestChunk.X, closestChunk.Y);

                int length = chunk.Items.Count;
                int itemIndex = -1;
                int lastDistance = -1;

                Item item;
                if (chunk.Items.Count > 1 && index - length > 0)
                {
                    for (int i = index; i < length; i++)
                    {
                        item = chunk.Items.ElementAt(i);

                        if (item.ItemID != type)
                        {
                            break;
                        }

                        int distance = MathUtil.GetDistanceFast(target, item.Location);

                        if (itemIndex == -1)
                        {
                            itemIndex = i;
                            lastDistance = distance;
                        }
                        else
                        {
                            if (distance < lastDistance)
                            {
                                itemIndex = i;
                                lastDistance = distance;
                            }
                        }
                    }
                }
                else
                {

                    throw new Exception("There should have been an item of the correct type here...");
                }

                return chunk.Items.ElementAt(itemIndex).Location;
            }

            MasterLog.DebugWriteLine("Item not found! Item ID: " + type.ToString());
            return Point.Zero;
        }

        /// <summary>
        /// Returns the closest chunk to the target location from the SortedDictionary of all chunks with at least one of the target item.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="target"></param>
        /// <param name="chunksContaining"></param>
        /// <param name="index">The position in the list of chunks that have the target item that this function has determined as the closest.</param>
        /// <returns></returns>
        private Point GetClosestChunk(int type, Point target, SortedDictionary<Point, int> chunksContaining, out int index)//TODO: This checks chunks in a bad order. When limited chunk searches are allowed, we need to more carefully choose who to check.
        {

            int length;

            if (chunksContaining.Count > this.MaxChunkSearch)
            {
                length = this.MaxChunkSearch;
            }
            else
            {
                length = chunksContaining.Count;
            }

            IEnumerable<Point> toCheck = chunksContaining.Keys.Take(length);
            int closest = Algorithms.GetClosestPoint(toCheck.ToList(), target);

            index = closest;
            return toCheck.ElementAt(closest);
        }
    }
}
