using MagicalLifeAPI.Entity.AI.Task.Tasks;
using ProtoBuf;
using System;
using System.Collections.Generic;

namespace MagicalLifeAPI.Entity.AI.Task
{
    /// <summary>
    /// Represents a task for the player to do.
    /// </summary>
    [ProtoContract]
    [ProtoInclude(8, typeof(BecomeAdjacentTask))]
    [ProtoInclude(9, typeof(MoveTask))]
    [ProtoInclude(10, typeof(HarvestTask))]
    [ProtoInclude(11, typeof(DropItemTask))]
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
        public List<Qualification> Qualifications { get; private set; }

        /// <summary>
        /// The ID of the worker this task has been reserved for.
        /// Will equal <see cref="Guid.Empty"/> if no worker is assigned.
        /// </summary>
        [ProtoMember(5)]
        public Guid ReservedFor { get; set; }

        /// <summary>
        /// The ID of the worker that is currently working on this task.
        /// </summary>
        [ProtoMember(6)]
        public Guid ToilingWorker { get; set; }

        /// <summary>
        /// The priority of this task compared to other tasks.
        /// </summary>
        [ProtoMember(7)]
        public int TaskPriority { get; set; }

        /// <param name="preRequisites">The dependencies of this task.</param>
        /// <param name="boundID">An ID used to determine if multiple tasks must be completed by the same worker.
        /// If multiple tasks have the same <paramref name="boundID"/>,
        /// then they must all be completed by the same worker.</param>
        protected MagicalTask(Dependencies preRequisites, Guid boundID, List<Qualification> qualifications, int taskPriority)
            : this(preRequisites, qualifications)
        {
            this.BoundID = boundID;
            this.TaskPriority = taskPriority;
        }

        /// <param name="preRequisites">The dependencies of this task.</param>
        private MagicalTask(Dependencies preRequisites, List<Qualification> qualifications)
        {
            this.Dependencies = preRequisites;
            this.Qualifications = qualifications;
            this.ReservedFor = Guid.Empty;
            this.ID = Guid.NewGuid();
            this.ToilingWorker = Guid.Empty;
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
            this.ReservedFor = l.ID;
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