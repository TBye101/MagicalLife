using System;
using System.Globalization;
using ProtoBuf;

namespace MLAPI.DataTypes
{
    [ProtoBuf.ProtoContract]
    public struct Point2DDouble : IEquatable<Point2DDouble>
    {
        [ProtoMember(1)]
        public double X { get; set; }

        [ProtoMember(2)]
        public double Y { get; set; }

        public Point2DDouble(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public override string ToString()
        {
            return "{ " + this.X.ToString(CultureInfo.InvariantCulture) + ", " + this.Y.ToString(CultureInfo.InvariantCulture) + " }";
        }

        public Point2D ToPoint2D()
        {
            return new Point2D((int)this.X, (int)this.Y);
        }

        public override bool Equals(object obj)
        {
            if (obj is Point2DDouble point2DDouble)
            {
                return this.Equals(point2DDouble);
            }
            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = (hash * 3) + this.X.GetHashCode();
                hash = (hash * 3) + this.Y.GetHashCode();
                return hash;
            }
        }

        public bool Equals(Point2DDouble other)
        {
            return Math.Abs(other.X - this.X) < 0.00001f && Math.Abs(other.Y - Y) < 0.00001f;
        }

        public static bool operator ==(Point2DDouble left, Point2DDouble right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Point2DDouble left, Point2DDouble right)
        {
            return !left.Equals(right);
        }
    }
}