using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entity.AI.Task.Qualifications;
using MagicalLifeAPI.Error.InternalExceptions;
using MagicalLifeAPI.GUI;
using MagicalLifeAPI.Registry.ItemRegistry;
using MagicalLifeAPI.World.Base;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeAPI.Entity.AI.Task.Tasks
{
    /// <summary>
    /// Gets the nearest of a certain item.
    /// </summary>
    [ProtoContract]
    public class GetItemTask : MagicalTask
    {
        /// <summary>
        /// The task used to move to the nearest item.
        /// </summary>
        [ProtoMember(1)]
        private MoveTask Move;

        [ProtoMember(2)]
        private bool MoveTaskCompleted;

        [ProtoMember(3)]
        protected readonly int ItemID;

        [ProtoMember(4)]
        protected Point2D ReservedItemLocation;

        public GetItemTask(Guid boundID, Item item, int dimension) 
            : base(Dependencies.None, boundID, GetQualifications(item.ItemID, dimension),
                  PriorityLayers.Default)
        {
            this.ItemID = item.ItemID;
            this.MoveTaskCompleted = false;
        }

        public GetItemTask(Guid boundID, int itemID, int dimension)
            : base(Dependencies.None, boundID, GetQualifications(itemID, dimension),
                  PriorityLayers.Default)
        {
            this.ItemID = itemID;
            this.MoveTaskCompleted = false;
        }

        private static List<Qualification> GetQualifications(int itemID, int dimension)
        {
            return new List<Qualification>
            {
                new CanMoveQualification(),
                new IsItemAvailible(itemID, dimension)
            };
        }

        public override void MakePreparations(Living l)
        {
            ComponentSelectable location = l.GetComponent<ComponentSelectable>();
            this.ReservedItemLocation = ItemFinder.FindNearestUnreserved(this.ItemID, location.MapLocation, l.Dimension);

            //Reserve the item
            Tile containing = World.Data.World.GetTile(l.Dimension, this.ReservedItemLocation.X, this.ReservedItemLocation.Y);

            if (containing.Item.ReservedID == Guid.Empty)
            {
                containing.Item.ReservedID = this.ID;
            }
            else
            {
                throw new UnexpectedStateException("An item was reserved unexpectedly");
            }

            this.Move = new MoveTask(this.BoundID, this.ReservedItemLocation);
            this.Move.Completed += this.Move_Completed;
            this.Move.MakePreparations(l);
        }

        private void Move_Completed(MagicalTask task)
        {
            this.MoveTaskCompleted = true;
        }

        public override void Reset()
        {
        }

        public override void Tick(Living l)
        {
            if (this.MoveTaskCompleted)
            {
                //Pick it up
                Item pickedUp = ItemRemover.RemoveAllItems(this.ReservedItemLocation, l.Dimension);
                l.Inventory.AddItem(pickedUp);
            }
            else
            {
                //Move closer to it
                this.Move.Tick(l);
            }
        }
    }
}
