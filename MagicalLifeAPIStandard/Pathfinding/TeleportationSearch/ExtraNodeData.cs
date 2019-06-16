using MagicalLifeAPI.DataTypes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeAPI.Pathfinding.TeleportationSearch
{
    /// <summary>
    /// Used to store the f(n) score and its components for the search, 
    /// as well as a node's "parent".
    /// </summary>
    public struct ExtraNodeData : IComparable<ExtraNodeData>, IEquatable<ExtraNodeData>
    {
        public int GScore { get; set; }
        public int HScore { get; set; }

        /// <summary>
        /// The previous node step in our calculated path.
        /// </summary>
        public SearchNode Parent { get; set; }

        public Point3D NodeLocation { get; set; }

        public ExtraNodeData(int gScore, int hScore, SearchNode parent, Point3D nodeLocation)
        {
            this.GScore = gScore;
            this.HScore = hScore;
            this.Parent = parent;
            this.NodeLocation = nodeLocation;
        }

        public bool Equals(ExtraNodeData other)
        {
            return other.GScore.Equals(this.GScore) 
                && other.HScore.Equals(this.HScore) 
                && other.Parent.Equals(this.Parent)
                && other.NodeLocation.Equals(this.NodeLocation);
        }

        public int CompareTo(ExtraNodeData other)
        {
            int xF = other.GScore + other.HScore;
            int yF = this.GScore + this.HScore;

            int fScoreComparison = xF.CompareTo(yF);

            if (fScoreComparison == 0)
            {
                return other.NodeLocation.CompareTo(this.NodeLocation);
            }
            else
            {
                return fScoreComparison;
            }
        }
    }
}
