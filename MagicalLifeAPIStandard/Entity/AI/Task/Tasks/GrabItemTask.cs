using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entity.AI.Task.Qualifications;
using MagicalLifeAPI.Registry.ItemRegistry;
using MagicalLifeAPI.World.Base;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MagicalLifeAPI.Entity.AI.Task.Tasks
{
    /// <summary>
    /// Gets the nearest of a certain item.
    /// </summary>
    [ProtoContract]
    public class GrabItemTask : MagicalTask
    {
        [ProtoMember(1)]
        protected readonly int ItemID;

        [ProtoMember(2)]
        protected Point2D ReservedItemLocation;

        public GrabItemTask(Guid boundID, int itemID, int dimension)
            : base(Dependencies.CreateEmpty(), boundID, GetQualifications(itemID, dimension),
                  PriorityLayers.Default)
        {
            this.ItemID = itemID;
        }

        public GrabItemTask(Guid boundID, Item item, int dimension)
            : this(boundID, item.ItemID, dimension)
        {
        }

        protected GrabItemTask()
        {
            //Protobuf-net constructor
        }

        private static Dependencies GetDependencies(Guid boundID, int itemID, int dimension)
        {
            Point2D nearest = ItemFinder.FindNearestUnreserved(itemID, Point2D.Zero, dimension);

            ObservableCollection<MagicalTask> dependency = new ObservableCollection<MagicalTask>
            {
                new GrabSpecificItemTask(boundID, nearest, dimension)
            };

            return new Dependencies(dependency);
        }

        private static List<Qualification> GetQualifications(int itemID, int dimension)
        {
            return new List<Qualification>
            {
                new CanMoveQualification(),
                new IsItemAvailibleQualification(itemID, dimension)
            };
        }

        public override bool CreateDependencies(Living l)
        {
            this.Dependencies = GetDependencies(this.BoundID, this.ItemID, l.Dimension);
            return true;
        }

        public override void MakePreparations(Living l)
        {
        }

        public override void Reset()
        {
        }

        public override void Tick(Living l)
        {
            this.CompleteTask();
        }
    }
}