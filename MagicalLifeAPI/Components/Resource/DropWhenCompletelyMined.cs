using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicalLifeAPI.World.Base;
using ProtoBuf;

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
            return null;
        }
    }
}
