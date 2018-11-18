using MagicalLifeGUIWindows.GUI.In;
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
            if (DisplayIndex > 0 && Containers[DisplayIndex].Child == null)
            {
                DisplayIndex--;
                BoundHandler.Popup(Containers[DisplayIndex]);
            }
            else
            {
                NullChild(BoundHandler.GUIWindows[DisplayIndex]);
            }
        }

        private static void NullChild(GUIContainer container)
        {
            if (container.Child == null)
            {
                BoundHandler.GUIWindows.Remove(container);
            }
            else
            {
                if (container.Child.Child == null)
                {
                    container.Child = null;
                }
                else
                {
                    NullChild(container.Child);
                }
            }
        }

        /// <summary>
        /// Clears all menu steps previously stored.
        /// </summary>
        public static void Clear()
        {
            if (InGameGUI.InGame == null)
            {
                BoundHandler.GUIWindows.Clear();
            }
            else
            {
                BoundHandler.GUIWindows.RemoveAll(x => x.GetType() != InGameGUI.InGame.GetType());
            }

            Containers.Clear();
        }
    }
}