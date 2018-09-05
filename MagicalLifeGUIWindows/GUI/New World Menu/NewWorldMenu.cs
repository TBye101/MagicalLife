namespace MagicalLifeGUIWindows.GUI.New
{
    /// <summary>
    /// Holds a reference to the new world menu.
    /// </summary>
    public static class NewWorldMenu
    {
        public static NewWorldMenuContainer NewWorldMenuM;

        internal static void Initialize()
        {
            NewWorldMenuContainer mainMenu = new NewWorldMenuContainer(true);
            NewWorldMenuM = mainMenu;
        }
    }
}