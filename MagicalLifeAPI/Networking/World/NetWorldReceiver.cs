using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.World.Data.Disk;
using MagicalLifeAPI.World.Data.Disk.DataStorage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Networking.World
{
    /// <summary>
    /// Knows how to handle the world from network messages.
    /// </summary>
    public static class NetWorldReceiver
    {
        /// <summary>
        /// How many chunks are expected from all incoming dimensions.
        /// </summary>
        private static int ExpectedChunks = 0;

        /// <summary>
        /// How many item registries are expected from all incoming dimensions.
        /// </summary>
        private static int ExpectedItemRegistries = 0;

        public static void Receive(WorldTransferBodyMessage msg)
        {
        }

        public static void Receive(WorldTransferHeaderMessage msg)
        {
            ExpectedChunks = 0;
            ExpectedItemRegistries = 0;

            WorldDiskSink sink = new WorldDiskSink();

            foreach (DimensionHeader item in msg.DimensionHeaders)
            {
                ExpectedChunks += item.Height * item.Width;
                ExpectedItemRegistries++;

                DirectoryInfo dirInfo = Directory.CreateDirectory(WorldStorage.DimensionSaveFolder + Path.DirectorySeparatorChar + item.ID);
                WorldStorage.DimensionPaths.Add(item.ID, dirInfo.FullName);
                WorldStorage.DimensionStorage.SerializeDimensionHeader(item, sink, dirInfo.FullName);
            }
        }

        public static void Receive(WorldTransferRegistryMessage msg)
        {
        }
    }
}
