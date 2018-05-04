using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Networking.Messages
{
    /// <summary>
    /// Generally used to transfer the world over to the client.
    /// </summary>
    [ProtoBuf.ProtoContract]
    public class WorldTransferMessage : BaseMessage
    {
        [ProtoBuf.ProtoMember(1)]
        public World.World World;

        public WorldTransferMessage(World.World world) : base(2)
        {
            this.World = world;
        }

        public WorldTransferMessage() : base(2)
        {

        }
    }
}
