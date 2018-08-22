using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.Registry.ItemRegistry;
using ProtoBuf;
using System;

namespace MagicalLifeAPI.Networking.Messages
{
    [ProtoContract]
    public class WorldTransferRegistryMessage : BaseMessage
    {
        [ProtoMember(1)]
        public ItemRegistry ItemReg { get; private set; }

        [ProtoMember(2)]
        public Guid DimensionID { get; private set; }

        public WorldTransferRegistryMessage(ItemRegistry itemReg, Guid dimensionID) : base(NetMessageID.WorldTransferRegistryMessage)
        {
            this.ItemReg = itemReg;
            this.DimensionID = dimensionID;
        }

        public WorldTransferRegistryMessage() : base(NetMessageID.WorldTransferRegistryMessage)
        {
        }
    }
}