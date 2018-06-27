using MagicalLifeAPI.Filing.Logging;
using Microsoft.Xna.Framework;
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
            PT pt = new PT(3, 1);
            Point point = new Point(3, 1);
            StackTest.Derived derived = new StackTest.Derived(point);

            //Startup.Go();

            //string input;

            //while (true)
            //{
            //    input = Console.ReadLine();
            //    MasterLog.DebugWriteLine(input);

            //    CommandSwitch.RecieveInput(input);

            //}
        }
    }
}
