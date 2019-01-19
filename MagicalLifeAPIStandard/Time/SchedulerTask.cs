using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Time
{
    /// <summary>
    /// Used to hold information needed to start a task from the scheduler.
    /// </summary>
    public struct SchedulerTask
    {
        /// <summary>
        /// The tick to execute this task at.
        /// </summary>
        public UInt64 WakeUp;

        /// <summary>
        /// The task to run at the specified time.
        /// </summary>
        public Task Task;

        /// <param name="wakeUp">The tick to execute this task at.</param>
        /// <param name="task">The task to run at the specified time.</param>
        public SchedulerTask(UInt64 wakeUp, Task task)
        {
            this.WakeUp = wakeUp;
            this.Task = task;
        }
    }
}
