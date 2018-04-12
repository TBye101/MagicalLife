using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DijkstraTools;
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
        private Graph<Point> Graph;

        private PathFinder<Point> PathFinder;

        private List<Vertex<Point>> Vertices = new List<Vertex<Point>>();


        public void AddConnections(Point location)
        {
            List<Point> neighbors;
            Tile[,] tiles = World.World.mainWorld.Tiles;
            neighbors = WorldUtil.GetNeighboringTiles(location);

            foreach (Point point in neighbors)
            {
                if (tiles[point.X, point.Y].IsWalkable)
                {
                    this.Graph.AddEdge(new Vertex<Point>(location), new Vertex<Point>(point), true, tiles[point.X, point.Y].MovementCost);
                }
            }
        }

        public List<PathLink> GetRoute(World.World world, Living living, Point origin, Point destination)
        {
            Vertex<Point> start = this.Vertices.Find(x => x.Value.X == origin.X && x.Value.Y == origin.Y);
            Vertex<Point> end = this.Vertices.Find(x => x.Value.X == destination.X && x.Value.Y == destination.Y);

            Path<Point> path = this.PathFinder.CalculateDijkstraPath(start, end);
            List<PathLink> ret = new List<PathLink>();

            foreach (Edge<Point> item in path.GetCopyOfEdgeList())
            {
                ret.Add(new PathLink(item.VertexFrom.Value, item.VertexTo.Value));
            }

            return ret;
        }

        public void Initialize()
        {
            Tile[,] tiles = World.World.mainWorld.Tiles;

            //Add nodes
            foreach (Tile item in tiles)
            {
                this.Vertices.Add(new Vertex<Point>(item.Location));
            }

            this.Graph = new Graph<Point>(this.Vertices);

            //add connections between the nodes
            foreach (Tile item in tiles)
            {
                this.AddConnections(item.Location);
            }

            this.PathFinder = new PathFinder<Point>(this.Graph);
        }

        public void RemoveConnections(Point location)
        {
            if (this.Graph.ContainsVertex(new Vertex<Point>(location)))
            {
                this.Graph.RemoveVertex(new Vertex<Point>(location));
            }
        }
    }
}
