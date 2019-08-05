namespace MLGUIWindows.GUI.Save_Game_Menu
{
    public static class SaveGameMenu
    {
        public static SaveGameMenuContainer Menu { get; private set; }

        internal static void Initialize()
        {
            Menu = new SaveGameMenuContainer();
        }
    }
}