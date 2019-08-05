using MonoGUI.MonoGUI;

namespace MLGUIWindows.GUI.In_Game_Escape_Menu
{
    public static class InGameEscapeMenu
    {
        public static InGameEscapeMenuContainer Menu { get; private set; }

        internal static void Initialize()
        {
            InGameEscapeMenuContainer mainMenu = new InGameEscapeMenuContainer();
            Menu = mainMenu;
            MenuHandler.DisplayMenu(Menu);
        }
    }
}