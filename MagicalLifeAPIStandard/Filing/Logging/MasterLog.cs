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
        }

        /// <summary>
        /// Writes a line to the master log.
        /// </summary>
        /// <param name="msg"></param>
        [Conditional("DEBUG")]
        public static void DebugWriteLine(string msg)
        {
            string time = DateTime.UtcNow.ToString("[yyyy-MM-dd HH:mm:ss.fff]");
            Writer.WriteLine(time + " [DBG]: " + msg);
            Writer.Flush();
        }

        [Conditional("DEBUG")]
        public static void DebugWriteLine(Exception e, string msg)
        {
            DebugWriteLine(msg);
            DebugWriteLine(e.GetType().AssemblyQualifiedName + ":");
            DebugWriteLine("Help link: " + e.HelpLink);
            DebugWriteLine("Error code: " + e.HResult.ToString());
            DebugWriteLine("Message: " + e.Message);
            DebugWriteLine("Source: " + e.Source);
            DebugWriteLine("Stack trace: \r\n" + e.StackTrace);

            if (e.InnerException != null)
            {
                DebugWriteLine(e, "Inner exception: ");
            }

            Writer.Flush();
        }
    }
}