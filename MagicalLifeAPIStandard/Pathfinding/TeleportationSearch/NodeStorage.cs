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
        private readonly Dictionary<Point3D, SearchNode> LocationToNode;

        /// <summary>
        /// Key: The location of a node.
        /// Value: The connected nodes. 
        /// </summary>
        private readonly Dictionary<Point3D, List<SearchNode>> LocationToConnected;

        /// <summary>
        /// Key: The two dimensions that have connecting nodes.
        /// Value: The nodes that are in the key's dimension that connect to another dimension.
        /// </summary>
        private readonly Dictionary<TwoGuid, List<SearchNode>> DimensionOutNodes;

        public NodeStorage()
        {
            this.LocationToNode = new Dictionary<Point3D, SearchNode>();
            this.LocationToConnected = new Dictionary<Point3D, List<SearchNode>>();
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
            this.LocationToNode.TryGetValue(nodeLocation, out SearchNode node);
            return node;
        }

        /// <summary>
        /// Returns all nodes connected to the specified node location.
        /// </summary>
        /// <param name="nodeLocation"></param>
        /// <returns></returns>
        public IReadOnlyList<SearchNode> GetConnected(Point3D nodeLocation)
        {
            this.LocationToConnected.TryGetValue(nodeLocation, out List<SearchNode> connected);
            return connected;
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
            a.Connections.Add(b.Location);
            b.Connections.Add(a.Location);
            this.LocationToConnected.TryGetValue(a.Location, out List<SearchNode> aConnections);
            this.LocationToConnected.TryGetValue(b.Location, out List<SearchNode> bConnections);

            if (aConnections == null)
            {
                this.LocationToConnected.Add(a.Location, new List<SearchNode>() { b });
            }
            else
            {
                if (!aConnections.Contains(b))
                {
                    aConnections.Add(b);
                }
            }

            if (bConnections == null)
            {
                this.LocationToConnected.Add(b.Location, new List<SearchNode>() { a });
            }
            else
            {
                if (!bConnections.Contains(a))
                {
                    bConnections.Add(a);
                }
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
            this.LocationToConnected.TryGetValue(a.Location, out List<SearchNode> aConnections);
            this.LocationToConnected.TryGetValue(b.Location, out List<SearchNode> bConnections);
            aConnections.Remove(b);
            bConnections.Remove(a);

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
