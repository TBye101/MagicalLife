using System;
using System.Collections.Generic;
using System.Text;
using MLAPI.DataTypes;
using MLAPI.DataTypes.Collection;
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
            for (int i = 1; i < width; i++)
            {
                for (int j = 1; j < height; j++)
                {
                    int chunkX = i / Chunk.Width;
                    int chunkY = j / Chunk.Height;
                    int tileX = i % Chunk.Width;
                    int tileY = j % Chunk.Height;
                    Chunk chunk = dungeonChunks[chunkX, chunkY];
                    chunk.Tiles[tileX, tileY].MainObject = null;
                }
            }
        }

        public void Setup(ProtoArray<Chunk> dungeonChunks)
        {
            this.GenerateStoneMap(dungeonChunks, Guid.NewGuid());
        }

        private ProtoArray<Chunk> GenerateStoneMap(ProtoArray<Chunk> chunks, Guid dimensionID)
        {
            for (int i = chunks.Data.Length - 1; i > -1; i--)
            {
                Chunk chunk = chunks.Data[i];
                chunk = this.GenerateStone(chunk, dimensionID);
            }

            return chunks;
        }

        private Chunk GenerateStone(Chunk chunk, Guid dimensionID)
        {
            int startingX = chunk.ChunkLocation.X * Chunk.Width;
            int startingY = chunk.ChunkLocation.Y * Chunk.Height;

            for (int x = 0; x < Chunk.Width; x++)
            {
                for (int y = 0; y < Chunk.Height; y++)
                {
                    int tileX = x + startingX;
                    int tileY = y + startingY;
                    Dirt dirt = new Dirt(new Point3D(tileX, tileY, dimensionID));
                    dirt.MainObject = new Rock(100);

                    chunk.Tiles[x, y] = dirt;
                }
            }

            return chunk;
        }
    }
}
