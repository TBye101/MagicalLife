using Microsoft.Xna.Framework.Content;
using MLAPI.Entity.AI.Task;

namespace MonoGUI.Game
{
    /// <summary>
    /// Holds rendering information about the map, as well as a few utilities.
    /// </summary>
    public static class RenderingData
    {
        /// <summary>
        /// The value of the last assigned priority to a GUI pop-up.
        /// </summary>
        private static int CurrentPriority = int.MinValue;

        /// <summary>
        /// The currently selected action in the game.
        /// </summary>
        public static ActionSelected CurrentlySelected { get; set; } = ActionSelected.None;

        /// <summary>
        /// A gift from Game1.cs in the GUI project. Allows us to load data.
        /// </summary>
        public static ContentManager AssetManagerClone { get; set; }

        /// <summary>
        /// Returns an ever increasing number for pop-up window priorities.
        /// </summary>
        /// <returns></returns>
        public static int GetGUIContainerPriority()
        {
            CurrentPriority += 1;
            return CurrentPriority;
        }
    }
}