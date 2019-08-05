using MLAPI.GameRegistry.WorldGeneration;
using MLAPI.Load;
using MLCoreMod.Core.WorldGeneration.Default;
using MLCoreMod.Core.WorldGeneration.Dungeon.Generation.HallwayGenerators;
using MLCoreMod.Core.WorldGeneration.TerrainGenerators;

namespace MLCoreMod.Core.Load
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