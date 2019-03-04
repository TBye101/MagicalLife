using MagicalLifeAPI.DataTypes.Attribute;
using MagicalLifeAPI.World.Base;
using ProtoBuf;
using System.Collections.Generic;
using System.Linq;

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

        /// <summary>
        /// The combined weight of all the objects in the inventory.
        /// </summary>
        [ProtoMember(2)]
        private double _Weight;

        [ProtoMember(3)]
        public AttributeDouble Multiplyer { get; set; }

        /// <summary>
        /// The weight of all items in this inventory taking into account multipliers.
        /// </summary>
        public double Weight
        {
            get
            {
                return this._Weight * this.Multiplyer.GetValue();
            }
        }

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

                int amount = 0;
                double weight = 0;

                foreach (Item item in stacks)
                {
                    amount += item.CurrentlyStacked;
                    weight = item.ItemWeight;
                }

                this.AdjustWeight(weight, amount, false);
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
                    return this.RemoveSomeSplit(itemID, amount);
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
        /// Removes some when the inventory stores more of the item than the amount which is requested.
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        private List<Item> RemoveSomeSplit(int itemID, int amount)
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
                    this.AdjustWeight(current.ItemWeight, current.CurrentlyStacked, false);
                }
                else
                {
                    //Stack's too big, split it
                    (Item, Item) result = Item.Split(current, amount - totalGrabbed);
                    allContained.RemoveAt(i);

                    Grabbed.Add(result.Item1);
                    totalGrabbed += result.Item1.CurrentlyStacked;
                    allContained.Add(result.Item2);
                    this.AdjustWeight(result.Item1.ItemWeight, result.Item1.CurrentlyStacked, false);
                }
                i++;
            }

            this.Items.Add(itemID, allContained);

            return Grabbed;
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
            this.AdjustWeight(item.ItemWeight, item.CurrentlyStacked, true);

            if (this.Items.ContainsKey(item.ItemID))
            {
                this.AddItemContaining(item);
            }
            else
            {
                List<Item> toAdd = new List<Item>
                {
                    item
                };

                this.Items.Add(item.ItemID, toAdd);
            }
        }

        /// <summary>
        /// Used to add an item when this inventory already contains some of that item.
        /// </summary>
        /// <param name="item"></param>
        private void AddItemContaining(Item item)
        {
            List<Item> stored = this.Items[item.ItemID];
            this.Items.Remove(item.ItemID);

            int resultIndex = -1;
            int length = stored.Count();
            for (int i = 0; i < length; i++)
            {
                Item current = stored[i];
                //If this stack can hold some more of the item...
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

        /// <summary>
        /// Adjust the weight stored in this container.
        /// </summary>
        /// <param name="itemWeight"></param>
        /// <param name="amountOfItem"></param>
        /// <param name="adding"></param>
        private void AdjustWeight(double itemWeight, int amountOfItem, bool adding)
        {
            if (adding)
            {
                this._Weight += itemWeight * amountOfItem;
            }
            else
            {
                this._Weight -= itemWeight * amountOfItem;
            }
        }

        /// <summary>
        /// Returns a list of all of the items in this inventory.
        /// Stored as: [itemID, itemObject]
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, List<Item>> GetAllInventoryItems()
        {
            return this.Items;
        }
    }
}