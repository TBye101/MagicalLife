using MagicalLifeAPI.Crafting;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.World.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeAPI.Registry.Recipe
{
    /// <summary>
    /// The registry for all recipes.
    /// </summary>
    public static class RecipeRegistry
    {
        public static MultiValueDictionary<Item, IRecipe> ItemToRecipe { get; private set; } = new MultiValueDictionary<Item, IRecipe>();

        /// <summary>
        /// Registers a recipe with the game.
        /// </summary>
        /// <param name="recipe"></param>
        public static void RegisterRecipe(SimpleItemRecipe recipe)
        {
            ItemToRecipe.Add(recipe.GetExampleOutput(), recipe);
        }
    }
}
