using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLAPI.DataTypes;
using MLAPI.DataTypes.Collection;
using MLAPI.Pathfinding;
using MLAPI.Pathfinding.AStar.Providers;
using MLAPI.Pathfinding.TeleportationSearch;
using MLAPI.Util.Math;
using MLAPI.World.Data;
using MLAPI.Util;
using MLAPI.World.Base;
using MLCoreMod.Core.Resources;
using MLCoreMod.Core.Tiles;
using MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph;

namespace MLCoreMod.Core.WorldGeneration.Dungeon.Generation.Translator
{
    class DefaultDungeonConstructor : IDungeonConstructor
    {
        public DefaultDungeonConstructor()
        {
        }

        public void CreateRoomOrHallway(ProtoArray<Chunk> dungeonChunks, Guid dimensionId, int x, int y, int width, int height)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    int chunkX = (x + i) / Chunk.Width;
                    int chunkY = (y + j) / Chunk.Height;
                    int tileX = (x + i) % Chunk.Width;
                    int tileY = (y + j) % Chunk.Height;

                    if (chunkX < dungeonChunks.Width && chunkY < dungeonChunks.Height)
                    {
                        Chunk chunk = dungeonChunks[chunkX, chunkY];
                        chunk.Tiles[tileX, tileY].MainObject = null;
                    }
                }
            }
        }

        public void Setup(ProtoArray<Chunk> dungeonChunks, Guid dimensionId)
        {
            this.GenerateStoneMap(dungeonChunks, dimensionId);
        }

        private ProtoArray<Chunk> GenerateStoneMap(ProtoArray<Chunk> chunks, Guid dimensionId)
        {
            for (int i = chunks.Data.Length - 1; i > -1; i--)
            {
                Chunk chunk = chunks.Data[i];
                chunk = this.GenerateStone(chunk, dimensionId);
            }

            return chunks;
        }

        private Chunk GenerateStone(Chunk chunk, Guid dimensionId)
        {
            int startingX = chunk.ChunkLocation.X * Chunk.Width;
            int startingY = chunk.ChunkLocation.Y * Chunk.Height;

            for (int x = 0; x < Chunk.Width; x++)
            {
                for (int y = 0; y < Chunk.Height; y++)
                {
                    int tileX = x + startingX;
                    int tileY = y + startingY;
                    Dirt dirt = new Dirt(new Point3D(tileX, tileY, dimensionId));
                    dirt.MainObject = new Rock(100);

                    chunk.Tiles[x, y] = dirt;
                }
            }

            return chunk;
        }

        public void ConnectRooms(ProtoArray<Chunk> dungeonChunks, Guid dimensionId, List<DungeonTranslationNode> translatedNodes, Point2D entranceLocation)
        {
            IWorldProvider worldProvider = new ChunkedWorldProvider(dungeonChunks);
            IConnectionProvider connectionProvider = new MiniHallPathfinder(translatedNodes, entranceLocation);

            for (int index = 0; index < translatedNodes.Count; index++)
            {
                DungeonTranslationNode item = translatedNodes[index];
                List<Point2D> validRoomEntrances = this.GetValidRoomEntrances(item, translatedNodes, entranceLocation);

                for (int i = 0; i < item.DesignNode.Connections.Count; i++)
                {
                    DungeonNode connectedNode = item.DesignNode.Connections[i];
                    DungeonTranslationNode connectedTranslationNode =
                        translatedNodes.Find(x => x.DesignNode.NodeId.Equals(connectedNode.NodeId));
                    List<Point2D> validNeighborRoomEntrances = this.GetValidRoomEntrances(item, translatedNodes, entranceLocation);
                    this.TryMakeConnection(dungeonChunks, dimensionId, validRoomEntrances, validNeighborRoomEntrances, worldProvider, connectionProvider);
                }
            }
        }

        /// <summary>
        /// Tries to make a hallway connection between the two lists of valid locations.
        /// </summary>
        /// <param name="dungeonChunks"></param>
        /// <param name="validRoomEntrances"></param>
        /// <param name="validNeighborRoomEntrances"></param>
        /// <param name="worldProvider"></param>
        /// <param name="connectionProvider"></param>
        private void TryMakeConnection(ProtoArray<Chunk> dungeonChunks, Guid dimensionId, List<Point2D> validRoomEntrances,
            List<Point2D> validNeighborRoomEntrances, IWorldProvider worldProvider, IConnectionProvider connectionProvider)
        {
            for (int index = 0; index < validRoomEntrances.Count; index++)
            {
                Point2D roomEntrance = validRoomEntrances[index];
                for (int i = 0; i < validNeighborRoomEntrances.Count; i++)
                {
                    Point2D neighborEntrance = validNeighborRoomEntrances[i];
                    bool success = this.MakeHallway(roomEntrance, neighborEntrance, dimensionId, worldProvider, connectionProvider);

                    if (success)
                    {
                        return;
                    }
                }
            }
        }

        private bool MakeHallway(Point2D roomEntrance, Point2D neighborEntrance, Guid dimensionId, IWorldProvider worldProvider, IConnectionProvider connectionProvider)
        {
            Point3D roomEntrance3 = Point3D.From2D(roomEntrance, dimensionId);
            Point3D neighborEntrance3 = Point3D.From2D(neighborEntrance, dimensionId);
            List<PathLink> hallwayPath = MainPathFinder.GetRoute(roomEntrance3, neighborEntrance3, connectionProvider, worldProvider);

            if (hallwayPath != null && hallwayPath.Count > 0)
            {
                for (int index = 0; index < hallwayPath.Count; index++)
                {
                    PathLink hallwayLink = hallwayPath[index];
                    Tile destinationTile = worldProvider.GetTile(hallwayLink.Destination);
                    Tile originTile = worldProvider.GetTile(hallwayLink.Origin);
                    destinationTile.MainObject = null;
                    originTile.MainObject = null;
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        private List<Point2D> GetValidRoomEntrances(DungeonTranslationNode item, List<DungeonTranslationNode> translatedNodes, Point2D entranceLocation)
        {
            Point2D rectTopLeft = new Point2D(item.Offset.X - 1, item.Offset.Y - 1);
            Point2D rectBottomRight =
                new Point2D(item.Offset.X + item.SectionWidth + 1, item.Offset.Y + item.SectionHeight + 1);
            MagicRectangle itemRectangle = new MagicRectangle(rectTopLeft, rectBottomRight);
            List<Point2D> points = Geometry.GetAllPointsOnRectangleExceptCorners(itemRectangle);

            MagicRectangle nodeRectangle = new MagicRectangle(new Point2D(0, 0), new Point2D(0, 0));
            for (int index = 0; index < translatedNodes.Count; index++)
            {
                DungeonTranslationNode translatedNode = translatedNodes[index];
                nodeRectangle.TopLeft.X = translatedNode.Offset.X - 1;
                nodeRectangle.TopLeft.Y = translatedNode.Offset.Y - 1;
                nodeRectangle.BottomRight.X = translatedNode.Offset.X + translatedNode.SectionHeight + 1;
                nodeRectangle.BottomRight.Y = translatedNode.Offset.Y + translatedNode.SectionHeight + 1;

                if (Geometry.DoRectanglesOverlap(itemRectangle, nodeRectangle))
                {
                    points.RemoveShared<Point2D>(Geometry.GetAllPointsOnRectangle(nodeRectangle));
                }
            }

            //Translate offset coordinates to real coordinates
            for (int i = 0; i < points.Count; i++)
            {
                Point2D validEntranceLocation = points[i];
                validEntranceLocation.X += entranceLocation.X;
                validEntranceLocation.Y += entranceLocation.Y;
            }

            return points;
        }
    }
}
