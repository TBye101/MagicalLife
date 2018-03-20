using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.GUI.In_Game_GUI
{
    /// <summary>
    /// Holds the container which is the in game GUI.
    /// </summary>
    public static class InGameGUI
    {
        public static InGameGUIContainer InGame;

        internal static void Initialize()
        {
            InGame = new InGameGUIContainer(true);
            MenuHandler.DisplayMenu(InGame);
        }
    }
}
