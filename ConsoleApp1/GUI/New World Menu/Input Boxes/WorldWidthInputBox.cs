using MagicalLifeAPI.Asset;
using MagicalLifeGUIWindows.GUI.Reusable;
using Microsoft.Xna.Framework;

namespace MagicalLifeGUIWindows.GUI.New
{
    /// <summary>
    /// Allows the user to input how wide they want the world to be.
    /// </summary>
    public class WorldWidthInputBox : MonoInputBox
    {
        public WorldWidthInputBox(bool isLocked)
            : base(TextureLoader.GUIInputBox100x50, TextureLoader.GUICursorCarrot, GetInitialLocation(),
                  int.MaxValue, TextureLoader.FontMainMenuFont12x, isLocked,
                  Rendering.Text.SimpleTextRenderer.Alignment.Left, true)
        {
        }

        public WorldWidthInputBox() : base()
        {
        }

        /// <summary>
        /// Returns the starting location for this input box.
        /// </summary>
        /// <returns></returns>
        private static Rectangle GetInitialLocation()
        {
            int x = NewWorldMenuLayout.WorldWidthInputBoxX;
            int y = NewWorldMenuLayout.WorldSizeInputBoxY;
            int width = NewWorldMenuLayout.WorldSizeInputBoxWidth;
            int height = NewWorldMenuLayout.WorldSizeInputBoxHeight;

            return new Rectangle(x, y, width, height);
        }
    }
}