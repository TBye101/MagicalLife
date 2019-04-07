using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.GUI.Action_Menu
{
    /// <summary>
    /// The action menu on the right side of the screen, when the correct key is pressed.
    /// </summary>
    public static class ActionMenu
    {
        public static ActionMenuContainer AMenu;

        internal static void Initialize()
        {
            AMenu = new ActionMenuContainer(true);
            MenuHandler.DisplayMenu(AMenu);
        }
    }
}
