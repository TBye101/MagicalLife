using System;
using MLAPI.GameRegistry.Items;
using MLAPI.Networking.Serialization;
using ProtoBuf;

namespace MLAPI.Networking.Messages
{
    [ProtoContract]
    public class WorldTransferRegistryMessage : BaseMessage
    {
        [ProtoMember(1)]
        public ItemRegistry ItemReg { get; private set; }

        [ProtoMember(2)]
        public Guid DimensionId { get; private set; }

        public WorldTransferRegistryMessage(ItemRegistry itemReg, Guid dimensionId)
            : base(NetMessageId.WorldTransferRegistryMessage)
        {
            this.ItemReg = itemReg;
            this.DimensionId = dimensionId;
        }

        public WorldTransferRegistryMessage()
        {
            //Protobuf-net constructor.
        }
    }
}