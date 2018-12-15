using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Sound;
using MagicalLifeAPI.World.Base;
using ProtoBuf;
using System.Collections.Generic;

namespace MagicalLifeAPI.Components.Resource
{
    [ProtoContract]
    public class DropWhenCompletelyHarvested : AbstractHarvestable
    {
        [ProtoMember(1)]
        protected List<Item> Items { get; set; }

        /// <summary>
        /// The sound that plays whenever harvesting happens.
        /// </summary>
        [ProtoMember(2)]
        protected string HarvestSound { get; set; }

        public DropWhenCompletelyHarvested(List<Item> items, string mineSound)
        {
            this.Items = items;
            this.HarvestSound = mineSound;
        }

        public DropWhenCompletelyHarvested()
        {
        }

        public override List<Item> Harvested()
        {
            return this.Items;
        }

        protected override List<Item> HarvestPercent(float percentMined, Point2D position)
        {
            FMODUtil.RaiseEvent(this.HarvestSound, "", 0, position);
            return null;
        }
    }
}