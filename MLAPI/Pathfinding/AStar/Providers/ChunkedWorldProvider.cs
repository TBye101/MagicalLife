using System;
using System.Collections.Generic;
using System.Text;
using MLAPI.Components;
using MLAPI.DataTypes;
using MLAPI.DataTypes.Collection;
using MLAPI.Error.InternalExceptions;
using MLAPI.Pathfinding.TeleportationSearch;
using MLAPI.World;
using MLAPI.World.Base;
using MLAPI.World.Data;

namespace MLAPI.Pathfinding.AStar.Providers
{
    /// <summary>
    /// Provides access to tiles from the specified chunks.
    /// </summary>
    public class ChunkedWorldProvider : IWorldProvider
    {
        private readonly ProtoArray<Chunk> Chunks;

        public ChunkedWorldProvider(ProtoArray<Chunk> chunks)
        {
            this.Chunks = chunks;
        }

        public Tile GetTile(Point3D location)
        {
            Point2D chunkLocation = WorldUtil.CalculateChunkLocation(location);
            Chunk chunk = this.Chunks[chunkLocation.X, chunkLocation.Y];
            Point2D tileLocation = WorldUtil.CalculateTileLocationInChunk(location);

            Tile tile = chunk.Tiles[tileLocation.X, tileLocation.Y];
            ComponentSelectable tileSelectable = tile.GetExactComponent<ComponentSelectable>();
            if (tileSelectable.MapLocation.DimensionId.Equals(location.DimensionId))
            {
                return tile;
            }
            else
            {
                throw new UnexpectedStateException(
                    "A tile was requested that is not of the same dimension as those that are stored");
            }
        }
    }
}
