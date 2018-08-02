using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entities;
using MagicalLifeAPI.Networking.Client;
using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Universal;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Entity.AI.Job
{
    /// <summary>
    /// Everything a <see cref="Living"/> does is a job. From construction, to hauling, to casting spells.
    /// At some point, all implementers of <see cref="Job"/> must call <see cref="CompleteJob"/>. 
    /// </summary>
    [ProtoContract]
    public abstract class Job : Unique
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

        /// <summary>
        /// Used when all components of the job must be completed by the same character.
        /// </summary>
        [ProtoMember(6)]
        private Job CurrentTask;

        /// <param name="dependencies"></param>
        /// <param name="requireSameWorker">If true, the same worker must do all steps of this job in order all at once.</param>
        public Job(Dictionary<Guid, Job> dependencies, bool requireSameWorker)
        {
            this.Dependencies = dependencies;
            this.RequireSameWorker = requireSameWorker;

            foreach (KeyValuePair<Guid, Job> item in this.Dependencies)
            {
                item.Value.JobComplete += this.Item_JobComplete;
                item.Value.ParentJob = this.ID;
            }
        }

        public Job(bool requireSameWorker)
        {
            this.RequireSameWorker = requireSameWorker;
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
            if (!this.Done && !this.RequireSameWorker || this.ParentJob == Guid.Empty)
            {
                this.Done = true;
                ClientSendRecieve.Send<JobCompletedMessage>(new JobCompletedMessage(this.ID));
            }
            else
            {
                this.RaiseJobCompleted(new Tuple<Guid, Living>(this.ID, living));
            }
        }

        /// <summary>
        /// Called one time before an entity begins work on this job.
        /// </summary>
        protected abstract void StartJob(Living living);

        public void BeginJob(Living living)
        {
            if (this.RequireSameWorker)
            {
                if (this.Dependencies.Count > 0)
                {
                    this.CurrentTask = this.GetNextDependency(this.Dependencies);
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
        private Job GetNextDependency(Dictionary<Guid, Job> dependencies)
        {
            Job job = this.Dependencies.ElementAt(0).Value;

            if (job.Dependencies != null && job.Dependencies.Count > 0)
            {
                return this.GetNextDependency(job.Dependencies);
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
                        this.CurrentTask = this.GetNextDependency(this.Dependencies);
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
                this.BeginJob(living);

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
