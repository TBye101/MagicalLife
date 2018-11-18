using MagicalLifeAPI.Networking.Serialization;
using ProtoBuf;
using System;

namespace MagicalLifeAPI.Networking.Messages
{
    [ProtoContract]
    public class ServerTickMessage : BaseMessage
    {
        /// <summary>
        /// The tick that the server is on.
        /// </summary>
        [ProtoMember(5)]
        public UInt64 Tick;

        public ServerTickMessage() : base(NetMessageID.ServerTickMessage)
        {
        }

        public ServerTickMessage(UInt64 tick) : base(NetMessageID.ServerTickMessage)
        {
            this.Tick = tick;
        }
    }
}