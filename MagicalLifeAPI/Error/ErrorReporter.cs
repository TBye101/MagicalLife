using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            if (Debugger.IsAttached)
            {
                Debugger.Break();
            }
        }

        private static void CurrentDomain_FirstChanceException(object sender, System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs e)
        {
            Log.Error(e.Exception, "First chance exception: ");

            if (Debugger.IsAttached)
            {
                Debugger.Break();
            }
        }
    }
}
