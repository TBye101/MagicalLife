using System;
using System.Collections.Generic;
using MLAPI.Components;
using MLAPI.Components.Entity;
using MLAPI.DataTypes;
using MLAPI.Entity.AI.Task.Qualifications;
using MLAPI.Pathfinding;
using ProtoBuf;

namespace MLAPI.Entity.AI.Task.Tasks
{
    [ProtoContract]
    public class MoveTask : MagicalTask
    {
        [ProtoMember(1)]
        public Point3D Destination { get; private set; }

        public MoveTask(Guid boundId, Point3D destination, int taskPriority)
            : base(Dependencies.CreateEmpty(), boundId, new List<Qualification> { new CanMoveQualification(), new IsRoutePossibleQualification(destination) }, taskPriority)
        {
            this.Destination = destination;
        }

        public MoveTask(Guid boundId, Point3D destination)
            : this(boundId, destination, PriorityLayers.Default)
        {
        }

        protected MoveTask()
        {
            //Protobuf-net constructor
        }

        public override void MakePreparations(Living living)
        {
            ComponentSelectable entityData = living.GetExactComponent<ComponentSelectable>();
            Point3D start = entityData.MapLocation;
            if (start != this.Destination)
            {
                ComponentMovement movementComponent = living.GetExactComponent<ComponentMovement>();

                //Handle reroute
                if (movementComponent.QueuedMovement.Count > 0)
                {
                    //Get a path to the nearest/next tile so that path finding and the screen location sync up.
                    PathLink previous = movementComponent.QueuedMovement.Peek();
                    movementComponent.QueuedMovement.Clear();
                    movementComponent.QueuedMovement.Enqueue(previous);
                    MainPathFinder.GiveRouteAsync(living, previous.Destination, this.Destination);
                }
                //No reroute
                else
                {
                    MainPathFinder.GiveRouteAsync(living, start, this.Destination);
                }
            }
        }

        public override void Reset()
        {
        }

        public override void Tick(Living l)
        {
            if (l.GetExactComponent<ComponentSelectable>().MapLocation.Equals(this.Destination))
            {
                this.CompleteTask();
            }
        }

        public override bool CreateDependencies(Living l)
        {
            return true;
        }
    }
}