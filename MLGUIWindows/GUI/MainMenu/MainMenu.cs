namespace MagicalLifeGUIWindows.GUI.MainMenu
{
    /// <summary>
    /// Handles some main menu stuff.
    /// </summary>
    public static class MainMenu
    {
        public static MainMenuContainer MainMenuID { get; private set; }

        internal static void Initialize()
        {
            MainMenuContainer mainMenu = new MainMenuContainer(true);
            MainMenuID = mainMenu;
            MenuHandler.DisplayMenu(MainMenuID);
        }

        internal static void ToggleMainMenu()
        {
            MenuHandler.DisplayMenu(MainMenuID);
        }
    }
}