using System;
using System.Collections.Generic;
using System.Text;
using MagicalLifeAPI.Components.Entity;
using MagicalLifeAPI.Components.MAP_GUI;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.GUI;
using MagicalLifeAPI.World;
using MagicalLifeAPI.World.Base;
using MagicalLifeAPI.World.Data;
using System.Linq;
using MagicalLifeAPI.Error.InternalExceptions;
using MagicalLifeAPI.Filing.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using MagicalLifeAPI.Util;

namespace MagicalLifeAPI.Pathfinding.TeleportationSearch
{
    //https://brilliant.org/wiki/a-star-search/
    //https://stackoverflow.com/questions/12401481/a-star-algorithm-reconstruct-path
    //https://en.wikipedia.org/wiki/A*_search_algorithm
    //https://github.com/roy-t/AStar/blob/master/Roy-T.AStar/PathFinder.cs

    public class Search : IPathFinder
    {
        //private NodeStorage Storage;
        //private readonly ConnectionAdder Cadder;

        public Search()
        {
            //this.Cadder = new ConnectionAdder();
        }

        public List<PathLink> GetRoute(Point3D origin, Point3D destination)
        {
            MasterLog.DebugWriteLine("Path from: " + origin.ToString() + " " + destination.ToString());
            MasterLog.DebugWriteLine("Estimated distance: " + MathUtil.GetDistance(origin, destination).ToString());
            Stopwatch sw = Stopwatch.StartNew();

            List<PathLink> path = this.SameDimensionRoute(origin, destination);

            sw.Stop();
            double milli = 1000;
            double elapsedMill = sw.ElapsedMilliseconds;
            double totalTime = elapsedMill / milli;
            double pathfindingVelocity = MathUtil.GetDistance(origin, destination) / totalTime;
            double timePerLink = totalTime / path.Count;

            MasterLog.DebugWriteLine("Path links: " + path.Count.ToString());
            MasterLog.DebugWriteLine("Time per link: " + timePerLink.ToString() + " seconds");
            MasterLog.DebugWriteLine("Pathfinding velocity: " + pathfindingVelocity.ToString() + " tiles/s");
            MasterLog.DebugWriteLine("Total time: " + totalTime.ToString() + " seconds");

            return path;
        }

        private List<PathLink> SameDimensionRoute(Point3D origin, Point3D destination)//Maybe weight diaganols less somehow
        {
            /*
                f(n) = total estimated cost of path through node 
                g(n) = cost so far to reach node 
                h(n) = estimated cost from  to goal. This is the heuristic part of the cost function, so it is like a guess.
            */

            if (origin.Equals(destination))
            {
                return new List<PathLink>();
            }
            else
            {
                Dimension originDim = World.Data.World.Dimensions[origin.DimensionID];

                SortedList<ExtraNodeData, Tile> open = new SortedList<ExtraNodeData, Tile>();
                SortedList<ExtraNodeData, Tile> closed = new SortedList<ExtraNodeData, Tile>();

                ExtraNodeData firstData = new ExtraNodeData(0, this.CalculateHScoreSameDim(origin, destination), null, origin);
                open.Add(firstData, originDim[origin.X, origin.Y]);

                while (open.Count > 0)
                {
                    ExtraNodeData lowestFKey = open.Keys[open.Count - 1];
                    open.TryGetValue(lowestFKey, out Tile value);

                    ComponentSelectable valueSelectable = value.GetExactComponent<ComponentSelectable>();
                    if (valueSelectable.MapLocation.Equals(destination))
                    {
                        MasterLog.DebugWriteLine("Open nodes: " + open.Count.ToString());
                        MasterLog.DebugWriteLine("Closed nodes: " + closed.Count.ToString());

                        return this.ReconstructPath(lowestFKey, value, open, closed, origin);
                    }
                    else
                    {
                        open.Remove(lowestFKey);
                        closed.Add(lowestFKey, value);


                        foreach (Point3D item in this.CalculateConnections(value))
                        {
                            Tile neighbor = World.Data.World.GetTile(item);
                            ExtraNodeData extraNeighborData;

                            int openIndexPosition = open.IndexOfValue(neighbor);

                            if (openIndexPosition == -1)
                            {
                                int closedIndexPosition = closed.IndexOfValue(neighbor);

                                if (closedIndexPosition == -1)
                                {
                                    ComponentSelectable selectable = neighbor.GetExactComponent<ComponentSelectable>();
                                    extraNeighborData = new ExtraNodeData(lowestFKey.GScore + neighbor.MovementCost, this.CalculateHScoreSameDim(selectable.MapLocation, destination), null, selectable.MapLocation);
                                    open.Add(extraNeighborData, neighbor);
                                }
                                else
                                {
                                    extraNeighborData = closed.ElementAt(closedIndexPosition).Key;
                                }
                            }
                            else
                            {
                                extraNeighborData = open.ElementAt(openIndexPosition).Key;
                            }
                        }
                    }
                }
            }

            return null;
        }

