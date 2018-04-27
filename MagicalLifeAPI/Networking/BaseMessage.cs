using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Networking
{
    /// <summary>
    /// The base of every message.
    /// </summary>
    public abstract class BaseMessage
    {
        [ProtoMember(1)]
        abstract public UInt16 MessageType { get; }
    }
}
