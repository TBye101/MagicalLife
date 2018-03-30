using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entities.Entity_Factory;
using MagicalLifeAPI.Util;
using MagicalLifeAPI.World.Tiles;
using Microsoft.Xna.Framework;

namespace MagicalLifeAPI.World.World_Generation.Generators
{
    /// <summary>
    /// Generates the whole map to be made out of dirt.
    /// </summary>
    public class Dirtland : WorldGenerator
    {
        public override string[,] AssignBiomes(int xSize, int ySize)
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

        public override Tile[,] GenerateDetails(Tile[,] map)
        {
            int xSize = map.GetLength(0);
            int ySize = map.GetLength(1);

            int x = StaticRandom.Rand(0, xSize);
            int y = StaticRandom.Rand(0, ySize);

            HumanFactory hFactory = new HumanFactory();
            map[x, y].Living = (hFactory.GenerateHuman(new Point(x, y)));

            return map;
        }

        public override Tile[,] GenerateLandType(string[,] biomeMap)
        {
            int xSize = biomeMap.GetLength(0);
            int ySize = biomeMap.GetLength(1);

            int x = 0;
            int y = 0;

            Tile[,] ret = new Tile[xSize, ySize];

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

        public override Tile[,] GenerateMinerals(Tile[,] map)
        {
            return map;
        }

        public override Tile[,] GenerateNaturalFeatures(Tile[,] map)
        {
            return map;
        }

        public override Tile[,] GenerateVegetation(Tile[,] map)
        {
            return map;
        }
    }
}