using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeGUIWindows.Rendering.Text;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.GUI.Join_Game_Menu.Input_Boxes
{
    public class PortInputBox : MonoInputBox
    {
        public PortInputBox(bool isLocked) : base("InputBox100x50", "CursorCarrot", GetInitialLocation(), int.MaxValue, "MainMenuFont12x", isLocked, Rendering.Text.SimpleTextRenderer.Alignment.Left)
        {
        }

        private static Rectangle GetInitialLocation()
        {
            int x = JoinGameMenuLayout.PortInputBoxX;
            int y = JoinGameMenuLayout.IPInputBoxY;
            int width = JoinGameMenuLayout.IPInputBoxWidth;
            int height = JoinGameMenuLayout.IPInputBoxHeight;
            return new Rectangle(x, y, width, height);
        }
    }
}
