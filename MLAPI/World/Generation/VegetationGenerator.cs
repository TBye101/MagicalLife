using System;
using MLAPI.World.Data;

namespace MLAPI.World.Generation
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
        public abstract Chunk[] GenerateVegetation(Chunk[] chunks, string dimensionName, Random random);
    }
}