using MagicalLifeAPI.Load;
using System.Collections.Generic;

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
        /// Should return a list of loading tasks to do to completely load the mod.
        /// Things such as registering (add to a registry) items, world generators, and resources should happen here.
        /// </summary>
        List<IGameLoader> Load();
    }
}