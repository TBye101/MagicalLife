using Serilog;
using System;
using System.Diagnostics;
using System.IO;

namespace MagicalLifeAPI.Filing.Logging
{
    /// <summary>
    /// The master log class where we log everything that happens, that isn't historical/statistical information.
    /// </summary>
    public static class MasterLog
    {
        private static readonly string LogPath = FileSystemManager.InstanceRootFolder + Path.DirectorySeparatorChar + "MasterLog.txt";
        private static TextWriter Writer;


        public static void Initialize()
        {
            Writer = new StreamWriter(LogPath, true);

            //Just proved that telling it to write to the same file will not overwrite it.
            //Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.File(LogPath).CreateLogger();
            //Log.Information("Log initialized!");
            //Log.Information("Session: " + Guid.NewGuid());
        }

        /// <summary>
        /// Writes a line to the master log.
        /// </summary>
        /// <param name="msg"></param>
        [Conditional("DEBUG")]
        public static void DebugWriteLine(string msg)
        {
            string time = DateTime.UtcNow.ToString("[yyyy-mm-dd hh:mm:ss.mmm]");
            Writer.WriteLine(time + " [DBG]: " + msg);
        }
    }
}