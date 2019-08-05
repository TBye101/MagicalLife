using Microsoft.Xna.Framework;
using MLAPI.Asset;
using MLAPI.Visual.Rendering;
using MonoGUI.MonoGUI.Reusable;

namespace MLGUIWindows.GUI.Join_Game_Menu.Input_Boxes
{
    public class IpInputBox : MonoInputBox
    {
        public IpInputBox(bool isLocked)
            : base(TextureLoader.GuiInputBox100X50, TextureLoader.GuiCursorCarrot, GetInitialLocation(),
                  int.MaxValue, TextureLoader.FontMainMenuFont12X, isLocked, SimpleTextRenderer.Alignment.Left, true)
        {
        }

        private static Rectangle GetInitialLocation()
        {
            int x = JoinGameMenuLayout.IpInputBoxX;
            int y = JoinGameMenuLayout.IpInputBoxY;
            int width = JoinGameMenuLayout.IpInputBoxWidth;
            int height = JoinGameMenuLayout.IpInputBoxHeight;
            return new Rectangle(x, y, width, height);
        }
    }
}