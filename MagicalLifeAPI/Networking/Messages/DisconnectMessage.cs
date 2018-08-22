using MagicalLifeAPI.Networking.Serialization;
using ProtoBuf;
using System;

namespace MagicalLifeAPI.Networking.Messages
{
    /// <summary>
    /// Used by the API to tell the server that a specific client has disconnected.
    /// </summary>
    [ProtoContract]
    public class DisconnectMessage : BaseMessage
    {
        [ProtoMember(3)]
        public Guid ClientPlayerID { get; set; }

        /// <param name="playerID">The ID of the player client that is disconnecting.</param>
        public DisconnectMessage(Guid playerID) : base(NetMessageID.DisconnectMessage)
        {
            this.ClientPlayerID = playerID;
        }

        public DisconnectMessage() : base(NetMessageID.DisconnectMessage)
        {
        }
    }
}