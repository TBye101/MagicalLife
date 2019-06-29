﻿using Microsoft.Xna.Framework;
using ProtoBuf;
using System;
using System.Globalization;

namespace MagicalLifeAPI.DataTypes
{
    /// <summary>
    /// A point class that includes the dimensionID.
    /// AKA dimension point.
    /// </summary>
    [ProtoContract]
    public class DPoint
    {
        public static readonly DPoint Zero = new DPoint(0, 0, Guid.Empty);

        [ProtoMember(1)]
        public int X { get; set; }

        [ProtoMember(2)]
        public int Y { get; set; }

        [ProtoMember(3)]
        public Guid DimensionID { get; set; }

        public DPoint(int x, int y, Guid dimensionID)
        {
            this.X = x;
            this.Y = y;
            this.DimensionID = dimensionID;
        }

        public DPoint()
        {
            //Protobuf-net constructor.
        }

        public override bool Equals(object obj)
        {
            if (obj is DPoint)
            {
                DPoint c = obj as DPoint;
                return this.X == c.X && this.Y == c.Y && this.DimensionID.Equals(c.DimensionID);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public static implicit operator Point(DPoint value)
        {
            return new Point(value.X, value.Y);
        }

        public static implicit operator Point2D(DPoint value)
        {
            return new Point2D(value.X, value.Y);
        }

        public static implicit operator Vector2(DPoint value)
        {
            return new Vector2(value.X, value.Y);
        }

        public static DPoint Parse(string str)
        {
            int x;
            int y;
            Guid dimensionID;

            const int xStart = 2;
            int xEnd = str.IndexOf(',');
            x = Convert.ToInt32(str.Substring(xStart, xEnd - xStart));

            int yStart = xEnd + 2;
            int yEnd = str.IndexOf(',', yStart) - 2;
            y = Convert.ToInt32(str.Substring(yStart, yEnd - yStart));

            int dimensionStart = yEnd + 2;
            int dimensionEnd = str.Length - 2;
            dimensionID = Guid.Parse(str.Substring(dimensionStart, dimensionEnd));

            return new DPoint(x, y, dimensionID);
        }

        public override string ToString()
        {
            return "{ " + this.X.ToString(CultureInfo.InvariantCulture) + ", " + this.Y.ToString(CultureInfo.InvariantCulture) + ", " + this.DimensionID.ToString() + " }";
        }

        public virtual bool Equals(Point2D other)
        {
            return other.X == this.X && other.Y == this.Y;
        }
    }
}