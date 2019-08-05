using Microsoft.Xna.Framework;
using MLAPI.Asset;
using MLAPI.Visual.Rendering;
using MonoGUI.MonoGUI.Reusable;

namespace MLGUIWindows.GUI.New_World_Menu.Input_Boxes
{
    /// <summary>
    /// Allows the user to input how long they want the world to be.
    /// </summary>
    public class WorldLengthInputBox : MonoInputBox
    {
        public WorldLengthInputBox(bool isLocked)
            : base(TextureLoader.GuiInputBox100X50, TextureLoader.GuiCursorCarrot, GetInitialLocation(),
                  int.MaxValue, TextureLoader.FontMainMenuFont12X, isLocked,
                  SimpleTextRenderer.Alignment.Left, true)
        {
        }

        public WorldLengthInputBox() : base()
        {
        }

        /// <summary>
        /// Returns the starting location for this input box.
        /// </summary>
        /// <returns></returns>
        private static Rectangle GetInitialLocation()
        {
            int x = NewWorldMenuLayout.WorldLengthInputBoxX;
            int y = NewWorldMenuLayout.WorldSizeInputBoxY;
            int width = NewWorldMenuLayout.WorldSizeInputBoxWidth;
            int height = NewWorldMenuLayout.WorldSizeInputBoxHeight;

            return new Rectangle(x, y, width, height);
        }
    }
}