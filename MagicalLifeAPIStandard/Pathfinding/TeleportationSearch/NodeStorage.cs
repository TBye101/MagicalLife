using MagicalLifeAPI.DataTypes;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeAPI.Pathfinding.TeleportationSearch
{
    /// <summary>
    /// Used to efficiently store nodes in a way that makes operations quick.
    /// </summary>
    [ProtoContract]
    public class NodeStorage
    {
        /// <summary>
        /// Key: The location of the node.
        /// Value: the actual node.
        /// </summary>
        public readonly Dictionary<Point3D, SearchNode> LocationToNode;

        /// <summary>
        /// Key: The two dimensions that have connecting nodes.
        /// Value: The nodes that are in the key's dimension that connect to another dimension.
        /// </summary>
        public readonly Dictionary<TwoGuid, List<SearchNode>> DimensionOutNodes;

        public NodeStorage(int nodes)
        {
            this.LocationToNode = new Dictionary<Point3D, SearchNode>(nodes);
            this.DimensionOutNodes = new Dictionary<TwoGuid, List<SearchNode>>();
        }

        /// <summary>
        /// Returns a list of all the search nodes that connect the two dimensions.
        /// </summary>
        /// <param name="dimensionOne"></param>
        /// <param name="dimensionTwo"></param>
        /// <returns></returns>
        public List<SearchNode> GetDimensionConnectors(Guid dimensionOne, Guid dimensionTwo)
        {
            TwoGuid dimData = new TwoGuid(dimensionOne, dimensionTwo);
            this.DimensionOutNodes.TryGetValue(dimData, out List<SearchNode> dimConnections);
            return dimConnections;
        }

        public void AddNode(SearchNode node)
        {
            if (!this.LocationToNode.ContainsKey(node.Location))
            {
                this.LocationToNode.Add(node.Location, node);
            }
        }

        public SearchNode GetNode(Point3D nodeLocation)
        {
            //this.LocationToNode.TryGetValue(nodeLocation, out SearchNode node);
            //return node;
            return this.LocationToNode[nodeLocation];
        }

        /// <summary>
        /// Returns all nodes connected to the specified node location.
        /// </summary>
        /// <param name="nodeLocation"></param>
        /// <returns></returns>
        public IReadOnlyList<Point3D> GetConnected(Point3D nodeLocation)
        {
            this.LocationToNode.TryGetValue(nodeLocation, out SearchNode node);
            return node.Connections;
        }

        /// <summary>
        /// Adds a connection between locations 'a' and 'b'.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public void AddConnection(Point3D a, Point3D b)
        {
            SearchNode nodeA = this.GetNode(a);
            SearchNode nodeB = this.GetNode(b);
            this.AddConnection(nodeA, nodeB);
        }

        /// <summary>
        /// Adds a connection between nodes 'a' and 'b'.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public void AddConnection(SearchNode a, SearchNode b)
        {
            if (!a.Connections.Contains(b.Location))
            {
                a.Connections.Add(b.Location);
            }
            if (!b.Connections.Contains(a.Location))
            {
                b.Connections.Add(a.Location);
            }

            if (!a.Location.DimensionID.Equals(b.Location.DimensionID))
            {
                this.AddDimensionalConnections(a, b);
            }
        }

        /// <summary>
        /// Registers that there are connections between two dimensions in these nodes. 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        private void AddDimensionalConnections(SearchNode a, SearchNode b)
        {
            TwoGuid dimData = new TwoGuid(a.Location.DimensionID, b.Location.DimensionID);

            this.DimensionOutNodes.TryGetValue(dimData, out List<SearchNode> connections);

            if (connections == null)
            {
                this.DimensionOutNodes.Add(dimData, new List<SearchNode>() { a, b });
            }
            else
            {
                if (!connections.Contains(a))
                {
                    connections.Add(a);
                }
                if (!connections.Contains(b))
                {
                    connections.Add(b);
                }
            }
        }

        /// <summary>
        /// Removes a connection between the two specified nodes.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public void RemoveConnection(SearchNode a, SearchNode b)
        {
            a.Connections.Remove(b.Location);
            b.Connections.Remove(a.Location);

            if (!a.Location.DimensionID.Equals(b.Location.DimensionID))
            {
                TwoGuid dimData = new TwoGuid(a.Location.DimensionID, b.Location.DimensionID);
                this.DimensionOutNodes.TryGetValue(dimData, out List<SearchNode> connections);
                connections.Remove(a);
                connections.Remove(b);
            }
        }

        /// <summary>
        /// Removes all connections of the specified node.
        /// </summary>
        /// <param name="node"></param>
        public void RemoveAllConnections(SearchNode node)
        {
            foreach (Point3D nodeLocation in node.Connections)
            {
                SearchNode connectedNode = this.GetNode(nodeLocation);
                this.RemoveConnection(node, connectedNode);
            }
        }

        public void RemoveAllConnections(Point3D node)
        {
            SearchNode sNode = this.GetNode(node);
            this.RemoveAllConnections(sNode);
        }
    }
}
