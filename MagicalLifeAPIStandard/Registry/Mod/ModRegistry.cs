using MagicalLifeAPI.Filing.Logging;
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
            foreach (IMod item in LoadedMods)
            {
                ModInformation info = item.GetInfo();
                MasterLog.DebugWriteLine("Loading mod: " + info.DisplayName + "(" + info.ModID + ")");
                item.Load();
                MasterLog.DebugWriteLine("Done loading: " + info.DisplayName + "(" + info.ModID + ")");
            }
        }
    }
}
