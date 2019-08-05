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
    /// Gets the nearest of a certain item.
    /// </summary>
    [ProtoContract]
    public class GrabItemTask : MagicalTask
    {
        [ProtoMember(1)]
        protected readonly int ItemId;

        [ProtoMember(2)]
        protected Point2D ReservedItemLocation;

        public GrabItemTask(Guid boundId, int itemId, Guid dimensionId)
            : base(Dependencies.CreateEmpty(), boundId, GetQualifications(itemId, dimensionId),
                  PriorityLayers.Default)
        {
            this.ItemId = itemId;
        }

        public GrabItemTask(Guid boundId, Item item, Guid dimensionId)
            : this(boundId, item.ItemId, dimensionId)
        {
        }

        protected GrabItemTask()
        {
            //Protobuf-net constructor
        }

        private static Dependencies GetDependencies(Guid boundId, int itemId, Guid dimensionId)
        {
            Point2D nearest = ItemFinder.FindNearestUnreserved(itemId, new Point3D(0, 0, dimensionId));

            ObservableCollection<MagicalTask> dependency = new ObservableCollection<MagicalTask>
            {
                new GrabSpecificItemTask(boundId, Point3D.From2D(nearest, dimensionId))
            };

            return new Dependencies(dependency);
        }

        private static List<Qualification> GetQualifications(int itemId, Guid dimensionId)
        {
            return new List<Qualification>
            {
                new CanMoveQualification(),
                new IsItemAvailibleQualification(itemId, dimensionId)
            };
        }

        public override bool CreateDependencies(Living l)
        {
            this.Dependencies = GetDependencies(this.BoundId, this.ItemId, l.DimensionId);
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