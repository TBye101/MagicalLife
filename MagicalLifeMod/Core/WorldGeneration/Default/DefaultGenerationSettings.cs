using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeMod.Core.WorldGeneration.Default
{
    /// <summary>
    /// Settings for how the default world generator should behave.
    /// </summary>
    public class DefaultGenerationSettings
    {
        /// <summary>
        /// How spread out the weighted chances for each terrain generator is.
        /// </summary>
        public int TerrainVariationChance { get; set; } = 2;

        /// <summary>
        /// The stackable percent that neighboring chunks give towards using the same terrain generation.
        /// </summary>
        public int NeighborWeight { get; set; } = 12;

        #region TerrainSpecific

        public int DirtTerrainWeight { get; set; } = 1;
        public int GrassTerrainWeight { get; set; } = 15;

        #endregion
    }
}
