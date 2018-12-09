using MagicalLifeAPI.DataTypes;
using ProtoBuf;

namespace MagicalLifeAPI.Util.Math
{
    /// <summary>
    /// Just another rectangle class.
    /// </summary>
    [ProtoContract]
    public class MagicRectangle
    {
        [ProtoMember(1)]
        public Point2D TopLeft { get; set; }

        [ProtoMember(2)]
        public Point2D BottomRight { get; set; }

        public MagicRectangle(Point2D topLeft, Point2D bottomRight)
        {
            this.TopLeft = topLeft;
            this.BottomRight = bottomRight;
        }
    }
}