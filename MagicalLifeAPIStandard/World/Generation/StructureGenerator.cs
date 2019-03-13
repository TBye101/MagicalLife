using MagicalLifeAPI.World.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeAPI.World.Generation
{
    /// <summary>
    /// Classes that implement this are responsible for generating structures within the given chunks.
    /// </summary>
    public abstract class StructureGenerator
    {
        /// <summary>
        /// Should generate structures in the received chunks.
        /// </summary>
        /// <param name="blankChunks"></param>
        /// <param name="biomeName">The name of the biome that is being worked with.</param>
        /// <returns></returns>
        public abstract Chunk[] GenerateStructures(Chunk[] blankChunks, string dimensionName, string biomeName);
    }
}
