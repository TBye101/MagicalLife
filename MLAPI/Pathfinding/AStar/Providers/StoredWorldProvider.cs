using System;
using System.Collections.Generic;
using System.Text;
using MLAPI.DataTypes;
using MLAPI.Pathfinding.TeleportationSearch;
using MLAPI.World;
using MLAPI.World.Base;
using MLAPI.World.Data;
using Dimension = MLAPI.World.Data.Dimension;

namespace MLAPI.Pathfinding.AStar.Providers
{
    /// <summary>
    /// Provides access to worlds stored in the <see cref="World"/>.
    /// </summary>
    public class StoredWorldProvider : IWorldProvider
    {
        public Tile GetTile(Point3D location)
        {
            return World.Data.World.GetTile(location);
        }

        public bool DoesTileExist(Point3D location)
        {
            World.Data.World.Dimensions.TryGetValue(location.DimensionId, out Dimension dimension);

            if (dimension == null)
            {
                return false;
            }

            Point2D chunkLocation = WorldUtil.CalculateChunkLocation(location);

            return chunkLocation.X < dimension.Width &&
                   chunkLocation.X > -1 &&
                   chunkLocation.Y > -1 &&
                   chunkLocation.Y < dimension.Height;
        }
    }
}
