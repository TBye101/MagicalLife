using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeAPI.Mod
{
    /// <summary>
    /// Implemented by mods to be executed when the game starts up.
    /// </summary>
    public interface IMod
    {
        /// <summary>
        /// Should return basic information about the mod.
        /// </summary>
        /// <returns></returns>
        ModInformation GetInfo();

        /// <summary>
        /// A chance for the mod to execute any code needed to load when the game loads.
        /// </summary>
        void Load();
    }
}
