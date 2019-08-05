using MonoGUI.MonoGUI;

namespace MLGUIWindows.GUI.MainMenu
{
    /// <summary>
    /// Handles some main menu stuff.
    /// </summary>
    public static class MainMenu
    {
        public static MainMenuContainer MainMenuId { get; private set; }

        internal static void Initialize()
        {
            MainMenuContainer mainMenu = new MainMenuContainer(true);
            MainMenuId = mainMenu;
            MenuHandler.DisplayMenu(MainMenuId);
        }

        internal static void ToggleMainMenu()
        {
            MenuHandler.DisplayMenu(MainMenuId);
        }
    }
}