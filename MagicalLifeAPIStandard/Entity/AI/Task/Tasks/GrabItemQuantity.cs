using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entity.AI.Task.Qualifications;
using MagicalLifeAPI.Registry.ItemRegistry;
using MagicalLifeAPI.World.Base;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MagicalLifeAPI.Entity.AI.Task.Tasks
{
    /// <summary>
    /// Has the character grab a certain amount of a specific item.
    /// </summary>
    [ProtoContract]
    public class GrabItemQuantity : MagicalTask
    {
        [ProtoMember(1)]
        private int ItemID;

        [ProtoMember(2)]
        private int Amount;

        public GrabItemQuantity(Guid boundID, int itemID, int amount, int dimension)
            : base(Dependencies.CreateEmpty(), boundID, GetQualifications(itemID, dimension), PriorityLayers.Default)
        {
            this.ItemID = itemID;
            this.Amount = amount;
        }

        public GrabItemQuantity(Guid boundID, Item item, int amount, int dimension)
            : this(boundID, item.ItemID, amount, dimension)
        {
        }

        protected GrabItemQuantity()
        {
            //Protobuf-net constructor.
        }

        private static List<Qualification> GetQualifications(int itemID, int dimension)
        {
            return new List<Qualification>
            {
                new CanMoveQualification(),
                new IsItemAvailibleQualification(itemID, dimension)
            };
        }

        public override bool CreateDependencies(Living l)//Need to return a bool to say if this step was successful.
        {
            List<Point2D> locations = ItemFinder.LocateUnreservedQuantityOfItem(this.ItemID, this.Amount, Point2D.Zero, l.Dimension);

            if (locations != null && locations.Any())
            {
                foreach (Point2D item in locations)
                {
                    GrabSpecificItemTask task = new GrabSpecificItemTask(this.BoundID, item, l.Dimension);
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