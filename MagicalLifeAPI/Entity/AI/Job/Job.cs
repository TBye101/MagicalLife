using MagicalLifeAPI.Entity.AI.Job.Jobs;
using MagicalLifeAPI.Networking.Client;
using MagicalLifeAPI.Networking.Messages;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MagicalLifeAPI.Entity.AI.Job
{
    /// <summary>
    /// Everything a <see cref="Living"/> does is a job. From construction, to hauling, to casting spells.
    /// At some point, all implementers of <see cref="Job"/> must call <see cref="CompleteJob"/>.
    /// </summary>
    [ProtoContract]
    [ProtoInclude(7, typeof(BecomeAdjacentJob))]
    [ProtoInclude(8, typeof(MineJob))]
    [ProtoInclude(9, typeof(MoveJob))]
    public abstract class Job
    {
        /// <summary>
        /// Raised by a job when all of its dependencies have been completed, and the job is ready to be done by a worker.
        /// </summary>
        public event EventHandler<Guid> DependenciesResolved;

        /// <summary>
        /// Raised by a job when it is done.
        /// </summary>
        public event EventHandler<Tuple<Guid, Living>> JobComplete;

        /// <summary>
        /// The dependencies that must be resolved before this job can begin.
        /// </summary>
        [ProtoMember(1)]
        public Dictionary<Guid, Job> Dependencies { get; private set; }

        /// <summary>
        /// The ID of the creature that is assigned to do this job.
        /// </summary>
        [ProtoMember(3)]
        public Guid AssignedWorker { get; private set; } = Guid.Empty;

        [ProtoMember(4)]
        public bool RequireSameWorker { get; private set; }

        [ProtoMember(5)]
        public Guid ParentJob { get; private set; }

        private bool DependResolved = false;
        private bool Done = false;

        private readonly object SyncObject = new object();

        /// <summary>
        /// Used when all components of the job must be completed by the same character.
        /// </summary>
        [ProtoMember(6)]
        private Job CurrentTask;

        [ProtoMember(10)]
        public Guid ID { get; }

        /// <param name="dependencies"></param>
        /// <param name="requireSameWorker">If true, the same worker must do all steps of this job in order all at once.</param>
        protected Job(Dictionary<Guid, Job> dependencies, bool requireSameWorker)
        {
            this.ID = Guid.NewGuid();
            this.Dependencies = dependencies;
            this.RequireSameWorker = requireSameWorker;
        }

        protected Job(bool requireSameWorker)
        {
            this.ID = Guid.NewGuid();
            this.RequireSameWorker = requireSameWorker;
        }

        protected Job()
        {
            //Protobuf-net constructor
        }

        public void RaiseJobCompleted(Tuple<Guid, Living> e)
        {
            this.JobComplete?.Invoke(this, e);
        }

        private void Item_JobComplete(object sender, Tuple<Guid, Living> e)
        {
            this.Dependencies.Remove(e.Item1);

            if (!this.DependResolved && this.Dependencies.Count == 0)
            {
                this.DependResolved = true;

                if (!this.RequireSameWorker)
                {
                    this.DependenciesResolvedHandler(this.ID);
                }
                else
                {
                    this.CurrentTask = null;
                    this.StartJob(e.Item2);
                }
            }
        }

        private void DependenciesResolvedHandler(Guid id)
        {
            this.DependenciesResolved?.Invoke(this, id);
        }

        /// <summary>
        /// This method should be called by the client whenever this job is done.
        /// </summary>
        protected void CompleteJob(Living living)
        {
            lock (this.SyncObject)
            {
                if (!this.Done && !this.RequireSameWorker || this.ParentJob == Guid.Empty)
                {
                    this.Done = true;
                    living.Task = null;
                    ClientSendRecieve.Send<JobCompletedMessage>(new JobCompletedMessage(this.ID));
                }
                else
                {
                    this.RaiseJobCompleted(new Tuple<Guid, Living>(this.ID, living));
                }
            }
        }

        /// <summary>
        /// Called one time before an entity begins work on this job.
        /// </summary>
        protected abstract void StartJob(Living living);

        public void BeginJob(Living living)
        {
            if (this.Dependencies != null)
            {
                foreach (KeyValuePair<Guid, Job> item in this.Dependencies)
                {
                    item.Value.JobComplete += this.Item_JobComplete;
                    item.Value.ParentJob = this.ID;
                }
            }

            if (this.RequireSameWorker)
            {
                if (this.Dependencies.Count > 0)
                {
                    this.CurrentTask = this.GetNextDependency();
                    this.CurrentTask.StartJob(living);
                }
                else
                {
                    this.StartJob(living);
                }
            }
            else
            {
                this.StartJob(living);
            }
        }

        /// <summary>
        /// Gets the next dependency to work on.
        /// </summary>
        /// <returns></returns>
        private Job GetNextDependency()
        {
            Job job = this.Dependencies.ElementAt(0).Value;

            if (job.Dependencies != null && job.Dependencies.Count > 0)
            {
                return this.GetNextDependency();
            }

            return job;
        }

        /// <summary>
        /// Called every tick.
        /// </summary>
        protected abstract void JobTick(Living living);

        public void DoJob(Living living)
        {
            if (this.RequireSameWorker)
            {
                if (this.CurrentTask != null)
                {
                    this.CurrentTask.DoJob(living);
                }
                else
                {
                    if (this.Dependencies != null && this.Dependencies.Count != 0)
                    {
                        this.CurrentTask = this.GetNextDependency();
                        this.CurrentTask.StartJob(living);
                    }
                    else
                    {
                        this.JobTick(living);
                    }
                }
            }
            else
            {
                this.JobTick(living);
            }
        }

        /// <summary>
        /// Allows the job to re-evaluate if it has dependencies before the job starts, and allows adapting to changing conditions.
        /// </summary>
        public abstract void ReevaluateDependencies();

        /// <summary>
        /// Locks this job to be completed only by a creature with the specified ID, and begins job execution.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool AssignJob(Living living)
        {
            if (this.AssignedWorker == Guid.Empty)
            {
                this.AssignedWorker = living.ID;

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Unlocks this job so that any living can complete it now.
        /// </summary>
        public void FreeJob()
        {
            this.AssignedWorker = Guid.Empty;
        }
    }
}