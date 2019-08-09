using System;
using System.Collections.Generic;
using System.Text;
using MLAPI.DataTypes;
using MLAPI.DataTypes.Collection;
using MLAPI.Pathfinding;
using MLAPI.Pathfinding.AStar.Providers;
using MLAPI.Pathfinding.TeleportationSearch;
using MLAPI.World.Data;
using MLCoreMod.Core.Resources;
using MLCoreMod.Core.Tiles;

namespace MLCoreMod.Core.WorldGeneration.Dungeon.Generation.Translator
{
    class DefaultDungeonConstructor : IDungeonConstructor
    {
        public DefaultDungeonConstructor()
        {
        }

        public void CreateRoomOrHallway(ProtoArray<Chunk> dungeonChunks, int x, int y, int width, int height)
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

        public void Setup(ProtoArray<Chunk> dungeonChunks)
        {
            this.GenerateStoneMap(dungeonChunks, Guid.NewGuid());
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

        public void ConnectRooms(ProtoArray<Chunk> dungeonChunks, List<DungeonTranslationNode> translatedNodes, Point2D entranceLocation)
        {
            IWorldProvider worldProvider = new ChunkedWorldProvider(dungeonChunks);
            IConnectionProvider connectionProvider = new MiniHallPathfinder(translatedNodes, entranceLocation);

            //Figure out which ones I want to connect
            //Then, calculate connection path and points at each room
            //Use path and make hallway
        }
    }
}
