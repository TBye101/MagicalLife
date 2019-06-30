using MagicalLifeAPI.Components.Entity;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entity.AI.Task.Qualifications;
using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.GUI;
using MagicalLifeAPI.Networking.Client;
using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Pathfinding;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Entity.AI.Task.Tasks
{
    [ProtoContract]
    public class MoveTask : MagicalTask
    {
        [ProtoMember(1)]
        public Point3D Destination { get; private set; }

        public MoveTask(Guid boundID, Point3D destination, int taskPriority)
            : base(Dependencies.CreateEmpty(), boundID, new List<Qualification> { new CanMoveQualification(), new IsRoutePossibleQualification(destination) }, taskPriority)
        {
            this.Destination = destination;
        }

        public MoveTask(Guid boundID, Point3D destination)
            : this(boundID, destination, PriorityLayers.Default)
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
                List<PathLink> pth;
                ComponentMovement movementComponent = living.GetExactComponent<ComponentMovement>();

                //Handle reroute
                if (movementComponent.QueuedMovement.Count > 0)
                {
                    //Get a path to the nearest/next tile so that path finding and the screen location sync up.
                    PathLink previous = movementComponent.QueuedMovement.Peek();
                    movementComponent.QueuedMovement.Clear();
                    movementComponent.QueuedMovement.Enqueue(previous);
                    //pth = MainPathFinder.GetRoute(previous.Destination, this.Destination);
                    //this.GiveRoute(living, previous.Destination, this.Destination);
                    System.Threading.Tasks.Task.Run(() => this.GiveRoute(living, previous.Destination, this.Destination));
                }
                //No reroute
                else
                {
                    System.Threading.Tasks.Task.Run(() => this.GiveRoute(living, start, this.Destination));
                    //this.GiveRoute(living, start, this.Destination);
                    //pth = MainPathFinder.GetRoute(start, this.Destination);

                    //MasterLog.DebugWriteLine("Path start: " + start.ToString() + " to " + this.Destination.ToString());
                    //foreach (PathLink item in pth)
                    //{
                    //    MasterLog.DebugWriteLine("Link: " + item.Origin.ToString() + " to " + item.Destination.ToString());
                    //}
                    //MasterLog.DebugWriteLine("Path end: " + start.ToString() + " to " + this.Destination.ToString());
                }

                //MagicalLifeAPI.Util.Extensions.EnqueueCollection(movementComponent.QueuedMovement, pth);
                //ClientSendRecieve.Send<RouteCreatedMessage>(new RouteCreatedMessage(pth, living.ID, living.DimensionID));
            }
        }

        private void GiveRoute(Living living, Point3D start, Point3D end)
        {
            Task<List<PathLink>> routeTask = Task<List<PathLink>>.Run(() => MainPathFinder.GetRoute(start, end));
            ComponentMovement movementComponent = living.GetExactComponent<ComponentMovement>();
            //List<PathLink> pth = MainPathFinder.GetRoute(start, this.Destination);
            MagicalLifeAPI.Util.Extensions.EnqueueCollection(movementComponent.QueuedMovement, routeTask.Result);
            ClientSendRecieve.Send<RouteCreatedMessage>(new RouteCreatedMessage(routeTask.Result, living.ID, living.DimensionID));
            //MagicalLifeAPI.Util.Extensions.EnqueueCollection(movementComponent.QueuedMovement, pth);
            //ClientSendRecieve.Send<RouteCreatedMessage>(new RouteCreatedMessage(pth, living.ID, living.DimensionID));
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