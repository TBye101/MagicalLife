using MagicalLifeAPI.Filing.Logging;
using System;
using System.Collections.Generic;

namespace MagicalLifeAPI.Entity.AI.Task
{
    /// <summary>
    /// Manages all of the TaskDrivers for a player.
    /// </summary>
    public class TaskManager
    {
        public static TaskManager Manager = new TaskManager();

        public List<TaskDriver> TaskDrivers { get; private set; }

        private object syncObject = new object();

        public TaskManager()
        {
            this.TaskDrivers = new List<TaskDriver>();
        }

        public void AddTask(MagicalTask task)
        {
            this.TaskDrivers.Add(new TaskDriver(task));
            task.Completed += this.Task_Completed;
        }

        private void Task_Completed(MagicalTask task)
        {
            this.TaskDrivers.RemoveAll(x => x.Task.Equals(task));
        }

        /// <summary>
        /// Gets a task for the creature.
        /// This also reserves the task for the creature.
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public void AssignTask(Living l)
        {
                List<MagicalTask> allCompatibleTasks = new List<MagicalTask>();

                //Get all compatible jobs
                foreach (TaskDriver item in this.TaskDrivers)
                {
                    allCompatibleTasks.AddRange(item.GetCompatibleJobs(l));
                }

                foreach (MagicalTask item in allCompatibleTasks)
                {
                    //Has the job been reserved for the unemployed creature
                    if (item.ReservedFor == l.ID)
                    {
                        MasterLog.DebugWriteLine("Its been reserved for me: " + item.ID);
                        this.AssignJob(l, item);
                        return;
                    }
                }

                if (allCompatibleTasks.Count > 0)
                {
                    MagicalTask task = allCompatibleTasks[0];
                    this.AssignJob(l, task);

                    foreach (TaskDriver item in this.TaskDrivers)
                    {
                        this.ReserveBoundTree(l, task.BoundID, item.Task);
                    }
            }
        }

        /// <summary>
        /// Reserve all tasks bound with the specified boundID for the specified creature.
        /// </summary>
        /// <param name="task"></param>
        /// <param name="boundID"></param>
        /// <param name="l"></param>
        /// <param name="recursionTask">The task to recurse over.</param>
        private void ReserveBoundTree(Living l, Guid boundID, MagicalTask recursionTask)
        {
            //If the same creature that needs to do the parent task needs to do the child task too...
            if (recursionTask.BoundID.Equals(boundID))
            {
                recursionTask.ReservedFor = l.ID;
            }

            if (recursionTask.Dependencies.PreRequisite.Count > 0)
            {
                foreach (MagicalTask item in recursionTask.Dependencies.PreRequisite)
                {
                    this.ReserveBoundTree(l, boundID, item);
                }
            }
        }

        private void AssignJob(Living l, MagicalTask task)
        {
            MasterLog.DebugWriteLine("Assigning job: " + task.ID);
            MasterLog.DebugWriteLine("Assigning job to: " + l.ID);
            l.AssignTask(task);
            task.MakePreparations(l);
            task.ToilingWorker = l.ID;
        }
    }
}