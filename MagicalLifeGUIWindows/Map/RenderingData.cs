using MagicalLifeAPI.World;
using MagicalLifeAPI.World.Base;

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
        /// Returns an ever increasing number for pop-up window priorities.
        /// </summary>
        /// <returns></returns>
        public static int GetGUIContainerPriority()
        {
            CurrentPriority += 1;
            return CurrentPriority;
        }

        static RenderingData()
        {
            Tile.TileCreated += Tile_TileCreated;
        }

        private static void Tile_TileCreated(object sender, TileEventArg e)
        {
        }

        /// <summary>
        /// The z axis level that is currently being displayed on screen.
        /// </summary>
        public static int ZLevel { get; set; } = 0;
    }
}