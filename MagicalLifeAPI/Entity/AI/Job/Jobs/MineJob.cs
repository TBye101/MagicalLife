using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicalLifeAPI.Components.Resource;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entities;
using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.Registry.ItemRegistry;
using MagicalLifeAPI.World;
using ProtoBuf;

namespace MagicalLifeAPI.Entity.AI.Job.Jobs
{
    /// <summary>
    /// Has the creature mine something.
    /// </summary>
    [ProtoContract]
    public class MineJob : Job
    {
        [ProtoMember(1)]
        public Point2D Target { get; private set; }

        [ProtoMember(2)]
        private IMinable Minable { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target">The tile that contains the object to mine up.</param>
        /// <param name="workStation">The position at which the creature will be at when it begins mining.</param>
        public MineJob(Point2D target) : base(GetDependencies(target), true)
        {
            this.Target = target;
            MasterLog.DebugWriteLine("Target: " + this.Target.ToXNA().ToString());
        }

        protected static Dictionary<Guid, Job> GetDependencies(Point2D target)
        {
            Dictionary<Guid, Job> ret = new Dictionary<Guid, Job>();
            BecomeAdjacentJob dependency = new BecomeAdjacentJob(target);

            ret.Add(dependency.ID, dependency);

            return ret;
        }

        public override void BeginJob(Living living)
        {
            Tile tile = World.Data.World.GetTile(living.Dimension, this.Target.X, this.Target.Y);
            this.Minable = tile.Resources;
        }

        public override void DoJob(Living living)
        {
            List<World.Base.Item> drop = this.Minable.MiningBehavior.MineSomePercent(.1F);

            if (drop != null && drop.Count > 0)
            {
                ItemAdder.AddItem(drop[0], living.MapLocation, living.Dimension);
            }

            if (this.Minable.MiningBehavior.PercentMined > 1)
            {
                this.RemoveResource(living.Dimension);
                this.CompleteJob();
            }
        }

        /// <summary>
        /// Removes the resource from the world, as it has been completely mined up.
        /// </summary>
        private void RemoveResource(int dimension)
        {
            Tile tile = World.Data.World.GetTile(dimension, this.Target.X, this.Target.Y);
            tile.Resources = null;
            tile.ImpendingAction = ActionSelected.None;
        }

        public override void ReevaluateDependencies()
        {
            //Evaluate that something needs to be mined first or something.
        }
    }
}
