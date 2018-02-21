using MagicalLifeAPI.Filing.Logging;
using System.Runtime.Remoting.Messaging;
using MagicalLifeAPI.Universal;
using MagicalLifeAPI.Util;
using System.Collections.Generic;

namespace MagicalLifeGUIWindows.Load
{
    /// <summary>
    /// Used to handle calculating how many jobs to do, and how many completed.
    /// </summary>
    public class LoadMoniter
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
        private Queue<IGameLoader> Jobs { get; set; } = new Queue<IGameLoader>();

        /// <summary>
        /// Adds a job to the queue.
        /// </summary>
        /// <param name="job"></param>
        public void AddJob(IGameLoader job)
        {
            this.JobCount += job.GetTotalOperations();
            this.Jobs.Enqueue(job);
        }

        public void AddJobs(List<IGameLoader> jobs)
        {
            int jobsAdded = 0;

            foreach (IGameLoader item in jobs)
            {
                jobsAdded += item.GetTotalOperations();
            }

            Extensions.EnqueueCollection(this.Jobs, jobs);
            this.JobCount += jobsAdded;
        }

        /// <summary>
        /// Begins execution of the jobs.
        /// </summary>
        /// <param name="message"></param>
        public void ExecuteJobs(ref string message)
        {
            IGameLoader job;
            int progress;
            MasterLog.DebugWriteLine("Executing loading jobs!");

            while (this.Jobs.Count > 0)
            {
                progress = 0;
                job = this.Jobs.Dequeue();
                job.InitialStartup(ref progress);
                this.JobsCompleted += job.GetTotalOperations();
                message = this.JobsCompleted.ToString() + " out of " + this.JobCount.ToString() + " jobs completed";
                MasterLog.DebugWriteLine(message);
            }
        }
    }
}