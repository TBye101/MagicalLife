using System;
using System.Diagnostics;
using System.IO;

namespace MagicalLifeAPI.Filing.Logging
{
    /// <summary>
    /// The master log class where we log everything that happens, that isn't historical/statistical information.
    /// </summary>
    public class MasterLog : IDisposable
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
                DebugWriteLine(e.InnerException, "Inner exception: ");
            }

            Writer.Flush();
        }

        #region IDisposable Support

        private bool disposedValue; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Writer.Dispose();
                }
                disposedValue = true;
            }
        }

        ~MasterLog()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Support

        internal static void Close()
        {
            Writer.Flush();
            Writer.Close();
            Writer.Dispose();
        }
    }
}