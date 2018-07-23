using MagicalLifeAPI.Networking.Serialization;
using ProtoBuf;
using System;

namespace MagicalLifeAPI.Networking.Messages
{
    /// <summary>
    /// Used by the client to tell the server which player in the game it is.
    /// </summary>
    [ProtoContract]
    public class LoginMessage : BaseMessage
    {
        [ProtoMember(1)]
        public Guid PlayerID { get; set; }

        public LoginMessage(Guid id) : base(6)
        {
            this.PlayerID = id;
        }

        public LoginMessage()
        {
        }
    }
}