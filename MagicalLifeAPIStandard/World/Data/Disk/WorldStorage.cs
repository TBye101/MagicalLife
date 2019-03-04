using MagicalLifeAPI.Filing;
using MagicalLifeAPI.World.Data.Disk.DataStorage;
using System;
using System.Collections.Generic;
using System.IO;

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
        public static string SaveName { get; set; } = string.Empty;

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
        public static Dictionary<Guid, string> DimensionPaths { get; private set; } = new Dictionary<Guid, string>();

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

        /// <summary>
        /// Sends a <see cref="WorldTransferHeaderMessage"/>, then serializes and sends the world of the network.
        /// </summary>
        /// <param name="saveName"></param>
        /// <param name="sink"></param>
        public static void NetSerializeWorld(string saveName, AbstractWorldSink sink)
        {
            List<DimensionHeader> headers = new List<DimensionHeader>();

            foreach (KeyValuePair<Guid, string> item in DimensionPaths)
            {
                headers.Add(DimensionStorage.LoadDimensionHeader(item.Key));
            }

            //Send header information about all dimensions
            //This is so that the client can properly handle the incoming parts of the world.
            sink.Receive(headers, null, Guid.Empty);//No headers

            //Send the client the world.
            SerializeWorld(saveName, sink);
        }

        /// <summary>
        /// Serializes the world to the sink.
        /// </summary>
        /// <param name="saveName"></param>
        /// <param name="sink"></param>
        public static void SerializeWorld(string saveName, AbstractWorldSink sink)
        {
            Initialize(saveName);

            foreach (Dimension item in World.Dimensions)
            {
                DimensionStorage.Serialize(item, sink);
            }
        }

        public static void AutoSave(string saveName, AbstractWorldSink sink)
        {
            string name = saveName + "-" + FileSystemManager.GetIOSafeTime();
            SerializeWorld(name, sink);
        }

        internal static void Initialize(string saveName)
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

            ParseDimensions();
        }

        /// <summary>
        /// Parses the dimensions to setup for serialization.
        /// </summary>
        /// <param name="saveName"></param>
        private static void ParseDimensions()
        {
            if (World.Dimensions.Count > 0)
            {
                //We are saving
                foreach (Dimension item in World.Dimensions)
                {
                    DirectoryInfo dirInfo = Directory.CreateDirectory(WorldStorage.DimensionSaveFolder + Path.DirectorySeparatorChar + item.ID);

                    if (DimensionPaths.TryGetValue(item.ID, out string value) == false)
                    {
                        DimensionPaths.Add(item.ID, dirInfo.FullName);
                    }
                }
            }
            else
            {
                //We are loading
                foreach (string item in Directory.EnumerateDirectories(DimensionSaveFolder))
                {
                    string dirName = Path.GetFileName(item);
                    DimensionHeader header = DimensionStorage.LoadDimensionHeader(Guid.Parse(dirName), item);

                    if (!DimensionPaths.ContainsKey(header.ID))
                    {
                        DimensionPaths.Add(header.ID, item);
                    }
                }
            }
        }

        internal static void LoadWorld(string saveName)
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