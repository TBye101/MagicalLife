using System;
using System.Collections.Generic;
using System.Diagnostics;
using MLAPI.Components;
using MLAPI.DataTypes;
using MLAPI.Filing.Logging;
using MLAPI.Util.Math;
using MLAPI.World;
using MLAPI.World.Base;
using Dimension = MLAPI.World.Data.Dimension;

namespace MLAPI.Pathfinding.TeleportationSearch
{
    /// <summary>
    /// Used to do pathfinding
    /// </summary>
    public class DynamicAStar : IPathFinder
    {
        public DynamicAStar()
        {
        }

        public List<PathLink> GetRoute(Point3D origin, Point3D destination, IConnectionProvider connectionProvider, IWorldProvider worldProvider)
        {
            MasterLog.DebugWriteLine("Path from: " + origin.ToString() + " " + destination.ToString());
            MasterLog.DebugWriteLine("Estimated distance: " + MathUtil.GetDistance(origin, destination));
            //GC.Collect();
            Stopwatch sw = Stopwatch.StartNew();

            List<PathLink> path = this.SameDimensionRoute(origin, destination, connectionProvider, worldProvider);

            sw.Stop();

            if (path == null)
            {
                MasterLog.DebugWriteLine("No Path found / Error");
            }
            else
            {
                const double milliseconds = 1000;
                double elapsedMill = sw.ElapsedMilliseconds;
                double totalTime = elapsedMill / milliseconds;
                double pathfindingVelocity = MathUtil.GetDistance(origin, destination) / totalTime;
                double timePerLink = totalTime / path.Count;

                MasterLog.DebugWriteLine("Path links: " + path.Count);
                MasterLog.DebugWriteLine("Time per link: " + timePerLink + " seconds");
                MasterLog.DebugWriteLine("Pathfinding velocity: " + pathfindingVelocity + " tiles/s");
                MasterLog.DebugWriteLine("Total time: " + totalTime + " seconds");
            }

            return path;
        }

        private List<PathLink> SameDimensionRoute(Point3D origin, Point3D destination, IConnectionProvider connectionProvider, IWorldProvider worldProvider)
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

                        return this.ReconstructPath(lowestFKey, value, open, closed, origin, connectionProvider, worldProvider);
                    }
                    else
                    {
                        open.Remove(lowestFKey);
                        closed.Add(lowestFKey, value);

                        Tile tile = worldProvider.GetTile(value.NodeLocation);
                        foreach (Point3D item in connectionProvider.CalculateConnections(tile, worldProvider, origin, destination))
                        {
                            Tile neighborTile = worldProvider.GetTile(item);
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

        private List<PathLink> ReconstructPath(Point3D lastNode, ExtraNodeData value, SortedList<Point3D, ExtraNodeData> open,
            SortedList<Point3D, ExtraNodeData> closed, Point3D origin, IConnectionProvider connectionProvider, IWorldProvider worldProvider)
        {
            List<Point3D> links = new List<Point3D>();

            Tile dataNode = worldProvider.GetTile(lastNode);
            Point3D location = lastNode;

            while (!location.Equals(origin))
            {
                links.Add(location);
                location = this.GetLowestGScore(connectionProvider.CalculateConnections(dataNode, worldProvider, lastNode, origin), open, closed);

                if (location == null)
                {
                    return null;
                }
                dataNode = worldProvider.GetTile(location);
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

            if (lowestGNode.Equals(default))
            {
                return null;
            }
            else
            {
                return lowestGNode.NodeLocation;
            }
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
            //Need to come up with a way to calculate distance between Point3D, even if they are in different dimensions.
        }

        public void Initialize(Dimension dimension)
        {
        }

        public void RemoveConnections(Point3D location, IConnectionProvider connectionProvider, IWorldProvider worldProvider)
        {
            //Don't need to manually remove connections for this algorithm.
        }

        public void AddConnections(Point3D location, IConnectionProvider connectionProvider, IWorldProvider worldProvider)
        {
            //Don't need to manually add connections for this algorithm.
        }

        public bool IsRoutePossible(Point3D origin, Point3D destination, IConnectionProvider connectionProvider, IWorldProvider worldProvider)
        {
            return this.GetRoute(origin, destination, connectionProvider, worldProvider) != null;
        }
    }
}