using MagicalLifeAPI.Error;
using MagicalLifeAPI.Filing;
using MagicalLifeAPI.Filing.Logging;
using System;

namespace MagicalLifeGUIWindows
{
#if WINDOWS || LINUX

    public static class Program
    {
        [STAThread]
        private static void Main()
        {
            FileSystemManager.Initialize();
            MasterLog.Initialize();
            ErrorReporter.Initialize();

            using (Game1 game = new Game1())
            {
                game.Run();
            }
        }
    }

#endif
}