using System.Collections.Generic;
using MLAPI.Networking.Serialization;
using MLAPI.World.Data.Disk.DataStorage;

namespace MLAPI.Networking.Messages
{
    /// <summary>
    /// Used to describe the following messages that contain the world.
    /// </summary>
    [ProtoBuf.ProtoContract]
    public class WorldTransferHeaderMessage : BaseMessage
    {
        [ProtoBuf.ProtoMember(5)]
        public List<DimensionHeader> DimensionHeaders { get; private set; }

        public WorldTransferHeaderMessage(List<DimensionHeader> dimensionHeaders)
            : base(NetMessageId.WorldTransferHeaderMessage)
        {
            this.DimensionHeaders = dimensionHeaders;
        }

        public WorldTransferHeaderMessage()
        {
            //Protobuf-net constructor.
        }
    }
}