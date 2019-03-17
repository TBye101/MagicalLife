using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.Load;
using MagicalLifeAPI.Mod;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeAPI.Registry.Mod
{
    /// <summary>
    /// Holds all of the loaded mods in the current game.
    /// </summary>
    public static class ModRegistry
    {
        /// <summary>
        /// Initialized by the <see cref="ModLoader"/> during game load.
        /// </summary>
        public static List<IMod> LoadedMods;

        /// <summary>
        /// Loads all the mods stored in this registry.
        /// </summary>
        internal static void LoadAllMods()
        {
            Loader loader = new Loader();
            string message = string.Empty;
            foreach (IMod item in LoadedMods)
            {
                ModInformation info = item.GetInfo();
                MasterLog.DebugWriteLine("Loading mod: " + info.DisplayName + "(" + info.ModID + ")");
                List<Load.IGameLoader> loadJobs = item.Load();
                loader.LoadAll(ref message, loadJobs);
                MasterLog.DebugWriteLine("Done loading: " + info.DisplayName + "(" + info.ModID + ")");
            }
        }
    }
}
