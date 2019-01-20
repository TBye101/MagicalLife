using MagicalLifeAPI.World.Base;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicalLifeAPI.Entity
{
    /// <summary>
    /// Holds the inventory for a creature.
    /// </summary>
    [ProtoContract]
    public class Inventory
    {
        /// <summary>
        /// The actual item storage of this inventory.
        /// <para></para>
        /// Stored as: [itemID, itemObject]
        /// </summary>
        [ProtoMember(1)]
        private readonly Dictionary<int, List<Item>> Items;

        public Inventory(bool someVar)
        {
            this.Items = new Dictionary<int, List<Item>>();
        }

        protected Inventory()
        {
            //Protobuf-net constructor
        }

        /// <summary>
        /// Returns all of the item contained in this inventory, and removes the item from this inventory.
        /// Returns null if the item is not contained in this inventory.
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        public List<Item> RemoveAllOfItem(int itemID)
        {
            if (this.Items.ContainsKey(itemID))
            {
                List<Item> stacks = this.Items[itemID];
                this.Items.Remove(itemID);
                return stacks;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Returns as much of the item as requested. 
        /// If more is requested than actually exists in this inventory than the amount stored is returned.
        /// Removes all items requested from this inventory.
        /// Returns null if this inventory stores non of the requested item.
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="amount">The amount to remove.</param>
        /// <returns></returns>
        public List<Item> RemoveSomeOfItem(int itemID, int amount)
        {
            int itemAmountContained = this.HasItem(itemID);

            if (itemAmountContained > 0)
            {
                if (itemAmountContained > amount)
                {
                    List<Item> Grabbed = new List<Item>();
                    List<Item> allContained = this.Items[itemID];
                    this.Items.Remove(itemID);

                    int totalGrabbed = 0;
                    int i = 0;
                    while (totalGrabbed < amount)
                    {
                        Item current = allContained[i];

                        if (current.CurrentlyStacked <= amount - totalGrabbed)
                        {
                            //The stack isn't too big, grab it
                            allContained.RemoveAt(i);
                            Grabbed.Add(current);
                            totalGrabbed += current.CurrentlyStacked;
                        }
                        else
                        {
                            //Stack's too big, split it
                            (Item, Item) result = Item.Split(current, amount - totalGrabbed);
                            allContained.RemoveAt(i);

                            Grabbed.Add(result.Item1);
                            totalGrabbed += result.Item1.CurrentlyStacked;
                            allContained.Add(result.Item2);
                        }
                        i++;
                    }

                    this.Items.Add(itemID, allContained);
                    return Grabbed;
                }
                else
                {
                    return this.RemoveAllOfItem(itemID);
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Returns how much of a certain item is stored in this inventory.
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        public int HasItem(int itemID)
        {
            int count = 0;

            if (this.Items.ContainsKey(itemID))
            {
                List<Item> stacks = this.Items[itemID];

                foreach (Item item in stacks)
                {
                    count += item.CurrentlyStacked;
                }
            }

            return count;
        }

        /// <summary>
        /// Adds the item(s) to this inventory.
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(Item item)
        {
            if (this.Items.ContainsKey(item.ItemID))
            {
                List<Item> stored = this.Items[item.ItemID];
                this.Items.Remove(item.ItemID);

                int resultIndex = -1;
                int length = stored.Count();
                for (int i = 0; i < length; i++)
                {
                    Item current = stored[i];
                    if (current.CurrentlyStacked < current.StackableLimit)
                    {
                        resultIndex = i;
                        break;
                    }
                }

                if (resultIndex == -1)
                {
                    stored.Add(item);
                }
                else
                {
                    Item storedItem = stored[resultIndex];
                    stored.RemoveAt(resultIndex);

                    Item combined = Item.Combine(storedItem, item, out Item overflow);
                    stored.Add(combined);

                    if (overflow != null)
                    {
                        stored.Add(overflow);
                    }
                }
                
            }
        }
    }
}
