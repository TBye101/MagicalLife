using MagicalLifeGUIWindows.GUI.Reusable;
using Microsoft.Xna.Framework;

namespace MagicalLifeGUIWindows.GUI.Host_Game_Menu.Input_Boxes
{
    /// <summary>
    /// The input box where the user inputs what port to host the game on.
    /// </summary>
    public class HostPortInputBox : MonoInputBox
    {
        public HostPortInputBox(bool isLocked) : base("InputBox100x50", "CursorCarrot", GetInitialLocation(), int.MaxValue, "MainMenuFont12x", isLocked, Rendering.Text.SimpleTextRenderer.Alignment.Left)
        {
        }

        private static Rectangle GetInitialLocation()
        {
            int x = HostGameMenuLayout.PortInputBoxX;
            int y = HostGameMenuLayout.PortInputBoxY;
            int width = HostGameMenuLayout.InputBoxWidth;
            int height = HostGameMenuLayout.InputBoxHeight;
            return new Rectangle(x, y, width, height);
        }
    }
}