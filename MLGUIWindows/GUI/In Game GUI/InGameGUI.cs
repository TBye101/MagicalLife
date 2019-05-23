using MagicalLifeAPI.Entity.AI.Task;
using MagicalLifeGUIWindows.Map;

namespace MagicalLifeGUIWindows.GUI.In
{
    /// <summary>
    /// Holds the container which is the in game GUI.
    /// </summary>
    public static class InGameGUI
    {
        public static ActionSelected Selected
        {
            get
            {
                return RenderingData.CurrentlySelected;
            }
            set
            {
                RenderingData.CurrentlySelected = value;
            }
        }

        public static InGameGUIContainer InGame;

        internal static void Initialize()
        {
            InGame = new InGameGUIContainer(true);
            MenuHandler.DisplayMenu(InGame);
            Selected = ActionSelected.None;
        }
    }
}