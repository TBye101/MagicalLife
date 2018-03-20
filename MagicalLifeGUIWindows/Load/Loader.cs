using MagicalLifeAPI.Universal;
using MagicalLifeAPI.Util;
using MagicalLifeAPI.World;
using System.Collections.Generic;
using System.Reflection;

namespace MagicalLifeGUIWindows.Load
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
        public void LoadAll(ref string message)
        {
            LoadMoniter loadMoniter = new LoadMoniter();

            List<IGameLoader> AllJobs = new List<IGameLoader>();

            AllJobs.AddRange(ReflectionUtil.LoadAllInterface<IGameLoader>(Assembly.GetAssembly(typeof(World))));
            AllJobs.AddRange(ReflectionUtil.LoadAllInterface<IGameLoader>(Assembly.GetAssembly(typeof(TextureLoader))));
            loadMoniter.AddJobs(AllJobs);
            loadMoniter.ExecuteJobs(ref message);
        }
    }
}