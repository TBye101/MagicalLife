using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.Registry.ItemRegistry;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Networking.Messages
{
    [ProtoContract]
    public class WorldTransferRegistryMessage : BaseMessage
    {
        [ProtoMember(1)]
        public ItemRegistry ItemReg { get; private set; }

        public WorldTransferRegistryMessage(ItemRegistry itemReg) : base(NetMessageID.WorldTransferRegistryMessage)
        {
            this.ItemReg = itemReg;
        }
        public WorldTransferRegistryMessage() : base(NetMessageID.WorldTransferRegistryMessage)
        {
        }
    }
}
