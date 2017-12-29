using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfTheGodsAPI.DND2E.Util
{
    /// <summary>
    /// Used to output to the <see cref="Console"/> or file, if necessary.
    /// </summary>
    public static class Output
    {
        /// <summary>
        /// If true, messages are logged to the console. Otherwise, they are just ignored.
        /// </summary>
        public static bool consoleOutput = true;

        /// <summary>
        /// Writes a line to the console if we are supposed to.
        /// </summary>
        /// <param name="msg"></param>
        public static void Writeline(string msg)
        {
            if (Output.consoleOutput)
            {
                Console.WriteLine(msg);
            }
        }
    }
}
