using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.World.Data
{
    /// <summary>
    /// Used to remember when and how many times chunk has been accessed. 
    /// </summary>
    public class ChunkAccessRecorder
    {
        private Queue<DateTime> Accesses = new Queue<DateTime>();

        private int ChunkX;
        private int ChunkY;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="chunkX">The x position of the chunk within a dimension.</param>
        /// <param name="chunkY">The y position of the chunk within a dimension.</param>
        public ChunkAccessRecorder(int chunkX, int chunkY)
        {
            this.ChunkX = chunkX;
            this.ChunkY = chunkY;
        }

        /// <summary>
        /// Records that something has been accessed right now.
        /// </summary>
        public void Access()
        {
            this.Accesses.Enqueue(DateTime.Now);
        }

        /// <summary>
        /// Returns how many times the chunk has been accessed within a certain time frame.
        /// </summary>
        /// <returns></returns>
        public int GetAccessCount()
        {
            return this.Accesses.Count;
        }
    }
}
