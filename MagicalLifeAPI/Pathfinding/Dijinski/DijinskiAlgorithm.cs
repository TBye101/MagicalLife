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
        private GraphBuilder tileConnectionGraph = new GraphBuilder();

        private Graph builtGraph;

        /// <summary>
        /// Used to determine the fastest route between two points.
        /// </summary>
        private PathFinder pathFinder;

        public List<PathLink> GetRoute(World.World world, Living living, Point origin, Point destination)
        {
            Path path = this.pathFinder.FindShortestPath(
    this.builtGraph.Nodes.Single(node => node.Id == origin.ToString()),
    this.builtGraph.Nodes.Single(node => node.Id == destination.ToString()));

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
        /// Creates connections between tiles in the <see cref="tileConnectionGraph"/>.
        /// </summary>
        /// <param name="world"></param>
        private void AddLinkes(World.World world)
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
                    this.AddConnections(new Point(x, y));
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
        /// <param name="tileLocation"></param>
        //private void AddNeighborLink(int xChange, int yChange, Point tileLocation)
        //{
        //    int x = tileLocation.X;
        //    int y = tileLocation.Y;
        //    Tile[,] tiles = World.World.mainWorld.Tiles;

        //    if (x + xChange > -1 && x + xChange < tiles.GetLength(0))
        //    {
        //        x += xChange;
        //    }
        //    else
        //    {
        //        //The neighboring tile didn't exist.
        //        return;
        //    }

        //    if (y + yChange > -1 && y + yChange < tiles.GetLength(1))
        //    {
        //        y += yChange;
        //    }
        //    else
        //    {
        //        //The neighboring tile didn't exist.
        //        return;
        //    }

        //    this.tileConnectionGraph.AddLink(tileLocation.ToString(), tiles[x, y].Location.ToString(), 101 - tiles[x, y].MovementCost);
        //}

        /// <summary>
        /// Adds tiles as nodes into the <see cref="tileConnectionGraph"/>.
        /// </summary>
        /// <param name="world"></param>
        private void AddNodes(World.World world)
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
                    this.tileConnectionGraph.AddNode(tiles[x, y].Location.ToString());
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
            this.builtGraph = this.tileConnectionGraph.Build();
            this.pathFinder = new PathFinder(this.builtGraph);
        }

        public void RemoveConnections(Point location)
        {

        }
        
        /// <summary>
        /// Returns the location within the <see cref="builtGraph"/> of the specified location.
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        private int GetGraphIndex(Point location)
        {
            //0123
            //4567
            //8

            //1, 2
            return ((location.X * World.World.mainWorld.Tiles.GetLength(0)) + location.Y + 1);
        }

        public void AddConnections(Point location)
        {
            List<Point> neighbors = WorldUtil.GetNeighboringTiles(location);

            foreach (Point item in neighbors)
            {
                this.tileConnectionGraph.AddLink(location.ToString(), item.ToString(), 101 - World.World.mainWorld.Tiles[item.X, item.Y].MovementCost);
            }
        }
    }
}
