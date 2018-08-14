using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.Pathfinding;
using MagicalLifeAPI.Util;
using MagicalLifeAPI.World;
using ProtoBuf;
using System.Collections.Generic;

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
        public BecomeAdjacentJob(Point2D target, bool requireSameWorker) : base(requireSameWorker)
        {
            this.Target = target;
        }

        public BecomeAdjacentJob()
        {
            //Protobuf-net constructor
        }

        protected override void StartJob(Living living)
        {
            List<Point2D> result = WorldUtil.GetNeighboringTiles(this.Target, living.Dimension);
            result.RemoveAll(x => !World.Data.World.GetTile(living.Dimension, x.X, x.Y).IsWalkable);

            int closestIndex = Algorithms.GetClosestPoint2D(result, living.MapLocation);
            this.AdjacentLocation = result[closestIndex];
            List<PathLink> path = MainPathFinder.GetRoute(living.Dimension, living.MapLocation, result[closestIndex]);
            living.QueuedMovement.Clear();
            Extensions.EnqueueCollection(living.QueuedMovement, path);
        }

        protected override void JobTick(Living living)
        {
            if (living.MapLocation.Equals(this.AdjacentLocation))
            {
                MasterLog.DebugWriteLine(this.ID.ToString());
                this.CompleteJob(living);
            }
        }

        public override void ReevaluateDependencies()
        {
        }
    }
}