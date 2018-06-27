using MagicalLifeAPI.Filing.Logging;
using System;

namespace MagicalLifeServerShell
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Startup.Go();

            string input;

            while (true)
            {
                input = Console.ReadLine();
                MasterLog.DebugWriteLine(input);

                CommandSwitch.RecieveInput(input);
            }
        }
    }
}