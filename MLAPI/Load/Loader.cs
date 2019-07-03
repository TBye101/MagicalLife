using System.Collections.Generic;

namespace MagicalLifeAPI.Load
{
    /// <summary>
    /// Handles loading everything at startup.
    /// </summary>
    internal class Loader
    {
        /// <summary>
        /// Loads all content.
        /// </summary>
        /// <param name="message">The message to display while loading.</param>
        internal void LoadAll(ref string message, List<IGameLoader> AllJobs)
        {
            LoadMoniter loadMoniter = new LoadMoniter();

            loadMoniter.AddJobs(AllJobs);
            loadMoniter.ExecuteJobs(ref message);
        }
    }
}