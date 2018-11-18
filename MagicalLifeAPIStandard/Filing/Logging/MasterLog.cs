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

        public static void Initialize()
        {
            //Just proved that telling it to write to the same file will not overwrite it.
            Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.File(LogPath).CreateLogger();
            Log.Information("Log initialized!");
            Log.Information("Session: " + Guid.NewGuid());

            //Sample for later when we need a second log file.
            //Log.Logger = new LoggerConfiguration()
            //.MinimumLevel.Debug()
            //.WriteTo.LiterateConsole()
            //.WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Information).WriteTo.RollingFile(@"Logs\Info-{Date}.log"))
            //.WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Debug).WriteTo.RollingFile(@"Logs\Debug-{Date}.log"))
            //.WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Warning).WriteTo.RollingFile(@"Logs\Warning-{Date}.log"))
            //.WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Error).WriteTo.RollingFile(@"Logs\Error-{Date}.log"))
            //.WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Fatal).WriteTo.RollingFile(@"Logs\Fatal-{Date}.log"))
            //.WriteTo.RollingFile(@"Logs\Verbose-{Date}.log")
            //.CreateLogger();
        }

        /// <summary>
        /// Writes a line to the master log.
        /// </summary>
        /// <param name="msg"></param>
        [Conditional("DEBUG")]
        public static void DebugWriteLine(string msg)
        {
            Log.Debug(msg);
        }
    }
}