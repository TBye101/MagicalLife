using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using MLAPI.DataTypes;
using MLAPI.Pathfinding.TeleportationSearch;
using MLAPI.World;
using MLAPI.World.Base;
using MLAPI.World.Data;
using ProtoBuf;
using Dimension = MLAPI.World.Data.Dimension;

namespace MLAPI.Pathfinding.AStar.Providers
{
    /// <summary>
    /// Provides access to worlds stored in the <see cref="World"/>.
    /// </summary>
    [ProtoContract]
    public class StoredWorldProvider : IWorldProvider, IEnumerable<Dimension>
    {
        [ProtoMember(1)]
        private Dictionary<Guid, Dimension> Dimensions { get; set; }

        public StoredWorldProvider(Dictionary<Guid, Dimension> dimensions)
        {
            this.Dimensions = dimensions;
        }

        protected StoredWorldProvider()
        {
            //Protobuf-net constructor
        }

        public void AddDimension(Dimension dim)
        {
            this.Dimensions.Add(dim.Id, dim);
        }

        public Dimension GetDimension(Guid dimensionId)
        {
            return this.Dimensions[dimensionId];
        }

        public bool DoesDimensionExist(Guid dimensionId)
        {
            this.Dimensions.TryGetValue(dimensionId, out Dimension value);
            return value != null;
        }

        public int GetNumberOfDimensions()
        {
            return this.Dimensions.Count;
        }

        public Tile GetTile(Point3D location)
        {
            Dimension dim = this.Dimensions[location.DimensionId];
            Chunk chunk = dim.GetChunkForLocation(location.X, location.Y);
            Point2D tileLocation = WorldUtil.CalculateTileLocationInChunk(location);
            return chunk.Tiles[tileLocation.X, tileLocation.Y];
        }

        public void SetTile(Point3D location, Tile value)
        {
            Dimension dim = this.Dimensions[location.DimensionId];
            Chunk chunk = dim.GetChunkForLocation(location.X, location.Y);
            Point2D tileLocation = WorldUtil.CalculateTileLocationInChunk(location);
            chunk.Tiles[tileLocation.X, tileLocation.Y] = value;
        }

        public bool DoesTileExist(Point3D location)
        {
            this.Dimensions.TryGetValue(location.DimensionId, out Dimension dimension);

            if (dimension == null)
            {
                return false;
            }

            return dimension.DoesTileExist(location.X, location.Y);
        }

        public Point2D GetWorldSizeInChunks(Guid dimId)
        {
            Dimension dim = this.Dimensions[dimId];
            return new Point2D(dim.Width, dim.Height);
        }

        public Chunk GetChunk(Point3D chunkLocation)
        {
            Dimension dim = this.Dimensions[chunkLocation.DimensionId];
            return dim.GetChunk(chunkLocation.X, chunkLocation.Y);
        }

        public Chunk GetChunkByTile(Point3D tileLocation)
        {
            int x = tileLocation.Y / Chunk.Width;
            int y = tileLocation.Y / Chunk.Height;
            return this.GetChunk(new Point3D(x, y, tileLocation.DimensionId));
        }

        public bool DoesChunkExist(Point3D location)
        {
            if (location.X < 0 && location.Y < 0)
            {
                return false;
            }

            Dimension dim = this.Dimensions[location.DimensionId];

            return location.X < dim.Width &&
                   location.Y < dim.Height;
        }

        public IEnumerator<Dimension> GetEnumerator()
        {
            foreach (KeyValuePair<Guid, Dimension> item in this.Dimensions)
            {
                yield return item.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
