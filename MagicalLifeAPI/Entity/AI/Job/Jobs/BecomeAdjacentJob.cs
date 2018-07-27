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

namespace MagicalLifeAPI.Entity.AI.Job.Jobs
{
    /// <summary>
    /// This job gets a living adjacent to a tile.
    /// </summary>
    public class BecomeAdjacentJob : Job
    {
        public Point2D Target { get; private set; }

        public List<PathLink> Route { get; private set; }

        /// <param name="target">The target to become adjacent to.</param>
        public BecomeAdjacentJob(Point2D target)
        {
            this.Target = target;
        }

        public override void BeginJob(Living living)
        {
            List<Point2D> result = WorldUtil.GetNeighboringTiles(this.Target, living.Dimension);
            int closestIndex = Algorithms.GetClosestPoint2D(result, living.MapLocation);
            List<PathLink> path = MainPathFinder.GetRoute(living.Dimension, living.MapLocation, result[closestIndex]);
            living.QueuedMovement.Clear();
            Extensions.EnqueueCollection(living.QueuedMovement, path);
        }

        public override void DoJob(Living living)
        {
        }

        public override void ReevaluateDependencies()
        {
        }
    }
}
