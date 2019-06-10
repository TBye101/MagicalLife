using MagicalLifeAPI.DataTypes;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeAPI.Pathfinding.TeleportationSearch
{
    /// <summary>
    /// A node used in our pathfinding algorithm.
    /// </summary>
    [ProtoContract]
    public class SearchNode
    {
        /// <summary>
        /// The connections to other nodes this node has.
        /// </summary>
        public List<Point3D> Connections { get; set; }

        /// <summary>
        /// The location of this node.
        /// </summary>
        public Point3D Location { get; set; }

        /// <summary>
        /// The movement cost of the node as defined by the tile it represents.
        /// </summary>
        public int Cost { get; set; }
    }
}
