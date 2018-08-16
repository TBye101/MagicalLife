using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.World.Base;
using MagicalLifeAPI.World.Data.Disk;
using ProtoBuf;
using System;
using System.Collections.Generic;

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
        //[ProtoMember(1)]
        private ProtoArray<ChunkAccess> Chunks { get; set; }

        /// <summary>
        /// The ID of the dimension that this chunk manager services.
        /// </summary>
        //[ProtoMember(2)]
        private Guid DimensionID;

        /// <summary>
        /// The width of this dimension in chunks.
        /// </summary>
        //[ProtoMember(3)]
        public int Width { get; set; }

        /// <summary>
        /// The height of the dimension in chunks.
        /// </summary>
        //[ProtoMember(4)]
        public int Height { get; set; }

        public ChunkManager(Guid dimensionID, ProtoArray<Chunk> chunks)
        {
            this.DimensionID = dimensionID;
            this.Width = chunks.Width;
            this.Height = chunks.Height;

            List<ChunkAccess> temp = new List<ChunkAccess>();

            int xLength = chunks.Width;
            int yLength = chunks.Height;

            for (int x = 0; x < xLength; x++)
            {
                for (int y = 0; y < yLength; y++)
                {
                    temp.Add(new ChunkAccess(chunks[x, y], new ChunkAccessRecorder(x, y)));
                }
            }

            this.Chunks = new ProtoArray<ChunkAccess>(chunks.Width, chunks.Height, temp.ToArray());
        }

        public ChunkManager()
        {
        }

        /// <summary>
        /// Returns the chunk for which the specified tile Point2D belongs to.
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
                return WorldStorage.ChunkStorage.LoadChunk(chunkX, chunkY, this.DimensionID);
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
            bool chunkExist = chunkX < this.Chunks.Width && chunkY < this.Chunks.Height;
            bool tileExist = x > -1 && y > -1;
            return chunkExist && tileExist;
        }

        public IEnumerator<Tile> GetEnumerator()
        {
            for (int x = 0; x < this.Width; x++)
            {
                for (int y = 0; y < this.Height; y++)
                {
                    ChunkAccess item = this.Chunks[x, y];

                    if (item.Chunk == null)
                    {
                        this.Chunks[x, y].Chunk = this.FetchChunk(x, y);
                    }

                    foreach (Tile item2 in item.Chunk)
                    {
                        yield return item2;
                    }
                }
            }
        }
    }
}