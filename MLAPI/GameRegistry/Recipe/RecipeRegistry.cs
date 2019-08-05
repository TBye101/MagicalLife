using MLAPI.Crafting;
using MLAPI.DataTypes.Collection;
using MLAPI.World.Base;

namespace MLAPI.GameRegistry.Recipe
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