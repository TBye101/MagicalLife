using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.World.Data.Disk.DataStorage;
using System.Collections.Generic;

namespace MagicalLifeAPI.Networking.Messages
{
    /// <summary>
    /// Used to describe the following messages that contain the world.
    /// </summary>
    [ProtoBuf.ProtoContract]
    public class WorldTransferHeaderMessage : BaseMessage
    {
        [ProtoBuf.ProtoMember(5)]
        public List<DimensionHeader> DimensionHeaders { get; private set; }

        public WorldTransferHeaderMessage(List<DimensionHeader> dimensionHeaders) : base(NetMessageID.WorldTransferHeaderMessage)
        {
            this.DimensionHeaders = dimensionHeaders;
        }

        public WorldTransferHeaderMessage() : base(NetMessageID.WorldTransferHeaderMessage)
        {
        }
    }
}