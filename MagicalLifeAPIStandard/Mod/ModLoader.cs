using MagicalLifeAPI.Filing;
using MagicalLifeAPI.Load;
using MagicalLifeAPI.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace MagicalLifeAPI.Mod
{
    /// <summary>
    /// Used to load mods that are found in the mods directory.
    /// </summary>
    public class ModLoader : IGameLoader
    {
        public void InitialStartup()
        {
            
        }

        /// <summary>
        /// Finds and loads all mod assemblies.
        /// </summary>
        /// <returns></returns>
        private List<Assembly> GetModAssemblies()
        {
            IEnumerable<string> files = Directory.EnumerateFiles(FileSystemManager.ModDirectory);
            return null;
        }
    }
}
