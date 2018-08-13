using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.World.Data;
using System.Collections.Generic;

namespace MagicalLifeAPI.Networking.Messages
{
    /// <summary>
    /// Generally used to transfer the world over to the client.
    /// </summary>
    [ProtoBuf.ProtoContract]
    public class WorldTransferMessage : BaseMessage
    {
        [ProtoBuf.ProtoMember(5)]
        public List<Dimension> World;

        public WorldTransferMessage(List<Dimension> world) : base(NetMessageID.WorldTransferMessage)
        {
            this.World = world;
        }

        public WorldTransferMessage() : base(NetMessageID.WorldTransferMessage)
        {
        }
    }
}