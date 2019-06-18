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

namespace MagicalLifeAPI.Pathfinding.TeleportationSearch
{
    //https://brilliant.org/wiki/a-star-search/
	//https://stackoverflow.com/questions/12401481/a-star-algorithm-reconstruct-path
    public class Search : IPathFinder
    {
        private readonly NodeStorage Storage = new NodeStorage();

        public Search()
        {
        }

        public void AddConnections(Point3D location)
        {
            int dimension = World.Data.World.Dimensions.FindIndex(x => x.ID.Equals(location.DimensionID));

            List<Point3D> neighbors = WorldUtil.GetNeighboringTiles(location, dimension);
            Dimension dim = World.Data.World.Dimensions[dimension];
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

        public List<PathLink> GetRoute(Point3D origin, Point3D destination)
        {
            if (origin.DimensionID.Equals(destination.DimensionID))
            {
                return this.SameDimensionRoute(origin, destination);
            }
            else
            {
                return this.DifferentDimensionsRoute(origin, destination);
            }
        }

        private List<PathLink> SameDimensionRoute(Point3D origin, Point3D destination)
        {
            /*
                f(n) = total estimated cost of path through node 
                g(n) = cost so far to reach node 
                h(n) = estimated cost from  to goal. This is the heuristic part of the cost function, so it is like a guess.
            */

            bool destinationReached = false;
            SortedList<ExtraNodeData, SearchNode> open = new SortedList<ExtraNodeData, SearchNode>();
            SortedList<ExtraNodeData, SearchNode> closed = new SortedList<ExtraNodeData, SearchNode>();

            ExtraNodeData firstData = new ExtraNodeData(0, this.CalculateHScoreSameDim(origin, destination), null, origin);
            open.Add(firstData, this.Storage.GetNode(origin));

            ExtraNodeData destinationData = default;
            SearchNode lastNode = null;

            while (!destinationReached)
            {
                ExtraNodeData lowestFKey = open.Keys[open.Count - 1];
                open.TryGetValue(lowestFKey, out SearchNode value);

                if (value.Location.Equals(destination))
                {
                    destinationReached = true;
                    destinationData = lowestFKey;
                    lastNode = value;
                }
                else
                {
                    open.Remove(lowestFKey);
                    closed.Add(lowestFKey, value);
                    foreach (Point3D item in value.Connections)
                    {
                        SearchNode neighboringNode = this.Storage.GetNode(item);
                        MasterLog.DebugWriteLine("Node: " + value.Location.ToString() + " Connection: " + item.ToString());

                        if (closed.ContainsValue(neighboringNode))
                        {
                            KeyValuePair<ExtraNodeData, SearchNode> neighbor = closed.ElementAt(closed.IndexOfValue(neighboringNode));
                            if (lowestFKey.GScore < neighbor.Key.GScore)
                            {
                                ExtraNodeData key = neighbor.Key;
                                SearchNode node = neighbor.Value;

                                closed.Remove(neighbor.Key);

                                key.GScore = lowestFKey.GScore;
                                key.Parent = value;
                                closed.Add(key, node);
                            }
                        }
                        else if (open.ContainsValue(neighboringNode))
                        {
                            KeyValuePair<ExtraNodeData, SearchNode> neighbor = open.ElementAt(open.IndexOfValue(neighboringNode));

                            if (lowestFKey.GScore < neighbor.Key.GScore)
                            {
                                ExtraNodeData key = neighbor.Key;
                                SearchNode node = neighbor.Value;

                                open.Remove(neighbor.Key);
                                key.GScore = lowestFKey.GScore;
                                key.Parent = value;
                                open.Add(key, node);
                            }
                        }
                        else
                        {
                            int hScore = this.CalculateHScoreSameDim(item, destination);
                            int gScore = lowestFKey.GScore + neighboringNode.Cost;
                            ExtraNodeData data = new ExtraNodeData(gScore, hScore, null, neighboringNode.Location);
                            open.Add(data, neighboringNode);//Need to add a location to the key, so that they aren't as overlapping
                        }
                    }
                }
            }

            return this.ReconstructPath(destinationData, lastNode, open, closed);
        }

        /// <summary>
        /// Reconstructs the path from the first node and the open and closed list.
        /// </summary>
        /// <param name="firstNodeData"></param>
        /// <param name="open"></param>
        /// <param name="closed"></param>
        /// <returns></returns>
        private List<PathLink> ReconstructPath(ExtraNodeData lastNodeData, SearchNode lastNode, SortedList<ExtraNodeData, SearchNode> open, SortedList<ExtraNodeData, SearchNode> closed)
        {
            List<Point3D> links = new List<Point3D>();

            ExtraNodeData data = lastNodeData;

            while (data.Parent != null)
            {
                links.Add(data.NodeLocation);
                KeyValuePair<ExtraNodeData, SearchNode> searchResult = this.GetNodeFromLists(data.Parent, open, closed);
                data = searchResult.Key;
            }

            links.Add(data.NodeLocation);

            List<PathLink> path = new List<PathLink>();

            int length = links.Count;
            for (int i = length - 1; i > 0 ; i--)
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

                return closed.ElementAt(closedIndex);
            }
            else
            {
                return open.ElementAt(openIndex);
            }
        }

