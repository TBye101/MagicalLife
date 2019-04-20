using MagicalLifeAPI.Crafting;
using MagicalLifeAPI.World.Base;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeAPI.Entity.AI.Task.Tasks
{
    [ProtoContract]
    public class CraftSimpleItemTask : MagicalTask
    {
        /// <summary>
        /// The recipe used to craft a item.
        /// </summary>
        [ProtoMember(1)]
        protected SimpleItemRecipe SimpleRecipe { get; set; }

        [ProtoMember(2)]
        protected int Quantity { get; set; }

        public CraftSimpleItemTask(Guid boundID, SimpleItemRecipe simpleRecipe, int quantity)
            : base(Dependencies.CreateEmpty(), boundID, new List<Qualification>(), PriorityLayers.Default)
        {
            this.SimpleRecipe = simpleRecipe;
            this.Quantity = quantity;
        }

        protected CraftSimpleItemTask()
        {
            //Protobuf-net constructor
        }

        public override void MakePreparations(Living l)
        {
        }

        public override void Reset()
        {
        }

        public override void Tick(Living l)
        {
            Item craft = this.SimpleRecipe.Craft(l.Inventory, this.Quantity);
            l.Inventory.AddItem(craft);
            this.CompleteTask();
        }

        public override void CreateDependencies(Living l)
        {
            foreach (RequiredItem requiredItem in this.SimpleRecipe.RequiredItems)
            {
                this.Dependencies.PreRequisite.Add(new GrabItemQuantity(this.BoundID, requiredItem.Item.ItemID, requiredItem.Count));
            }
        }
    }
}
