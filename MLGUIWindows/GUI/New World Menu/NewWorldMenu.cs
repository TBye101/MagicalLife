namespace MLGUIWindows.GUI.New_World_Menu
{
    /// <summary>
    /// Holds a reference to the new world menu.
    /// </summary>
    public static class NewWorldMenu
    {
        public static NewWorldMenuContainer NewWorldMenuM;

        internal static void Initialize()
        {
            NewWorldMenuM = new NewWorldMenuContainer(true);
        }
    }
}