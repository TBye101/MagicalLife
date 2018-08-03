using System.Collections.Generic;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Networking.Client;
using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Pathfinding;
using ProtoBuf;

namespace MagicalLifeAPI.Entity.AI.Job.Jobs
{
    /// <summary>
    /// This job gets the living to move from point 'A' to point 'B'.
    /// </summary>
    [ProtoContract]
    public class MoveJob : Job
    {
        [ProtoMember(1)]
        public Point2D Destination { get; private set; }

        public MoveJob(Point2D destination, bool requireSameWorker) : base(requireSameWorker)
        {
            this.Destination = destination;
        }

        public MoveJob() : base()
        {
            //Protobuf-net constructor
        }

        protected override void StartJob(Living living)
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

        protected override void JobTick(Living living)
        {
            //We don't need to do anything more
        }

        public override void ReevaluateDependencies()
        {
        }
    }
}
