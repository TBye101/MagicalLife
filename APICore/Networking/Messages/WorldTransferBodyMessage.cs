using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.World.Data;
using ProtoBuf;
using System;

namespace MagicalLifeAPI.Networking.Messages
{
    [ProtoContract]
    public class WorldTransferBodyMessage : BaseMessage
    {
        [ProtoMember(1)]
        public Chunk Chunk { get; private set; }

        [ProtoMember(2)]
        public Guid DimensionID { get; private set; }

        public WorldTransferBodyMessage(Chunk chunk, Guid dimensionID) : base(NetMessageID.WorldTransferBodyMessage)
        {
            this.Chunk = chunk;
            this.DimensionID = dimensionID;
        }

        public WorldTransferBodyMessage() : base(NetMessageID.WorldTransferBodyMessage)
        {
        }
    }
}