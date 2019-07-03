using ProtoBuf;
using System;
using System.Collections.Generic;

namespace MagicalLifeAPI.World.Data
{
    /// <summary>
    /// Used to remember when and how many times an object has been accessed.
    /// </summary>
    [ProtoContract]
    public class ObjectAccessRecorder
    {
        [ProtoMember(1)]
        private readonly List<DateTime> Accesses = new List<DateTime>();

        /// <summary>
        /// The time until a access is no longer counted in calculating how many times a chunk has been accessed.
        /// </summary>
        [ProtoMember(4)]
        private readonly int MilliSecondTimeout;

        public ObjectAccessRecorder()
        {
            //Protobuf-net constructor.
            this.MilliSecondTimeout = this.CalculateTimeout();
        }

        /// <summary>
        /// Calculates the proper timeout for deciding which accesses count for calculating the activity of a chunk.
        /// </summary>
        /// <returns></returns>
        private int CalculateTimeout()
        {
            //Probably need an algorithm here to do this. Project for another day when the project is more mature.
            return 1000;
        }

        /// <summary>
        /// Records that something has been accessed right now.
        /// </summary>
        public void Access()
        {
            this.Accesses.Add(DateTime.Now);
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
            if (this.Accesses.Count > 0)
            {
                while (DateTime.Now.Subtract(this.Accesses[0]).Milliseconds > this.MilliSecondTimeout)
                {
                    this.Accesses.RemoveAt(0);
                }
            }
        }
    }
}