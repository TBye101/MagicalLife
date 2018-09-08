using MagicalLifeAPI.Filing.Logging;
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
                    if (item.ToilingWorker == l.ID)
                    {
                        MasterLog.DebugWriteLine("Its been reserved for me: " + item.ID);
                        this.AssignJob(l, item);
                        return;
                    }
                }

                if (allCompatibleTasks.Count > 0)
                {
                    this.AssignJob(l, allCompatibleTasks[0]);
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