using MagicalLifeAPI.World.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeAPI.World.Generation
{
    /// <summary>
    /// Classes that implements this are responsible for generating the vegetation for the specified chunks.
    /// </summary>
    public abstract class VegetationGenerator
    {
        /// <summary>
        /// Should decorate the received chunks with vegetation.
        /// </summary>
        /// <param name="blankChunks"></param>
        /// <param name="biomeName">The name of the biome that is being worked with.</param>
        /// <returns></returns>
        public abstract Chunk[] GenerateVegetation(Chunk[] blankChunks, string dimensionName, string biomeName);
    }
}
