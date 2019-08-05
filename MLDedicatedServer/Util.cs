using System;
using System.Collections.Generic;
using System.Reflection;
using MLAPI.Filing.Logging;
using MLAPI.Server;
using MLAPI.Util;

namespace MLDedicatedServer
{
    /// <summary>
    /// A utility class.
    /// </summary>
    public static class Util
    {
        /// <summary>
        /// Writes a line to the log and to the console all at once.
        /// </summary>
        /// <param name=""></param>
        public static void WriteLine(string msg)
        {
            Console.WriteLine(msg);
            MasterLog.DebugWriteLine(msg);
        }

        /// <summary>
        /// Loads all findable ICommandModules.
        /// </summary>
        /// <returns></returns>
        public static List<ICommandModule> LoadAllModules()
        {
            Assembly server = Assembly.GetExecutingAssembly();
            //Should load up mod assemblies and search them too
            List<ICommandModule> modules = ReflectionUtil.LoadAllInterface<ICommandModule>(server);

            foreach (ICommandModule item in modules)
            {
                MasterLog.DebugWriteLine("Discovered server command module: " + item.GetFullName());

                foreach (ICommand iitem in item.GetCommands())
                {
                    MasterLog.DebugWriteLine("Found command: " + iitem.GetName());
                }
            }

            return modules;
        }
    }
}