using MagicalLifeAPI.Filing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.World.Data.Disk
{
    /// <summary>
    /// The access point for accessing every class that knows how to load something about the world.
    /// </summary>
    public static class WorldStorage
    {
        /// <summary>
        /// The name of the save game.
        /// </summary>
        public static string SaveName { get; set; }

        /// <summary>
        /// The path to the root of the directory where the current game is saved.
        /// </summary>
        public static string GameSaveRoot { get; set; }

        public static string DimensionSaveFolder { get; set; }

        /// <summary>
        /// Contains the path to the root of each dimension directory, where the chunk files go.
        /// Key: The ID of the dimension.
        /// Value: The path to the root of where all of the chunks are stored for the dimension.
        /// </summary>
        public static readonly Dictionary<Guid, string> DimensionPaths = new Dictionary<Guid, string>();

        private static DimensionStorage Dimension { get; set; } = new DimensionStorage();


        public static void Save(string saveName)
        {
            SaveName = saveName;

            DirectoryInfo gameSavePath = Directory.CreateDirectory(FileSystemManager.SaveDirectory + Path.DirectorySeparatorChar + saveName);
            GameSaveRoot = gameSavePath.FullName;

            DirectoryInfo dimensionSavePath = Directory.CreateDirectory(GameSaveRoot + Path.DirectorySeparatorChar + "Dimensions");
            DimensionSaveFolder = dimensionSavePath.FullName;

            foreach (Dimension item in World.Dimensions)
            {
                Dimension.Save(item);
            }
        }

        public static void Load(string saveName, Guid ID)
        {
            SaveName = saveName;

            if (Directory.Exists(FileSystemManager.SaveDirectory + Path.DirectorySeparatorChar + saveName))
            {
                GameSaveRoot = FileSystemManager.SaveDirectory + Path.DirectorySeparatorChar + saveName;

                if (Directory.Exists(GameSaveRoot + Path.DirectorySeparatorChar + "Dimensions"))
                {
                    foreach (string item in Directory.EnumerateFiles(GameSaveRoot + Path.DirectorySeparatorChar + "Dimensions"))
                    {
                        World.Dimensions.Add(Dimension.Load(Guid.Parse(item)));
                    }
                }
                else
                {
                    throw new DirectoryNotFoundException();
                }
            }
            else
            {
                throw new DirectoryNotFoundException();
            }
        }
    }
}
