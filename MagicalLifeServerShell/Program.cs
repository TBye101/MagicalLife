using MagicalLifeAPI.Filing.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeServerShell
{
    class Program
    {
        static void Main(string[] args)
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
