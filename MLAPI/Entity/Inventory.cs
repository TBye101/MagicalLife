using System.Collections.Generic;
using MLAPI.DataTypes.Attribute;
using MLAPI.World.Base;
using ProtoBuf;

namespace MLAPI.Entity
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
        private Dictionary<int, List<Item>> Items;

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

        [ProtoAfterDeserialization]
        private void PostDeserialization()
        {
            if (this.Items == null)
            {
                this.Items = new Dictionary<int, List<Item>>();
            }
        }

        /// <summary>
        /// Returns all of the item contained in this inventory, and removes the item from this inventory.
        /// Returns an empty list if the item is not contained in this inventory.
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public List<Item> RemoveAllOfItem(int itemId)
        {
            if (this.Items.ContainsKey(itemId))
            {
                List<Item> stacks = this.Items[itemId];
                this.Items.Remove(itemId);

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
                return default;
            }
        }

        /// <summary>
        /// Returns as much of the item as requested.
        /// If more is requested than actually exists in this inventory than the amount stored is returned.
        /// Removes all items requested from this inventory.
        /// Returns an empty collection if this inventory stores non of the requested item.
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="amount">The amount to remove.</param>
        /// <returns></returns>
        public List<Item> RemoveSomeOfItem(int itemId, int amount)
        {
            int itemAmountContained = this.HasItem(itemId);

            if (itemAmountContained > 0)
            {
                if (itemAmountContained > amount)
                {
                    return this.RemoveSomeSplit(itemId, amount);
                }
                else
                {
                    return this.RemoveAllOfItem(itemId);
                }
            }
            else
            {
                return default;
            }
        }

        /// <summary>
        /// Removes some when the inventory stores more of the item than the amount which is requested.
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        private List<Item> RemoveSomeSplit(int itemId, int amount)
        {
            List<Item> grabbed = new List<Item>();
            List<Item> allContained = this.Items[itemId];
            this.Items.Remove(itemId);

            int totalGrabbed = 0;
            int i = 0;
            while (totalGrabbed < amount)
            {
                Item current = allContained[i];

                if (current.CurrentlyStacked <= amount - totalGrabbed)
                {
                    //The stack isn't too big, grab it
                    allContained.RemoveAt(i);
                    grabbed.Add(current);
                    totalGrabbed += current.CurrentlyStacked;
                    this.AdjustWeight(current.ItemWeight, current.CurrentlyStacked, false);
                }
                else
                {
                    //Stack's too big, split it
                    (Item, Item) result = Item.Split(current, amount - totalGrabbed);
                    allContained.RemoveAt(i);

                    grabbed.Add(result.Item1);
                    totalGrabbed += result.Item1.CurrentlyStacked;
                    allContained.Add(result.Item2);
                    this.AdjustWeight(result.Item1.ItemWeight, result.Item1.CurrentlyStacked, false);
                }
                i++;
            }

            this.Items.Add(itemId, allContained);

            return grabbed;
        }

        /// <summary>
        /// Returns how much of a certain item is stored in this inventory.
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public int HasItem(int itemId)
        {
            int count = 0;

            if (this.Items.ContainsKey(itemId))
            {
                List<Item> stacks = this.Items[itemId];

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

            if (this.Items.ContainsKey(item.ItemId))
            {
                this.AddItemContaining(item);
            }
            else
            {
                List<Item> toAdd = new List<Item>
                {
                    item
                };

                this.Items.Add(item.ItemId, toAdd);
            }
        }

        /// <summary>
        /// Used to add an item when this inventory already contains some of that item.
        /// </summary>
        /// <param name="item"></param>
        private void AddItemContaining(Item item)
        {
            List<Item> stored = this.Items[item.ItemId];
            this.Items.Remove(item.ItemId);

            int resultIndex = -1;
            int length = stored.Count;
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
                this.Items.Add(item.ItemId, stored);
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