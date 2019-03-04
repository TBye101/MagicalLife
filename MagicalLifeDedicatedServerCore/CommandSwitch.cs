using MagicalLifeAPI.Server;
using System.Collections.Generic;
using System.Linq;

namespace MagicalLifeDedicatedServer
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
                Util.WriteLine("Command not found!");
            }
        }

        private static void FindCommand(string[] inp)
        {
            foreach (ICommandModule item in modules)
            {
                if (item.GetCommandUsageName().ToLower() == inp[0])
                {
                    foreach (ICommand iitem in item.GetCommands())
                    {
                        if (iitem.GetName().ToLower() == inp[1])
                        {
                            commandFound = true;
                            if (inp.Length >= 3)
                            {
                                iitem.Run(inp.ToList().GetRange(2, inp.Length - 2));
                            }
                            else
                            {
                                iitem.Run(new List<string>());
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
                if (item.GetCommandUsageName().ToLower() == inp[0])
                {
                    foreach (ICommand iitem in item.GetCommands())
                    {
                        if (iitem.GetName().ToLower() == inp[1])
                        {
                            cf = true;
                            Util.WriteLine(iitem.GetHelp());
                        }
                    }
                }
            }

            if (!cf)
            {
                Util.WriteLine("Command not found!");
            }
        }

        /// <summary>
        /// Displays help about one specific module.
        /// </summary>
        /// <param name="inp"></param>
        private static void DisplayModuleHelp(string[] inp)
        {
            Util.WriteLine("Listing names of commands within the specified module. For detailed command information, do \"(modulename) (commandname) help\"");

            foreach (ICommandModule item in modules)
            {
                if (item.GetCommandUsageName().ToLower() == inp[0])
                {
                    foreach (ICommand iitem in item.GetCommands())
                    {
                        Util.WriteLine(iitem.GetName());
                    }
                }
            }
        }

        /// <summary>
        /// Displays help.
        /// </summary>
        private static void DisplayModulesHelp()
        {
            Util.WriteLine("Displaying module names. For help on individual commands in a module, do \"(modulename) help\"");
            Util.WriteLine("");
            foreach (ICommandModule item in modules)
            {
                Util.WriteLine(item.GetCommandUsageName());
            }
        }
    }
}