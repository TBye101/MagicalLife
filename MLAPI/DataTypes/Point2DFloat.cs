using System;
using System.Globalization;
using ProtoBuf;

namespace MLAPI.DataTypes
{
    [ProtoBuf.ProtoContract]
    public struct Point2DFloat : IEquatable<Point2DFloat>
    {
        [ProtoMember(1)]
        public float X { get; set; }

        [ProtoMember(2)]
        public float Y { get; set; }

        public Point2DFloat(float x, float y)
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

        public bool Equals(Point2DFloat other)
        {
            return Math.Abs(other.X - this.X) < 0.00001f && Math.Abs(other.Y - this.Y) < 0.00001f;
        }

        public override bool Equals(object obj)
        {
            if (obj is Point2DFloat point2DFloat)
            {
                return this.Equals(point2DFloat);
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

        public static bool operator ==(Point2DFloat left, Point2DFloat right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Point2DFloat left, Point2DFloat right)
        {
            return !left.Equals(right);
        }
    }
}