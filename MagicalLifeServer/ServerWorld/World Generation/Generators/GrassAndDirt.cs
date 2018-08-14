using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.World;
using MagicalLifeAPI.World.Base;
using MagicalLifeAPI.World.Data;
using MagicalLifeAPI.World.Resources;
using MagicalLifeAPI.World.Tiles;
using System;

namespace MagicalLifeServer.ServerWorld.World
{
    public class GrassAndDirt : DimensionGenerator
    {
        public GrassAndDirt(int dimension) : base(dimension)
        {
        }

        protected override string[,] AssignBiomes(int xSize, int ySize, Random random)
        {
            return new string[xSize, ySize];
        }

        protected override void GenerateDetails(ProtoArray<Chunk> map, Random random)
        {
        }

        protected override void GenerateLandType(string[,] biomeMap, ProtoArray<Chunk> map, Random random)
        {
            int xSize = biomeMap.GetLength(0);
            int ySize = biomeMap.GetLength(1);

            int chunkHeight = Chunk.Height;
            int chunkWidth = Chunk.Width;

            ProtoArray<Chunk> ret = map;

            for (int x = 0; x < xSize; x++)
            {
                for (int y = 0; y < ySize; y++)
                {
                    for (int cx = 0; cx < chunkWidth; cx++)
                    {
                        Chunk chunk = ret[x, y];

                        for (int cy = 0; cy < chunkHeight; cy++)
                        {
                            Tile tile;
                            if (random.Next(25) == 2)
                            {
                                tile = new Dirt(new Point2D((chunkWidth * x) + cx, (chunkHeight * y) + cy));
                            }
                            else
                            {
                                tile = new Grass(new Point2D((chunkWidth * x) + cx, (chunkHeight * y) + cy));
                            }

                            if (random.Next(4) == 2)
                            {
                                tile.Resources = new Stone(random.Next(25) + 1);
                                tile.IsWalkable = false;
                            }

                            chunk.Tiles[cx, cy] = tile;
                        }
                    }
                }
            }
        }

        protected override void GenerateMinerals(ProtoArray<Chunk> map, Random random)
        {
        }

        protected override void GenerateNaturalFeatures(ProtoArray<Chunk> map, Random random)
        {
            foreach (Chunk item in map)
            {
                foreach (Tile tile in item)
                {
                    tile.GetRenderable().CalculateTexture(item.Tiles, tile.MapLocation);
                }
            }
        }

        protected override void GenerateStructures(ProtoArray<Chunk> map, Random random)
        {
        }

        protected override void GenerateVegetation(ProtoArray<Chunk> map, Random random)
        {
        }
    }
}