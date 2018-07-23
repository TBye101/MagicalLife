using MagicalLifeAPI.Entities;
using MagicalLifeAPI.Entity.AI.Job;
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
        public List<Living> Busy { get; private set; }

        /// <summary>
        /// All of the workers in this list need a job.
        /// </summary>
        public List<Living> Idle { get; private set; }

        public JobSystem(List<Living> workers, Guid playerID)
        {
            this.NoDependencies = new Dictionary<Guid, Job>();
            this.WithDependencies = new Dictionary<Guid, Job>();
            this.InProgress = new Dictionary<Guid, Job>();

            this.Busy = new List<Living>();
            this.Idle = new List<Living>();

            this.Idle.AddRange(workers);
            this.PlayerID = playerID;
            this.CommonSetup();
        }

        public JobSystem()
        {
            this.CommonSetup();
        }

        protected void CommonSetup()
        {
            MagicalLifeServer.Server.ServerTick += this.Server_ServerTick;
        }

        private void Server_ServerTick(object sender, ulong e)
        {
        }

        /// <summary>
        /// Handles when a job is completed.
        /// </summary>
        /// <param name="ID"></param>
        public void MarkJobAsComplete(Guid ID)
        {
            this.InProgress[ID].RaiseJobCompleted(ID);
            this.InProgress.Remove(ID);
        }

        private void StartJob(Job job, Living living)
        {
            ServerSendRecieve.Send(new JobAssignedMessage(living, job), this.PlayerID);
        }

        public void AddJob(KeyValuePair<Guid, Job> job)
        {
            if (job.Value.Dependencies.Count > 0)
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
            Job job = this.WithDependencies[ID];
            this.WithDependencies.Remove(ID);
            this.NoDependencies.Add(ID, job);
        }
    }
}
