using MagicalLifeAPI.Entities;
using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Networking.Server;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Entity.AI.Job
{
    /// <summary>
    /// Manages all jobs for a single player
    /// </summary>
    [ProtoContract]
    public class JobSystem
    {
        /// <summary>
        /// Jobs that are available to start, with no unresolved dependencies.
        /// </summary>
        [ProtoMember(1)]
        public List<Job> NoDependencies { get; private set; }

        /// <summary>
        /// Jobs that are awaiting the resolution of their dependencies.
        /// </summary>
        [ProtoMember(2)]
        public List<Job> WithDependencies { get; private set; }

        /// <summary>
        /// Jobs that are currently in progress.
        /// </summary>
        [ProtoMember(3)]
        public List<Job> InProgress { get; private set; }

        /// <summary>
        /// The player that this <see cref="JobSystem"/> manages workers for.
        /// </summary>
        [ProtoMember(4)]
        public Guid PlayerID { get; private set; }

        /// <summary>
        /// All of the workers/living within this <see cref="JobSystem"/>.
        /// All of these workers are under control of the same player. 
        /// </summary>
        public List<Living> Workers { get; private set; }

        public JobSystem(List<Living> workers, Guid playerID)
        {
            this.NoDependencies = new List<Job>();
            this.Workers = workers;
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

        private void DoJobs()
        {
        }

        private void StartJob(Job job, Living living)
        {
            ServerSendRecieve.Send(new JobAssignedMessage(living, job), this.PlayerID);
        }

        public void AddJob(Job job)
        {
            if (job.Dependencies.Count > 0)
            {
                job.DependenciesResolved += this.Job_DependenciesResolved;
                this.WithDependencies.Add(job);

                foreach (Job item in job.Dependencies)
                {
                    this.AddJob(item);
                }
            }
            else
            {
                this.NoDependencies.Add(job);
            }
        }

        private void Job_JobComplete(object sender, Job e)
        {
            this.InProgress.Remove(e);
        }

        private void Job_DependenciesResolved(object sender, Job e)
        {
            this.WithDependencies.Remove(e);
            this.NoDependencies.Add(e);
        }
    }
}
