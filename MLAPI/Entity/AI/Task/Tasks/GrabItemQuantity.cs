using System;
using System.Collections.Generic;
using System.Linq;
using MLAPI.DataTypes;
using MLAPI.Entity.AI.Task.Qualifications;
using MLAPI.GameRegistry.Items;
using MLAPI.World.Base;
using ProtoBuf;

namespace MLAPI.Entity.AI.Task.Tasks
{
    /// <summary>
    /// Has the character grab a certain amount of a specific item.
    /// </summary>
    [ProtoContract]
    public class GrabItemQuantity : MagicalTask
    {
        [ProtoMember(1)]
        private int ItemId;

        [ProtoMember(2)]
        private int Amount;

        public GrabItemQuantity(Guid boundId, int itemId, int amount, Guid dimensionId)
            : base(Dependencies.CreateEmpty(), boundId, GetQualifications(itemId, dimensionId), PriorityLayers.Default)
        {
            this.ItemId = itemId;
            this.Amount = amount;
        }

        public GrabItemQuantity(Guid boundId, Item item, int amount, Guid dimensionId)
            : this(boundId, item.ItemId, amount, dimensionId)
        {
        }

        protected GrabItemQuantity()
        {
            //Protobuf-net constructor.
        }

        private static List<Qualification> GetQualifications(int itemId, Guid dimensionId)
        {
            return new List<Qualification>
            {
                new CanMoveQualification(),
                new IsItemAvailibleQualification(itemId, dimensionId)
            };
        }

        public override bool CreateDependencies(Living l)//Need to return a bool to say if this step was successful.
        {
            List<Point3D> locations = ItemFinder.LocateUnreservedQuantityOfItem(this.ItemId, this.Amount, new Point3D(0, 0, l.DimensionId));

            if (locations != null && locations.Any())
            {
                foreach (Point3D item in locations)
                {
                    GrabSpecificItemTask task = new GrabSpecificItemTask(this.BoundId, item);
                    this.Dependencies.PreRequisite.Add(task);
                }

                return true;
            }

            return false;
        }

        public override void MakePreparations(Living l)
        {
            //No preparations to make yet
        }

        public override void Reset()
        {
            //This method isn't being used yet
        }

        public override void Tick(Living l)
        {
            this.CompleteTask();
        }
    }
}