        private Point3D GetLowestGScore(List<Point3D> connections, SortedList<ExtraNodeData, Tile> open, SortedList<ExtraNodeData, Tile> closed)
        {
            int length = connections.Count;
            ExtraNodeData lowestGNode = default;
            lowestGNode.GScore = int.MaxValue;


            for (int i = 0; i < length; i++)
            {
                Point3D connection = connections[i];
                Tile connectedNode = World.Data.World.GetTile(connection);

                KeyValuePair<ExtraNodeData, Tile> nodeData = this.GetNodeFromLists(connectedNode, open, closed);
                if (!nodeData.Equals(default(KeyValuePair<ExtraNodeData, Tile>)))
                {
                    if (nodeData.Key.GScore < lowestGNode.GScore)
                    {
                        lowestGNode = nodeData.Key;
                    }
                }
            }

            if (lowestGNode.Equals(default(KeyValuePair<ExtraNodeData, Tile>)))
            {
                return null;
            }
            else
            {
                return lowestGNode.NodeLocation;
            }
        }

        /// <summary>
        /// Reconstructs the path from the first node and the open and closed list.
        /// </summary>
        /// <param name="firstNodeData"></param>
        /// <param name="open"></param>
        /// <param name="closed"></param>
        /// <returns></returns>
        private List<PathLink> ReconstructPath(ExtraNodeData lastNodeData, Tile lastNode, SortedList<ExtraNodeData, Tile> open, SortedList<ExtraNodeData, Tile> closed, Point3D origin)
        {
            List<Point3D> links = new List<Point3D>();

            ComponentSelectable selectable = lastNode.GetExactComponent<ComponentSelectable>();
            Tile dataNode = lastNode;

            while (!selectable.MapLocation.Equals(origin))
            {
                links.Add(selectable.MapLocation);
                Point3D lowest = this.GetLowestGScore(this.CalculateConnections(dataNode), open, closed);
                dataNode = dataNode = World.Data.World.GetTile(lowest);
                selectable = dataNode.GetExactComponent<ComponentSelectable>();
            }

            links.Add(origin);

            List<PathLink> path = new List<PathLink>();

            int length = links.Count;
            for (int i = length - 1; i > 0; i--)
            {
                path.Add(new PathLink(links[i], links[i - 1]));
            }

            return path;
        }

        private List<Point3D> CalculateConnections(Tile tile)
        {
            Point3D location = tile.GetExactComponent<ComponentSelectable>().MapLocation;
            List<Point3D> neighbors = this.DiagnolFavorNeighboringTiles(location, location.DimensionID);
            Dimension dim = World.Data.World.Dimensions[location.DimensionID];

            if (tile.IsWalkable)
            {
                for (int i = neighbors.Count - 1; i > -1; i--)
                {
                    Tile t = World.Data.World.GetTile(neighbors[i]);
                    if (!t.IsWalkable)
                    {
                        neighbors.RemoveAt(i);
                    }
                }

                GameObject ceiling = tile.Ceiling;
                GameObject floor = tile.Floor;
                GameObject mainObject = tile.MainObject;

                if (ceiling != null)
                {
                    PortalComponent ceilingPortals = ceiling.GetComponent<PortalComponent>();

                    if (ceilingPortals != null)
                    {
                        neighbors.AddRange(ceilingPortals.Connections);
                    }
                }

                if (floor != null)
                {
                    PortalComponent floorPortals = floor.GetComponent<PortalComponent>();
                    if (floorPortals != null)
                    {
                        neighbors.AddRange(floorPortals.Connections);
                    }
                }

                if (mainObject != null)
                {
                    PortalComponent mainObjectPortals = mainObject.GetComponent<PortalComponent>();
                    if (mainObjectPortals != null)
                    {
                        neighbors.AddRange(mainObjectPortals.Connections);
                    }
                }

                return neighbors;
            }

            return new List<Point3D>();
        }

