using MagicalLifeAPI.Networking.Test;
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
    [ProtoContract]
    [ProtoInclude(3, typeof(ConcreteTest))]
    public class BaseMessage
    {
        /// <summary>
        /// The id of this base message. Used to determine what message to deserialize this into.
        /// </summary>
        [ProtoMember(1)]
        public UInt16 ID { get; }

        public BaseMessage(UInt16 id)
        {
            this.ID = id;
        }
    }
}
