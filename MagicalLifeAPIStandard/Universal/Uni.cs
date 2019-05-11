using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.Networking.Messages;
using System;

namespace MagicalLifeAPI.Universal
{
    /// <summary>
    /// Holds some universal events.
    /// </summary>
    public static class Uni
    {
        /// <summary>
        /// The tick the client is executing.
        /// </summary>
        public static UInt64 GameTick { get; private set; }

        /// <summary>
        /// The event that is raised when the game ticks.
        /// </summary>
        public static event EventHandler<UInt64> TickEvent;

        /// <summary>
        /// Raised when the game is exiting, and done unloading.
        /// </summary>
        public static event EventHandler GameExit;

        /// <summary>
        /// Raises the world generated event.
        /// </summary>
        /// <param name="e"></param>
        internal static void GameExitHandler()
        {
            EventHandler handler = GameExit;
            handler?.Invoke(null, null);
        }


        /// <summary>
        /// How the server handles tick messages.
        /// </summary>
        /// <param name="msg"></param>
        internal static void Tick(ServerTickMessage msg)
        {
            Tick(msg.TickSent);
        }

        internal static void Tick(UInt64 tickSentAt)
        {
            UInt64 ticksBehind = tickSentAt - GameTick - 1;

            if (ticksBehind != 0)
            {
                MasterLog.DebugWriteLine("Running " + ticksBehind.ToString() + " tick(s) behind");
            }

            TickLoop(ticksBehind + 1);
        }

        private static void TickLoop(UInt64 times)
        {
            UInt64 i = 0;

            while (i != times)
            {
                GameTick++;

                TickEvent?.Invoke(null, GameTick);
                i++;
            }
        }
    }
}