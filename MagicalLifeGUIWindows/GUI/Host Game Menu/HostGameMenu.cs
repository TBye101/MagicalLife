namespace MagicalLifeGUIWindows.GUI.Host_Game_Menu
{
    /// <summary>
    /// Holds a reference to the host game menu.
    /// </summary>
    public static class HostGameMenu
    {
        public static HostGameMenuContainer menu;

        internal static void Initialize()
        {
            HostGameMenuContainer mainMenu = new HostGameMenuContainer();
            menu = mainMenu;
            MenuHandler.DisplayMenu(menu);
        }
    }
}