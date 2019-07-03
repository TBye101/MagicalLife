using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Registry.ItemRegistry;
using MagicalLifeAPI.World.Base;
using System;
using System.Collections.Generic;

namespace MagicalLifeAPI.World.Data
{
    /// <summary>
    /// Holds some information about the level of the world.
    /// </summary>
    public class Dimension
    {
        /// <summary>
        /// Handles access to the chunks stored in this dimension.
        /// </summary>
        private readonly ChunkManager ChunkManage;

        /// <summary>
        /// Handles access to the structures stored in this dimension.
        /// </summary>
        internal readonly StructureManager StructureManage;

        /// <summary>
        /// The display name of the dimension.
        /// </summary>
        public string DimensionName { get; set; }

        public Guid ID { get; }

        public ItemRegistry Items { get; set; }

        /// <summary>
        /// The width of this dimension in chunks.
        /// </summary>
        public int Width
        {
            get
            {
                return this.ChunkManage.Width;
            }
        }

        /// <summary>
        /// The height of this dimension in chunks.
        /// </summary>
        public int Height
        {
            get
            {
                return this.ChunkManage.Height;
            }
        }

        public Tile this[int x, int y]
        {
            get
            {
                return this.ChunkManage[x, y];
            }
            set
            {
                this.ChunkManage[x, y] = value;
            }
        }

        /// <summary>
        /// This constructor creates a new dimension.
        /// </summary>
        /// <param name="dimensionName"></param>
        /// <param name="chunks"></param>
        public Dimension(string dimensionName, ProtoArray<Chunk> chunks, Guid dimensionID)
        {
            this.ChunkManage = new ChunkManager(this.ID, chunks);
            this.DimensionName = dimensionName;
            this.ID = dimensionID;
            this.StructureManage = new StructureManager(this.ID);//Depends on the dimension ID to be initialized first.
            this.Items = new ItemRegistry(World.AddDimension(this));
        }

        /// <summary>
        /// This constructor is for creating a dimension identical to a dimension loaded from disk/network.
        /// </summary>
        /// <param name="dimensionName"></param>
        /// <param name="chunks"></param>
        /// <param name="id"></param>
        /// <param name="registry"></param>
        public Dimension(string dimensionName, ProtoArray<Chunk> chunks, Guid id, ItemRegistry registry)
        {
            this.ID = id;
            this.ChunkManage = new ChunkManager(id, chunks);
            this.DimensionName = dimensionName;

            int dimensionID = World.AddDimension(this);

            //Anything that needs a dimensionID
            this.Items = registry;
        }

        public Chunk GetChunkForLocation(int x, int y)
        {
            return this.ChunkManage.GetChunkForLocation(x, y);
        }

        /// <summary>
        /// Returns a chunk that correspondences with the specified chunk coordinate.
        /// </summary>
        /// <param name="chunkX"></param>
        /// <param name="chunkY"></param>
        /// <returns></returns>
        public Chunk GetChunk(int chunkX, int chunkY)
        {
            return this.ChunkManage.GetChunk(chunkX, chunkY);
        }

        /// <summary>
        /// Determines if the specified tile exists, without loading the tile.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool DoesTileExist(int x, int y)
        {
            return this.ChunkManage.DoesTileExist(x, y);
        }

        public IEnumerator<Tile> GetEnumerator()
        {
            foreach (Tile item in this.ChunkManage)
            {
                yield return item;
            }
        }
    }
}