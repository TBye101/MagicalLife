using System;
using MLAPI.Filing;
using MLAPI.Universal;
using ProtoBuf;

namespace MLAPI.Networking.Serialization
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
        public NetMessageId Id { get; }

        /// <summary>
        /// The ID of the player that sent this message.
        /// </summary>
        [ProtoMember(2)]
        public Guid PlayerId { get; }

        [ProtoMember(3)]
        public UInt64 TickSent { get; private set; }

        public BaseMessage(NetMessageId id)
        {
            this.Id = id;
            this.PlayerId = SettingsManager.PlayerSettings.Settings.PlayerId;
            this.TickSent = Uni.GameTick;
        }

        protected BaseMessage()
        {
            //Protobuf-net constructor.
        }
    }
}