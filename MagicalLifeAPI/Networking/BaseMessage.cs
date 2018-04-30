using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicalLifeAPI.Networking.Messages;

namespace MagicalLifeAPI.Networking
{
    /// <summary>
    /// The base of every message.
    /// </summary>
    [ProtoInclude(7, typeof(TileMessage))]
    [ProtoContract]
    public class BaseMessage
    {
        [ProtoMember(1)]
        public UInt16 MessageType { get; }
    }
}
