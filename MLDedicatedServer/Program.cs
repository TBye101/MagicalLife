using System;
using MLAPI.Filing.Logging;

namespace MLDedicatedServer
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Startup.Go();

            string input;

            while (true)
            {
                try
                {
                    input = Console.ReadLine();
                    MasterLog.DebugWriteLine(input);

                    CommandSwitch.RecieveInput(input);
                }
                catch (Exception e)
                {
                    MasterLog.DebugWriteLine(e.Message);
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}