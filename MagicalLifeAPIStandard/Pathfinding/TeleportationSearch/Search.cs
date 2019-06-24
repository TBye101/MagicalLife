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

namespace MagicalLifeAPI.Pathfinding.TeleportationSearch
{
    //https://brilliant.org/wiki/a-star-search/
    //https://stackoverflow.com/questions/12401481/a-star-algorithm-reconstruct-path
    //https://en.wikipedia.org/wiki/A*_search_algorithm
    //https://github.com/roy-t/AStar/blob/master/Roy-T.AStar/PathFinder.cs

    public class Search : IPathFinder
    {
        private readonly NodeStorage Storage = new NodeStorage();

        public Search()
        {
        }

        /// <summary>
        /// Gets all of the neighbors, but returns diagnol neighbors first.
        /// </summary>
        /// <param name="tileLocation"></param>
        /// <param name="dimension"></param>
        /// <returns></returns>
        private List<Point3D> DiagnolFavorNeighboringTiles(Point3D tileLocation, int dimension)
        {
            Guid dimensionID = World.Data.World.Dimensions[dimension].ID;

            List<Point3D> neighbors = new List<Point3D>();

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
                if (!WorldUtil.DoesTileExist(neighbors[i], dimension))
                {
                    neighbors.RemoveAt(i);
                }
            }

            return neighbors;
        }

        public void AddConnections(Point3D location)
        {
            int dimension = World.Data.World.Dimensions.FindIndex(x => x.ID.Equals(location.DimensionID));

            List<Point3D> neighbors = this.DiagnolFavorNeighboringTiles(location, dimension);
            Dimension dim = World.Data.World.Dimensions[dimension];

            Tile targetLocation = dim[location.X, location.Y];

            if (targetLocation.IsWalkable)
            {
                foreach (Point3D item in neighbors)
                {
                    Tile t = dim[item.X, item.Y];
                    if (t.IsWalkable)
                    {
                        this.Storage.AddConnection(location, item);
                    }
                }

                Tile tile = dim[location.X, location.Y];

                GameObject ceiling = tile.Ceiling;
                GameObject floor = tile.Floor;
                GameObject mainObject = tile.MainObject;
                List<Point3D> extraConnections = new List<Point3D>();

                if (ceiling != null)
                {
                    PortalComponent ceilingPortals = ceiling.GetComponent<PortalComponent>();

                    if (ceilingPortals != null)
                    {
                        extraConnections.AddRange(ceilingPortals.Connections);
                    }
                }

                if (floor != null)
                {
                    PortalComponent floorPortals = floor.GetComponent<PortalComponent>();
                    if (floorPortals != null)
                    {
                        extraConnections.AddRange(floorPortals.Connections);
                    }
                }

                if (mainObject != null)
                {
                    PortalComponent mainObjectPortals = mainObject.GetComponent<PortalComponent>();
                    if (mainObjectPortals != null)
                    {
                        extraConnections.AddRange(mainObjectPortals.Connections);
                    }
                }

                foreach (Point3D item in extraConnections)
                {
                    this.Storage.AddConnection(location, item);
                }
            }
        }

