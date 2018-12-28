using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entity.Entity;
using MagicalLifeAPI.Entity.Humanoid;
using MagicalLifeAPI.Filing;
using MagicalLifeAPI.Util;
using MagicalLifeAPI.World;
using MagicalLifeAPI.World.Data;
using MagicalLifeAPI.World.Tiles;
using System;

namespace MagicalLifeServer.ServerWorld.World
{
    /// <summary>
    /// Generates the whole map to be made out of dirt.
    /// </summary>
    public class Dirtland : DimensionGenerator
    {
        public Dirtland(int dimension) : base(dimension)
        {
        }

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
                    Dirt dirt = new Dirt(new Point2D(x, y));
                    ret[x, y] = dirt.GetName();
                    y++;
                }
                y = 0;
                x++;
            }

            return ret;
        }

        protected override void GenerateDetails(ProtoArray<Chunk> map, Random r)
        {
            int chunkWidth = map.Width;
            int chunkHeight = map.Height;

            int chunkX = StaticRandom.Rand(0, chunkWidth);
            int chunkY = StaticRandom.Rand(0, chunkHeight);

            int x = StaticRandom.Rand(0, Chunk.Width);
            int y = StaticRandom.Rand(0, Chunk.Height);

            HumanFactory hFactory = new HumanFactory();
            Point2D location = new Point2D(((chunkX * Chunk.Width) + x), (chunkY * Chunk.Height) + y);
            Human human = hFactory.GenerateHuman(location, this.Dimension, SettingsManager.PlayerSettings.Settings.PlayerID);
            map[chunkX, chunkY].Creatures.Add(human.ID, human);
        }

        protected override void GenerateLandType(string[,] biomeMap, ProtoArray<Chunk> map, Random r)
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
                            chunk.Tiles[cx, cy] = new Dirt(new Point2D((chunkWidth * x) + cx, (chunkHeight * y) + cy));
                        }
                    }
                }
            }
        }

        protected override void GenerateMinerals(ProtoArray<Chunk> map, Random r)
        {
        }

        protected override void GenerateNaturalFeatures(ProtoArray<Chunk> map, Random r)
        {
        }

        protected override void GenerateStructures(ProtoArray<Chunk> map, Random random)
        {
        }

        protected override void GenerateVegetation(ProtoArray<Chunk> map, Random r)
        {
        }
    }
}