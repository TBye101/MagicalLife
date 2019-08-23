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
using ProtoBuf;

namespace MLAPI.Pathfinding.AStar.Providers
{
    /// <summary>
    /// Provides access to tiles from the specified chunks.
    /// </summary>
    [ProtoContract]
    public class ChunkedWorldProvider : IWorldProvider
    {
        [ProtoMember(1)]
        private readonly ProtoArray<Chunk> Chunks;

        [ProtoMember(2)]
        private readonly Guid DimensionId;

        public ChunkedWorldProvider(ProtoArray<Chunk> chunks, Guid dimensionId)
        {
            this.Chunks = chunks;
            this.DimensionId = dimensionId;
        }

        protected ChunkedWorldProvider()
        {
            //Protobuf-net constructor
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

        public void SetTile(Point3D location, Tile value)
        {
            if (this.DoesTileExist(location))
            {
                Point2D chunkLocation = WorldUtil.CalculateChunkLocation(location);
                Chunk chunk = this.Chunks[chunkLocation.X, chunkLocation.Y];
                Point2D tileLocation = WorldUtil.CalculateTileLocationInChunk(location);
                chunk.Tiles[tileLocation.X, tileLocation.Y] = value;
                Tile tile = chunk.Tiles[tileLocation.X, tileLocation.Y];
                ComponentSelectable tileSelectable = tile.GetExactComponent<ComponentSelectable>();
            }
            else
            {
                throw new UnexpectedStateException(
                    "A tile was accessed that is not of the same dimension as those that are stored");
            }
        }

        public bool DoesTileExist(Point3D location)
        {
            if (location.DimensionId.Equals(this.DimensionId))
            {
                Point2D chunkLocation = WorldUtil.CalculateChunkLocation(location);

                return chunkLocation.X < this.Chunks.Width &&
                       chunkLocation.X > -1 &&
                       chunkLocation.Y > -1 &&
                       chunkLocation.Y < this.Chunks.Height;
            }
            
            return false;
        }

        public Point2D GetWorldSizeInChunks(Guid dimensionId)
        {
            return new Point2D(this.Chunks.Width, this.Chunks.Height);
        }

        public Chunk GetChunk(Point3D chunkLocation)
        {
            return this.Chunks[chunkLocation.X, chunkLocation.Y];
        }

        public Chunk GetChunkByTile(Point3D tileLocation)
        {
            int chunkX = tileLocation.X / Chunk.Width;
            int chunkY = tileLocation.Y / Chunk.Height;
            return this.Chunks[chunkX, chunkY];
        }

        public bool DoesChunkExist(Point3D location)
        {
            return location.X < this.Chunks.Width &&
                   location.Y < this.Chunks.Height &&
                   location.X > -1 &&
                   location.Y > -1;
        }
    }
}
