using Microsoft.Xna.Framework;
using ProtoBuf;
using RBush;
using System;

namespace MagicalLifeAPI.DataTypes
{
    [ProtoContract]
    public class Point2D : ISpatialData
    {
        [ProtoMember(1)]
        public int X { get; set; }

        [ProtoMember(2)]
        public int Y { get; set; }

        protected Envelope _Envelope;

        public Point2D(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this._Envelope = new Envelope(x, y, x, y);
        }

        public Point2D()
        {
            this._Envelope = new Envelope(this.X, this.Y, this.X, this.Y);
        }

        public ref readonly Envelope Envelope
        {
            get
            {
                return ref this._Envelope;
            }
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
