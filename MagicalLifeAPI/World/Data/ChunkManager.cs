using MagicalLifeAPI.DataTypes;
using ProtoBuf;
using System;
using System.Collections;
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
    public sealed class ChunkManager : IEnumerable<Tile>
    {
        /// <summary>
        /// A 2D array that holds every chunk in the dimension that this chunk manager services.
        /// </summary>
        [ProtoMember(1)]
        private ProtoArray<ChunkAccess> Chunks { get; set; }

        /// <summary>
        /// The ID of the dimension that this chunk manager services.
        /// </summary>
        [ProtoMember(2)]
        private Guid DimensionID;

        /// <summary>
        /// The width of this dimension in chunks.
        /// </summary>
        [ProtoMember(3)]
        public int Width { get; set; }

        /// <summary>
        /// The height of the dimension in chunks.
        /// </summary>
        [ProtoMember(4)]
        public int Height { get; set; }

        public ChunkManager(Guid dimensionID, ProtoArray<Chunk> chunks)
        {
            this.DimensionID = dimensionID;
            this.Width = chunks.Width;
            this.Height = chunks.Height;

            List<ChunkAccess> temp = new List<ChunkAccess>();

            foreach (Chunk item in chunks)
            {
                temp.Add(new ChunkAccess(item, new ChunkAccessRecorder(item.ChunkLocation.X, item.ChunkLocation.Y)));
            }

            this.Chunks = new ProtoArray<ChunkAccess>(chunks.Width, chunks.Height, temp.ToArray());
        }

        public ChunkManager()
        {

        }

        /// <summary>
        /// Returns the chunk for which the specified tile point belongs to.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Chunk GetChunkForLocation(int x, int y)
        {
            int chunkX = x / Chunk.Width;
            int chunkY = y / Chunk.Height;

            return this.FetchChunk(chunkX, chunkY);
        }

        /// <summary>
        /// Returns a chunk that correspondences with the specified chunk coordinate.
        /// </summary>
        /// <param name="chunkX"></param>
        /// <param name="chunkY"></param>
        /// <returns></returns>
        public Chunk GetChunk(int chunkX, int chunkY)
        {
            return this.FetchChunk(chunkX, chunkY);
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
            ChunkAccess storage = this.Chunks[chunkX, chunkY];
            storage.Recorder.Access();

            if (storage.Chunk == null)
            {
                return World.Storage.LoadChunk(chunkX, chunkY, this.DimensionID);
            }
            else
            {
                return storage.Chunk;
            }
        }

        /// <summary>
        /// Determines if the specified tile exists, without loading the tile or chunk.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool DoesTileExist(int x, int y)
        {
            int chunkX = x / Chunk.Width;
            int chunkY = y / Chunk.Height;

            return chunkX < this.Chunks.Width && chunkY < this.Chunks.Height;
        }

        public IEnumerator<Tile> GetEnumerator()
        {
            foreach (ChunkAccess item in this.Chunks)
            {
                foreach (Tile item2 in item.Chunk)
                {
                    yield return item2;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
