using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Crafting;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Registry.Recipe;
using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeGUIWindows.GUI.Reusable.Collections;
using MagicalLifeAPI.World.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MagicalLifeGUIWindows.GUI.Action_Menu
{
    /// <summary>
    /// The action menu container.
    /// </summary>
    public class ActionMenuContainer : GUIContainer
    {
        public MonoGrid ActionGrid { get; set; }

        public ActionMenuContainer(bool visible) : base(TextureLoader.GUIMenuBackground, ActionMenuLayout.ActionMenuLocation, false)
        {
            this.Visible = visible;

            this.ActionGrid = new MonoGrid(new Point2D(32 ,32), ActionMenuLayout.ActionMenuLocation, int.MaxValue,
                true, TextureLoader.FontMainMenuFont12x, 5);
            this.PopulateActionGrid();

            this.Controls.Add(this.ActionGrid);
        }

        private void PopulateActionGrid()
        {
            Rectangle zero = new Rectangle(0, 0, 0, 0);
            foreach (KeyValuePair<Item, List<IRecipe>> item in RecipeRegistry.ItemToRecipe)
            {
                foreach (IRecipe item2 in item.Value)
                {
                    RenderableImage recipeImage = new RenderableImage(zero, item2.GetDisplayTextureID(), true);
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
