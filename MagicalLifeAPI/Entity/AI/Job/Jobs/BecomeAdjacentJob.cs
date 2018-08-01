using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entities;
using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.Pathfinding;
using MagicalLifeAPI.Util;
using MagicalLifeAPI.World;
using ProtoBuf;

namespace MagicalLifeAPI.Entity.AI.Job.Jobs
{
    /// <summary>
    /// This job gets a living adjacent to a tile.
    /// </summary>
    [ProtoContract]
    public class BecomeAdjacentJob : Job
    {
        [ProtoMember(1)]
        public Point2D Target { get; private set; }

        [ProtoMember(2)]
        public List<PathLink> Route { get; private set; }

        [ProtoMember(3)]
        public Point2D AdjacentLocation { get; private set; }

        /// <param name="target">The target to become adjacent to.</param>
        public BecomeAdjacentJob(Point2D target)
        {
            this.Target = target;
        }

        public override void BeginJob(Living living)
        {
            List<Point2D> result = WorldUtil.GetNeighboringTiles(this.Target, living.Dimension);
            result.RemoveAll(x => !World.Data.World.GetTile(living.Dimension, x.X, x.Y).IsWalkable);

            int closestIndex = Algorithms.GetClosestPoint2D(result, living.MapLocation);
            this.AdjacentLocation = result[closestIndex];
            List<PathLink> path = MainPathFinder.GetRoute(living.Dimension, living.MapLocation, result[closestIndex]);
            living.QueuedMovement.Clear();
            Extensions.EnqueueCollection(living.QueuedMovement, path);
        }

        public override void DoJob(Living living)
        {
            if (living.MapLocation.Equals(this.AdjacentLocation))
            {
                this.CompleteJob();
            }
        }

        public override void ReevaluateDependencies()
        {
        }
    }
}
