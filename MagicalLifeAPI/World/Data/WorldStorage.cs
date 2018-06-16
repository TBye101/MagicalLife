using MagicalLifeAPI.Filing;
using MagicalLifeAPI.Protobuf.Serialization;
using Microsoft.Xna.Framework;
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
        /// The name of the save game.
        /// </summary>
        private string SaveName;

        private string GameSaveRoot;

        /// <summary>
        /// Contains the path to the root of each dimension directory, where the chunk files go.
        /// Key: The ID of the dimension.
        /// Value: The path to the root of where all of the chunks are stored for the dimension.
        /// </summary>
        private Dictionary<Guid, string> DimensionPaths = new Dictionary<Guid, string>();

        public WorldStorage(string saveName)
        {
            this.SaveName = saveName;

            DirectoryInfo savePath = Directory.CreateDirectory(FileSystemManager.RootDirectory + Path.DirectorySeparatorChar + "Save");
            this.SaveDirectory = savePath.FullName;

            DirectoryInfo gameSavePath = Directory.CreateDirectory(SaveDirectory + Path.DirectorySeparatorChar + this.SaveName);
            this.GameSaveRoot = gameSavePath.FullName;
        }

        /// <summary>
        /// Creates folders for a new dimension.
        /// </summary>
        public void PrepareForDimension(Guid dimensionID)
        {
            DirectoryInfo info = Directory.CreateDirectory(this.GameSaveRoot + Path.DirectorySeparatorChar + dimensionID);
            this.DimensionPaths.Add(dimensionID, info.FullName);
        }

        /// <summary>
        /// Saves a chunk to disk.
        /// </summary>
        /// <param name="chunk">The chunk to save.</param>
        /// <param name="dimensionID">The ID of the dimension the chunk belongs to.</param>
        public void SaveChunk(Chunk chunk, Guid dimensionID)
        {
            string path;
            bool dimensionExists = this.DimensionPaths.TryGetValue(dimensionID, out path);

            if (!dimensionExists)
            {
                throw new Exception("Dimension save folder does not exist!");
            }

            using (FileStream fs = File.Create(path + chunk.ChunkLocation.ToString() + ".chunk"))
            {
                string serialized = ProtoUtil.Serialize<Chunk>(chunk);

                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteAsync(serialized);
                }
            }
        }

        /// <summary>
        /// Loads a chunk from disk.
        /// </summary>
        /// <param name="chunkX">The x position of the chunk within the dimension.</param>
        /// <param name="chunkY">The y position of the chunk within the dimension.</param>
        /// <param name="dimensionID">The ID of the dimension that the chunk belongs to.</param>
        /// <returns></returns>
        public Chunk LoadChunk(int chunkX, int chunkY, Guid dimensionID)
        {

        }
    }
}
