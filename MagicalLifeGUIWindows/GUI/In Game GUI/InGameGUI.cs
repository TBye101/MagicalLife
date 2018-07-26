using MagicalLifeAPI.Entity.AI.Job;

namespace MagicalLifeGUIWindows.GUI.In_Game_GUI
{
    /// <summary>
    /// Holds the container which is the in game GUI.
    /// </summary>
    public static class InGameGUI
    {
        public static ActionSelected Selected = ActionSelected.None;

        public static InGameGUIContainer InGame;

        internal static void Initialize()
        {
            InGame = new InGameGUIContainer(true);
            MenuHandler.DisplayMenu(InGame);
        }
    }
}