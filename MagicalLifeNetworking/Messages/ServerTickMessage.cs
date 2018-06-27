using MagicalLifeAPI.Networking;
using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeNetworking.Serialization;
using ProtoBuf;
using System;

namespace MagicalLifeNetworking.Messages
{
    [ProtoContract]
    public class ServerTickMessage : BaseMessage
    {
        /// <summary>
        /// The tick that the server is on.
        /// </summary>
        [ProtoMember(1)]
        public UInt64 Tick;

        public ServerTickMessage() : base(4)
        {
        }

        public ServerTickMessage(UInt64 tick) : base(4)
        {
            this.Tick = tick;
        }
    }
}