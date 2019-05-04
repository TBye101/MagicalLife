using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Components;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.Error.InternalExceptions;
using MagicalLifeAPI.GUI;
using MagicalLifeAPI.Registry.ItemRegistry;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MagicalLifeAPI.World.Base
{
    /// <summary>
    /// Represents almost everything in a movable/harvested form.
    /// </summary>
    [ProtoContract]
    public abstract class Item : HasComponents, IEquatable<Item>
    {
        /// <summary>
        /// The name of this <see cref="Item"/>.
        /// </summary>
        [ProtoMember(1)]
        public string Name { get; }

        /// <summary>
        /// The name of the mod this item is from.
        /// </summary>
        [ProtoMember(2)]
        public string ModFrom { get; }

        /// <summary>
        /// The description and lore of this item. Is not revealed until the item has been identified, unless it never needed identification.
        /// </summary>
        [ProtoMember(3)]
        public List<string> Lore { get; set; }

        /// <summary>
        /// The maximum number of this item that may be contained in the same stack.
        /// Must be greater than or equal to one.
        /// </summary>
        [ProtoMember(4)]
        public int StackableLimit { get; set; }

        /// <summary>
        /// How many identical items are currently being clumped and held be this class.
        /// </summary>
        [ProtoMember(5)]
        public int CurrentlyStacked { get; set; }

        private int _itemID = int.MinValue;

        /// <summary>
        /// The ID that describes this item to the <see cref="ItemRegistry"/>.
        /// </summary>
        [ProtoMember(6)]
        public int ItemID
        {
            get
            {
                if (this._itemID == int.MinValue)
                {
                    this._itemID = ItemRegistry.ItemToID[this];
                }
                return this._itemID;
            }

            private set
            {
                this._itemID = value;
            }
        }

        [ProtoMember(7)]
        public string TextureName { get; set; }

        [ProtoMember(8)]
        public double ItemWeight { get; set; }

        [ProtoMember(9)]
        public Guid ID { get; set; }

        /// <summary>
        /// The ID of the job that this item is reserved for.
        /// Empty Guid signifies that this item is not reserved for a job.
        /// </summary>
        [ProtoMember(10)]
        public Guid ReservedID { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="name">The display name of the item.</param>
        /// <param name="lore">Any text accompanying the item.</param>
        /// <param name="location">The location of this item.</param>
        /// <param name="stackableLimit">How many items of this kind can be in one stack.</param>
        /// <param name="count">How many of this item to create into a stack.</param>
        /// <param name="itemID">The ID of this item.</param>
        protected Item(string name, List<string> lore, int stackableLimit, int count, string textureName, double itemWeight, string modFrom)
            : base(true)
        {
            this.Name = name;
            this.ModFrom = modFrom;
            this.Lore = lore;
            this.StackableLimit = stackableLimit;
            this.CurrentlyStacked = count;
            this.TextureName = textureName;
            this.ItemWeight = itemWeight;
            this.ID = Guid.NewGuid();
            this.ReservedID = Guid.Empty;
            this.InitializeComponents();
            this.Validate();
        }

        protected Item() : base()
        {
            //Protobuf-net constructor
        }

        private void InitializeComponents()
        {
            int textureIndex = AssetManager.GetTextureIndex(this.TextureName);

            ComponentHasTexture textureComponent = new ComponentHasTexture(false);
            textureComponent.Visuals.Add(new StaticTexture(textureIndex, RenderLayer.Items));

            this.AddComponent(new ComponentHasTexture(false));
        }


        private void SetItemID()
        {
            try
            {
                this.ItemID =
                    ItemRegistry.IDToItem.First(x => x.Value.ModFrom.Equals(this.ModFrom) &&
                x.Value.Name.Equals(this.Name)).Key;//slow
            }
            catch (InvalidOperationException e)
            {
                this.ItemID = -1;
            }
        }

        protected internal void Validate()
        {
            if (this.CurrentlyStacked < 1)
            {
                throw new ArgumentOutOfRangeException("Error: Cannot have an item with 0 items");
            }
            if (this.StackableLimit < 1)
            {
                throw new ArgumentOutOfRangeException("Error: Must be able to stack at least one item");
            }
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
        public static Item Combine(Item one, Item two, out Item overflow)
        {
            //Check to make sure the items are compatible, otherwise modders/hackers/bugs could be exploited to transmute cheap items into rarer things.
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
                throw new InvalidOperationException("Error: Combining two items of different types is impossible to store.");
            }
        }

        /// <summary>
        /// Creates two items and will have the first be the specified amount, and the second be the leftovers.
        /// Note: This will not remove any items.
        /// </summary>
        /// <param name="originalItem"></param>
        /// <param name="firstItemSize">The size of how big the first item in the tuple should be. The second item gets whatever is leftover.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static ValueTuple<Item, Item> Split(Item originalItem, int firstItemSize)
        {
            if (originalItem.CurrentlyStacked <= firstItemSize)
            {
                throw new ArgumentException(string.Format("{0} is greater than {1}, the amount originally stacked.",firstItemSize,originalItem.CurrentlyStacked));
            }
            else
            {
                int totalCount = originalItem.CurrentlyStacked;
                Item firstItem = originalItem;
                Item secondItem = originalItem;

                firstItem.CurrentlyStacked = firstItemSize;
                secondItem.CurrentlyStacked = totalCount - firstItemSize;

                return new ValueTuple<Item, Item>(firstItem, secondItem);
            }
        }

        /// <summary>
        /// Return a deep copy of the current item.
        /// </summary>
        /// <param name="amouont">The amount of the item to be created via deep copy.</param>
        /// <returns></returns>
        public abstract Item GetDeepCopy(int amount);

        /// <summary>
        /// Returns true if the items are of the same type.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Item other)
        {
            return other.GetType().Equals(this.GetType());
        }

        public override int GetHashCode()
        {
            int hash = (this.Name != null ? this.Name.GetHashCode() : 0);
            hash = (hash * 396) ^ (this.ModFrom != null ? this.ModFrom.GetHashCode() : 0);
            hash = (hash * 396) ^ (this.StackableLimit.GetHashCode());
            return hash;
        }
    }
}