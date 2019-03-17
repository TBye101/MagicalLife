using MagicalLifeAPI.World;
using MagicalLifeAPI.World.Generation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeAPI.Registry.WorldGeneration
{
    /// <summary>
    /// Holds all of the world generators.
    /// </summary>
    public static class WorldGeneratorRegistry
    {
        /// <summary>
        /// All known dimension generators are stored in this list.
        /// </summary>
        public static List<DimensionGenerator> Generators = new List<DimensionGenerator>();

        /// <summary>
        /// All known terrain generators are to be stored in this list.
        /// </summary>
        public static List<TerrainGenerator> TerrainGenerators = new List<TerrainGenerator>();

        /// <summary>
        /// All known vegetation generators are to be stored in this list.
        /// </summary>
        public static List<VegetationGenerator> VegetationGenerators = new List<VegetationGenerator>();

        /// <summary>
        /// All known structure generators are to be stored in this list.
        /// </summary>
        public static List<StructureGenerator> StructureGenerators = new List<StructureGenerator>();
    }
}
