using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Time
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
        public static Scheduler ServerScheduler = new Scheduler();

        /// <summary>
        /// The scheduler that only runs if the client is being hosted in this process.
        /// </summary>
        public static Scheduler ClientScheduler = new Scheduler();

        private readonly List<SchedulerTask> WaitingQueue = new List<SchedulerTask>();

        private UInt64 TickAt;

        private SchedulerTaskComparer Comparer = new SchedulerTaskComparer();

        /// <param name="tickCounter">The counter that ticks are to be based off of.</param>
        public Scheduler()
        {
        }

        /// <param name="tickAt">The tick that the system is now at.</param>
        public void Tick(UInt64 tickAt)
        {
            this.TickAt = tickAt;
            
            while (this.WaitingQueue.Count > 0)
            {
                SchedulerTask current = this.WaitingQueue[0];
                
                //If it's time to run that task.
                if (current.WakeUp <= tickAt)
                {
                    current.Task.Start();
                    this.WaitingQueue.RemoveAt(0);
                }
                else
                {
                    //Nothing else will be run since they are sorted
                    break;
                }
            }
        }

        /// <param name="ticksToWait">How many ticks to wait for.</param>
        public void AddTask(Task task, UInt64 ticksToWait)
        {
            UInt64 waitTick = this.TickAt + ticksToWait;
            SchedulerTask properTask = new SchedulerTask(waitTick, task);

            this.Insert(properTask, waitTick);
        }

        /// <summary>
        /// Inserts the <see cref="SchedulerTask"/> at the correct position so that it shall wait
        /// until <paramref name="tick"/> is reached. 
        /// </summary>
        /// <param name="task"></param>
        /// <param name="tick"></param>
        private void Insert(SchedulerTask task, UInt64 tick)
        {
            int index = this.WaitingQueue.BinarySearch(0, this.WaitingQueue.Count, task, this.Comparer);
            this.WaitingQueue.Insert(index, task);

            //int lowBound = 0;
            //int highBound = this.WaitingQueue.Count - 1;

            //while (lowBound != highBound)
            //{
            //    int half = (highBound + lowBound) / 2;

            //    SchedulerTask check = this.WaitingQueue[half];
            //    if (check.WakeUp > tick)
            //    {
            //        highBound = half;
            //    }
            //    if (check.WakeUp < tick)
            //    {
            //        lowBound = half;
            //    }
            //    if (check.WakeUp == tick)
            //    {
            //        //Set low and high bounds to equal half
            //        //Since we've found another that's waiting for the exact same tick as this task
            //        lowBound = half;
            //        highBound = half;
            //    }
            //}

            //this.WaitingQueue.Insert(highBound, task);
        }
    }
}
