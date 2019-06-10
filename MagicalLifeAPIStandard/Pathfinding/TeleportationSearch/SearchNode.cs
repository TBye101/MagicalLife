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
        [ProtoMember(1)]
        public List<Point3D> Connections { get; set; }

        /// <summary>
        /// The location of this node.
        /// </summary>
        [ProtoMember(2)]
        public Point3D Location { get; set; }

        /// <summary>
        /// The movement cost of the node as defined by the tile it represents.
        /// </summary>
        [ProtoMember(3)]
        public int Cost { get; set; }

        /// <summary>
        /// If true the tile represented by this node is not currently in the player's sight.
        /// </summary>
        [ProtoMember(4)]
        public bool FogOWar { get; set; }

        /// <summary>
        /// If false the tile represented by this node has never been visited by the player. 
        /// </summary>
        [ProtoMember(5)]
        public bool Visible { get; set; }

        public SearchNode(Point3D location, int cost, bool fogOWar, bool visible)
        {
            this.Connections = new List<Point3D>();
            this.Location = location;
            this.Cost = cost;
            this.FogOWar = fogOWar;
            this.Visible = visible;
        }

        protected SearchNode()
        {
            //Protobuf-net constructor.
        }
    }
}
