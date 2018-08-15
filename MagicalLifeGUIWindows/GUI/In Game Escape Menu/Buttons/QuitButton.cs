using MagicalLifeAPI.Sound;
using MagicalLifeGUIWindows.GUI.Reusable;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.GUI.In_Game_Escape_Menu.Buttons
{
    public class QuitButton : MonoButton
    {
        public QuitButton() : base("MenuButton", GetDisplayArea(), true, "Quit")
        {
        }

        private static Rectangle GetDisplayArea()
        {
            int x = InGameEscapeMenuLayout.ButtonX;
            int y = InGameEscapeMenuLayout.QuitButtonY;
            int width = InGameEscapeMenuLayout.ButtonWidth;
            int height = InGameEscapeMenuLayout.ButtonHeight;

            return new Rectangle(x, y, width, height);
        }

        public override void Click(MouseEventArgs e, GUIContainer container)
        {
            FMODUtil.RaiseEvent(EffectsTable.UIClick);
        }

        public override void DoubleClick(MouseEventArgs e, GUIContainer container)
        {
            FMODUtil.RaiseEvent(EffectsTable.UIClick);
        }
    }
}
