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
    /// Has the character grab a certain amount of a specific item.
    /// </summary>
    [ProtoContract]
    public class GrabItemQuantity : MagicalTask
    {
        [ProtoMember(1)]
        private int ItemID;

        [ProtoMember(2)]
        private int Amount;

        public GrabItemQuantity(Guid boundID, int itemID, int amount)
            : base(Dependencies.None, boundID, GetQualifications(), PriorityLayers.Default)
        {
            this.ItemID = itemID;
            this.Amount = amount;
        }

        public GrabItemQuantity(Guid boundID, Item item, int amount)
            : this(boundID, item.ItemID, amount)
        {
        }

        protected GrabItemQuantity()
        {
            //Protobuf-net constructor.
        }

        private static List<Qualification> GetQualifications()
        {
            return new List<Qualification>
            {
                new CanMoveQualification()
            };
        }

        public override void MakePreparations(Living l)
        {
            List<Point2D> locations = ItemFinder.LocateQuantityOfItem(this.ItemID, this.Amount, Point2D.Zero, l.Dimension);

            foreach (Point2D item in locations)
            {
                GrabSpecificItemTask task = new GrabSpecificItemTask(this.BoundID, item, l.Dimension);
                this.Dependencies.PreRequisite.Add(task);
            }
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
