using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MLAPI.DataTypes;
using MLAPI.Entity.AI.Task.Qualifications;
using MLAPI.GameRegistry.Items;
using MLAPI.World.Base;
using ProtoBuf;

namespace MLAPI.Entity.AI.Task.Tasks
{
    /// <summary>
    /// Has the creature drop an item at the specified point.
    /// </summary>
    [ProtoContract]
    public class DropItemTask : MagicalTask
    {
        [ProtoMember(1)]
        private Point3D Location { get; set; }

        /// <summary>
        /// The ID of the item to drop.
        /// </summary>
        [ProtoMember(2)]
        private readonly int ItemId;

        /// <summary>
        /// The amount of the item to drop.
        /// </summary>
        [ProtoMember(3)]
        private readonly int ItemAmount;

        /// <param name="location">The location to drop the item at.</param>
        /// <param name="dimension">The dimension to drop the item in.</param>
        /// <param name="item">The item to drop.</param>
        /// <param name="creatureId">The id of the creature with the object.</param>
        public DropItemTask(Point3D location, Item item, Guid creatureId, Guid boundId)
            : base(GetDependencies(boundId, location, creatureId),
                  boundId, GetQualifications(creatureId), PriorityLayers.SpecificCreature)
        {
            this.Location = location;
            this.ItemId = item.ItemId;
            this.ItemAmount = item.CurrentlyStacked;
        }

        private static List<Qualification> GetQualifications(Guid creatureId)
        {
            return new List<Qualification>
            {
                new SpecificCreatureQualification(creatureId)
            };
        }

        public DropItemTask()
        {
            //Protobuf-net constructor
        }

        protected static Dependencies GetDependencies(Guid boundId, Point3D target, Guid creatureId)
        {
            MoveTask move = new MoveTask(boundId, target, PriorityLayers.SpecificCreature);
            move.Qualifications.Add(new SpecificCreatureQualification(creatureId));

            ObservableCollection<MagicalTask> deps = new ObservableCollection<MagicalTask>
            {
                move
            };

            return new Dependencies(deps);
        }

        public override void MakePreparations(Living living)
        {
            //No preparations to make here
        }

        public override void Reset()
        {
            //Nothing that I can think of to reset right now.
        }

        public override void Tick(Living l)
        {
            List<Item> toDrop = l.Inventory.RemoveSomeOfItem(this.ItemId, this.ItemAmount);

            if (toDrop != null)
            {
                //Drop all of the items that should be dropped.
                foreach (Item item in toDrop)
                {
                    ItemAdder.AddItem(item, this.Location, this.Location.DimensionId);
                }
            }

            this.CompleteTask();
        }

        public override bool CreateDependencies(Living l)
        {
            return true;
        }
    }
}