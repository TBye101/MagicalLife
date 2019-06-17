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
        public Point3D Origin;

        [ProtoMember(2)]
        public Point3D Destination;

        public PathLink(Point3D origin, Point3D destination)
        {
            this.Origin = origin;
            this.Destination = destination;
        }

        protected PathLink()
        {
            //Protobuf-net constructor
        }
    }
}