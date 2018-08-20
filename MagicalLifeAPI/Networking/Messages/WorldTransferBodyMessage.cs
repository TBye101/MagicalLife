using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.World.Data;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Networking.Messages
{
    [ProtoContract]
    public class WorldTransferBodyMessage : BaseMessage
    {
        [ProtoMember(1)]
        public Chunk Chunk { get; private set; }

        public WorldTransferBodyMessage(Chunk chunk) : base(NetMessageID.WorldTransferBodyMessage)
        {
            this.Chunk = chunk;
        }

        protected WorldTransferBodyMessage() : base(NetMessageID.WorldTransferBodyMessage)
        {

        }
    }
}
