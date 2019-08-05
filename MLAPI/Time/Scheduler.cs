using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MLAPI.Time
{
    /// <summary>
    /// Used to schedule when things are run,
    /// in order to allow some things to not even check if they should be running.
    /// </summary>
    public class Scheduler
    {
        /// <summary>
        /// The scheduler that only runs if the server is being hosted in this process.
        /// </summary>
        public static Scheduler MainScheduler = new Scheduler();

        private readonly List<SchedulerTask> WaitingQueue = new List<SchedulerTask>();

        private UInt64 TickAt;

        private readonly SchedulerTaskComparer Comparer = new SchedulerTaskComparer();

        /// <param name="tickCounter">The counter that ticks are to be based off of.</param>
        public Scheduler()
        {
        }

        /// <param name="tickAt">The tick that the system is now at.</param>
        public void Tick(UInt64 tickAt)
        {
            this.TickAt = tickAt;

            SchedulerTask current;
            while (this.WaitingQueue.Count > 0 && this.WaitingQueue[0].WakeUp <= tickAt)
            {
                current = this.WaitingQueue[0];

                //It's time to run that task.
                Task.Run(current.Task);
                this.WaitingQueue.RemoveAt(0);
            }
        }

        /// <param name="ticksToWait">How many ticks to wait for.</param>
        public void AddTask(Action task, UInt64 ticksToWait)
        {
            UInt64 waitTick = this.TickAt + ticksToWait;
            SchedulerTask properTask = new SchedulerTask(waitTick, task);

            this.Insert(properTask);
        }

        /// <summary>
        /// Inserts the <see cref="SchedulerTask"/> at the correct position so that it shall wait
        /// until <paramref name="tick"/> is reached. 
        /// </summary>
        /// <param name="task"></param>
        /// <param name="tick"></param>
        private void Insert(SchedulerTask task)
        {
            int index = this.WaitingQueue.BinarySearch(0, this.WaitingQueue.Count, task, this.Comparer);
            this.WaitingQueue.Insert(index, task);
        }
    }
}
