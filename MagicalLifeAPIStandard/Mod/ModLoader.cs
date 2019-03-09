using MagicalLifeAPI.Filing;
using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.Load;
using MagicalLifeAPI.Registry.Mod;
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
            ModRegistry.LoadedMods = this.GetMods();
        }

        /// <summary>
        /// Gets all mods from the mod assemblies that wish to be run.
        /// </summary>
        /// <returns></returns>
        private List<IMod> GetMods()
        {
            Assembly[] modAssemblies = this.GetModAssemblies();
            List<IMod> mods = new List<IMod>();

            foreach (Assembly item in modAssemblies)
            {
                mods.AddRange(ReflectionUtil.LoadAllInterface<IMod>(item));
            }

            this.RemoveInvalidMods(mods);

            return mods;
        }

        /// <summary>
        /// Removes all mods that have invalid/duplicate mod ids from the passed in list.
        /// </summary>
        /// <param name="mods"></param>
        /// <returns></returns>
        private void RemoveInvalidMods(List<IMod> mods)
        {
            Dictionary<string, IMod> idToMods = new Dictionary<string, IMod>();
            foreach (IMod item in mods)
            {
                ModInformation info = item.GetInfo();
                if (idToMods.ContainsKey(info.ModID))
                {
                    idToMods.TryGetValue(info.ModID, out IMod value);
                    MasterLog.DebugWriteLine("Mod conflict: " + info.DisplayName + "(" + info.ModID + 
                        ") has an identical ModID to " + value.GetInfo().DisplayName + "(" + value.GetInfo().ModID + ")");
                    mods.Remove(item);
                    mods.Remove(value);
                    MasterLog.DebugWriteLine("Refusing to load either mod due to the ModID conflict");
                }
                else
                {
                    if (!this.IsValid(info))
                    {
                        mods.Remove(item);
                    }
                }
            }
        }

        /// <summary>
        /// Used to validate that a mod contains correct information.
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        private bool IsValid(ModInformation info)
        {

            if (info == null)
            {
                MasterLog.DebugWriteLine("Mod rejected due to ModInformation being invalid.");
                return false;
            }
            if (info.AuthorName == null || info.AuthorName.Equals(string.Empty))
            {
                MasterLog.DebugWriteLine("Mod rejected due to AuthorName in ModInformation being invalid.");
                return false;
            }
            if (info.Description == null)
            {
                MasterLog.DebugWriteLine("Mod rejected due to Description in ModInformation being invalid.");
                return false;
            }
            if (info.DisplayName == null || info.DisplayName.Equals(string.Empty))
            {
                MasterLog.DebugWriteLine("Mod rejected due to DisplayName in ModInformation being invalid.");
                return false;
            }
            if (info.Version == null)
            {
                MasterLog.DebugWriteLine("Mod rejected due to Version in ModInformation being invalid.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Finds and loads all mod assemblies.
        /// </summary>
        /// <returns></returns>
        private Assembly[] GetModAssemblies()
        {
            string[] files = Directory.GetFiles(FileSystemManager.ModDirectory);
            Assembly[] assemblies = new Assembly[files.Length];

            int length = files.Length;
            for (int i = 0; i < length; i++)
            {
                assemblies[i] = Assembly.LoadFile(files[i]);
            }

            return assemblies;
        }
    }
}
