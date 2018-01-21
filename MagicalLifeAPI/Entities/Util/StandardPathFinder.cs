using MagicalLifeAPI.World;
using DijkstraAlgorithm.Graphing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Entities.Util
{
    /// <summary>
    /// A class that handles the construction of the graph used to do optimal pathfinding.
    /// </summary>
    public class StandardPathFinder
    {
        /// <summary>
        /// Holds data that describes which tiles connect to which tiles.
        /// This graph contains data used to pathfind for the standard movement.
        /// </summary>
        private GraphBuilder tileConnectionGraph = new GraphBuilder();

        /// <summary>
        /// Populates the <see cref="tileConnectionGraph"/> with data.
        /// This should be called once after the world is generated.
        /// </summary>
        /// <param name="world"></param>
        public void BuildPathGraph(World.World world)
        {
            this.AddNodes(world);
            this.AddLinkes(world);
        }

        /// <summary>
        /// Creates connections between tiles in the <see cref="tileConnectionGraph"/>.
        /// </summary>
        /// <param name="world"></param>
        private void AddLinkes(World.World world)
        {
            Tile[,,] tiles = world.Tiles;
            int xSize = tiles.GetLength(0);
            int ySize = tiles.GetLength(1);
            int zSize = tiles.GetLength(2);

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
                        this.tileConnectionGraph.AddLink(tiles[x, y, z].ID.ToString(), tiles[x + 1, y, z].ID.ToString(), 101 - tiles[x, y, z].MovementCost);
                        this.tileConnectionGraph.AddLink(tiles[x, y, z].ID.ToString(), tiles[x - 1, y, z].ID.ToString(), 101 - tiles[x, y, z].MovementCost);
                        this.tileConnectionGraph.AddLink(tiles[x, y, z].ID.ToString(), tiles[x, y + 1, z].ID.ToString(), 101 - tiles[x, y, z].MovementCost);
                        this.tileConnectionGraph.AddLink(tiles[x, y, z].ID.ToString(), tiles[x, y - 1, z].ID.ToString(), 101 - tiles[x, y, z].MovementCost);
                        this.tileConnectionGraph.AddLink(tiles[x, y, z].ID.ToString(), tiles[x + 1, y + 1, z].ID.ToString(), 101 - tiles[x, y, z].MovementCost);
                        this.tileConnectionGraph.AddLink(tiles[x, y, z].ID.ToString(), tiles[x + 1, y - 1, z].ID.ToString(), 101 - tiles[x, y, z].MovementCost);
                        this.tileConnectionGraph.AddLink(tiles[x, y, z].ID.ToString(), tiles[x - 1, y + 1, z].ID.ToString(), 101 - tiles[x, y, z].MovementCost);
                        this.tileConnectionGraph.AddLink(tiles[x, y, z].ID.ToString(), tiles[x - 1, y - 1, z].ID.ToString(), 101 - tiles[x, y, z].MovementCost);
                        z++;
                    }
                    y++;
                    z = 0;
                }
                y = 0;
                x++;
            }
        }

        /// <summary>
        /// Adds tiles as nodes into the <see cref="tileConnectionGraph"/>.
        /// </summary>
        /// <param name="world"></param>
        private void AddNodes(World.World world)
        {
            Tile[,,] tiles = world.Tiles;
            int xSize = tiles.GetLength(0);
            int ySize = tiles.GetLength(1);
            int zSize = tiles.GetLength(2);

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
                        this.tileConnectionGraph.AddNode(tiles[x, y, z].ID.ToString());
                        z++;
                    }
                    y++;
                    z = 0;
                }
                y = 0;
                x++;
            }
        }
    }
}
