using MagicalLifeAPI.Universal;

namespace MagicalLifeAPI.World
{
    /// <summary>
    /// The world, which contains all of the tiles.
    /// </summary>
    public class World : Unique
    {
        /// <summary>
        /// A 3D array that holds every tile in the current world.
        /// </summary>
        public Tile[,,] Tiles { get; }

        /// <summary>
        /// Generates a new world with the specified height, width, depth, and world generator.
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <param name="depth"></param>
        /// <param name="generator"></param>
        public World(int height, int width, int depth, WorldGenerator generator)
        {
            this.Tiles = this.GenerateWorld(height, width, depth, generator);
        }

        /// <summary>
        /// Actually handles generating the world.
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <param name="depth"></param>
        /// <param name="generator"></param>
        /// <returns></returns>
        private Tile[,,] GenerateWorld(int height, int width, int depth, WorldGenerator generator)
        {
            string[,,] stage1 = generator.AssignBiomes(height, width, depth);
            Tile[,,] stage2 = generator.GenerateLandType(stage1);

            stage2 = generator.GenerateNaturalFeatures(stage2);
            stage2 = generator.GenerateMinerals(stage2);
            stage2 = generator.GenerateVegetation(stage2);
            stage2 = generator.GenerateDetails(stage2);

            return stage2;
        }
    }
}