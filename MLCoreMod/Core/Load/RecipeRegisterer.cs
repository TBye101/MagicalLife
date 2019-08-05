using System;
using MLAPI.Crafting;
using MLAPI.GameRegistry.Recipe;
using MLAPI.Load;
using MLCoreMod.Core.Items;

namespace MLCoreMod.Core.Load
{
    public class RecipeRegisterer : IGameLoader
    {
        internal readonly SimpleItemRecipe WoodPlankRecipe;
        internal readonly Guid WoodPlankRecipeID = Guid.Parse("082CEDD8-290B-409C-8F1B-7D08DD632F56");

        public RecipeRegisterer()
        {
            this.WoodPlankRecipe = new SimpleItemRecipe(new WoodPlank(4), this.WoodPlankRecipeID,
                new string[0], new RequiredItem(ItemRegisterer.ExampleLog, 1));
        }

        public void InitialStartup()
        {
            RecipeRegistry.RegisterRecipe(this.WoodPlankRecipe);
        }
    }
}