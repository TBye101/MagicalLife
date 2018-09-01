using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Entity.AI.Task
{
    /// <summary>
    /// Represents a task for the player to do.
    /// </summary>
    [ProtoContract]
    public abstract class MagicalTask
    {
        /// <summary>
        /// The dependencies of this task.
        /// </summary>
        [ProtoMember(1)]
        public Dependencies Dependencies { get; private set; }

        [ProtoMember(2)]
        public Guid ID { get; private set; }

        [ProtoMember(3)]
        public Guid BoundID { get; private set; }

        /// <param name="preRequisites">The dependencies of this task.</param>
        /// <param name="boundID">An ID used to determine if multiple tasks must be completed by the same worker.
        /// If multiple tasks have the same <paramref name="boundID"/>,
        /// then they must all be completed by the same worker.</param>
        public MagicalTask(Dependencies preRequisites, Guid boundID)
        {
            this.Dependencies = preRequisites;
            this.BoundID = boundID;
        }

        /// <param name="preRequisites">The dependencies of this task.</param>
        public MagicalTask(Dependencies preRequisites)
        {
            this.Dependencies = preRequisites;
        }

        public MagicalTask()
        {
            //Protobuf-net Constructor
        }

        /// <summary>
        /// Make any preparations required to execute the job in this method.
        /// </summary>
        /// <param name="l"></param>
        public abstract void MakePreperations(Living l);

        /// <summary>
        /// Every server tick that the creature does its job.
        /// </summary>
        /// <param name="l"></param>
        public abstract void Tick(Living l);
    }
}
