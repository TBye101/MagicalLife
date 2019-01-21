using MagicalLifeAPI.Components.Resource;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.Registry.ItemRegistry;
using MagicalLifeAPI.Util.Reusable;
using MagicalLifeAPI.World.Base;
using MagicalLifeAPI.World.Tiles;
using ProtoBuf;
using System;
using System.Collections.Generic;

namespace MagicalLifeAPI.Entity.AI.Task.Tasks
{
    [ProtoContract]
    public class TillTask : MagicalTask
    {
        [ProtoMember(1)]
        public Point2D Target { get; private set; }

        [ProtoMember(2)]
        private ITillable Tillable { get; set; }

        [ProtoMember(3)]
        private TickTimer HitTimer { get; set; }

        [ProtoMember(4)]
        private int Dimension { get; set; }

        public TillTask(Point2D target, Guid boundID, int dimension)
            : base(GetDependencies(boundID, target), boundID, new List<Qualification>(), PriorityLayers.Default)
        {
            this.Dimension = dimension;
            this.Target = target;
            MasterLog.DebugWriteLine("Target: " + this.Target.ToString());
            this.HitTimer = new TickTimer(30);
        }

        private TillTask()
        {
        }

        protected static Dependencies GetDependencies(Guid boundID, Point2D target)
        {
            List<MagicalTask> deps = new List<MagicalTask>
            {
                new BecomeAdjacentTask(boundID, target)
            };

            return new Dependencies(deps);
        }

        public override void MakePreparations(Living l)
        {
            Tile tile = World.Data.World.GetTile(l.Dimension, this.Target.X, this.Target.Y);
            this.Tillable = (ITillable)tile;
        }

        public override void Reset()
        {
            //Nothing to do here...
        }

        public override void Tick(Living l)
        {
            if (this.HitTimer.Allow())
            {
                Tile tile = World.Data.World.GetTile(l.Dimension, this.Target.X, this.Target.Y);

                List<World.Base.Item> drop = null;
                if (tile is Grass)
                {
                    drop = this.Tillable.TillableBehavior.TillSomePercent(.02F, this.Target);
                }
                else if (tile is Dirt)
                {
                    drop = this.Tillable.TillableBehavior.TillSomePercent(.07F, this.Target);
                }

                if (drop != null && drop.Count > 0)
                {
                    ItemAdder.AddItem(drop[0], l.MapLocation, l.Dimension);
                }

                if (this.Tillable.TillableBehavior.PercentTilled > 1)
                {
                    Tile tillableTile = new TilledDirt(new Point2D(this.Target.X, this.Target.Y));
                    World.Data.World.Dimensions[this.Dimension][this.Target.X, this.Target.Y] = tillableTile;
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