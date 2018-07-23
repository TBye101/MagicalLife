using MagicalLifeAPI.Networking.Messages;
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

        /// <summary>
        /// The ID of the player that sent this message.
        /// </summary>
        [ProtoMember(2)]
        public Guid PlayerID { get; }

        public BaseMessage(UInt16 id)
        {
            this.ID = id;
            this.PlayerID = MagicalLifeSettings.Storage.Player.Default.PlayerID;
        }

        public BaseMessage()
        {
        }
    }
}