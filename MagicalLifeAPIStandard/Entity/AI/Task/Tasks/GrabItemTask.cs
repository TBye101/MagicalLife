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

        public GrabItemTask(Guid boundID, int itemID, Guid dimensionID)
            : base(Dependencies.CreateEmpty(), boundID, GetQualifications(itemID, dimensionID),
                  PriorityLayers.Default)
        {
            this.ItemID = itemID;
        }

        public GrabItemTask(Guid boundID, Item item, Guid dimensionID)
            : this(boundID, item.ItemID, dimensionID)
        {
        }

        protected GrabItemTask()
        {
            //Protobuf-net constructor
        }

        private static Dependencies GetDependencies(Guid boundID, int itemID, Guid dimensionID)
        {
            Point2D nearest = ItemFinder.FindNearestUnreserved(itemID, new Point3D(0, 0, dimensionID));

            ObservableCollection<MagicalTask> dependency = new ObservableCollection<MagicalTask>
            {
                new GrabSpecificItemTask(boundID, Point3D.From2D(nearest, dimensionID))
            };

            return new Dependencies(dependency);
        }

        private static List<Qualification> GetQualifications(int itemID, Guid dimensionID)
        {
            return new List<Qualification>
            {
                new CanMoveQualification(),
                new IsItemAvailibleQualification(itemID, dimensionID)
            };
        }

        public override bool CreateDependencies(Living l)
        {
            this.Dependencies = GetDependencies(this.BoundID, this.ItemID, l.DimensionID);
            return true;
        }

        public override void MakePreparations(Living l)
        {
            //No preparations to make
        }

        public override void Reset()
        {
            //This method is not in use yet
        }

        public override void Tick(Living l)
        {
            this.CompleteTask();
        }
    }
}