using MagicalLifeAPI.Universal;
using MagicalLifeAPI.Util;
using System.Collections.Generic;
using System.Reflection;

namespace MagicalLifeAPI.Load
{
    /// <summary>
    /// Handles loading everything at startup.
    /// </summary>
    public class Loader
    {
        /// <summary>
        /// Loads all content.
        /// </summary>
        /// <param name="message">The message to display while loading.</param>
        public void LoadAll(ref string message, List<Assembly> targetAssembly)
        {
            LoadMoniter loadMoniter = new LoadMoniter();

            List<IGameLoader> AllJobs = new List<IGameLoader>();

            foreach (Assembly item in targetAssembly)
            {
                AllJobs.AddRange(ReflectionUtil.LoadAllInterface<IGameLoader>(item));
            }

            loadMoniter.AddJobs(AllJobs);
            loadMoniter.ExecuteJobs(ref message);
        }
    }
}