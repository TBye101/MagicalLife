using Microsoft.Xna.Framework;
using ProtoBuf;

namespace MagicalLifeAPI.Pathfinding
{
    /// <summary>
    /// Used to describe the steps a entity will take between two points for path finding.
    /// </summary>
    [ProtoContract]
    public class PathLink
    {
        [ProtoMember(1)]
        public Point Origin;

        [ProtoMember(2)]
        public Point Destination;

        public PathLink(Point origin, Point destination)
        {
            this.Origin = origin;
            this.Destination = destination;
        }

        public PathLink()
        {

        }
    }
}