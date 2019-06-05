using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entity.AI.Task.Qualifications;
using MagicalLifeAPI.Error.InternalExceptions;
using MagicalLifeAPI.Registry.ItemRegistry;
using MagicalLifeAPI.World.Base;
using ProtoBuf;
using System;
using System.Collections.Generic;

namespace MagicalLifeAPI.Entity.AI.Task.Tasks
{
    /// <summary>
    /// Has the character pick up the item specified.
    /// Reserves the item that is to be picked up.
    /// </summary>
    [ProtoContract]
    public class GrabSpecificItemTask : MagicalTask
    {
        /// <summary>
        /// The task used to move to the nearest item.
        /// </summary>
        [ProtoMember(1)]
        private MoveTask Move;

        [ProtoMember(2)]
        private bool MoveTaskCompleted;

        [ProtoMember(3)]
        protected Point2D ReservedItemLocation;

        private object SyncObject = new object();

        public GrabSpecificItemTask(Guid boundID, Point2D itemLocation, int dimension)
            : base(Dependencies.CreateEmpty(), boundID, GetQualifications(),
                  PriorityLayers.Default)
        {
            this.MoveTaskCompleted = false;
            this.ReserveItem(itemLocation, dimension);
            this.ReservedItemLocation = itemLocation;
        }

        protected GrabSpecificItemTask()
        {
            //Protobuf-net constructor
        }

        private void ReserveItem(Point2D itemLocation, int dimension)
        {
            Tile containing = World.Data.World.GetTile(dimension, itemLocation.X, itemLocation.Y);

            Item item = containing.MainObject as Item;
            if (item != null && item.ReservedID == Guid.Empty)
            {
                item.ReservedID = this.ID;
            }
            else
            {
                throw new UnexpectedStateException("An item was unexpectedly reserved");
            }
        }

        private static List<Qualification> GetQualifications()
        {
            return new List<Qualification>
            {
                new CanMoveQualification(),
            };
        }

        public override void MakePreparations(Living l)
        {
            //Setup the task to move to the reserved item
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
            //This method is not in use yet
        }

        public override void Tick(Living l)
        {
            lock (this.SyncObject)
            {
                if (this.MoveTaskCompleted)
                {
                    //Pick it up
                    Item pickedUp = ItemRemover.RemoveAllItems(this.ReservedItemLocation, l.Dimension);
                    pickedUp.ReservedID = Guid.Empty;
                    l.Inventory.AddItem(pickedUp);
                    this.CompleteTask();
                }
                else
                {
                    //Move closer to it
                    this.Move.Tick(l);
                }
            }
        }

        public override bool CreateDependencies(Living l)
        {
            return true;
        }
    }
}