using MagicalLifeAPI.Entity.AI.Job;
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
    /// Used to tell the server that a new job has been created.
    /// </summary>
    [ProtoContract]
    public class JobCreatedMessage : BaseMessage
    {
        [ProtoMember(1)]
        public Job Job { get; set; }

        public JobCreatedMessage(Job job) : base(8)
        {
            this.Job = job;
        }

        public JobCreatedMessage() : base(8)
        {
        }
    }
}
