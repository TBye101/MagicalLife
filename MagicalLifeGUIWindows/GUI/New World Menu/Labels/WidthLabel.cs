using MagicalLifeGUIWindows.GUI.Reusable;
using Microsoft.Xna.Framework;

namespace MagicalLifeGUIWindows.GUI.New_World_Menu.Labels
{
    /// <summary>
    /// The label that hovers over the width input box within the new world menu.
    /// </summary>
    public class WidthLabel : MonoLabel
    {
        public WidthLabel() : base(GetLocation(), "InputBox100x50")
        {
            this.Text = "World Width";
        }

        private static Rectangle GetLocation()
        {
            int x = NewWorldMenuLayout.WorldWidthInputBoxX;
            int y = NewWorldMenuLayout.LabelY;
            int width = NewWorldMenuLayout.WorldSizeInputBoxWidth;
            int height = NewWorldMenuLayout.WorldSizeInputBoxHeight;

            return new Rectangle(x, y, width, height);
        }
    }
}