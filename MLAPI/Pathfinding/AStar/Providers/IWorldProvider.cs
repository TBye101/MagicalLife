using System;
using System.Collections.Generic;
using System.Text;
using MLAPI.DataTypes;
using MLAPI.World.Base;
using MLAPI.World.Data;
using ProtoBuf;

namespace MLAPI.Pathfinding.TeleportationSearch
{
    /// <summary>
    /// Used to provide the world to the pathfinding algorithm.
    /// </summary>
    [ProtoContract]
    public interface IWorldProvider
    {
        Tile GetTile(Point3D location);
        void SetTile(Point3D location, Tile value);
        bool DoesTileExist(Point3D location);

        Point2D GetWorldSizeInChunks(Guid dimensionId);
        Chunk GetChunk(Point3D chunkLocation);
        Chunk GetChunkByTile(Point3D tileLocation);
        bool DoesChunkExist(Point3D location);
    }
}
