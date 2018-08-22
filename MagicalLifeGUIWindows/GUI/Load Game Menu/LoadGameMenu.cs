namespace MagicalLifeGUIWindows.GUI.Load_Game_Menu
{
    public static class LoadGameMenu
    {
        public static LoadGameMenuContainer Menu { get; private set; }

        internal static void Initialize()
        {
            LoadGameMenuContainer mainMenu = new LoadGameMenuContainer();
            Menu = mainMenu;
        }
    }
}