using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.World.Data;
using MagicalLifeAPI.World.Generation.Dungeon;
using MagicalLifeAPI.World.Resources;
using MagicalLifeAPI.World.Tiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeMod.Core.WorldGeneration.HallwayGenerators
{
    public class CircularHallwayGenerator : HallwayGenerator
    {
        public CircularHallwayGenerator()
        {
        }

        public override Chunk[] GenerateHallways(Chunk[] chunks, string dimensionName, Random random, Guid dimensionID)
        {
            chunks = this.GenerateStoneMap(chunks, dimensionID);




            return chunks;
        }

        private Chunk[] GenerateStoneMap(Chunk[] chunks, Guid dimensionID)
        {
            for (int i = chunks.Length - 1; i > -1; i--)
            {
                Chunk chunk = chunks[i];
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
