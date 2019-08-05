using System;
using MLAPI.Error;
using MLAPI.Filing;
using MLAPI.Filing.Logging;

namespace MLGUIWindows
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