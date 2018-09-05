namespace MagicalLifeGUIWindows.GUI.In
{
    public static class InGameEscapeMenu
    {
        public static InGameEscapeMenuContainer menu { get; private set; }

        internal static void Initialize()
        {
            InGameEscapeMenuContainer mainMenu = new InGameEscapeMenuContainer();
            menu = mainMenu;
            MenuHandler.DisplayMenu(menu);
        }
    }
}