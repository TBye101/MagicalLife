using ProtoBuf;
using System.Globalization;

namespace MagicalLifeAPI.DataTypes
{
    [ProtoBuf.ProtoContract]
    public struct Point2DFloat
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
    }
}