using MagicalLifeAPI.Asset;
using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeGUIWindows.GUI.Reusable.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            this.ActionGrid = new MonoGrid(ActionMenuLayout.ActionMenuLocation, int.MaxValue,
                true, TextureLoader.FontMainMenuFont12x, 5);

            this.Controls.Add(this.ActionGrid);
        }

        public override string GetTextureName()
        {
            return TextureLoader.GUIMenuBackground;
        }
    }
}
