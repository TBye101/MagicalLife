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
        /// The int is the dimension ID aka where it can be found within <see cref="Dimensions"/>.
        /// </summary>
        public static event EventHandler<int> DimensionGenerated;

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
        /// <param name="chunkWidth"></param>
        /// <param name="chunkHeight"></param>
        /// <param name="depth"></param>
        /// <param name="generator"></param>
        public static void Initialize(int chunkWidth, int chunkHeight, DimensionGenerator generator)
        {
            Random r = new Random();
            Dimension zero = new Dimension("First Reality", generator.GenerateWorld(chunkWidth, chunkHeight, r));
            World.Dimensions.Add(zero);
            World.DimensionGeneratedHandler(World.Dimensions.Count - 1);
        }

        /// <summary>
        /// Raises the world generated event.
        /// </summary>
        /// <param name="e"></param>
        public static void DimensionGeneratedHandler(int e)
        {
            EventHandler<int> handler = DimensionGenerated;
            if (handler != null)
            {
                handler(null, e);
            }
        }
    }
}