namespace MagicalLifeGUIWindows.GUI.Load
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