using MagicalLifeAPI.Components.Resource;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entity.AI.Task.Qualifications;
using MagicalLifeAPI.Entity.Skills;
using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.Registry.ItemRegistry;
using MagicalLifeAPI.Util.Reusable;
using MagicalLifeAPI.World.Base;
using ProtoBuf;
using System;
using System.Collections.Generic;

namespace MagicalLifeAPI.Entity.AI.Task.Tasks
{
    [ProtoContract]
    public class HarvestTask : MagicalTask
    {
        [ProtoMember(1)]
        public Point2D Target { get; private set; }

        [ProtoMember(2)]
        private IHarvestable Harvestable { get; set; }

        [ProtoMember(3)]
        private TickTimer HitTimer { get; set; }

        public HarvestTask(Point2D target, Guid boundID)
            : base(GetDependencies(boundID, target), boundID, GetQualifications(), PriorityLayers.Default)
        {
            this.Target = target;
            MasterLog.DebugWriteLine("Target: " + this.Target.ToString());
            this.HitTimer = new TickTimer(30);
        }

        private HarvestTask()
        {
        }

        protected static List<Qualification> GetQualifications()
        {
            return new List<Qualification>
            {
                new HasSkillQualification(HarvestingSkill.InternalIDName)
            };
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
            this.Harvestable = tile.Resources;
            if (tile.Resources == null)
            {
                MasterLog.DebugWriteLine("Minable is null");
            }
        }

        public override void Reset()
        {
            //Nothing to do here...
        }

        /// <summary>
        /// Determines how much to harvest based upon the creatures skill.
        /// </summary>
        /// <returns></returns>
        private double CalculatePercentHarvest(HarvestingSkill l)
        {
            float baseAmount = .1F;
            return baseAmount + Math.Sqrt(l.SkillAmount.GetValue() / 100);
        }

        public override void Tick(Living l)
        {
            if (this.HitTimer.Allow())
            {
                //Locate harvest skill.
                Skill skill = l.CreatureSkills.Find(x => x.InternalName == HarvestingSkill.InternalIDName);
                HarvestingSkill harvestSkill = (HarvestingSkill)skill;

                //Calculate how much to mine based upon skill of creature in harvesting
                double amount = this.CalculatePercentHarvest(harvestSkill);

                //Harvest whatever
                List<World.Base.Item> drop =
                    this.Harvestable.HarvestingBehavior.HarvestSomePercent(amount, this.Target);

                //Give out XP for the harvest skill.
                skill.GainXP(1);

                if (drop != null && drop.Count > 0)
                {
                    int length = drop.Count;
                    for (int i = 0; i < length; i++)
                    {
                        this.DropItem(l, drop[i]);
                    }
                }

                if (this.Harvestable.HarvestingBehavior.PercentHarvested > 1)
                {
                    this.RemoveResource(l.Dimension);
                    this.CompleteTask();
                }
            }
        }

        /// <summary>
        /// Drops the result of the harvesting down.
        /// </summary>
        /// <param name="l"></param>
        /// <param name="drop"></param>
        private void DropItem(Living l, Item drop)
        {
            //The tile the entity is standing on
            Tile entityOn = World.Data.World.GetTile(l.Dimension, l.MapLocation.X, l.MapLocation.Y);

            if (entityOn.Item == null || entityOn.Item.GetType() == drop.GetType())
            {
                ItemAdder.AddItem(drop, l.MapLocation, l.Dimension);
            }
            else
            {
                l.Inventory.AddItem(drop);
                Point2D emtpyTile = ItemFinder.FindItemEmptyTile(entityOn.MapLocation, l.Dimension);
                DropItemTask task = new DropItemTask(emtpyTile, l.Dimension, drop, l.ID, Guid.NewGuid());
                task.ReservedFor = l.ID;
                TaskManager.Manager.AddTask(task);
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