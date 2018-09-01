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
        public delegate void CompletionEventHandler(MagicalTask task);

        /// <summary>
        /// This event is raised when this task has finished.
        /// </summary>
        public event CompletionEventHandler Completed;

        /// <summary>
        /// The dependencies of this task.
        /// </summary>
        [ProtoMember(1)]
        public Dependencies Dependencies { get; private set; }

        [ProtoMember(2)]
        public Guid ID { get; private set; }

        /// <summary>
        /// An ID used to determine if multiple tasks must be completed by the same worker.
        /// If multiple tasks have the same BoundID, then they must all be completed by the same worker.
        /// </summary>
        [ProtoMember(3)]
        public Guid BoundID { get; private set; }

        /// <summary>
        /// The criteria to determine if a worker is qualified to do a job.
        /// </summary>
        [ProtoMember(4)]
        public Qualification Qualifications { get; private set; }

        /// <summary>
        /// The ID of the worker assigned to work on this <see cref="MagicalTask"/>.
        /// Will equal <see cref="Guid.Empty"/> if no worker is assigned.
        /// </summary>
        [ProtoMember(5)]
        public Guid ToilingWorker { get; private set; }

        /// <param name="preRequisites">The dependencies of this task.</param>
        /// <param name="boundID">An ID used to determine if multiple tasks must be completed by the same worker.
        /// If multiple tasks have the same <paramref name="boundID"/>,
        /// then they must all be completed by the same worker.</param>
        public MagicalTask(Dependencies preRequisites, Guid boundID, List<Qualification> qualifications)
            : this(preRequisites, qualifications)
        {
            this.BoundID = boundID;
        }

        /// <param name="preRequisites">The dependencies of this task.</param>
        public MagicalTask(Dependencies preRequisites, List<Qualification> qualifications)
        {
            this.Dependencies = preRequisites;
        }

        public MagicalTask()
        {
            //Protobuf-net Constructor
        }

        protected void CompleteTask()
        {
            this.Completed?.Invoke(this);
        }

        /// <summary>
        /// Assigns this task to the provided creature.
        /// </summary>
        /// <param name="l"></param>
        public void AssignTask(Living l)
        {
            this.ToilingWorker = l.ID;
        }

        /// <summary>
        /// Make any preparations required to execute the job in this method.
        /// </summary>
        /// <param name="l"></param>
        public abstract void MakePreparations(Living l);

        /// <summary>
        /// Resets the task, in order to prepare for something such as the assigned creature dying.
        /// </summary>
        public abstract void Reset();

        /// <summary>
        /// Every server tick that the creature does its job.
        /// </summary>
        /// <param name="l"></param>
        public abstract void Tick(Living l);
    }
}
