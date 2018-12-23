using Serilog;
using System;

namespace MagicalLifeAPI.Error
{
    /// <summary>
    /// Reports all exceptions thrown in Magical Life.
    /// </summary>
    public static class ErrorReporter
    {
        public static void Initialize()
        {
            AppDomain.CurrentDomain.FirstChanceException += CurrentDomain_FirstChanceException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Log.Error((Exception)e.ExceptionObject, "Unhandled exception: ");
        }

        private static void CurrentDomain_FirstChanceException(object sender, System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs e)
        {
            Log.Error(e.Exception, "First chance exception: ");
        }
    }
}