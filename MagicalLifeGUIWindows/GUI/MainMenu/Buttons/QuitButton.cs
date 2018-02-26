using MagicalLifeAPI.Universal;
using MagicalLifeGUIWindows.GUI.Reusable;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.GUI.MainMenu.Buttons
{
    public class QuitButton : MonoButton
    {
        public QuitButton() : base("MenuButton", GetLocation(), "Quit")
        {

        }

        public override void Click(MouseEventArgs e)
        {
            UniversalEvents.GameExitHandler();
        }

        public override void DoubleClick(MouseEventArgs e)
        {
            UniversalEvents.GameExitHandler();
        }

        private static Rectangle GetLocation()
        {
            int width = MainMenuLayout.ButtonWidth;
            int height = MainMenuLayout.ButtonHeight;
            int x = MainMenuLayout.ButtonX;
            int y = MainMenuLayout.QuitButtonY;

            return new Rectangle(x, y, width, height);
        }
    }
}
