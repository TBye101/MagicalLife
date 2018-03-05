using MagicalLifeRenderEngine.Main.GUI.Click;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.GUI.New_World_Menu
{
    /// <summary>
    /// Holds a reference to the new world menu.
    /// </summary>
    public static class NewWorldMenu
    {
        private static NewWorldMenuContainer NewWorldMenuM;

        internal static void Initialize()
        {
            NewWorldMenuContainer mainMenu = new NewWorldMenuContainer(true);
            NewWorldMenuM = mainMenu;
            MouseHandler.AddContainer(mainMenu);
        }
    }
}
