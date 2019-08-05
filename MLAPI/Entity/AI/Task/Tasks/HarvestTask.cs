using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MLAPI.Components;
using MLAPI.Components.Resource;
using MLAPI.DataTypes;
using MLAPI.Entity.AI.Task.Qualifications;
using MLAPI.Entity.Skills;
using MLAPI.Error.InternalExceptions;
using MLAPI.Filing.Logging;
using MLAPI.GameRegistry.Items;
using MLAPI.Util.Reusable;
using MLAPI.World.Base;
using ProtoBuf;

namespace MLAPI.Entity.AI.Task.Tasks
{
    [ProtoContract]
    public class HarvestTask : MagicalTask
    {
        [ProtoMember(1)]
        public Point2D Target { get; private set; }

        [ProtoMember(2)]
        private ComponentHarvestable Harvestable { get; set; }

        [ProtoMember(3)]
        private TickTimer HitTimer { get; set; }

        public HarvestTask(Point3D target, Guid boundId)
            : base(GetDependencies(boundId, target), boundId, GetQualifications(), PriorityLayers.Default)
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
                new HasSkillQualification(HarvestingSkill.InternalIdName)
            };
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
            Resource resource = tile.MainObject as Resource;

            if (resource == null)
            {
                throw new UnexpectedStateException();
            }
            else
            {
                this.Harvestable = resource.GetComponent<ComponentHarvestable>();
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
                Skill skill = l.CreatureSkills.Find(x => x.InternalName == HarvestingSkill.InternalIdName);
                HarvestingSkill harvestSkill = (HarvestingSkill)skill;

                //Calculate how much to mine based upon skill of creature in harvesting
                double amount = this.CalculatePercentHarvest(harvestSkill);

                //Harvest whatever
                List<Item> drop = this.Harvestable.HarvestSomePercent(amount, this.Target);

                //Give out XP for the harvest skill.
                skill.GainXp(1);

                if (drop?.Count > 0 && drop != null)
                {
                    int length = drop.Count;
                    for (int i = 0; i < length; i++)
                    {
                        this.DropItem(l, drop?[i]);
                    }
                }

                if (this.Harvestable.PercentHarvested > 1)
                {
                    this.RemoveResource(l.DimensionId);
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
            ComponentSelectable entityS = l.GetExactComponent<ComponentSelectable>();
            Tile entityOn = World.Data.World.GetTile(l.DimensionId, entityS.MapLocation.X, entityS.MapLocation.Y);

            if (entityOn.MainObject == null || entityOn.MainObject.GetType() == drop.GetType())
            {
                ItemAdder.AddItem(drop, entityS.MapLocation, l.DimensionId);
            }
            else
            {
                l.Inventory.AddItem(drop);
                Point3D emtpyTile = ItemFinder.FindMainObjectEmptyTile(entityOn.GetExactComponent<ComponentSelectable>().MapLocation);
                DropItemTask task = new DropItemTask(emtpyTile, drop, l.Id, Guid.NewGuid());
                task.ReservedFor = l.Id;
                TaskManager.Manager.AddTask(task);
            }
        }

        /// <summary>
        /// Removes the resource from the world, as it has been completely mined up.
        /// </summary>
        private void RemoveResource(Guid dimensionId)
        {
            Tile tile = World.Data.World.GetTile(dimensionId, this.Target.X, this.Target.Y);

            Resource resource = tile.MainObject as Resource;

            if (resource != null)
            {
                tile.MainObject = null;
            }
            tile.ImpendingAction = ActionSelected.None;
        }

        public override bool CreateDependencies(Living l)
        {
            return true;
        }
    }
}