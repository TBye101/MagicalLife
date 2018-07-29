using MagicalLifeAPI.Entities;
using MagicalLifeAPI.Entity.AI.Job;
using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Networking.Server;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeServer.JobSystem
{
    /// <summary>
    /// Manages all jobs for a single player's creatures.
    /// </summary>
    [ProtoContract]
    public class JobSystem
    {
        /// <summary>
        /// Jobs that are available to start, with no unresolved dependencies.
        /// </summary>
        [ProtoMember(1)]
        public Dictionary<Guid, Job> NoDependencies { get; private set; }

        /// <summary>
        /// Jobs that are awaiting the resolution of their dependencies.
        /// </summary>
        [ProtoMember(2)]
        public Dictionary<Guid, Job> WithDependencies { get; private set; }

        /// <summary>
        /// Jobs that are currently in progress.
        /// </summary>
        [ProtoMember(3)]
        public Dictionary<Guid, Job> InProgress { get; private set; }

        /// <summary>
        /// The player that this <see cref="JobSystem"/> manages workers for.
        /// </summary>
        [ProtoMember(4)]
        public Guid PlayerID { get; private set; }

        /// <summary>
        /// All of the workers in this list have a job and are working on it.
        /// </summary>
        [ProtoMember(5)]
        public Dictionary<Guid, Living> Busy { get; private set; }

        /// <summary>
        /// All of the workers in this list need a job.
        /// </summary>
        public Dictionary<Guid, Living> Idle { get; private set; }

        /// <summary>
        /// Used to synchronize <see cref="ManageJobs"/>.
        /// </summary>
        private object SyncObject { get; set; } = new object();

        public JobSystem(Dictionary<Guid, Living> workers, Guid playerID)
        {
            this.NoDependencies = new Dictionary<Guid, Job>();
            this.WithDependencies = new Dictionary<Guid, Job>();
            this.InProgress = new Dictionary<Guid, Job>();
            this.Busy = new Dictionary<Guid, Living>();
            this.Idle = new Dictionary<Guid, Living>();

            this.Idle = workers;
            this.PlayerID = playerID;
            this.CommonSetup();
        }

        public JobSystem()
        {
            this.CommonSetup();
        }

        protected void CommonSetup()
        {
        }

        /// <summary>
        /// Every tick this method assigns jobs to workers who do not have jobs, if possible.
        /// </summary>
        public void ManageJobs()
        {
            int i = 0;

            lock (this.SyncObject)
            {
                while (i != this.Idle.Count)
                {
                    Living worker = this.Idle.ElementAt(i).Value;

                    bool result = AssignJob(worker);

                    if (result)
                    {
                        Job job = worker.Task;
                        Type type = job.GetType();
                        MasterLog.DebugWriteLine("Worker received job: " + type.FullName);
                        this.Idle.Remove(worker.ID);
                        this.Busy.Add(worker.ID, worker);
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }

        /// <summary>
        /// Assigns a job that the creature is capable of doing. Returns whether or not this operation succeeded. 
        /// </summary>
        /// <param name="living"></param>
        /// <returns></returns>
        private bool AssignJob(Living living)
        {
            if (this.NoDependencies.Count > 0)
            {
                IEnumerable<KeyValuePair<Guid, Job>> result = this.NoDependencies.Take(1);
                KeyValuePair<Guid, Job> one = result.First();

                one.Value.ReevaluateDependencies();
                if (one.Value.Dependencies != null && one.Value.Dependencies.Count > 0)
                {
                    this.AddJob(one);
                    return this.AssignJob(living);
                }
                else
                {
                    one.Value.AssignJob(living);
                    this.InProgress.Add(one.Key, one.Value);
                    this.StartJob(one.Value, living);

                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Handles when a job is completed.
        /// </summary>
        /// <param name="ID"></param>
        public void MarkJobAsComplete(Guid ID)
        {
            lock (this.InProgress)
            {
                this.InProgress[ID].RaiseJobCompleted(ID);
                Guid workerID = this.InProgress[ID].AssignedWorker;

                this.InProgress.Remove(ID);
                Living worker = this.Busy[workerID];

                this.Busy.Remove(workerID);
                this.Idle.Add(workerID, worker);
                worker.Task = null;
            }
        }

        private void StartJob(Job job, Living living)
        {
            living.Task = job;
            ServerSendRecieve.Send(new JobAssignedMessage(living, job), this.PlayerID);
        }

        public void AddJob(KeyValuePair<Guid, Job> job)
        {
            if (job.Value.Dependencies != null && job.Value.Dependencies.Count > 0)
            {
                job.Value.DependenciesResolved += this.Job_DependenciesResolved;
                this.WithDependencies.Add(job.Key, job.Value);

                foreach (KeyValuePair<Guid, Job> item in job.Value.Dependencies)
                {
                    this.AddJob(item);
                }
            }
            else
            {
                this.NoDependencies.Add(job.Key, job.Value);
            }
        }

        private void Job_DependenciesResolved(object sender, Guid ID)
        {
            lock (this.WithDependencies)
            {
                Job job = this.WithDependencies[ID];
                this.WithDependencies.Remove(ID);
                this.NoDependencies.Add(ID, job);
            }
        }
    }
}
