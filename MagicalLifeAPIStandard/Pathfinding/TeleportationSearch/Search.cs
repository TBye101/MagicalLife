using MagicalLifeAPI.Components.MAP_GUI;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.GUI;
using MagicalLifeAPI.Util;
using MagicalLifeAPI.World;
using MagicalLifeAPI.World.Base;
using MagicalLifeAPI.World.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Pathfinding.TeleportationSearch
{
    /// <summary>
    /// Used to do pathfinding
    /// </summary>
    public class Search : IPathFinder
    {
        public Search()
        {
        }

        public List<PathLink> GetRoute(Point3D origin, Point3D destination)
        {
            MasterLog.DebugWriteLine("Path from: " + origin.ToString() + " " + destination.ToString());
            MasterLog.DebugWriteLine("Estimated distance: " + MathUtil.GetDistance(origin, destination).ToString());
            GC.Collect();
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
                SortedList<Point3D, ExtraNodeData> open = new SortedList<Point3D, ExtraNodeData>();
                SortedList<Point3D, ExtraNodeData> closed = new SortedList<Point3D, ExtraNodeData>();

                ExtraNodeData firstData = new ExtraNodeData(0, this.CalculateHScoreSameDim(origin, destination), origin);
                open.Add(firstData.NodeLocation, firstData);

                while (open.Count > 0)
                {
                    Point3D lowestFKey = open.Keys[open.Count - 1];
                    open.TryGetValue(lowestFKey, out ExtraNodeData value);

                    if (lowestFKey.Equals(destination))
                    {
                        MasterLog.DebugWriteLine("Open nodes: " + open.Count.ToString());
                        MasterLog.DebugWriteLine("Closed nodes: " + closed.Count.ToString());

                        return this.ReconstructPath(lowestFKey, value, open, closed, origin);
                    }
                    else
                    {
                        open.Remove(lowestFKey);
                        closed.Add(lowestFKey, value);

                        Tile tile = World.Data.World.GetTile(value.NodeLocation);
                        foreach (Point3D item in this.CalculateConnections(tile))
                        {
                            Tile neighborTile = World.Data.World.GetTile(item);
                            ExtraNodeData extraNeighborData;

                            bool inOpen = open.TryGetValue(item, out ExtraNodeData neighborData);

                            if (!inOpen)
                            {
                                bool inClosed = closed.TryGetValue(item, out ExtraNodeData closedNeighborData);

                                if (!inClosed)
                                {
                                    extraNeighborData = new ExtraNodeData(value.GScore + neighborTile.MovementCost, this.CalculateHScoreSameDim(item, destination), item);
                                    open.Add(item, extraNeighborData);
                                }
                                else
                                {
                                    extraNeighborData = closedNeighborData;
                                }
                            }
                            else
                            {
                                extraNeighborData = neighborData;
                            }
                        }
                    }
                }
            }

            return null;
        }

        private List<PathLink> ReconstructPath(Point3D lastNode, ExtraNodeData value, SortedList<Point3D, ExtraNodeData> open, SortedList<Point3D, ExtraNodeData> closed, Point3D origin)
        {
            List<Point3D> links = new List<Point3D>();

            Tile dataNode = World.Data.World.GetTile(lastNode);
            Point3D location = lastNode;

            while (!location.Equals(origin))
            {
                links.Add(location);
                location = this.GetLowestGScore(this.CalculateConnections(dataNode), open, closed);
                dataNode = World.Data.World.GetTile(location);
            }

            links.Add(origin);

            List<PathLink> path = new List<PathLink>(links.Count + 1);

            int length = links.Count;
            for (int i = length - 1; i > 0; i--)
            {
                path.Add(new PathLink(links[i], links[i - 1]));
            }

            return path;
        }

        private Point3D GetLowestGScore(List<Point3D> connections, SortedList<Point3D, ExtraNodeData> open, SortedList<Point3D, ExtraNodeData> closed)
        {
            int length = connections.Count;
            ExtraNodeData lowestGNode = default;
            lowestGNode.GScore = int.MaxValue;

            for (int i = 0; i < length; i++)
            {
                Point3D connection = connections[i];

                ExtraNodeData nodeData = this.GetNodeFromLists(connection, open, closed);
                if (!nodeData.Equals(default))
                {
                    if (nodeData.GScore < lowestGNode.GScore)
                    {
                        lowestGNode = nodeData;
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

        private List<Point3D> CalculateConnections(Tile tile)
        {
            Point3D location = tile.GetExactComponent<ComponentSelectable>().MapLocation;
            List<Point3D> neighbors = this.DiagnolFavorNeighboringTiles(location, location.DimensionID);

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

                for (int i = neighbors.Count - 1; i > -1; i--)
                {
                    if (!WorldUtil.DoesTileExist(neighbors[i]))
                    {
                        neighbors.RemoveAt(i);
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
            List<Point3D> neighbors = new List<Point3D>(8)
            {
                new Point3D(tileLocation.X + 1, tileLocation.Y + 1, dimensionID),
                new Point3D(tileLocation.X + 1, tileLocation.Y - 1, dimensionID),
                new Point3D(tileLocation.X - 1, tileLocation.Y + 1, dimensionID),
                new Point3D(tileLocation.X - 1, tileLocation.Y - 1, dimensionID),
                new Point3D(tileLocation.X + 1, tileLocation.Y, dimensionID),
                new Point3D(tileLocation.X - 1, tileLocation.Y, dimensionID),
                new Point3D(tileLocation.X, tileLocation.Y + 1, dimensionID),
                new Point3D(tileLocation.X, tileLocation.Y - 1, dimensionID)
            };

            for (int i = neighbors.Count - 1; i > -1; i--)
            {
                if (!WorldUtil.DoesTileExist(neighbors[i], dimensionID))
                {
                    neighbors.RemoveAt(i);
                }
            }

            return neighbors;
        }

        private ExtraNodeData GetNodeFromLists(Point3D node, SortedList<Point3D,
            ExtraNodeData> open, SortedList<Point3D, ExtraNodeData> closed)
        {
            bool inOpen = open.TryGetValue(node, out ExtraNodeData openValue);

            if (inOpen)
            {
                return openValue;
            }
            else
            {
                bool inClosed = closed.TryGetValue(node, out ExtraNodeData closedValue);

                if (inClosed)
                {
                    return closedValue;
                }
                else
                {
                    return default;
                }
            }
        }

        private int CalculateHScoreSameDim(Point3D node, Point3D destination)
        {
            return Math.Abs(node.X - destination.X) + Math.Abs(node.Y - destination.Y);
            //return (int)Math.Sqrt(Math.Pow(destination.X - node.X, 2) + Math.Pow(destination.Y - node.Y, 2));
            //Need to come up with a way to calculate distance between Point3D, even if they are in different dimensions.
        }

        public void Initialize(Dimension dimension)
        {
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