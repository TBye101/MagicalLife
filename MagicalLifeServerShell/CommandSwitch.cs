using MagicalLifeAPI.Filing.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MagicalLifeServerShell
{
    /// <summary>
    /// Used to determine which command to call, if any.
    /// </summary>
    public static class CommandSwitch
    {
        /// <summary>
        /// All found commands.
        /// </summary>
        private static readonly List<ICommandModule> modules = Util.LoadAllModules();

        private static bool commandFound = false;

        static CommandSwitch()
        {
        }

        /// <summary>
        /// Receive input, and determine what command to call.
        /// </summary>
        /// <param name="input"></param>
        public static void RecieveInput(string input)
        {
            commandFound = false;
            string inpt = input.ToLower();
            string[] inp = inpt.Split(' ');

            MaybeDisplayHelp(inp);
            if (!commandFound)
            {
                FindCommand(inp);
            }

            if (!commandFound)
            {
                Console.WriteLine("Command not found!");
                MasterLog.DebugWriteLine("Command not found!");
            }
        }

        private static void FindCommand(string[] inp)
        {
            foreach (ICommandModule item in modules)
            {
                if (item.getCommandUsageName().ToLower() == inp[0])
                {
                    foreach (ICommand iitem in item.getCommands())
                    {
                        if (iitem.getName().ToLower() == inp[1])
                        {
                            commandFound = true;
                            if (inp.Length >= 3)
                            {
                                iitem.run(inp.ToList().GetRange(2, inp.Length - 2));
                            }
                            else
                            {
                                iitem.run(new List<string>());
                            }
                        }
                    }
                }
            }
        }

        private static void MaybeDisplayHelp(string[] inp)
        {
            if (inp[0] == "help")
            {
                commandFound = true;
                DisplayModulesHelp();
            }

            if (inp.Length >= 2 && inp[1] == "help")
            {
                commandFound = true;
                DisplayModuleHelp(inp);
            }

            if (inp.Length >= 3 && inp[2] == "help")
            {
                commandFound = true;
                DisplayCommandHelp(inp);
            }
        }

        /// <summary>
        /// Displays help about a specific command.
        /// </summary>
        /// <param name="inp"></param>
        private static void DisplayCommandHelp(string[] inp)
        {
            bool cf = false;
            foreach (ICommandModule item in modules)
            {
                if (item.getCommandUsageName().ToLower() == inp[0])
                {
                    foreach (ICommand iitem in item.getCommands())
                    {
                        if (iitem.getName().ToLower() == inp[1])
                        {
                            cf = true;
                            Console.WriteLine(iitem.getHelp());
                            MasterLog.DebugWriteLine(iitem.getHelp());
                        }
                    }
                }
            }

            if (!cf)
            {
                Console.WriteLine("Command not found!");
                MasterLog.DebugWriteLine("Command not found!");
            }
        }

        /// <summary>
        /// Displays help about one specific module.
        /// </summary>
        /// <param name="inp"></param>
        private static void DisplayModuleHelp(string[] inp)
        {
            Console.WriteLine("Listing names of commands within the specified module. For detailed command information, do \"(modulename) (commandname) help\"");
            MasterLog.DebugWriteLine("Listing names of commands within the specified module. For detailed command information, do \"(modulename) (commandname) help\"");


            foreach (ICommandModule item in modules)
            {
                if (item.getCommandUsageName().ToLower() == inp[0])
                {
                    foreach (ICommand iitem in item.getCommands())
                    {
                        Console.WriteLine(iitem.getName());
                        MasterLog.DebugWriteLine(iitem.getName());
                    }
                }
            }
        }

        /// <summary>
        /// Displays help.
        /// </summary>
        private static void DisplayModulesHelp()
        {
            Console.WriteLine("Displaying module names. For help on individual commands in a module, do \"(modulename) help\"");
            MasterLog.DebugWriteLine("Displaying module names. For help on individual commands in a module, do \"(modulename) help\"");

            Console.WriteLine("");
            MasterLog.DebugWriteLine("");
            foreach (ICommandModule item in modules)
            {
                Console.WriteLine(item.getCommandUsageName());
                MasterLog.DebugWriteLine(item.getCommandUsageName());
            }
        }
    }
}