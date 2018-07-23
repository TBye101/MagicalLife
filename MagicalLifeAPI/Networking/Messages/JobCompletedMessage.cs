using MagicalLifeAPI.Networking.Serialization;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public JobCompletedMessage(Guid completedID) : base(7)
        {
            this.CompletedID = completedID;
        }
    }
}
