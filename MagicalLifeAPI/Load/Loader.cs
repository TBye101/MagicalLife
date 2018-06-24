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
        public void LoadAll(ref string message, List<IGameLoader> AllJobs)
        {
            LoadMoniter loadMoniter = new LoadMoniter();

            loadMoniter.AddJobs(AllJobs);
            loadMoniter.ExecuteJobs(ref message);
        }
    }
}