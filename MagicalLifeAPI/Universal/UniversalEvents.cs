using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Universal
{
    /// <summary>
    /// Holds some universal events.
    /// </summary>
    public class UniversalEvents
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
            if (handler != null)
            {
                handler.Invoke(null, null);
            }
        }
    }
}
