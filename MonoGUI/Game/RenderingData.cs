using MagicalLifeAPI.Entity.AI.Task;
using MagicalLifeAPI.World;
using MagicalLifeAPI.World.Base;
using Microsoft.Xna.Framework.Content;

namespace MagicalLifeGUIWindows.Map
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
        public static ActionSelected CurrentlySelected = ActionSelected.None;

        /// <summary>
        /// A gift from Game1.cs in the GUI project. Allows us to load data.
        /// </summary>
        public static ContentManager AssetManagerClone;

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