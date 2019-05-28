using MagicalLifeAPI.Components.Resource;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.GUI;
using MagicalLifeAPI.Registry.ItemRegistry;
using MagicalLifeAPI.Util.Reusable;
using MagicalLifeAPI.World.Base;
using MagicalLifeAPI.World.Tiles;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MagicalLifeAPI.Entity.AI.Task.Tasks
{
    [ProtoContract]
    public class TillTask : MagicalTask
    {
        [ProtoMember(1)]
        public Point2D Target { get; private set; }

        /// <summary>
        /// The tillable component of the tile this task is supposed to till.
        /// </summary>
        [ProtoMember(2)]
        private ComponentTillable Tillable { get; set; }

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
            ObservableCollection<MagicalTask> deps = new ObservableCollection<MagicalTask>
            {
                new BecomeAdjacentTask(boundID, target)
            };

            return new Dependencies(deps);
        }

        public override void MakePreparations(Living living)
        {
            Tile tile = World.Data.World.GetTile(living.Dimension, this.Target.X, this.Target.Y);
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
                Tile tile = World.Data.World.GetTile(l.Dimension, this.Target.X, this.Target.Y);

                List<Item> drop = null;
                if (tile is Grass)
                {
                    drop = this.Tillable.TillSomePercent(.02F, this.Target);
                }
                else if (tile is Dirt)
                {
                    drop = this.Tillable.TillSomePercent(.07F, this.Target);
                }

                if (drop?.Count > 0)
                {
                    ItemAdder.AddItem(drop[0], l.GetExactComponent<ComponentSelectable>().MapLocation, l.Dimension);
                }

                if (this.Tillable.PercentTilled > 1)
                {
                    Tile tillableTile = new TilledDirt(new Point2D(this.Target.X, this.Target.Y), this.Dimension);
                    World.Data.World.Dimensions[this.Dimension][this.Target.X, this.Target.Y] = tillableTile;
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