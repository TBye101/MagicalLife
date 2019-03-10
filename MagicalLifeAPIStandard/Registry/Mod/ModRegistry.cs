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
    }
}
