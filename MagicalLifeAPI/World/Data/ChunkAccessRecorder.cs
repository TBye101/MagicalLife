using ProtoBuf;
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
    [ProtoContract]
    public class ChunkAccessRecorder
    {
        [ProtoMember(1)]
        private Queue<DateTime> Accesses = new Queue<DateTime>();

        [ProtoMember(2)]
        private int ChunkX;

        [ProtoMember(3)]
        private int ChunkY;

        /// <summary>
        /// The time until a access is no longer counted in calculating how many times a chunk has been accessed. 
        /// </summary>
        [ProtoMember(4)]
        private int MilliSecondTimeout;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="chunkX">The x position of the chunk within a dimension.</param>
        /// <param name="chunkY">The y position of the chunk within a dimension.</param>
        public ChunkAccessRecorder(int chunkX, int chunkY)
        {
            this.ChunkX = chunkX;
            this.ChunkY = chunkY;
            this.MilliSecondTimeout = this.CalculateTimeout();
        }

        public ChunkAccessRecorder()
        {

        }

        /// <summary>
        /// Calculates the proper timeout for deciding which accesses count for calculating the activity of a chunk.
        /// </summary>
        /// <returns></returns>
        private int CalculateTimeout()
        {
            //Probably need an algorithm here to do this. Later...
            return 1000;
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
            this.RemoveStale();
            return this.Accesses.Count;
        }

        /// <summary>
        /// Removes access records that no longer apply.
        /// </summary>
        private void RemoveStale()
        {
            while (DateTime.Now.Subtract(this.Accesses.Peek()).Milliseconds > this.MilliSecondTimeout)
            {
                this.Accesses.Dequeue();
            }
        }
    }
}
