using System.Collections.Generic;
using MonoGUI.MonoGUI.Input;
using MonoGUI.MonoGUI.Reusable;

namespace MonoGUI.MonoGUI
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
        private static List<GuiContainer> Containers = new List<GuiContainer>();

        /// <summary>
        /// Displays the menu/popup.
        ///         <paramref name="ignore"/>A container to not clear when popping up a new one, such as the in game escape menu.<paramref name="ignore"/>
        /// </summary>
        /// <param name="container"></param>
        public static void DisplayMenu(GuiContainer container)
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

        private static void NullChild(GuiContainer container)
        {
            if (container.Child == null)
            {
                if (DisplayIndex > 0)
                {
                    BoundHandler.GUIWindows.Remove(container);
                }
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
        /// <paramref name="ignore"/>A container to not clear, such as the in game GUI.<paramref name="ignore"/>
        /// </summary>
        public static void Clear()
        {
            BoundHandler.GUIWindows.RemoveAll(x => !x.IsHUD);
            Containers.Clear();
        }
    }
}