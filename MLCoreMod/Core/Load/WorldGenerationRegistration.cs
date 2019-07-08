using MagicalLifeAPI.Load;
using MagicalLifeAPI.Registry.WorldGeneration;
using MagicalLifeMod.Core.WorldGeneration;
using MagicalLifeMod.Core.WorldGeneration.Default;
using MagicalLifeMod.Core.WorldGeneration.HallwayGenerators;
using MagicalLifeMod.Core.WorldGeneration.TerrainGenerators;

namespace MagicalLifeMod.Core.Load
{
    /// <summary>
    /// Registers all world generators with the world registry.
    /// </summary>
    public class WorldGenerationRegistration : IGameLoader
    {
        public void InitialStartup()
        {
            WorldGeneratorRegistry.Generators.Add(new GenerationAllocator());
            WorldGeneratorRegistry.TerrainGenerators.Add(new DirtTerrain(-1));
            WorldGeneratorRegistry.TerrainGenerators.Add(new GrassTerrain(-1));
            WorldGeneratorRegistry.HallwayGenerators.Add(new CircularHallwayGenerator());
            WorldGeneratorRegistry.DungeonGenerators.Add(new DefaultDungeonGenerator());
        }
    }
}