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

        internal List<TaskDriver> TaskDrivers { get; private set; }

        private readonly object SyncObject = new object();

        public TaskManager()
        {
            this.TaskDrivers = new List<TaskDriver>();
        }

        public void AddTask(MagicalTask task)
        {
            lock (this.SyncObject)
            {
                this.TaskDrivers.Add(new TaskDriver(task));
                task.Completed += this.Task_Completed;
            }
        }

        private void Task_Completed(MagicalTask task)
        {
            lock (this.SyncObject)
            {
                this.TaskDrivers.RemoveAll(x => x.Task.Equals(task));
            }
        }

        /// <summary>
        /// A comparator used to compare magical tasks.
        /// Determines whether x is greater than, less than, or equal to y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private static int CompareTasks(MagicalTask x, MagicalTask y)
        {
            int equal = 0; //x and y are equal.
            int lessThan = 1; //x is less than y.
            int greaterThan = -1; //x is greater than y.

            if (x == null || y == null)
            {
                if (x == null && y != null)
                {
                    return lessThan; //x is less than y.
                }
                if (x != null && y == null)
                {
                    return greaterThan; //x is greater than y.
                }

                return equal; //They are both null.
            }
            else
            {
                if (x.TaskPriority == y.TaskPriority)
                {
                    return equal; //They are equal in priority.
                }
                if (x.TaskPriority > y.TaskPriority)
                {
                    return greaterThan; //x is greater in priority.
                }
                else
                {
                    return lessThan; //x is less than y.
                }
            }
        }

        /// <summary>
        /// Gets a task for the creature.
        /// This also reserves the task for the creature.
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        internal void AssignTask(Living l)
        {
            lock (this.SyncObject)
            {
                List<MagicalTask> allCompatibleTasks = new List<MagicalTask>();

                //Get all compatible jobs
                foreach (TaskDriver item in this.TaskDrivers)
                {
                    allCompatibleTasks.AddRange(item.GetCompatibleJobs(l));
                }

                if (allCompatibleTasks.Count > 0)
                {
                    allCompatibleTasks.Sort(CompareTasks);
                }

                foreach (MagicalTask item in allCompatibleTasks)
                {
                    //Has the job been reserved for the unemployed creature
                    if (item.ReservedFor == l.ID)
                    {
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
            l.AssignTask(task);
            task.MakePreparations(l);
            task.ToilingWorker = l.ID;
        }
    }
}