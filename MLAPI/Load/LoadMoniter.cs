using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.Util;
using System.Collections.Generic;

namespace MagicalLifeAPI.Load
{
    /// <summary>
    /// Used to handle calculating how many jobs to do, and how many completed.
    /// </summary>
    internal class LoadMoniter
    {
        /// <summary>
        /// The number of jobs total to do.
        /// </summary>
        private int JobCount = 0;

        /// <summary>
        /// The number of jobs that have been completed.
        /// </summary>
        private int JobsCompleted = 0;

        /// <summary>
        /// The jobs that are still queued up.
        /// </summary>
        private ProtoQueue<IGameLoader> Jobs { get; set; } = new ProtoQueue<IGameLoader>();

        /// <summary>
        /// Adds a job to the queue.
        /// </summary>
        /// <param name="job"></param>
        public void AddJob(IGameLoader job)
        {
            this.Jobs.Enqueue(job);
        }

        public void AddJobs(List<IGameLoader> jobs)
        {
            Extensions.EnqueueCollection(this.Jobs, jobs);
            this.JobCount = jobs.Count;
        }

        /// <summary>
        /// Begins execution of the jobs.
        /// </summary>
        /// <param name="message"></param>
        public void ExecuteJobs(ref string message)
        {
            IGameLoader job;
            MasterLog.DebugWriteLine("Executing loading jobs!");

            while (this.Jobs.Count > 0)
            {
                job = this.Jobs.Dequeue();
                job.InitialStartup();
                this.JobsCompleted++;
                message = this.JobsCompleted.ToString() + " out of " + this.JobCount.ToString() + " jobs completed";
                MasterLog.DebugWriteLine(message);
            }
        }
    }
}