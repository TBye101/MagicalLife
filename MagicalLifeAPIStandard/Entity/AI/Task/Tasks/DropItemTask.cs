using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entity.AI.Task.Qualifications;
using MagicalLifeAPI.Registry.ItemRegistry;
using MagicalLifeAPI.World.Base;
using ProtoBuf;
using System;
using System.Collections.Generic;

namespace MagicalLifeAPI.Entity.AI.Task.Tasks
{
    /// <summary>
    /// Has the creature drop an item at the specified point.
    /// </summary>
    [ProtoContract]
    public class DropItemTask : MagicalTask
    {
        [ProtoMember(1)]
        private Point2D Location { get; set; }

        [ProtoMember(2)]
        private int Dimension { get; set; }

        /// <summary>
        /// The ID of the item to drop.
        /// </summary>
        [ProtoMember(3)]
        private int ItemID;

        /// <summary>
        /// The amount of the item to drop.
        /// </summary>
        [ProtoMember(4)]
        private int ItemAmount;

        /// <param name="location">The location to drop the item at.</param>
        /// <param name="dimension">The dimension to drop the item in.</param>
        /// <param name="item">The item to drop.</param>
        /// <param name="creatureID">The id of the creature with the object.</param>
        public DropItemTask(Point2D location, int dimension, Item item, Guid creatureID, Guid boundID)
            : base(GetDependencies(boundID, location, creatureID),
                  boundID, GetQualifications(creatureID), PriorityLayers.SpecificCreature)
        {
            this.Location = location;
            this.Dimension = dimension;
            this.ItemID = item.ItemID;
            this.ItemAmount = item.CurrentlyStacked;
        }

        private static List<Qualification> GetQualifications(Guid creatureID)
        {
            return new List<Qualification>
            {
                new SpecificCreatureQualification(creatureID)
            };
        }

        public DropItemTask()
        {
            //Protobuf-net constructor
        }

        protected static Dependencies GetDependencies(Guid boundID, Point2D target, Guid creatureID)
        {
            MoveTask move = new MoveTask(boundID, target, PriorityLayers.SpecificCreature);
            move.Qualifications.Add(new SpecificCreatureQualification(creatureID));

            List<MagicalTask> deps = new List<MagicalTask>
            {
                move
            };

            return new Dependencies(deps);
        }

        public override void MakePreparations(Living l)
        {
            //No preparations to make here
        }

        public override void Reset()
        {
            //Nothing that I can think of to reset right now.
        }

        public override void Tick(Living l)
        {
            List<Item> toDrop = l.Inventory.RemoveSomeOfItem(this.ItemID, this.ItemAmount);

            if (toDrop != null)
            {
                //Drop all of the items that should be dropped.
                foreach (Item item in toDrop)
                {
                    ItemAdder.AddItem(item, this.Location, this.Dimension);
                }
            }

            this.CompleteTask();
        }
    }
}