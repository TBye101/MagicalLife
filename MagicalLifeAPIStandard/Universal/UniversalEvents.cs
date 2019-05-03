using System;

namespace MagicalLifeAPI.Universal
{
    /// <summary>
    /// Holds some universal events.
    /// </summary>
    public static class UniversalEvents
    {
        /// <summary>
        /// Raised when the game is exiting, and done unloading.
        /// </summary>
        public static event EventHandler GameExit;

        /// <summary>
        /// Raises the world generated event.
        /// </summary>
        /// <param name="e"></param>
        public static void GameExitHandler()
        {
            EventHandler handler = GameExit;
            handler?.Invoke(null, null);
        }
    }
}