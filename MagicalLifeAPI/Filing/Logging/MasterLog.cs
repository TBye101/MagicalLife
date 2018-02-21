using Serilog;
using System;
using System.IO;

namespace MagicalLifeAPI.Filing.Logging
{
    /// <summary>
    /// The master log class where we log everything that happens, that isn't historical/statistical information.
    /// </summary>
    public static class MasterLog
    {
        private static readonly string LogPath = FileSystemManager.rootFolder + Path.DirectorySeparatorChar + "MasterLog.txt";

        public static void Initialize()
        {
            //Just proved that telling it to write to the same file will not overwrite it.
            Log.Logger = new LoggerConfiguration().MinimumLevel.Information().WriteTo.File(LogPath).CreateLogger();
            Log.Information("Log initialized!");
            Log.Information("Session: " + Guid.NewGuid());
        }
    }
}