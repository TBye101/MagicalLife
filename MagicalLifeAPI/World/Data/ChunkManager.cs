using MagicalLifeAPI.DataTypes;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.World.Data
{
    /// <summary>
    /// Manages what chunks are loaded and cached from a given list of chunks.
    /// </summary>
    [ProtoContract]
    public sealed class ChunkManager
    {
        /// <summary>
        /// A 2D array that holds every chunk in the dimension that this chunk manager services.
        /// </summary>
        [ProtoMember(1)]
        private ProtoArray<Chunk> Chunks { get; set; }

        /// <summary>
        /// The ID of the dimension that this chunk manager services.
        /// </summary>
        [ProtoMember(2)]
        private Guid DimensionID;

        public ChunkManager(Guid dimensionID)
        {
            this.DimensionID = dimensionID;
        }

        public ChunkManager()
        {

        }

        /// <summary>
        /// Returns the chunk for which the specified point belongs to.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Chunk GetChunkForLocation(int x, int y)
        {

        }

        public Tile this[int x, int y]
        {
            get
            {
                int chunkX = x / Chunk.Width;
                int chunkY = y / Chunk.Height;

                Chunk chunk = this.FetchChunk(x, y);

                int xInChunk = x % Chunk.Width;
                int yInChunk = y % Chunk.Height;

                return chunk.Tiles[xInChunk, yInChunk];
            }
            set
            {
                int chunkX = x / Chunk.Width;
                int chunkY = y / Chunk.Height;

                Chunk chunk = this.FetchChunk(x, y);

                int xInChunk = x % Chunk.Width;
                int yInChunk = y % Chunk.Height;
                chunk.Tiles[xInChunk, yInChunk] = value;
            }
        }

        /// <summary>
        /// Returns a chunk
        /// </summary>
        /// <returns></returns>
        private Chunk FetchChunk(int x, int y)
        {

        }

        /// <summary>
        /// Loads a chunk from disk.
        /// </summary>
        /// <returns></returns>
        private Chunk LoadChunk()
        {

        }

        /// <summary>
        /// Saves a chunk to disk.
        /// </summary>
        private void SaveChunk()
        {

        }
    }
}
