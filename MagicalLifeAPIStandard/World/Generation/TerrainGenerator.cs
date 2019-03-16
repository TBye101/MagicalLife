using MagicalLifeAPI.World.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeAPI.World
{
    /// <summary>
    /// Classes that implements this are responsible for generating the terrain for the specified chunks.
    /// </summary>
    public abstract class TerrainGenerator
    {
        /// <summary>
        /// The likelihood of this terrain generator being used when the default biome allocator is utilized.
        /// </summary>
        public int Weight { get; set; }

        /// <param name="weight">The likelihood of this terrain generator being used when the default biome allocator is utilized.</param>
        public TerrainGenerator(int weight)
        {
            this.Weight = weight;
        }

        /// <summary>
        /// Should generate the received blank chunks, and return chunks with fully generated terrain.
        /// </summary>
        /// <param name="blankChunks"></param>
        /// <param name="biomeName">The name of the biome that is being worked with.</param>
        /// <returns></returns>
        public abstract Chunk[] GenerateTerrain(Chunk[] blankChunks, string dimensionName, Random random);
    }
}
