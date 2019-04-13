using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entity.AI.Task.Qualifications;
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
        private readonly MoveTask Move;

        [ProtoMember(2)]
        private readonly int ItemID;

        public GetItemTask(Guid boundID, Item item) 
            : base(Dependencies.None, boundID, GetQualifications(), PriorityLayers.Default)
        {
            this.ItemID = item.ItemID;
        }

        public GetItemTask(Guid boundID, int itemID)
            : base(Dependencies.None, boundID, GetQualifications(), PriorityLayers.Default)
        {
            this.ItemID = itemID;
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
            ComponentSelectable location = l.GetComponent<ComponentSelectable>();
            Point2D closest = ItemFinder.FindNearestUnreserved(this.ItemID, location.MapLocation, l.Dimension);
            //if closest exists
            //else reset/re-queue the task
            //Or make a qualification to check that (slow)
        }

        public override void Reset()
        {
        }

        public override void Tick(Living l)
        {
            throw new NotImplementedException();
        }
    }
}
