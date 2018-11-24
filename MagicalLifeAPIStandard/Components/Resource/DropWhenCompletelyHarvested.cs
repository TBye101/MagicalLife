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

        public DropWhenCompletelyHarvested(List<Item> items)
        {
            this.Items = items;
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
            FMODUtil.RaiseEvent(SoundsTable.PickaxeHit, "", 0, position);
            return null;
        }
    }
}