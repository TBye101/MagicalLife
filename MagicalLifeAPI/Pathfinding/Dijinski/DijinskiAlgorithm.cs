using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DijkstraAlgorithm.Graphing;
using DijkstraAlgorithm.Pathing;
using MagicalLifeAPI.Entities;
using MagicalLifeAPI.World;
using Microsoft.Xna.Framework;

namespace MagicalLifeAPI.Pathfinding.Dijinski
{
    /// <summary>
    /// Use the dijinski algorithm we were, but modified it to use points in string form, and accept dynamically calculated movement costs.
    /// </summary>
    public class DijinskiAlgorithm : IPathFinder
    {

        /// <summary>
        /// Holds data that describes which tiles connect to which tiles.
        /// This graph contains data used to pathfind for the standard movement.
        /// </summary>
        private static GraphBuilder tileConnectionGraph = new GraphBuilder();

        private static Graph builtGraph;

        /// <summary>
        /// Used to determine the fastest route between two points.
        /// </summary>
        private static PathFinder pathFinder;

        public List<PathLink> GetRoute(World.World world, Living living, Point origin, Point destination)
        {
            Path path = pathFinder.FindShortestPath(
    builtGraph.Nodes.Single(node => node.Id == origin.ToString()),
    builtGraph.Nodes.Single(node => node.Id == destination.ToString()));

            return Convert(path);
        }

        private List<PathLink> Convert(Path path)
        {
            List<PathLink> ret = new List<PathLink>();
            foreach (PathSegment item in path.Segments)
            {
                Point origin = WorldUtil.GetTileByID(World.World.mainWorld.Tiles, item.Origin.Id).Location;
                Point endpoint = WorldUtil.GetTileByID(World.World.mainWorld.Tiles, item.Destination.Id).Location;

                PathLink a = new PathLink(origin, endpoint);
                ret.Add(a);
            }

            return ret;
        }

        /// <summary>
        /// Returns the fastest route between the source and destination tiles.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public static Path GetFastestPath(Tile source, Tile destination)
        {
            Path path = pathFinder.FindShortestPath(
                builtGraph.Nodes.Single(node => node.Id == source.Location.ToString()),
                builtGraph.Nodes.Single(node => node.Id == destination.Location.ToString()));
            return path;
        }

        /// <summary>
        /// Populates the <see cref="tileConnectionGraph"/> with data.
        /// This should be called once after the world is generated.
        /// </summary>
        /// <param name="world"></param>
        public static void BuildPathGraph(World.World world)
        {
            AddNodes(world);
            AddLinkes(world);
            builtGraph = tileConnectionGraph.Build();
            pathFinder = new PathFinder(builtGraph);
        }

        /// <summary>
        /// Creates connections between tiles in the <see cref="tileConnectionGraph"/>.
        /// </summary>
        /// <param name="world"></param>
        private static void AddLinkes(World.World world)
        {
            Tile[,] tiles = world.Tiles;
            int xSize = tiles.GetLength(0);
            int ySize = tiles.GetLength(1);

            int x = 0;
            int y = 0;

            //Iterate over each row.
            for (int i = 0; i < xSize; i++)
            {
                //Iterate over each column
                for (int ii = 0; ii < ySize; ii++)
                {
                    AddNeighborLink(1, 0, tiles, tiles[x, y]);
                    AddNeighborLink(-1, 0, tiles, tiles[x, y]);
                    AddNeighborLink(0, 1, tiles, tiles[x, y]);
                    AddNeighborLink(0, -1, tiles, tiles[x, y]);
                    AddNeighborLink(1, 1, tiles, tiles[x, y]);
                    AddNeighborLink(1, -1, tiles, tiles[x, y]);
                    AddNeighborLink(-1, 1, tiles, tiles[x, y]);
                    AddNeighborLink(-1, -1, tiles, tiles[x, y]);
                    y++;
                }
                y = 0;
                x++;
            }
        }

        /// <summary>
        /// Adds a link to a neighboring tile if the tile exists/is in bounds.
        /// </summary>
        /// <param name="xChange"></param>
        /// <param name="yChange"></param>
        /// <param name="zChange"></param>
        /// <param name="tiles"></param>
        /// <param name="source"></param>
        private static void AddNeighborLink(int xChange, int yChange, Tile[,] tiles, Tile source)
        {
            int x = (int)source.Location.X;
            int y = (int)source.Location.Y;

            if (x + xChange > -1 && x + xChange < tiles.GetLength(0))
            {
                x += xChange;
            }
            else
            {
                //The neighboring tile didn't exist.
                return;
            }

            if (y + yChange > -1 && y + yChange < tiles.GetLength(1))
            {
                y += yChange;
            }
            else
            {
                //The neighboring tile didn't exist.
                return;
            }

            tileConnectionGraph.AddLink(source.Location.ToString(), tiles[x, y].Location.ToString(), 101 - tiles[x, y].MovementCost);
        }

        /// <summary>
        /// Adds tiles as nodes into the <see cref="tileConnectionGraph"/>.
        /// </summary>
        /// <param name="world"></param>
        private static void AddNodes(World.World world)
        {
            Tile[,] tiles = world.Tiles;
            int xSize = tiles.GetLength(0);
            int ySize = tiles.GetLength(1);

            int x = 0;
            int y = 0;

            //Iterate over each row.
            for (int i = 0; i < xSize; i++)
            {
                //Iterate over each column
                for (int ii = 0; ii < ySize; ii++)
                {
                    tileConnectionGraph.AddNode(tiles[x, y].Location.ToString());
                    y++;
                }
                y = 0;
                x++;
            }
        }

        public void Initialize()
        {
            AddNodes(World.World.mainWorld);
            AddLinkes(World.World.mainWorld);
            builtGraph = tileConnectionGraph.Build();
            pathFinder = new PathFinder(builtGraph);
        }
    }
}
