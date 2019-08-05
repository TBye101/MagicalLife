using Microsoft.Xna.Framework;
using MLAPI.Asset;
using MLAPI.Visual.Rendering;
using MonoGUI.MonoGUI.Reusable;

namespace MLGUIWindows.GUI.Join_Game_Menu.Input_Boxes
{
    public class IPInputBox : MonoInputBox
    {
        public IPInputBox(bool isLocked)
            : base(TextureLoader.GUIInputBox100x50, TextureLoader.GUICursorCarrot, GetInitialLocation(),
                  int.MaxValue, TextureLoader.FontMainMenuFont12x, isLocked, SimpleTextRenderer.Alignment.Left, true)
        {
        }

        private static Rectangle GetInitialLocation()
        {
            int x = JoinGameMenuLayout.IPInputBoxX;
            int y = JoinGameMenuLayout.IPInputBoxY;
            int width = JoinGameMenuLayout.IPInputBoxWidth;
            int height = JoinGameMenuLayout.IPInputBoxHeight;
            return new Rectangle(x, y, width, height);
        }
    }
}