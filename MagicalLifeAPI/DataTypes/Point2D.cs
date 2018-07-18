using Microsoft.Xna.Framework;
using ProtoBuf;

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

        /// <summary>
        /// Converts this point to a monogame/xna point.
        /// </summary>
        /// <returns></returns>
        public Point ToXNA()
        {
            return new Point(this.X, this.Y);
        }
    }
}