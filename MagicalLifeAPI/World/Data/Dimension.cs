using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Universal;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.World.Data
{
    /// <summary>
    /// Holds some information about the level of the world.
    /// Could be a dungeon, the starting point, or some other thing.
    /// </summary>
    [ProtoContract]
    public class Dimension : Unique
    {

        /// <summary>
        /// Handles access to the chunks stored in this dimension.
        /// </summary>
        [ProtoMember(1)]
        private ChunkManager Manager;

        /// <summary>
        /// The display name of the dimension.
        /// </summary>
        [ProtoMember(2)]
        public string DimensionName { get; set; }

        public Tile this[int x, int y]
        {
            get
            {
                return this.Manager[x, y];
            }
            set
            {
                this.Manager[x, y] = value;
            }
        }

        public Dimension(string dimensionName)
        {
            this.Manager = new ChunkManager(this.ID);
            this.DimensionName = dimensionName;
            World.Storage.PrepareForDimension(this.ID);
        }

        public Dimension()
        {

        }

        public Chunk GetChunkForLocation(int x, int y)
        {
            return this.Manager.GetChunkForLocation(x, y);
        }

        /// <summary>
        /// Returns a chunk that correspondences with the specified chunk coordinate.
        /// </summary>
        /// <param name="chunkX"></param>
        /// <param name="chunkY"></param>
        /// <returns></returns>
        public Chunk GetChunk(int chunkX, int chunkY)
        {
            return this.Manager.GetChunk(chunkX, chunkY);
        }
    }
}
