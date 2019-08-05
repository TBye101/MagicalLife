using System;
using MLAPI.Networking.Serialization;
using MLAPI.World.Data;
using ProtoBuf;

namespace MLAPI.Networking.Messages
{
    [ProtoContract]
    public class WorldTransferBodyMessage : BaseMessage
    {
        [ProtoMember(1)]
        public Chunk Chunk { get; private set; }

        [ProtoMember(2)]
        public Guid DimensionId { get; private set; }

        public WorldTransferBodyMessage(Chunk chunk, Guid dimensionId) : base(NetMessageId.WorldTransferBodyMessage)
        {
            this.Chunk = chunk;
            this.DimensionId = dimensionId;
        }

        public WorldTransferBodyMessage()
        {
            //Protobuf-net constructor.
        }
    }
}