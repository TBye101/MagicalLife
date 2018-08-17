﻿using MagicalLifeAPI.Filing;
using MagicalLifeAPI.World.Data.Disk.DataStorage;
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

        /// <summary>
        /// Knows how to save information about a dimension.
        /// </summary>
        public static DimensionStorage DimensionStorage { get; private set; }

        /// <summary>
        /// Knows how to save a dimensions chunks.
        /// </summary>
        public static ChunkStorage ChunkStorage { get; private set; }

        /// <summary>
        /// Knows how to save a dimension's item registry.
        /// </summary>
        public static ItemRegistryStorage ItemStorage { get; private set; }


        public static void SerializeWorld(string saveName, AbstractWorldSink sink)
        {
            Initialize(saveName);

            foreach (Dimension item in World.Dimensions)
            {
                DimensionStorage.Serialize(item, sink);
            }
        }

        private static void Initialize(string saveName)
        {
            SaveName = saveName;

            DirectoryInfo gameSavePath = Directory.CreateDirectory(FileSystemManager.SaveDirectory + Path.DirectorySeparatorChar + saveName);
            GameSaveRoot = gameSavePath.FullName;

            DirectoryInfo dimensionSavePath = Directory.CreateDirectory(GameSaveRoot + Path.DirectorySeparatorChar + "Dimensions");
            DimensionSaveFolder = dimensionSavePath.FullName;

            if (ChunkStorage == null)
            {
                ChunkStorage = new ChunkStorage(saveName);
            }

            if (DimensionStorage == null)
            {
                DimensionStorage = new DimensionStorage();
            }

            if (ItemStorage == null)
            {
                ItemStorage = new ItemRegistryStorage();
            }

            ParseDimensions(saveName);
        }

        /// <summary>
        /// Parses the dimensions to setup for serialization.
        /// </summary>
        /// <param name="saveName"></param>
        private static void ParseDimensions(string saveName)
        {
            if (World.Dimensions.Count > 0)
            {
                //We are saving
                foreach (Dimension item in World.Dimensions)
                {
                    DirectoryInfo dirInfo = Directory.CreateDirectory(WorldStorage.DimensionSaveFolder + Path.DirectorySeparatorChar + item.ID);
                    DimensionPaths.Add(item.ID, dirInfo.FullName);
                }
            }
            else
            {
                //We are loading
                foreach (string item in Directory.EnumerateDirectories(DimensionSaveFolder))
                {
                    string dirName = Path.GetFileName(item);
                    DimensionHeader header = DimensionStorage.LoadDimensionHeader(Guid.Parse(dirName), item);
                    DimensionPaths.Add(header.ID, item);
                }
            }
        }

        public static void LoadWorld(string saveName)
        {
            Initialize(saveName);

            if (Directory.Exists(FileSystemManager.SaveDirectory + Path.DirectorySeparatorChar + saveName))
            {
                GameSaveRoot = FileSystemManager.SaveDirectory + Path.DirectorySeparatorChar + saveName;

                if (Directory.Exists(GameSaveRoot + Path.DirectorySeparatorChar + "Dimensions"))
                {
                    foreach (string item in Directory.EnumerateDirectories(GameSaveRoot + Path.DirectorySeparatorChar + "Dimensions"))
                    {
                        string dirName = Path.GetFileName(item);
                        DimensionStorage.Load(Guid.Parse(dirName));
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
