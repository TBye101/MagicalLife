using MagicalLifeAPI.Entities.Entity_Factory;
using MagicalLifeAPI.Util;
using MagicalLifeAPI.World.Tiles;
using System.Web.UI.DataVisualization.Charting;

namespace MagicalLifeAPI.World.World_Generation.Generators
{
    /// <summary>
    /// Generates the whole map to be made out of dirt.
    /// </summary>
    public class Dirtland : WorldGenerator
    {
        public override string[,,] AssignBiomes(int xSize, int ySize, int zSize)
        {
            string[,,] ret = new string[xSize, ySize, zSize];

            int x = 0;
            int y = 0;
            int z = 0;

            //Iterate over each row.
            for (int i = 0; i < xSize; i++)
            {
                //Iterate over each column
                for (int ii = 0; ii < ySize; ii++)
                {
                    //Iterate over the depth of each tile in the z axis.
                    for (int iii = 0; iii < zSize; iii++)
                    {
                        //Each tile can be accessed by the xyz coordinates from this inner loop properly.
                        Dirt dirt = new Dirt(new Point3D(x, y, z));
                        ret[x, y, z] = dirt.GetName();

                        z++;
                    }
                    y++;
                    z = 0;
                }
                y = 0;
                x++;
            }

            return ret;
        }

        public override Tile[,,] GenerateDetails(Tile[,,] map)
        {
            int xSize = map.GetLength(0);
            int ySize = map.GetLength(1);
            int zSize = map.GetLength(2);

            int x = StaticRandom.Rand(0, xSize);
            int y = StaticRandom.Rand(0, ySize);
            int z = zSize - 1;

            HumanFactory hFactory = new HumanFactory();
            map[x, y, z].Living.Enqueue(hFactory.GenerateHuman());

            return map;
        }

        public override Tile[,,] GenerateLandType(string[,,] biomeMap)
        {
            int xSize = biomeMap.GetLength(0);
            int ySize = biomeMap.GetLength(1);
            int zSize = biomeMap.GetLength(2);

            int x = 0;
            int y = 0;
            int z = 0;

            Tile[,,] ret = new Tile[xSize, ySize, zSize];

            //Iterate over each row.
            for (int i = 0; i < xSize; i++)
            {
                //Iterate over each column
                for (int ii = 0; ii < ySize; ii++)
                {
                    //Iterate over the depth of each tile in the z axis.
                    for (int iii = 0; iii < zSize; iii++)
                    {
                        //Each tile can be accessed by the xyz coordinates from this inner loop properly.
                        ret[x, y, z] = new Dirt(new Point3D(x, y, z));
                        z++;
                    }
                    y++;
                    z = 0;
                }
                y = 0;
                x++;
            }

            return ret;
        }

        public override Tile[,,] GenerateMinerals(Tile[,,] map)
        {
            return map;
        }

        public override Tile[,,] GenerateNaturalFeatures(Tile[,,] map)
        {
            return map;
        }

        public override Tile[,,] GenerateVegetation(Tile[,,] map)
        {
            return map;
        }
    }
}