using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MLAPI.Components;
using MLAPI.Components.Resource;
using MLAPI.DataTypes;
using MLAPI.Filing.Logging;
using MLAPI.GameRegistry.Items;
using MLAPI.Util.Reusable;
using MLAPI.World.Base;
using ProtoBuf;

namespace MLAPI.Entity.AI.Task.Tasks
{
    [ProtoContract]
    public class TillTask : MagicalTask
    {
        [ProtoMember(1)]
        public Point3D Target { get; private set; }

        /// <summary>
        /// The tillable component of the tile this task is supposed to till.
        /// </summary>
        [ProtoMember(2)]
        private ComponentTillable Tillable { get; set; }

        [ProtoMember(3)]
        private TickTimer HitTimer { get; set; }

        public TillTask(Point3D target, Guid boundId)
            : base(GetDependencies(boundId, target), boundId, new List<Qualification>(), PriorityLayers.Default)
        {
            this.Target = target;
            MasterLog.DebugWriteLine("Target: " + this.Target.ToString());
            this.HitTimer = new TickTimer(30);
        }

        private TillTask()
        {
        }

        protected static Dependencies GetDependencies(Guid boundId, Point3D target)
        {
            ObservableCollection<MagicalTask> deps = new ObservableCollection<MagicalTask>
            {
                new BecomeAdjacentTask(boundId, target)
            };

            return new Dependencies(deps);
        }

        public override void MakePreparations(Living living)
        {
            Tile tile = World.Data.World.GetTile(living.DimensionId, this.Target.X, this.Target.Y);
            this.Tillable = tile.GetComponent<ComponentTillable>();
        }

        public override void Reset()
        {
            //Nothing to do here...
        }

        public override void Tick(Living l)
        {
            if (this.HitTimer.Allow())
            {
                Tile tile = World.Data.World.GetTile(l.DimensionId, this.Target.X, this.Target.Y);

                List<Item> drop = this.Tillable.TillSomePercent(this.Tillable.PercentTillTick, this.Target);

                if (drop?.Count > 0)
                {
                    ItemAdder.AddItem(drop[0], l.GetExactComponent<ComponentSelectable>().MapLocation, l.DimensionId);
                }

                if (this.Tillable.PercentTilled > 1)
                {
                    Tile tillableTile = this.Tillable.ResultingTile(this.Target);
                    World.Data.World.Dimensions[this.Target.DimensionId][this.Target.X, this.Target.Y] = tillableTile;
                    this.CompleteTask();
                }
            }
        }

        public override bool CreateDependencies(Living l)
        {
            return true;
        }
    }
}