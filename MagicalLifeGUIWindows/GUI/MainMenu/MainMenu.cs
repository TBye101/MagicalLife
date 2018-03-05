using MagicalLifeRenderEngine.Main.GUI.Click;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.GUI.MainMenu
{
    public static class MainMenu
    {
        private static MainMenuContainer MainMenuID;

        internal static void Initialize()
        {
            MainMenuContainer mainMenu = new MainMenuContainer(true);
            MainMenuID = mainMenu;
            MouseHandler.AddContainer(mainMenu);
        }

        internal static void ToggleMainMenu()
        {
            if (MainMenuID.Visible)
            {
                MainMenuID.Visible = false;
            }
            else
            {
                MainMenuID.Visible = true;
            }
        }
    }
}
