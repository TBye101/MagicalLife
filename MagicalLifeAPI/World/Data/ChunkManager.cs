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
        private ProtoArray<Tuple<Chunk, ChunkAccessRecorder>> Chunks { get; set; }

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
            int chunkX = x / Chunk.Width;
            int chunkY = y / Chunk.Height;

            return this.FetchChunk(x, y);
        }

        public Tile this[int x, int y]
        {
            get
            {
                Chunk chunk = this.GetChunkForLocation(x, y);

                int xInChunk = x % Chunk.Width;
                int yInChunk = y % Chunk.Height;

                return chunk.Tiles[xInChunk, yInChunk];
            }
            set
            {
                Chunk chunk = this.GetChunkForLocation(x, y);

                int xInChunk = x % Chunk.Width;
                int yInChunk = y % Chunk.Height;
                chunk.Tiles[xInChunk, yInChunk] = value;
            }
        }

        /// <summary>
        /// Returns a chunk
        /// </summary>
        /// <returns></returns>
        private Chunk FetchChunk(int chunkX, int chunkY)
        {
            Tuple<Chunk, ChunkAccessRecorder> storage = this.Chunks[chunkX, chunkY];
            storage.Item2.Access();

            if (storage.Item1 == null)
            {
                return this.LoadChunk(chunkX, chunkY);
            }
            else
            {
                return storage.Item1;
            }
        }

        /// <summary>
        /// Loads a chunk from disk.
        /// </summary>
        /// <returns></returns>
        private Chunk LoadChunk(int chunkX, int chunkY)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Saves a chunk to disk.
        /// </summary>
        private void SaveChunk()
        {
            throw new NotImplementedException();
        }
    }
}
