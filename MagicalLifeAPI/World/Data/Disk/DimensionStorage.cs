using MagicalLifeAPI.Networking.Serialization;
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
    /// Knows how to save a dimension
    /// </summary>
    public class DimensionStorage
    {
        public DimensionStorage()
        {

        }

        /// <summary>
        /// Creates folders for a new dimension.
        /// </summary>
        public void PrepareForDimension(Guid dimensionID)
        {
            DirectoryInfo info = Directory.CreateDirectory(WorldStorage.GameSaveRoot + Path.DirectorySeparatorChar + dimensionID);
            WorldStorage.DimensionPaths.Add(dimensionID, info.FullName);
        }

        public Dimension Load(Guid ID)
        {
            throw new NotImplementedException();
        }

        public void Save(Dimension dimension)
        {
            int width = dimension.Width;
            int height = dimension.Height;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Chunk chunk = dimension.GetChunk(x, y);
                    WorldStorage.ChunkStorage.SaveChunk(chunk, dimension.ID);
                    SaveDimensionHeader(dimension);
                }
            }
        }

        private void SaveDimensionHeader(Dimension dimension)
        {
            string dimensionRoot = WorldStorage.DimensionPaths[dimension.ID];

            using (FileStream writer = new FileStream(dimensionRoot + dimension.ID + ".header", FileMode.Create))
            {
                DimensionHeader header = new DimensionHeader(dimension.DimensionName, dimension.ID, dimension.Width, dimension.Height);
                byte[] headerData = ProtoUtil.Serialize(header);

                writer.WriteAsync(headerData, 0, headerData.Length);
                //Have an IWorldReciever so that serializing the world into its parts doesn't know if it is going on disk or over the network
            }
        }
    }
}
