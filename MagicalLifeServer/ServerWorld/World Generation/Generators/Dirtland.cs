using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entities.Entity_Factory;
using MagicalLifeAPI.Util;
using MagicalLifeAPI.World;
using MagicalLifeAPI.World.Data;
using MagicalLifeAPI.World.Tiles;
using Microsoft.Xna.Framework;
using System;

namespace MagicalLifeServer.ServerWorld.World_Generation.Generators
{
    /// <summary>
    /// Generates the whole map to be made out of dirt.
    /// </summary>
    public class Dirtland : DimensionGenerator
    {
        protected override string[,] AssignBiomes(int xSize, int ySize, Random r)
        {
            string[,] ret = new string[xSize, ySize];

            int x = 0;
            int y = 0;

            //Iterate over each row.
            for (int i = 0; i < xSize; i++)
            {
                //Iterate over each column
                for (int ii = 0; ii < ySize; ii++)
                {
                    Dirt dirt = new Dirt(new Point(x, y));
                    ret[x, y] = dirt.GetName();
                    y++;
                }
                y = 0;
                x++;
            }

            return ret;
        }

        protected override ProtoArray<Chunk> GenerateDetails(ProtoArray<Chunk> map, Random r)
        {
            int chunkWidth = map.Width;
            int chunkHeight = map.Height;

            int chunkX = StaticRandom.Rand(0, chunkWidth);
            int chunkY = StaticRandom.Rand(0, chunkHeight);

            int x = StaticRandom.Rand(0, Chunk.Width);
            int y = StaticRandom.Rand(0, Chunk.Height);

            HumanFactory hFactory = new HumanFactory();
            map[chunkX, chunkY].Creatures.Add(hFactory.GenerateHuman(new Point((chunkX * Chunk.Width) + x), (chunkY * Chunk.Height) + y));

            return map;
        }

        protected override ProtoArray<Chunk> GenerateLandType(string[,] biomeMap, Random r)
        {
            int xSize = biomeMap.GetLength(0);
            int ySize = biomeMap.GetLength(1);

            int chunkHeight = Chunk.Height;
            int chunkWidth = Chunk.Width;

            ProtoArray<Chunk> ret = new ProtoArray<Chunk>(xSize, ySize);

            for (int x = 0; x < xSize; x++)
            {
                for (int y = 0; y < ySize; y++)
                {
                    for (int cx = 0; cx < chunkWidth; cx++)
                    {
                        Chunk chunk = ret[x, y];

                        for (int cy = 0; cy < chunkHeight; cy++)
                        {
                            chunk.Tiles[cx, cy] = new Dirt(new Point((chunkWidth * x) + cx, (chunkHeight * y) + cy));
                        }
                    }
                }
            }

            return ret;
        }

        protected override ProtoArray<Chunk> GenerateMinerals(ProtoArray<Chunk> map, Random r)
        {
            return map;
        }

        protected override ProtoArray<Chunk> GenerateNaturalFeatures(ProtoArray<Chunk> map, Random r)
        {
            return map;
        }

        protected override ProtoArray<Chunk> GenerateStructures(ProtoArray<Chunk> map, Random random)
        {
            return map;
        }

        protected override ProtoArray<Chunk> GenerateVegetation(ProtoArray<Chunk> map, Random r)
        {
            return map;
        }
    }
}