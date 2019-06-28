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
        public float GScore { get; set; }
        public int HScore { get; set; }

        public Point3D NodeLocation { get; set; }

        public ExtraNodeData(float gScore, int hScore, Point3D nodeLocation)
        {
            this.GScore = gScore;
            this.HScore = hScore;
            this.NodeLocation = nodeLocation;
        }

        public bool Equals(ExtraNodeData other)
        {
            bool numsSame = other.GScore.Equals(this.GScore)
                && other.HScore.Equals(this.HScore);

            if (numsSame)
            {
                if (other.NodeLocation == null)
                {
                    if (this.NodeLocation == null)
                    {
                        return true;
                    }
                }
                else
                {
                    if (this.NodeLocation != null)
                    {
                        return other.NodeLocation.Equals(this.NodeLocation);
                    }
                }
            }

            return false;
        }

        public int CompareTo(ExtraNodeData other)
        {
            float xF = other.GScore + other.HScore;
            float yF = this.GScore + this.HScore;

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
