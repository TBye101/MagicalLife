using MagicalLifeAPI.Filing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.World.Data
{
    /// <summary>
    /// Knows how to load and save data from every dimension in the world.
    /// </summary>
    internal class WorldStorage
    {
        /// <summary>
        /// The path to the save directory.
        /// </summary>
        private readonly string SaveDirectory;

        /// <summary>
        /// Contains the path to the root of each dimension directory, where the chunk files go.
        /// </summary>
        private List<string> DimensionPaths = new List<string>();

        public WorldStorage()
        {
            DirectoryInfo info = Directory.CreateDirectory(FileSystemManager.RootDirectory + Path.DirectorySeparatorChar + "Save");
            this.SaveDirectory = info.FullName;
        }

        /// <summary>
        /// Creates folders for a new dimension.
        /// </summary>
        public void PrepareForDimension(Guid dimensionID)
        {
            DirectoryInfo info = Directory.CreateDirectory(this.SaveDirectory + Path.DirectorySeparatorChar + dimensionID);
            this.DimensionPaths.Add(info.FullName);
        }
    }
}
