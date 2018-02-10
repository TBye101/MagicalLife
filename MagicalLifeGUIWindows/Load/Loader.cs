using MagicalLifeAPI.World;
using System.Reflection;
using MagicalLifeAPI.Universal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            AllJobs.AddRange(this.LoadTiles());
            loadMoniter.AddJobs(AllJobs);
        }

        /// <summary>
        /// Finds all the tiles.
        /// </summary>
        /// <returns></returns>
        private List<IGameLoader> LoadTiles()
        {
            List<IGameLoader> modules = new List<IGameLoader>();
            Assembly apiAssembly = Assembly.GetAssembly(typeof(World));

            foreach (Type item in apiAssembly.ExportedTypes)
            {
                if (!item.IsAbstract && item.IsAssignableFrom(typeof(Tile)))
                {
                    object tileObject = Activator.CreateInstance(item);

                    if (tileObject is Tile)
                    {
                        modules.Add((IGameLoader)tileObject);
                    }
                }
            }

            return modules;
        }
    }
}
