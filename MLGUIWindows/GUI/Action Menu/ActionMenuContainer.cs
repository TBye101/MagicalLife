using System.Collections.Generic;
using MLAPI.Asset;
using MLAPI.Crafting;
using MLAPI.DataTypes;
using MLAPI.GameRegistry.Recipe;
using MLAPI.World.Base;
using MonoGUI.Game.Custom;
using MonoGUI.MonoGUI.Reusable;
using MonoGUI.MonoGUI.Reusable.Collections;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace MLGUIWindows.GUI.Action_Menu
{
    /// <summary>
    /// The action menu container.
    /// </summary>
    public class ActionMenuContainer : GuiContainer
    {
        public MonoGrid ActionGrid { get; set; }

        public ActionMenuContainer(bool visible) : base(TextureLoader.GUIMenuBackground, ActionMenuLayout.ActionMenuLocation, false)
        {
            this.Visible = visible;

            this.ActionGrid = new MonoGrid(new Point2D(32, 32), ActionMenuLayout.ActionGridBounds, int.MaxValue,
                true, TextureLoader.FontMainMenuFont12x, 5);
            this.PopulateActionGrid();

            this.Controls.Add(this.ActionGrid);
        }

        private void PopulateActionGrid()
        {
            Rectangle zero = new Rectangle(0, 0, 32, 32);
            foreach (KeyValuePair<Item, List<IRecipe>> item in RecipeRegistry.ItemToRecipe)
            {
                foreach (IRecipe item2 in item.Value)
                {
                    RenderableImage recipeImage = new RenderableIRecipe(zero, item2.GetDisplayTextureID(), true, item2);
                    this.ActionGrid.Add(recipeImage);
                }
            }
        }

        public override string GetTextureName()
        {
            return TextureLoader.GUIMenuBackground;
        }
    }
}