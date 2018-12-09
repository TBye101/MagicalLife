using ProtoBuf;
using System;

namespace MagicalLifeAPI.Util.Reusable
{
    /// <summary>
    /// Used to allow something to happen every so many ticks.
    /// </summary>
    [ProtoContract]
    public class TickTimer
    {
        /// <summary>
        /// The number of ticks between every time that something is allowed.
        /// </summary>
        [ProtoMember(1)]
        protected int Ticks { get; set; }

        [ProtoMember(2)]
        protected int CurrentTick { get; set; }

        /// <param name="ticks">The number of ticks between every time that something is allowed.</param>
        public TickTimer(int ticks)
        {
            this.Ticks = ticks;

            if (ticks < 0)
            {
                throw new ArgumentOutOfRangeException("ticks", "Cannot be less than 0");
            }
        }

        /// <summary>
        /// The protobuf-net constructor. This should not be used.
        /// </summary>
        public TickTimer()
        {
        }

        /// <summary>
        /// Resets the countdown on this tick timer.
        /// This does not
        /// </summary>
        public void Reset()
        {
            this.CurrentTick = 0;
        }

        public bool Allow()
        {
            this.CurrentTick++;

            if (this.CurrentTick >= this.Ticks)
            {
                this.Reset();
                return true;
            }
            else
            {
                this.CurrentTick++;
                return false;
            }
        }
    }
}