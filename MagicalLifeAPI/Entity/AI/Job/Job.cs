using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entities;
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
    /// </summary>
    [ProtoContract]
    public abstract class Job : Unique
    {
        /// <summary>
        /// Raised by a job when all of its dependencies have been completed, and the job is ready to be done by a worker.
        /// </summary>
        public event EventHandler<Job> DependenciesResolved;

        /// <summary>
        /// Raised by a job when it is done.
        /// </summary>
        public event EventHandler<Job> JobComplete;

        /// <summary>
        /// The dependencies that must be resolved before this job can begin.
        /// </summary>
        [ProtoMember(1)]
        public List<Job> Dependencies { get; private set; }

        /// <summary>
        /// The ID of the creature that is assigned to do this job.
        /// </summary>
        [ProtoMember(3)]
        public Guid AssignedWorker { get; private set; } = Guid.Empty;

        /// <summary>
        /// The location of the worker that is doing this job.
        /// </summary>
        [ProtoMember(4)]
        public Point2D Location { get; private set; }

        public Job(List<Job> dependencies)
        {
            this.Dependencies = dependencies;

            foreach (Job item in this.Dependencies)
            {
                item.JobComplete += this.Item_JobComplete;
            }
        }

        private void Item_JobComplete(object sender, Job e)
        {
            this.Dependencies.Remove(e);

            if (this.Dependencies.Count == 0)
            {
                this.DependenciesResolvedHandler(this);
            }
        }

        private void DependenciesResolvedHandler(Job job)
        {
            this.DependenciesResolved?.Invoke(this, job);
        }

        /// <summary>
        /// This method should be called whenever this job is done.
        /// </summary>
        protected void CompleteJob()
        {
            this.JobComplete?.Invoke(this, this);
        }

        public Job()
        {

        }

        /// <summary>
        /// Called one time before an entity begins work on this job.
        /// </summary>
        public abstract void BeginJob(Living living);

        /// <summary>
        /// Called every tick.
        /// </summary>
        public abstract void DoJob(Living living);

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
