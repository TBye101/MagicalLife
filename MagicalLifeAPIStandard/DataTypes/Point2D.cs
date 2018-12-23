using Microsoft.Xna.Framework;
using ProtoBuf;
using System;
using System.Globalization;

namespace MagicalLifeAPI.DataTypes
{
    [ProtoContract]
    public class Point2D
    {
        [ProtoMember(1)]
        public int X { get; set; }

        [ProtoMember(2)]
        public int Y { get; set; }

        public Point2D(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Point2D()
        {
        }

        public override bool Equals(object obj)
        {
            if (obj is Point2D)
            {
                Point2D c = obj as Point2D;
                return (this.X == c.X && this.Y == c.Y);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public static implicit operator Point2D(Point value)
        {
            return new Point2D(value.X, value.Y);
        }

        public static implicit operator Point(Point2D value)
        {
            return new Point(value.X, value.Y);
        }

        public static implicit operator Vector2(Point2D value)
        {
            return new Vector2(value.X, value.Y);
        }

        public static Point2D Parse(string str)
        {
            int x;
            int y;

            int xStart = 2;
            int xEnd = str.IndexOf(',');
            x = Convert.ToInt32(str.Substring(xStart, xEnd - xStart));

            int yStart = xEnd + 2;
            int yEnd = str.Length - 2;
            y = Convert.ToInt32(str.Substring(yStart, yEnd - yStart));

            return new Point2D(x, y);
        }

        public override string ToString()
        {
            return "{ " + this.X.ToString(CultureInfo.InvariantCulture) + ", " + this.Y.ToString(CultureInfo.InvariantCulture) + " }";
        }
    }
}