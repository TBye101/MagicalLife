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
        public event EventHandler<Guid> JobComplete;

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

        private bool DependResolved = false;
        private bool Done = false;

        public Job(Dictionary<Guid, Job> dependencies)
        {
            this.Dependencies = dependencies;

            foreach (KeyValuePair<Guid, Job> item in this.Dependencies)
            {
                item.Value.JobComplete += this.Item_JobComplete;
            }
        }

        public void RaiseJobCompleted(Guid ID)
        {
            this.JobComplete?.Invoke(this, ID);
        }

        private void Item_JobComplete(object sender, Guid e)
        {
            if (!this.DependResolved)
            {
                this.DependResolved = true;
                this.Dependencies.Remove(e);

                if (this.Dependencies.Count == 0)
                {
                    this.DependenciesResolvedHandler(this.ID);
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
        protected void CompleteJob()
        {
            if (!this.Done)
            {
                this.Done = true;
                ClientSendRecieve.Send<JobCompletedMessage>(new JobCompletedMessage(this.ID));
            }
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
