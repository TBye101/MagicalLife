using System;
using System.Collections.Generic;
using System.Text;

namespace MLCoreMod.Core.Settings
{
    /// <summary>
    /// Holds some settings for dungeon generation.
    /// </summary>
    public class DungeonGenConfig
    {
        #region CircularHallwayGeneration

        /// <summary>
        /// The minimum number of circular hallways to generate.
        /// </summary>
        public int MinCircleHallways { get; set; } = 1;

        /// <summary>
        /// The maximum number of circular hallways to generate.
        /// </summary>
        public int MaxCircleHallways { get; set; } = 2;

        /// <summary>
        /// The minimum size of the circular hallway to generate.
        /// </summary>
        public int MinCircleThickness { get; set; } = 2;

        /// <summary>
        /// The maximum size of the circular hallway to generate. 
        /// </summary>
        public int MaxCircleThickness { get; set; } = 8;

        #endregion
    }
}
