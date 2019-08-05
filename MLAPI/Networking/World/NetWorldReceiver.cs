using System;
using System.IO;
using MLAPI.Filing;
using MLAPI.Networking.Messages;
using MLAPI.Properties;
using MLAPI.World;
using MLAPI.World.Data.Disk;
using MLAPI.World.Data.Disk.DataStorage;

namespace MLAPI.Networking.World
{
    /// <summary>
    /// Knows how to handle the world from network messages.
    /// </summary>
    public static class NetWorldReceiver
    {
        /// <summary>
        /// How many chunks are expected from all incoming dimensions.
        /// </summary>
        private static int ExpectedChunks;

        /// <summary>
        /// How many item registries are expected from all incoming dimensions.
        /// </summary>
        private static int ExpectedItemRegistries;

        private static int ReceivedChunks;
        private static int ReceivedItemRegistries;

        private static WorldDiskSink DiskSink = new WorldDiskSink();

        private static string SaveName;

        /// <summary>
        /// Checks to see if we are done receiving the world.
        /// </summary>
        private static void CheckCompletion()
        {
            if (ReceivedChunks == ExpectedChunks && ReceivedItemRegistries == ExpectedItemRegistries)
            {
                HandleCompletion();
            }
        }

        /// <summary>
        /// Handles when we are done receiving the world.
        /// </summary>
        private static void HandleCompletion()
        {
            WorldStorage.LoadWorld(SaveName);
            Guid firstDimensionID = WorldUtil.GetDimensionByName(Lang._1stDimensionName).Key;
            MLAPI.World.Data.World.RaiseChangeCameraDimension(firstDimensionID);
        }

        internal static void Receive(WorldTransferBodyMessage msg)
        {
            ReceivedChunks++;
            WorldStorage.ChunkStorage.SaveChunk(msg.Chunk, msg.DimensionID, DiskSink);
            CheckCompletion();
        }

        internal static void Receive(WorldTransferHeaderMessage msg)
        {
            ExpectedChunks = 0;
            ExpectedItemRegistries = 0;
            ReceivedChunks = 0;
            ReceivedItemRegistries = 0;

            SaveName = FileSystemManager.GetIOSafeTime();
            WorldStorage.Initialize(SaveName);

            foreach (DimensionHeader item in msg.DimensionHeaders)
            {
                ExpectedChunks += item.Height * item.Width;
                ExpectedItemRegistries++;

                DirectoryInfo dirInfo = Directory.CreateDirectory(WorldStorage.DimensionSaveFolder + Path.DirectorySeparatorChar + item.ID);
                WorldStorage.DimensionPaths.Add(item.ID, dirInfo.FullName);
                WorldStorage.DimensionStorage.SerializeDimensionHeader(item, DiskSink, dirInfo.FullName);
            }
        }

        internal static void Receive(WorldTransferRegistryMessage msg)
        {
            ReceivedItemRegistries++;
            WorldStorage.ItemStorage.SaveItemRegistry(msg.ItemReg, DiskSink, msg.DimensionID);
            CheckCompletion();
        }
    }
}