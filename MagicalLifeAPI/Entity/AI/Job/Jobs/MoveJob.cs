using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entities;
using MagicalLifeAPI.Networking.Client;
using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Pathfinding;

namespace MagicalLifeAPI.Entity.AI.Job.Jobs
{
    /// <summary>
    /// This job gets the living to move from point 'A' to point 'B'.
    /// </summary>
    public class MoveJob : Job
    {
        public Point2D Destination { get; private set; }

        public MoveJob(Point2D destination) : base()
        {
            this.Destination = destination;
        }

        public override void BeginJob(Living living)
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

        public override void DoJob(Living living)
        {
            //We don't need to do anything more
        }

        public override void ReevaluateDependencies()
        {
        }
    }
}
