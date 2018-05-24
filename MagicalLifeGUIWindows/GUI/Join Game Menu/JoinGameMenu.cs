namespace MagicalLifeGUIWindows.GUI.Join_Game_Menu
{
    /// <summary>
    /// Holds a reference to the join game menu.
    /// </summary>
    public static class JoinGameMenu
    {
        public static JoinGameMenuContainer menu;

        internal static void Initialize()
        {
            JoinGameMenuContainer mainMenu = new JoinGameMenuContainer();
            menu = mainMenu;
            MenuHandler.DisplayMenu(menu);
        }
    }
}