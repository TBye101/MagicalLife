using Microsoft.Xna.Framework;
using MLAPI.Asset;
using MLAPI.Visual.Rendering;
using MonoGUI.MonoGUI.Reusable;

namespace MLGUIWindows.GUI.Save_Game_Menu.InputBoxes
{
    public class NewSaveInputBox : MonoInputBox
    {
        public NewSaveInputBox() :
            base(TextureLoader.GuiInputBox100X50, TextureLoader.GuiCursorCarrot, GetInitialLocation(), int.MaxValue, TextureLoader.FontMainMenuFont12X,
                false, SimpleTextRenderer.Alignment.Left, true)
        {
        }

        private static Rectangle GetInitialLocation()
        {
            int x = SaveGameMenuLayout.NewSaveInputBoxX;
            int y = SaveGameMenuLayout.NewSaveInputBoxY;
            int width = SaveGameMenuLayout.NewSaveInputBoxWidth;
            int height = SaveGameMenuLayout.NewSaveInputBoxHeight;

            return new Rectangle(x, y, width, height);
        }
    }
}