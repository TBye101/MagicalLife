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
    public struct ExtraNodeData : IComparer<ExtraNodeData>, IEquatable<ExtraNodeData>
    {
        public int GScore { get; set; }
        public int HScore { get; set; }

        /// <summary>
        /// The previous node step in our calculated path.
        /// </summary>
        public SearchNode Parent { get; set; }

        public ExtraNodeData(int gScore, int hScore, SearchNode parent)
        {
            this.GScore = gScore;
            this.HScore = hScore;
            this.Parent = parent;
        }

        public int Compare(ExtraNodeData x, ExtraNodeData y)
        {
            int xF = x.GScore + x.HScore;
            int yF = y.GScore + y.HScore;

            return xF.CompareTo(yF);
        }

        public bool Equals(ExtraNodeData other)
        {
            return other.GScore.Equals(this.GScore) && other.HScore.Equals(this.HScore) && other.Parent.Equals(this.Parent);
        }
    }
}
