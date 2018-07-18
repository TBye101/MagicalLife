using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entities.Entity_Factory;
using MagicalLifeAPI.Entities.Humanoid;
using MagicalLifeAPI.Util;
using MagicalLifeAPI.World;
using MagicalLifeAPI.World.Data;
using MagicalLifeAPI.World.Resources;
using MagicalLifeAPI.World.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeServer.ServerWorld.World_Generation.Generators
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
            int chunkWidth = map.Width;
            int chunkHeight = map.Height;

            int chunkX = StaticRandom.Rand(0, chunkWidth);
            int chunkY = StaticRandom.Rand(0, chunkHeight);

            int x = StaticRandom.Rand(0, Chunk.Width);
            int y = StaticRandom.Rand(0, Chunk.Height);

            while (map[chunkX, chunkY].Tiles[x, y].Resources != null)
            {
                chunkX = StaticRandom.Rand(0, chunkWidth);
                chunkY = StaticRandom.Rand(0, chunkHeight);

                x = StaticRandom.Rand(0, Chunk.Width);
                y = StaticRandom.Rand(0, Chunk.Height);
            }

            HumanFactory hFactory = new HumanFactory();
            Point2D entityLocation = new Point2D(((chunkX * Chunk.Width) + x), (chunkY * Chunk.Height) + y);
            Human human = hFactory.GenerateHuman(entityLocation, this.Dimension);

            map[chunkX, chunkY].Creatures.Add(human);
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
                            if (random.Next(15) == 2)
                            {
                                tile = new Dirt(new Point2D((chunkWidth * x) + cx, (chunkHeight * y) + cy));
                            }
                            else
                            {
                                tile = new Grass(new Point2D((chunkWidth * x) + cx, (chunkHeight * y) + cy));
                            }

                            //if (random.Next(4) == 2)
                            //{
                            //    tile.Resources = new MarbleResource(random.Next(25));
                            //    tile.IsWalkable = false;
                            //}

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
                    tile.GetRenderable().CalculateTexture(item.Tiles, tile.Location);
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