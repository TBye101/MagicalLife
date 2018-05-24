using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Universal;
using ProtoBuf;
using System;

namespace MagicalLifeAPI.World
{
    /// <summary>
    /// The world, which contains all of the tiles.
    /// </summary>
    [ProtoContract]
    public class World : Unique
    {
        /// <summary>
        /// A 3D array that holds every tile in the current world.
        /// </summary>
        [ProtoMember(1)]
        public ProtoArray<Tile> Tiles { get; set; }

        /// <summary>
        /// Raised when the world is finished generating for the first time.
        /// </summary>
        public static event EventHandler<WorldEventArgs> WorldGenerated;

        public static World MainWorld { get; set; }

        /// <summary>
        /// If true, it is the player's turn. If not, AI logic and other logic should be running.
        /// </summary>
        [ProtoMember(2)]
        public static bool IsPlayersTurn { get; private set; } = false;

        public World()
        {
        }

        /// <summary>
        /// Generates a new world with the specified height, width, depth, and world generator.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="depth"></param>
        /// <param name="generator"></param>
        public static void Initialize(int width, int height, WorldGenerator generator)
        {
            MainWorld = new World();
            MainWorld.Tiles = MainWorld.GenerateWorld(height, width, generator);

            WorldEventArgs worldEventArgs = new WorldEventArgs(MainWorld);
            World.WorldGeneratedHandler(worldEventArgs);
        }

        /// <summary>
        /// Actually handles generating the world.
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <param name="depth"></param>
        /// <param name="generator"></param>
        /// <returns></returns>
        private ProtoArray<Tile> GenerateWorld(int height, int width, WorldGenerator generator)
        {
            Random r = new Random();
            string[,] stage1 = generator.AssignBiomes(height, width, r);
            ProtoArray<Tile> stage2 = generator.GenerateLandType(stage1, r);

            stage2 = generator.GenerateNaturalFeatures(stage2, r);
            stage2 = generator.GenerateMinerals(stage2, r);
            stage2 = generator.GenerateVegetation(stage2, r);
            stage2 = generator.GenerateDetails(stage2, r);

            return stage2;
        }

        /// <summary>
        /// Raises the world generated event.
        /// </summary>
        /// <param name="e"></param>
        public static void WorldGeneratedHandler(WorldEventArgs e)
        {
            EventHandler<WorldEventArgs> handler = WorldGenerated;
            if (handler != null)
            {
                handler(World.MainWorld, e);
            }
        }
    }
}