        /// <summary>
        /// Gets all of the neighbors, but returns diagnol neighbors first.
        /// </summary>
        /// <param name="tileLocation"></param>
        /// <param name="dimension"></param>
        /// <returns></returns>
        private List<Point3D> DiagnolFavorNeighboringTiles(Point3D tileLocation, Guid dimensionID)
        {
            List<Point3D> neighbors = new List<Point3D>(8);
            neighbors.Add(new Point3D(tileLocation.X + 1, tileLocation.Y + 1, dimensionID));
            neighbors.Add(new Point3D(tileLocation.X + 1, tileLocation.Y - 1, dimensionID));
            neighbors.Add(new Point3D(tileLocation.X - 1, tileLocation.Y + 1, dimensionID));
            neighbors.Add(new Point3D(tileLocation.X - 1, tileLocation.Y - 1, dimensionID));
            neighbors.Add(new Point3D(tileLocation.X + 1, tileLocation.Y, dimensionID));
            neighbors.Add(new Point3D(tileLocation.X - 1, tileLocation.Y, dimensionID));
            neighbors.Add(new Point3D(tileLocation.X, tileLocation.Y + 1, dimensionID));
            neighbors.Add(new Point3D(tileLocation.X, tileLocation.Y - 1, dimensionID));

            for (int i = neighbors.Count - 1; i > -1; i--)
            {
                if (!WorldUtil.DoesTileExist(neighbors[i], dimensionID))
                {
                    neighbors.RemoveAt(i);
                }
            }

            return neighbors;
        }

        private KeyValuePair<ExtraNodeData, Tile> GetNodeFromLists(Tile node, SortedList<ExtraNodeData,
            Tile> open, SortedList<ExtraNodeData, Tile> closed)
        {
            int openIndex = open.IndexOfValue(node);

            if (openIndex == -1)
            {
                int closedIndex = closed.IndexOfValue(node);

                if (closedIndex == -1)
                {
                    return default;
                }
                else
                {
                    return closed.ElementAt(closedIndex);
                }
            }
            else
            {
                return open.ElementAt(openIndex);
            }
        }

        private int CalculateHScoreSameDim(Point3D node, Point3D destination)
        {
            //return Math.Abs(node.X - destination.X) + Math.Abs(node.Y - destination.Y);
            return (int)Math.Sqrt(Math.Pow(destination.X - node.X, 2) + Math.Pow(destination.Y - node.Y, 2));
            //Need to come up with a way to calculate distance between Point3D, even if they are in different dimensions.
        }

        public void Initialize(Dimension dimension)
        {
            GC.Collect();

            Stopwatch sw = Stopwatch.StartNew();

            //if (this.Storage == null)
            //{
            //    this.Storage = new NodeStorage(dimension.Width * Chunk.Width * dimension.Height * Chunk.Height);
            //}

            //I think I'll need to add all nodes from all dimensions to storage first before I can add connections.
            //Maybe
            //foreach (Tile item in dimension)
            //{
            //    ComponentSelectable selectable = item.GetExactComponent<ComponentSelectable>();
            //    SearchNode newNode = new SearchNode(selectable.MapLocation, item.MovementCost, true, item.IsVisible);
            //    this.Storage.AddNode(newNode);
            //}


            //foreach (Tile item in dimension)
            //{
            //    ComponentSelectable selectable = item.GetExactComponent<ComponentSelectable>();
            //    this.AddConnections(selectable.MapLocation);//This gets more expensive as time goes on
            //}

            sw.Stop();
            double milli = 1000;
            double elapsedMill = sw.ElapsedMilliseconds;
            double initTime = (elapsedMill / milli);
            double aveTileTime = ((elapsedMill / (dimension.Width * dimension.Height)) / milli);

            MasterLog.DebugWriteLine("Initialization time for dimension: " + initTime.ToString() + " seconds");
            MasterLog.DebugWriteLine("Dimension size: " + (dimension.Width * Chunk.Width).ToString() + "X" + (dimension.Height * Chunk.Height).ToString());
            MasterLog.DebugWriteLine("Average time per tile: " + aveTileTime.ToString() + " seconds");
        }

        public bool IsRoutePossible(Point3D origin, Point3D destination)
        {
            return true;
        }

        public void RemoveConnections(Point3D location)
        {
            //this.Storage.RemoveAllConnections(location);
        }

        public void AddConnections(Point3D location)
        {
            //this.Cadder.AddConnections(location, this.Storage);
        }
    }
}
