using MagicalLifeAPI.Networking.Serialization;
using ProtoBuf;
using System;

namespace MagicalLifeAPI.Networking.Messages
{
    /// <summary>
    /// Sent by the client whenever a worker completes their job.
    /// </summary>
    [ProtoContract]
    public class JobCompletedMessage : BaseMessage
    {
        /// <summary>
        /// The ID of the completed <see cref="MagicalLifeAPI.Entity.AI.Job.Job"/>.
        /// </summary>
        [ProtoMember(1)]
        public Guid CompletedID { get; set; }

        public JobCompletedMessage(Guid completedID) : base(NetMessageID.JobCompletedMessage)
        {
            this.CompletedID = completedID;
        }

        public JobCompletedMessage() : base(NetMessageID.JobCompletedMessage)
        {

        }
    }
}
