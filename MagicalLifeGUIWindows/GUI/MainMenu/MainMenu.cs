namespace MagicalLifeGUIWindows.GUI.MainMenu
{
    /// <summary>
    /// Handles some main menu stuff.
    /// </summary>
    public static class MainMenu
    {
        private static MainMenuContainer MainMenuID;

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