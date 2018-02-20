using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.Filing;
using System;

namespace MagicalLifeGUIWindows
{
#if WINDOWS || LINUX

    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            FileSystemManager.Initialize();
            MasterLog.Initialize();

            using (Game1 game = new Game1())
            {
                game.Run();
            }
        }
    }

#endif
}