        public List<PathLink> GetRoute(Point3D origin, Point3D destination)
        {
            return this.SameDimensionRoute(origin, destination);
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
                SortedList<ExtraNodeData, SearchNode> open = new SortedList<ExtraNodeData, SearchNode>();
                SortedList<ExtraNodeData, SearchNode> closed = new SortedList<ExtraNodeData, SearchNode>();

                ExtraNodeData firstData = new ExtraNodeData(0, this.CalculateHScoreSameDim(origin, destination), null, origin);
                open.Add(firstData, this.Storage.GetNode(origin));

                while (open.Count > 0)
                {
                    ExtraNodeData lowestFKey = open.Keys[open.Count - 1];
                    open.TryGetValue(lowestFKey, out SearchNode value);

                    if (value.Location.Equals(destination))
                    {
                        return this.ReconstructPath(lowestFKey, value, open, closed, origin);
                    }
                    else
                    {
                        open.Remove(lowestFKey);
                        closed.Add(lowestFKey, value);


                        foreach (Point3D item in value.Connections)
                        {
                            SearchNode neighbor = this.Storage.GetNode(item);
                            ExtraNodeData extraNeighborData;

                            int openIndexPosition = open.IndexOfValue(neighbor);

                            if (openIndexPosition == -1)
                            {
                                int closedIndexPosition = closed.IndexOfValue(neighbor);

                                if (closedIndexPosition == -1)
                                {
                                    extraNeighborData = new ExtraNodeData(lowestFKey.GScore + neighbor.Cost, this.CalculateHScoreSameDim(neighbor.Location, destination), null, neighbor.Location);
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

                            if ((extraNeighborData.HScore + neighbor.Cost < lowestFKey.HScore))
                            {
                                extraNeighborData.Parent = value;
                            }
                        }
                    }
                }
            }

            return null;
        }

        private Point3D getLowestGScore(List<Point3D> connections, SortedList<ExtraNodeData, SearchNode> open, SortedList<ExtraNodeData, SearchNode> closed)
        {
            int length = connections.Count;
            ExtraNodeData lowestGNode = default;
            lowestGNode.GScore = int.MaxValue;


            for (int i = 0; i < length; i++)
            {
                Point3D connection = connections[i];
                SearchNode connectedNode = this.Storage.GetNode(connection);

                KeyValuePair<ExtraNodeData, SearchNode> nodeData = this.GetNodeFromLists(connectedNode, open, closed);
                if (!nodeData.Equals(default(KeyValuePair<ExtraNodeData, SearchNode>)))
                {
                    if (nodeData.Key.GScore < lowestGNode.GScore)
                    {
                        lowestGNode = nodeData.Key;
                    }
                }
            }

            if (lowestGNode.Equals(default(KeyValuePair<ExtraNodeData, SearchNode>)))
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
        private List<PathLink> ReconstructPath(ExtraNodeData lastNodeData, SearchNode lastNode, SortedList<ExtraNodeData, SearchNode> open, SortedList<ExtraNodeData, SearchNode> closed, Point3D origin)
        {
            List<Point3D> links = new List<Point3D>();

            //ExtraNodeData data = lastNodeData;
            SearchNode dataNode = lastNode;

            while (!dataNode.Location.Equals(origin))
            {
                links.Add(dataNode.Location);
                Point3D lowest = this.getLowestGScore(dataNode.Connections, open, closed);
                dataNode = this.Storage.GetNode(lowest);
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

        private KeyValuePair<ExtraNodeData, SearchNode> GetNodeFromLists(SearchNode node, SortedList<ExtraNodeData,
            SearchNode> open, SortedList<ExtraNodeData, SearchNode> closed)
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


            //I think I'll need to add all nodes from all dimensions to storage first before I can add connections.
            //Maybe
            foreach (Tile item in dimension)
            {
                ComponentSelectable selectable = item.GetExactComponent<ComponentSelectable>();
                Point3D tileLocation = new Point3D(selectable.MapLocation.X, selectable.MapLocation.Y, dimension.ID);
                SearchNode newNode = new SearchNode(tileLocation, item.MovementCost, true, item.IsVisible);
                this.Storage.AddNode(newNode);
            }

            int dimID = World.Data.World.Dimensions.FindIndex(x => x.ID.Equals(dimension.ID));
            foreach (Tile item in dimension)
            {
                ComponentSelectable selectable = item.GetExactComponent<ComponentSelectable>();
                Point3D tileLocation = new Point3D(selectable.MapLocation.X, selectable.MapLocation.Y, dimension.ID);
                this.AddConnections(tileLocation);//This gets more expensive as time goes on
            }

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
            this.Storage.RemoveAllConnections(location);
        }
    }
}
