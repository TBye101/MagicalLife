namespace MagicalLifeGUIWindows.GUI.Join
{
    /// <summary>
    /// Holds a reference to the join game menu.
    /// </summary>
    public static class JoinGameMenu
    {
        public static JoinGameMenuContainer Menu { get; set; }

        internal static void Initialize()
        {
            JoinGameMenuContainer mainMenu = new JoinGameMenuContainer();
            Menu = mainMenu;
        }
    }
}