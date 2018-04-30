using MagicalLifeAPI.World.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Networking.Messages
{
    [ProtoBuf.ProtoContract]
    public class TileMessage : BaseMessage
    {
        [ProtoBuf.ProtoMember(1)]
        public Dirt tile;

        public ushort MessageType
        {
            get
            {
                return 0;
            }
        }

        public TileMessage(Dirt tile)
        {
            this.tile = tile;
        }

        public TileMessage()
        {

        }
    }
}
