namespace MagicalLifeGUIWindows.GUI.Action_Menu
{
    /// <summary>
    /// The action menu on the right side of the screen, when the correct key is pressed.
    /// </summary>
    public static class ActionMenu
    {
        public static ActionMenuContainer AMenu { get; } = new ActionMenuContainer(true);

        internal static void Initialize()
        {
            MenuHandler.DisplayMenu(AMenu);
        }
    }
}