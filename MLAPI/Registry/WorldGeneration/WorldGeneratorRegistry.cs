using MagicalLifeAPI.World;
using MagicalLifeAPI.World.Generation;
using MagicalLifeAPI.World.Generation.Dungeon;
using System.Collections.Generic;

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
        public static List<DimensionGenerator> Generators { get; } = new List<DimensionGenerator>();

        /// <summary>
        /// All known dungeon generators are stored in this list. 
        /// </summary>
        public static List<DungeonGenerator> DungeonGenerators { get; } = new List<DungeonGenerator>();

        /// <summary>
        /// All known terrain generators are to be stored in this list.
        /// </summary>
        public static List<TerrainGenerator> TerrainGenerators { get; } = new List<TerrainGenerator>();

        /// <summary>
        /// All known vegetation generators are to be stored in this list.
        /// </summary>
        public static List<VegetationGenerator> VegetationGenerators { get; } = new List<VegetationGenerator>();

        /// <summary>
        /// All known structure generators are to be stored in this list.
        /// </summary>
        public static List<StructureGenerator> StructureGenerators { get; } = new List<StructureGenerator>();

        /// <summary>
        /// All known creature generators are to be stored in this list.
        /// </summary>
        public static List<CreatureGenerator> CreatureGenerators { get; } = new List<CreatureGenerator>();

        /// <summary>
        /// All known hallway generators are to be stored in this list.
        /// </summary>
        public static List<HallwayGenerator> HallwayGenerators { get; } = new List<HallwayGenerator>();

        /// <summary>
        /// All known room decorators are to be stored in this list.
        /// </summary>
        public static List<RoomDecorationGenerator> RoomDecorators { get; } = new List<RoomDecorationGenerator>();

        /// <summary>
        /// All known room generators are to be stored in this list.
        /// </summary>
        public static List<RoomGenerator> RoomGenerators { get; set; } = new List<RoomGenerator>();
    }
}