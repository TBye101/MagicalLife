using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entity.AI.Task.Qualifications;
using MagicalLifeAPI.Networking.Client;
using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Pathfinding;
using ProtoBuf;
using System;
using System.Collections.Generic;

namespace MagicalLifeAPI.Entity.AI.Task.Tasks
{
    [ProtoContract]
    public class MoveTask : MagicalTask
    {
        [ProtoMember(1)]
        public Point2D Destination { get; private set; }

        public MoveTask(Guid boundID, Point2D destination, int taskPriority)
            : base(Dependencies.None, boundID, new List<Qualification> { new CanMoveQualification() }, taskPriority)
        {
            this.Destination = destination;
        }

        public MoveTask(Guid boundID, Point2D destination)
            : base(Dependencies.None, boundID, new List<Qualification> { new CanMoveQualification() }, PriorityLayers.Default)
        {
            this.Destination = destination;
        }

        public MoveTask()
        {
            //Protobuf-net constructor
        }

        public override void MakePreparations(Living living)
        {
            Point2D start = living.MapLocation;
            if (start != this.Destination)
            {
                List<PathLink> pth;

                //Handle reroute
                if (living.QueuedMovement.Count > 0)
                {
                    //Get a path to the nearest/next tile so that path finding and the screen location sync up.
                    PathLink previous = living.QueuedMovement.Peek();
                    living.QueuedMovement.Clear();
                    living.QueuedMovement.Enqueue(previous);
                    pth = MainPathFinder.GetRoute(living.Dimension, previous.Destination, this.Destination);
                }
                //No reroute
                else
                {
                    pth = MainPathFinder.GetRoute(living.Dimension, living.MapLocation, this.Destination);
                }

                MagicalLifeAPI.Util.Extensions.EnqueueCollection(living.QueuedMovement, pth);
                ClientSendRecieve.Send<RouteCreatedMessage>(new RouteCreatedMessage(pth, living.ID, living.Dimension));
            }
        }

        public override void Reset()
        {
        }

        public override void Tick(Living l)
        {
            if (l.MapLocation.Equals(this.Destination))
            {
                this.CompleteTask();
            }
        }
    }
}