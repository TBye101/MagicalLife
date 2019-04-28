using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.GUI;
using MagicalLifeAPI.Pathfinding;
using ProtoBuf;

namespace MagicalLifeAPI.Entity.AI.Task.Qualifications
{
    /// <summary>
    /// Makes a requirement that the destination specified must be reachable.
    /// </summary>
    [ProtoContract]
    public class IsRoutePossibleQualification : Qualification
    {
        [ProtoMember(1)]
        protected Point2D Destination { get; set; }

        public IsRoutePossibleQualification(Point2D destination)
        {
            this.Destination = destination;
        }

        protected IsRoutePossibleQualification()
        {
            //Protobuf-net constructor
        }

        public override bool ArePreconditionsMet()
        {
            return true;
        }

        public override bool IsQualified(Living living)
        {
            Point2D mapLocation = living.GetExactComponent<ComponentSelectable>().MapLocation;
            return MainPathFinder.IsRoutePossible(living.Dimension, mapLocation, this.Destination);
        }
    }
}