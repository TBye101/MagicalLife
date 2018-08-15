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

        }
    }
}
