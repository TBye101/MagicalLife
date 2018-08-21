using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.GUI.Save_Game_Menu
{
    public static class SaveGameMenu
    {
        public static SaveGameMenuContainer menu;

        internal static void Initialize()
        {
            SaveGameMenuContainer mainMenu = new SaveGameMenuContainer();
            menu = mainMenu;
        }
    }
}
