using MagicalLifeGUIWindows.GUI.Reusable;
using Microsoft.Xna.Framework;

namespace MagicalLifeGUIWindows.GUI.Join_Game_Menu.Input_Boxes
{
    public class IPInputBox : MonoInputBox
    {
        public IPInputBox(bool isLocked) : base("InputBox100x50", "CursorCarrot", GetInitialLocation(), int.MaxValue, "MainMenuFont12x", isLocked, Rendering.Text.SimpleTextRenderer.Alignment.Left)
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