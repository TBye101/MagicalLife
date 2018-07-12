using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entities.Entity_Factory;
using MagicalLifeAPI.Entities.Humanoid;
using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.Registry.ItemRegistry;
using MagicalLifeAPI.Util;
using MagicalLifeAPI.World;
using MagicalLifeAPI.World.Data;
using MagicalLifeAPI.World.Items;
using MagicalLifeAPI.World.Resources;
using MagicalLifeAPI.World.Tiles;
using Microsoft.Xna.Framework;
using System;

namespace MagicalLifeServer.ServerWorld.World_Generation.Generators
{
    /// <summary>
    /// A world generator that throws in a sprinkle of stone.
    /// </summary>
    public class StoneSprinkle : DimensionGenerator
    {
        public StoneSprinkle(int dimension) : base(dimension)
        {
        }

        protected override string[,] AssignBiomes(int xSize, int ySize, Random random)
        {
            string[,] ret = new string[xSize, ySize];
            return ret;
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
            Point entityLocation = new Point(((chunkX * Chunk.Width) + x), (chunkY * Chunk.Height) + y);
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
                            Dirt dirt = new Dirt(new Point((chunkWidth * x) + cx, (chunkHeight * y) + cy));
                            if (random.Next(4) == 2)
                            {
                                dirt.Resources = new MarbleResource(random.Next(25));
                                dirt.IsWalkable = false;
                            }

                            chunk.Tiles[cx, cy] = dirt;

                            if (random.Next(4) == 2 && dirt.Resources == null)
                            {
                                ItemAdder.AddItemWorldGen(new StoneChunk(0), new Point2D((chunkWidth * x) + cx, (chunkHeight * y) + cy), map, this.Dimension);
                                MasterLog.DebugWriteLine("Created stone chunk: " + dirt.Location.ToString());
                            }
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
        }

        protected override void GenerateStructures(ProtoArray<Chunk> map, Random random)
        {
        }

        protected override void GenerateVegetation(ProtoArray<Chunk> map, Random random)
        {
        }
    }
}