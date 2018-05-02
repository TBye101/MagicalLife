using MagicalLifeGUIWindows.GUI.Reusable;
using Microsoft.Xna.Framework;

namespace MagicalLifeGUIWindows.GUI.New_World_Menu.Input_Boxes
{
    public class WorldDepthInputBox : InputBox
    {
        public WorldDepthInputBox(bool isLocked) : base("InputBox100x50", "CursorCarrot", GetInitialLocation(), int.MaxValue, "MainMenuFont12x", isLocked, Rendering.Text.SimpleTextRenderer.Alignment.Left)
        {
        }

        public WorldDepthInputBox() : base()
        {
        }

        public string GetTextureName()
        {
            return "CursorCarrot";
        }

        /// <summary>
        /// Returns the starting location for this input box.
        /// </summary>
        /// <returns></returns>
        private static Rectangle GetInitialLocation()
        {
            int x = NewWorldMenuLayout.WorldDepthInputBoxX;
            int y = NewWorldMenuLayout.WorldSizeInputBoxY;
            int width = NewWorldMenuLayout.WorldSizeInputBoxWidth;
            int height = NewWorldMenuLayout.WorldSizeInputBoxHeight;

            return new Rectangle(x, y, width, height);
        }
    }
}