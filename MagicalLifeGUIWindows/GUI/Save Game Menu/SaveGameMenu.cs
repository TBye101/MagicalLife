namespace MagicalLifeGUIWindows.GUI.Save_Game_Menu
{
    public static class SaveGameMenu
    {
        public static SaveGameMenuContainer menu { get; private set; }

        internal static void Initialize()
        {
            SaveGameMenuContainer mainMenu = new SaveGameMenuContainer();
            menu = mainMenu;
        }
    }
}