using MagicalLifeAPI.DataTypes;
using ProtoBuf;

namespace MagicalLifeAPI.Pathfinding
{
    /// <summary>
    /// Used to describe the steps a entity will take between two Point2Ds for path finding.
    /// </summary>
    [ProtoContract]
    public class PathLink
    {
        [ProtoMember(1)]
        public Point2D Origin;

        [ProtoMember(2)]
        public Point2D Destination;

        public PathLink(Point2D origin, Point2D destination)
        {
            this.Origin = origin;
            this.Destination = destination;
        }

        public PathLink()
        {
        }
    }
}