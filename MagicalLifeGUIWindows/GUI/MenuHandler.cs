using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeRenderEngine.Main.GUI.Click;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.GUI
{
    /// <summary>
    /// Handles transitioning between menus.
    /// </summary>
    public static class MenuHandler
    {
        private static int DisplayIndex = -1;

        /// <summary>
        /// The menus that we are currently handling.
        /// Containers[0] is the very first menu showed
        /// Containers[x] is the latest menu showed.
        /// </summary>
        private static List<GUIContainer> Containers = new List<GUIContainer>();

        /// <summary>
        /// Displays the menu/popup.
        /// </summary>
        /// <param name="container"></param>
        public static void DisplayMenu(GUIContainer container)
        {
            MouseHandler.Popup(container);
            Containers.Add(container);
            DisplayIndex = Containers.Count - 1;
        }

        /// <summary>
        /// Displays the last shown menu.
        /// </summary>
        public static void Back()
        {
            if (DisplayIndex > 0)
            {
                DisplayIndex--;
                MouseHandler.Popup(Containers[DisplayIndex]);
            }
        }

        public static void Forward()
        {
            if (DisplayIndex <= Containers.Count)
            {
                DisplayIndex++;
                MouseHandler.Popup(Containers[DisplayIndex]);
            }
        }
    }
}
