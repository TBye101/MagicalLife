using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entities.Entity_Factory;
using MagicalLifeAPI.Util;
using MagicalLifeAPI.World;
using MagicalLifeAPI.World.Resources;
using MagicalLifeAPI.World.Tiles;
using Microsoft.Xna.Framework;
using System;

namespace MagicalLifeServer.ServerWorld.World_Generation.Generators
{
    /// <summary>
    /// A world generator that throws in a sprinkle of stone.
    /// </summary>
    public class StoneSprinkle : WorldGenerator
    {
        public override string[,] AssignBiomes(int xSize, int ySize, Random random)
        {
            string[,] ret = new string[xSize, ySize];//We don't need biomes right now
            return ret;
        }

        public override ProtoArray<Tile> GenerateDetails(ProtoArray<Tile> map, Random random)
        {
            int xSize = map.Width;
            int ySize = map.Height;

            int x = StaticRandom.Rand(0, xSize);
            int y = StaticRandom.Rand(0, ySize);

            HumanFactory hFactory = new HumanFactory();
            map[x, y].Living = (hFactory.GenerateHuman(new Point(x, y)));

            return map;
        }

        public override ProtoArray<Tile> GenerateLandType(string[,] biomeMap, Random random)
        {
            int x = 0;
            int y = 0;
            int xSize = biomeMap.GetLength(0);
            int ySize = biomeMap.GetLength(1);

            ProtoArray<Tile> tiles = new ProtoArray<Tile>(xSize, ySize);

            while (x < xSize)
            {
                while (y < ySize)
                {
                    Dirt dirt = new Dirt(new Point(x, y));

                    if (random.Next(4) == 2)
                    {
                        dirt.Resources = new MarbleResource(random.Next(25));
                        dirt.IsWalkable = false;
                    }
                    tiles[x, y] = dirt;
                    y++;
                }
                x++;
                y = 0;
            }

            return tiles;
        }

        public override ProtoArray<Tile> GenerateMinerals(ProtoArray<Tile> map, Random random)
        {
            return map;
        }

        public override ProtoArray<Tile> GenerateNaturalFeatures(ProtoArray<Tile> map, Random random)
        {
            return map;
        }

        public override ProtoArray<Tile> GenerateVegetation(ProtoArray<Tile> map, Random random)
        {
            return map;
        }
    }
}