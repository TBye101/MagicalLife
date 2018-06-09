using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeGUIWindows.Input;
using System.Collections.Generic;

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
            BoundHandler.Popup(container);
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
                BoundHandler.Popup(Containers[DisplayIndex]);
            }
        }

        /// <summary>
        /// Displays the menu displayed 1 step ahead of the currently displayed menu.
        /// </summary>
        public static void Forward()
        {
            if (DisplayIndex <= Containers.Count)
            {
                DisplayIndex++;
                BoundHandler.Popup(Containers[DisplayIndex]);
            }
        }

        /// <summary>
        /// Clears all menu steps previously stored.
        /// </summary>
        public static void Clear()
        {
            Containers.Clear();
        }
    }
}