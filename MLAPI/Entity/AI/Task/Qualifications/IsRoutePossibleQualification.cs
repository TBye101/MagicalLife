using MLAPI.Components;
using MLAPI.DataTypes;
using MLAPI.Pathfinding;
using ProtoBuf;

namespace MLAPI.Entity.AI.Task.Qualifications
{
    /// <summary>
    /// Makes a requirement that the destination specified must be reachable.
    /// </summary>
    [ProtoContract]
    public class IsRoutePossibleQualification : Qualification
    {
        [ProtoMember(1)]
        protected Point3D Destination { get; set; }

        public IsRoutePossibleQualification(Point3D destination)
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
            Point3D mapLocation = living.GetExactComponent<ComponentSelectable>().MapLocation;
            return MainPathFinder.IsRoutePossible(mapLocation, this.Destination);
        }
    }
}