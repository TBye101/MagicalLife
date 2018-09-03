using MagicalLifeAPI.Components.Resource;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entity.AI.Job;
using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.Registry.ItemRegistry;
using MagicalLifeAPI.Util.Reusable;
using MagicalLifeAPI.World.Base;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Entity.AI.Task.Tasks
{
    [ProtoContract]
    public class MineTask : MagicalTask
    {
        [ProtoMember(1)]
        public Point2D Target { get; private set; }

        [ProtoMember(2)]
        private IMinable Minable { get; set; }

        [ProtoMember(3)]
        private TickTimer HitTimer { get; set; }

        public MineTask(Point2D target, Guid boundID) : base(GetDependencies(boundID), boundID, new List<Qualification>())
        {
            this.Target = target;
            MasterLog.DebugWriteLine("Target: " + this.Target.ToString());
            this.HitTimer = new TickTimer(30);
        }

        private MineTask()
        {

        }

        protected static Dependencies GetDependencies(Guid boundID)
        {
            List<MagicalTask> deps = new List<MagicalTask>
            {
                new BecomeAdjacentTask(boundID)
            };

            return new Dependencies(deps);
        }

        public override void MakePreparations(Living l)
        {
            Tile tile = World.Data.World.GetTile(l.Dimension, this.Target.X, this.Target.Y);
            this.Minable = tile.Resources;
        }

        public override void Reset()
        {
            //Nothing to do here...
        }

        public override void Tick(Living l)
        {
            if (this.HitTimer.Allow())
            {
                List<World.Base.Item> drop = this.Minable.MiningBehavior.MineSomePercent(.1F);

                if (drop != null && drop.Count > 0)
                {
                    ItemAdder.AddItem(drop[0], l.MapLocation, l.Dimension);
                }

                if (this.Minable.MiningBehavior.PercentMined > 1)
                {
                    this.RemoveResource(l.Dimension);
                    this.CompleteTask();
                }
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
    }
}
