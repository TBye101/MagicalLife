using MagicalLifeGUIWindows.GUI.In_Game_GUI.Buttons;
using MagicalLifeGUIWindows.GUI.Reusable;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.GUI.In_Game_GUI
{
    /// <summary>
    /// The in game GUI container.
    /// </summary>
    public class InGameGUIContainer : GUIContainer
    {
        public TurnButton turnButton = new TurnButton();

        public InGameGUIContainer(bool visible) : base("MenuBackground", GetDrawingBounds())
        {
            this.Visible = visible;
            this.Controls.Add(this.turnButton);
        }

        /// <summary>
        /// Returns the bounds of which this should be rendered at.
        /// </summary>
        /// <returns></returns>
        public static Rectangle GetDrawingBounds()
        {
            int x = InGameGUILayout.ContainerX;
            int y = InGameGUILayout.ContainerY;
            int width = InGameGUILayout.ContainerWidth;
            int height = InGameGUILayout.ContainerHeight;

            return new Rectangle(x, y, width, height);
        }

        public override string GetTextureName()
        {
            return "MenuBackground";
        }
    }
}
