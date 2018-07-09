using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Registry
{
    /*
     * design goals:
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

    /*
     * Item IDs start from 0, and go to int32.MaxValue
     * 
     * Map<ID, ItemType>
     * Every item has an entry
     * Dictionary<ItemID, SortedDictionary<ChunkLocation, 1stOccurance>> GlobalItemsIndex
     * -If no index for an item yet, value is -1 (Saves me from resizing later)
     * -To get the index of the first of each item ID in GlobalItems from this, simply do GlobalItemsIndex[ItemID]
     * -Gets chunks that have the item
     * 
     * In each chunk:
     * SortedSet<Item> ChunkItems
     * -Items are sorted by ID, then by location
     * 
     * Performance analysis:
     * Find AN item of a kind via ID: O(1)
     * 
     * To find the CLOSEST: O(log(nm))
     * where n is the number of items in the SortedDictionary<ChunkLocation, 1stOcurance>
     * where m is the number of items in a chunk
     * 
     * To insert a new item/remove an item: O(log(m))
     * where n is the number of items in the SortedDictionary<ChunkLocation, 1stOcurance>
     * where m is the number of items in a chunk
     */

    /// <summary>
    /// Holds all of the loaded items in the game.
    /// 
    /// </summary>
    public class ItemRegistry
    {
    }
}
