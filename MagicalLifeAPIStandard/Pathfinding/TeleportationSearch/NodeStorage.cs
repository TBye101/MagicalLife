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

        public NodeStorage()
        {
            this.LocationToNode = new Dictionary<Point3D, SearchNode>();
            this.LocationToConnected = new Dictionary<Point3D, List<SearchNode>>();
        }

        public void AddNode(SearchNode node)
        {
            if (!this.LocationToNode.ContainsKey(node.Location))
            {
                this.LocationToNode.Add(node.Location, node);
            }

            foreach (Point3D item in node.Connections)
            {
                if (this.LocationToConnected.ContainsKey(item))
                {
                    this.LocationToConnected.TryGetValue(item, out List<SearchNode> connected);
                    connected.Add(node);
                }
                else
                {
                    List<SearchNode> connected = new List<SearchNode> { node };
                    this.LocationToConnected.Add(item, connected);
                }
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
            aConnections.Add(b);
            bConnections.Add(a);
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
