using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeGUIWindows.GUI.Save_Game_Menu;
using MagicalLifeGUIWindows.Input;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.GUI.In_Game_Escape_Menu.Buttons
{
    public class BackButton : MonoButton
    {
        public BackButton() : base("MenuButton", GetDisplayArea(), true, "Back")
        {
        }

        private static Rectangle GetDisplayArea()
        {
            int x = InGameEscapeMenuLayout.ButtonX;
            int y = InGameEscapeMenuLayout.BackButtonY;
            int width = InGameEscapeMenuLayout.ButtonWidth;
            int height = InGameEscapeMenuLayout.ButtonHeight;

            return new Rectangle(x, y, width, height);
        }

        public override void Click(MouseEventArgs e, GUIContainer container)
        {
            MenuHandler.Back();
        }

        public override void DoubleClick(MouseEventArgs e, GUIContainer container)
        {
            MenuHandler.Back();
        }
    }
}
