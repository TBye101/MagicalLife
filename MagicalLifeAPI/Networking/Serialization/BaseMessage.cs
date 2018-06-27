using ProtoBuf;
using System;

namespace MagicalLifeAPI.Networking.Serialization
{
    /// <summary>
    /// The base of every message.
    /// </summary>
    [ProtoContract]
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

        public BaseMessage()
        {

        }
    }
}