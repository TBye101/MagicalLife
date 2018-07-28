using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicalLifeAPI.World.Base;

namespace MagicalLifeAPI.Components.Resource
{
    public class DropWhenCompletelyMined : AbstractMinable
    {
        protected List<Item> Items { get; set; }

        public DropWhenCompletelyMined(List<Item> items)
        {
            this.Items = items;
        }

        public override List<Item> Mined()
        {
            return this.Items;
        }

        public override List<Item> MiningInProgress(float percentMined)
        {
            return null;
        }
    }
}
