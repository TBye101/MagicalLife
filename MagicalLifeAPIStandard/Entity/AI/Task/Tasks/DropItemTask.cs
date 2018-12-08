using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entity.AI.Task.Qualifications;
using MagicalLifeAPI.Registry.ItemRegistry;
using MagicalLifeAPI.World.Base;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

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

        [ProtoMember(3)]
        private Item ToDrop { get; set; }

        /// <param name="location">The location to drop the item at.</param>
        /// <param name="dimension">The dimension to drop the item in.</param>
        /// <param name="item">The item to drop.</param>
        /// <param name="creatureID">The id of the creature with the object.</param>
        public DropItemTask(Point2D location, int dimension, Item item, Guid creatureID) : base(GetDependencies(creatureID, location), creatureID, GetQualifications(creatureID))
        {
            this.Location = location;
            this.Dimension = dimension;
            this.ToDrop = item;
        }

        private static List<Qualification> GetQualifications(Guid creatureID)
        {
            return new List<Qualification>()
            {
                new SpecificCreatureQualification(creatureID)
            };
        }

        public DropItemTask() : base()
        {
            //Protobuf-net constructor
        }

        protected static Dependencies GetDependencies(Guid boundID, Point2D target)
        {
            List<MagicalTask> deps = new List<MagicalTask>
            {
                new MoveTask(boundID, target)
            };

            return new Dependencies(deps);
        }

        public override void MakePreparations(Living l)
        {
        }

        public override void Reset()
        {
        }

        public override void Tick(Living l)
        {
            ItemAdder.AddItem(this.ToDrop, this.Location, this.Dimension);
            this.CompleteTask();
        }
    }
}