        private List<PathLink> DifferentDimensionsRoute(Point3D origin, Point3D destination)
        {
            throw new NotImplementedException();
        }

        private int CalculateHScoreSameDim(Point3D node, Point3D destination)
        {
            return Math.Abs(node.X - destination.X) + Math.Abs(node.Y - destination.Y);
            //Need to come up with a way to calculate distance between Point3D, even if they are in different dimensions.
        }

        private int CalculateHScoreDiffDim(Point3D node, Point3D destination)
        {
            List<SearchNode> connectingNodes = this.Storage.GetDimensionConnectors(node.DimensionID, destination.DimensionID);

            if (connectingNodes == null || connectingNodes.Count < 1)
            {
                //Calculate which dimensional entrances/exits and dimensions to use to get from node to destination.
            }
            else
            {
                return this.GuessBestJumpPath(node, destination, connectingNodes).Item2;
            }

            throw new NotImplementedException();
            //Get all connections to the target dimension and calculate the costs from each to the destination.
            //Pathfind to the lowest cost connection
        }

        /// <summary>
        /// Calculates which nodes to other dimensions are needed to get into the same dimension as the destination from the starting node.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        private List<SearchNode> CalculateMultiDimensionalPath(Point3D node, Point3D destination)
        {
            List<SearchNode> openList = new List<SearchNode>();
            List<SearchNode> closedList = new List<SearchNode>();
            bool destinationReached = false;

            openList.Add(this.Storage.GetNode(node));

            while (!destinationReached)
            {
                //A* dim search
            }
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Guesses/calculates the dimensional entrance/exit to use to get to the destination with the least amount of distance.
        /// This uses a found list of connecting nodes.
        /// Only works if connecting nodes has direct connections between the dimension "node" is in, and the dimension "destination" is in.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        private ValueTuple<SearchNode, int> GuessBestJumpPath(Point3D node, Point3D destination, List<SearchNode> connectingNodes)
        {
            SearchNode bestEntrance = null;
            int bestDistance = int.MaxValue;

            if (connectingNodes != null && connectingNodes.Count > 0)
            {
                int sameDimCost;
                int otherDimCost = int.MaxValue;

                foreach (SearchNode item in connectingNodes)
                {
                    sameDimCost = this.CalculateHScoreSameDim(node, item.Location);

                    foreach (Point3D connection in item.Connections)
                    {
                        if (connection.DimensionID.Equals(destination.DimensionID))
                        {
                            int otherDimTempCost = this.CalculateHScoreSameDim(connection, destination);

                            if (otherDimTempCost < otherDimCost)
                            {
                                otherDimCost = otherDimTempCost;
                            }
                        }
                    }

                    if ((sameDimCost + otherDimCost) < bestDistance)
                    {
                        bestDistance = sameDimCost + otherDimCost;
                        bestEntrance = item;
                    }
                }
            }

            return new ValueTuple<SearchNode, int>(bestEntrance, bestDistance);
        }

        public void Initialize(Dimension dimension)
        {
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
                this.AddConnections(tileLocation);
            }
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
