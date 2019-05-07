namespace MagicalLifeGUIWindows.GUI.Settings_Menu
{
    public static class SettingsGameMenu
    {
        public static SettingsGameMenuContainer Menu { get; private set; }

        /// <summary>
        /// Initializes the specified from main menu.
        /// </summary>
        /// <param name="fromMainMenu">if set to <c>true</c> [from main menu], it will route us to the main menu. Otherwise let us resume the game.</param>
        internal static void Initialize(bool fromMainMenu)
        {
            SettingsGameMenuContainer settingsMenu = new SettingsGameMenuContainer(fromMainMenu);
            Menu = settingsMenu;
        }
    }
}