using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entities.Entity_Factory;
using MagicalLifeAPI.Util;
using MagicalLifeAPI.World;
using MagicalLifeAPI.World.Tiles;
using Microsoft.Xna.Framework;
using System;

namespace MagicalLifeServer.ServerWorld.World_Generation.Generators
{
    /// <summary>
    /// Generates the whole map to be made out of dirt.
    /// </summary>
    public class Dirtland : WorldGenerator
    {
        public override string[,] AssignBiomes(int xSize, int ySize, Random r)
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

        public override ProtoArray<Tile> GenerateDetails(ProtoArray<Tile> map, Random r)
        {
            int xSize = map.Width;
            int ySize = map.Height;

            int x = StaticRandom.Rand(0, xSize);
            int y = StaticRandom.Rand(0, ySize);

            HumanFactory hFactory = new HumanFactory();
            map[x, y].Living = (hFactory.GenerateHuman(new Point(x, y)));

            return map;
        }

        public override ProtoArray<Tile> GenerateLandType(string[,] biomeMap, Random r)
        {
            int xSize = biomeMap.GetLength(0);
            int ySize = biomeMap.GetLength(1);

            int x = 0;
            int y = 0;

            ProtoArray<Tile> ret = new ProtoArray<Tile>(xSize, ySize);

            //Iterate over each row.
            for (int i = 0; i < xSize; i++)
            {
                //Iterate over each column
                for (int ii = 0; ii < ySize; ii++)
                {
                    ret[x, y] = new Dirt(new Point(x, y));
                    y++;
                }
                y = 0;
                x++;
            }

            return ret;
        }

        public override ProtoArray<Tile> GenerateMinerals(ProtoArray<Tile> map, Random r)
        {
            return map;
        }

        public override ProtoArray<Tile> GenerateNaturalFeatures(ProtoArray<Tile> map, Random r)
        {
            return map;
        }

        public override ProtoArray<Tile> GenerateVegetation(ProtoArray<Tile> map, Random r)
        {
            return map;
        }
    }
}