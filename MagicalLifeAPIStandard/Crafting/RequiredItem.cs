using MagicalLifeAPI.World.Base;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeAPI.Crafting
{
    /// <summary>
    /// Holds an item and the amount required for various crafting purposes.
    /// </summary>
    [ProtoContract]
    public struct RequiredItem
    {
        [ProtoMember(1)]
        public Item Item { get; set; }

        [ProtoMember(2)]
        public int Count { get; set; }

        public RequiredItem(Item item, int count)
        {
            this.Item = item;
            this.Count = count;
        }
    }
}
