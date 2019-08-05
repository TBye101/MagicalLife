using Microsoft.Xna.Framework;
using MLAPI.Asset;
using MLGUIWindows.Properties;
using MonoGUI.MonoGUI.Reusable;

namespace MLGUIWindows.GUI.New_World_Menu.Labels
{
    /// <summary>
    /// The label that hovers over the width input box within the new world menu.
    /// </summary>
    public class LengthLabel : MonoLabel
    {
        public LengthLabel() : base(GetLocation(), TextureLoader.GuiInputBox100X50, true, Resources.WorldLength)
        {
        }

        private static Rectangle GetLocation()
        {
            int x = NewWorldMenuLayout.WorldLengthInputBoxX;
            int y = NewWorldMenuLayout.LabelY;
            int width = NewWorldMenuLayout.WorldSizeInputBoxWidth;
            int height = NewWorldMenuLayout.WorldSizeInputBoxHeight;

            return new Rectangle(x, y, width, height);
        }
    }
}