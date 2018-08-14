using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Registry.ItemRegistry;
using MagicalLifeAPI.World.Base;
using ProtoBuf;

namespace MagicalLifeAPI.Networking.World.Modifiers
{
    /// <summary>
    /// Creates a new item in a server/client that receives this message to keep them in sync.
    /// </summary>
    [ProtoContract]
    public class ItemCreatedModifier : AbstractWorldModifier
    {
        [ProtoMember(1)]
        public Item Item { get; private set; }

        [ProtoMember(2)]
        public Point2D Location { get; private set; }

        [ProtoMember(3)]
        public int Dimension { get; private set; }

        /// <param name="item">The item which is being added, and needs to be synced.</param>
        /// <param name="mapLocation">The location at which the item was added at.</param>
        /// <param name="dimension">The dimension in which the item was added at.</param>
        public ItemCreatedModifier(Item item, Point2D mapLocation, int dimension)
        {
            this.Item = item;
            this.Location = mapLocation;
            this.Dimension = dimension;
        }

        private ItemCreatedModifier()
        {
            //Protobuf-net constructor
        }

        public override void ModifyWorld()
        {
            ItemAdder.AddItem(this.Item, this.Location, this.Dimension);
        }
    }
}