using MagicalLifeAPI.Filing.Logging;
using System;

namespace MagicalLifeAPI.Error
{
    /// <summary>
    /// Reports all exceptions thrown in Magical Life.
    /// </summary>
    internal static class ErrorReporter
    {
        internal static void Initialize()
        {
            AppDomain.CurrentDomain.FirstChanceException += CurrentDomain_FirstChanceException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MasterLog.DebugWriteLine((Exception)e.ExceptionObject, "Unhandled exception: ");
        }

        private static void CurrentDomain_FirstChanceException(object sender, System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs e)
        {
            MasterLog.DebugWriteLine(e.Exception, "First chance exception: ");
        }
    }
}