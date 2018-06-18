using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Universal;
using ProtoBuf;
using System;
using System.Collections.Generic;

namespace MagicalLifeAPI.World.Data
{
    /// <summary>
    /// The world, which contains all of the tiles.
    /// </summary>
    [ProtoContract]
    public class World : Unique
    {
        /// <summary>
        /// The dimensions of a single world.
        /// Dimension 0 is the main world, where the players start.
        /// After that, anything goes.
        /// </summary>
        [ProtoMember(1)]
        public static List<Dimension> Dimensions { get; set; }

        public static WorldStorage Storage { get; set; } = new WorldStorage(Filing.FileSystemManager.GetIOSafeTime());

        /// <summary>
        /// Raised when the world is finished generating for the first time.
        /// </summary>
        public static event EventHandler<WorldEventArgs> WorldGenerated;

        public static World MainWorld { get; set; }

        public World()
        {
        }
        
        /// <summary>
        /// Returns the chunk at the specified chunk location.
        /// </summary>
        /// <param name="dimension"></param>
        /// <param name="chunkX"></param>
        /// <param name="chunkY"></param>
        /// <returns></returns>
        public static Chunk GetChunk(int dimension, int chunkX, int chunkY)
        {
            return World.Dimensions[dimension].GetChunk(chunkX, chunkY);
        }

        /// <summary>
        /// Returns the chunk at the specified tile location.
        /// </summary>
        /// <param name="dimension"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Chunk GetChunkByTile(int dimension, int x, int y)
        {
            return World.Dimensions[dimension].GetChunkForLocation(x, y);
        }

        /// <summary>
        /// Returns a tile in the specified dimension, at the specified location.
        /// </summary>
        /// <param name="dimension"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Tile GetTile(int dimension, int x, int y)
        {
            return World.Dimensions[dimension][x, y];
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
            MainWorld.Chunks = MainWorld.GenerateWorld(height, width, generator);

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