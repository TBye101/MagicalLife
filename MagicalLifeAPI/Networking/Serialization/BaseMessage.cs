using MagicalLifeAPI.Networking.Messages;
using ProtoBuf;
using System;

namespace MagicalLifeAPI.Networking.Serialization
{
    /// <summary>
    /// The base of every message.
    /// </summary>
    [ProtoContract]
    //[ProtoInclude(2, typeof(WorldTransferMessage))]
    //[ProtoInclude(3, typeof(RouteCreatedMessage))]
    //[ProtoInclude(4, typeof(ServerTickMessage))]
    //[ProtoInclude(5, typeof(ClientWorldConfirmation))]
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