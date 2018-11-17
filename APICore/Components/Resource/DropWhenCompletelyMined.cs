using MagicalLifeAPI.Sound;
using MagicalLifeAPI.World.Base;
using ProtoBuf;
using System.Collections.Generic;

namespace MagicalLifeAPI.Components.Resource
{
    [ProtoContract]
    public class DropWhenCompletelyMined : AbstractMinable
    {
        [ProtoMember(1)]
        protected List<Item> Items { get; set; }

        public DropWhenCompletelyMined(List<Item> items)
        {
            this.Items = items;
        }

        public DropWhenCompletelyMined()
        {
        }

        public override List<Item> Mined()
        {
            return this.Items;
        }

        protected override List<Item> MinePercent(float percentMined)
        {
            FMODUtil.RaiseEvent(EffectsTable.PickaxeHit);
            return null;
        }
    }
}