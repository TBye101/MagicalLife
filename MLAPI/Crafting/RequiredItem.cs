using System;
using MLAPI.World.Base;
using ProtoBuf;

namespace MLAPI.Crafting
{
    /// <summary>
    /// Holds an item and the amount required for various crafting purposes.
    /// </summary>
    [ProtoContract]
    public struct RequiredItem : IEquatable<RequiredItem>
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

        public bool Equals(RequiredItem other)
        {
            return this.Item.Equals(other.Item) && this.Count == other.Count;
        }
    }
}