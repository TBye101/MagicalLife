using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Entity;
using MagicalLifeAPI.Entity.AI.Task;
using MagicalLifeAPI.Entity.AI.Task.Tasks;
using MagicalLifeAPI.Registry.ItemRegistry;
using MagicalLifeAPI.World.Base;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeAPI.Crafting
{
    /// <summary>
    /// For simple item recipes.
    /// Take items in, craft them, create new items.
    /// No benches required for these recipes.
    /// </summary>
    [ProtoContract]
    public class SimpleItemRecipe : IRecipe
    {
        [ProtoMember(1)]
        public Item[] RequiredItems { get; internal set; }

        /// <summary>
        /// The itemID of the item that this recipe constructs.
        /// </summary>
        [ProtoMember(2)]
        public int OutputItemID { get; internal set; }

        /// <summary>
        /// An example of the output that this recipe creates.
        /// </summary>
        /// <param name="requiredItems"></param>
        /// <param name="exampleOutput"></param>
        [ProtoMember(3)]
        private Item ExampleOutput { get; set; }

        [ProtoMember(4)]
        private Guid ID { get; set; }

        /// <summary>
        /// Keywords that can be used to more easily find this recipe.
        /// </summary>
        [ProtoMember(5)]
        private string[] RecipeKeywords { get; set; }

        public SimpleItemRecipe(Item exampleOutput, Guid constantGuid, string[] recipeKeywords, params Item[] requiredItems)
        {
            this.RequiredItems = requiredItems;
            this.ExampleOutput = exampleOutput;
            this.ID = constantGuid;
            this.RecipeKeywords = recipeKeywords;
        }

        /// <summary>
        /// Crafts the item and removes the used ingredients from the inventory.
        /// </summary>
        /// <param name="inventory"></param>
        /// <param name="craftAmount">The amount to be crafted.</param>
        /// <returns>Returns null if the item cannot be crafted.</returns>
        public Item Craft(Inventory inventory, int craftAmount)
        {
            if (this.CanCraft(inventory) > craftAmount)
            {
                foreach (Item item in this.RequiredItems)
                {
                    inventory.RemoveSomeOfItem(item.ItemID, item.CurrentlyStacked * craftAmount);
                }

                Item output = this.ExampleOutput.GetDeepCopy(craftAmount);
                output.CurrentlyStacked = craftAmount;
                return output;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Determines the number of an item we could craft based upon the provided inventory.
        /// </summary>
        /// <param name="inventory"></param>
        /// <returns></returns>
        public int CanCraft(Inventory inventory)
        {
            int limiter = int.MaxValue;

            foreach (Item item in this.RequiredItems)
            {
                //The amount the inventory has of the item.
                int quantityStored = inventory.HasItem(item.ItemID);
                //The amount of this recipe we could craft if this were the only item.
                int craftable = quantityStored / item.StackableLimit;

                if (craftable < limiter)
                {
                    limiter = craftable;
                }
            }

            return limiter;
        }

        public Item GetExampleOutput()
        {
            return this.ExampleOutput;
        }

        public Guid GetUniqueID()
        {
            return this.ID;
        }

        public int GetDisplayTextureID()
        {
            return AssetManager.NameToIndex[this.ExampleOutput.TextureName];
        }

        public string GetDisplayName()
        {
            return this.ExampleOutput.Name;
        }

        public string[] GetKeywords()
        {
            return this.RecipeKeywords;
        }

        public string GetModName()
        {
            return this.ExampleOutput.ModFrom;
        }

        public void Clicked()
        {
            throw new NotImplementedException();//Need to create some sort of recipe viewing window now.
        }

        public void SpecialClicked()
        {
            TaskManager.Manager.AddTask(new CraftSimpleItemTask(Guid.NewGuid(), this, 1));
        }
    }
}
